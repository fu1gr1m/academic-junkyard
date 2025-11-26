<?php
require_once __DIR__ . '/../config.php';
require_once __DIR__ . '/../includes/Database.php';
require_once __DIR__ . '/../classes/Roles.php';
require_once __DIR__ . '/../classes/User.php';


if (!isset($_GET['user_id'])) {
    var_dump($_GET['user_id']);
    die();
}
$user_id = $_GET['user_id'];
$user = User::getUserById($user_id);
$roles = Roles::getAllRoles();
$username = $user->username;
$fullname = $user->full_name;
$email = $user->email;
$phone_number = $user->phone_number;
$date_of_birth = $user->date_of_birth;
$role_type_id = $user->role_type_id;
?>
    <!DOCTYPE html>
    <html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Edit User</title>
        <style>
                body {
                    font-family: Arial, sans-serif;
                    background-color: #f2f2f2;
                    margin: 0;
                    padding: 0;
                }

                .container {
                    max-width: 600px;
                    margin: 20px auto;
                    padding: 20px;
                    background-color: #fff;
                    border-radius: 5px;
                    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
                }

                h2 {
                    text-align: center;
                }

                form {
                    margin-top: 20px;
                }

                label {
                    display: block;
                    margin-bottom: 5px;
                }

                input[type="text"],
                input[type="password"],
                input[type="email"],
                input[type="date"],
                select {
                    width: calc(100% - 10px);
                    padding: 8px;
                    margin-bottom: 10px;
                    border: 1px solid #ccc;
                    border-radius: 3px;
                    box-sizing: border-box;
                }

                button {
                    background-color: #4CAF50;
                    color: white;
                    padding: 10px 20px;
                    border: none;
                    border-radius: 4px;
                    cursor: pointer;
                }

                button:hover {
                    background-color: #45a049;
                }

                nav {
                    display: flex;
                    margin-bottom: 10px;
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

            <form action="../_administrator/users.php" method="get">
                <button class="nav-button" type="submit">Nazad</button>
            </form>
        </nav>

        <hr>
        <div class="container">
            <h2>Izmeni korisnika</h2>
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
            <form action="update_user_logistics.php" method="POST">
                <input type="hidden" name="user_id" value="<?php echo $user_id; ?>">
                <label for="username">Korisničko ime:</label>
                <input type="text" id="username" name="username" value="<?php echo $username; ?>" required>
                <label for="fullname">Ime i prezime:</label>
                <input type="text" id="fullname" name="fullname" value="<?php echo $fullname; ?>" required>
                <label for="email">Email:</label>
                <input type="email" id="email" name="email" value="<?php echo $email; ?>" required>
                <label for="phone_number">Broj telefona:</label>
                <input type="text" id="phone_number" name="phone_number" value="<?php echo $phone_number; ?>">
                <label for="date_of_birth">Datum rođenja:</label>
                <input type="date" id="date_of_birth" name="date_of_birth" value="<?php echo $date_of_birth; ?>">
                <label for="role">Tip korisnika:</label>
                <select id="role" name="role" required>
                    <?php foreach ($roles as $role): ?>
                        <option value="<?php echo $role->id; ?>" <?php if ($role->id == $role_type_id) echo 'selected'; ?>><?php echo $role->name; ?></option>
                    <?php endforeach; ?>
                </select>
                <button type="submit">Izmeni korisnika</button>
            </form>
        </div>
        </body>
    </html>
