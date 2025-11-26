<?php
require_once __DIR__ . '/../config.php';
require_once __DIR__ . '/../includes/Database.php';
require_once __DIR__ . '/../classes/Roles.php';

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    if (isset($_POST['role_id'], $_POST['new_role_name']) && !empty($_POST['role_id']) && !empty($_POST['new_role_name'])) {
        $roleId = $_POST['role_id'];
        $newRoleName = $_POST['new_role_name'];
        $result = Roles::changeRoleName($roleId, $newRoleName);


        if ($result) {
            header('Location: role_type.php?status=success');
            exit();
        } else {
            header('Location: role_type.php?status=error');
            exit();
        }
    } else {
        header('Location: role_type.php?status=missing_data');
        exit();
    }
} else {
    header('Location: role_type.php');
    exit();
}
