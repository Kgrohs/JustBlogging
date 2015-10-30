CREATE TABLE [dbo].[Entry]
(
	[EntryId] INT NOT NULL Identity(1,1) PRIMARY KEY,
	[UserId] INT NOT NULL,
	[EntryText] NVARCHAR(MAX) NOT NULL
	CONSTRAINT FK_User_Entry FOREIGN KEY (UserId) 
    REFERENCES [dbo].[User] (UserId), 
    [Date] DATETIME NOT NULL 
)
