<?php
require_once __DIR__ . '/../classes/TaskAssignees.php';

$task_id = $_POST['task_id'];
$user_id = $_POST['user_id'];

$status = TaskAssignees::updateTaskStatus($task_id, $user_id, 1);

if(!$status)
{
    header("Location: izvrsilac_dashboard.php");
    die();
}
else
{
    echo "nije azuriran status";
}
