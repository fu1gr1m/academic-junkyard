<?php
if(isset($_GET['group_id'])) {
    $group_id = $_GET['group_id'];
    $user_id = $_GET['user_id'];
    header("Location: view_tasks.php?user_id=" . $user_id . "&" . "group_id=" . $group_id);
    die();
}
