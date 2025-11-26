<?php

require_once __DIR__ . "/../classes/Tasks.php";

if(isset($_GET['leader_id']) && isset($_GET['user_id'])) {
    $leader_id = $_GET['leader_id'];
    $user_id = $_GET['user_id'];
    $filtered_tasks = Tasks::getCommonTasksByLeader($user_id, $leader_id);
    $encoded_tasks = urlencode(serialize($filtered_tasks));

    if(count($filtered_tasks) === 0)
    {
        header("Location: izvrsilac_dashboard.php?filtered_tasks={$encoded_tasks}&filter=1");
        die();
    }

    $url = "izvrsilac_dashboard.php?filtered_tasks={$encoded_tasks}";
    header("Location: $url");
    exit();
} else {
    echo "error";
    exit();
}