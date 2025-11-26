<?php
require_once __DIR__ . '/../config.php';
require_once __DIR__ . '/../includes/Database.php';
require_once __DIR__ . '/TaskAssignees.php';
require_once __DIR__ . '/TaskAttachments.php';
require_once __DIR__ . '/TaskComments.php';

class Tasks
{
    public $id;
    public $title;
    public $description;
    public $assigned_to;
    public $manager_id;
    public $deadline;
    public $priority;
    public $task_group_id;
    public $attachment_name;
    public $attachment_path;
    public $mime_type;
    public static function getTasksByGroupId($groupId) {
        $database = Database::getInstance();
        $sql = "SELECT * FROM tasks WHERE group_id = :group_id";
        $params = array(':group_id' => $groupId);
        return $database->select('Tasks', $sql, $params);
    }

    public static function createTask($title, $description, $deadline, $priority, $group_id, $leader_id)
    {
        $database = Database::getInstance();

        $sql = 'INSERT INTO tasks (title, description, deadline, priority, group_id, leader_id) 
            VALUES (:title, :description, :deadline, :priority, :group_id, :leader_id)';
        $params = [
            ':title' => $title,
            ':description' => $description,
            ':deadline' => $deadline,
            ':priority' => $priority,
            ':group_id' => $group_id,
            ':leader_id' => $leader_id,
        ];
        $database->insert('Task', $sql, $params);

        $task_id = $database->lastInsertId();

        return $task_id;
    }

    public static function deleteTask($taskId) {
        $database = Database::getInstance();

        TaskAssignees::deleteTaskAssignees($taskId);
        TaskAttachments::deleteTaskAttachments($taskId);
        TaskComments::deleteTaskComments($taskId);

        $sql = 'DELETE FROM tasks WHERE id = :id';
        $params = [':id' => $taskId];
        $database->delete($sql, $params);
    }

    public function getAssignees() {
        $database = Database::getInstance();
        $sql = "SELECT users.*, task_assignees.task_status 
            FROM users 
            INNER JOIN task_assignees ON users.id = task_assignees.assignee_id 
            WHERE task_assignees.task_id = :task_id";
        $params = array(':task_id' => $this->id);
        return $database->select('TaskAssignees', $sql, $params);
    }


    public function getAttachments() {
        $database = Database::getInstance();
        $sql = "SELECT * FROM task_attachments WHERE task_id = :task_id";
        $params = array(':task_id' => $this->id);
        return $database->select('TaskAttachments', $sql, $params);
    }

    public static function updateTask($task_id, $title, $description, $deadline, $priority, $group_id, $leader_id) {
        $database = Database::getInstance();

        $sql = 'UPDATE tasks 
                SET title = :title, 
                    description = :description, 
                    deadline = :deadline, 
                    priority = :priority, 
                    group_id = :group_id, 
                    leader_id = :leader_id 
                WHERE id = :task_id';
        $params = [
            ':task_id' => $task_id,
            ':title' => $title,
            ':description' => $description,
            ':deadline' => $deadline,
            ':priority' => $priority,
            ':group_id' => $group_id,
            ':leader_id' => $leader_id,
        ];

        return $database->update('Task', $sql, $params);
    }

    public static function markTaskAsFinished($task_id)
    {
        $database = Database::getInstance();

        $sql = 'UPDATE tasks SET finished = 1 WHERE id = :task_id';
        $params = [
            ':task_id' => $task_id,
        ];
        $result = $database->update('Tasks', $sql, $params);

        return $result;
    }

    public static function markTaskAsCanceled($task_id)
    {
        $database = Database::getInstance();

        $sql = 'UPDATE tasks SET canceled = 1 WHERE id = :task_id';
        $params = [
            ':task_id' => $task_id,
        ];
        $result = $database->update('Tasks', $sql, $params);

        return $result;
    }

    public static function getTasksByDeadlineRange($start_date, $end_date, $group_id) {
        $database = Database::getInstance();
        $sql = "SELECT * FROM tasks WHERE deadline BETWEEN :start_date AND :end_date AND group_id = :group_id";
        $params = array(
            ':start_date' => $start_date,
            ':end_date' => $end_date,
            ':group_id' => $group_id
        );
        return $database->select('Tasks', $sql, $params);
    }


    public static function getTasksByPriority($priority, $group_id) {
        $database = Database::getInstance();
        $sql = "SELECT * FROM tasks WHERE priority = :priority AND group_id = :group_id";
        $params = array(
            ':priority' => $priority,
            ':group_id' => $group_id
        );
        return $database->select('Tasks', $sql, $params);
    }


    public static function getTasksByAssigneeCount() {
        $database = Database::getInstance();
        $sql = "SELECT tasks.*, COUNT(task_assignees.assignee_id) AS assignee_count 
            FROM tasks 
            LEFT JOIN task_assignees ON tasks.id = task_assignees.task_id 
            GROUP BY tasks.id 
            ORDER BY assignee_count";
        return $database->select('Tasks', $sql);
    }
    public static function getTasksByTitle($group_id) {
        $database = Database::getInstance();
        $sql = "SELECT * FROM tasks WHERE group_id = :group_id ORDER BY title ASC";
        $params = array(
            ':group_id' => $group_id
        );
        return $database->select('Tasks', $sql, $params);
    }


    public static function getTasksByAssignee($assignee_id, $group_id) {
        $database = Database::getInstance();
        $sql = "SELECT tasks.*
            FROM tasks 
            INNER JOIN task_assignees ON tasks.id = task_assignees.task_id 
            WHERE task_assignees.assignee_id = :assignee_id 
            AND tasks.group_id = :group_id";
        $params = array(':assignee_id' => $assignee_id, ':group_id' => $group_id);
        return $database->select('Tasks', $sql, $params);
    }

    public static function getTasksByAssigneeW($assignee_id) {
        $database = Database::getInstance();
        $sql = "SELECT tasks.*
            FROM tasks 
            INNER JOIN task_assignees ON tasks.id = task_assignees.task_id 
            WHERE task_assignees.assignee_id = :assignee_id";
        $params = array(':assignee_id' => $assignee_id);
        return $database->select('Tasks', $sql, $params);
    }

    public static function getLeaderNameByTaskId($task_id)
    {
        $database = Database::getInstance();
        $sql = "SELECT users.full_name 
            FROM tasks 
            INNER JOIN users ON tasks.leader_id = users.id 
            WHERE tasks.id = :task_id";
        $params = array(':task_id' => $task_id);
        $result = $database->select('User', $sql, $params);
        if (!empty($result)) {
            return $result[0]->full_name;
        }
        return null;
    }

    public static function getTasksByDeadline($user_id)
    {
        $database = Database::getInstance();
        $sql = "SELECT tasks.*, task_assignees.task_status 
            FROM tasks 
            INNER JOIN task_assignees ON tasks.id = task_assignees.task_id 
            WHERE task_assignees.assignee_id = :user_id 
            ORDER BY tasks.deadline ASC";
        $params = [':user_id' => $user_id];
        return $database->select('Tasks', $sql, $params);
    }

    public static function getCommonTasks($current_user_id, $assignee_id)
    {
        $database = Database::getInstance();
        $sql = "SELECT tasks.* 
            FROM tasks 
            INNER JOIN task_assignees AS ta1 ON tasks.id = ta1.task_id AND ta1.assignee_id = :current_user_id
            INNER JOIN task_assignees AS ta2 ON tasks.id = ta2.task_id AND ta2.assignee_id = :assignee_id";
        $params = [
            ':current_user_id' => $current_user_id,
            ':assignee_id' => $assignee_id
        ];
        return $database->select('Tasks', $sql, $params);
    }

    public static function getCommonTasksByLeader($current_user_id, $leader_id)
    {
        $database = Database::getInstance();
        $sql = "SELECT tasks.* 
        FROM tasks 
        INNER JOIN task_assignees ON tasks.id = task_assignees.task_id 
        WHERE task_assignees.assignee_id = :current_user_id 
        AND tasks.leader_id = :leader_id";
        $params = [
            ':current_user_id' => $current_user_id,
            ':leader_id' => $leader_id
        ];
        return $database->select('Tasks', $sql, $params);
    }





}