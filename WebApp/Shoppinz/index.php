<?php require 'Components/Headers.php'?>

<!-- Form Code-->

<?php require './Components/Application.php'?> 
<?php login();?>

<div class="login-page">
  <div class="form">
    <form class="login-form" method="post" name="LoginForm">
      <input type="text" name="Username" id="Username" placeholder="username"/>
      <input type="password" name="Password" id="Password" placeholder="password"/>
      <button name="LogIn">login</button>
      <p class="message">Not registered? <a href="./CreateAccount.php">Sign Up</a></p>
    </form>
  </div>
</div>
<?php include 'Components/NavBar.php'?>


<!-- The headers .php file contains the body and html tags, .:. should be tag closed each time -->
</body>
</html>
