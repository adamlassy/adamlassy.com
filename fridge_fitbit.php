<?php

//email: babbjw@gmail.com
//pw: undercurrent

function get_calories($dat,$objFitbit,$_sdb)
{

    // Base URL
    $baseUrl = 'http://api.fitbit.com';
    
    // Request token path
    $req_url = $baseUrl . '/oauth/request_token';

    // Authorization path
    $authurl = $baseUrl . '/oauth/authorize';

    // Access token path
    $acc_url = $baseUrl . '/oauth/access_token';

    // Consumer key
    $conskey = '2baf86f824bd42a489c49fe1714a47de';

    // Consumer secret
    $conssec = '79212ddbed1d4e3a846e6a6c32b11db0';

    //Get FitBit info
    $write_fitbit = false;

    $state = $objFitbit->Attribute[3]->Value;
    $status = $objFitbit->Attribute[0]->Value;
    $token = $objFitbit->Attribute[2]->Value;
    $secret = $objFitbit->Attribute[4]->Value;
    $calorie_limit = $objFitbit->Attribute[1]->Value;

    echo "<br>state: " . $state;
    echo "<br>status: " . $status;
    echo "<br>token: " . $token;
    echo "<br>secret: " . $secret;
    echo "<br>calorie_limit: " . $calorie_limi;

    // Fitbit API call (get activities for specified date)
    $apiCall = "http://api.fitbit.com/1/user/-/activities/date/" . $dat . ".xml";
    //$apiCall = "http://api.fitbit.com/1/user/-/activities/date/2012-05-08.xml";

    // Start session to store the information between calls
    //session_start();

    // In state=1 the next request should include an oauth_token.
    // If it doesn't go back to 0
    if ( !isset($_GET['oauth_token']) && $state==1 ) {
      $state = 0;
      $write_fitbit = true;
    }


    try 
    {
        // Create OAuth object
        $oauth = new OAuth($conskey,$conssec,OAUTH_SIG_METHOD_HMACSHA1,OAUTH_AUTH_TYPE_AUTHORIZATION);

        // Enable ouath debug (should be disabled in production)
        $oauth->enableDebug();

        if ( $state == 0 ) 
        {
            // Getting request token. Callback URL is the Absolute URL to which the server provder will redirect the User back when the obtaining user authorization step is completed.

	    $callbackUrl = "http://adamlassyphp.elasticbeanstalk.com/fridge.php";
            $request_token_info = $oauth->getRequestToken($req_url, $callbackUrl);

            // Storing key and state in a session.
            $secret = $request_token_info['oauth_token_secret'];
            $state = 1;
            sdb_fridge_set_fitbit($_sdb,$status,$token,$secret,$state,$calorie_limit);

            // Redirect to the authorization.
            header('Location: '.$authurl.'?oauth_token='.$request_token_info['oauth_token']);

            exit;
        } 
        else if ( $state==1 ) 
        {
            // Authorized. Getting access token and secret
            $oauth->setToken($_GET['oauth_token'],$secret);
            $access_token_info = $oauth->getAccessToken($acc_url);

            // Storing key and state in a session.
            $state = 2;
            $token = $access_token_info['oauth_token'];
            $secret = $access_token_info['oauth_token_secret'];
            $write_fitbit = true;
        } 

        // Setting asccess token to the OAuth object
        $oauth->setToken($token,$secret);

        // Performing API call 
        $oauth->fetch($apiCall);

        // Getting last response
        $response = $oauth->getLastResponse();

        // Initializing the simple_xml object using API response 
        $xml = simplexml_load_string($response);
    } 
    catch( OAuthException $E ) 
    {
        print_r($E);
    }

    //Now save the state
    if ($write_fitbit) 
      sdb_fridge_set_fitbit($_sdb,$status,$token,$secret,$state,$calorie_limit);
  
    return $xml->summary->caloriesOut;

}
