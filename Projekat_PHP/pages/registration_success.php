<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Registration Success</title>
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

        .resend-link {
            display: block;
            margin-top: 20px;
            text-decoration: none;
            color: #007bff;
        }

        .resend-link:hover {
            color: #0056b3;
        }
    </style>
</head>
<body>
<div class="container">
    <h1>Registracija uspešna!</h1>
    <p>Uspešno ste se registrovali. Uskoro će vam stići link za verifikaciju vašeg naloga.</p>
    <a href="../logistics/resend_activation_link_logistics.php" class="resend-link">Pošalji ponovo aktivacioni link</a>
    <?php if (isset($_GET['success']) && $_GET['success'] == '1') : ?>
        <p class="success-message">Aktivacioni email je uspešno poslat.</p>
    <?php endif; ?>
</div>
</body>
</html>
