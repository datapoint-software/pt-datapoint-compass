USE `Compass`;

--
-- Facilities
--
INSERT INTO `Facilities` (`Id`, `RowVersionId`, `Code`, `Name`) VALUES
	(UUID(), UUID(), 'A206', 'ACME Washington, DC');

-- 
-- Services
--
INSERT INTO `Services` (`Id`, `RowVersionId`, `Code`, `Name`) VALUES
	(UUID(), UUID(), 'CHCR', 'Childcare');

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
	SELECT `r`.`Id`, 870835
    FROM `Roles` `r`
    WHERE NOT EXISTS (SELECT * FROM `RolePermissions` `rp` WHERE `rp`.`Permission` = 870835)
    
	UNION
	SELECT `r`.`Id`, 876993
    FROM `Roles` `r`
    WHERE NOT EXISTS (SELECT * FROM `RolePermissions` `rp` WHERE `rp`.`Permission` = 876993);
    
