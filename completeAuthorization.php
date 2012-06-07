<?php
    //babbjw@gmail.com
    //undercurrent

    // Base URL
    $baseUrl = 'http://api.fitbit.com';
    
    // Request token path
    $req_url = $baseUrl . '/oauth/request_token';

    // Authorization path
    $authurl = $baseUrl . '/oauth/authorize';

    // Access token path
    $acc_url = $baseUrl . '/oauth/access_token';

    // Consumer key
    //$conskey = 'local-fitbit-example-php-client-application';
    $conskey = '2baf86f824bd42a489c49fe1714a47de';

    // Consumer secret
    //$conssec = 'e388e4f4d6f4cc10ff6dc0fd1637da370478e49e2';
    $conssec = '79212ddbed1d4e3a846e6a6c32b11db0';

    // Fitbit API call (get activities for specified date)
    $dat = date('Y-m-d');
    $apiCall = "http://api.fitbit.com/1/user/-/activities/date/" . $dat . ".xml";
    //$apiCall = "http://api.fitbit.com/1/user/-/activities/date/2012-05-08.xml";


    // Start session to store the information between calls
    session_start();

    if ($_GET['state'])
    {
      $state = $_GET['state'];
    }
    else
    {
      $state = $_SESSION['state'];
    }

    // In state=1 the next request should include an oauth_token.
    // If it doesn't go back to 0
    if ( !isset($_GET['oauth_token']) && $state==1 ) $state = 0;

    try 
    {
        // Create OAuth object
        $oauth = new OAuth($conskey,$conssec,OAUTH_SIG_METHOD_HMACSHA1,OAUTH_AUTH_TYPE_AUTHORIZATION);

        // Enable ouath debug (should be disabled in production)
        $oauth->enableDebug();

echo "STATE>" . $state;

        if ( $state == 0 ) 
        {
            // Getting request token. Callback URL is the Absolute URL to which the server provder will redirect the User back when the obtaining user authorization step is completed.

$callbackUrl = "http://adamlassyphp.elasticbeanstalk.com/completeAuthorization.php";
            $request_token_info = $oauth->getRequestToken($req_url, $callbackUrl);
echo "callback>" . $callbackUrl;

            // Storing key and state in a session.
            $_SESSION['secret'] = $request_token_info['oauth_token_secret'];
            $state = 1;

            // Redirect to the authorization.
            header('Location: '.$authurl.'?oauth_token='.$request_token_info['oauth_token']);
            //echo('Location: '.$authurl.'?oauth_token='.$request_token_info['oauth_token']);
            exit;
        } 
        else if ( $state==1 ) 
        {
            // Authorized. Getting access token and secret
            $oauth->setToken($_GET['oauth_token'],$_SESSION['secret']);
            $access_token_info = $oauth->getAccessToken($acc_url);

            // Storing key and state in a session.
            $_SESSION['state'] = 2;
           
	     $_SESSION['token'] = $access_token_info['oauth_token'];
             $_SESSION['secret'] = $access_token_info['oauth_token_secret'];
            
	     //$_SESSION['token'] = $_GET['token'];  //$access_token_info['oauth_token'];
             //$_SESSION['secret'] = $_GET['secret'];  //$access_token_info['oauth_token_secret'];
             
             $state = 2;
             //$token = $access_token_info['oauth_token'];
             //$secret = $access_token_info['oauth_token_secret'];
        } 

        if ($_GET['token'])
        {
             $token = $_GET['token'];
             $secret = $_GET['secret'];
        }

        // Setting asccess token to the OAuth object
        $oauth->setToken($_SESSION['token'],$_SESSION['secret']);
        //$oauth->setToken($token,$secret);

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

    $_SESSION['state'] = $state;
?>

<?php echo $xml->summary->caloriesOut ?>
