<?php
require_once __DIR__ . '/../classes/TaskGroups.php';
require_once __DIR__ . '/../classes/Tasks.php';
require_once __DIR__ . '/../classes/TaskAssignees.php';



if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_POST['task_id']) && isset($_POST['group_id'])) {
    $task_id = $_POST['task_id'];
    $group_id = $_POST['group_id'];
    $user_id = $_POST['user_id'];
    Tasks::deleteTask($task_id);
    header("Location: view_tasks.php?user_id=" . $user_id . "&" . "group_id=" . $group_id);
    die();
}