CREATE DATABASE  IF NOT EXISTS `benfinit_water` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `benfinit_water`;
-- MySQL dump 10.13  Distrib 8.0.40, for Win64 (x86_64)
--
-- Host: localhost    Database: benfinit_water
-- ------------------------------------------------------
-- Server version	8.0.40

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
-- Table structure for table `access_history`
--

DROP TABLE IF EXISTS `access_history`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `access_history` (
  `id` int NOT NULL,
  `id_action` int NOT NULL AUTO_INCREMENT,
  `access_time` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `action_type` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`,`id_action`),
  UNIQUE KEY `id_action` (`id_action`),
  CONSTRAINT `access_history_ibfk_1` FOREIGN KEY (`id`) REFERENCES `users` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=306 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `access_history`
--

LOCK TABLES `access_history` WRITE;
/*!40000 ALTER TABLE `access_history` DISABLE KEYS */;
INSERT INTO `access_history` VALUES (1,1,'2024-12-13 13:27:32','User created with ID: 1'),(1,71,'2024-12-18 18:56:40','Updated is_active for ID: 1 to 1'),(1,72,'2024-12-18 18:56:55','Updated is_active for ID: 1 to 0'),(1,73,'2024-12-18 18:57:35','Updated is_active for ID: 1 to 1'),(1,74,'2024-12-18 18:58:06','Updated is_active for ID: 1 to 0'),(1,75,'2024-12-18 18:59:33','Updated is_active for ID: 1 to 1'),(1,76,'2024-12-18 18:59:54','Updated is_active for ID: 1 to 0'),(1,77,'2024-12-18 19:00:57','Updated is_active for ID: 1 to 1'),(1,78,'2024-12-18 19:01:13','Updated is_active for ID: 1 to 0'),(1,79,'2024-12-18 19:02:52','Updated is_active for ID: 1 to 1'),(1,80,'2024-12-18 19:03:20','Updated is_active for ID: 1 to 0'),(1,81,'2024-12-18 19:05:19','Updated is_active for ID: 1 to 1'),(1,82,'2024-12-18 19:05:51','Updated is_active for ID: 1 to 0'),(2,2,'2024-12-13 13:27:32','User created with ID: 2'),(3,3,'2024-12-13 20:36:58','User created with ID: 3'),(3,4,'2024-12-16 18:12:42','Updated is_admin for ID: 3 to 2'),(3,5,'2024-12-16 18:12:42','Updated is_active for ID: 3 to 2'),(3,6,'2024-12-16 18:17:11','Updated is_admin for ID: 3 to 2'),(3,7,'2024-12-16 18:17:11','Updated is_active for ID: 3 to 1'),(3,8,'2024-12-16 18:17:29','Updated is_admin for ID: 3 to 2'),(3,9,'2024-12-16 18:17:29','Updated is_active for ID: 3 to 0'),(3,10,'2024-12-16 18:20:05','Updated is_admin for ID: 3 to 2'),(3,11,'2024-12-16 18:20:53','Updated is_admin for ID: 3 to 2'),(3,12,'2024-12-16 18:22:24','Updated is_active for ID: 3 to 1'),(3,13,'2024-12-16 18:22:41','Updated is_active for ID: 3 to 0'),(3,14,'2024-12-16 18:22:58','Updated is_active for ID: 3 to 1'),(3,15,'2024-12-16 18:23:24','Updated is_active for ID: 3 to 0'),(3,33,'2024-12-18 18:35:03','Updated is_active for ID: 3 to 1'),(3,34,'2024-12-18 18:35:16','Updated user_name for ID: 3 to anh'),(3,35,'2024-12-18 18:35:16','Updated address for ID: 3to1'),(3,36,'2024-12-18 18:35:17','Updated email for ID: 3to1'),(3,37,'2024-12-18 18:35:17','Updated password for ID: 3'),(3,38,'2024-12-18 18:35:17','Updated first_name for ID: 3to11'),(3,39,'2024-12-18 18:35:17','Updated last_name for ID: 3to13'),(3,40,'2024-12-18 18:35:23','Updated is_active for ID: 3 to 0'),(3,41,'2024-12-18 18:36:10','Updated is_active for ID: 3 to 1'),(3,42,'2024-12-18 18:36:22','Updated user_name for ID: 3 to anh'),(3,43,'2024-12-18 18:36:22','Updated address for ID: 3to1'),(3,44,'2024-12-18 18:36:22','Updated email for ID: 3to1'),(3,45,'2024-12-18 18:36:22','Updated password for ID: 3'),(3,46,'2024-12-18 18:36:22','Updated first_name for ID: 3to11'),(3,47,'2024-12-18 18:36:22','Updated last_name for ID: 3to13'),(3,48,'2024-12-18 18:36:43','Updated user_name for ID: 3 to anh'),(3,49,'2024-12-18 18:36:43','Updated address for ID: 3to1'),(3,50,'2024-12-18 18:36:43','Updated email for ID: 3to1'),(3,51,'2024-12-18 18:36:43','Updated phone for ID: 3'),(3,52,'2024-12-18 18:36:43','Updated first_name for ID: 3to11'),(3,53,'2024-12-18 18:36:43','Updated last_name for ID: 3to13'),(3,54,'2024-12-18 18:36:50','Updated user_name for ID: 3 to anh'),(3,55,'2024-12-18 18:36:50','Updated address for ID: 3to1'),(3,56,'2024-12-18 18:36:50','Updated email for ID: 3to1'),(3,57,'2024-12-18 18:36:50','Updated password for ID: 3'),(3,58,'2024-12-18 18:36:50','Updated first_name for ID: 3to11'),(3,59,'2024-12-18 18:36:50','Updated last_name for ID: 3to13'),(3,60,'2024-12-18 18:36:57','Updated user_name for ID: 3 to anh'),(3,61,'2024-12-18 18:36:57','Updated address for ID: 3to1'),(3,62,'2024-12-18 18:36:57','Updated email for ID: 3to1'),(3,63,'2024-12-18 18:36:57','Updated phone for ID: 3'),(3,64,'2024-12-18 18:36:57','Updated first_name for ID: 3to11'),(3,65,'2024-12-18 18:36:57','Updated last_name for ID: 3to13'),(3,66,'2024-12-18 18:37:10','Updated is_active for ID: 3 to 0'),(3,67,'2024-12-18 18:38:13','Updated is_active for ID: 3 to 1'),(3,68,'2024-12-18 18:38:26','Updated phone for ID: 3'),(3,69,'2024-12-18 18:38:34','Updated password for ID: 3'),(3,70,'2024-12-18 18:38:44','Updated is_active for ID: 3 to 0'),(3,86,'2024-12-18 23:52:22','Updated is_active for ID: 3 to 1'),(3,87,'2024-12-18 23:52:48','Updated is_active for ID: 3 to 0'),(3,88,'2024-12-18 23:55:38','Updated is_active for ID: 3 to 1'),(3,89,'2024-12-18 23:55:42','Updated is_active for ID: 3 to 0'),(3,96,'2024-12-19 01:01:17','Updated is_active for ID: 3 to 1'),(3,97,'2024-12-19 01:02:00','Updated is_active for ID: 3 to 0'),(3,99,'2024-12-19 01:06:48','Updated is_active for ID: 3 to 1'),(3,100,'2024-12-19 01:07:20','Updated is_active for ID: 3 to 0'),(3,101,'2024-12-19 01:08:32','Updated is_active for ID: 3 to 1'),(3,102,'2024-12-19 01:09:09','Updated is_active for ID: 3 to 0'),(3,103,'2024-12-19 01:10:46','Updated is_active for ID: 3 to 1'),(3,104,'2024-12-19 01:11:31','Updated is_active for ID: 3 to 0'),(3,105,'2024-12-19 01:12:48','Updated is_active for ID: 3 to 1'),(3,106,'2024-12-19 01:13:12','Updated is_active for ID: 3 to 0'),(3,107,'2024-12-19 01:15:45','Updated is_active for ID: 3 to 1'),(3,108,'2024-12-19 01:16:00','Updated _name for ID: 36toNam Định'),(3,109,'2024-12-19 01:16:08','Updated _muc_do_hanh_chinh_id for ID: 36to2'),(3,110,'2024-12-19 01:16:29','Updated is_active for ID: 3 to 0'),(3,111,'2024-12-19 01:31:02','Updated is_active for ID: 3 to 1'),(3,112,'2024-12-19 01:31:22','Updated is_active for ID: 3 to 0'),(3,113,'2024-12-19 01:32:30','Updated is_active for ID: 3 to 1'),(3,114,'2024-12-19 01:33:41','Updated is_active for ID: 3 to 0'),(3,115,'2024-12-19 01:36:28','Updated is_active for ID: 3 to 1'),(3,116,'2024-12-19 01:36:45','Updated is_active for ID: 3 to 0'),(3,117,'2024-12-19 01:39:29','Updated is_active for ID: 3 to 1'),(3,118,'2024-12-19 01:40:07','Updated is_active for ID: 3 to 0'),(3,119,'2024-12-19 01:41:22','Updated is_active for ID: 3 to 1'),(3,120,'2024-12-19 01:41:59','Updated is_active for ID: 3 to 1'),(3,121,'2024-12-19 01:43:13','Updated _muc_do_hanh_chinh_id for ID: 36to1'),(3,122,'2024-12-19 01:43:32','Updated is_active for ID: 3 to 0'),(3,126,'2024-12-19 02:15:25','Updated is_active for ID: 3 to 1'),(3,127,'2024-12-19 02:16:09','Delete co_so3'),(3,128,'2024-12-19 02:17:09','Updated is_active for ID: 3 to 0'),(3,132,'2024-12-19 02:40:05','Updated is_active for ID: 3 to 1'),(3,133,'2024-12-19 02:40:31','Updated is_active for ID: 3 to 0'),(3,143,'2024-12-19 02:50:07','Updated is_active for ID: 3 to 1'),(3,144,'2024-12-19 02:50:14','Delete co_so5'),(3,145,'2024-12-19 02:50:23','Updated is_active for ID: 3 to 0'),(3,146,'2024-12-19 02:51:24','Updated is_active for ID: 3 to 1'),(3,147,'2024-12-19 02:51:37','Updated _name for ID: 36toNam Địnhh'),(3,148,'2024-12-19 02:51:54','Updated _name for ID: 36toNam Định'),(3,149,'2024-12-19 02:52:08','Updated is_active for ID: 3 to 0'),(3,150,'2024-12-19 03:09:56','Updated is_active for ID: 3 to 1'),(3,151,'2024-12-19 03:10:07','Updated is_active for ID: 3 to 0'),(3,152,'2024-12-19 03:11:03','Updated is_active for ID: 3 to 1'),(3,153,'2024-12-19 03:12:01','Updated is_active for ID: 3 to 0'),(3,154,'2024-12-19 03:45:22','Updated is_active for ID: 3 to 1'),(3,155,'2024-12-19 03:45:41','Updated is_active for ID: 3 to 0'),(3,156,'2024-12-19 03:47:00','Updated is_active for ID: 3 to 1'),(3,157,'2024-12-19 03:47:15','Updated is_active for ID: 3 to 0'),(3,158,'2024-12-19 03:49:53','Updated is_active for ID: 3 to 1'),(3,159,'2024-12-19 03:50:04','Updated is_active for ID: 3 to 0'),(3,160,'2024-12-19 03:50:27','Updated is_active for ID: 3 to 1'),(3,161,'2024-12-19 03:50:50','Updated is_active for ID: 3 to 0'),(3,162,'2024-12-19 03:52:47','Updated is_active for ID: 3 to 1'),(3,163,'2024-12-19 03:53:13','Updated is_active for ID: 3 to 0'),(3,164,'2024-12-19 03:53:57','Updated is_active for ID: 3 to 1'),(3,165,'2024-12-19 03:54:09','Updated is_active for ID: 0 to 0'),(3,166,'2024-12-19 03:54:09','Updated don_vi_cong_tac for ID: 0to2'),(3,167,'2024-12-19 03:58:09','Updated is_active for ID: 3 to 1'),(3,168,'2024-12-19 03:58:30','Updated is_active for ID: 0 to 0'),(3,169,'2024-12-19 03:58:30','Updated don_vi_cong_tac for ID: 0to2'),(3,170,'2024-12-19 04:00:13','Updated is_active for ID: 3 to 1'),(3,171,'2024-12-19 04:00:26','Updated is_active for ID: 4 to 0'),(3,172,'2024-12-19 04:01:52','Updated is_active for ID: 3 to 0'),(3,173,'2024-12-19 04:16:36','Updated is_active for ID: 3 to 1'),(3,174,'2024-12-19 04:16:47','Updated is_active for ID: 4 to 0'),(3,175,'2024-12-19 04:16:47','Updated don_vi_cong_tac for ID: 4to0'),(3,176,'2024-12-19 04:17:17','Updated is_active for ID: 4 to 0'),(3,177,'2024-12-19 04:17:17','Updated don_vi_cong_tac for ID: 4to0'),(3,178,'2024-12-19 04:17:56','Updated is_active for ID: 3 to 1'),(3,179,'2024-12-19 04:19:43','Updated is_active for ID: 3 to 1'),(3,180,'2024-12-19 04:19:55','Updated is_admin for ID: 4 to 1'),(3,181,'2024-12-19 04:19:55','Updated is_active for ID: 4 to 0'),(3,182,'2024-12-19 04:20:01','Updated is_active for ID: 4 to 0'),(3,183,'2024-12-19 04:20:01','Updated don_vi_cong_tac for ID: 4to36'),(3,184,'2024-12-19 22:53:38','Updated is_active for ID: 3 to 1'),(3,185,'2024-12-19 22:54:58','Delete co_so3'),(3,186,'2024-12-19 22:55:55','Updated is_active for ID: 3 to 0'),(3,187,'2024-12-19 22:59:20','Updated is_active for ID: 3 to 1'),(3,188,'2024-12-19 23:04:18','Transfer from all co_so truc_thuoc_id36to38'),(3,189,'2024-12-19 23:04:21','Transfer from all co_so truc_thuoc_id36to38'),(3,190,'2024-12-19 23:04:23','Transfer from all co_so truc_thuoc_id36to38'),(3,191,'2024-12-19 23:04:23','Transfer from all co_so truc_thuoc_id36to38'),(3,192,'2024-12-19 23:04:25','Transfer from all co_so truc_thuoc_id36to38'),(3,193,'2024-12-19 23:04:27','Transfer from all co_so truc_thuoc_id36to38'),(3,194,'2024-12-19 23:04:27','Transfer from all co_so truc_thuoc_id36to38'),(3,195,'2024-12-19 23:04:27','Transfer from all co_so truc_thuoc_id36to38'),(3,196,'2024-12-19 23:04:29','Transfer from all co_so truc_thuoc_id36to38'),(3,197,'2024-12-19 23:04:29','Transfer from all co_so truc_thuoc_id36to38'),(3,198,'2024-12-19 23:04:29','Transfer from all co_so truc_thuoc_id36to38'),(3,199,'2024-12-19 23:04:47','Updated is_active for ID: 3 to 0'),(3,200,'2024-12-19 23:19:01','Updated is_active for ID: 3 to 1'),(3,201,'2024-12-19 23:19:17','Updated is_active for ID: 3 to 0'),(3,202,'2024-12-19 23:24:02','Updated is_active for ID: 3 to 1'),(3,203,'2024-12-19 23:24:14','Updated is_active for ID: 3 to 0'),(3,204,'2024-12-19 23:35:07','Updated is_active for ID: 3 to 1'),(3,205,'2024-12-19 23:36:09','Updated is_active for ID: 3 to 0'),(3,206,'2024-12-19 23:36:41','Updated is_active for ID: 3 to 1'),(3,207,'2024-12-19 23:37:00','Transfer from all co_so truc_thuoc_id38to36'),(3,208,'2024-12-19 23:37:10','Delete co_so38'),(3,209,'2024-12-19 23:37:24','Updated is_active for ID: 3 to 0'),(3,210,'2024-12-19 23:39:00','Updated is_active for ID: 3 to 1'),(3,211,'2024-12-19 23:39:12','Delete co_so3'),(3,212,'2024-12-19 23:39:53','Delete co_so1'),(3,213,'2024-12-19 23:46:14','Updated is_active for ID: 3 to 1'),(3,214,'2024-12-19 23:46:31','Updated _name for ID: 36toHà Nội'),(3,215,'2024-12-19 23:46:50','Updated is_active for ID: 3 to 0'),(3,216,'2024-12-19 23:50:16','Updated is_active for ID: 3 to 1'),(3,217,'2024-12-19 23:50:33','Updated _name for ID: 36toNam Định'),(3,218,'2024-12-19 23:52:30','Updated is_active for ID: 3 to 1'),(3,219,'2024-12-19 23:52:43','Updated _muc_do_hanh_chinh_id for ID: 36to2'),(3,220,'2024-12-19 23:56:19','Updated is_active for ID: 3 to 1'),(3,221,'2024-12-19 23:56:28','Updated _muc_do_hanh_chinh_id for ID: 36to1'),(3,222,'2024-12-19 23:56:40','Delete co_so36'),(3,223,'2024-12-19 23:57:11','Delete co_so1'),(3,224,'2024-12-19 23:58:01','Updated is_active for ID: 3 to 0'),(3,225,'2024-12-20 00:22:47','Updated is_active for ID: 3 to 1'),(3,226,'2024-12-20 00:23:47','Updated is_active for ID: 3 to 0'),(3,227,'2024-12-20 00:24:15','Updated is_active for ID: 3 to 1'),(3,228,'2024-12-20 00:25:10','Updated is_active for ID: 3 to 0'),(3,229,'2024-12-20 00:29:59','Updated is_active for ID: 3 to 1'),(3,230,'2024-12-20 00:30:17','Updated is_active for ID: 3 to 0'),(3,231,'2024-12-20 00:31:17','Updated is_active for ID: 3 to 1'),(3,232,'2024-12-20 01:41:07','Updated is_active for ID: 3 to 1'),(3,233,'2024-12-20 01:41:57','Transfer from all user don_vi_cong_tac_id0to36'),(3,234,'2024-12-20 01:42:35','Updated is_active for ID: 3 to 0'),(3,235,'2024-12-20 01:42:41','Updated is_active for ID: 3 to 1'),(3,236,'2024-12-20 01:42:54','Updated is_active for ID: 3 to 0'),(3,237,'2024-12-20 01:56:27','Updated is_active for ID: 3 to 1'),(3,238,'2024-12-20 01:56:51','Transfer from all user don_vi_cong_tac_id36to0'),(3,239,'2024-12-20 01:57:03','Updated is_active for ID: 3 to 0'),(3,240,'2024-12-20 01:58:23','Updated is_active for ID: 3 to 1'),(3,241,'2024-12-20 01:58:44','Transfer from all user don_vi_cong_tac_id0to36'),(3,242,'2024-12-20 02:00:08','Updated is_active for ID: 3 to 0'),(3,243,'2024-12-20 02:04:40','Updated is_active for ID: 3 to 1'),(3,244,'2024-12-20 02:04:59','Transfer from all user don_vi_cong_tac_id36to0'),(3,245,'2024-12-20 02:05:08','Updated is_active for ID: 3 to 0'),(3,246,'2024-12-20 02:05:34','Updated is_active for ID: 3 to 1'),(3,247,'2024-12-20 02:05:50','Updated is_active for ID: 2 to 0'),(3,248,'2024-12-20 02:05:50','Updated don_vi_cong_tac for ID: 2to36'),(3,249,'2024-12-20 02:05:59','Updated is_active for ID: 3 to 0'),(3,250,'2024-12-20 02:10:10','Updated is_active for ID: 3 to 1'),(3,251,'2024-12-20 02:10:28','Transfer from all user don_vi_cong_tac_id0to36'),(3,252,'2024-12-20 02:10:50','Updated is_active for ID: 3 to 0'),(3,253,'2024-12-20 02:10:50','Updated don_vi_cong_tac for ID: 3to0'),(3,254,'2024-12-20 02:11:06','Updated is_active for ID: 3 to 0'),(3,255,'2024-12-20 02:13:38','Updated is_active for ID: 3 to 1'),(3,256,'2024-12-20 02:14:02','Updated is_active for ID: 3 to 0'),(3,257,'2024-12-20 02:37:32','Updated is_active for ID: 3 to 1'),(3,258,'2024-12-20 02:37:45','Updated is_active for ID: 3 to 0'),(3,259,'2024-12-20 02:42:44','Updated is_active for ID: 3 to 1'),(3,260,'2024-12-20 02:43:51','Updated is_active for ID: 3 to 0'),(3,261,'2024-12-20 02:46:42','Updated is_active for ID: 3 to 1'),(3,262,'2024-12-20 02:46:53','Updated is_active for ID: 3 to 0'),(3,263,'2024-12-20 02:50:02','Updated is_active for ID: 3 to 1'),(3,264,'2024-12-20 02:50:21','Updated is_active for ID: 3 to 0'),(3,265,'2024-12-20 02:50:21','Updated don_vi_cong_tac for ID: 3to36'),(3,266,'2024-12-20 02:50:47','Updated is_active for ID: 3 to 0'),(3,267,'2024-12-20 03:05:22','Updated is_active for ID: 3 to 1'),(3,268,'2024-12-20 03:05:58','Updated is_active for ID: 3 to 0'),(3,269,'2024-12-20 03:06:36','Updated is_active for ID: 3 to 1'),(3,270,'2024-12-20 03:06:47','Updated is_active for ID: 3 to 0'),(3,271,'2024-12-20 03:08:34','Updated is_active for ID: 3 to 1'),(3,272,'2024-12-20 03:08:51','Updated is_active for ID: 3 to 0'),(3,273,'2024-12-20 03:14:37','Updated is_active for ID: 3 to 1'),(3,274,'2024-12-20 03:15:42','Updated is_active for ID: 3 to 0'),(3,275,'2024-12-20 04:17:36','Updated is_active for ID: 3 to 1'),(3,276,'2024-12-20 04:18:00','Updated is_active for ID: 3 to 0'),(3,277,'2024-12-20 04:18:29','Updated is_active for ID: 3 to 1'),(3,278,'2024-12-20 04:18:46','Updated is_active for ID: 3 to 0'),(3,279,'2024-12-20 04:20:02','Updated is_active for ID: 3 to 1'),(3,280,'2024-12-20 04:20:32','Updated is_active for ID: 3 to 0'),(3,281,'2024-12-20 04:22:10','Updated is_active for ID: 3 to 1'),(3,282,'2024-12-20 04:22:26','Updated is_active for ID: 3 to 0'),(3,283,'2024-12-20 04:58:44','Updated is_active for ID: 3 to 1'),(3,284,'2024-12-20 04:59:03','Updated is_active for ID: 3 to 0'),(3,285,'2024-12-20 05:02:31','Updated is_active for ID: 3 to 1'),(3,286,'2024-12-20 05:02:42','Updated is_active for ID: 3 to 0'),(3,287,'2024-12-20 05:06:34','Updated is_active for ID: 3 to 1'),(3,288,'2024-12-20 05:09:16','Updated is_active for ID: 3 to 1'),(3,289,'2024-12-20 05:09:25','Updated is_active for ID: 3 to 0'),(3,290,'2024-12-20 05:17:20','Updated is_active for ID: 3 to 1'),(3,291,'2024-12-20 05:17:25','Updated is_active for ID: 3 to 0'),(3,292,'2024-12-20 05:18:02','Updated is_active for ID: 3 to 1'),(3,293,'2024-12-20 05:18:42','Updated is_active for ID: 3 to 0'),(3,294,'2024-12-20 05:18:57','Updated is_active for ID: 3 to 1'),(3,295,'2024-12-20 05:19:07','Updated is_active for ID: 3 to 0'),(3,296,'2024-12-20 05:21:27','Updated is_active for ID: 3 to 1'),(3,297,'2024-12-20 05:21:34','Updated is_active for ID: 3 to 0'),(3,298,'2024-12-20 05:22:41','Updated is_active for ID: 3 to 1'),(3,299,'2024-12-20 05:22:54','Updated is_active for ID: 3 to 0'),(3,300,'2024-12-20 05:23:10','Updated is_active for ID: 3 to 1'),(3,301,'2024-12-20 05:23:51','Updated is_active for ID: 3 to 0'),(3,302,'2024-12-20 05:26:52','Updated is_active for ID: 3 to 1'),(3,303,'2024-12-20 05:26:56','Updated is_active for ID: 3 to 0'),(3,304,'2024-12-20 05:29:58','Updated is_active for ID: 3 to 1'),(3,305,'2024-12-20 05:30:12','Updated is_active for ID: 3 to 0'),(5,123,'2024-12-19 01:50:49','User created with ID: 5'),(5,124,'2024-12-19 01:50:57','Updated is_active for ID: 5 to 1'),(5,125,'2024-12-19 01:51:19','Updated is_active for ID: 5 to 0'),(5,134,'2024-12-19 02:41:28','Updated is_active for ID: 5 to 1'),(5,135,'2024-12-19 02:41:52','Updated is_active for ID: 5 to 0'),(5,136,'2024-12-19 02:43:16','Updated is_active for ID: 5 to 1'),(5,137,'2024-12-19 02:43:51','Updated is_active for ID: 5 to 0'),(5,138,'2024-12-19 02:45:02','Updated is_active for ID: 5 to 1'),(5,139,'2024-12-19 02:46:18','Delete co_so5'),(5,140,'2024-12-19 02:46:28','Updated is_active for ID: 5 to 0'),(5,141,'2024-12-19 02:48:30','Updated is_active for ID: 5 to 1'),(5,142,'2024-12-19 02:49:25','Updated is_active for ID: 5 to 0');
/*!40000 ALTER TABLE `access_history` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `allcolumns`
--

DROP TABLE IF EXISTS `allcolumns`;
/*!50001 DROP VIEW IF EXISTS `allcolumns`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `allcolumns` AS SELECT 
 1 AS `TABLE_NAME`,
 1 AS `data_seach`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `baocao`
--

DROP TABLE IF EXISTS `baocao`;
/*!50001 DROP VIEW IF EXISTS `baocao`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `baocao` AS SELECT 
 1 AS `so_tai_khoan_hien_co`,
 1 AS `sotaikhoanonline`,
 1 AS `sotaikhoanoffline`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `co_so`
--

DROP TABLE IF EXISTS `co_so`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `co_so` (
  `id` int NOT NULL,
  `name` varchar(255) NOT NULL,
  `muc_do_hanh_chinh_id` int DEFAULT NULL,
  `truc_thuoc` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `muc_do_hanh_chinh_id` (`muc_do_hanh_chinh_id`),
  CONSTRAINT `co_so_ibfk_1` FOREIGN KEY (`muc_do_hanh_chinh_id`) REFERENCES `muc_do_hanh_chinh` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `co_so`
--

LOCK TABLES `co_so` WRITE;
/*!40000 ALTER TABLE `co_so` DISABLE KEYS */;
INSERT INTO `co_so` VALUES (0,'',6,NULL),(36,'Nam Định',1,0),(356,'Nam Định',3,36),(358,'Mỹ Lộc',2,36),(359,'Vụ Bản',2,36),(360,'Ý Yên',2,36),(361,'Nghĩa Hưng',2,36),(362,'Nam Trực',2,36),(363,'Trực Ninh',2,36),(364,'Xuân Trường',2,36),(365,'Giao Thủy',2,36),(366,'Hải Hậu',2,36),(13633,'Hạ Long',5,356),(13636,'Trần Tế Xương',5,356),(13639,'Vị Hoàng',5,356),(13642,'Vị Xuyên',5,356),(13645,'Quang Trung',5,356),(13648,'Cửa Bắc',5,356),(13651,'Nguyễn Du',5,356),(13654,'Bà Triệu',5,356),(13657,'Trường Thi',5,356),(13660,'Phan Đình Phùng',5,356),(13663,'Ngô Quyền',5,356),(13666,'Trần Hưng Đạo',5,356),(13669,'Trần Đăng Ninh',5,356),(13672,'Năng Tĩnh',5,356),(13675,'Văn Miếu',5,356),(13678,'Trần Quang Khải',5,356),(13681,'Thống Nhất',5,356),(13684,'Lộc Hạ',5,356),(13687,'Lộc Vượng',5,356),(13690,'Cửa Nam',5,356),(13693,'Lộc Hòa',5,356),(13696,'Nam Phong',4,356),(13699,'Mỹ Xá',5,356),(13702,'Lộc An',4,356),(13705,'Nam Vân',4,356),(13708,'Mỹ Lộc',6,358),(13711,'Mỹ Hà',4,358),(13714,'Mỹ Tiến',4,358),(13717,'Mỹ Thắng',4,358),(13720,'Mỹ Trung',4,358),(13723,'Mỹ Tân',4,358),(13726,'Mỹ Phúc',4,358),(13729,'Mỹ Hưng',4,358),(13732,'Mỹ Thuận',4,358),(13735,'Mỹ Thịnh',4,358),(13738,'Mỹ Thành',4,358),(13741,'Gôi',6,359),(13744,'Minh Thuận',4,359),(13747,'Hiển Khánh',4,359),(13750,'Tân Khánh',4,359),(13753,'Hợp Hưng',4,359),(13756,'Đại An',4,359),(13759,'Tân Thành',4,359),(13762,'Cộng Hòa',4,359),(13765,'Trung Thành',4,359),(13768,'Quang Trung',4,359),(13771,'Minh Tân',4,359),(13774,'Liên Bảo',4,359),(13777,'Thành Lợi',4,359),(13780,'Kim Thái',4,359),(13783,'Liên Minh',4,359),(13786,'Đại Thắng',4,359),(13789,'Tam Thanh',4,359),(13792,'Vĩnh Hào',4,359),(13795,'Lâm',6,360),(13798,'Yên Trung',4,360),(13801,'Yên Thành',4,360),(13804,'Yên Tân',4,360),(13807,'Yên Lợi',4,360),(13810,'Yên Thọ',4,360),(13813,'Yên Nghĩa',4,360),(13816,'Yên Minh',4,360),(13819,'Yên Phương',4,360),(13822,'Yên Chính',4,360),(13825,'Yên Bình',4,360),(13828,'Yên Phú',4,360),(13831,'Yên Mỹ',4,360),(13834,'Yên Dương',4,360),(13840,'Yên Hưng',4,360),(13843,'Yên Khánh',4,360),(13846,'Yên Phong',4,360),(13849,'Yên Ninh',4,360),(13852,'Yên Lương',4,360),(13855,'Yên Hồng',4,360),(13858,'Yên Quang',4,360),(13861,'Yên Tiến',4,360),(13864,'Yên Thắng',4,360),(13867,'Yên Phúc',4,360),(13870,'Yên Cường',4,360),(13873,'Yên Lộc',4,360),(13876,'Yên Bằng',4,360),(13879,'Yên Đồng',4,360),(13882,'Yên Khang',4,360),(13885,'Yên Nhân',4,360),(13888,'Yên Trị',4,360),(13891,'Liễu Đề',6,361),(13894,'Rạng Đông',6,361),(13897,'Nghĩa Đồng',4,361),(13900,'Nghĩa Thịnh',4,361),(13903,'Nghĩa Minh',4,361),(13906,'Nghĩa Thái',4,361),(13909,'Hoàng Nam',4,361),(13912,'Nghĩa Châu',4,361),(13915,'Nghĩa Trung',4,361),(13918,'Nghĩa Sơn',4,361),(13921,'Nghĩa Lạc',4,361),(13924,'Nghĩa Hồng',4,361),(13927,'Nghĩa Phong',4,361),(13930,'Nghĩa Phú',4,361),(13933,'Nghĩa Bình',4,361),(13936,'Quỹ Nhất',6,361),(13939,'Nghĩa Tân',4,361),(13942,'Nghĩa Hùng',4,361),(13945,'Nghĩa Lâm',4,361),(13948,'Nghĩa Thành',4,361),(13951,'Phúc Thắng',4,361),(13954,'Nghĩa Lợi',4,361),(13957,'Nghĩa Hải',4,361),(13963,'Nam Điền',4,361),(13966,'Nam Giang',6,362),(13969,'Nam Mỹ',4,362),(13972,'Điền Xá',4,362),(13975,'Nghĩa An',4,362),(13978,'Nam Thắng',4,362),(13981,'Nam Toàn',4,362),(13984,'Hồng Quang',4,362),(13987,'Tân Thịnh',4,362),(13990,'Nam Cường',4,362),(13993,'Nam Hồng',4,362),(13996,'Nam Hùng',4,362),(13999,'Nam Hoa',4,362),(14002,'Nam Dương',4,362),(14005,'Nam Thanh',4,362),(14008,'Nam Lợi',4,362),(14011,'Bình Minh',4,362),(14014,'Đồng Sơn',4,362),(14017,'Nam Tiến',4,362),(14020,'Nam Hải',4,362),(14023,'Nam Thái',4,362),(14026,'Cổ Lễ',6,363),(14029,'Phương Định',4,363),(14032,'Trực Chính',4,363),(14035,'Trung Đông',4,363),(14038,'Liêm Hải',4,363),(14041,'Trực Tuấn',4,363),(14044,'Việt Hùng',4,363),(14047,'Trực Đạo',4,363),(14050,'Trực Hưng',4,363),(14053,'Trực Nội',4,363),(14056,'Cát Thành',6,363),(14059,'Trực Thanh',4,363),(14062,'Trực Khang',4,363),(14065,'Trực Thuận',4,363),(14068,'Trực Mỹ',4,363),(14071,'Trực Đại',4,363),(14074,'Trực Cường',4,363),(14077,'Ninh Cường',6,363),(14080,'Trực Thái',4,363),(14083,'Trực Hùng',4,363),(14086,'Trực Thắng',4,363),(14089,'Xuân Trường',6,364),(14092,'Xuân Châu',4,364),(14095,'Xuân Hồng',4,364),(14098,'Xuân Thành',4,364),(14101,'Xuân Thượng',4,364),(14104,'Xuân Phong',4,364),(14107,'Xuân Đài',4,364),(14110,'Xuân Tân',4,364),(14113,'Xuân Thủy',4,364),(14116,'Xuân Ngọc',4,364),(14119,'Xuân Bắc',4,364),(14122,'Xuân Phương',4,364),(14125,'Thọ Nghiệp',4,364),(14128,'Xuân Phú',4,364),(14131,'Xuân Trung',4,364),(14134,'Xuân Vinh',4,364),(14137,'Xuân Kiên',4,364),(14140,'Xuân Tiến',4,364),(14143,'Xuân Ninh',4,364),(14146,'Xuân Hòa',4,364),(14149,'Ngô Đồng',6,365),(14152,'Quất Lâm',6,365),(14155,'Giao Hương',4,365),(14158,'Hồng Thuận',4,365),(14161,'Giao Thiện',4,365),(14164,'Giao Thanh',4,365),(14167,'Hoành Sơn',4,365),(14170,'Bình Hòa',4,365),(14173,'Giao Tiến',4,365),(14176,'Giao Hà',4,365),(14179,'Giao Nhân',4,365),(14182,'Giao An',4,365),(14185,'Giao Lạc',4,365),(14188,'Giao Châu',4,365),(14191,'Giao Tân',4,365),(14194,'Giao Yến',4,365),(14197,'Giao Xuân',4,365),(14200,'Giao Thịnh',4,365),(14203,'Giao Hải',4,365),(14206,'Bạch Long',4,365),(14209,'Giao Long',4,365),(14212,'Giao Phong',4,365),(14215,'Yên Định',6,366),(14218,'Cồn',6,366),(14221,'Thịnh Long',6,366),(14224,'Hải Nam',4,366),(14227,'Hải Trung',4,366),(14230,'Hải Vân',4,366),(14233,'Hải Minh',4,366),(14236,'Hải Anh',4,366),(14239,'Hải Hưng',4,366),(14242,'Hải Bắc',4,366),(14245,'Hải Phúc',4,366),(14248,'Hải Thanh',4,366),(14251,'Hải Hà',4,366),(14254,'Hải Long',4,366),(14257,'Hải Phương',4,366),(14260,'Hải Đường',4,366),(14263,'Hải Lộc',4,366),(14266,'Hải Quang',4,366),(14269,'Hải Đông',4,366),(14272,'Hải Sơn',4,366),(14275,'Hải Tân',4,366),(14281,'Hải Phong',4,366),(14284,'Hải An',4,366),(14287,'Hải Tây',4,366),(14290,'Hải Lý',4,366),(14293,'Hải Phú',4,366),(14296,'Hải Giang',4,366),(14299,'Hải Cường',4,366),(14302,'Hải Ninh',4,366),(14305,'Hải Chính',4,366),(14308,'Hải Xuân',4,366),(14311,'Hải Châu',4,366),(14314,'Hải Triều',4,366),(14317,'Hải Hòa',4,366);
/*!40000 ALTER TABLE `co_so` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `congtrinhthuyloi`
--

DROP TABLE IF EXISTS `congtrinhthuyloi`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `congtrinhthuyloi` (
  `ID_CongTrinh` int NOT NULL AUTO_INCREMENT,
  `TenCongTrinh` varchar(255) NOT NULL,
  `LoaiCongTrinh` varchar(50) DEFAULT NULL,
  `ViTri` varchar(255) DEFAULT NULL,
  `CapCongTrinh` varchar(50) DEFAULT NULL,
  `ID_QuyHoach` int DEFAULT NULL,
  PRIMARY KEY (`ID_CongTrinh`),
  KEY `ID_QuyHoach` (`ID_QuyHoach`),
  CONSTRAINT `congtrinhthuyloi_ibfk_1` FOREIGN KEY (`ID_QuyHoach`) REFERENCES `quyhoach` (`ID_QuyHoach`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `congtrinhthuyloi`
--

LOCK TABLES `congtrinhthuyloi` WRITE;
/*!40000 ALTER TABLE `congtrinhthuyloi` DISABLE KEYS */;
INSERT INTO `congtrinhthuyloi` VALUES (1,'Hồ chứa Cổ Lễ','Hồ chứa','Huyện Trực Ninh, Nam Định','Cấp 1',1),(2,'Kênh Bắc Nam Định','Kênh mương','Huyện Xuân Trường, Nam Định','Cấp 2',1),(3,'Đập tràn Nghĩa Hưng','Đập tràn','Huyện Nghĩa Hưng, Nam Định','Cấp 3',2),(4,'Trạm bơm Xuân Thủy','Trạm bơm','Huyện Giao Thủy, Nam Định','Cấp 1',2);
/*!40000 ALTER TABLE `congtrinhthuyloi` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `danh_sach_co_so`
--

DROP TABLE IF EXISTS `danh_sach_co_so`;
/*!50001 DROP VIEW IF EXISTS `danh_sach_co_so`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `danh_sach_co_so` AS SELECT 
 1 AS `id`,
 1 AS `data`,
 1 AS `name`,
 1 AS `muc_do_hanh_chinh_id`,
 1 AS `truc_thuoc`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `danhsachlichsutruycap`
--

DROP TABLE IF EXISTS `danhsachlichsutruycap`;
/*!50001 DROP VIEW IF EXISTS `danhsachlichsutruycap`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `danhsachlichsutruycap` AS SELECT 
 1 AS `id`,
 1 AS `data`,
 1 AS `user_name`,
 1 AS `action_type`,
 1 AS `access_time`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `daptran`
--

DROP TABLE IF EXISTS `daptran`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `daptran` (
  `ID_DapTran` int NOT NULL AUTO_INCREMENT,
  `TenDapTran` varchar(255) NOT NULL,
  `ChieuCao` decimal(10,2) DEFAULT NULL,
  `ChieuDai` decimal(10,2) DEFAULT NULL,
  `VatLieu` varchar(50) DEFAULT NULL,
  `TinhTrang` varchar(50) DEFAULT NULL,
  `ViTri` varchar(255) DEFAULT NULL,
  `ID_CongTrinh` int DEFAULT NULL,
  PRIMARY KEY (`ID_DapTran`),
  KEY `ID_CongTrinh` (`ID_CongTrinh`),
  CONSTRAINT `daptran_ibfk_1` FOREIGN KEY (`ID_CongTrinh`) REFERENCES `congtrinhthuyloi` (`ID_CongTrinh`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `daptran`
--

LOCK TABLES `daptran` WRITE;
/*!40000 ALTER TABLE `daptran` DISABLE KEYS */;
INSERT INTO `daptran` VALUES (1,'Đập Nghĩa Hưng 1',15.00,400.00,'Bê tông','Tốt','Huyện Nghĩa Hưng, Nam Định',3),(2,'Đập Nghĩa Hưng 2',10.00,300.00,'Đá','Trung bình','Huyện Nghĩa Hưng, Nam Định',3);
/*!40000 ALTER TABLE `daptran` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dientichtuoi`
--

DROP TABLE IF EXISTS `dientichtuoi`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dientichtuoi` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `id_hanhchinh` int NOT NULL,
  `DienTich` decimal(10,2) DEFAULT NULL,
  `Vu` varchar(50) DEFAULT NULL,
  `Nam` varchar(10) DEFAULT NULL,
  `ThongTinKhac` text,
  PRIMARY KEY (`ID`),
  KEY `id_hanhchinh` (`id_hanhchinh`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dientichtuoi`
--

LOCK TABLES `dientichtuoi` WRITE;
/*!40000 ALTER TABLE `dientichtuoi` DISABLE KEYS */;
/*!40000 ALTER TABLE `dientichtuoi` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `duongong`
--

DROP TABLE IF EXISTS `duongong`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `duongong` (
  `ID_DuongOng` int NOT NULL AUTO_INCREMENT,
  `TenDuongOng` varchar(255) NOT NULL,
  `ChieuDai` decimal(10,2) DEFAULT NULL,
  `DuongKinh` decimal(10,2) DEFAULT NULL,
  `VatLieu` varchar(50) DEFAULT NULL,
  `ViTri` varchar(255) DEFAULT NULL,
  `ID_CongTrinh` int DEFAULT NULL,
  PRIMARY KEY (`ID_DuongOng`),
  KEY `ID_CongTrinh` (`ID_CongTrinh`),
  CONSTRAINT `duongong_ibfk_1` FOREIGN KEY (`ID_CongTrinh`) REFERENCES `congtrinhthuyloi` (`ID_CongTrinh`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `duongong`
--

LOCK TABLES `duongong` WRITE;
/*!40000 ALTER TABLE `duongong` DISABLE KEYS */;
INSERT INTO `duongong` VALUES (1,'Đường ống chính Trực Ninh',1200.00,1.50,'Thép','Huyện Trực Ninh, Nam Định',1),(2,'Đường ống phụ Xuân Trường',800.00,1.00,'Nhựa','Huyện Xuân Trường, Nam Định',2);
/*!40000 ALTER TABLE `duongong` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `muc_do_hanh_chinh`
--

DROP TABLE IF EXISTS `muc_do_hanh_chinh`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `muc_do_hanh_chinh` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `muc_do_hanh_chinh`
--

LOCK TABLES `muc_do_hanh_chinh` WRITE;
/*!40000 ALTER TABLE `muc_do_hanh_chinh` DISABLE KEYS */;
INSERT INTO `muc_do_hanh_chinh` VALUES (1,'Tỉnh'),(2,'Huyện'),(3,'Thành phố'),(4,'xã'),(5,'Phường'),(6,'Thị trấn');
/*!40000 ALTER TABLE `muc_do_hanh_chinh` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `quyhoach`
--

DROP TABLE IF EXISTS `quyhoach`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `quyhoach` (
  `ID_QuyHoach` int NOT NULL AUTO_INCREMENT,
  `TenKyQuyHoach` varchar(255) NOT NULL,
  `ThoiGian` varchar(50) NOT NULL,
  `MoTa` text,
  `BanDoQuyHoach` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`ID_QuyHoach`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `quyhoach`
--

LOCK TABLES `quyhoach` WRITE;
/*!40000 ALTER TABLE `quyhoach` DISABLE KEYS */;
INSERT INTO `quyhoach` VALUES (1,'Quy hoạch thủy lợi Nam Định 2024','2024-01-01','Quy hoạch các công trình thủy lợi tỉnh Nam Định năm 2024','bando_namdinh_2024.pdf'),(2,'Quy hoạch thủy lợi Nam Định 2025','2025-01-01','Quy hoạch nâng cấp các công trình năm 2025','bando_namdinh_2025.pdf');
/*!40000 ALTER TABLE `quyhoach` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trambom`
--

DROP TABLE IF EXISTS `trambom`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `trambom` (
  `ID_TramBom` int NOT NULL AUTO_INCREMENT,
  `TenTramBom` varchar(255) NOT NULL,
  `CongSuat` decimal(10,2) DEFAULT NULL,
  `SoMayBom` int DEFAULT NULL,
  `ViTri` varchar(255) DEFAULT NULL,
  `ID_CongTrinh` int DEFAULT NULL,
  PRIMARY KEY (`ID_TramBom`),
  KEY `ID_CongTrinh` (`ID_CongTrinh`),
  CONSTRAINT `trambom_ibfk_1` FOREIGN KEY (`ID_CongTrinh`) REFERENCES `congtrinhthuyloi` (`ID_CongTrinh`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trambom`
--

LOCK TABLES `trambom` WRITE;
/*!40000 ALTER TABLE `trambom` DISABLE KEYS */;
INSERT INTO `trambom` VALUES (1,'Trạm bơm Xuân Thủy 1',600.00,5,'Huyện Giao Thủy, Nam Định',4),(2,'Trạm bơm Xuân Thủy 2',800.00,8,'Huyện Giao Thủy, Nam Định',4);
/*!40000 ALTER TABLE `trambom` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `id` int NOT NULL AUTO_INCREMENT,
  `is_admin` tinyint(1) DEFAULT '0',
  `user_name` varchar(50) NOT NULL,
  `is_active` tinyint(1) DEFAULT '0',
  `don_vi_cong_tac` int DEFAULT '0',
  `address` varchar(200) NOT NULL,
  `email` varchar(50) NOT NULL,
  `phone` varchar(16) NOT NULL,
  `password` varchar(255) NOT NULL,
  `date_joined` datetime DEFAULT CURRENT_TIMESTAMP,
  `first_name` varchar(255) NOT NULL,
  `last_name` varchar(255) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `user_name` (`user_name`),
  KEY `don_vi_cong_tac` (`don_vi_cong_tac`),
  CONSTRAINT `users_ibfk_1` FOREIGN KEY (`don_vi_cong_tac`) REFERENCES `co_so` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,1,'admin_user',0,36,'Admin Address','admin@example.com','1234567890','hashed_adminpassword','2024-12-13 13:27:32','Admin','User'),(2,0,'user_account',0,36,'User Address','user@example.com','0987654321','hashed_userpassword','2024-12-13 13:27:32','Normal','User'),(3,1,'anh',0,36,'1','1','31','3102004','2024-12-13 20:36:58','11','13'),(5,0,'#',0,36,'a','a','2','3102004aZ','2024-12-19 01:50:49','a','a');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `v_users`
--

DROP TABLE IF EXISTS `v_users`;
/*!50001 DROP VIEW IF EXISTS `v_users`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `v_users` AS SELECT 
 1 AS `id`,
 1 AS `is_admin`,
 1 AS `v_is_admin`,
 1 AS `user_name`,
 1 AS `is_active`,
 1 AS `v_is_active`,
 1 AS `don_vi_cong_tac`,
 1 AS `v_don_vi_cong_tac`,
 1 AS `address`,
 1 AS `email`,
 1 AS `phone`,
 1 AS `password`,
 1 AS `date_joined`,
 1 AS `first_name`,
 1 AS `last_name`,
 1 AS `full_name`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `view_access_by_day`
--

DROP TABLE IF EXISTS `view_access_by_day`;
/*!50001 DROP VIEW IF EXISTS `view_access_by_day`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `view_access_by_day` AS SELECT 
 1 AS `access_date`,
 1 AS `total_accesses`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `view_access_by_hour`
--

DROP TABLE IF EXISTS `view_access_by_hour`;
/*!50001 DROP VIEW IF EXISTS `view_access_by_hour`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `view_access_by_hour` AS SELECT 
 1 AS `access_hour`,
 1 AS `total_accesses`*/;
SET character_set_client = @saved_cs_client;

--
-- Dumping events for database 'benfinit_water'
--

--
-- Dumping routines for database 'benfinit_water'
--
/*!50003 DROP FUNCTION IF EXISTS `bool_to_string` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `bool_to_string`(input INT) RETURNS varchar(5) CHARSET utf8mb4
    DETERMINISTIC
BEGIN
    RETURN IF(input = 1, 'Có', 'Không');
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP FUNCTION IF EXISTS `bool_to_string_active` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `bool_to_string_active`(input INT) RETURNS varchar(5) CHARSET utf8mb4
    DETERMINISTIC
BEGIN
    RETURN IF(input = 1, 'Có', 'Không');
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `f_co_so` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `f_co_so`(
    mode INT,
    _id INT, 
    _id_target INT,
    _name VARCHAR(255),               
    _muc_do_hanh_chinh_id INT,  
    _truc_thuoc INT
)
BEGIN
	
    -- Mode -1: Xóa bản ghi
    IF mode = -1  THEN
		
		INSERT INTO access_history (id, action_type)
		VALUES (_id, CONCAT('Delete co_so', _id_target));
        DELETE FROM co_so WHERE id = _id_target;
    -- Mode 0: Cập nhật bản ghi
    ELSEIF mode = 0 THEN
        -- Cập nhật name nếu không phải NULL
        IF _name IS NOT NULL THEN
            UPDATE co_so 
            SET name = _name
            WHERE id = _id_target;
            INSERT INTO access_history (id, action_type)
            VALUES (_id, CONCAT('Updated _name for ID: ', _id_target,'to',_name));
        END IF;
        -- Cập nhật muc_do_hanh_chinh_id nếu không phải NULL
        IF _muc_do_hanh_chinh_id IS NOT NULL THEN
            UPDATE co_so 
            SET muc_do_hanh_chinh_id = _muc_do_hanh_chinh_id
            WHERE id = _id_target;
            INSERT INTO access_history (id, action_type)
            VALUES (_id, CONCAT('Updated _muc_do_hanh_chinh_id for ID: ', _id_target,'to',_muc_do_hanh_chinh_id));
        END IF;

        -- Cập nhật truc_thuoc nếu không phải NULL
        IF _truc_thuoc IS NOT NULL THEN
            UPDATE co_so
            SET truc_thuoc = _truc_thuoc
            WHERE id = _id_target;
            INSERT INTO access_history (id, action_type)
            VALUES (_id, CONCAT('Updated _truc_thuoc for ID: ', _id_target,'to',_truc_thuoc));
        END IF;

    -- Mode 1: Thêm mới bản ghi
    ELSEIF mode = 1 THEN
        INSERT INTO co_so (truc_thuoc,name,id,muc_do_hanh_chinh_id)
			VALUES (_truc_thuoc,_name,_id_target,_muc_do_hanh_chinh_id);
	ELSE
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Invalid mode';
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `f_dieu_chuyen_cong_tac_1_nhom` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `f_dieu_chuyen_cong_tac_1_nhom`(
	_id int,
    _don_vi_cong_tac_cu INT,   -- ID cũ
    _don_vi_cong_tac_moi INT   -- ID mới
)
BEGIN
	
    -- Khai báo các biến
    DECLARE done INT DEFAULT 0;
    DECLARE cur_id INT;
    
    -- Khai báo con trỏ (cursor) để chọn tất cả các id có truc_thuoc = _truc_thuoc_cu
    DECLARE cur CURSOR FOR
        SELECT id FROM users WHERE don_vi_cong_tac = _don_vi_cong_tac_cu;
    
    -- Khai báo handler để thoát vòng lặp khi không còn id nào
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1;
    
    -- Mở con trỏ
    OPEN cur;
    
    -- Vòng lặp để lấy từng id từ con trỏ
    read_loop: LOOP
        FETCH cur INTO cur_id;  -- Lấy id từ con trỏ
        IF done THEN
            LEAVE read_loop;   -- Thoát vòng lặp khi không còn id nào
        END IF;
        
        -- Cập nhật truc_thuoc cho từng id
        UPDATE users
        SET don_vi_cong_tac = _don_vi_cong_tac_moi
        WHERE id = cur_id;
    END LOOP;
    
    -- Đóng con trỏ
    CLOSE cur;
    INSERT INTO access_history (id, action_type)
	VALUES (_id, CONCAT('Transfer from all user don_vi_cong_tac_id', _don_vi_cong_tac_cu,'to',_don_vi_cong_tac_moi));
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `f_phan_quyen_theo_nhom_co_so` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `f_phan_quyen_theo_nhom_co_so`(
	_id int,
    _truc_thuoc_cu INT,   -- ID cũ
    _truc_thuoc_moi INT   -- ID mới
)
BEGIN
	
    -- Khai báo các biến
    DECLARE done INT DEFAULT 0;
    DECLARE cur_id INT;
    
    -- Khai báo con trỏ (cursor) để chọn tất cả các id có truc_thuoc = _truc_thuoc_cu
    DECLARE cur CURSOR FOR
        SELECT id FROM co_so WHERE truc_thuoc = _truc_thuoc_cu;
    
    -- Khai báo handler để thoát vòng lặp khi không còn id nào
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1;
    
    -- Mở con trỏ
    OPEN cur;
    
    -- Vòng lặp để lấy từng id từ con trỏ
    read_loop: LOOP
        FETCH cur INTO cur_id;  -- Lấy id từ con trỏ
        IF done THEN
            LEAVE read_loop;   -- Thoát vòng lặp khi không còn id nào
        END IF;
        
        -- Cập nhật truc_thuoc cho từng id
        UPDATE co_so
        SET truc_thuoc = _truc_thuoc_moi
        WHERE id = cur_id;
    END LOOP;
    
    -- Đóng con trỏ
    CLOSE cur;
    INSERT INTO access_history (id, action_type)
	VALUES (_id, CONCAT('Transfer from all co_so truc_thuoc_id', _truc_thuoc_cu,'to',_truc_thuoc_moi));
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `f_users` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `f_users`(
    mode INT,
    _id int,
    _id_target int,
    _is_admin BOOLEAN,
    _user_name VARCHAR(50),
    _is_active BOOLEAN,
    _don_vi_cong_tac int,
    _address VARCHAR(200),
    _email VARCHAR(50),
    _phone VARCHAR(16),
    _password VARCHAR(255), -- Storing encrypted password
    _first_name VARCHAR(255),
    _last_name VARCHAR(255)
)
BEGIN
	DECLARE temp INT;
	DECLARE idd INT;
    -- Mode -1: Delete user
    IF mode = -1 THEN
        INSERT INTO access_history (id, action_type)
        VALUES (_id, CONCAT('Deleted user ID: ', _id_target));
        DELETE FROM access_history WHERE id = _id_target;
        DELETE FROM users WHERE id = _id_target;

    -- Mode 0: Update user information
    ELSEIF mode = 0 THEN
        IF _is_admin IS NOT NULL THEN
            UPDATE users
            SET is_admin = _is_admin
            WHERE id = _id_target;
            INSERT INTO access_history (id, action_type)
            VALUES (_id, CONCAT('Updated is_admin for ID: ', _id_target, ' to ', _is_admin));
        END IF;

        IF _user_name IS NOT NULL THEN
            UPDATE users
            SET user_name = _user_name
            WHERE id = _id_target;
            INSERT INTO access_history (id, action_type)
            VALUES (_id, CONCAT('Updated user_name for ID: ', _id_target, ' to ', _user_name));
        END IF;

        IF _is_active IS NOT NULL THEN
            UPDATE users
            SET is_active = _is_active
            WHERE id = _id_target;
            INSERT INTO access_history (id, action_type)
            VALUES (_id, CONCAT('Updated is_active for ID: ', _id_target, ' to ', _is_active));
        END IF;
		IF _don_vi_cong_tac IS NOT NULL THEN
            UPDATE users
            SET don_vi_cong_tac = _don_vi_cong_tac
            WHERE id = _id_target;
            INSERT INTO access_history (id, action_type)
            VALUES (_id, CONCAT('Updated don_vi_cong_tac for ID: ', _id_target,'to',_don_vi_cong_tac));
        END IF;
        -- Update details in thong_tin_user
        IF _address IS NOT NULL THEN
            UPDATE users
            SET address = _address
            WHERE id = _id_target;
            INSERT INTO access_history (id, action_type)
            VALUES (_id, CONCAT('Updated address for ID: ', _id_target,'to',_address));
        END IF;

        IF _email IS NOT NULL THEN
            UPDATE users
            SET email = _email
            WHERE id = _id_target;
            INSERT INTO access_history (id, action_type)
            VALUES (_id, CONCAT('Updated email for ID: ', _id_target,'to',_email));
        END IF;

        IF _phone IS NOT NULL THEN
            UPDATE users
            SET phone = _phone
            WHERE id = _id_target;
            INSERT INTO access_history (id, action_type)
            VALUES (_id, CONCAT('Updated phone for ID: ', _id_target));
        END IF;

        IF _password IS NOT NULL THEN
            UPDATE users
            SET password = _password
            WHERE id = _id_target;
            INSERT INTO access_history (id, action_type)
            VALUES (_id, CONCAT('Updated password for ID: ', _id_target));
        END IF;

        IF _first_name IS NOT NULL THEN
            UPDATE users
            SET first_name = _first_name
            WHERE id = _id_target;
            INSERT INTO access_history (id, action_type)
            VALUES (_id, CONCAT('Updated first_name for ID: ', _id_target,'to',_first_name));
        END IF;

        IF _last_name IS NOT NULL THEN
            UPDATE users
            SET last_name = _last_name
            WHERE id = _id_target;
            INSERT INTO access_history (id, action_type)
            VALUES (_id, CONCAT('Updated last_name for ID: ', _id_target,'to',_last_name));
        END IF;
        
    -- Mode 1: Add new user
    ELSEIF mode = 1 THEN
		IF _don_vi_cong_tac IS NULL THEN 
            SET temp = 0;
        ELSE 
            SET temp = _don_vi_cong_tac;
        END IF;
        INSERT INTO users (is_admin, user_name, is_active, don_vi_cong_tac, address, email, phone, password, first_name, last_name)
        VALUES (_is_admin, _user_name, _is_active, temp, _address, _email, _phone, _password, _first_name, _last_name);

        SELECT id INTO idd FROM users WHERE user_name = _user_name LIMIT 1;
        INSERT INTO access_history (id, action_type)
        VALUES (idd, CONCAT('User created with ID: ', idd));
	
    ELSE
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Invalid mode';
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SearchDatabase` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SearchDatabase`(IN keyword VARCHAR(255))
BEGIN
    DECLARE done INT DEFAULT 0;
    DECLARE tbl_name VARCHAR(255);
    DECLARE col_name VARCHAR(255);
    DECLARE pk_name VARCHAR(255);
    DECLARE result JSON DEFAULT JSON_ARRAY();
    DECLARE cur CURSOR FOR 
        SELECT TABLE_NAME, COLUMN_NAME
        FROM information_schema.COLUMNS
        WHERE TABLE_SCHEMA = DATABASE();

    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1;

    -- Mở con trỏ để duyệt qua các bảng và cột
    OPEN cur;

    read_loop: LOOP
        FETCH cur INTO tbl_name, col_name;
        IF done THEN
            LEAVE read_loop;
        END IF;

        -- Tạo truy vấn động để tìm kiếm trong mỗi bảng/cột
        SET @query = CONCAT('SELECT ', 
                             '(SELECT COLUMN_NAME FROM information_schema.KEY_COLUMN_USAGE WHERE TABLE_NAME = "', tbl_name, 
                             '" AND TABLE_SCHEMA = DATABASE() AND CONSTRAINT_NAME = "PRIMARY" LIMIT 1) AS pk, ',
                             ' "', tbl_name, '" AS table_name, ',
                             ' "', col_name, '" AS column_name FROM ', tbl_name,
                             ' WHERE ', col_name, ' LIKE "%', keyword, '%" LIMIT 1');  -- Thêm LIMIT 1 để chỉ cần 1 dòng kết quả

        -- Thực thi truy vấn động và lưu kết quả vào một bảng tạm
        SET @sql = @query;
        PREPARE stmt FROM @sql;
        EXECUTE stmt;
        DEALLOCATE PREPARE stmt;

        -- Kiểm tra xem có kết quả không
        IF FOUND_ROWS() > 0 THEN
            SET result = JSON_ARRAY_APPEND(result, '$', JSON_OBJECT("table", tbl_name, "column", col_name, "key", pk_name));
        END IF;

    END LOOP;

    CLOSE cur;

    -- Trả về kết quả JSON chứa tất cả các kết quả tìm kiếm
    SELECT result;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Final view structure for view `allcolumns`
--

/*!50001 DROP VIEW IF EXISTS `allcolumns`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `allcolumns` AS select `information_schema`.`columns`.`TABLE_NAME` AS `TABLE_NAME`,concat(`information_schema`.`columns`.`COLUMN_NAME`,' Của ',`information_schema`.`columns`.`TABLE_NAME`) AS `data_seach` from `information_schema`.`COLUMNS` where (`information_schema`.`columns`.`TABLE_SCHEMA` = 'benfinit_water') */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `baocao`
--

/*!50001 DROP VIEW IF EXISTS `baocao`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `baocao` AS select (select count(0) from `users`) AS `so_tai_khoan_hien_co`,(select count(0) from `users` where (`users`.`is_active` = true)) AS `sotaikhoanonline`,(select count(0) from `users` where (`users`.`is_active` = false)) AS `sotaikhoanoffline` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `danh_sach_co_so`
--

/*!50001 DROP VIEW IF EXISTS `danh_sach_co_so`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `danh_sach_co_so` AS select `c`.`id` AS `id`,concat(`m`.`name`,' ',`c`.`name`,' trực thuộc đơn vị ',`p`.`name`) AS `data`,`c`.`name` AS `name`,`c`.`muc_do_hanh_chinh_id` AS `muc_do_hanh_chinh_id`,`c`.`truc_thuoc` AS `truc_thuoc` from ((`co_so` `c` left join `muc_do_hanh_chinh` `m` on((`c`.`muc_do_hanh_chinh_id` = `m`.`id`))) left join `co_so` `p` on((`c`.`truc_thuoc` = `p`.`id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `danhsachlichsutruycap`
--

/*!50001 DROP VIEW IF EXISTS `danhsachlichsutruycap`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `danhsachlichsutruycap` AS select `a`.`id` AS `id`,concat('Người thực hiện: "',`u`.`user_name`) AS `data`,`u`.`user_name` AS `user_name`,`a`.`action_type` AS `action_type`,`a`.`access_time` AS `access_time` from (`access_history` `a` left join `users` `u` on((`u`.`id` = `a`.`id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `v_users`
--

/*!50001 DROP VIEW IF EXISTS `v_users`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `v_users` AS select `u`.`id` AS `id`,`u`.`is_admin` AS `is_admin`,`bool_to_string`(`u`.`is_admin`) AS `v_is_admin`,`u`.`user_name` AS `user_name`,`u`.`is_active` AS `is_active`,`bool_to_string_active`(`u`.`is_active`) AS `v_is_active`,`u`.`don_vi_cong_tac` AS `don_vi_cong_tac`,`c`.`name` AS `v_don_vi_cong_tac`,`u`.`address` AS `address`,`u`.`email` AS `email`,`u`.`phone` AS `phone`,`u`.`password` AS `password`,`u`.`date_joined` AS `date_joined`,`u`.`first_name` AS `first_name`,`u`.`last_name` AS `last_name`,concat(`u`.`first_name`,' ',`u`.`last_name`) AS `full_name` from (`users` `u` left join `co_so` `c` on((`c`.`id` = `u`.`don_vi_cong_tac`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `view_access_by_day`
--

/*!50001 DROP VIEW IF EXISTS `view_access_by_day`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `view_access_by_day` AS select cast(`access_history`.`access_time` as date) AS `access_date`,count(0) AS `total_accesses` from `access_history` where ((`access_history`.`action_type` like 'Updated is_active%') and (`access_history`.`action_type` like '%to 1%')) group by `access_date` order by `access_date` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `view_access_by_hour`
--

/*!50001 DROP VIEW IF EXISTS `view_access_by_hour`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `view_access_by_hour` AS select date_format(`access_history`.`access_time`,'%Y-%m-%d %H:00:00') AS `access_hour`,count(0) AS `total_accesses` from `access_history` where ((`access_history`.`action_type` like 'Updated is_active%') and (`access_history`.`action_type` like '%to 1%')) group by `access_hour` order by `access_hour` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-12-20  5:30:59
