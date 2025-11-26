<?php
require_once __DIR__ . '/../config.php';
require_once __DIR__ . '/../includes/Database.php';

class TaskAssignees
{
    public $id;
    public $task_id;
    public $assignee_id;


    public static function createTaskAssignee($task_id, $assignee_ids)
    {
        $database = Database::getInstance();
        foreach ($assignee_ids as $assignee_id) {
            $sql = 'INSERT INTO task_assignees (task_id, assignee_id) 
                VALUES (:task_id, :assignee_id)';
            $params = [
                ':task_id' => $task_id,
                ':assignee_id' => $assignee_id
            ];
            $database->insert('TaskAssignees', $sql, $params);
        }
    }

    public static function getAssigneesByTaskId($task_id)
    {
        $database = Database::getInstance();
        $sql = 'SELECT * FROM task_assignees WHERE task_id = :task_id';
        $params = [':task_id' => $task_id];
        return $database->select('TaskAssignees', $sql, $params);
    }

    public static function deleteTaskAssignees($taskId) {
        $database = Database::getInstance();

        // Brišemo sve izvršioce povezane sa zadatkom
        $sql = 'DELETE FROM task_assignees WHERE task_id = :task_id';
        $params = [':task_id' => $taskId];
        $database->delete($sql, $params);
    }

    public static function updateTaskAssignees($task_id, $assignee_ids) {
        $database = Database::getInstance();

        $deleteSql = 'DELETE FROM task_assignees WHERE task_id = :task_id';
        $deleteParams = [':task_id' => $task_id];
        $database->delete($deleteSql, $deleteParams);

        foreach ($assignee_ids as $assignee_id) {
            $insertSql = 'INSERT INTO task_assignees (task_id, assignee_id) 
                          VALUES (:task_id, :assignee_id)';
            $insertParams = [
                ':task_id' => $task_id,
                ':assignee_id' => $assignee_id
            ];
            $database->insert('TaskAssignees', $insertSql, $insertParams);
        }
    }

    public static function updateTaskStatus($task_id, $assignee_id, $status) {
        $database = Database::getInstance();

        $sql = 'UPDATE task_assignees SET task_status = :status 
            WHERE task_id = :task_id AND assignee_id = :assignee_id';
        $params = [
            ':status' => $status,
            ':task_id' => $task_id,
            ':assignee_id' => $assignee_id
        ];

        return $database->update('TaskAssignees', $sql, $params);
    }

    public static function getCurrentTaskStatus($task_id, $assignee_id)
    {
        $database = Database::getInstance();
        $sql = "SELECT task_status FROM task_assignees WHERE task_id = :task_id AND assignee_id = :assignee_id";
        $params = [
            ':task_id' => $task_id,
            ':assignee_id' => $assignee_id
        ];
        $result = $database->select('TaskAssignees', $sql, $params);
        if (!empty($result)) {
            return $result[0]->task_status;
        }
        return null;
    }



}