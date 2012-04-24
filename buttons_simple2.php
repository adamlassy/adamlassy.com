<?php

if (stripos($_SERVER['REQUEST_URI'], 'staging') !== false) {
    # staging
    $facebook_app_id = '146959438681102';
    $facebook_api_key = '72f9e105e0c5d1dd5d7653da5db2a297';
    $facebook_api_secret = '3ca6614d5576bd2b22f586401a6d1db6';
    $app_url = 'http://discover-zvents.zvents.com/staging_zvents/';
} else {
    # production
    $facebook_app_id = '153096238040709';
    $facebook_api_key = '41cb94201fb3690267d85bacd4afed67';
    $facebook_api_secret = '2d5c6e9c94dba664b2f852fce45cf9ec';
    $app_url = 'http://discover-zvents.zvents.com/discover_zvents/';
}

include_once('facebook.php');

$facebook = new Facebook(array(
    'appId'  => $facebook_app_id,
    'secret' => $facebook_api_secret,
    'cookie' => true, // enable optional cookie support
));
$uid = $facebook->getUser();

$sequence_id = isset($_REQUEST['sid']) && $_REQUEST['sid'] ? $_REQUEST['sid'] : '';
if (!$sequence_id) {

    return_empty_page();
    exit();
}

$venue_name = "venue name";
$venue_city ="Los Angeles";
$venue_state = "CA";
$starttime = "start time";

# RSVP info

?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns:fb="http://www.facebook.com/2008/fbml" xmlns="http://www.w3.org/1999/xhtml">
<head>
    <style type="text/css">


        .facebook_button {
            background-color: #5B74A8;
            border-color: #29447E #29447E #1A356E;
            border-style: solid;
            border-width: 1px;
            color: #fff;
            display: inline-block;
            font-family: 'Lucida Grande', Tahoma, Verdana, Arial, sans-serif;
            font-size: 12px;
            font-weight: bold;
            margin-right: 8px;
            text-decoration: none;
            vertical-align: middle;
            -moz-border-radius: 3px;
            -webkit-border-radius: 3px;
            border-radius: 3px;
        }

        .facebook_button:hover {
            text-decoration: none;
            background-color: #8b99b9;
            border-color: #41578a;
        }

        .facebook_button span {
            display: block;
            border-top: 1px solid #8a9cc2;
            line-height: 17px;
            padding: 1px 6px;
            -moz-border-radius: 3px;
            -webkit-border-radius: 3px;
            border-radius: 3px;
        }

        .facebook_button:hover span {
            border-top-color: #c1c8d9;
        }

        #attending_status {
            color: #fff;
            padding-right: 1em;
        }

	#attending_value {
            color: #36C;
	}

        .hidden {
            display: none;
        }

    </style>
</head>
<body>
    <script type="text/javascript">
        var user_location = '';
        var ip = '<?=$_SERVER["REMOTE_ADDR"]?>';
        var facebook_permissions = '';
        var event_type = 'event_series';
        var tracking_tag = '';
        var event_image = '';
        var event_caption = '<?=urlencode("@ ".$venue_name.", ".$venue_city.", ".$venue_state.", ".$starttime)?>';
        var event_name = '<?=urlencode($event_name)?>';
        var event_name_escaped = "<?=htmlspecialchars_decode($event_name)?>";
        var event_description = '';
        var app_id = '<?=$facebook_app_id?>';
    </script>
    
    <div style="position:relative">

    <div id="attending_buttons">
        <a class="facebook_button attending" onClick="shareRSVP('I\'m going to ','Want to join?','I\'m Attending','<?=$id?>','<?=$sequence_id?>','','')">
            <span>I&rsquo;m Attending</span>
        </a>
        <a class="facebook_button maybe" onClick="shareRSVP('I might go to ','Want to join?','Maybe','','')">
            <span>Maybe</span>
        </a>
    </div>

    <span id="attending_status" class="hidden">
        Your RSVP status:
        <span id="attending_value"></span>
    </span>

    <fb:like style="position:absolute;top:1px;left:175px;" href="http://www.zvents.com/sequences/show/<?=$sequence_id?>" send="true" layout="button_count"></fb:like>

    </div>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.5.2/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">

    function setRSVP(rsvp_value)
    {
	$('#attending_buttons').addClass('hidden');
        $('#attending_status').removeClass('hidden');
	$('#attending_value').text(rsvp_value);
    }

    function shareRSVP(msg,linktext,rsvp_value,id,sid,caption,event_name) {       
                _gaq.push(['_trackPageview', '/share']);

		alert('http://discover-zvents.zvents.com/staging_zvents/?id=' + id + '&sid=' + sid);

                //Zvents.tracker.notifyClick({cm:'ad',from:'e:<?=$id?>',to:'/share'});    
                FB.ui(
                   {
                         method: 'feed',
                         //name: '<?=$event_name?>',
			 link: 'http://discover-zvents.zvents.com/staging_zvents/?id=' + id + '&sid=' + sid,
                         //link: 'http://apps.facebook.com/discover_zvents/?id=' + id + '&sid=' + sid,
                         //picture: '<?=$image?>',
                         caption: caption,
                         message: msg + event_name +'!'
                   },
                   function(response) {
                         if (response && response.post_id) {
    				setRSVP(rsvp_value)
				Zvents.Cookie.write_persistent('fb.rsvp.'+id+'.'+sid,rsvp_value);

                                _gaq.push(['_trackPageview', '/share/success', rsvp_value]);
                         } else {
                                _gaq.push(['_trackPageview', '/share/failure', rsvp_value]);                           
                         }
                   }
                 );
    }

    $(function(){
        var event_id = $('body').attr('data-event-id');
        var sid = $('body').attr('data-sid');

    });

var Zvents = window.Zvents || {};

$.extend(Zvents, {
    Cookie: {
        read: function(name) {
            var match = document.cookie.match(new RegExp(name + '=([^;]+)'));
            return match && unescape(match[1]);
        },
        write: function(name, value) {
            document.cookie = name + '=' + escape(value);
        },
        write_persistent: function(name, value) {
	    var expireDate = new Date();
	    expireDate.setYear(expireDate.getYear() + 1);
            document.cookie = name + '=' + escape(value) + ";expires=" + expireDate.toGMTString() + ";";
	}
    },
    performance: {
        documentReady: function() {
            if (!startTime) {
                return;
            }
            var loadTime = (new Date()).getTime() - startTime;
            $.get("/z/metrics/document-ready", {'loadTime': loadTime});
        }
    }
});
    </script>
    
    <div id="fb-root"></div>
    <script type="text/javascript">
        var fbAsyncInit = function(){
            FB.init({
                appId: '<?=$facebook_app_id?>',
                status: true, // check login status
                cookie: true, // enable cookies to allow the server to access the session
                xfbml: true,  // parse XFBML
                channelUrl: '<?=$app_url?>channel.html'
            });
            if (typeof onFacebookInit == 'function') {
                onFacebookInit();
            }
        };
        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-31999-114']);
        _gaq.push(['_trackEvent', 'event_detail', 'fb buttons show']);
        (function() {
            var e = document.createElement('script');
            e.async = true;
            e.src = document.location.protocol + '//connect.facebook.net/en_US/all.js';
            document.getElementById('fb-root').appendChild(e);
            var ga = document.createElement('script'); ga.type = 'text/javascript'; 
            ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0];
            s.parentNode.insertBefore(ga, s);
        })();

	val = Zvents.Cookie.read('fb.rsvp.<?=$id?>.<?=$sequence_id?>');

        if (val && val != "") {
		setRSVP(val);
        }

    </script>
</body>
</html>
