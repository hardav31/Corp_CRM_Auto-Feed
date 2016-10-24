﻿use [praemium1]

IF OBJECT_ID('[dbo].[Team]', 'u') IS NOT NULL
    DROP table [dbo].[Team];
GO

CREATE TABLE [dbo].[Team](
	[TeamID] [bigint] NOT NULL,
	[TeamName] [nvarchar](50) NOT NULL,
	[isDeleted] [bit] NOT NULL CONSTRAINT [DF_Team_isDeleted]  DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[TeamID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO

IF OBJECT_ID('[dbo].[Member]', 'u') IS NOT NULL
    DROP table [dbo].[Member];
GO

CREATE TABLE [dbo].[Member](
	[MemberID] [bigint] NOT NULL,
	[TeamID] [bigint] NOT NULL,
	[MemberName] [nvarchar](50) NOT NULL,
	[MemberSurname] [nvarchar](50) NOT NULL,
	[isDeleted] [bit] NOT NULL CONSTRAINT [DF_Member_isDeleted]  DEFAULT ((0)),
 CONSTRAINT [PK__Member__0CF04B38FB5B69FB] PRIMARY KEY CLUSTERED 
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO

ALTER TABLE [dbo].[Member]  WITH CHECK ADD  CONSTRAINT [FK__Member__TeamID__38996AB5] FOREIGN KEY([TeamID])
REFERENCES [dbo].[Team] ([TeamID])
GO

ALTER TABLE [dbo].[Member] CHECK CONSTRAINT [FK__Member__TeamID__38996AB5]
GO
GO

IF OBJECT_ID('[dbo].[Project]', 'u') IS NOT NULL
    DROP table [dbo].[Project];
GO


CREATE TABLE [dbo].[Project](
	[ProjectID] [bigint] NOT NULL,
	[ProjectName] [nvarchar](50) NOT NULL,
	[ProjectCreatedDate] [date] NOT NULL,
	[ProjectDueDate] [date] NOT NULL,
	[ProjectDescription] [nvarchar](50) NOT NULL,
	[isDeleted] [bit] NOT NULL CONSTRAINT [DF_Project_isDeleted]  DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO

IF OBJECT_ID('[dbo].[ProjectMember]', 'u') IS NOT NULL
    DROP table [dbo].[ProjectMember];
GO


CREATE TABLE [dbo].[ProjectMember](
	[MemberID] [bigint] NOT NULL,
	[ProjectID] [bigint] NOT NULL
)

GO

ALTER TABLE [dbo].[ProjectMember]  WITH CHECK ADD  CONSTRAINT [FK__ProjectMe__Membe__3C69FB99] FOREIGN KEY([MemberID])
REFERENCES [dbo].[Member] ([MemberID])
GO

ALTER TABLE [dbo].[ProjectMember] CHECK CONSTRAINT [FK__ProjectMe__Membe__3C69FB99]
GO

ALTER TABLE [dbo].[ProjectMember]  WITH CHECK ADD FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO