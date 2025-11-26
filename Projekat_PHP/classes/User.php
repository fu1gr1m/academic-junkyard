<?php
require_once __DIR__ . '/../config.php';
require_once __DIR__ . '/../includes/Database.php';
require_once __DIR__ . '/../classes/TaskAssignees.php';
require_once __DIR__ . '/../classes/TaskComments.php';

class User
{
    public $id;
    public $role_type_id;
    public $username;
    public $password;
    public $full_name;
    public $email;
    public $phone_number;
    public $date_of_birth;
    public $token;
    public $token_creation_time;
    public $status;

    public static function registration($role_type_id, $username, $password, $fullname, $email, $phone_number, $date_of_birth, $token)
    {
        $password = hash('sha512', $password);
        $database = Database::getInstance();

        $existing_user = $database->select('User',
            'SELECT * FROM users WHERE username = :username OR email = :email OR phone_number = :phone_number',
            [
                ':username' => $username,
                ':email' => $email,
                ':phone_number' => $phone_number
            ]
        );

        if (!empty($existing_user)) {
            return -1;
        }


        $sql = 'INSERT INTO users (role_type_id, username, password, full_name, email, phone_number, date_of_birth, token) 
            VALUES (:role_type_id, :username, :password, :full_name, :email, :phone_number, :date_of_birth, :token)';


        $params = [
            ':role_type_id' => $role_type_id,
            ':username' => $username,
            ':password' => $password,
            ':full_name' => $fullname,
            ':email' => $email,
            ':phone_number' => $phone_number,
            ':date_of_birth' => $date_of_birth,
            ':token' => $token
        ];

        $database->insert('User', $sql, $params);

        $id = $database->lastInsertId();
        return $id;
    }

    public static function updateUser($user_id, $role_type_id, $username, $fullname, $email, $phone_number, $date_of_birth)
    {
        $database = Database::getInstance();

        $existing_user = $database->select('User',
            'SELECT * FROM users WHERE (username = :username OR email = :email OR phone_number = :phone_number) AND id <> :user_id',
            [
                ':username' => $username,
                ':email' => $email,
                ':phone_number' => $phone_number,
                ':user_id' => $user_id
            ]
        );


        if (!empty($existing_user)) {
            return -1;
        }


        $sql = 'UPDATE users 
            SET role_type_id = :role_type_id, 
                username = :username, 
                full_name = :full_name, 
                email = :email, 
                phone_number = :phone_number, 
                date_of_birth = :date_of_birth 
            WHERE id = :user_id';


        $params = [
            ':user_id' => $user_id,
            ':role_type_id' => $role_type_id,
            ':username' => $username,
            ':full_name' => $fullname,
            ':email' => $email,
            ':phone_number' => $phone_number,
            ':date_of_birth' => $date_of_birth
        ];

        $result = $database->update('User', $sql, $params);

        if ($result) {
            return $user_id;
        } else {
            return false;
        }
    }


    public static function credentials_check($username, $password)
    {
        $password = hash('sha512', $password);
        $database = Database::getInstance();

        $users = $database->select('User',
            'SELECT * FROM users WHERE username LIKE :username AND password LIKE :password',
            [
                ':username' => $username,
                ':password' => $password
            ]
        );

        foreach ($users as $user)
        {
            return $user;
        }
        return null;
    }

    public static function getUserById($userId)
    {
        $database = Database::getInstance();

        $user = $database->select('User',
            'SELECT * FROM users WHERE id = :id',
            [
                ':id' => $userId
            ]
        );


        if (!empty($user)) {

            return $user[0];
        } else {

            return null;
        }
    }

    public static function getUserByToken($token)
    {
        $database = Database::getInstance();

        $user = $database->select('User',
            'SELECT * FROM users WHERE token = :token',
            [
                ':token' => $token
            ]
        );


        if (!empty($user)) {

            return $user[0];
        } else {

            return null;
        }
    }

    public static function activateAccount($userId)
    {
        $database = Database::getInstance();

        $sql = 'UPDATE users SET status = 1 WHERE id = :id';
        $params = [':id' => $userId];

        $database->update('User', $sql, $params);
    }

    public static function getStatusByUsername($username)
    {
        $database = Database::getInstance();
        $user = $database->select('User',
            'SELECT * FROM users WHERE username = :username',
            [
                ':username' => $username,
            ]
        );

        if (!empty($user)) {
            return $user[0]->status;
        } else {
            return null;
        }
    }

    public static function updateActivationToken($userId, $token, $tokenCreationTime)
    {
        $database = Database::getInstance();

        $sql = 'UPDATE users SET token = :token, token_creation_time = :tokenCreationTime WHERE id = :userId';

        $params = [
            ':token' => $token,
            ':tokenCreationTime' => $tokenCreationTime,
            ':userId' => $userId
        ];

        $database->update('User', $sql, $params);
    }

    public static function checkUserByEmail($email) {
        $database = Database::getInstance();
        $user = $database->select('User', 'SELECT * FROM users WHERE email = :email', [':email' => $email]);

        return !empty($user);
    }

    public static function getIdByEmail($email)
    {
        $database = Database::getInstance();

        $user = $database->select('User', 'SELECT id FROM users WHERE email = :email', [':email' => $email]);

        if (!empty($user)) {
            return $user[0]->id;
        } else {
            return null;
        }
    }

    public static function getUserByEmail($email)
    {
        $database = Database::getInstance();

        $user = $database->select('User', 'SELECT * FROM users WHERE email = :email', [':email' => $email]);

        if (!empty($user)) {
            return $user[0];
        } else {
            return null;
        }
    }

    public static function updatePassword($userId, $password)
    {
        $database = Database::getInstance();

        $sql = 'UPDATE users SET password = :password WHERE id = :userId';

        $params = [
            ':password' => $password,
            ':userId' => $userId
        ];

        $database->update('User', $sql, $params);
    }

    public static function getRoleTypeId($userId)
    {
        $database = Database::getInstance();

        $query = 'SELECT role_type_id FROM users WHERE id = :userId';
        $params = [':userId' => $userId];
        $user = $database->select('User', $query, $params);


        if (!empty($user)) {
            return $user[0]->role_type_id;
        } else {
            return null;
        }
    }

    public static function getAllUsersByRoleId($roleId)
    {
        $database = Database::getInstance();

        $users = $database->select('User',
            'SELECT * FROM users WHERE role_type_id = :role_id',
            [
                ':role_id' => $roleId
            ]
        );

        return $users;
    }



    public static function getUserNameById($userId) {

        $database = Database::getInstance();

        $sql = "SELECT full_name FROM users WHERE id = :user_id";

        $params = [':user_id' => $userId];

        $result = $database->select('User', $sql, $params);

        if ($result) {
            $user = $result[0];
            return $user->full_name;
        } else {
            return null;
        }
    }

    public static function getAllUsers()
    {
        $database = Database::getInstance();

        $query = 'SELECT * FROM users';

        $users = $database->select('User', $query);

        return $users;
    }

    public static function deleteUser($user_id)
    {
        $database = Database::getInstance();

        TaskAssignees::deleteTaskAssignees($user_id);
        TaskComments::deleteTaskComments($user_id);

        $sql = 'DELETE FROM users WHERE id = :id';
        $params = [':id' => $user_id];
        $database->delete($sql, $params);
    }
}