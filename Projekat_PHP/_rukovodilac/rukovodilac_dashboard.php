<?php
require_once __DIR__ . "/../logistics/checking_logistics.php";
require_once __DIR__ . '/../classes/TaskGroups.php';

$user_id = $_SESSION['user_id'];
require_once __DIR__ . '/../classes/User.php';
$user_role_id = User::getRoleTypeId($user_id);

if ($user_role_id == 2 || $user_role_id == 1) {

}
else
{
    header('Location: ../pages/login.php?access=0');
    die();
}


$task_groups = TaskGroups::getAllTaskGroups();
?>

<!DOCTYPE html>
<html>
<head>
    <title>Zadaci</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f2f2f2;
            margin: 0;
            padding: 0;
        }

        .container {
            max-width: 800px;
            margin: 20px auto;
            padding: 20px;
            background-color: #fff;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .form-group {
            margin-bottom: 20px;
            text-align: center;
        }

        .form-group label {
            display: block;
            font-weight: bold;
            margin-bottom: 5px;
        }

        .form-group input[type="text"] {
            width: 250px;
            padding: 5px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 3px;
            box-sizing: border-box;
        }

        .form-group input[type="submit"] {
            padding: 5px 10px;
            background-color: #4CAF50;
            color: white;
            border: none;
            border-radius: 3px;
            cursor: pointer;
        }

        h2{
            text-align: center;
        }

        ul {
            list-style: none;
            padding: 0;
            margin: 0;
        }

        ul li {
            margin-bottom: 10px;
            padding: 10px;
            background-color: #fff;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            display: flex;
            align-items: center;
        }

        ul li span {
            flex-grow: 1;
            font-weight: bold;
        }

        ul li form {
            margin-left: 10px;
        }

        ul li form button[type="submit"] {
            padding: 5px 10px;
            background-color: #007bff;
            color: #fff;
            border: none;
            border-radius: 3px;
            cursor: pointer;
            transition: background-color 0.3s;
        }

        ul li form button[type="submit"]:hover {
            background-color: #0056b3;
        }

        a {
            text-decoration: none;
            color: #007bff;
            margin-top: 10px;
        }

        a:hover {
            color: #0056b3;
        }

        hr {
            width: 100%;
        }
        nav {
            display: flex;
            justify-content: center;
            text-align: center;
            margin-bottom: -10px;
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
            text-align: center;
        }

        .nav-button:hover {
            background-color: #0056b3;
        }
    </style>
    <script>
        function editGroupName(groupId) {
            document.getElementById('editGroupForm' + groupId).style.display = 'block';
        }
    </script>
</head>
<body>
<div class="container">
    <nav>
        <form action="../logistics/logout_logistics.php" method="post" class="form-group">
            <button class="nav-button" type="submit">Odjavi se</button>
        </form>
        <?php if($user_role_id == 1): ?>
            <form action="../_administrator/role_type.php" method="post" class="form-group">
                <button class="nav-button" type="submit">Tipovi korisnika</button>
            </form>
            <form action="../_administrator/users.php" method="post" class="form-group">
                <button class="nav-button" type="submit">Korisnici</button>
            </form>
        <?php endif; ?>
    </nav>
    <hr>
    <h2>Kreiranje nove grupe zadataka</h2>
    <form action="create_task_group.php" method="POST" class="form-group"">
        <label for="group_name">Naziv grupe zadataka</label>
        <input type="text" id="group_name" name="group_name" required>
        <button type="submit" class="nav-button">Kreiraj grupu</button>
    </form>
    <?php if(!empty($task_groups)): ?>
        <h2>Grupe</h2>
    <?php endif; ?>
    <ul>
    <?php foreach ($task_groups as $group): ?>
        <li>
            <span><?php echo $group->name; ?></span>
            <form action="edit_task_group.php" method="POST">
                <input type="hidden" name="group_id" value="<?php echo $group->id; ?>">
                <input type="text" name="new_name" placeholder="Novo ime">
                <button type="submit">Uredi</button>
            </form>
            <form action="delete_task_group.php" method="POST">
                <input type="hidden" name="group_id" value="<?php echo $group->id; ?>">
                <button type="submit">Izbriši</button>
            </form>
            <form action="tasks.php" method="GET">
                <input type="hidden" name="group_id" value="<?php echo $group->id; ?>">
                <button type="submit">Napravi Zadatak</button>
            </form>
            <form action="view_tasks.php" method="GET">
                <input type="hidden" name="user_id" value="<?php echo $user_id?>">
                <input type="hidden" name="group_id" value="<?php echo $group->id; ?>">
                <button type="submit">Pogledaj Zadatke</button>
            </form>
        </li>
    <?php endforeach; ?>
    </ul>
</div>
</body>
</html>
