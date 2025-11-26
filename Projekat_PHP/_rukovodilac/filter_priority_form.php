<?php

require_once __DIR__ . "/../classes/Tasks.php";

$group_id = $_GET['group_id'];
$user_id = $_GET['user_id'];

$all_filtered_tasks = [];

for ($priority = 1; $priority <= 10; $priority++)
{
    $filtered_tasks = Tasks::getTasksByPriority($priority, $group_id);

    $all_filtered_tasks = array_merge($all_filtered_tasks, $filtered_tasks);
}

$encoded_tasks = urlencode(serialize($all_filtered_tasks));

header("Location: view_tasks.php?user_id=" . $user_id . "&" . "group_id=" . $group_id . "&" . "filtered_tasks=" . $encoded_tasks);
die();

?>

