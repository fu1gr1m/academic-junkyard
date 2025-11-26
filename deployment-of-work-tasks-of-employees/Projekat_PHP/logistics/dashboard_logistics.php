<?php
session_start();

if (!isset($_SESSION['user_id'])) {
    header("Location: ../pages/login.php");
    die();
}

$user_id = $_SESSION['user_id'];

require_once __DIR__ . '/../classes/User.php';

$user_role_id = User::getRoleTypeId($user_id);

if ($user_role_id == 2) {
    header("Location: ../_rukovodilac/rukovodilac_dashboard.php");
} elseif ($user_role_id == 3) {
    header("Location: ../_izvrsilac/izvrsilac_dashboard.php");
} elseif ($user_role_id == 1) {
    header("Location: ../_rukovodilac/rukovodilac_dashboard.php");
} else {
    header("Location: ../pages/login.php?korisnik=-1");
    die();
}
?>
