<?php
require_once __DIR__ . '/../config.php';
require_once __DIR__ . '/../includes/Database.php';
require_once __DIR__ . '/../classes/User.php';
use PHPMailer\PHPMailer\PHPMailer;
use PHPMailer\PHPMailer\Exception;

if ($_SERVER['REQUEST_METHOD'] === 'POST') {

    if (!isset($_POST['email']) || empty($_POST['email'])) {
        echo "Morate uneti email adresu.";
        die();
    }
    $email = $_POST['email'];
    if (!filter_var($email, FILTER_VALIDATE_EMAIL)) {
        header('Location: ../pages/email_input.php?email=0');
        die();
    }

    $activation_token = hash('sha512', uniqid(rand(), true));
    $token_creation_time = date('Y-m-d H:i:s');

    $reset_link = 'http://localhost/Projekat_PHP/logistics/reset_password_authentication_logistics.php?token=' . $activation_token;
    $user = User::getUserByEmail($email);
    $user_id = User::getIdByEmail($email);
    User::updateActivationToken($user_id, $activation_token, $token_creation_time);
    require_once __DIR__ . '/../phpmailer/src/PHPMailer.php';
    require_once __DIR__ . '/../phpmailer/src/Exception.php';
    require_once __DIR__ . '/../phpmailer/src/SMTP.php';

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

        $mail->isHTML(true);
        $mail->Subject = 'Resetovanje vase sifre';
        $mail->Body = 'Kliknite na <a href="' . $reset_link . '">link</a> kako bi ste resetovali vasu sifru.';

        $mail->send();
    } catch (Exception $e) {
        echo "Poruka nije mogla da se posalje, greska: $mail->ErrorInfo";
    }
    header('Location: ../pages/email_input.php?email=1');
} else {
    header('Location: ../pages/email_input.php');
    die();
}