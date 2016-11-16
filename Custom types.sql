
CREATE TYPE Source AS TABLE
(
  MemberID BIGINT NOT NULL ,
  MemberName nvarchar(50) NOT NULL,
  MemberSurname nvarchar(50) NOT NULL,
  TeamID BIGINT NOT NULL,
  TeamName nvarchar(50) NOT NULL,
  ProjectID bigint NOT NULL ,
  ProjectName nvarchar(50)  NULL,
  ProjectCreatedDate date NOT NULL,
  ProjectDueDate date NOT NULL,
  ProjectDescription nvarchar(50) NOT NULL
);
GO