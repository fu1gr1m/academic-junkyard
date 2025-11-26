-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 16, 2024 at 03:32 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `php_projekat`
--

-- --------------------------------------------------------

--
-- Table structure for table `roles`
--

CREATE TABLE `roles` (
  `id` int(10) UNSIGNED NOT NULL,
  `name` varchar(80) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `roles`
--

INSERT INTO `roles` (`id`, `name`) VALUES
(1, 'Administrator'),
(2, 'Rukovodilac Odeljenja'),
(3, 'Izvrsilac'),
(6, 'NoviTipKorisnika');

-- --------------------------------------------------------

--
-- Table structure for table `tasks`
--

CREATE TABLE `tasks` (
  `id` int(10) UNSIGNED NOT NULL,
  `title` varchar(191) NOT NULL,
  `description` text NOT NULL,
  `deadline` datetime NOT NULL,
  `priority` int(11) NOT NULL,
  `group_id` int(11) UNSIGNED NOT NULL,
  `leader_id` int(11) UNSIGNED NOT NULL,
  `finished` tinyint(4) NOT NULL DEFAULT 0,
  `canceled` tinyint(4) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `tasks`
--

INSERT INTO `tasks` (`id`, `title`, `description`, `deadline`, `priority`, `group_id`, `leader_id`, `finished`, `canceled`) VALUES
(103, 'Zadatak 1', 'Zadatak 1', '2024-03-29 11:01:00', 1, 34, 47, 0, 0),
(104, 'Zadatak 2', 'Zadatak 2', '2024-03-30 12:03:00', 2, 34, 47, 1, 0),
(105, 'Zadatak 3', 'Zadatak 3', '2024-03-24 12:03:00', 6, 34, 47, 0, 1),
(106, 'Zadatak 4', 'Zadatak 4', '2024-11-18 11:01:00', 4, 34, 47, 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `task_assignees`
--

CREATE TABLE `task_assignees` (
  `id` int(10) UNSIGNED NOT NULL,
  `task_id` int(10) UNSIGNED NOT NULL,
  `assignee_id` int(10) UNSIGNED NOT NULL,
  `task_status` tinyint(4) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `task_assignees`
--

INSERT INTO `task_assignees` (`id`, `task_id`, `assignee_id`, `task_status`) VALUES
(199, 103, 55, 0),
(200, 103, 54, 0),
(201, 104, 51, 0),
(202, 104, 65, 0),
(203, 105, 54, 0),
(204, 106, 64, 0);

-- --------------------------------------------------------

--
-- Table structure for table `task_attachments`
--

CREATE TABLE `task_attachments` (
  `id` int(10) UNSIGNED NOT NULL,
  `task_id` int(10) UNSIGNED NOT NULL,
  `attachment_name` varchar(355) NOT NULL,
  `attachment_path` varchar(355) NOT NULL,
  `mime_type` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `task_attachments`
--

INSERT INTO `task_attachments` (`id`, `task_id`, `attachment_name`, `attachment_path`, `mime_type`) VALUES
(48, 103, '810lrsCYpKL.png', 'C:\\xampp\\tmp\\phpEFF9.tmp', 'image/png');

-- --------------------------------------------------------

--
-- Table structure for table `task_comments`
--

CREATE TABLE `task_comments` (
  `id` int(10) UNSIGNED NOT NULL,
  `task_id` int(10) UNSIGNED NOT NULL,
  `user_id` int(10) UNSIGNED NOT NULL,
  `comment` text NOT NULL,
  `timestamp` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `task_comments`
--

INSERT INTO `task_comments` (`id`, `task_id`, `user_id`, `comment`, `timestamp`) VALUES
(152, 105, 52, 'Neki novi komentar', '2024-03-16 03:27:30'),
(153, 104, 52, 'Neki komentar', '2024-03-16 03:27:38'),
(154, 104, 51, 'Jos neki komentar', '2024-03-16 03:28:19');

-- --------------------------------------------------------

--
-- Table structure for table `task_groups`
--

CREATE TABLE `task_groups` (
  `id` int(10) UNSIGNED NOT NULL,
  `name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `task_groups`
--

INSERT INTO `task_groups` (`id`, `name`) VALUES
(34, 'Grupa 1'),
(35, 'Grupa 2'),
(36, 'Grupa 3');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) UNSIGNED NOT NULL,
  `role_type_id` int(10) UNSIGNED NOT NULL,
  `username` varchar(20) NOT NULL,
  `password` varchar(255) NOT NULL,
  `full_name` varchar(50) NOT NULL,
  `email` varchar(255) NOT NULL,
  `phone_number` varchar(255) DEFAULT NULL,
  `date_of_birth` date DEFAULT NULL,
  `token` varchar(255) NOT NULL,
  `token_creation_time` timestamp NOT NULL DEFAULT current_timestamp(),
  `status` tinyint(4) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `role_type_id`, `username`, `password`, `full_name`, `email`, `phone_number`, `date_of_birth`, `token`, `token_creation_time`, `status`) VALUES
(47, 1, 'Fulgrim', '1d255920ada6ac787656b393e9e0b5845aa1d975f1db4015f80904da4c232786444e6dc87e719981bd4d8596b4d0f937d6e464cbd7424a3a0aff6059fa0caee1', 'Admin', 'stojiljkovics@hotmail.rs', '0611546141', '2024-03-27', '55ca4b2a67c75d1fcedbedff62f49c30c7ac9528b57011353fa45cd441b0f2a35f650ff89bc579cf3a97d542bfad2c5ce1c7f191a6c617904878681012e01749', '2024-03-15 00:41:09', 1),
(51, 3, 'Voja', '401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429080fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1', 'Vojislav Vojkovski', 'stojiljkovicstefan42@gmail.com', '1515015348', '2024-03-13', 'f6615c55fa3f0a153d22a837aff4570c4f3e5b7fa5b9d68fd25e7c4128000578b7c2120c710c303c886cd86a924825c75965f2f748f6a1b52c4557d6124b884f', '2024-03-10 18:46:54', 1),
(52, 2, 'Milan', '401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429080fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1', 'Milan', 'stopiguy11@gmail.com', '051849455', '2024-03-15', '523359f546fbdb8e93e8b683b1f2e201e34a2547ba5d85cecf599e1547799a84cb53a7fca1adad9102a4eceb34b0ea60a5e67f9d97c7ecc858b4c468e55b0334', '2024-03-10 18:47:28', 1),
(53, 2, 'Aleksandar', '401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429080fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1', 'Aleksandar Majkovski', 'waiodjiawodjowa@gmail.com', NULL, NULL, '', '2024-03-11 18:00:01', 1),
(54, 3, 'Nemanja', '401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429080fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1', 'Nemanja Ilic', 'sadkowadk@gmail.com', NULL, NULL, '', '2024-03-11 18:00:23', 1),
(55, 3, 'Stefanos', '401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429080fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1', 'Stefanos Milanos', 'awjdjwoapdw@hotmail.rs', '0614584649', '2024-03-30', '', '2024-03-13 15:54:02', 1),
(64, 3, 'Leksa', 'fd4341d903abb36bacfb1128166a0f69ea5dd4edea1e65841f90ef2c21b43f98433e86b86562d2fcf941ec3fc4e90172c44480c7e409635eb3e23453cdefb5b0', 'Aleksandrica', 'nekimejl@gmail.com', '0612412321', '2003-03-10', '456de89616128bc9a3581fb74e8b21d563127522c86e6febd2ce9aeccb9c8c80dc82e39fb40c82357994e8e6d37c08f9490a3c25d06ccad2b4b65ef4199ac64c', '2024-03-16 01:12:01', 1),
(65, 3, 'dwdaawdawdawdadw', '73941847d9611927275d93139981ee78316de50bc51bf398f8ccdd778c7723f370cb252c5293c085ec3c6a3d185246837ed71d651a679cb680793581ad77ac24', 'awdwadwadaw', 'wiodjwaiojdioad@gmail.com', NULL, NULL, 'f62e203afd4dc1e78360349309e43f4a49be5cdd6bb5abf3f71d2f260512263c1c7403b17c7d02057bd714be8c3b1b064162fc27ca28dea9ed5838fb1974a3c8', '2024-03-16 02:15:22', 1),
(66, 1, 'Administrator', '401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429080fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1', 'Administrator', 'administrator@gmail.com', NULL, NULL, 'e6b51e7ecf0ef1e906ecae66e87b59f32d59db82932cc884d94d3e765e09bb16a4bb02eafa7d55831d340938a8a642cb9f6df4f9edcbcf9e51a3365c42c40081', '2024-03-16 02:30:26', 1);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `roles`
--
ALTER TABLE `roles`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tasks`
--
ALTER TABLE `tasks`
  ADD PRIMARY KEY (`id`),
  ADD KEY `task_group_id` (`group_id`),
  ADD KEY `leader_id` (`leader_id`);

--
-- Indexes for table `task_assignees`
--
ALTER TABLE `task_assignees`
  ADD PRIMARY KEY (`id`),
  ADD KEY `task_id` (`task_id`),
  ADD KEY `assignee_id` (`assignee_id`);

--
-- Indexes for table `task_attachments`
--
ALTER TABLE `task_attachments`
  ADD PRIMARY KEY (`id`),
  ADD KEY `task_id` (`task_id`);

--
-- Indexes for table `task_comments`
--
ALTER TABLE `task_comments`
  ADD PRIMARY KEY (`id`),
  ADD KEY `task_id` (`task_id`),
  ADD KEY `user_id` (`user_id`);

--
-- Indexes for table `task_groups`
--
ALTER TABLE `task_groups`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`),
  ADD UNIQUE KEY `email` (`email`),
  ADD UNIQUE KEY `phone_number` (`phone_number`),
  ADD KEY `role_type_id` (`role_type_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `roles`
--
ALTER TABLE `roles`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `tasks`
--
ALTER TABLE `tasks`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=107;

--
-- AUTO_INCREMENT for table `task_assignees`
--
ALTER TABLE `task_assignees`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=205;

--
-- AUTO_INCREMENT for table `task_attachments`
--
ALTER TABLE `task_attachments`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=49;

--
-- AUTO_INCREMENT for table `task_comments`
--
ALTER TABLE `task_comments`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=155;

--
-- AUTO_INCREMENT for table `task_groups`
--
ALTER TABLE `task_groups`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=37;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=67;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `tasks`
--
ALTER TABLE `tasks`
  ADD CONSTRAINT `tasks_ibfk_1` FOREIGN KEY (`leader_id`) REFERENCES `users` (`id`);

--
-- Constraints for table `task_assignees`
--
ALTER TABLE `task_assignees`
  ADD CONSTRAINT `task_assignees_ibfk_1` FOREIGN KEY (`assignee_id`) REFERENCES `users` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `task_attachments`
--
ALTER TABLE `task_attachments`
  ADD CONSTRAINT `task_attachments_ibfk_1` FOREIGN KEY (`task_id`) REFERENCES `tasks` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `task_comments`
--
ALTER TABLE `task_comments`
  ADD CONSTRAINT `task_comments_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `users`
--
ALTER TABLE `users`
  ADD CONSTRAINT `users_ibfk_1` FOREIGN KEY (`role_type_id`) REFERENCES `roles` (`id`) ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
