<?php
require_once __DIR__ . '/../config.php';
require_once __DIR__ . '/../includes/Database.php';
require_once __DIR__ . '/../classes/TaskComments.php';
require_once __DIR__ . '/../classes/User.php';

if ($_SERVER["REQUEST_METHOD"] === "POST") {
    if (isset($_POST['task_id']) && isset($_POST['user_id'])) {
        $taskId = $_POST['task_id'];
        $user_id = $_POST['user_id'];
        $comments = TaskComments::getCommentsByTaskId($taskId);
        $html = '';
        foreach ($comments as $comment) {
            $timestamp = date('Y-m-d H:i:s', strtotime($comment->timestamp));
            $userName = User::getUserNameById($comment->user_id);
            $html .= '<div class="comment">';
            $html .= '<hr>';
            $html .= '<strong>' . htmlspecialchars($userName) . '</strong>';
            $html .= '<p class="komentar">' . htmlspecialchars($comment->comment) . '</p>';
            $html .= '<span class="timestamp">' . $timestamp . '</span>';
            if ($comment->user_id == $user_id || User::getRoleTypeId($user_id) == 1 || User::getRoleTypeId($user_id) == 2) {
                $html .= '<button class="delete-comment-button" data-comment-id="' . $comment->id . '">Obriši</button>';
            }
            $html .= '</div>';
        }
        echo $html;
    }
    else
    {
        echo "error";
    }
}
else
{
    http_response_code(400);
    echo 'error';
}
