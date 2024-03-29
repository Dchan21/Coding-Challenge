USE [master]
GO
/****** Object:  Database [CodingChallenge]    Script Date: 11/17/2019 10:15:33 PM ******/
CREATE DATABASE [CodingChallenge]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CodingChallenge', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLDATABASE\MSSQL\DATA\CodingChallenge.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CodingChallenge_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLDATABASE\MSSQL\DATA\CodingChallenge_log.ldf' , SIZE = 4096KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CodingChallenge] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CodingChallenge].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CodingChallenge] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CodingChallenge] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CodingChallenge] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CodingChallenge] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CodingChallenge] SET ARITHABORT OFF 
GO
ALTER DATABASE [CodingChallenge] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CodingChallenge] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CodingChallenge] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CodingChallenge] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CodingChallenge] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CodingChallenge] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CodingChallenge] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CodingChallenge] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CodingChallenge] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CodingChallenge] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CodingChallenge] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CodingChallenge] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CodingChallenge] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CodingChallenge] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CodingChallenge] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CodingChallenge] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CodingChallenge] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CodingChallenge] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CodingChallenge] SET  MULTI_USER 
GO
ALTER DATABASE [CodingChallenge] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CodingChallenge] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CodingChallenge] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CodingChallenge] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CodingChallenge] SET DELAYED_DURABILITY = DISABLED 
GO
USE [CodingChallenge]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 11/17/2019 10:15:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[Id] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[Credits] [int] NOT NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 11/17/2019 10:15:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserProject]    Script Date: 11/17/2019 10:15:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProject](
	[UserId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[AssignedDate] [datetime] NOT NULL
) ON [PRIMARY]

GO
INSERT [dbo].[Project] ([Id], [StartDate], [EndDate], [Credits]) VALUES (1, CAST(N'2019-08-08 00:00:00.000' AS DateTime), CAST(N'2019-12-12 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Project] ([Id], [StartDate], [EndDate], [Credits]) VALUES (2, CAST(N'2019-07-06 00:00:00.000' AS DateTime), CAST(N'2019-11-10 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Project] ([Id], [StartDate], [EndDate], [Credits]) VALUES (3, CAST(N'2019-09-21 00:00:00.000' AS DateTime), CAST(N'2019-11-20 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Project] ([Id], [StartDate], [EndDate], [Credits]) VALUES (4, CAST(N'2019-05-06 00:00:00.000' AS DateTime), CAST(N'2019-10-05 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Project] ([Id], [StartDate], [EndDate], [Credits]) VALUES (5, CAST(N'2019-11-30 00:00:00.000' AS DateTime), CAST(N'2020-02-15 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[User] ([Id], [FirstName], [LastName]) VALUES (1, N'John', N'Doe')
INSERT [dbo].[User] ([Id], [FirstName], [LastName]) VALUES (2, N'Kevin', N'Simpson')
INSERT [dbo].[User] ([Id], [FirstName], [LastName]) VALUES (3, N'Terry', N'Brown')
INSERT [dbo].[UserProject] ([UserId], [ProjectId], [IsActive], [AssignedDate]) VALUES (1, 2, 1, CAST(N'2019-07-05 00:00:00.000' AS DateTime))
INSERT [dbo].[UserProject] ([UserId], [ProjectId], [IsActive], [AssignedDate]) VALUES (2, 5, 0, CAST(N'2019-11-16 00:00:00.000' AS DateTime))
INSERT [dbo].[UserProject] ([UserId], [ProjectId], [IsActive], [AssignedDate]) VALUES (3, 2, 1, CAST(N'2019-07-10 00:00:00.000' AS DateTime))
INSERT [dbo].[UserProject] ([UserId], [ProjectId], [IsActive], [AssignedDate]) VALUES (1, 1, 1, CAST(N'2019-08-08 00:00:00.000' AS DateTime))
INSERT [dbo].[UserProject] ([UserId], [ProjectId], [IsActive], [AssignedDate]) VALUES (1, 3, 1, CAST(N'2019-09-27 00:00:00.000' AS DateTime))
INSERT [dbo].[UserProject] ([UserId], [ProjectId], [IsActive], [AssignedDate]) VALUES (1, 4, 1, CAST(N'2019-05-10 00:00:00.000' AS DateTime))
INSERT [dbo].[UserProject] ([UserId], [ProjectId], [IsActive], [AssignedDate]) VALUES (1, 5, 0, CAST(N'2019-11-15 00:00:00.000' AS DateTime))
INSERT [dbo].[UserProject] ([UserId], [ProjectId], [IsActive], [AssignedDate]) VALUES (3, 5, 0, CAST(N'2019-11-20 00:00:00.000' AS DateTime))
ALTER TABLE [dbo].[UserProject]  WITH CHECK ADD  CONSTRAINT [FK_UserProject_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[UserProject] CHECK CONSTRAINT [FK_UserProject_Project]
GO
ALTER TABLE [dbo].[UserProject]  WITH CHECK ADD  CONSTRAINT [FK_UserProject_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserProject] CHECK CONSTRAINT [FK_UserProject_User]
GO
USE [master]
GO
ALTER DATABASE [CodingChallenge] SET  READ_WRITE 
GO
