CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Username] NVARCHAR(100) NOT NULL, 
    [Password] NVARCHAR(100) NOT NULL
)

INSERT INTO [dbo].[Users] ([username], [Password])
VALUES
('Admin', 'Admin'),
('Cyrill Josh', 'Odato'),
('Charles Andre', 'Pua'),
('Aikem', 'Buenaflor'),
('William', 'Marpa')