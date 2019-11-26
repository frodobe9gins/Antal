USE [master]
GO

/****** Object:  Database [TestAntal]    Script Date: 26.11.2019 10:41:36 ******/
CREATE DATABASE [TestAntal]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TestAntal', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\TestAntal.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TestAntal_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\TestAntal_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
USE [TestAntal]
GO

CREATE TABLE [dbo].[Article](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Theme] [nvarchar](255) NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Article] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[Tags](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Tags_Article](
	[Id_Article] [int] NOT NULL,
	[Id_Theme] [int] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Tags_Article]  WITH CHECK ADD  CONSTRAINT [FK_Tags_Article_Article] FOREIGN KEY([Id_Article])
REFERENCES [dbo].[Article] ([Id])
GO

ALTER TABLE [dbo].[Tags_Article] CHECK CONSTRAINT [FK_Tags_Article_Article]
GO

ALTER TABLE [dbo].[Tags_Article]  WITH CHECK ADD  CONSTRAINT [FK_Tags_Article_Tags] FOREIGN KEY([Id_Theme])
REFERENCES [dbo].[Tags] ([Id])
GO

ALTER TABLE [dbo].[Tags_Article] CHECK CONSTRAINT [FK_Tags_Article_Tags]
GO


INSERT INTO [dbo].[Article] ([Theme],[Text]) VALUES ('theme1' ,'text1')
INSERT INTO [dbo].[Article] ([Theme],[Text]) VALUES ('theme2' ,'text2')
INSERT INTO [dbo].[Article] ([Theme],[Text]) VALUES ('theme3' ,'text3')
INSERT INTO [dbo].[Tags] ([Name]) VALUES ('tag1')
INSERT INTO [dbo].[Tags] ([Name]) VALUES ('tag2')
INSERT INTO [dbo].[Tags] ([Name]) VALUES ('tag3')
INSERT INTO [dbo].[Tags_Article] ([Id_Article] ,[Id_Theme]) VALUES (1,1)
INSERT INTO [dbo].[Tags_Article] ([Id_Article] ,[Id_Theme]) VALUES (1,2)
INSERT INTO [dbo].[Tags_Article] ([Id_Article] ,[Id_Theme]) VALUES (3,1)
INSERT INTO [dbo].[Tags_Article] ([Id_Article] ,[Id_Theme]) VALUES (3,3)


select a.Theme,isnull(t.[Name],'#notag') from [Article] a 
left join Tags_Article ta on ta.Id_Article=a.Id
left join Tags t on t.Id=ta.Id_Theme