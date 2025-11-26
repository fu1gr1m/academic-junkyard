<?php

if(empty($_POST['username']) || empty($_POST['password']) || empty($_POST['password_repeat'])
    || empty($_POST['email']) || empty($_POST['fullname']) || empty($_POST['role']))
{
    header('Location: ../_administrator/add_user.php?error=0');
    die();
}

$phone_number = null;
$date_of_birth = null;

if(!empty($_POST['phone_number']))
{
    $phone_number = $_POST['phone_number'];
}
if(!empty($_POST['date_of_birth']))
{
    $date_of_birth = $_POST['date_of_birth'];
}


$username = $_POST['username'];
$password = $_POST['password'];
$password_repeat = $_POST['password_repeat'];
$email = $_POST['email'];
$fullname = $_POST['fullname'];
$role_id = $_POST['role'];

if($password !== $password_repeat)
{
    header('Location: ../_administrator/users.php?pass=0');
    die();
}

if (!filter_var($email, FILTER_VALIDATE_EMAIL)) {
    header('Location: ../_administrator/users.php?email=0');
    die();
}

$activation_token = hash('sha512', uniqid(rand(), true));

require_once __DIR__ . '/../classes/User.php';
$id = User::registration($role_id, $username, $password, $fullname, $email, $phone_number, $date_of_birth, $activation_token);
User::activateAccount($id);
header('Location: ../_administrator/users.php?success=1');

if($id < 1)
{
    header('Location: ../_administrator/users.php?user=0');
    die();
}