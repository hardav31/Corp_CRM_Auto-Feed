
INSERT INTO Team
(TeamID,TeamName)
VALUES
(111,'Team1'),
(112,'Team2'),
(113,'Team3'),
(114,'Team4'),
(115,'Team5'),
(116,'Team4'),
(117,'Team4'),
(118,'Team4'),
(119,'Team4'),
(120,'Team4'),
(121,'Team4')
GO

INSERT INTO Member
(MemberID,MemberName,MemberSurname,TeamID)
VALUES
(1,'Name1','SurName1',111),
(2,'Name2','SurName2',111),
(3,'Name3','SurName3',112),
(4,'Name4','SurName4',113),
(5,'Name5','SurName5',112),
(6,'Name6','SurName5',112),
(7,'Name7','SurName7',112),
(8,'Name8','SurName9',113),
(9,'Name1','SurName8',113),
(10,'Name4','SurName1',114)
GO

INSERT INTO Project
(ProjectID,ProjectName,ProjectCreatedDate,ProjectDueDate,ProjectDescription)
VALUES
(1,'Project1','01/13/2016','12/09/2016','desc1'),
(2,'Project2','03/01/2016','12/02/2016','desc2'),
(3,'Project3','04/01/2016','11/04/2016','desc3'),
(4,'Project4','05/01/2016','07/05/2016','desc4'),
(5,'Project5','06/01/2016','07/23/2016','desc5'),
(6,'Project6','07/01/2016','09/02/2016','desc6'),
(7,'Project7','08/01/2016','09/13/2016','desc6'),
(8,'Project8','09/01/2016','09/17/2016','desc6')
GO

INSERT INTO ProjectMember
VALUES
(1,1),
(1,2),
(1,3),
(1,4),
(1,5),
(2,2),
(2,5),
(2,7),
(2,8),
(3,4),
(3,6),
(4,1),
(4,7),
(5,1),
(5,2),
(6,1),
(7,1),
(7,5),
(7,6),
(7,4),
(8,6),
(8,3),
(8,8),
(9,8),
(9,7),
(10,7),
(10,3)
GO
