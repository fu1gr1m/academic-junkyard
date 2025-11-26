<?php
require_once __DIR__ . '/../config.php';
require_once __DIR__ . '/../includes/Database.php';
require_once __DIR__ . '/Tasks.php';

class TaskGroups
{
    public $id;
    public $name;


    public static function getAllTaskGroups() {
        $database = Database::getInstance();
        $task_groups = $database->select('TaskGroups', 'SELECT * FROM task_groups');
        return $task_groups;
    }
    public function addTaskGroup() {
        $database = Database::getInstance();
        $sql = 'INSERT INTO task_groups (name) VALUES (:name)';
        $params = [':name' => $this->name];
        $database->insert('TaskGroups', $sql, $params);
    }
    public static function updateGroupName($group_id, $new_name) {
        $database = Database::getInstance();
        $sql = 'UPDATE task_groups SET name = :new_name WHERE id = :group_id';
        $params = [':new_name' => $new_name, ':group_id' => $group_id];
        $database->update('TaskGroups', $sql, $params);
    }

    public static function deleteTaskGroup($groupId) {
        $database = Database::getInstance();

        $sqlSelectTasks = 'SELECT id FROM tasks WHERE group_id = :group_id';
        $paramsSelectTasks = [':group_id' => $groupId];
        $tasks = $database->select('Tasks', $sqlSelectTasks, $paramsSelectTasks);


        foreach ($tasks as $task) {
            Tasks::deleteTask($task->id);
        }

        $sqlDeleteGroup = 'DELETE FROM task_groups WHERE id = :id';
        $paramsDeleteGroup = [':id' => $groupId];
        $database->delete($sqlDeleteGroup, $paramsDeleteGroup);
    }


    public static function getGroupNameById($groupId)
    {
        $database = Database::getInstance();

        $group = $database->select('TaskGroups',
            'SELECT name FROM task_groups WHERE id = :id',
            [
                ':id' => $groupId
            ]
        );

        if (!empty($group)) {
            return $group[0]->name;
        } else {
            return null;
        }
    }

}



