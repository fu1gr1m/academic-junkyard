<?php
require_once __DIR__ . '/../classes/TaskGroups.php';
require_once __DIR__ . '/../classes/Tasks.php';
require_once __DIR__ . '/../classes/TaskAssignees.php';



if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_POST['group_id'])) {
    $groupId = $_POST['group_id'];
    TaskGroups::deleteTaskGroup($groupId);

    header("Location: rukovodilac_dashboard.php");
    die();
}
