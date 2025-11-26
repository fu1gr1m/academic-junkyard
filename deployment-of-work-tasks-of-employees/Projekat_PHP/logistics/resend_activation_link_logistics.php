<?php
session_start();

if (!isset($_SESSION['user_id'])) {
    header('Location: ../pages/registration_success.php');
    die();
}

$user_id = $_SESSION['user_id'];
require_once __DIR__ . '/../classes/User.php';
$user = User::getUserById($user_id);

$status = User::getStatusByUsername($user->username);

if ($status == 1) {
    unset($_SESSION['user_id']);
}

$activation_token = hash('sha512', uniqid(rand(), true));
$token_creation_time = date('Y-m-d H:i:s');

User::updateActivationToken($user_id, $activation_token, $token_creation_time);

require_once __DIR__ . '/../phpmailer/src/PHPMailer.php';
require_once __DIR__ . '/../phpmailer/src/Exception.php';
require_once __DIR__ . '/../phpmailer/src/SMTP.php';

use PHPMailer\PHPMailer\PHPMailer;
use PHPMailer\PHPMailer\Exception;

$mail = new PHPMailer(true);
$success = true;
try {
    $mail->isSMTP();
    $mail->Host = 'smtp.gmail.com';
    $mail->SMTPAuth = true;
    $mail->Username = 'stojiljkovicstefan42@gmail.com';
    $mail->Password = 'alcveuccpcukknnw ';
    $mail->SMTPSecure = 'tls';
    $mail->Port = 587;

    $mail->setFrom('stojiljkovicstefan42@gmail.com', 'PHP_Projekat');

    $mail->addAddress($user->email, $user->username);

    $activation_link = 'http://localhost/Projekat_PHP/logistics/account_activation_logistics.php?token=' . $activation_token;
    $mail->isHTML(true);
    $mail->Subject = 'Aktivacija vaseg naloga';
    $mail->Body = 'Kliknite na <a href="' . $activation_link . '">link</a> kako bi ste aktivirali vaš nalog.';

    $mail->send();
} catch (Exception $e) {
    $success = false;
    echo "Poruka nije mogla da se posalje, greska: {$mail->ErrorInfo}";
}

header('Location: ../pages/registration_success.php?success=' . ($success ? '1' : '0'));
