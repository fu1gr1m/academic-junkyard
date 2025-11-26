<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Unesite Email</title>
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
            text-align: center;
        }

        .container {
            background-color: #ffffff;
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            width: 300px;
        }

        h1, p {
            margin-bottom: 15px;
        }

        input[type="email"] {
            width: calc(100% - 20px);
            padding: 10px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 3px;
        }

        input[type="submit"] {
            width: calc(100% - 20px);
            padding: 10px;
            background-color: #007bff;
            color: #ffffff;
            border: none;
            border-radius: 3px;
            cursor: pointer;
        }

        input[type="submit"]:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
<div class="container">
    <h1>Unesite Vaš Email</h1>
    <p>Unesite email sa kojim ste se registrovali. Poslaćemo vam link za resetovanje lozinke.</p>
    <form action="../logistics/email_input_logistics.php" method="post">
        <input type="email" name="email" placeholder="Unesite vaš email" required>
        <input type="submit" value="Pošalji">
        <?php
        if(isset($_GET['email']) && $_GET['email'] === "0") {
            echo "<p>Uneli ste neispravan email.</p>";
        }
        elseif(isset($_GET['email']) && $_GET['email'] === "1")
        {
            echo "<p>Poslat vam je link(aktivan 30 minuta) za promenu sifre na email adresu.</p>";
        }
        ?>
    </form>
</div>
</body>
</html>
