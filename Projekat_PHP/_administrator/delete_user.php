<?php
require_once __DIR__ . "/../classes/User.php";
if(!isset($_GET['user_id']))
{
    header("Location: users.php?user_id=0");
}

$user_id = $_GET['user_id'];

User::deleteUser($user_id);
header("Location: users.php?delete=1");