-- MySQL Script generated by MySQL Workbench
-- 09/28/15 00:25:24
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mydb` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `mydb` ;

-- -----------------------------------------------------
-- Table `mydb`.`Faculties`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Faculties` (
  `Id` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `FacultyName` VARCHAR(45) NULL COMMENT '',
  PRIMARY KEY (`Id`)  COMMENT '')
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Departments`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Departments` (
  `Id` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `DepartmentName` VARCHAR(45) NOT NULL COMMENT '',
  `FacultyId` INT NOT NULL COMMENT '',
  PRIMARY KEY (`Id`)  COMMENT '',
  INDEX `fk_Departments_Faculties_idx` (`FacultyId` ASC)  COMMENT '',
  CONSTRAINT `fk_Departments_Faculties`
    FOREIGN KEY (`FacultyId`)
    REFERENCES `mydb`.`Faculties` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Courses`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Courses` (
  `Id` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `CourseName` VARCHAR(45) NOT NULL COMMENT '',
  `TrainingHours` INT NULL COMMENT '',
  PRIMARY KEY (`Id`)  COMMENT '')
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Professors`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Professors` (
  `Id` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `FirstName` VARCHAR(45) NULL COMMENT '',
  `LastName` VARCHAR(45) NOT NULL COMMENT '',
  `DepartmentId` INT NOT NULL COMMENT '',
  `CourseId` INT NOT NULL COMMENT '',
  PRIMARY KEY (`Id`)  COMMENT '',
  INDEX `fk_Professors_Departments1_idx` (`DepartmentId` ASC)  COMMENT '',
  INDEX `fk_Professors_Courses1_idx` (`CourseId` ASC)  COMMENT '',
  CONSTRAINT `fk_Professors_Departments1`
    FOREIGN KEY (`DepartmentId`)
    REFERENCES `mydb`.`Departments` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Professors_Courses1`
    FOREIGN KEY (`CourseId`)
    REFERENCES `mydb`.`Courses` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Departments_Courses`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Departments_Courses` (
  `DepartmentId` INT NOT NULL COMMENT '',
  `CourseId` INT NOT NULL COMMENT '',
  INDEX `fk_Departments_Courses_Departments1_idx` (`DepartmentId` ASC)  COMMENT '',
  INDEX `fk_Departments_Courses_Courses1_idx` (`CourseId` ASC)  COMMENT '',
  CONSTRAINT `fk_Departments_Courses_Departments1`
    FOREIGN KEY (`DepartmentId`)
    REFERENCES `mydb`.`Departments` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Departments_Courses_Courses1`
    FOREIGN KEY (`CourseId`)
    REFERENCES `mydb`.`Courses` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Titles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Titles` (
  `Id` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `Title` VARCHAR(25) NULL COMMENT '',
  PRIMARY KEY (`Id`)  COMMENT '')
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Professors_Titles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Professors_Titles` (
  `ProfessorId` INT NOT NULL COMMENT '',
  `TitleId` INT NOT NULL COMMENT '',
  INDEX `fk_Professors_Titles_Professors1_idx` (`ProfessorId` ASC)  COMMENT '',
  INDEX `fk_Professors_Titles_Titles1_idx` (`TitleId` ASC)  COMMENT '',
  CONSTRAINT `fk_Professors_Titles_Professors1`
    FOREIGN KEY (`ProfessorId`)
    REFERENCES `mydb`.`Professors` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Professors_Titles_Titles1`
    FOREIGN KEY (`TitleId`)
    REFERENCES `mydb`.`Titles` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Students`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Students` (
  `Id` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `FirstName` VARCHAR(25) NULL COMMENT '',
  `LastName` VARCHAR(25) NOT NULL COMMENT '',
  `AdmissionDate` DATE NULL COMMENT '',
  `FacultyId` INT NOT NULL COMMENT '',
  PRIMARY KEY (`Id`)  COMMENT '',
  INDEX `fk_Students_Faculties1_idx` (`FacultyId` ASC)  COMMENT '',
  CONSTRAINT `fk_Students_Faculties1`
    FOREIGN KEY (`FacultyId`)
    REFERENCES `mydb`.`Faculties` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Students_Courses`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Students_Courses` (
  `StudentId` INT NOT NULL COMMENT '',
  `CourseId` INT NOT NULL COMMENT '',
  INDEX `fk_Students_Courses_Students1_idx` (`StudentId` ASC)  COMMENT '',
  INDEX `fk_Students_Courses_Courses1_idx` (`CourseId` ASC)  COMMENT '',
  CONSTRAINT `fk_Students_Courses_Students1`
    FOREIGN KEY (`StudentId`)
    REFERENCES `mydb`.`Students` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Students_Courses_Courses1`
    FOREIGN KEY (`CourseId`)
    REFERENCES `mydb`.`Courses` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
