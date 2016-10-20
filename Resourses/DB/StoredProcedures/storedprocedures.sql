IF EXISTS (SELECT * FROM sys.objects so join sys.schemas sc on so.schema_id = sc.schema_id WHERE so.type = 'P' AND so.name = 'getProjectMemberTeam' and sc.name=N'dbo')
	DROP PROCEDURE [dbo].[getProjectMemberTeam]
GO
CREATE PROCEDURE dbo.getProjectMemberTeam
(
	@condition nvarchar(255)
)
AS
BEGIN
	SET NOCOUNT ON
	--DECLARE @condition NVARCHAR(255)
	--SET @condition='Project.ProjectName Like N''%Project1%'''
	
	DECLARE @sql Nvarchar(MAX)
	SET @sql='SELECT Member.MemberName, Member.MemberSurname,Team.TeamName,Project.ProjectName,Project.ProjectCreatedDate,Project.ProjectDueDate,Project.ProjectDescription FROM 
	Member INNER JOIN Team ON Member.TeamID=Team.TeamID
    INNER JOIN ProjectMember ON Member.MemberID=ProjectMember.MemberID
    INNER JOIN Project ON Project.ProjectID=ProjectMember.ProjectID'
	
	IF (@condition<>'' AND @condition IS NOT NULL)
		SET @sql=concat(@sql, ' where ', @condition)
	
	EXECUTE sp_executesql  @sql
END
GO

--exec dbo.getProjectMemberTeam @condition='Project.ProjectName Like N''%Project1%'''