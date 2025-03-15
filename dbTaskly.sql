CREATE DATABASE  IF NOT EXISTS `dbtaskly` /*!40100 DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci */;
USE `dbtaskly`;
-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: dbtaskly
-- ------------------------------------------------------
-- Server version	11.3.2-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `tblcategories`
--

DROP TABLE IF EXISTS `tblcategories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tblcategories` (
  `strCategoryCode` varchar(20) NOT NULL,
  `strCategory` varchar(100) NOT NULL,
  PRIMARY KEY (`strCategoryCode`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblcategories`
--

LOCK TABLES `tblcategories` WRITE;
/*!40000 ALTER TABLE `tblcategories` DISABLE KEYS */;
INSERT INTO `tblcategories` VALUES ('ACT','Activity'),('GRP','Groupings'),('MEET','Meeting'),('ORG','Organizations'),('PROJ','Project'),('QUIZ','Quiz'),('TEST','Test');
/*!40000 ALTER TABLE `tblcategories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblschedule`
--

DROP TABLE IF EXISTS `tblschedule`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tblschedule` (
  `intSchedID` int(10) NOT NULL AUTO_INCREMENT,
  `strCourseAbbre` varchar(20) NOT NULL,
  `strSchedule` varchar(100) NOT NULL,
  `strProfessor` varchar(200) NOT NULL,
  PRIMARY KEY (`intSchedID`),
  KEY `strCourseAbbre` (`strCourseAbbre`),
  CONSTRAINT `tblschedule_ibfk_1` FOREIGN KEY (`strCourseAbbre`) REFERENCES `tblsubjects` (`strCourseAbbre`)
) ENGINE=InnoDB AUTO_INCREMENT=2014 DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblschedule`
--

LOCK TABLES `tblschedule` WRITE;
/*!40000 ALTER TABLE `tblschedule` DISABLE KEYS */;
INSERT INTO `tblschedule` VALUES (2007,'HCI','Wednesday 14:30:00 - 17:30:00 | LEC','Dr. Diluc Ragnvindr White'),(2008,'FOR','Monday 12:00:00 - 15:00:00 | LEC','Prof. Ayaka Kamisato'),(2009,'APPDEV','Saturday 07:30:00 - 10:30:00 | LAB & 10:30:00 - 12:30:00 | LEC','Dr. Jean Gunnhildr'),(2010,'COAL','Saturday 13:30:00 - 16:30:00 | LAB & 16:30:00 - 18:30:00 | LEC','Prof. Ayato Kamisato'),(2011,'ALT','Wednesday/ Saturday 19:30:00 - 21:00:00 | LEC','Engr. Mavuika'),(2012,'PPL','Tuesday 13:30:00 - 15:30:00 | LEC & Friday 13:30:00 - 16:30:00 | LAB','Dr. Baizhu'),(2013,'ELEC','Monday 16:00:00 - 18:00:00 | LEC','Engr. Kaveh');
/*!40000 ALTER TABLE `tblschedule` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblsubjects`
--

DROP TABLE IF EXISTS `tblsubjects`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tblsubjects` (
  `strCourseAbbre` varchar(20) NOT NULL,
  `strCourseCode` varchar(20) NOT NULL,
  `strCourseName` varchar(200) NOT NULL,
  PRIMARY KEY (`strCourseAbbre`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblsubjects`
--

LOCK TABLES `tblsubjects` WRITE;
/*!40000 ALTER TABLE `tblsubjects` DISABLE KEYS */;
INSERT INTO `tblsubjects` VALUES ('ALT','COSC-302','Automata and Language Theory'),('APPDEV','COMP-019','Applications Development and Emerging Technologies'),('COAL','COSC-301','Computer Organization and Assembly Language'),('ELEC','ELEC-CS-E1','BSCS Elective 1'),('FOR','COMP-015','Fundamentals of Research'),('HCI','COMP-013','Human Computer Interaction'),('PPL','COSC-303','Principles of Programming Languages');
/*!40000 ALTER TABLE `tblsubjects` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbltasks`
--

DROP TABLE IF EXISTS `tbltasks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbltasks` (
  `intTaskID` int(10) NOT NULL AUTO_INCREMENT,
  `strCourseAbbre` varchar(20) NOT NULL,
  `strCategoryCode` varchar(20) NOT NULL,
  `txtTaskDesc` text NOT NULL,
  `strProgress` enum('Not Started','In Progress','Completed') NOT NULL,
  `dtmDeadline` datetime NOT NULL,
  PRIMARY KEY (`intTaskID`),
  KEY `strCourseAbbre` (`strCourseAbbre`),
  KEY `strCategoryCode` (`strCategoryCode`),
  CONSTRAINT `tbltasks_ibfk_1` FOREIGN KEY (`strCourseAbbre`) REFERENCES `tblsubjects` (`strCourseAbbre`),
  CONSTRAINT `tbltasks_ibfk_2` FOREIGN KEY (`strCategoryCode`) REFERENCES `tblcategories` (`strCategoryCode`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbltasks`
--

LOCK TABLES `tbltasks` WRITE;
/*!40000 ALTER TABLE `tbltasks` DISABLE KEYS */;
INSERT INTO `tbltasks` VALUES (1,'HCI','PROJ','Complete the assets for the game group project.','In Progress','2025-01-28 17:00:00'),(2,'FOR','QUIZ','Prepare for the upcoming topic presentation.','Not Started','2025-02-01 09:00:00'),(3,'APPDEV','TEST','Finish the reviewer for the midterm test.','Completed','2025-01-25 23:59:59'),(4,'COAL','ACT','Do the lab activities in Proteus.','Not Started','2025-02-05 12:00:00'),(5,'ALT','MEET','Meet with the team for brainstorming.','In Progress','2025-01-30 10:00:00'),(6,'PPL','QUIZ','Prepare for the quiz on BNF.','Not Started','2025-02-08 10:00:00'),(7,'FOR','TEST','Complete the test on research methodology.','Not Started','2025-02-03 15:00:00'),(8,'APPDEV','PROJ','Finalize project report on applications development.','In Progress','2025-02-05 17:00:00'),(9,'ALT','GRP','Finalize the last phase of the project.','Not Started','2025-01-27 12:00:00'),(10,'HCI','ACT','Do the website rating activity.','Completed','2025-01-26 18:00:00'),(11,'ELEC','ACT','Prepare the presentation for the elective project.','Not Started','2025-01-29 10:00:00'),(12,'COAL','QUIZ','Review for long quiz','Not Started','2025-02-04 15:00:00'),(13,'PPL','QUIZ','Do the group project','In Progress','2025-02-05 13:00:00');
/*!40000 ALTER TABLE `tbltasks` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-01-31  6:20:32
