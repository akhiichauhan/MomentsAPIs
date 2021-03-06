---- MySQL Workbench Forward Engineering

--SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
--SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
--SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

---- -----------------------------------------------------
---- Schema mydb
---- -----------------------------------------------------
---- -----------------------------------------------------
---- Schema moments
---- -----------------------------------------------------
--DROP SCHEMA IF EXISTS `moments` ;

---- -----------------------------------------------------
---- Schema moments
---- -----------------------------------------------------
--CREATE SCHEMA IF NOT EXISTS `moments` DEFAULT CHARACTER SET latin1 ;
--USE `moments` ;

---- -----------------------------------------------------
---- Table `moments`.`person`
---- -----------------------------------------------------
--DROP TABLE IF EXISTS `moments`.`person` ;

--CREATE TABLE IF NOT EXISTS `moments`.`person` (
--  `personId` INT(11) NOT NULL AUTO_INCREMENT COMMENT '',
--  `CreatedOn` DATETIME NULL DEFAULT NULL COMMENT '',
--  PRIMARY KEY (`personId`))
--ENGINE = InnoDB
--DEFAULT CHARACTER SET = latin1;


---- -----------------------------------------------------
---- Table `moments`.`user`
---- -----------------------------------------------------
--DROP TABLE IF EXISTS `moments`.`user` ;

--CREATE TABLE IF NOT EXISTS `moments`.`user` (
--  `userid` INT(11) NOT NULL AUTO_INCREMENT  COMMENT '',
--  `peopleId` INT(11) NULL DEFAULT NULL COMMENT '',
--   `userIdentifier` INT(11) NULL DEFAULT NULL COMMENT '',
--  `CreatedDate` DATETIME NULL DEFAULT NULL COMMENT '',
--  `CreatedBy` VARCHAR(45) NULL DEFAULT NULL COMMENT '',
--  `UpdatedOn` DATETIME NULL DEFAULT NULL COMMENT '',
--  `UpdatedBy` DATETIME NULL DEFAULT NULL COMMENT '',
--  `FirstName` VARCHAR(150) NULL DEFAULT NULL COMMENT '',
--  `MiddleName` VARCHAR(150) NULL DEFAULT NULL COMMENT '',
--  `LastName` VARCHAR(150) NULL DEFAULT NULL COMMENT '',
--  `emailId` VARCHAR(45) NULL DEFAULT NULL COMMENT '',
--  `gender` VARCHAR(45) NULL DEFAULT NULL COMMENT '',
--  PRIMARY KEY (`userid`),
--  INDEX `People_user_idx` (`peopleId` ASC),
--  CONSTRAINT `People_user`
--    FOREIGN KEY (`peopleId`)
--    REFERENCES `moments`.`person` (`personId`)
--    ON DELETE NO ACTION
--    ON UPDATE NO ACTION)
--ENGINE = InnoDB
--DEFAULT CHARACTER SET = latin1;


---- -----------------------------------------------------
---- Table `moments`.`friends`
---- -----------------------------------------------------
--DROP TABLE IF EXISTS `moments`.`friends` ;

--CREATE TABLE IF NOT EXISTS `moments`.`friends` (
--  `Id` INT(11) NOT NULL AUTO_INCREMENT COMMENT '',
--  `userId` INT(11) NULL DEFAULT NULL COMMENT '',
--  `friendId` VARCHAR(45) NULL DEFAULT NULL COMMENT '',
--  PRIMARY KEY (`Id`),
--  INDEX `user_friend_idx` (`userId` ASC),
--  CONSTRAINT `user_friend`
--    FOREIGN KEY (`userId`)
--    REFERENCES `moments`.`user` (`userid`)
--    ON DELETE NO ACTION
--    ON UPDATE NO ACTION)
--ENGINE = InnoDB
--DEFAULT CHARACTER SET = latin1;


---- -----------------------------------------------------
---- Table `moments`.`photos`
---- -----------------------------------------------------
--DROP TABLE IF EXISTS `moments`.`photos` ;

--CREATE TABLE IF NOT EXISTS `moments`.`photos` (
--  `PhotoId` INT(11) NOT NULL AUTO_INCREMENT COMMENT '',
--  `userId` INT(11) NULL DEFAULT NULL COMMENT '',
--  `url` VARCHAR(500) NULL DEFAULT NULL COMMENT '',
--  `location` VARCHAR(200) NULL DEFAULT NULL COMMENT '',
--  `time` DATETIME NULL DEFAULT NULL COMMENT '',
--  PRIMARY KEY (`PhotoId`),
--  INDEX `user_Photos_idx` (`userId` ASC),
--  CONSTRAINT `user_Photos`
--    FOREIGN KEY (`userId`)
--    REFERENCES `moments`.`user` (`userid`)
--    ON DELETE NO ACTION
--    ON UPDATE NO ACTION)
--ENGINE = InnoDB
--DEFAULT CHARACTER SET = latin1;


---- -----------------------------------------------------
---- Table `moments`.`phototag`
---- -----------------------------------------------------
--DROP TABLE IF EXISTS `moments`.`phototag` ;

--CREATE TABLE IF NOT EXISTS `moments`.`phototag` (
--  `tagId` INT(11) NOT NULL AUTO_INCREMENT COMMENT '',
--  `photoId` INT(11) NULL DEFAULT NULL COMMENT '',
--  `personId` INT(11) NULL DEFAULT NULL COMMENT '',
--  PRIMARY KEY (`tagId`),
--  INDEX `photo_photoTags_idx` (`photoId` ASC),
--  INDEX `person_photoTags_idx` (`personId` ASC),
--  CONSTRAINT `person_phototags`
--    FOREIGN KEY (`personId`)
--    REFERENCES `moments`.`person` (`personId`)
--    ON DELETE NO ACTION
--    ON UPDATE NO ACTION,
--  CONSTRAINT `photo_phototags`
--    FOREIGN KEY (`photoId`)
--    REFERENCES `moments`.`photos` (`PhotoId`)
--    ON DELETE NO ACTION
--    ON UPDATE NO ACTION)
--ENGINE = InnoDB
--DEFAULT CHARACTER SET = latin1;


--SET SQL_MODE=@OLD_SQL_MODE;
--SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
--SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
