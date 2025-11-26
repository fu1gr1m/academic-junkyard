<?php
session_start();

require_once __DIR__ . '/../classes/Tasks.php';

if (!isset($_SESSION['user_id'])) {
    header('Location: ../pages/login.php?access=0');
    exit();
}

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $task_id = $_POST['task_id'];
    $group_id = $_POST['group_id'];
    $user_id = $_POST['user_id'];

    $result = Tasks::markTaskAsFinished($task_id);

    if (!$result) {
        header("Location: view_tasks.php?user_id=$user_id&group_id=$group_id&complete=success");
        exit();
    } else {
        header("Location: view_tasks.php?user_id=$user_id&group_id=$group_id&complete=error");
        exit();
    }
} else {
    header('Location: view_tasks.php');
    exit();
}
?>
