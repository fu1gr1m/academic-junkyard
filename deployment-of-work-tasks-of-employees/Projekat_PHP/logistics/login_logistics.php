<?php

if(empty($_POST['username']) || empty($_POST['password']))
{
    header('Location: ../pages/login.php?error=0');
    die();
}

$username = $_POST['username'];
$password = $_POST['password'];

require_once __DIR__ . '/../classes/User.php';

$user = User::credentials_check($username, $password);

if($user === null)
{
    header('Location: ../pages/login.php?login=0');
    die();
}

$status = User::getStatusByUsername($username);
if ($status === 0) {
    header('Location: ../pages/login.php?status=0');
    die();
}
session_start();
$_SESSION['user_id'] = $user->id;

header('Location: ../logistics/dashboard_logistics.php');

