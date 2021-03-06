USE [master]
GO
/****** Object:  Database [ThinkBridge]    Script Date: 18-03-2021 15:33:40 ******/
CREATE DATABASE [ThinkBridge]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ThinkBridge', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER2017\MSSQL\DATA\ThinkBridge.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ThinkBridge_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER2017\MSSQL\DATA\ThinkBridge_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ThinkBridge] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ThinkBridge].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ThinkBridge] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ThinkBridge] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ThinkBridge] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ThinkBridge] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ThinkBridge] SET ARITHABORT OFF 
GO
ALTER DATABASE [ThinkBridge] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ThinkBridge] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ThinkBridge] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ThinkBridge] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ThinkBridge] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ThinkBridge] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ThinkBridge] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ThinkBridge] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ThinkBridge] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ThinkBridge] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ThinkBridge] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ThinkBridge] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ThinkBridge] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ThinkBridge] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ThinkBridge] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ThinkBridge] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ThinkBridge] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ThinkBridge] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ThinkBridge] SET  MULTI_USER 
GO
ALTER DATABASE [ThinkBridge] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ThinkBridge] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ThinkBridge] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ThinkBridge] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ThinkBridge] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ThinkBridge] SET QUERY_STORE = OFF
GO
USE [ThinkBridge]
GO
/****** Object:  Table [dbo].[Inventory]    Script Date: 18-03-2021 15:33:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Price] [float] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Inventory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Inventory] ADD  CONSTRAINT [DF_Inventory_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  StoredProcedure [dbo].[DeleteInventoryById]    Script Date: 18-03-2021 15:33:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteInventoryById] 
@Id int
	as
BEGIN
delete from Inventory where id= @Id
END
GO
/****** Object:  StoredProcedure [dbo].[GetInventory]    Script Date: 18-03-2021 15:33:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetInventory] 

	as
BEGIN
select * from Inventory
END
GO
/****** Object:  StoredProcedure [dbo].[GetInventoryById]    Script Date: 18-03-2021 15:33:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetInventoryById] 
@Id int
	as
BEGIN
select * from Inventory where id= @Id
END
GO
/****** Object:  StoredProcedure [dbo].[InsertInventory]    Script Date: 18-03-2021 15:33:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertInventory] 
	@Name nvarchar(50),
	@Description nvarchar(50),
	@Price float
	as
BEGIN

	 insert into Inventory(Name,Description,Price)values (@Name,@Description,@Price)
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateInventory]    Script Date: 18-03-2021 15:33:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateInventory] 
@Id int,
	@Name nvarchar(50),
	@Description nvarchar(50),
	@Price float
	as
BEGIN

	 update Inventory set Name =@Name,Description=@Description,Price =@Price where id=@Id
END
GO
USE [master]
GO
ALTER DATABASE [ThinkBridge] SET  READ_WRITE 
GO
