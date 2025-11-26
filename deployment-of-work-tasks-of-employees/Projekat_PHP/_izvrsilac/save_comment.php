<?php
require_once __DIR__ . '/../classes/TaskComments.php';

if ($_SERVER['REQUEST_METHOD'] === 'POST' && isset($_POST['task_id']) && isset($_POST['user_id']) && isset($_POST['comment'])) {

    $task_id = $_POST['task_id'];
    $user_id = $_POST['user_id'];
    $comment_text = $_POST['comment'];
    $success = TaskComments::createComment($task_id, $user_id, $comment_text);

    if ($success) {
        echo 'success';
    } else {
        echo 'error';
    }
} else {
    http_response_code(400);
    echo 'error';
}


