<?php
/*=================================================== Login Existing User ===============================================================*/
function login()
{
    //Check if Log In button is pressed
    if(isset($_POST['LogIn']))
    {
        //Get Form Input
        $username = $_POST['Username'];
        $username = stripslashes($username);
        $password = $_POST['Password'];
        $password = stripslashes($password);

        $_SESSION["username"] = $username;
        $_SESSION["isloggedin"] = "True";

        //Array Options    
        $arrContextOptions=array("ssl"=>array("verify_peer"=>false,"verify_peer_name"=>false,),);

        //Get REST API response
        $response = file_get_contents("https://localhost:7244/api/Shopinz/{$username}", false, stream_context_create($arrContextOptions));

        //Deserialize into Array
        $response = json_decode($response);

        //Decrypt Password$response->password
        $encryptedPassword = $response->password; // Replace with the encrypted password from the ASP.NET API
        $decryptedPassword = decryptCaesar($encryptedPassword,2);

        //Authentication
        if($password == $decryptedPassword)
        {
            //If the password matches, we need to session store the user has logged in, THEN redirect to the desired page
            //Session name as Username, and Logged in as true
            $_SESSION['login']=$username;
			$_SESSION["loggedIn"] = true;
            echo "Working!!!";
        }
        else
        {
            //test
            echo "Incorrect Password";
        }
    }
}

//================================================================= Decryptor ================================================================
function decryptCaesar($ciphertext, $shift) {
    $plaintext = "";
    $length = strlen($ciphertext);

    for ($i = 0; $i < $length; $i++) {
        $letter = $ciphertext[$i];

        if (ctype_alpha($letter)) {
            $offset = ctype_upper($letter) ? ord('A') : ord('a');
            $letter = chr((ord($letter) - $offset - $shift + 26) % 26 + $offset);
        }

        $plaintext .= $letter;
    }

    return $plaintext;
}

//================================================================ Get Recommended Product =====================================================

function GetRec()
{
    //Check if Log In button is pressed //Change
    if(isset($_POST['LogIn']))
    {
        //Get Form Input //Change
        $username = $_POST['Username'];
        $username = stripslashes($username);
        $password = $_POST['Password'];
        $password = stripslashes($password);


        //Array Options    
        $arrContextOptions=array("ssl"=>array("verify_peer"=>false,"verify_peer_name"=>false,),);

        //Get REST API response
        $response = file_get_contents("https://localhost:7259/api/ProRec/{$username}", false, stream_context_create($arrContextOptions));

        //Deserialize into Array
        $response = json_decode($response);

        //Get Product
        $productname = $response->productName;


    }
}

//======================================================================== Signup =============================================================

function Signup()
{
    //Check if Log In button is pressed //Change
    if(isset($_POST['Signup']))
    {
        //Get Form Input //Change
        $username = $_POST['Username'];
        $username = stripslashes($username);
        $password = $_POST['Password'];
        $password = stripslashes($password);
        $RePassword = $_POST['RePassword'];
        $RePassword = stripslashes($RePassword);
        $PrePro = $_POST['PrePro'];
        $PrePro = stripslashes($PrePro);
        $Blockw = $_POST['Blockw'];
        $Blockw = stripslashes($Blockw);


        $url = 'https://localhost:7244/api/Shopinz/';
        $data = array('username' => $username, 'password' => $password, 'personalcard' => $PrePro, 'Personalcode' => $Blockw);

        // use key 'http' even if you send the request to https://...
        $options = array(
            'http' => array(
                'header'  => "Content-type: application/x-www-form-urlencoded\r\n",
                'method'  => 'POST',
                'content' => http_build_query($data)
            )
        );
        $context  = stream_context_create($options);
        $result = file_get_contents($url, false, $context);
        if ($result === FALSE) { /* Handle error */ }

        var_dump($result);

                //Array Options    
                $arrContextOptions=array("ssl"=>array("verify_peer"=>false,"verify_peer_name"=>false,),);

                //Get REST API response
                $response = file_get_contents("https://localhost:7244/api/Shopinz/{$username}", false, stream_context_create($arrContextOptions));
        
                //Deserialize into Array
                $response = json_decode($response);
        
                //Decrypt Password$response->password
                $encryptedPassword = $response->password; // Replace with the encrypted password from the ASP.NET API
                $decryptedPassword = decryptCaesar($encryptedPassword,2);


    }
}