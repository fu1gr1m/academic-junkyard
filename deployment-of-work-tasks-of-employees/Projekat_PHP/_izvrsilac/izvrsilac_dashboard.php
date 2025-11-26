<?php
require_once __DIR__ . "/../logistics/checking_logistics.php";
require_once __DIR__ . '/../classes/User.php';
require_once __DIR__ . '/../classes/Tasks.php';
require_once __DIR__ . '/../classes/TaskAssignees.php';

$user_id = $_SESSION['user_id'];

$user_role_id = User::getRoleTypeId($user_id);
$assignees_fetched = User::getAllUsersByRoleId(3);
$leader_fetched = User::getAllUsersByRoleId(2);
$filtered_tasks = isset($_GET['filtered_tasks']) ? unserialize(urldecode($_GET['filtered_tasks'])) : null;


if ($user_role_id != 3) {
    header('Location: ../pages/login.php?access=0');
    die();
}

$tasks = Tasks::getTasksByAssigneeW($user_id);
if (!empty($filtered_tasks)) {
    $tasks = $filtered_tasks;
}
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <title>Zadaci</title>
    <script>
        function toggleAssigneeShow() {
            var form = document.getElementById("filterAssigneeForm");
            var dateRange = form.querySelector(".assigneeDropdown");

            if (dateRange.style.display === "none") {
                dateRange.style.display = "block";
            } else {
                dateRange.style.display = "none";
            }
        }

        function toggleLeaderShow() {
            var form = document.getElementById("filterLeaderForm");
            var dropdown = form.querySelector(".leaderDropdown");

            if (dropdown.style.display === "none") {
                dropdown.style.display = "block";
            } else {
                dropdown.style.display = "none";
            }
        }

        function toggleCommentBox(button) {
            var dropdown = button.nextElementSibling;

            if (dropdown.style.display === "none" || dropdown.style.display === "") {
                dropdown.style.display = "block";
            } else {
                dropdown.style.display = "none";
            }
        }

        function sendComment(userId, taskId, commentText) {
            var xhr = new XMLHttpRequest();
            var url = 'save_comment.php';
            xhr.open('POST', url, true);
            xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
            xhr.onload = function () {
                console.log(xhr.responseText);
                if (xhr.status === 200) {
                    if (xhr.responseText === 'success') {
                        console.log('Komentar uspešno poslat.');
                        displayComments(taskId, userId);
                    } else {
                        console.error('Došlo je do greške prilikom slanja komentara.');
                    }
                } else {
                    console.error('Došlo je do greške prilikom slanja AJAX zahtjeva.');
                }
            };
            xhr.send('task_id=' + taskId + '&user_id=' + userId + '&comment=' + commentText);
            displayComments(taskId, userId);
        }

        function displayComments(taskId, userId) {
            var commentContainer = document.querySelector('.task-box[data-task-id="' + taskId + '"][data-user-id="' + userId + '"] .comment-container');

            commentContainer.innerHTML = '';

            var xhr = new XMLHttpRequest();
            var url = 'get_comments.php';
            xhr.open('POST', url, true);
            xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
            xhr.onload = function() {
                if (xhr.status === 200) {
                    commentContainer.innerHTML = xhr.responseText;
                } else {
                    console.error('Došlo je do greške prilikom dobijanja komentara.');
                }
            };
            xhr.send('task_id=' + taskId + '&user_id=' + userId);
        }

        document.addEventListener('DOMContentLoaded', function() {
            document.querySelectorAll(".send-comment").forEach(function(button) {
                button.addEventListener('click', function() {
                    var userId = this.getAttribute('data-user-id');
                    var taskId = this.getAttribute('data-task-id');
                    var commentText = this.parentElement.querySelector(".comment-text").value;
                    console.log(userId); //vraca id kako trebaa greska je negde drugde
                    if (commentText.trim() === '') {
                        alert('Molimo vas unesite tekst komentara.');
                        return;
                    }
                    sendComment(userId, taskId, commentText);
                    displayComments(taskId, userId);
                });
            });

            document.querySelectorAll(".toggle-comments").forEach(function(button) {
                button.addEventListener('click', function() {
                    var taskId = this.getAttribute('data-task-id');
                    var userId = this.getAttribute('data-user-id');
                    displayComments(taskId, userId);
                });
            });
        });

        document.addEventListener('click', function(event) {
            if (event.target && event.target.classList.contains('delete-comment-button')) {
                console.log("Button clicked.")
                var commentId = event.target.getAttribute('data-comment-id');
                var taskBox = event.target.closest('.task-box');
                var taskId = taskBox.getAttribute('data-task-id');
                var userId = taskBox.getAttribute('data-user-id');

                deleteComment(commentId, taskId, userId);
            }
        });


        function deleteComment(commentId, taskId, userId) {
            var xhr = new XMLHttpRequest();
            var url = 'delete_comment.php';
            xhr.open('POST', url, true);
            xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
            xhr.onload = function() {
                if (xhr.status === 200) {
                    displayComments(taskId, userId);
                } else {
                    console.error('Došlo je do greške prilikom brisanja komentara.');
                }
            };
            console.log('Brisanje komentara za commentId: ' + commentId);
            xhr.send('comment_id=' + commentId);
        }

    </script>
    <style>
        body
        {
            font-family: Arial, sans-serif;
            background-color: #f2f2f2;
            padding: 1px;
            display: flex;
            flex-wrap: wrap;
            justify-content: center;
            align-items: flex-start;
        }
        h2
        {
            text-align: center;
            width: 100%;
        }

        h3
        {
            background-color: #007bff;
            color: #ffffff;
            text-align: center;
            width: 100%;
        }
        .task-box
        {
            background-color: #fff;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            padding: 20px;
            margin-right: 20px;
            margin-bottom: 20px;
            width: calc(33.33% - 20px);
            box-sizing: border-box;
        }
        .task-box strong
        {
            margin-right: 5px;
        }
        .task-box ul
        {
            list-style-type: none;
            padding: 0;
            margin: 0;
        }
        .task-box ul li
        {
            margin-bottom: 5px;
        }
        .task-box hr
        {
            border: none;
            border-top: 1px solid #ccc;
            margin-top: 10px;
            margin-bottom: 10px;
        }
        .action-buttons
        {
            display: flex;
            justify-content: space-between;
            margin-top: 10px;
        }
        .action-buttons button
        {
            padding: 5px 10px;
            background-color: #007bff;
            color: #ffffff;
            border: none;
            border-radius: 3px;
            cursor: pointer;
            transition: background-color 0.3s;
        }
        .action-buttons button:hover
        {
            background-color: #0056b3;
        }
        nav {
            display: flex;
            margin-bottom: 20px;
        }

        .nav-button {
            padding: 5px 10px;
            background-color: #007bff;
            color: #ffffff;
            border: none;
            border-radius: 3px;
            cursor: pointer;
            transition: background-color 0.3s;
            margin-left: 10px;
        }

        .nav-button:hover {
            background-color: #0056b3;
        }

        hr {
            width: 100%;
            margin-top: 10px;

        }
        p {
            margin: 10px 0;
            text-align: center;
            color: red;
            width: 100%;
        }

        .toggle-comments {
            padding: 5px 10px;
            background-color: #007bff;
            color: #ffffff;
            border: none;
            border-radius: 3px;
            cursor: pointer;
            transition: background-color 0.3s;
            margin-bottom: 10px;
            margin-top: 10px;
        }

        .toggle-comments:hover {
            background-color: #0056b3;
        }

        .comment-box {
            display: none;
            margin-top: 10px;
        }

        .comment-text {
            width: calc(100% - 30px);
            padding: 5px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 3px;
            display: block;
        }

        .send-comment {
            padding: 5px 10px;
            background-color: #007bff;
            color: #ffffff;
            border: none;
            border-radius: 3px;
            cursor: pointer;
            transition: background-color 0.3s;
        }

        .send-comment:hover {
            background-color: #0056b3;
        }

        .komentar
        {
            color: black;
            text-align: left;
        }

    </style>
</head>
<body>
<form action="../logistics/logout_logistics.php" method="post">
    <button class="nav-button" type="submit">Odjavi se</button>
</form>

<hr>

<nav>
    <form action="task_deadline_filter.php" method="get">
        <input type="hidden" name="user_id" value="<?php echo $user_id; ?>">
        <button class="nav-button" type="submit" name="filter" value="date">Filtriraj po datumu zavrsetka</button>
    </form>

    <form id="filterAssigneeForm" action="task_assignee_filter.php" method="get">
        <button id="filterAssigneeButton" class="nav-button" type="button" onclick="toggleAssigneeShow()">Filtriraj po izvrsiocima</button>
        <div class="assigneeDropdown" style="display: none;">
            <form action="izvrsilac_dashboard.php" method="get">
                <select id="assigneeSelect" name="assignee_id">
                    <?php foreach ($assignees_fetched as $assignee): ?>
                        <option value="<?php echo $assignee->id; ?>"><?php echo $assignee->full_name; ?></option>
                    <?php endforeach; ?>
                </select>
                <input type="hidden" name="user_id" value="<?php echo $user_id; ?>">
                <button id="filterAssigneeSubmit" class="nav-button" type="submit">Filtriraj</button>
            </form>
        </div>
    </form>

    <form id="filterLeaderForm" action="task_leader_filter.php" method="get">
        <button id="filterLeaderButton" class="nav-button" type="button" onclick="toggleLeaderShow()">Filtriraj po rukovodiocima</button>
        <div class="leaderDropdown" style="display: none;">
            <form action="izvrsilac_dashboard.php" method="get">
                <select id="assigneeSelect2" name="leader_id">
                    <?php foreach ($leader_fetched as $leader): ?>
                        <option value="<?php echo $leader->id; ?>"><?php echo $leader->full_name; ?></option>
                    <?php endforeach; ?>
                </select>
                <input type="hidden" name="user_id" value="<?php echo $user_id; ?>">
                <button id="filterAssigneeSubmit2" class="nav-button" type="submit">Filtriraj</button>
            </form>
        </div>
    </form>


    <form action="task_clear_filter.php" method="get">
        <input type="hidden" name="user_id" value="<?php echo $user_id; ?>">
        <button class="nav-button" type="submit" name="filter" value="date">Ocisti filtere</button>
    </form>
</nav>

<?php
if(isset($filtered_tasks))
{

    if(isset($_GET['filter']) && $_GET['filter'] === "0")
    {
        echo "<h2>Zadaci dodeljeni vama</h2>";
        echo "<p>Ne postoje zadaci za izabranog korisnika!</p>";

    }
    elseif(isset($_GET['filter']) && $_GET['filter'] === "1")
    {
        echo "<h2>Zadaci dodeljeni vama</h2>";
        echo "<p>Ne postoje zadaci za izabranog rukovodioca!</p>";

    }
    else
    {
        echo "<h2>Zadaci dodeljeni vama</h2>";
    }
}
else
{
    echo "<h2>Zadaci dodeljeni vama</h2>";
}
?>

<?php foreach ($tasks as $task): ?>
    <div class="task-box" data-task-id="<?php echo $task->id; ?>" data-user-id="<?php echo $user_id; ?>">
        <?php if ($task->finished == 1): ?>
            <h3>ZADATAK JE ZAVRŠEN</h3>
        <?php elseif ($task->canceled == 1): ?>
            <h3>ZADATAK JE OTKAZAN</h3>
        <?php endif; ?>
        <strong>Naslov:</strong> <?php echo $task->title; ?><br>
        <strong>Opis:</strong> <?php echo $task->description; ?><br>
        <strong>Deadline:</strong> <?php echo $task->deadline; ?><br>
        <strong>Prioritet:</strong> <?php echo $task->priority; ?><br>
        <strong>Rukovodilac:</strong> <?php echo Tasks::getLeaderNameByTaskId($task->id);?><br>
        <?php if(!empty($task->getAssignees())): ?>
            <strong>Izvrsioci:</strong>
            <ul>
                <?php foreach ($task->getAssignees() as $assignee): ?>
                    <li><?php echo $assignee->full_name;
                        if($assignee->task_status === 0)
                        {
                            echo " - Nije zavrsio zadatak";
                        }
                        else
                        {
                            echo " - Gotov";
                        }
                        ?></li>
                <?php endforeach; ?>
            </ul>
        <?php endif; ?>

        <?php if(!empty($task->getAttachments())): ?>
            <strong>Prilozi:</strong>
            <ul>
                <?php foreach ($task->getAttachments() as $attachment): ?>
                    <li><a href="<?php echo $attachment->attachment_path; ?>" download><?php echo $attachment->attachment_name;?></a></li>
                <?php endforeach; ?>
            </ul>
        <?php endif; ?>

        <div class="action-buttons">
            <?php if ($task->canceled == 1 || $task->finished == 1 || TaskAssignees::getCurrentTaskStatus($task->id, $user_id) == 1): ?>

            <?php else: ?>
                <form action="task_completed.php" method="post">
                    <input type="hidden" name="user_id" value="<?php echo $user_id; ?>">
                    <input type="hidden" name="task_id" value="<?php echo $task->id; ?>">
                    <button type="submit" name="complete_task">Završen</button>
                </form>
            <?php endif; ?>
        </div>
        <button type="button" class="toggle-comments" onclick="toggleCommentBox(this)" data-user-id="<?php echo $user_id; ?>" data-task-id="<?php echo $task->id; ?>">Komentari</button>
        <div class="comment-box" style="display: none;">
            <textarea name="comment-text" class="comment-text" rows="4" placeholder="Unesite vaš komentar"></textarea>
            <button type="button" class="send-comment" data-user-id="<?php echo $user_id; ?>" data-task-id="<?php echo $task->id; ?>">Pošalji</button>
            <div class="comment-container">
                <!-- Ovde će se prikazivati komentari -->
            </div>
        </div>

    </div>
<?php endforeach; ?>
</body>
</html>