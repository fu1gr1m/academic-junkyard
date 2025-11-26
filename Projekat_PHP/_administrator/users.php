<?php
require_once __DIR__ . '/../config.php';
require_once __DIR__ . '/../includes/Database.php';
require_once __DIR__ . '/../classes/Roles.php';
require_once __DIR__ . '/../classes/User.php';


$roles = Roles::getAllRoles();
$users = User::getAllUsers();
?>


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Korisnici</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f2f2f2;
            margin: 0;
            padding: 0;
        }

        h2 {
            text-align: center;
            margin-top: 20px;
        }

        form {
            margin-bottom: 20px;
            text-align: center;
        }

        label {
            display: block;
            margin-bottom: 5px;
        }

        div
        {
            width: 30%; margin: 0 auto;
        }

        div button
        {
            background-color: #4CAF50;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

        div button:hover
        {
            background-color: #45a049;
        }

        div input,select
        {
            width: 100%;
            padding: 8px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
        }

        table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }

        th, td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }

        th {
            background-color: #4CAF50;
            color: white;
        }

        tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        a {
            text-decoration: none;
            margin-right: 5px;
            color: #007bff;
        }

        a:hover {
            color: #0056b3;
        }

        nav {
            display: flex;
            margin-top: 10px;
            margin-bottom: -20px;
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
        p
        {
            text-align: center;
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

<div>
    <h2 style="text-align: center;">Unos novog korisnika</h2>
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
    elseif(isset($_GET['success']) && $_GET['success'] === "1")
    {
        echo "<p>Nalog je uspesno kreiran!</p>";
    }
    elseif(isset($_GET['success']) && $_GET['success'] === "2")
    {
        echo "<p>Nalog je uspesno izmenjen!</p>";
    }
    elseif(isset($_GET['delete']) && $_GET['delete'] === "1")
    {
        echo "<p>Nalog je uspesno obrisan!</p>";
    }
    ?>
    <form action="add_user_logistics.php" method="POST" style="margin: 0 auto; text-align: center;">
        <label for="username">Korisničko ime:</label>
        <input type="text" id="username" name="username" required><br>
        <label for="password">Lozinka:</label>
        <input type="password" id="password" name="password" required><br>
        <label for="password">Ponovite lozinku:</label>
        <input type="password" id="password_repeat" name="password_repeat" required><br>
        <label for="fullname">Ime i prezime:</label>
        <input type="text" id="fullname" name="fullname" required><br>
        <label for="email">Email:</label>
        <input type="email" id="email" name="email" required><br>
        <label for="phone_number">Broj telefona:</label>
        <input type="text" id="phone_number" name="phone_number"><br>
        <label for="date_of_birth">Datum rođenja:</label>
        <input type="date" id="date_of_birth" name="date_of_birth"><br>
        <label for="role">Tip korisnika:</label>
        <select id="role" name="role" required>
            <?php foreach ($roles as $role): ?>
                <option value="<?php echo $role->id; ?>"><?php echo $role->name; ?></option>
            <?php endforeach; ?>
        </select><br>

        <input type="hidden" name="status" value="1">
        <button type="submit" style="">Dodaj korisnika</button>
    </form>
</div>


<hr>

<h2>Lista korisnika</h2>
<table>
    <thead>
    <tr>
        <th>Username</th>
        <th>Fullname</th>
        <th>Email</th>
        <th>Phone Number</th>
        <th>Date of Birth</th>
        <th>Status</th>
        <th>Role</th>
        <th>Action</th>
    </tr>
    </thead>
    <tbody>
    <?php foreach ($users as $user): ?>
        <tr>
            <td><?php echo $user->username; ?></td>
            <td><?php echo $user->full_name; ?></td>
            <td><?php echo $user->email; ?></td>
            <td><?php echo $user->phone_number; ?></td>
            <td><?php echo $user->date_of_birth; ?></td>
            <td><?php echo $user->status; ?></td>
            <td>
                <?php
                foreach ($roles as $role) {
                    if ($role->id === $user->role_type_id) {
                        echo $role->name;
                        break;
                    }
                }
                ?>
            </td>
            <td>
                <a href="edit_user.php?user_id=<?php echo $user->id; ?>">Edit</a>

                <a href="delete_user.php?user_id=<?php echo $user->id; ?>">Delete</a>
            </td>
        </tr>
    <?php endforeach; ?>
    </tbody>
</table>

</body>
</html>

