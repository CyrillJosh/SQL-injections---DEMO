CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Username] NVARCHAR(100) NOT NULL, 
    [Password] NVARCHAR(100) NOT NULL
)

INSERT INTO [dbo].[Users]
VALUES
('Admin', 'Admin'),
('Cyrill Josh', 'Odato')
('Charles Andre', 'Pua')
('Aikem', 'Buenaflor')
('William', 'Marpa')