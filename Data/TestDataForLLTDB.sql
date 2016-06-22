-- Players

INSERT INTO [LLTPlayer]
           ([FirstName],[LastName],[MiddleName],[DateOfBirth],[City],[ForehandRight],[Gender],[Height],[Weight],[Deleted], [PlayFrom], [Level])
     VALUES
           (N'�����',N'���������',N'','1990-01-01',N'�����',1,0,200,100,0, '2000-01-01', 2)
GO


INSERT INTO [LLTPlayer]
           ([FirstName],[LastName],[MiddleName],[DateOfBirth],[City],[ForehandRight],[Gender],[Height],[Weight],[Deleted], [PlayFrom], [Level])
     VALUES
           (N'�������',N'��������',N'','1990-01-01',N'�����',1,0,190,85,0, '2000-01-01', 1)
GO

-- Tournaments

INSERT INTO [LLTTournament]
           ([Name],[StartDate],[EndDate],[Type],[Rates],[Deleted])
     VALUES
           (N'Challenger 1',GETDATE() + 10,GETDATE() + 20,2,'',0)
GO

-- Addresses

INSERT INTO [LLTAddress]
           ([Country],[City],[Line1],[Line2],[ZipCode],[Phone],[Deleted])
     VALUES
           (N'��������',N'�����',N'',N'','220000','+375 17 123 45 67',0)
GO

-- Tennis Clubs

INSERT INTO [LLTTennisClub]
           ([Name],[Email],[Description],[Courts],[Deleted],[Address_Id])
     VALUES
           (N'�����','email@tut.by',N'����� �����',10,0,1)
GO


-- Tournament Clubs

INSERT INTO [LLTTournamentClubs]
           ([Club_Id],[Tournament_Id])
     VALUES
           (1,1)
GO