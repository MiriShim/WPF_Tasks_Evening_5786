USE [master]
GO
/****** Object:  Database [Pesach_Tasks_DB]    Script Date: 15/03/2026 16:22:17 ******/
CREATE DATABASE [Pesach_Tasks_DB]
 GO
CREATE TABLE [dbo].[People](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[Email] [varchar](255) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[UserPassword] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 15/03/2026 16:22:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasks](
	[TaskId] [int] IDENTITY(1,1) NOT NULL,
	[Header] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](1000) NULL,
	[EstimatedHours] [int] NULL,
	[ParentTaskId] [int] NULL,
	[PersonId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[TaskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[People] ON 
GO
INSERT [dbo].[People] ([PersonId], [FirstName], [LastName], [Email], [DateOfBirth], [UserPassword]) VALUES (1, N'שרה', N'לוינסון', N'sara_lein@gmail.com', CAST(N'1977-01-29' AS Date), N'1234')
GO
SET IDENTITY_INSERT [dbo].[People] OFF
GO
SET IDENTITY_INSERT [dbo].[Tasks] ON 
GO
INSERT [dbo].[Tasks] ([TaskId], [Header], [Description], [EstimatedHours], [ParentTaskId], [PersonId]) VALUES (1, N'חדר ילדים כשר לפסח', NULL, 15, NULL, 1)
GO
INSERT [dbo].[Tasks] ([TaskId], [Header], [Description], [EstimatedHours], [ParentTaskId], [PersonId]) VALUES (2, N'ארונית צעצועים', N'לכבס צעצועים מבד, להשרות בנוזל ניקוי צעצועי פלסטיק', 4, 1, NULL)
GO
INSERT [dbo].[Tasks] ([TaskId], [Header], [Description], [EstimatedHours], [ParentTaskId], [PersonId]) VALUES (3, N'ארון בגדים', NULL, 3, 1, NULL)
GO
INSERT [dbo].[Tasks] ([TaskId], [Header], [Description], [EstimatedHours], [ParentTaskId], [PersonId]) VALUES (4, N'מטבח', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Tasks] ([TaskId], [Header], [Description], [EstimatedHours], [ParentTaskId], [PersonId]) VALUES (5, N'מקרר', NULL, NULL, 4, NULL)
GO
INSERT [dbo].[Tasks] ([TaskId], [Header], [Description], [EstimatedHours], [ParentTaskId], [PersonId]) VALUES (6, N'תנור וכיריים', NULL, NULL, 4, NULL)
GO
INSERT [dbo].[Tasks] ([TaskId], [Header], [Description], [EstimatedHours], [ParentTaskId], [PersonId]) VALUES (7, N'תבניות של התנור', NULL, NULL, 6, NULL)
GO
INSERT [dbo].[Tasks] ([TaskId], [Header], [Description], [EstimatedHours], [ParentTaskId], [PersonId]) VALUES (8, N'חצובות', NULL, NULL, 9, NULL)
GO
INSERT [dbo].[Tasks] ([TaskId], [Header], [Description], [EstimatedHours], [ParentTaskId], [PersonId]) VALUES (9, N'כיריים', NULL, NULL, 6, NULL)
GO
SET IDENTITY_INSERT [dbo].[Tasks] OFF
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD FOREIGN KEY([ParentTaskId])
REFERENCES [dbo].[Tasks] ([TaskId])
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD FOREIGN KEY([PersonId])
REFERENCES [dbo].[People] ([PersonId])
GO
USE [master]
GO
ALTER DATABASE [Pesach_Tasks_DB] SET  READ_WRITE 
GO
