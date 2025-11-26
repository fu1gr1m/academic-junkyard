<?php

require_once __DIR__ . "/../classes/Tasks.php";

if(isset($_GET['group_id'])) {
    $group_id = $_GET['group_id'];
    $user_id = $_GET['user_id'];

    $filtered_tasks = Tasks::getTasksByTitle($group_id);

    $encoded_tasks = urlencode(serialize($filtered_tasks));

    header("Location: view_tasks.php?user_id=" . $user_id . "&" . "group_id=" . $group_id . "&" . "filtered_tasks=" . $encoded_tasks);
    exit();
} else {
    header("Location: default_page.php");
    exit();
}

