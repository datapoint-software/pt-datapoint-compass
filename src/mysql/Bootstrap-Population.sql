USE `Compass`;

--
-- Roles
--
INSERT INTO `Roles` (`Id`, `RowVersionId`, `Name`) VALUES
	(UUID(), UUID(), 'Administrators');

--
-- Employees
--
INSERT INTO `Employees` (`Id`, `RowVersionId`, `Name`, `EmailAddress`, `PasswordHash`) VALUES
	(UUID(), UUID(), 'Willy E. Coyote', 'hello@datapoint.software', '$2b$14$mepBaTN6hpsdPfeOQPYcauSVkIBzrtf/uetJlO7CkyZnFFlcdxgHm');

--
-- Employee roles
--
INSERT INTO `EmployeeRoles` (`EmployeeId`, `RoleId`) 
	SELECT `e`.`Id`, `r`.`Id`
    FROM `Employees` `e`, `Roles` `r`
    WHERE `e`.`Name` = 'Willy E. Coyote' AND `r`.`Name` = 'Administrators';
    
--
-- Role permissions
--
INSERT INTO `RolePermissions` (`RoleId`, `Permission`)
	SELECT `r`.`Id`, 312983
    FROM `Roles` `r`
    WHERE NOT EXISTS (SELECT * FROM `RolePermissions` `rp` WHERE `rp`.`Permission` = 312983);
	
INSERT INTO `RolePermissions` (`RoleId`, `Permission`)
    SELECT `r`.`Id`, 429881
    FROM `Roles` `r`
    WHERE NOT EXISTS (SELECT * FROM `RolePermissions` `rp` WHERE `rp`.`Permission` = 429881);
	
INSERT INTO `RolePermissions` (`RoleId`, `Permission`)
    SELECT `r`.`Id`, 601347
    FROM `Roles` `r`
    WHERE NOT EXISTS (SELECT * FROM `RolePermissions` `rp` WHERE `rp`.`Permission` = 601347);