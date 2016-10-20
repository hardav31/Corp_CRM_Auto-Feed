use [praemium1]

IF OBJECT_ID('[dbo].[Team]', 'u') IS NOT NULL
    DROP table [dbo].[Team];
GO

CREATE TABLE Team
(
TeamID bigint NOT NULL PRIMARY KEY,
TeamName nvarchar(50) NOT NULL
)
GO

IF OBJECT_ID('[dbo].[Member]', 'u') IS NOT NULL
    DROP table [dbo].[Member];
GO
CREATE TABLE Member
(
MemberID bigint NOT NULL PRIMARY KEY,
TeamID bigint NOT NULL FOREIGN KEY REFERENCES Team(TeamID),
MemberName nvarchar(50) NOT NULL,
MemberSurname nvarchar(50) NOT NULL
)
GO

IF OBJECT_ID('[dbo].[Project]', 'u') IS NOT NULL
    DROP table [dbo].[Project];
GO

CREATE TABLE Project
(
ProjectID bigint NOT NULL PRIMARY KEY,
ProjectName nvarchar(50) NOT NULL,
ProjectCreatedDate date NOT NULL,
ProjectDueDate date NOT NULL,
ProjectDescription nvarchar(50) NOT NULL
)
GO

IF OBJECT_ID('[dbo].[ProjectMember]', 'u') IS NOT NULL
    DROP table [dbo].[ProjectMember];
GO

CREATE TABLE ProjectMember
(
MemberID bigint NOT NULL FOREIGN KEY REFERENCES Member(MemberID),
ProjectID bigint NOT NULL FOREIGN KEY REFERENCES Project(ProjectID)
)
GO