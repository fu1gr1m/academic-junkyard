<?php
require_once __DIR__ . '/../config.php';
require_once __DIR__ . '/../includes/Database.php';
require_once __DIR__ . '/../classes/TaskComments.php';

if ($_SERVER["REQUEST_METHOD"] === "POST") {
    if (isset($_POST['comment_id'])) {
        $commentId = $_POST['comment_id'];
        $success = TaskComments::deleteComment($commentId);
        if ($success) {
            echo 'success';
        } else {
            echo 'error';
        }
    } else {
        echo 'error';
    }
} else {
    http_response_code(400);
    echo 'error';
}
?>
