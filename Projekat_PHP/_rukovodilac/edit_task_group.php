<?php
require_once __DIR__ . '/../logistics/checking_logistics.php';
require_once __DIR__ . '/../classes/TaskGroups.php';

if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_POST['group_id']) && isset($_POST['new_name'])) {
    $group_id = $_POST['group_id'];
    $new_name = $_POST['new_name'];

    TaskGroups::updateGroupName($group_id, $new_name);

    header("Location: rukovodilac_dashboard.php");
    exit();
}

