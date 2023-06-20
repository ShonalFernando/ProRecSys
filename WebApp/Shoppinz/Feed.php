<?php require 'Components/Headers.php'?>
<?php require './Components/Application.php'?> 

<!-- TAb Nav -->
<ul data-app-bar="true" data-role="materialtabs">
    <li><a href="#">Recommended</a></li>
</ul>

<?php

         $username = $_SESSION["username"] = $username;


        //Array Options    
        $arrContextOptions=array("ssl"=>array("verify_peer"=>false,"verify_peer_name"=>false,),);

        //Get REST API response
        $response = file_get_contents("https://localhost:7259/api/ProRec/$username", false, stream_context_create($arrContextOptions));

        //Deserialize into Array
        $response = json_decode($response);

        //Get Product
        $productname = $response->productName;
        $productRemarks = $response->productRemarks;


echo("
<div style='margin-top: 112px'>
    <div id='Recommended'>
        <div class='grid'>
            <div class='row'>
                <div class='cell-3'>
                    <div class='card image-header'>
                        <div class='card-header fg-black' style='background-image: url(./img/Uploads/$productname.jpeg)'>$productname</div>
                        <div class='card-content p-2'>
                            <p class='fg-gray'>$productRemarks
                        </div>
                    <div class='card-footer'>
                    <button class='button secondary'>Add to Cart</button>
                </div>
            </div>
        </div>
    </div>
</div>
");
?>
</div>