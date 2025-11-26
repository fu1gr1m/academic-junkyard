<?php
session_start();
if(!isset($_SESSION['user_id']))
{
    header('Location: ../pages/login.php?login=0');
    die();
}
?>