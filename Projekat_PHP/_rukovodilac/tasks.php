<?php
require_once __DIR__ . "/../logistics/checking_logistics.php";
require_once __DIR__ . '/../classes/User.php';
require_once __DIR__ . '/../classes/TaskGroups.php';
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <title>Zadaci</title>
    <style>
        nav
        {
            margin-top: 10px;
        }
        body {
            font-family: Arial, sans-serif;
            background-color: #f2f2f2;
            margin: 0;
            padding: 0;
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
        }

        form {
            width: 400px;
            padding: 20px;
            background-color: #fff;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            display: flex;
            flex-direction: column;
        }

        form label {
            font-weight: bold;
            margin-bottom: 5px;
        }

        form input[type="text"],
        form textarea,
        form select {
            width: 100%;
            padding: 10px;
            margin-bottom: 15px;
            border: 1px solid #ccc;
            border-radius: 3px;
            box-sizing: border-box;
        }

        form select[multiple] {
            height: 100px;
        }

        form button[type="button"],
        form input[type="submit"] {
            width: 100%;
            padding: 10px;
            background-color: #007bff;
            color: #ffffff;
            border: none;
            border-radius: 3px;
            cursor: pointer;
            transition: background-color 0.3s;
        }

        form button[type="button"]:hover,
        form input[type="submit"]:hover {
            background-color: #0056b3;
        }

        form #selectedAssignees {
            margin-bottom: 15px;
        }

        form #selectedAssignees div {
            display: inline-block;
            padding: 5px 10px;
            margin: 5px;
            background-color: #007bff;
            color: #ffffff;
            border-radius: 3px;
        }

        form #selectedAssignees div button {
            margin-left: 10px;
            background-color: #ffffff;
            color: #007bff;
            border: none;
            cursor: pointer;
            transition: color 0.3s;
        }

        form #selectedAssignees div button:hover {
            color: #0056b3;
        }

        body a {
            text-decoration: none;
            color: #007bff;
            margin-top: 10px;
        }

        body a:first-child
        {

        }

        body a:hover {
            color: #0056b3;
        }

        body hr {
            width: 100%;
            margin: 10px 0;
        }

        body h2 {
            margin-top: 0;
        }
    </style>
    <script>
        function addAssignee() {
            var selectElement = document.getElementById("assignees");
            var selectedAssigneesDiv = document.getElementById("selectedAssignees");

            var selectedOptions = [];
            for (var i = 0; i < selectElement.options.length; i++) {
                var option = selectElement.options[i];
                if (option.selected) {
                    selectedOptions.push(option);
                }
            }

            selectedOptions.forEach(function(option) {
                var userId = option.value;
                var userName = option.textContent;

                var existingAssignee = document.querySelector('#selectedAssignees [data-user-id="' + userId + '"]');
                if (!existingAssignee) {

                    var div = document.createElement("div");
                    div.textContent = userName;
                    div.dataset.userId = userId;
                    selectedAssigneesDiv.appendChild(div);


                    var hiddenInput = document.createElement("input");
                    hiddenInput.type = "hidden";
                    hiddenInput.name = "selected_assignees[]";
                    hiddenInput.value = userId;
                    div.appendChild(hiddenInput);


                    var removeButton = document.createElement("button");
                    removeButton.textContent = "Ukloni";
                    removeButton.onclick = function() {
                        removeAssignee(div, option);
                    };
                    div.appendChild(removeButton);
                }


                option.style.display = "none";
            });
        }



        function removeAssignee(div, option) {
            div.parentNode.removeChild(div);

            option.style.display = "block";
            option.selected = false;
        }

    </script>


</head>
<body>
<nav>
<a href="../logistics/logout_logistics.php">Odjavi se</a>
<a href="rukovodilac_dashboard.php">Nazad</a><br>
</nav>
<hr>

<h2>Kreiranje novog zadatka</h2>
<?php
if(isset($_GET['success']) && $_GET['success'] === "1") {
    echo "<p>Zadatak je uspesno kreiran!</p>";
}
?>
<form action="create_task.php" method="POST" enctype="multipart/form-data">
    <?php
    $rukovodilac_id = $_SESSION['user_id'];
    $rukovodilac_ime = User::getUserById($rukovodilac_id);
    $rukovodilac_fullname = $rukovodilac_ime->full_name;
    $izvrsioci = User::getAllUsersByRoleId(3);

    $group_id = $_GET['group_id'];
    $group_name = TaskGroups::getGroupNameById($group_id);
    ?>
    <label for="title">Naslov:</label><br>
    <input type="text" id="title" name="title" required><br><br>

    <label for="description">Opis zadatka:</label><br>
    <textarea id="description" name="description" rows="4" cols="50" required></textarea><br><br>

    <label for="deadline">Rok izvršenja:</label><br>
    <input type="datetime-local" id="deadline" name="deadline" required><br><br>

    <label for="priority">Prioritet:</label><br>
    <select id="priority" name="priority" required>
        <?php

        for ($i = 1; $i <= 10; $i++) {
            echo "<option value='$i'>$i</option>";
        }
        ?>
    </select><br><br>


    <label for="group_id">Grupa zadatka:</label><br>
    <input type="hidden" id="group_id" name="group_id" value="<?php echo $group_id?>" required>
    <input type="text" id="group_name" name="group_name" value="<?php echo $group_name?>" required readonly><br><br>

    <label for="assignees">Izvršioci:</label><br>
    <select id="assignees" name="assignees[]" multiple>
        <?php
        foreach ($izvrsioci as $izvrsioc) {
            echo '<option value="' . $izvrsioc->id . '">' . $izvrsioc->full_name . '</option>';
        }
        ?>
    </select>
    <button type="button" onclick="addAssignee()">Dodaj izvršioca</button><br><br>

    <label for="selectedAssignees">Izabrani izvršioci:</label><br>
    <div id="selectedAssignees">
        <!-- Prikaz izvrsioca -->
    </div>


    <label for="leader">Rukovodilac:</label><br>
    <input type="hidden" id="leader_id" name="leader_id" value="<?php echo $rukovodilac_id ?>" required>
    <input type="text" id="leader" name="leader" value="<?php echo $rukovodilac_fullname?>" required readonly><br><br>

    <label for="attachments">Prilozi:</label><br>
    <input type="file" id="attachments" name="attachments[]" multiple><br><br>

    <input type="submit" value="Kreiraj zadatak">
</form>
</body>
</html>