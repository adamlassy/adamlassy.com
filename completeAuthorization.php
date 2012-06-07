<?php

    echo "2";
    $b = $a;

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
    $apiCall = "http://api.fitbit.com/1/user/-/activities/date/2012-05-08.xml";

    // Start session to store the information between calls
    session_start();

    // In state=1 the next request should include an oauth_token.
    // If it doesn't go back to 0
    if ( !isset($_GET['oauth_token']) && $_SESSION['state']==1 ) $_SESSION['state'] = 0;

    try 
    {
        // Create OAuth object
        $oauth = new OAuth($conskey,$conssec,OAUTH_SIG_METHOD_HMACSHA1,OAUTH_AUTH_TYPE_AUTHORIZATION);

        // Enable ouath debug (should be disabled in production)
        $oauth->enableDebug();

echo "STATE>" . $_SESSION['state'];

        if ( $_SESSION['state'] == 0 ) 
        {
            // Getting request token. Callback URL is the Absolute URL to which the server provder will redirect the User back when the obtaining user authorization step is completed.

$callbackUrl = "http://adamlassyphp.elasticbeanstalk.com/completeAuthorization.php";
            $request_token_info = $oauth->getRequestToken($req_url, $callbackUrl);
echo "callback>" . $callbackUrl;

            // Storing key and state in a session.
            $_SESSION['secret'] = $request_token_info['oauth_token_secret'];
            $_SESSION['state'] = 1;

            // Redirect to the authorization.
            header('Location: '.$authurl.'?oauth_token='.$request_token_info['oauth_token']);
            //echo('Location: '.$authurl.'?oauth_token='.$request_token_info['oauth_token']);
            exit;
        } 
        else if ( $_SESSION['state']==1 ) 
        {
            // Authorized. Getting access token and secret
            $oauth->setToken($_GET['oauth_token'],$_SESSION['secret']);
            $access_token_info = $oauth->getAccessToken($acc_url);

            // Storing key and state in a session.
            $_SESSION['state'] = 2;
            $_SESSION['token'] = $access_token_info['oauth_token'];
            $_SESSION['secret'] = $access_token_info['oauth_token_secret'];
            
echo "<br>>" . $_SESSION['token'];
echo "<br>>" . $_SESSION['secret'];
        } 

        // Setting asccess token to the OAuth object
        $oauth->setToken($_SESSION['token'],$_SESSION['secret']);

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
?>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
  <head>
    <title>Fitbit Example</title>
  </head>
  <body>
  <!-- Show activities on the page -->
    Unit System: <?php echo $xml->unitSystem ?><br />
    Active Score: <?php echo $xml->summary->activeScore ?><br />
    Calories Out: <?php echo $xml->summary->caloriesOut ?><br />
    Fairly Active Minutes: <?php echo $xml->summary->fairlyActiveMinutes ?><br />
    Lightly Active Minutes: <?php echo $xml->summary->lightlyActiveMinutes ?><br />
    Very Active Minutes: <?php echo $xml->summary->veryActiveMinutes ?><br />    
    Sedentary Minutes: <?php echo $xml->summary->sedentaryMinutes ?><br />    
    Steps: <?php echo $xml->summary->steps ?><br />
    Distances:<br />
    <table border="1">
      <tr>
        <th>Activity</th>
        <th>Distance</th>
      </tr>
      <?php foreach ($xml->summary->distances->activityDistance as $distance) { ?>
        <tr>
          <td><?php echo $distance->activity ?></td>
          <td><?php echo $distance->distance ?></td>
        </tr>
      <?php } ?>
    </table>
  </body>
</html>
