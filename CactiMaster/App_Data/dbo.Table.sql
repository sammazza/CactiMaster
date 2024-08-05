CREATE TABLE [dbo].[usersTbl]
(
	[uName] NVARCHAR(30) NOT NULL PRIMARY KEY, 
    [fName] NVARCHAR(15) NOT NULL, 
    [lName] NVARCHAR(20) NOT NULL, 
    [email] NVARCHAR(30) NOT NULL, 
    [yearBorn] INT NOT NULL, 
    [gender] NVARCHAR(1) NOT NULL, 
    [prefix] NVARCHAR(3) NOT NULL, 
    [phone] NCHAR(7) NOT NULL, 
    [city] NVARCHAR(20) NOT NULL, 
    [hob1] NCHAR(1) NOT NULL, 
    [hob2] NCHAR(1) NOT NULL, 
    [hob3] NCHAR(1) NOT NULL, 
    [hob4] NCHAR(1) NOT NULL, 
    [password] NVARCHAR(10) NOT NULL,
	[isAdmin] NCHAR(1) NOT NULL
)
