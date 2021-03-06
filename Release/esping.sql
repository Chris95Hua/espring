-- phpMyAdmin SQL Dump
-- version 4.5.2
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Dec 16, 2016 at 08:09 AM
-- Server version: 10.1.8-MariaDB
-- PHP Version: 5.6.14

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `esping`
--

-- --------------------------------------------------------

--
-- Table structure for table `department`
--

CREATE TABLE `department` (
  `department_id` int(10) UNSIGNED NOT NULL,
  `name` varchar(64) NOT NULL,
  `c_user` int(10) UNSIGNED NOT NULL,
  `c_date` datetime NOT NULL,
  `e_user` int(10) UNSIGNED DEFAULT NULL,
  `e_date` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `department`
--

INSERT INTO `department` (`department_id`, `name`, `c_user`, `c_date`, `e_user`, `e_date`) VALUES
(1, 'Approval', 1, '2016-11-09 00:00:00', NULL, NULL),
(2, 'Cutting Department', 1, '2016-11-09 00:00:00', NULL, NULL),
(3, 'Embroidery Department', 1, '2016-11-09 00:00:00', NULL, NULL),
(4, 'Inventory Preparation', 1, '2016-11-09 00:00:00', NULL, NULL),
(5, 'Order Management', 1, '2016-11-09 00:00:00', NULL, NULL),
(6, 'Printing Department', 1, '2016-11-09 00:00:00', NULL, NULL),
(7, 'Sewing Department', 1, '2016-11-09 00:00:00', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `inventory`
--

CREATE TABLE `inventory` (
  `inventory_id` int(10) UNSIGNED NOT NULL,
  `item` varchar(64) NOT NULL,
  `quantity` int(11) NOT NULL,
  `c_user` int(10) UNSIGNED NOT NULL,
  `c_date` datetime NOT NULL,
  `e_user` int(10) UNSIGNED DEFAULT NULL,
  `e_date` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `inventory`
--

INSERT INTO `inventory` (`inventory_id`, `item`, `quantity`, `c_user`, `c_date`, `e_user`, `e_date`) VALUES
(1, 'Fabric', 0, 0, '0000-00-00 00:00:00', NULL, NULL),
(2, 'Collar', 0, 0, '0000-00-00 00:00:00', NULL, NULL),
(3, 'Cuff', 0, 0, '0000-00-00 00:00:00', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `order_customer`
--

CREATE TABLE `order_customer` (
  `order_id` int(10) UNSIGNED NOT NULL,
  `order_name` varchar(64) NOT NULL,
  `salesperson_id` int(10) UNSIGNED NOT NULL,
  `customer` varchar(128) NOT NULL,
  `fabric` varchar(128) NOT NULL,
  `collar` int(10) UNSIGNED NOT NULL,
  `cuff` int(10) UNSIGNED NOT NULL,
  `front` varchar(20) DEFAULT NULL,
  `front_dept` int(1) UNSIGNED NOT NULL,
  `back` varchar(20) DEFAULT NULL,
  `back_dept` int(1) UNSIGNED NOT NULL,
  `artwork` varchar(340) DEFAULT NULL,
  `size` varchar(160) NOT NULL,
  `material` varchar(128) NOT NULL,
  `colour` varchar(128) NOT NULL,
  `packaging` varchar(128) NOT NULL,
  `issue_date` date NOT NULL,
  `delivery_date` date NOT NULL,
  `delivery_type` tinyint(1) UNSIGNED NOT NULL,
  `payment` varchar(32) NOT NULL,
  `payment_doc` char(51) DEFAULT NULL,
  `amount` decimal(10,2) UNSIGNED NOT NULL,
  `remarks` varchar(255) DEFAULT NULL,
  `inventory_order` varchar(255) DEFAULT NULL,
  `production_parts` varchar(182) DEFAULT NULL,
  `approval` tinyint(1) UNSIGNED DEFAULT '0',
  `inventory` tinyint(1) UNSIGNED DEFAULT '0',
  `cutting` tinyint(1) UNSIGNED DEFAULT '0',
  `embroidery` tinyint(1) UNSIGNED DEFAULT '0',
  `printing` tinyint(1) UNSIGNED DEFAULT '0',
  `sewing` tinyint(1) UNSIGNED NOT NULL DEFAULT '0',
  `e_user` int(10) UNSIGNED DEFAULT NULL,
  `e_date` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `order_log`
--

CREATE TABLE `order_log` (
  `log_id` int(10) UNSIGNED NOT NULL,
  `order_id` int(10) UNSIGNED NOT NULL,
  `department_id` int(10) NOT NULL,
  `datetime` datetime NOT NULL,
  `status` varchar(255) NOT NULL,
  `c_user` int(10) UNSIGNED NOT NULL,
  `e_user` int(10) UNSIGNED DEFAULT NULL,
  `e_date` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `package`
--

CREATE TABLE `package` (
  `package_id` int(10) NOT NULL,
  `order_id` int(10) UNSIGNED NOT NULL,
  `package_key` varchar(60) NOT NULL,
  `dept` varchar(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `user_id` int(11) NOT NULL,
  `first_name` varchar(64) NOT NULL,
  `last_name` varchar(64) NOT NULL,
  `username` varchar(16) NOT NULL,
  `password` char(44) NOT NULL,
  `salt` char(44) NOT NULL,
  `role` int(10) UNSIGNED NOT NULL,
  `department_id` int(11) NOT NULL,
  `c_user` int(10) UNSIGNED NOT NULL,
  `c_date` datetime NOT NULL,
  `e_user` int(10) UNSIGNED DEFAULT NULL,
  `e_date` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`user_id`, `first_name`, `last_name`, `username`, `password`, `salt`, `role`, `department_id`, `c_user`, `c_date`, `e_user`, `e_date`) VALUES
(1, 'Admin', 'Esping', 'admin', 'rjzLG6rlS+ONny+/8l9Omady8Fl1EyhhfONz0gmmIpI=', 'xGsL38dZj8yazjismTQu2imW9qtzLX/jP8uaiZsYki2n', 0, 0, 0, '2016-11-07 00:00:00', 1, '2016-11-28 11:37:34');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `department`
--
ALTER TABLE `department`
  ADD PRIMARY KEY (`department_id`);

--
-- Indexes for table `inventory`
--
ALTER TABLE `inventory`
  ADD PRIMARY KEY (`inventory_id`);

--
-- Indexes for table `order_customer`
--
ALTER TABLE `order_customer`
  ADD PRIMARY KEY (`order_id`);

--
-- Indexes for table `order_log`
--
ALTER TABLE `order_log`
  ADD PRIMARY KEY (`log_id`),
  ADD KEY `order_id` (`order_id`);

--
-- Indexes for table `package`
--
ALTER TABLE `package`
  ADD PRIMARY KEY (`package_id`),
  ADD KEY `order_id` (`order_id`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`user_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `department`
--
ALTER TABLE `department`
  MODIFY `department_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
--
-- AUTO_INCREMENT for table `inventory`
--
ALTER TABLE `inventory`
  MODIFY `inventory_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT for table `order_customer`
--
ALTER TABLE `order_customer`
  MODIFY `order_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `order_log`
--
ALTER TABLE `order_log`
  MODIFY `log_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `package`
--
ALTER TABLE `package`
  MODIFY `package_id` int(10) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `order_log`
--
ALTER TABLE `order_log`
  ADD CONSTRAINT `order_log_ibfk_1` FOREIGN KEY (`order_id`) REFERENCES `order_customer` (`order_id`) ON DELETE CASCADE ON UPDATE NO ACTION;

--
-- Constraints for table `package`
--
ALTER TABLE `package`
  ADD CONSTRAINT `package_ibfk_1` FOREIGN KEY (`order_id`) REFERENCES `order_customer` (`order_id`) ON DELETE CASCADE ON UPDATE NO ACTION;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
