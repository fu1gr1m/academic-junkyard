<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Reset Password</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f2f2f2;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        form {
            background-color: #ffffff;
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            width: 300px;
            text-align: center;
        }

        input[type="password"] {
            width: calc(100% - 20px);
            padding: 10px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 3px;
        }

        input[type="submit"] {
            width: calc(100% - 20px);
            padding: 10px;
            margin-top: 10px;
            background-color: #007bff;
            color: #ffffff;
            border: none;
            border-radius: 3px;
            cursor: pointer;
        }

        input[type="submit"]:hover {
            background-color: #0056b3;
        }

        p {
            color: red;
            margin-top: 10px;
            text-align: center;
        }

        .links {
            text-align: center;
            margin-top: 10px;
        }

        .links a {
            display: block;
            text-decoration: none;
            color: #007bff;
            margin-top: 5px;
        }

        .links a:hover {
            color: #0056b3;
        }
    </style>
</head>
<body>
<form action="../logistics/reset_password_logistics.php" method="post">
    <input type="hidden" name="token" value="<?php echo isset($_GET['token']) ? htmlspecialchars($_GET['token']) : ''; ?>">
    <h2>Promeni šifru</h2>
    <label for="password">Novi password</label>
    <input type="password" id="password" name="password" required>
    <label for="confirm_password">Potvrdi password</label>
    <input type="password" id="confirm_password" name="confirm_password" required>
    <input type="submit" value="Promeni">
    <?php
    if(isset($_GET['pass']) && $_GET['pass'] === "0") {
        echo "<p>Token ne postoji.</p>";
    }
    elseif(isset($_GET['pass']) && $_GET['pass'] === "1") {
        echo "<p>Morate popuniti sva polja!</p>";
    }
    elseif(isset($_GET['pass']) && $_GET['pass'] === "2") {
        echo "<p>Sifre vam se ne poklapaju!</p>";
    }
    elseif(isset($_GET['pass1']) && $_GET['pass1'] === "0") {
        echo "<p>Ne postoji korisnik sa datim tokenom.</p>";
    }
    ?>
</form>
</body>
</html>
