<?php

if(!isset($_POST['username']) || !isset($_POST['email']) || !isset($_POST['fullname']) || !isset($_POST['role']))
{
    $user_id = $_POST['user_id'];
    header('Location: ../_administrator/edit_user.php?user_id=' . $user_id . '&error=0');
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

$user_id = $_POST['user_id'];
$username = $_POST['username'];
$email = $_POST['email'];
$fullname = $_POST['fullname'];
$role_id = $_POST['role'];


if (!filter_var($email, FILTER_VALIDATE_EMAIL)) {
    header('Location: ../_administrator/edit_user.php?' . $user_id . '&email=0');
    die();
}

require_once __DIR__ . '/../classes/User.php';
$id = User::updateUser($user_id, $role_id, $username, $fullname, $email, $phone_number, $date_of_birth);
header('Location: ../_administrator/users.php?' . $user_id . '&success=2');
die();