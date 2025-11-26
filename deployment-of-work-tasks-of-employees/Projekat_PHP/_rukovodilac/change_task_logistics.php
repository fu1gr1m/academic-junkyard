<?php
session_start();

require_once __DIR__ . '/../classes/User.php';
require_once __DIR__ . '/../classes/Tasks.php';

if (!isset($_SESSION['user_id'])) {
    header('Location: ../pages/login.php?access=0');
    exit();
}

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $user_id = $_POST['user_id'];
    $title = $_POST['title'];
    $task_id = $_POST['task_id'];
    $description = $_POST['description'];
    $deadline = $_POST['deadline'];
    $priority = $_POST['priority'];
    $group_id = intval($_POST['group_id']);
    $assignees = $_POST['selected_assignees'];
    $assignee_ids = array_map('intval', $assignees);
    $leader = intval($_POST['leader_id']);

    $taskId = Tasks::updateTask($task_id, $title, $description, $deadline, $priority, $group_id, $leader);
    TaskAssignees::updateTaskAssignees($task_id, $assignee_ids);
    if(empty($_FILES['attachments']['name'][0]))
    {
        TaskAttachments::deleteTaskAttachments($task_id);
    }
    else
    {
        $attachment_names = $_FILES['attachments']['name'];
        $attachment_paths = $_FILES['attachments']['tmp_name'];
        $mime_types = $_FILES['attachments']['type'];
        TaskAttachments::updateTaskAttachments($task_id, $attachment_names, $attachment_paths, $mime_types);
    }


    if ($task_id){
        header("Location: view_tasks.php?user_id=$user_id&group_id=$group_id&change=success");
        exit();
    } else {
        header("Location: view_tasks.php?user_id=$user_id&group_id=$group_id&change=error");
        exit();
    }
} else {
    header('Location: view_tasks.php?user_id=' . $_POST['user_id'] . 'group_id=' . $_POST['group_id']);
    exit();
}
