<?php
/*=================================================== Login Existing User ===============================================================*/
function login()
{
    $arrContextOptions=array(
        "ssl"=>array(
            "verify_peer"=>false,
            "verify_peer_name"=>false,
        ),
    );

    $response = file_get_contents('https://localhost:7244/api/Shopinz/shonal', false, stream_context_create($arrContextOptions));
    echo("$response");

    //Check if Log In button is pressed
    if(isset($_POST['LogIn']))
    {
        //Get Form Input
        $username = $_POST['Username'];
        $username = stripslashes($username);
        $password = $_POST['Password'];
        $password = stripslashes($password);

        //Deserialize into Array
        $response = json_decode($response);

        //Authentication
        if($password == $response->password)
        {
            echo "OKOK";
        }
        //test
        echo $response->password;


    }



}

