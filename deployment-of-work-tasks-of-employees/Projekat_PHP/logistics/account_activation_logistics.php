<?php
require_once __DIR__ . '/../config.php';
require_once __DIR__ . '/../includes/Database.php';
require_once __DIR__ . '/../classes/User.php';

if(isset($_GET['token'])) {
    $activation_token = $_GET['token'];

    $user = User::getUserByToken($activation_token);

    if($user) {
        User::activateAccount($user->id);
        header("Location: ../pages/account_activation_success.php");
    } else {
        echo "Neuspešna verifikacija: Nalog sa datim tokenom nije pronađen.";
    }
} else {
    echo "Neuspešna verifikacija: Token nije prosleđen.";
}
?>
