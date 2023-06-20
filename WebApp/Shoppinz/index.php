<?php require 'Components/Headers.php'?>
<?php require './Components/Application.php'?> 


<?php login();?>

<div class="login-page">
  <div class="form-group">
    <form class="login-form" method="post" name="LoginForm">
      <input type="text"  class="metro-input"name="Username" id="Username" placeholder="username"/>
      <input type="password"  class="metro-input" name="Password" id="Password" placeholder="password"/>
      <br/>
      <br/>
      <button name="SIgnup" class="button">login</button>
      <p class="message">Not registered? <a href="./CreateAccount.php">Sign Up</a></p>
    </form>
  </div>
</div>


<!-- The headers .php file contains the body and html tags, .:. should be tag closed each time -->
</body>
</html>
