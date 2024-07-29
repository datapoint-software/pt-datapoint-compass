CREATE DATABASE `Compass` 
    DEFAULT ENCRYPTION 'N'
	DEFAULT CHARACTER SET `utf8mb4`
    COLLATE `utf8mb4_0900_ai_ci`;

CREATE USER 'compass-app'@'%'
IDENTIFIED BY '815c3306-f775-4bf5-9d87-1e9e70899fbc';

GRANT DELETE, INSERT, UPDATE, SELECT
	ON `Compass`.* 
	TO 'compass-app'@'%';

FLUSH PRIVILEGES;

CREATE USER 'compass-migrator-app'@'%'
	IDENTIFIED BY '9d67330f-2df4-4174-a7b7-a5440acfd967';
    
GRANT ALL PRIVILEGES
	ON `Compass`.* 
	TO 'compass-migrator-app'@'%';
    
FLUSH PRIVILEGES;