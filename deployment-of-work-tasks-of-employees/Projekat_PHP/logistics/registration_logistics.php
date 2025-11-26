<?php

if(empty($_POST['username']) || empty($_POST['password']) || empty($_POST['password_repeat'])
    || empty($_POST['email']) || empty($_POST['fullname']))
{
    header('Location: ../pages/registration.php?error=0');
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


if($password !== $password_repeat)
{
    header('Location: ../pages/registration.php?pass=0');
    die();
}

if (!filter_var($email, FILTER_VALIDATE_EMAIL)) {
    header('Location: ../pages/registration.php?email=0');
    die();
}

$activation_token = hash('sha512', uniqid(rand(), true));

require_once __DIR__ . '/../classes/User.php';
$id = User::registration(3, $username, $password, $fullname, $email, $phone_number, $date_of_birth, $activation_token);

if($id < 1)
{
    header('Location: ../pages/registration.php?user=0');
    die();
}

$user = User::getUserById($id);

require_once __DIR__ . '/../phpmailer/src/PHPMailer.php';
require_once __DIR__ . '/../phpmailer/src/Exception.php';
require_once __DIR__ . '/../phpmailer/src/SMTP.php';

use PHPMailer\PHPMailer\PHPMailer;
use PHPMailer\PHPMailer\Exception;


$mail = new PHPMailer(true);

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
    session_start();
    $_SESSION['user_id'] = $user->id;
    header('Location: ../pages/registration_success.php');
} catch (Exception $e) {
    echo "Poruka nije mogla da se posalje, greska: {$mail->ErrorInfo}";
}
