<?php
require_once __DIR__ . '/../config.php';
require_once __DIR__ . '/../includes/Database.php';

class TaskComments
{
    public $id;
    public $task_id;
    public $user_id;
    public $comment;
    public $timestamp;

    public static function createComment($taskId, $userId, $commentText)
    {
        $database = Database::getInstance();

        $sql = 'INSERT INTO task_comments (task_id, user_id, comment, timestamp) VALUES (:task_id, :user_id, :comment, NOW())';

        $params = [
            ':task_id' => $taskId,
            ':user_id' => $userId,
            ':comment' => $commentText,
        ];

        $database->insert('Comment', $sql, $params);

        return $database->lastInsertId();
    }
    public static function getCommentsByTaskId($taskId)
    {
        $database = Database::getInstance();

        $sql = 'SELECT * FROM task_comments WHERE task_id = :task_id ORDER BY timestamp DESC';

        $params = [':task_id' => $taskId];

        $comments = $database->select('TaskComments', $sql, $params);

        return $comments;
    }

    public static function deleteTaskComments($taskId) {
        $database = Database::getInstance();

        $sql = 'DELETE FROM task_comments WHERE task_id = :task_id';
        $params = [':task_id' => $taskId];
        $database->delete($sql, $params);
    }

    public static function deleteComment($commentId) {
        $database = Database::getInstance();
        $sql = 'DELETE FROM task_comments WHERE id = :id';
        $params = [':id' => $commentId];
        return $database->delete($sql, $params);
    }



}