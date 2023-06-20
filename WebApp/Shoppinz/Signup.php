<?php require 'Components/Headers.php'?>
<?php require './Components/Application.php'?> 


<?php login();?>

<div class="login-page">
  <div class="form-group">
    <form class="login-form" method="post" name="LoginForm">
      <input type="text"  class="metro-input"name="Username" id="Username" placeholder="Twitter username"/>
      <input type="password"  class="metro-input" name="Password" id="Password" placeholder="password"/>
      <input type="password"  class="metro-input" name="RePassword" id="Password" placeholder="password"/>
      <input type="text"  class="metro-input" name="Blockw" id="Password" placeholder="Blocked Keywords"/>
      <input type="text"  class="metro-input" name="PrePro" id="Password" placeholder="Preffered Product"/>
      <br/>
      <br/>
      <button name="LogIn" class="button">login</button>
      <p class="message">Registered? <a href="./index.php">Sign Up</a></p>
    </form>
  </div>
</div>
<?php include 'Components/NavBar.php'?>


<!-- The headers .php file contains the body and html tags, .:. should be tag closed each time -->
</body>
</html>
