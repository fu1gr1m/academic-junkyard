<!DOCTYPE html>
<html>
<head>
    <title>Registracija</title>
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
        input[type="password"],
        input[type="email"],
        input[type="tel"],
        input[type="date"] {
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

        a {
            display: block;
            text-align: center;
            margin-top: 10px;
            text-decoration: none;
            color: #007bff;
        }

        a:hover {
            color: #0056b3;
        }
    </style>
</head>
<body>
    <form method="post" action="../logistics/registration_logistics.php">
        <input type="text" name="fullname" placeholder="Unesite puno ime"><br>
        <input type="text" name="username" placeholder="Unesite username"><br>
        <input type="password" name="password" placeholder="Unesite password"><br>
        <input type="password" name="password_repeat" placeholder="Ponovite password"><br>
        <input type="email" name="email" placeholder="Unesite e-mail" pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$" required><br>
        <input type="tel" name="phone_number" placeholder="Unesite broj telefona"><br>
        <input type="date" name="date_of_birth"><br>
        <input type="submit" value="Registruj se">
        <a href="login.php">Imas nalog? Uloguj se.</a>
        <?php
        if(isset($_GET['error']) && $_GET['error'] === "0") {
            echo "<p>Popunite sva polja!</p>";
        }
        elseif(isset($_GET['pass']) && $_GET['pass'] === "0") {
            echo "<p>Sifra nije ispravna u oba sektora!</p>";
        }
        elseif(isset($_GET['user']) && $_GET['user'] === "0") {
            echo "<p>Korisnik sa datim brojem telefona, emailom ili username-om vec postoji.</p>";
        }
        elseif(isset($_GET['email']) && $_GET['email'] === "0")
        {
            echo "<p>Uneli ste losu email adresu.</p>";
        }
        ?>
    </form>
</body>
</html>