<?php
require_once __DIR__ . "/../logistics/checking_logistics.php";
require_once __DIR__ . "/../classes/Tasks.php";
require_once __DIR__ . "/../classes/User.php";
require_once __DIR__ . "/../classes/TaskAssignees.php";
require_once __DIR__ . "/../classes/TaskAttachments.php";

if ($_SERVER["REQUEST_METHOD"] == "POST") {
    if (isset($_POST['title']) && isset($_POST['description']) && isset($_POST['deadline']) && isset($_POST['priority']) && isset($_POST['group_id']) && isset($_POST['selected_assignees']) && isset($_POST['leader_id'])) {

        $title = $_POST['title'];
        $description = $_POST['description'];
        $deadline = $_POST['deadline'];
        $priority = $_POST['priority'];
        $group_id = intval($_POST['group_id']);
        $assignees = $_POST['selected_assignees'];
        $assignee_ids = array_map('intval', $assignees);
        $leader = intval($_POST['leader_id']);
        $taskId = Tasks::createTask($title, $description, $deadline, $priority, $group_id, $leader);
        TaskAssignees::createTaskAssignee($taskId, $assignee_ids);
        if(!empty($_FILES['attachments']['name'][0]))
        {
            $attachment_names = $_FILES['attachments']['name'];
            $attachment_paths = $_FILES['attachments']['tmp_name'];
            $mime_types = $_FILES['attachments']['type'];
            TaskAttachments::createTaskAttachments($taskId, $attachment_names, $attachment_paths, $mime_types);
        }

        if ($taskId !== false) {
            header("Location: tasks.php?group_id=" . $group_id . "&success=1");
            die();
        } else {
            echo "greska prilikom kreiranja";
            die();
        }
    } else {
        echo "server nije fetchovao sve podatke";
        die();
    }
} else {
    echo "request metod != post";
    die();
}

