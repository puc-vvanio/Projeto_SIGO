CREATE DATABASE IF NOT EXISTS `autenticacao` CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
GRANT ALL ON `autenticacao`.* TO 'sysdba'@'%';

CREATE DATABASE IF NOT EXISTS `normastecnicas` CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
GRANT ALL ON `normastecnicas`.* TO 'sysdba'@'%';

CREATE DATABASE IF NOT EXISTS `consultorias` CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
GRANT ALL ON `consultorias`.* TO 'sysdba'@'%';

CREATE DATABASE IF NOT EXISTS `processoindustrial` CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
GRANT ALL ON `processoindustrial`.* TO 'sysdba'@'%';
