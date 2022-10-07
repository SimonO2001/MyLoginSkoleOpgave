USE Master
GO
IF DB_ID('LoginDB') IS NOT NULL
	BEGIN
		ALTER DATABASE LoginDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
		DROP DATABASE LoginDB
	END
GO
CREATE DATABASE LoginDB
GO
USE LoginDB
GO

DROP TABLE IF EXISTS UserDataTable
CREATE TABLE UserDataTable (
LoginUser NVARCHAR(255) NOT NULL PRIMARY KEY,
LoginPassword NVARCHAR(255) NOT NULL,
)

INSERT INTO UserDataTable (LoginUser, LoginPassword) VALUES ('cristiano ronaldo', 'suii1')
INSERT INTO UserDataTable (LoginUser, LoginPassword) VALUES ('Lionel Messi', 'w0rldb3st')