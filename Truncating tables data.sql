------------------------Queries for truncating tables data----------------------

alter table [Member]
drop constraint [FK__Member__TeamID__38996AB5]
GO

alter table [ProjectMember]
drop constraint [FK__ProjectMe__Membe__3C69FB99]
GO

alter table [ProjectMember]
drop constraint [FK__ProjectMe__Proje__3D5E1FD2]
GO

truncate table project
truncate table team
truncate table member
truncate table projectmember
GO

ALTER TABLE [dbo].[Member]  WITH CHECK ADD  CONSTRAINT [FK__Member__TeamID__38996AB5] FOREIGN KEY([TeamID])
REFERENCES [dbo].[Team] ([TeamID])
GO
ALTER TABLE [dbo].[Member] CHECK CONSTRAINT [FK__Member__TeamID__38996AB5]
GO


ALTER TABLE [dbo].[ProjectMember]  WITH CHECK ADD  CONSTRAINT [FK__ProjectMe__Membe__3C69FB99] FOREIGN KEY([MemberID])
REFERENCES [dbo].[Member] ([MemberID])
GO
ALTER TABLE [dbo].[ProjectMember] CHECK CONSTRAINT [FK__ProjectMe__Membe__3C69FB99]
GO


ALTER TABLE [dbo].[ProjectMember]  WITH CHECK ADD  CONSTRAINT [FK__ProjectMe__Proje__3D5E1FD2] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[ProjectMember] CHECK CONSTRAINT [FK__ProjectMe__Proje__3D5E1FD2]
GO


select * from team
select * from member
select * from project
select * from projectmember