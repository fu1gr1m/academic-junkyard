<?php

require_once __DIR__ . "/../logistics/checking_logistics.php";
require_once __DIR__ . '/../classes/Tasks.php';

$user_id = $_GET['user_id'];

$filtered_tasks = Tasks::getTasksByDeadline($user_id);


$encoded_tasks = urlencode(serialize($filtered_tasks));
$url = "izvrsilac_dashboard.php?filtered_tasks={$encoded_tasks}";
header("Location: $url");
die();
