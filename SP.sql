IF EXISTS (SELECT * FROM sys.objects so join sys.schemas sc on so.schema_id = sc.schema_id WHERE so.type = 'P' AND so.name = 'getAllRecords' and sc.name=N'dbo')
	DROP PROCEDURE [dbo].[getAllRecords]
GO
CREATE PROC [dbo].[getAllRecords]
(
	@MemberName nvarchar(50)=null,
	@MemberSurname nvarchar(50)=null,
	@TeamName nvarchar(50)=null,
	@ProjectName nvarchar(50)=null,
	@ProjectCreatedDate nvarchar(50)=null,
	@ProjectDueDate nvarchar(50)=null,
	@ProjectDescription nvarchar(50)=null
	)
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @condition nvarchar(1000)
	
	SET @condition=concat(iif(@MemberName is not null, concat('MemberName=''',@MemberName, ''''), ''),
	iif(@TeamName is not null, concat(',TeamName=''', @TeamName,''''), ''),
	iif(@MemberSurname is not null, concat(',MemberSurname=''', @MemberSurname,''''), ''),
	iif(@ProjectName is not null, concat(',ProjectName=''', @ProjectName,''''), ''),
	iif(@ProjectCreatedDate is not null, concat(',ProjectCreatedDate=''', @ProjectCreatedDate,''''), ''),
	iif(@ProjectDueDate is not null, concat(',ProjectDueDate=''', @ProjectDueDate,''''), ''),
	iif(@ProjectDescription is not null, concat(' ProjectDescription=''', @ProjectDescription,''''), '')
	)

	IF (left(@condition, 1)) =','
	SET @condition=right(@condition, len(@condition)-1)

	SET @condition=replace(@condition, ',', ' and ')
	
	DECLARE @sql nvarchar(max)
		
	SET @sql='SELECT Member.MemberName, Member.MemberSurname,Team.TeamName,Project.ProjectName,Project.ProjectCreatedDate,Project.ProjectDueDate,Project.ProjectDescription FROM 
	Member INNER JOIN Team ON Member.TeamID=Team.TeamID
	INNER JOIN ProjectMember ON Member.MemberID=ProjectMember.MemberID
	INNER JOIN Project ON Project.ProjectID=ProjectMember.ProjectID'
	
	IF (@condition<>'')
    SET @sql=concat(@sql,' where ', @condition)
    
	EXECUTE sp_executesql  @sql
END

GO

--exec dbo.getProjectMemberTeam @condition='Project.ProjectName Like N''%Project1%'''

IF EXISTS (SELECT * FROM sys.objects so join sys.schemas sc on so.schema_id = sc.schema_id WHERE so.type = 'P' AND so.name = 'insertData' and sc.name=N'dbo')
	DROP PROCEDURE [dbo].[insertData]
GO

USE [praemium1]
GO
/****** Object:  StoredProcedure [dbo].[insertData]    Script Date: 11/4/2016 12:35:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[insertData]
(
	@sourcetable Source READONLY
)
AS
BEGIN
	SET NOCOUNT ON
		
		
-----------------------------Data for testing------------------------------------

	--declare @input Source
	--insert into  @input
	--select distinct Member.memberid,member.MemberName, Member.MemberSurname, 400 as  TeramID, team.teamname,  project.ProjectID,'Project1' as ProjectName, project.ProjectCreatedDate, project.ProjectDueDate, project.ProjectDescription from team inner join Member on member.teamid=team.teamid
	--inner join projectmember on projectmember.memberid=member.memberid
	--inner join project on project.projectid=projectmember.projectid
	--where member.teamid=111 and member.memberid=1 and project.projectid=1


	DECLARE @faildresult varchar(max)

	BEGIN TRY
	BEGIN TRANSACTION

-----------------------------Inset/Update Team table------------------------------------

		MERGE Team AS targetTeam
		USING (SELECT Distinct TeamID, TeamName FROM @sourcetable) AS sourceTeam   
		ON (targetTeam.TeamID=sourceTeam.TeamID AND targetTeam.isDeleted=0)
		WHEN MATCHED AND targetTeam.TeamName<>sourceTeam.TeamName 
		THEN
			UPDATE SET targetTeam.TeamName=sourceTeam.TeamName, targetTeam.Modified=GETDATE() 
		WHEN NOT MATCHED  BY TARGET 
		THEN  
			INSERT (TeamID, TeamName)  
			VALUES (sourceTeam.TeamID, sourceTeam.TeamName);
			--OUTPUT $action, 
			--Inserted.TeamID,
			--Inserted.TeamName,
			--deleted.TeamID,
			--deleted.TeamName;



-----------------------------Inset/Update Member table------------------------------------

		MERGE Member AS targetMember
		USING (SELECT Distinct MemberID, MemberName, MemberSurname, TeamID FROM @sourcetable) AS sourceMember   
		ON (targetMember.MemberID=sourceMember.MemberID AND targetMember.isDeleted=0 )  
		WHEN MATCHED AND targetMember.MemberName<>sourceMember.MemberName 
			OR targetMember.MemberSurname<>sourceMember.MemberSurname 
			OR targetMember.TeamID<>sourceMember.TeamID
		THEN
			UPDATE SET targetMember.MemberName=sourceMember.MemberName, 
			targetMember.MemberSurname=sourceMember.MemberSurname,
			targetMember.TeamID=sourceMember.TeamID,targetMember.Modified=GETDATE()
		WHEN NOT MATCHED  BY TARGET 
		THEN  
			INSERT  (MemberID, MemberName, MemberSurname, TeamID)  
			VALUES (sourceMember.MemberID, sourceMember.MemberName, sourceMember.MemberSurname, sourceMember.TeamID);
			--OUTPUT $action, 
			--Inserted.MemberID,
			--Inserted.MemberName,
			--Inserted.MemberSurname,
			--deleted.MemberID,
			--deleted.MemberName,
			--deleted.MemberSurname;
	
		

-----------------------------Inset/Update Project table------------------------------------

		MERGE Project AS targetProject
		USING (SELECT Distinct ProjectID, ProjectName, ProjectCreatedDate, ProjectDueDate, ProjectDescription FROM @sourcetable) AS sourceProject   
		ON (targetProject.ProjectID=sourceProject.ProjectID AND targetProject.isDeleted=0)  
		WHEN MATCHED AND targetProject.ProjectName<>sourceProject.ProjectName 
			OR targetProject.ProjectCreatedDate<>sourceProject.ProjectCreatedDate
			OR targetProject.ProjectDueDate<>sourceProject.ProjectDueDate
			OR targetProject.ProjectDescription<>sourceProject.ProjectDescription
		THEN
			UPDATE SET targetProject.ProjectName=sourceProject.ProjectName,
			targetProject.ProjectCreatedDate=sourceProject.ProjectCreatedDate,
			targetProject.ProjectDueDate=sourceProject.ProjectDueDate,
			targetProject.ProjectDescription=sourceProject.ProjectDescription,
			targetProject.Modified=GETDATE()
		
		WHEN NOT MATCHED  BY TARGET 
		THEN  
			INSERT (ProjectID, ProjectName, ProjectCreatedDate, ProjectDueDate, ProjectDescription )  
			VALUES (sourceProject.ProjectID, sourceProject.ProjectName, sourceProject.ProjectCreatedDate, sourceProject.ProjectDueDate, sourceProject.ProjectDescription);
			--OUTPUT $action, 
			--Inserted.ProjectID,
			--Inserted.ProjectName,
			--Inserted.ProjectCreatedDate,
			--Inserted.ProjectDueDate,
			--Inserted.ProjectDescription,
			--deleted.ProjectID,
			--deleted.ProjectName,
			--deleted.ProjectCreatedDate,
			--deleted.ProjectDueDate,
			--deleted.ProjectDescription;


-----------------------------Inset/Update ProjectMember table------------------------------------

		MERGE ProjectMember AS targetProjectMember
		USING (SELECT ProjectID, MemberID FROM @sourcetable) AS sourceProjectMember  
		ON (targetProjectMember.ProjectID=sourceProjectMember.ProjectID)  
		WHEN MATCHED AND targetProjectMember.MemberID<>sourceProjectMember.MemberID 
		THEN
			UPDATE SET  targetProjectMember.MemberID=sourceProjectMember.MemberID 
		WHEN NOT MATCHED  BY TARGET 
		THEN  
			INSERT (ProjectID, MemberID)  
			VALUES (sourceProjectMember.ProjectID, sourceProjectMember.MemberID);
			--OUTPUT $action, 
			--Inserted.ProjectID,
			--deleted.MemberID;

		COMMIT
	END TRY
	BEGIN CATCH 
		SELECT @faildresult=concat(ERROR_NUMBER(), ' ', 
									ERROR_SEVERITY(), ' ',
									ERROR_PROCEDURE(), ' ', 
									ERROR_LINE(), ' ',
									ERROR_MESSAGE())

		ROLLBACK
		END CATCH
END
GO

IF EXISTS (SELECT * FROM sys.objects so join sys.schemas sc on so.schema_id = sc.schema_id WHERE so.type = 'P' AND so.name = 'DeleteRecords' and sc.name=N'dbo')
	DROP PROCEDURE [dbo].[DeleteRecords]
GO

CREATE PROC [dbo].[deleteRecords]
(
	@teamID		BIGINT=NULL,
	@memberID	BIGINT=NULL,
	@projectID	BIGINT=NULL
)
AS
BEGIN
	SET NOCOUNT ON

	--DECLARE @teamID		BIGINT=NULL,
	--DECLARE	@memberID	BIGINT=NULL,
	--DECLARE	@projectID	BIGINT=NULL
	--SET @teamID	=115,
		
	DECLARE @faildresult VARCHAR(MAX)
	
	BEGIN Try
		BEGIN TRANSACTION
			IF (@teamID IS NOT NULL)
			Update  Team SET isDeleted = 1, Modified = GETDATE() WHERE TeamID = @teamID

			IF (@memberID IS NOT NULL)
			BEGIN
				UPDATE MEMBER SET isDeleted = 1, Modified = GETDATE()WHERE MemberID = @memberID
			END

			IF (@projectID IS NOT NULL)
			BEGIN
				UPDATE Project SET isDeleted = 1, Modified = GETDATE() WHERE ProjectID = @projectID
				DELETE FROM ProjectMember WHERE ProjectID = @projectID
			END
		COMMIT
	END TRY
	BEGIN CATCH
		SELECT @faildresult=concat(ERROR_NUMBER(), ' ', 
									ERROR_SEVERITY(), ' ',
									ERROR_PROCEDURE(), ' ', 
									ERROR_LINE(), ' ',
									ERROR_MESSAGE())
		ROLLBACK
	END CATCH
END
GO