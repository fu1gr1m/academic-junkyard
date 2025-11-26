<?php
require_once __DIR__ . '/../logistics/checking_logistics.php';
require_once __DIR__ . '/../classes/TaskGroups.php';

if ($_SERVER["REQUEST_METHOD"] == "POST") {
    if (isset($_POST['group_name'])) {
        $group_name = $_POST['group_name'];

        $task_group = new TaskGroups();


        $task_group->name = $group_name;

        $task_group->addTaskGroup();

        header("Location: rukovodilac_dashboard.php");
        exit();
    }
}
?>