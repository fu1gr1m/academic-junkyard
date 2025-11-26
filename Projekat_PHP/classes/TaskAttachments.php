<?php
require_once __DIR__ . '/../includes/Database.php';
class TaskAttachments
{
    public $id;
    public $task_id;
    public $attachment_name;
    public $attachment_path;
    public $mime_type;

    public static function createTaskAttachments($taskId, $attachmentNames, $attachmentPaths, $mimeTypes)
    {
        $database = Database::getInstance();

        for ($i = 0; $i < count($attachmentNames); $i++)
        {
            $sql = 'INSERT INTO task_attachments (task_id, attachment_name, attachment_path, mime_type) 
                    VALUES (:task_id, :attachment_name, :attachment_path, :mime_type)';
            $params = [
                ':task_id' => $taskId,
                ':attachment_name' => $attachmentNames[$i],
                ':attachment_path' => $attachmentPaths[$i],
                ':mime_type' => $mimeTypes[$i]
            ];
            $database->insert('TaskAttachments', $sql, $params);
        }
        return true;
    }

    public static function deleteTaskAttachments($taskId)
    {
        $database = Database::getInstance();

        $sql = 'DELETE FROM task_attachments WHERE task_id = :task_id';
        $params = [':task_id' => $taskId];
        $database->delete($sql, $params);
    }

    public static function updateTaskAttachments($taskId, $attachmentNames, $attachmentPaths, $mimeTypes) {
        $database = Database::getInstance();

        $deleteSql = 'DELETE FROM task_attachments WHERE task_id = :task_id';
        $deleteParams = [':task_id' => $taskId];
        $database->delete($deleteSql, $deleteParams);


        for ($i = 0; $i < count($attachmentNames); $i++) {
            $insertSql = 'INSERT INTO task_attachments (task_id, attachment_name, attachment_path, mime_type) 
                          VALUES (:task_id, :attachment_name, :attachment_path, :mime_type)';
            $insertParams = [
                ':task_id' => $taskId,
                ':attachment_name' => $attachmentNames[$i],
                ':attachment_path' => $attachmentPaths[$i],
                ':mime_type' => $mimeTypes[$i]
            ];
            $database->insert('TaskAttachments', $insertSql, $insertParams);
        }
    }

}