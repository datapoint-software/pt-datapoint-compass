USE `Compass`;

INSERT INTO `Roles` (`Id`, `RowVersionId`, `Name`) VALUES
	(UUID(), UUID(), 'Administrators');
    
INSERT INTO `Employees` (`Id`, `RowVersionId`, `Name`, `EmailAddress`, `PasswordHash`) VALUES
	(UUID(), UUID(), 'Willy E. Coyote', 'hello@datapoint.software', '$2b$14$mepBaTN6hpsdPfeOQPYcauSVkIBzrtf/uetJlO7CkyZnFFlcdxgHm');
    
INSERT INTO `EmployeeRoles` (`EmployeeId`, `RoleId`) 
	SELECT `e`.`Id`, `r`.`Id`
    FROM `Employees` `e`, `Roles` `r`
    WHERE `e`.`Name` = 'Willy E. Coyote' AND `r`.`Name` = 'Administrators';