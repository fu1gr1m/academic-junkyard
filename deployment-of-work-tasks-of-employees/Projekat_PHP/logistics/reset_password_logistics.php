<?php
require_once __DIR__ . '/../config.php';
require_once __DIR__ . '/../includes/Database.php';
require_once __DIR__ . '/../classes/User.php';

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    if (!isset($_POST['token']) || empty($_POST['token'])) {
        header("Location: ../pages/reset_password.php?pass=0");
        die();
    }

    $activation_token = $_POST['token'];

    if (!isset($_POST['password']) || !isset($_POST['confirm_password']) || empty($_POST['password']) || empty($_POST['confirm_password'])) {
        header("Location: ../pages/reset_password.php?pass=1&token=" . $activation_token);
        die();
    }

    $password = $_POST['password'];
    $confirm_password = $_POST['confirm_password'];


    if ($password !== $confirm_password) {
        header("Location: ../pages/reset_password.php?pass=2&token=" . $activation_token);
        die();
    }

    $user = User::getUserByToken($activation_token);

    if ($user) {
        $password = hash('sha512', $password);
        $user_id = $user->id;
        User::updatePassword($user_id, $password);

        header("Location: ../pages/login.php?pass=0");
        die();
    } else {
        header("Location: ../pages/reset_password.php?pass1=0&token=" . $activation_token);
    }
} else {
    header('Location: ../pages/email_input.php');
    exit;
}
