<?php
require_once __DIR__ . '/../config.php';
require_once __DIR__ . '/../includes/Database.php';
require_once __DIR__ . '/../classes/User.php';

if(isset($_GET['token'])) {
    $activation_token = $_GET['token'];

    $user = User::getUserByToken($activation_token);

    if($user) {
        $token_creation_time = $user->token_creation_time;
        $expiration_time = strtotime($token_creation_time) + (30 * 60);

        if(time() <= $expiration_time) {
            header("Location: ../pages/reset_password.php?token=" . $activation_token);
        } else {
            echo "Nemoguce menjanje sifre: Link za resetovanje lozinke je istekao. Molimo zatražite novi.";
        }
    } else {
        echo "Nemoguce menjanje sifre: Nalog sa datim tokenom nije pronađen.";
    }
} else {
    echo "Neuspešna verifikacija: Token nije prosleđen.";
}