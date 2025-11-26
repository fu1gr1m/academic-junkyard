<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="refresh" content="5;url=login.php">
    <title>Aktivacija naloga</title>
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
            margin-top: 50px;
        }

        h1, p {
            margin-bottom: 15px;
        }

        /* Animacija tačaka */
        .dots {
            display: inline-block;
            overflow: hidden;
            position: relative;
            width: 1em;
            height: 1em;
            vertical-align: middle;
            margin-top: 10px;
        }

        .dots div {
            position: absolute;
            width: 0.25em;
            height: 0.25em;
            border-radius: 50%;
            background-color: #000;
            animation: dots 1s infinite linear;
        }

        .dots div:nth-child(1) {
            left: 0;
            animation-delay: 0s;
        }

        .dots div:nth-child(2) {
            left: 0.75em;
            animation-delay: 0.15s;
        }

        .dots div:nth-child(3) {
            left: 1.5em;
            animation-delay: 0.3s;
        }

        @keyframes dots {
            0% {
                transform: scale(0);
            }
            50% {
                transform: scale(1.5);
            }
            100% {
                transform: scale(0);
            }
        }
    </style>
</head>
<body>
<div class="container">
    <h1>Čestitamo!</h1>
    <p>Uspešno ste aktivirali svoj nalog. Sada možete pristupiti svim funkcijama naše platforme.</p>
    <p>Platforma će vas preusmeriti na login stranicu.</p>
    <div class="dots">
        <div></div>
        <div></div>
        <div></div>
    </div>
</div>
</body>
</html>
