<?php

require_once __DIR__ . "/../classes/Tasks.php";

if (isset($_GET['start_date']) && isset($_GET['end_date'])) {
    $start_date = $_GET['start_date'];
    $end_date = $_GET['end_date'];
    $group_id = $_GET['group_id'];
    $user_id = $_GET['user_id'];

    $start_date = date("Y-m-d", strtotime($start_date));
    $end_date = date("Y-m-d", strtotime($end_date));

    $filtered_tasks = Tasks::getTasksByDeadlineRange($start_date, $end_date, $group_id);
    $encoded_tasks = urlencode(serialize($filtered_tasks));
    if(count($filtered_tasks) === 0)
    {
        header("Location: view_tasks.php?user_id={$user_id}&group_id={$group_id}&filtered_tasks={$encoded_tasks}&filter=1");
        die();
    }

    header("Location: view_tasks.php?user_id=" . $user_id . "&" . "group_id=" . $group_id . "&" . "filtered_tasks=" . $encoded_tasks);
    die();

} else {

}
