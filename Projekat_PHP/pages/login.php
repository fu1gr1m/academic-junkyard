<!DOCTYPE html>
<html>
<head>
    <title>Uloguj se</title>
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

        input[type="text"],
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
<form method="post" action="../logistics/login_logistics.php">
    <input type="text" name="username" placeholder="Unesite username"><br>
    <input type="password" name="password" placeholder="Unesite password"><br>
    <input type="submit" value="Prijavi se">
    <div class="links">
        <a href="email_input.php">Zaboravio si sifru?</a>
        <a href="registration.php">Nemas nalog? Registruj se.</a>
    </div>
    <?php
    if(isset($_GET['error']) && $_GET['error'] === "0") {
        echo "<p>Unesite korisničko ime i lozinku.</p>";
    }
    elseif(isset($_GET['login']) && $_GET['login'] === "0") {
        echo "<p>Pogrešno korisničko ime ili lozinka.</p>";
    }
    elseif(isset($_GET['status']) && $_GET['status'] === "0") {
        echo "<p>Verifikujte vas email, kako bi ste se ulogovali.</p>";
    }
    elseif(isset($_GET['pass']) && $_GET['pass'] === "0") {
        echo "<p>Sifra je uspesno promenjena! Sada se mozete ulogovati.</p>";
    }
    elseif(isset($_GET['korisnik']) && $_GET['korisnik'] === "-1") {
        echo "<p>Nepoznata uloga korisnika.</p>";
    }
    elseif(isset($_GET['access']) && $_GET['access'] === "0") {
        echo "<p>ACCESS DENIED!</p>";
    }
    ?>
</form>
</body>
</html>