<?php
require_once __DIR__ . '/../classes/Roles.php';

$roles = Roles::getAllRoles();
?>


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Upravljanje tipovima korisnika</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f2f2f2;
            margin: 0;
            padding: 20px;
        }

        .container {
            max-width: 600px;
            margin: 0 auto;
            background-color: #fff;
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        h2 {
            text-align: center;
        }

        .form-group {
            margin-bottom: 20px;
        }

        label {
            display: block;
            font-weight: bold;
            margin-bottom: 5px;
            text-align: center;
        }

        input[type="text"] {
            width: 100%;
            padding: 8px;
            border: 1px solid #ccc;
            border-radius: 3px;
            box-sizing: border-box;
        }

        input[type="submit"] {
            padding: 10px 20px;
            background-color: #007bff;
            color: #fff;
            border: none;
            border-radius: 3px;
            cursor: pointer;
            transition: background-color 0.3s;
        }

        input[type="submit"]:hover {
            background-color: #0056b3;
        }

        ul {
            list-style: none;
            padding: 0;
        }

        li {
            margin-bottom: 10px;
        }

        .role-name {
            font-weight: bold;
        }

        .change-role-form {
            display: flex;
            align-items: center;
        }

        .new-role-name-input {
            margin-right: 10px;
            padding: 5px;
            border: 1px solid #ccc;
            border-radius: 3px;
        }

        .change-role-button {
            padding: 5px 10px;
            background-color: #007bff;
            color: #ffffff;
            border: none;
            border-radius: 3px;
            cursor: pointer;
        }

        .change-role-button:hover {
            background-color: #0056b3;
        }

        nav {
            display: flex;
            margin-bottom: 20px;
            justify-content: center;
        }

        .nav-button {
            padding: 5px 10px;
            background-color: #007bff;
            color: #ffffff;
            border: none;
            border-radius: 3px;
            cursor: pointer;
            transition: background-color 0.3s;
            margin-left: 10px;

        }

        .nav-button:hover {
            background-color: #0056b3;
        }

    </style>
</head>
<body>
<nav>
    <form action="../logistics/logout_logistics.php" method="post">
        <button class="nav-button" type="submit">Odjavi se</button>
    </form>

    <form action="../_rukovodilac/rukovodilac_dashboard.php" method="get">
        <button class="nav-button" type="submit">Nazad</button>
    </form>
</nav>
<hr>
<div class="container">
    <h2>Dodavanje novog tipa korisnika</h2>
    <form action="process_role_type.php" method="POST" class="form-group">
        <div class="form-group">
            <label for="role_name">Naziv tipa korisnika:</label>
            <input type="text" id="role_name" name="role_name" required>
        </div>
        <input type="submit" value="Dodaj tip korisnika">
    </form>

    <h2>Lista tipova korisnika</h2>
    <?php foreach ($roles as $role): ?>
        <li>
            <span class="role-name"><?php echo $role->name; ?></span>
            <form action="change_role_type.php" method="post" class="change-role-form">
                <input type="hidden" name="role_id" value="<?php echo $role->id; ?>">
                <input type="text" name="new_role_name" placeholder="Novo ime" required class="new-role-name-input">
                <button type="submit" class="change-role-button">Promeni ime</button>
            </form>
        </li>
    <?php endforeach; ?>
</div>
</body>
</html>
