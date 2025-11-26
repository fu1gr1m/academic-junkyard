<?php
require_once __DIR__ . '/../config.php';
require_once __DIR__ . '/../includes/Database.php';

class Roles
{
    public $id;
    public $name;
    public $priority;
    public static function getAllRoles()
    {
        $database = Database::getInstance();

        $roles = $database->select('roles', 'SELECT id, name FROM roles');

        return $roles;
    }

    public static function addRole($roleName)
    {
        $database = Database::getInstance();
        $sql = 'INSERT INTO roles (name) VALUES (:roles)';
        $params = [
            ':roles' => $roleName
        ];

        $result = $database->insert('Roles', $sql, $params);
        if ($result) {
            return true;
        } else {
            return false;
        }
    }

    public static function changeRoleName($roleId, $newRoleName)
    {
        $database = Database::getInstance();
        $sql = 'UPDATE roles SET name = :new_name WHERE id = :role_id';
        $params = [
            ':new_name' => $newRoleName,
            ':role_id' => $roleId
        ];

        $result = $database->update('Roles', $sql, $params);
        if ($result) {
            return true;
        } else {
            return false;
        }
    }

}