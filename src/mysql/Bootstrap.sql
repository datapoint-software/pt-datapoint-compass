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