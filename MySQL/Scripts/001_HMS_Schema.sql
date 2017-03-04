-- Create Database

create database if not exists HMS_SriSena;

use HMS_SriSena;

-- HMS_Detail

CREATE TABLE IF NOT EXISTS `HMS_Detail` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `RoomType` varchar(50),
  `RoomNo` varchar(10),
  `NoOfDays` smallint(1) unsigned,
  `Name` varchar(100),
  `IC` varchar(50),
  `ContactNo` varchar(50),
  `Address` varchar(150),
  `RoomPrice` decimal(6,2) unsigned,

  `TotalPrice` decimal(8,2) unsigned,

  `PaidAmount` decimal(8,2) unsigned,
  `DepositAmount` decimal(6,2) unsigned,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;

-- HMS_Log

CREATE TABLE IF NOT EXISTS `HMS_Log` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `RoomNo` varchar(10) NOT NULL,
  `LogType` tinyint(1) unsigned NOT NULL default '0',
  `DateTime` datetime NOT NULL,
  `DetailID` int(10) unsigned,
  `MaintenanceID` int(10) unsigned,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;

-- HMS_Maintenance

CREATE TABLE IF NOT EXISTS `HMS_Maintenance` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Room` varchar(10) NOT NULL,
  `Reason` varchar(200),
  `Complete` tinyint(1) NOT NULL default '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;

-- HMS_Room

CREATE TABLE IF NOT EXISTS `HMS_Room` (
  `id` int(5) unsigned NOT NULL AUTO_INCREMENT,
  `RoomType` varchar(50) NOT NULL,
  `RoomNo` varchar(10) NOT NULL,
  `Price` decimal(6,2) unsigned,

  `Picture` blob,
  `IsUsed` tinyint(1) NOT NULL default '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;

-- HMS_RoomOccupant

CREATE TABLE IF NOT EXISTS `HMS_RoomOccupant` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `RoomNo` varchar(10) NOT NULL,
  `DetailID` int(10) unsigned,
  `CheckInDate` datetime,
  `CheckOutDate` datetime,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;

-- HMS_ReceiptNo

CREATE TABLE IF NOT EXISTS `HMS_ReceiptNo` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `DetailID` int(10) unsigned,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;