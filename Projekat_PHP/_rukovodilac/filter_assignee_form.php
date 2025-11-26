<?php

require_once __DIR__ . "/../classes/Tasks.php";

if(isset($_GET['group_id']) && isset($_GET['assignee_id'])) {
    $group_id = $_GET['group_id'];
    $assignee_id = $_GET['assignee_id'];
    $user_id = $_GET['user_id'];

    $filtered_tasks = Tasks::getTasksByAssignee($assignee_id, $group_id);



    $encoded_tasks = urlencode(serialize($filtered_tasks));

    if(count($filtered_tasks) === 0)
    {
        header("Location: view_tasks.php?user_id={$user_id}&group_id={$group_id}&filtered_tasks={$encoded_tasks}&filter=0");
        die();
    }

    header("Location: view_tasks.php?user_id=" . $user_id . "&" . "group_id=" . $group_id . "&" . "filtered_tasks=" . $encoded_tasks);
    exit();
} else {
    header("Location: default_page.php");
    exit();
}

