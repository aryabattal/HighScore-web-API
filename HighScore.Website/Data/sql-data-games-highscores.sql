USE [Highscore1]
GO
SET IDENTITY_INSERT [dbo].[Games] ON 

INSERT [dbo].[Games] ([GameId], [Name], [Description], [Genre], [RealseYear], [ImageUrl]) VALUES (1, 'Tetris', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.','Puzzle',1984, 'https://www.heilpraxisnet.de/wp-content/uploads/2017/03/Tetris-PTSD-1024x1024.jpg')
INSERT [dbo].[Games] ([GameId], [Name], [Description], [Genre], [RealseYear], [ImageUrl]) VALUES (2, 'Pacman', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.','Maze', 1980,'https://www.wakondatech.com/wp-content/uploads/2015/06/pacman.jpg')
INSERT [dbo].[Games] ([GameId], [Name], [Description], [Genre], [RealseYear],  [ImageUrl]) VALUES (3, 'Asteroids', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.','	Multidirectional shooter', 1979,'https://image.winudf.com/v1/image/Y29tLmdyZXlvbGx0d2l0LmFzdGVyb2lkc19zY3JlZW5zaG90c180X2FmMDQ5MjM4/screen-3=x800.jpg')
INSERT [dbo].[Games] ([GameId], [Name], [Description], [Genre], [RealseYear],  [ImageUrl]) VALUES (4, 'Donkey Kong', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.','Platform',1981 , 'https://images2.minutemediacdn.com/image/upload/c_fill,g_auto,h_1248,w_2220/v1555440536/shape/mentalfloss/why-is-this-game-named-after-the-villain.png?itok=AV1LjYPG')

SET IDENTITY_INSERT [dbo].[Games] OFF
Go
SET IDENTITY_INSERT [dbo].[HighScores] ON
INSERT [dbo].[HighScores] ([HighscoreId], [PlayerName], [Date], [Score], [GameId]) VALUES (1, 'John Doe', '2020-01-01', 78900, 1)
INSERT [dbo].[HighScores] ([HighscoreId], [PlayerName], [Date], [Score], [GameId]) VALUES (2, 'John Doe', '2021-02-03', 1000, 2)
INSERT [dbo].[HighScores] ([HighscoreId], [PlayerName], [Date], [Score], [GameId]) VALUES (3, 'John Doe', '2020-01-01', 70021, 3)
INSERT [dbo].[HighScores] ([HighscoreId], [PlayerName], [Date], [Score], [GameId]) VALUES (4, 'John Doe', '2021-02-03', 30020, 4)

INSERT [dbo].[HighScores] ([HighscoreId], [PlayerName], [Date], [Score], [GameId]) VALUES (5, 'Jane Doe', '2020-01-01', 6500, 1)
INSERT [dbo].[HighScores] ([HighscoreId], [PlayerName], [Date], [Score], [GameId]) VALUES (6, 'Jane Doe', '2021-03-01', 1032654,2)
INSERT [dbo].[HighScores] ([HighscoreId], [PlayerName], [Date], [Score], [GameId]) VALUES (7, 'Jane Doe', '2020-01-01', 12654, 3)
INSERT [dbo].[HighScores] ([HighscoreId], [PlayerName], [Date], [Score], [GameId]) VALUES (8, 'Jane Doe', '2021-03-01', 119000, 4)

INSERT [dbo].[HighScores] ([HighscoreId], [PlayerName], [Date], [Score], [GameId]) VALUES (9, 'Jim Doe', '2020-01-01', 20322, 1)
INSERT [dbo].[HighScores] ([HighscoreId], [PlayerName], [Date], [Score], [GameId]) VALUES (10, 'Jim Doe', '2021-02-01', 89628, 2)
INSERT [dbo].[HighScores] ([HighscoreId], [PlayerName], [Date], [Score], [GameId]) VALUES (11, 'Jim Doe', '2020-01-01', 89668, 3)
INSERT [dbo].[HighScores] ([HighscoreId], [PlayerName], [Date], [Score], [GameId]) VALUES (12, 'Jim Doe', '2021-02-01', 229000, 4)

INSERT [dbo].[HighScores] ([HighscoreId], [PlayerName], [Date], [Score], [GameId]) VALUES (13, 'Jessica Doe', '2020-01-01', 1200,1)
INSERT [dbo].[HighScores] ([HighscoreId], [PlayerName], [Date], [Score], [GameId]) VALUES (14, 'Jessica Doe', '2021-04-01', 7300, 2)
INSERT [dbo].[HighScores] ([HighscoreId], [PlayerName], [Date], [Score], [GameId]) VALUES (15, 'Jessica Doe', '2020-01-01', 7800, 3)
INSERT [dbo].[HighScores] ([HighscoreId], [PlayerName], [Date], [Score], [GameId]) VALUES (16, 'Jessica Doe', '2021-04-01', 256352, 4)
SET IDENTITY_INSERT [dbo].[HighScores] ON
GO
