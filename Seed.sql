USE [master]
GO
ALTER DATABASE [StoreDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StoreDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StoreDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StoreDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StoreDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StoreDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StoreDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [StoreDb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [StoreDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StoreDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StoreDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StoreDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StoreDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StoreDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StoreDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StoreDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StoreDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [StoreDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StoreDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StoreDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StoreDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StoreDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StoreDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StoreDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StoreDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StoreDb] SET  MULTI_USER 
GO
ALTER DATABASE [StoreDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StoreDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StoreDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StoreDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [StoreDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [StoreDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [StoreDb] SET QUERY_STORE = OFF
GO
USE [StoreDb]

SET IDENTITY_INSERT [dbo].[Addresses] ON 

INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (2, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (3, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (4, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (5, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (6, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (7, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (8, NULL, NULL, NULL, 0, N'dsf', N'dsf', N'dfssdf', N'dfsdf', N'dsf', N'fd', N'sdf', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (9, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (10, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (11, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (12, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (13, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (14, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (15, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (17, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (18, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (19, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (20, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (21, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (22, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (23, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (24, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (25, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (26, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (27, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (28, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (29, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (30, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (31, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (32, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (33, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (34, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (35, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (36, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (37, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (38, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (39, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (40, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (41, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (42, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (43, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (44, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (45, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (46, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (47, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (48, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (49, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (50, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (51, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (52, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (53, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (54, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (55, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (56, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (57, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (58, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (59, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (60, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (61, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (62, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (63, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (64, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (65, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1065, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1066, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1067, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1068, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1069, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'3500', N'Chattogram', N'Cumilla', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1070, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1071, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1072, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1073, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1074, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1075, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1076, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1077, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1078, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1079, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1080, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1081, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1082, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1083, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1084, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1085, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1086, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1087, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1088, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1089, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1090, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1091, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1092, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1093, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1094, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1095, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1096, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1097, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1098, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1099, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1100, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1101, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1102, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1103, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1104, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1105, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1106, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1107, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1108, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1109, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1110, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1111, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1112, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1113, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1114, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1115, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1116, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1117, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1118, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1119, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1120, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1121, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1122, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1123, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1124, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1125, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1126, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1127, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1128, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1129, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1130, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1131, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1132, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1133, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1134, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1135, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1136, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1137, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1138, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1139, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1140, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1141, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1142, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1143, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1144, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1145, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1146, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1147, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1148, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1149, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1150, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1151, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1152, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1153, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1154, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1155, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1156, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1157, NULL, NULL, NULL, 0, N'12/6 Outer Circular Road, New Eskaton', N'Banglamotor, Ramna', N'+6156656515', NULL, N'1217', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1158, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1159, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1160, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1161, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1162, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1163, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1164, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1165, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1166, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1167, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1168, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1169, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1170, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1171, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1172, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1173, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1174, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1175, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1176, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1177, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1178, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1179, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1180, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1181, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1182, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1183, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1184, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1185, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1186, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1187, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1188, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1189, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1190, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1191, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1192, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1193, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1194, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1195, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1196, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1197, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1198, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1199, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1200, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1201, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1202, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1203, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1204, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1205, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1206, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1207, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1208, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1209, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1210, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1211, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1212, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1213, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1214, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1215, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1216, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1217, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1218, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1219, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1220, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1221, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1222, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1223, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1224, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1225, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1226, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1227, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1228, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1229, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1230, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1231, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1232, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1233, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1234, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1235, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1236, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1237, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1238, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1239, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1240, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1241, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1242, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1243, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1244, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1245, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1246, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1247, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1248, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1249, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'1360', N'Dhaka', N'Dhaka', NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1250, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1251, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1252, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1253, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Addresses] ([Id], [FirstName], [LastName], [CustomerId], [AddressType], [AddressLineOne], [AddressLineTwo], [Mobile], [AltMobile], [Zip], [State], [City], [Country]) VALUES (1254, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Addresses] OFF
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'5d51305b-79a1-42cd-a27a-8b10815e258f', N'Admin', N'ADMIN', N'4d399c32-92f6-4c39-89d9-56a78607c4bf')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b82992cf-004f-464a-809d-3643385257c5', N'5d51305b-79a1-42cd-a27a-8b10815e258f')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Discriminator], [FirstName], [LastName], [Gender], [ProfilePicLink], [BirthDate], [IdCardNo], [IdCardType], [IdCardVerifyPic], [IsVerified], [CreatedOn], [ModifiedOn], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'09aacb03-6adf-40ca-b9cd-85afc458b1ee', N'Customer', N'Jim', N'Doe', NULL, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'tanvir.mbstucs@gmail.com', N'TANVIR.MBSTUCS@GMAIL.COM', N'tanvir.mbstucs@gmail.com', N'TANVIR.MBSTUCS@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEN+FMOCdGaZ1XVcrPJvuGQTPqm8lU7WCeXT/lH/NH3YbPRGyHIbaTnINnJkN+st+Xw==', N'ICGQ66C3MZURTUQDGDBZSIFHW4QIQCOJ', N'f17cf0bb-baae-4c66-9d68-b8897969ec3c', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Discriminator], [FirstName], [LastName], [Gender], [ProfilePicLink], [BirthDate], [IdCardNo], [IdCardType], [IdCardVerifyPic], [IsVerified], [CreatedOn], [ModifiedOn], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'5288c36f-8aa1-4a06-b3e0-bb5b9cd1e1b1', N'Customer', N'Tanvir', N'Ahmed', NULL, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'shantgrylls@gmail.com', N'SHANTGRYLLS@GMAIL.COM', N'shantgrylls@gmail.com', N'SHANTGRYLLS@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEDUVt/Hw+J9LOj+LnkXFhLx4K1O5mtbi0wXlXHSOliQw/jMQVwSjY0zSOpWKmMxGag==', N'YCJV23TSZ7F5PZ56HJYXQYIQHURQBWOX', N'0e5b9d11-e6e6-4703-95a4-4b4979068682', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Discriminator], [FirstName], [LastName], [Gender], [ProfilePicLink], [BirthDate], [IdCardNo], [IdCardType], [IdCardVerifyPic], [IsVerified], [CreatedOn], [ModifiedOn], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'62a36308-06c5-40c0-82a0-3e7c37eb3709', N'Customer', N'Rickybailk', N'RickybailkPD', NULL, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'k.a.e.emccoy1.99.7@gmail.com', N'K.A.E.EMCCOY1.99.7@GMAIL.COM', N'k.a.e.emccoy1.99.7@gmail.com', N'K.A.E.EMCCOY1.99.7@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEL/uPj4PYzW+5eSudmX2Zveq39kIqujS7kGPb7AFgI3zVbb+Csgik4UAKpdqg31sIg==', N'IIGX2LOI26DFPTVSIL7A5CCJ4WFR5DCB', N'a3cde4eb-768a-4fe2-9cc1-1afab41e23fb', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Discriminator], [FirstName], [LastName], [Gender], [ProfilePicLink], [BirthDate], [IdCardNo], [IdCardType], [IdCardVerifyPic], [IsVerified], [CreatedOn], [ModifiedOn], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'7c0b912a-349f-4d00-8186-40b7b1ddd263', N'Customer', N'Md Mafiz', N'Sarker', NULL, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'kkll.kl251@gmail.com', N'KKLL.KL251@GMAIL.COM', N'kkll.kl251@gmail.com', N'KKLL.KL251@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEER4TGN5VInRX2HJZoT5Vy6gXdEmfob+Hg7zISJz0yxzcc8UqgyrqV/697Po+cAsRw==', N'DUJGOQSIUL5FQHYUNPFFAYLOJBINVNZY', N'53765a2b-9034-42ae-86aa-5e1c83a90502', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Discriminator], [FirstName], [LastName], [Gender], [ProfilePicLink], [BirthDate], [IdCardNo], [IdCardType], [IdCardVerifyPic], [IsVerified], [CreatedOn], [ModifiedOn], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'b82992cf-004f-464a-809d-3643385257c5', N'Customer', NULL, NULL, NULL, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'tanvir14012@gmail.com', N'TANVIR14012@GMAIL.COM', N'tanvir14012@gmail.com', N'TANVIR14012@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEJtuwWuhYpiKVYwR/p3EKoPtrQFgsr3zNrtoOxS178BG0jCddsKWNVdeuw3MQdhkWQ==', N'2DFOVBVXTRAL4YHWBZDD4B5JSQHBMKID', N'872972c9-9b0b-427e-9b19-5e895badee7a', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[CarouselJoinCarouselImages] ON 

INSERT [dbo].[CarouselJoinCarouselImages] ([Id], [ImageUrl], [CreatedOn], [LastModifiedOn], [CarouselId]) VALUES (1, N'ImageResources\Carousel\f0c55779-ad47-407b-888c-a92beb704f14.jpg', CAST(N'2020-10-08T13:10:14.0000000' AS DateTime2), CAST(N'2020-10-08T14:21:58.3982958' AS DateTime2), 1)
INSERT [dbo].[CarouselJoinCarouselImages] ([Id], [ImageUrl], [CreatedOn], [LastModifiedOn], [CarouselId]) VALUES (4, N'ImageResources\Carousel\88c1fa68-7109-4788-91cf-cff00451bda7.jpg', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2020-10-08T14:21:58.3984779' AS DateTime2), 1)
INSERT [dbo].[CarouselJoinCarouselImages] ([Id], [ImageUrl], [CreatedOn], [LastModifiedOn], [CarouselId]) VALUES (5, N'ImageResources\Carousel\cd5ca066-8cae-4e5b-8b36-acd6a47f745b.jpg', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2020-10-08T14:21:58.3984788' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[CarouselJoinCarouselImages] OFF
GO
SET IDENTITY_INSERT [dbo].[Carousels] ON 

INSERT [dbo].[Carousels] ([Id], [Name], [Rank], [CreatedOn], [LastModifiedOn]) VALUES (1, N'Gift Cards', 1, CAST(N'2020-10-08T13:10:14.0000000' AS DateTime2), CAST(N'2020-10-08T14:21:58.3984793' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Carousels] OFF
GO
SET IDENTITY_INSERT [dbo].[CartItems] ON 

INSERT [dbo].[CartItems] ([Id], [CartId], [ProductItemId], [Quantity]) VALUES (54, 156, 1, 4)
INSERT [dbo].[CartItems] ([Id], [CartId], [ProductItemId], [Quantity]) VALUES (55, 156, 15, 1)
INSERT [dbo].[CartItems] ([Id], [CartId], [ProductItemId], [Quantity]) VALUES (56, 156, 14, 2)
INSERT [dbo].[CartItems] ([Id], [CartId], [ProductItemId], [Quantity]) VALUES (57, 156, 16, 1)
INSERT [dbo].[CartItems] ([Id], [CartId], [ProductItemId], [Quantity]) VALUES (58, 156, 5, 1)
SET IDENTITY_INSERT [dbo].[CartItems] OFF
GO
SET IDENTITY_INSERT [dbo].[Carts] ON 

INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (156, N'b0054e38-ecf0-4868-9aff-8fe81ad12ab6', CAST(N'2021-05-28T17:32:13.7056624' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (215, N'25ff8e30-85aa-41c3-ab6d-b642501ce65e', CAST(N'2021-12-31T09:16:36.3599525' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (254, N'09aacb03-6adf-40ca-b9cd-85afc458b1ee', CAST(N'2022-01-12T14:09:44.2918548' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (265, NULL, CAST(N'2022-01-19T23:09:08.4563949' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (266, NULL, CAST(N'2022-01-20T21:03:13.8119431' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (267, NULL, CAST(N'2022-01-20T21:29:17.9348873' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (268, NULL, CAST(N'2022-01-21T09:26:06.3122480' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (269, NULL, CAST(N'2022-01-22T00:50:57.7618599' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (270, NULL, CAST(N'2022-01-22T08:42:49.0925230' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (271, NULL, CAST(N'2022-01-23T04:46:59.9981541' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (272, NULL, CAST(N'2022-01-23T05:05:48.6825351' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (273, NULL, CAST(N'2022-01-23T18:07:11.7771945' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (274, NULL, CAST(N'2022-01-24T02:42:50.0280985' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (276, NULL, CAST(N'2022-01-27T00:36:28.1979224' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (277, NULL, CAST(N'2022-01-27T03:14:34.7082614' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (279, NULL, CAST(N'2022-01-27T08:22:10.0982854' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (280, NULL, CAST(N'2022-01-27T20:39:54.9365775' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (281, NULL, CAST(N'2022-01-28T00:53:24.5427313' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (282, NULL, CAST(N'2022-01-28T01:55:31.4741900' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (283, NULL, CAST(N'2022-01-28T03:58:46.5736369' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (284, NULL, CAST(N'2022-01-29T22:46:08.7895966' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (285, NULL, CAST(N'2022-01-30T07:33:23.3613421' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (286, NULL, CAST(N'2022-02-01T10:42:07.0040483' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (287, NULL, CAST(N'2022-02-01T12:37:06.9942662' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (288, NULL, CAST(N'2022-02-01T23:29:33.5679766' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (289, NULL, CAST(N'2022-02-02T13:27:12.5002833' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (291, NULL, CAST(N'2022-02-05T00:27:07.9581892' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (292, NULL, CAST(N'2022-02-06T01:57:40.4845777' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (293, NULL, CAST(N'2022-02-08T14:25:13.0120009' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (294, NULL, CAST(N'2022-02-09T15:16:17.1886344' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (295, NULL, CAST(N'2022-02-10T02:21:52.2059146' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (296, NULL, CAST(N'2022-02-10T06:52:58.1087694' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (297, NULL, CAST(N'2022-02-10T09:25:00.5630606' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (298, NULL, CAST(N'2022-02-11T12:38:17.0074868' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (299, NULL, CAST(N'2022-02-12T08:59:44.2111464' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (300, NULL, CAST(N'2022-02-13T01:07:11.8668289' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (301, NULL, CAST(N'2022-02-14T22:31:40.7017253' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (302, NULL, CAST(N'2022-02-16T02:07:15.8841111' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (303, NULL, CAST(N'2022-02-16T12:02:38.4577752' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (304, NULL, CAST(N'2022-02-16T16:16:52.4381184' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (305, NULL, CAST(N'2022-02-17T02:04:42.3013030' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (306, NULL, CAST(N'2022-02-17T02:06:05.2691875' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (307, NULL, CAST(N'2022-02-19T15:58:08.4868619' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (308, NULL, CAST(N'2022-02-20T02:17:31.0680309' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (309, NULL, CAST(N'2022-02-20T04:26:09.7406658' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (310, NULL, CAST(N'2022-02-20T11:37:08.4665603' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (311, NULL, CAST(N'2022-02-20T21:25:49.1639290' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (312, N'62a36308-06c5-40c0-82a0-3e7c37eb3709', CAST(N'2022-02-22T02:00:29.9334117' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (313, NULL, CAST(N'2022-02-23T01:36:09.5065321' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (314, NULL, CAST(N'2022-02-23T04:17:16.3445981' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (315, NULL, CAST(N'2022-02-24T01:07:25.6974542' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (316, NULL, CAST(N'2022-02-24T03:32:41.6058626' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (317, NULL, CAST(N'2022-02-28T03:58:54.6305202' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (318, NULL, CAST(N'2022-03-02T06:16:52.5667338' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (319, NULL, CAST(N'2022-03-03T22:21:47.5893257' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (320, NULL, CAST(N'2022-03-04T02:28:37.4475990' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (321, NULL, CAST(N'2022-03-05T21:21:31.9340987' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (322, NULL, CAST(N'2022-03-10T00:03:35.1863149' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (323, NULL, CAST(N'2022-03-10T16:13:39.8583916' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (324, NULL, CAST(N'2022-03-11T04:02:42.8796489' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (325, NULL, CAST(N'2022-03-11T09:40:08.6037390' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (326, NULL, CAST(N'2022-03-11T19:45:40.4549538' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (327, NULL, CAST(N'2022-03-13T06:30:08.3123695' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (328, NULL, CAST(N'2022-03-14T03:32:03.3849514' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (329, NULL, CAST(N'2022-03-15T02:04:57.4827572' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (330, NULL, CAST(N'2022-03-15T05:52:28.8019014' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (331, NULL, CAST(N'2022-03-15T13:13:37.9026088' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (332, NULL, CAST(N'2022-03-15T13:16:05.8319518' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (333, NULL, CAST(N'2022-03-15T13:17:40.1262847' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (334, NULL, CAST(N'2022-03-16T01:56:03.2395436' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (335, NULL, CAST(N'2022-03-16T14:11:54.7448078' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (336, NULL, CAST(N'2022-03-16T23:23:08.1580347' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (337, NULL, CAST(N'2022-03-17T01:33:13.6676629' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (338, NULL, CAST(N'2022-03-20T04:10:06.3909162' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (339, NULL, CAST(N'2022-03-20T14:55:07.0478719' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (340, NULL, CAST(N'2022-03-22T01:10:51.4363391' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (341, NULL, CAST(N'2022-03-22T01:13:12.3510490' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (342, NULL, CAST(N'2022-03-22T01:14:41.4256068' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (343, NULL, CAST(N'2022-03-23T07:25:05.7497350' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (344, NULL, CAST(N'2022-03-24T02:51:01.3955940' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (345, NULL, CAST(N'2022-03-24T04:19:35.8852668' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (346, NULL, CAST(N'2022-03-24T22:22:06.9857528' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (347, NULL, CAST(N'2022-03-25T18:03:13.1204253' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (348, NULL, CAST(N'2022-03-27T22:04:13.9586627' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (349, NULL, CAST(N'2022-03-27T22:12:04.3840844' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (350, NULL, CAST(N'2022-03-29T23:21:18.9922133' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (351, NULL, CAST(N'2022-03-31T19:27:34.2561261' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (352, NULL, CAST(N'2022-04-01T16:57:13.4903430' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (353, NULL, CAST(N'2022-04-02T21:29:13.4330406' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (354, NULL, CAST(N'2022-04-03T11:57:30.9695352' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (355, NULL, CAST(N'2022-04-04T21:55:05.2611730' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (356, NULL, CAST(N'2022-04-05T18:12:19.7721658' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (357, NULL, CAST(N'2022-04-08T12:07:33.7580432' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (358, NULL, CAST(N'2022-04-09T14:50:30.9092345' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (359, NULL, CAST(N'2022-04-09T15:22:22.9566484' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (360, NULL, CAST(N'2022-04-10T01:09:36.5101212' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (361, NULL, CAST(N'2022-04-12T10:10:26.1349912' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (362, NULL, CAST(N'2022-04-15T06:56:18.5699230' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (363, NULL, CAST(N'2022-04-17T01:37:38.5706111' AS DateTime2), 0)
GO
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (364, NULL, CAST(N'2022-04-18T02:32:42.2472245' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (365, NULL, CAST(N'2022-04-19T06:07:02.1024908' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (366, NULL, CAST(N'2022-04-19T15:51:41.3360024' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (367, NULL, CAST(N'2022-04-20T15:45:05.4550290' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (368, NULL, CAST(N'2022-04-22T08:46:41.2829727' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (369, NULL, CAST(N'2022-04-23T01:15:49.9573645' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (370, NULL, CAST(N'2022-04-24T00:42:57.0355584' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (371, NULL, CAST(N'2022-04-24T14:57:51.1411591' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (372, NULL, CAST(N'2022-04-25T03:22:38.3245909' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (373, NULL, CAST(N'2022-04-27T00:35:39.4163376' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (374, NULL, CAST(N'2022-04-27T01:51:12.5177668' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (375, NULL, CAST(N'2022-04-28T08:35:51.4691102' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (376, NULL, CAST(N'2022-04-28T13:21:17.1503358' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (377, NULL, CAST(N'2022-04-30T06:53:36.5621652' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (378, NULL, CAST(N'2022-05-01T08:30:06.0514291' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (379, NULL, CAST(N'2022-05-02T02:26:29.9139880' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (380, NULL, CAST(N'2022-05-02T12:21:39.9644663' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (381, NULL, CAST(N'2022-05-03T00:36:58.6300041' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (382, NULL, CAST(N'2022-05-03T20:01:14.1354827' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (383, NULL, CAST(N'2022-05-05T12:34:26.5838290' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (384, NULL, CAST(N'2022-05-07T02:18:53.6400817' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (385, NULL, CAST(N'2022-05-08T11:11:28.7016825' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (386, NULL, CAST(N'2022-05-10T04:42:17.1181299' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (387, NULL, CAST(N'2022-05-10T12:29:53.0287222' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (388, NULL, CAST(N'2022-05-12T10:46:27.4189400' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (389, NULL, CAST(N'2022-05-13T08:51:35.7526774' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (390, NULL, CAST(N'2022-05-14T01:20:16.1379226' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (391, NULL, CAST(N'2022-05-14T11:47:50.5965561' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (392, NULL, CAST(N'2022-05-15T13:48:45.5950470' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (393, NULL, CAST(N'2022-05-17T19:31:34.4996754' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (394, NULL, CAST(N'2022-05-17T19:32:32.9979629' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (395, NULL, CAST(N'2022-05-18T07:07:40.6073334' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (396, NULL, CAST(N'2022-05-18T07:52:23.6430312' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (397, NULL, CAST(N'2022-05-18T15:58:47.5084891' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (398, NULL, CAST(N'2022-05-20T20:05:16.5493084' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (399, NULL, CAST(N'2022-05-21T02:01:33.9257856' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (400, NULL, CAST(N'2022-05-22T20:31:18.1105649' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (401, NULL, CAST(N'2022-05-23T08:00:21.7223593' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (402, NULL, CAST(N'2022-05-23T19:11:44.7906118' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (403, NULL, CAST(N'2022-05-23T23:01:02.7330931' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (404, NULL, CAST(N'2022-05-25T02:19:32.7709344' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (405, NULL, CAST(N'2022-05-25T14:55:56.9417490' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (406, NULL, CAST(N'2022-05-26T13:39:12.0271666' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (407, NULL, CAST(N'2022-05-27T11:18:53.2707740' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (408, NULL, CAST(N'2022-05-28T08:51:11.0007021' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (409, NULL, CAST(N'2022-05-29T00:32:56.3385248' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (410, NULL, CAST(N'2022-05-29T15:58:02.8640126' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (411, NULL, CAST(N'2022-05-30T13:50:45.8192834' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (412, NULL, CAST(N'2022-06-01T19:25:21.5646501' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (413, NULL, CAST(N'2022-06-01T23:37:04.5245102' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (414, NULL, CAST(N'2022-06-02T03:16:17.6606664' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (415, NULL, CAST(N'2022-06-04T00:23:13.2838188' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (416, NULL, CAST(N'2022-06-05T00:11:36.3293817' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (417, NULL, CAST(N'2022-06-06T14:35:59.3699789' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (418, NULL, CAST(N'2022-06-07T07:38:33.0013279' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (419, NULL, CAST(N'2022-06-08T00:57:01.9425516' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (420, NULL, CAST(N'2022-06-09T06:12:15.8038352' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (421, NULL, CAST(N'2022-06-09T09:19:14.6643083' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (422, NULL, CAST(N'2022-06-10T21:26:43.2926549' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (423, NULL, CAST(N'2022-06-11T18:08:13.1635774' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (424, NULL, CAST(N'2022-06-11T18:26:52.4791540' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (425, NULL, CAST(N'2022-06-12T19:33:08.7587292' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (426, NULL, CAST(N'2022-06-14T19:50:55.2138248' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (427, NULL, CAST(N'2022-06-15T01:17:26.0418905' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (428, NULL, CAST(N'2022-06-15T10:31:51.8598396' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (429, NULL, CAST(N'2022-06-16T19:51:46.6055833' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (430, NULL, CAST(N'2022-06-17T04:46:17.1571070' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (431, NULL, CAST(N'2022-06-17T16:21:14.6773515' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (432, NULL, CAST(N'2022-06-18T08:19:12.1569393' AS DateTime2), 0)
INSERT [dbo].[Carts] ([Id], [UserId], [CreatedOn], [IsCheckedOut]) VALUES (433, NULL, CAST(N'2022-06-19T21:06:19.7275884' AS DateTime2), 0)
SET IDENTITY_INSERT [dbo].[Carts] OFF
GO
SET IDENTITY_INSERT [dbo].[DataProtectionKeys] ON 

INSERT [dbo].[DataProtectionKeys] ([Id], [FriendlyName], [Xml]) VALUES (1, N'key-55f12cf2-709a-4d41-8930-3610fec1e136', N'<key id="55f12cf2-709a-4d41-8930-3610fec1e136" version="1"><creationDate>2022-01-10T14:07:06.5199788Z</creationDate><activationDate>2022-01-10T14:07:04.8570759Z</activationDate><expirationDate>2022-04-10T14:07:04.8570759Z</expirationDate><descriptor deserializerType="Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorDescriptorDeserializer, Microsoft.AspNetCore.DataProtection, Version=5.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"><descriptor><encryption algorithm="AES_256_CBC" /><validation algorithm="HMACSHA256" /><masterKey p4:requiresEncryption="true" xmlns:p4="http://schemas.asp.net/2015/03/dataProtection"><!-- Warning: the key below is in an unencrypted form. --><value>a+Hx8j126Df+/5zkgsTZIl9yfb1++Zreje8XvvwPWhvB+DpeYRF6/CADv8jVfBacFw9rMowjaJrh4pabRBJ1pQ==</value></masterKey></descriptor></descriptor></key>')
INSERT [dbo].[DataProtectionKeys] ([Id], [FriendlyName], [Xml]) VALUES (2, N'key-a916afa5-eebf-4a59-8984-7ac2a7c2e4d7', N'<key id="a916afa5-eebf-4a59-8984-7ac2a7c2e4d7" version="1"><creationDate>2022-04-08T14:16:08.0248342Z</creationDate><activationDate>2022-04-10T14:07:04.8570759Z</activationDate><expirationDate>2022-07-07T14:16:05.5436431Z</expirationDate><descriptor deserializerType="Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorDescriptorDeserializer, Microsoft.AspNetCore.DataProtection, Version=5.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"><descriptor><encryption algorithm="AES_256_CBC" /><validation algorithm="HMACSHA256" /><masterKey p4:requiresEncryption="true" xmlns:p4="http://schemas.asp.net/2015/03/dataProtection"><!-- Warning: the key below is in an unencrypted form. --><value>DfIDksybnQzIIp9Z1Mp8D/m4ZTRaHUMrMB+AG60B6nnxs3zWs7o/5qRux69m4C0ZQfjR9hSuA/TaR6fCQw4noQ==</value></masterKey></descriptor></descriptor></key>')
SET IDENTITY_INSERT [dbo].[DataProtectionKeys] OFF
GO
SET IDENTITY_INSERT [dbo].[DeliverableBundleItems] ON 

INSERT [dbo].[DeliverableBundleItems] ([Id], [DeliverableBundleId], [ProductStockId]) VALUES (17, 15, 65)
INSERT [dbo].[DeliverableBundleItems] ([Id], [DeliverableBundleId], [ProductStockId]) VALUES (18, 15, 64)
INSERT [dbo].[DeliverableBundleItems] ([Id], [DeliverableBundleId], [ProductStockId]) VALUES (19, 16, 69)
INSERT [dbo].[DeliverableBundleItems] ([Id], [DeliverableBundleId], [ProductStockId]) VALUES (20, 16, 68)
INSERT [dbo].[DeliverableBundleItems] ([Id], [DeliverableBundleId], [ProductStockId]) VALUES (21, 17, 76)
INSERT [dbo].[DeliverableBundleItems] ([Id], [DeliverableBundleId], [ProductStockId]) VALUES (22, 17, 75)
SET IDENTITY_INSERT [dbo].[DeliverableBundleItems] OFF
GO
SET IDENTITY_INSERT [dbo].[DeliverableBundles] ON 

INSERT [dbo].[DeliverableBundles] ([Id], [DeliverableId], [ProductItemBundleId]) VALUES (15, 17, 7)
INSERT [dbo].[DeliverableBundles] ([Id], [DeliverableId], [ProductItemBundleId]) VALUES (16, 18, 7)
INSERT [dbo].[DeliverableBundles] ([Id], [DeliverableId], [ProductItemBundleId]) VALUES (17, 23, 7)
SET IDENTITY_INSERT [dbo].[DeliverableBundles] OFF
GO
SET IDENTITY_INSERT [dbo].[DeliverableItems] ON 

INSERT [dbo].[DeliverableItems] ([Id], [DeliverableId], [OrderItemId], [ProductStockId]) VALUES (9, 17, 55, 62)
INSERT [dbo].[DeliverableItems] ([Id], [DeliverableId], [OrderItemId], [ProductStockId]) VALUES (10, 18, 56, 66)
INSERT [dbo].[DeliverableItems] ([Id], [DeliverableId], [OrderItemId], [ProductStockId]) VALUES (11, 19, NULL, 63)
INSERT [dbo].[DeliverableItems] ([Id], [DeliverableId], [OrderItemId], [ProductStockId]) VALUES (12, 19, 57, 67)
INSERT [dbo].[DeliverableItems] ([Id], [DeliverableId], [OrderItemId], [ProductStockId]) VALUES (13, 20, 58, 70)
INSERT [dbo].[DeliverableItems] ([Id], [DeliverableId], [OrderItemId], [ProductStockId]) VALUES (14, 21, 59, 71)
INSERT [dbo].[DeliverableItems] ([Id], [DeliverableId], [OrderItemId], [ProductStockId]) VALUES (15, 22, 60, 72)
INSERT [dbo].[DeliverableItems] ([Id], [DeliverableId], [OrderItemId], [ProductStockId]) VALUES (16, 23, 61, 73)
INSERT [dbo].[DeliverableItems] ([Id], [DeliverableId], [OrderItemId], [ProductStockId]) VALUES (17, 24, 63, 74)
INSERT [dbo].[DeliverableItems] ([Id], [DeliverableId], [OrderItemId], [ProductStockId]) VALUES (18, 25, 64, 77)
INSERT [dbo].[DeliverableItems] ([Id], [DeliverableId], [OrderItemId], [ProductStockId]) VALUES (19, 26, 68, 80)
INSERT [dbo].[DeliverableItems] ([Id], [DeliverableId], [OrderItemId], [ProductStockId]) VALUES (20, 27, 73, 81)
INSERT [dbo].[DeliverableItems] ([Id], [DeliverableId], [OrderItemId], [ProductStockId]) VALUES (21, 28, 75, 82)
INSERT [dbo].[DeliverableItems] ([Id], [DeliverableId], [OrderItemId], [ProductStockId]) VALUES (22, 29, 76, 83)
SET IDENTITY_INSERT [dbo].[DeliverableItems] OFF
GO
SET IDENTITY_INSERT [dbo].[Deliverables] ON 

INSERT [dbo].[Deliverables] ([Id], [OrderId], [Completed]) VALUES (17, 68, 1)
INSERT [dbo].[Deliverables] ([Id], [OrderId], [Completed]) VALUES (18, 69, 1)
INSERT [dbo].[Deliverables] ([Id], [OrderId], [Completed]) VALUES (19, 70, 1)
INSERT [dbo].[Deliverables] ([Id], [OrderId], [Completed]) VALUES (20, 71, 1)
INSERT [dbo].[Deliverables] ([Id], [OrderId], [Completed]) VALUES (21, 72, 1)
INSERT [dbo].[Deliverables] ([Id], [OrderId], [Completed]) VALUES (22, 73, 1)
INSERT [dbo].[Deliverables] ([Id], [OrderId], [Completed]) VALUES (23, 74, 1)
INSERT [dbo].[Deliverables] ([Id], [OrderId], [Completed]) VALUES (24, 76, 1)
INSERT [dbo].[Deliverables] ([Id], [OrderId], [Completed]) VALUES (25, 77, 1)
INSERT [dbo].[Deliverables] ([Id], [OrderId], [Completed]) VALUES (26, 81, 1)
INSERT [dbo].[Deliverables] ([Id], [OrderId], [Completed]) VALUES (27, 85, 1)
INSERT [dbo].[Deliverables] ([Id], [OrderId], [Completed]) VALUES (28, 87, 1)
INSERT [dbo].[Deliverables] ([Id], [OrderId], [Completed]) VALUES (29, 88, 1)
INSERT [dbo].[Deliverables] ([Id], [OrderId], [Completed]) VALUES (30, 90, 0)
INSERT [dbo].[Deliverables] ([Id], [OrderId], [Completed]) VALUES (31, 91, 0)
SET IDENTITY_INSERT [dbo].[Deliverables] OFF
GO
SET IDENTITY_INSERT [dbo].[EncryptionKeys] ON 

INSERT [dbo].[EncryptionKeys] ([Id], [Key], [LastUpdated]) VALUES (1, N'DbieFWw3PA6GsnHxBxE8Yzxgk3s4oAcruXDMzfxnOLh3O9bS3M6GcSOsMBPYvwhf', CAST(N'2022-01-11T17:12:05.2980490' AS DateTime2))
SET IDENTITY_INSERT [dbo].[EncryptionKeys] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderItem] ON 

INSERT [dbo].[OrderItem] ([Id], [Name], [OrderId], [ProductItemId], [Quantity], [PriceCurrency], [Price], [Discount], [Vat], [ProductStockId]) VALUES (55, N'Amazon 5$ Gift Card', 68, 1, 1, N'BDT', CAST(460.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[OrderItem] ([Id], [Name], [OrderId], [ProductItemId], [Quantity], [PriceCurrency], [Price], [Discount], [Vat], [ProductStockId]) VALUES (56, N'Amazon 5$ Gift Card', 69, 1, 1, N'BDT', CAST(460.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[OrderItem] ([Id], [Name], [OrderId], [ProductItemId], [Quantity], [PriceCurrency], [Price], [Discount], [Vat], [ProductStockId]) VALUES (57, N'Windows 10 Pro OEM Cd Key', 70, 12, 2, N'BDT', CAST(990.00 AS Decimal(18, 2)), CAST(90.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[OrderItem] ([Id], [Name], [OrderId], [ProductItemId], [Quantity], [PriceCurrency], [Price], [Discount], [Vat], [ProductStockId]) VALUES (58, N'Amazon 5$ Gift Card', 71, 1, 1, N'BDT', CAST(460.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[OrderItem] ([Id], [Name], [OrderId], [ProductItemId], [Quantity], [PriceCurrency], [Price], [Discount], [Vat], [ProductStockId]) VALUES (59, N'Amazon 5$ Gift Card', 72, 1, 1, N'BDT', CAST(460.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[OrderItem] ([Id], [Name], [OrderId], [ProductItemId], [Quantity], [PriceCurrency], [Price], [Discount], [Vat], [ProductStockId]) VALUES (60, N'Amazon 5$ Gift Card', 73, 1, 1, N'BDT', CAST(460.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[OrderItem] ([Id], [Name], [OrderId], [ProductItemId], [Quantity], [PriceCurrency], [Price], [Discount], [Vat], [ProductStockId]) VALUES (61, N'Amazon 5$ Gift Card', 74, 1, 1, N'BDT', CAST(460.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[OrderItem] ([Id], [Name], [OrderId], [ProductItemId], [Quantity], [PriceCurrency], [Price], [Discount], [Vat], [ProductStockId]) VALUES (62, N'Windows 10 Pro OEM Cd Key', 75, 12, 1, N'BDT', CAST(990.00 AS Decimal(18, 2)), CAST(90.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[OrderItem] ([Id], [Name], [OrderId], [ProductItemId], [Quantity], [PriceCurrency], [Price], [Discount], [Vat], [ProductStockId]) VALUES (63, N'Windows 10 Pro OEM Cd Key', 76, 12, 1, N'BDT', CAST(990.00 AS Decimal(18, 2)), CAST(90.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[OrderItem] ([Id], [Name], [OrderId], [ProductItemId], [Quantity], [PriceCurrency], [Price], [Discount], [Vat], [ProductStockId]) VALUES (64, N'Amazon 5$ Gift Card', 77, 1, 1, N'BDT', CAST(460.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[OrderItem] ([Id], [Name], [OrderId], [ProductItemId], [Quantity], [PriceCurrency], [Price], [Discount], [Vat], [ProductStockId]) VALUES (68, N'Test Product', 81, 18, 1, N'BDT', CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[OrderItem] ([Id], [Name], [OrderId], [ProductItemId], [Quantity], [PriceCurrency], [Price], [Discount], [Vat], [ProductStockId]) VALUES (69, N'Amazon 5$ Gift Card', 82, 1, 1, N'BDT', CAST(460.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[OrderItem] ([Id], [Name], [OrderId], [ProductItemId], [Quantity], [PriceCurrency], [Price], [Discount], [Vat], [ProductStockId]) VALUES (70, N'Test Product', 82, 18, 1, N'BDT', CAST(5.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[OrderItem] ([Id], [Name], [OrderId], [ProductItemId], [Quantity], [PriceCurrency], [Price], [Discount], [Vat], [ProductStockId]) VALUES (71, N'Test Product', 83, 18, 1, N'BDT', CAST(5.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[OrderItem] ([Id], [Name], [OrderId], [ProductItemId], [Quantity], [PriceCurrency], [Price], [Discount], [Vat], [ProductStockId]) VALUES (72, N'Test Product', 84, 18, 1, N'BDT', CAST(5.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[OrderItem] ([Id], [Name], [OrderId], [ProductItemId], [Quantity], [PriceCurrency], [Price], [Discount], [Vat], [ProductStockId]) VALUES (73, N'Test Product', 85, 18, 1, N'BDT', CAST(5.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[OrderItem] ([Id], [Name], [OrderId], [ProductItemId], [Quantity], [PriceCurrency], [Price], [Discount], [Vat], [ProductStockId]) VALUES (74, N'Test Product', 86, 18, 1, N'BDT', CAST(5.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[OrderItem] ([Id], [Name], [OrderId], [ProductItemId], [Quantity], [PriceCurrency], [Price], [Discount], [Vat], [ProductStockId]) VALUES (75, N'Test Product', 87, 18, 1, N'BDT', CAST(5.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[OrderItem] ([Id], [Name], [OrderId], [ProductItemId], [Quantity], [PriceCurrency], [Price], [Discount], [Vat], [ProductStockId]) VALUES (76, N'Test Product', 88, 18, 1, N'BDT', CAST(5.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[OrderItem] ([Id], [Name], [OrderId], [ProductItemId], [Quantity], [PriceCurrency], [Price], [Discount], [Vat], [ProductStockId]) VALUES (77, N'Amazon 5$ Gift Card', 89, 1, 1, N'BDT', CAST(460.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[OrderItem] ([Id], [Name], [OrderId], [ProductItemId], [Quantity], [PriceCurrency], [Price], [Discount], [Vat], [ProductStockId]) VALUES (78, N'Test Product', 90, 18, 1, N'BDT', CAST(5.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[OrderItem] ([Id], [Name], [OrderId], [ProductItemId], [Quantity], [PriceCurrency], [Price], [Discount], [Vat], [ProductStockId]) VALUES (79, N'Test Product', 91, 18, 1, N'BDT', CAST(5.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL)
SET IDENTITY_INSERT [dbo].[OrderItem] OFF
GO
INSERT [dbo].[OrderProductItemBundle] ([OrderId], [ProductItemBundleId], [Quantity], [PriceCurrency], [BundlePrice], [BundleDiscount]) VALUES (68, 7, 1, N'BDT', CAST(5560.00 AS Decimal(18, 2)), CAST(233.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderProductItemBundle] ([OrderId], [ProductItemBundleId], [Quantity], [PriceCurrency], [BundlePrice], [BundleDiscount]) VALUES (69, 7, 1, N'BDT', CAST(5560.00 AS Decimal(18, 2)), CAST(233.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderProductItemBundle] ([OrderId], [ProductItemBundleId], [Quantity], [PriceCurrency], [BundlePrice], [BundleDiscount]) VALUES (74, 7, 1, N'BDT', CAST(5560.00 AS Decimal(18, 2)), CAST(233.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [CartId], [ConfirmEmail], [CustomerId], [BillingAddressId], [Subtotal], [PromoCode], [PromoCodeDiscount], [TaxesAndFees], [GrandTotal], [PriceCurrency], [SendOfferInMail], [TransactionId], [IsAnonymousOrder], [Status], [CreatedOn], [LastModifiedOn], [DiscountTotal], [DeliverableId]) VALUES (68, 247, N'tanvir14012@gmail.com', N'b82992cf-004f-464a-809d-3643385257c5', 1214, CAST(5777.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(5777.0000 AS Decimal(19, 4)), N'BDT', 0, NULL, 0, 4, CAST(N'2022-01-11T17:34:59.4871112' AS DateTime2), CAST(N'2022-01-11T17:35:01.4456804' AS DateTime2), CAST(443.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Orders] ([Id], [CartId], [ConfirmEmail], [CustomerId], [BillingAddressId], [Subtotal], [PromoCode], [PromoCodeDiscount], [TaxesAndFees], [GrandTotal], [PriceCurrency], [SendOfferInMail], [TransactionId], [IsAnonymousOrder], [Status], [CreatedOn], [LastModifiedOn], [DiscountTotal], [DeliverableId]) VALUES (69, 248, N'tanvir14012@gmail.com', N'b82992cf-004f-464a-809d-3643385257c5', 1216, CAST(5777.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(5777.0000 AS Decimal(19, 4)), N'BDT', 0, NULL, 0, 4, CAST(N'2022-01-11T17:39:52.0164627' AS DateTime2), CAST(N'2022-01-11T17:39:54.3489196' AS DateTime2), CAST(443.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Orders] ([Id], [CartId], [ConfirmEmail], [CustomerId], [BillingAddressId], [Subtotal], [PromoCode], [PromoCodeDiscount], [TaxesAndFees], [GrandTotal], [PriceCurrency], [SendOfferInMail], [TransactionId], [IsAnonymousOrder], [Status], [CreatedOn], [LastModifiedOn], [DiscountTotal], [DeliverableId]) VALUES (70, 249, N'tanvir14012@gmail.com', N'b82992cf-004f-464a-809d-3643385257c5', 1218, CAST(1800.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(1800.0000 AS Decimal(19, 4)), N'BDT', 0, NULL, 0, 4, CAST(N'2022-01-11T17:43:45.2587237' AS DateTime2), CAST(N'2022-01-11T17:43:47.1369724' AS DateTime2), CAST(180.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Orders] ([Id], [CartId], [ConfirmEmail], [CustomerId], [BillingAddressId], [Subtotal], [PromoCode], [PromoCodeDiscount], [TaxesAndFees], [GrandTotal], [PriceCurrency], [SendOfferInMail], [TransactionId], [IsAnonymousOrder], [Status], [CreatedOn], [LastModifiedOn], [DiscountTotal], [DeliverableId]) VALUES (71, 250, N'tanvir14012@gmail.com', N'b82992cf-004f-464a-809d-3643385257c5', 1220, CAST(450.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(450.0000 AS Decimal(19, 4)), N'BDT', 0, NULL, 0, 4, CAST(N'2022-01-11T17:46:43.2270819' AS DateTime2), CAST(N'2022-01-11T17:46:45.0973387' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Orders] ([Id], [CartId], [ConfirmEmail], [CustomerId], [BillingAddressId], [Subtotal], [PromoCode], [PromoCodeDiscount], [TaxesAndFees], [GrandTotal], [PriceCurrency], [SendOfferInMail], [TransactionId], [IsAnonymousOrder], [Status], [CreatedOn], [LastModifiedOn], [DiscountTotal], [DeliverableId]) VALUES (72, 251, N'tanvir14012@gmail.com', N'b82992cf-004f-464a-809d-3643385257c5', 1222, CAST(450.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(450.0000 AS Decimal(19, 4)), N'BDT', 0, NULL, 0, 4, CAST(N'2022-01-11T17:49:19.4800915' AS DateTime2), CAST(N'2022-01-11T17:49:21.3964951' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Orders] ([Id], [CartId], [ConfirmEmail], [CustomerId], [BillingAddressId], [Subtotal], [PromoCode], [PromoCodeDiscount], [TaxesAndFees], [GrandTotal], [PriceCurrency], [SendOfferInMail], [TransactionId], [IsAnonymousOrder], [Status], [CreatedOn], [LastModifiedOn], [DiscountTotal], [DeliverableId]) VALUES (73, 252, N'tanvir14012@gmail.com', N'b82992cf-004f-464a-809d-3643385257c5', 1224, CAST(450.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(450.0000 AS Decimal(19, 4)), N'BDT', 0, NULL, 0, 4, CAST(N'2022-01-11T18:07:20.0790927' AS DateTime2), CAST(N'2022-01-11T18:07:21.8666537' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Orders] ([Id], [CartId], [ConfirmEmail], [CustomerId], [BillingAddressId], [Subtotal], [PromoCode], [PromoCodeDiscount], [TaxesAndFees], [GrandTotal], [PriceCurrency], [SendOfferInMail], [TransactionId], [IsAnonymousOrder], [Status], [CreatedOn], [LastModifiedOn], [DiscountTotal], [DeliverableId]) VALUES (74, 253, N'tanvir14012@gmail.com', N'b82992cf-004f-464a-809d-3643385257c5', 1226, CAST(5777.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(5777.0000 AS Decimal(19, 4)), N'BDT', 0, NULL, 0, 4, CAST(N'2022-01-12T06:34:11.7457446' AS DateTime2), CAST(N'2022-01-12T06:34:14.9479347' AS DateTime2), CAST(443.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Orders] ([Id], [CartId], [ConfirmEmail], [CustomerId], [BillingAddressId], [Subtotal], [PromoCode], [PromoCodeDiscount], [TaxesAndFees], [GrandTotal], [PriceCurrency], [SendOfferInMail], [TransactionId], [IsAnonymousOrder], [Status], [CreatedOn], [LastModifiedOn], [DiscountTotal], [DeliverableId]) VALUES (75, 255, N'tanvir14012@gmail.com', N'b82992cf-004f-464a-809d-3643385257c5', 1227, CAST(900.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(900.0000 AS Decimal(19, 4)), N'BDT', 0, NULL, 0, 0, CAST(N'2022-01-15T10:57:34.6936164' AS DateTime2), CAST(N'2022-01-15T10:57:34.6937128' AS DateTime2), CAST(90.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Orders] ([Id], [CartId], [ConfirmEmail], [CustomerId], [BillingAddressId], [Subtotal], [PromoCode], [PromoCodeDiscount], [TaxesAndFees], [GrandTotal], [PriceCurrency], [SendOfferInMail], [TransactionId], [IsAnonymousOrder], [Status], [CreatedOn], [LastModifiedOn], [DiscountTotal], [DeliverableId]) VALUES (76, 259, N'tanvir14012@gmail.com', N'b82992cf-004f-464a-809d-3643385257c5', 1229, CAST(900.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(900.0000 AS Decimal(19, 4)), N'BDT', 0, NULL, 0, 4, CAST(N'2022-01-19T13:48:35.9909183' AS DateTime2), CAST(N'2022-01-19T13:48:39.3217927' AS DateTime2), CAST(90.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Orders] ([Id], [CartId], [ConfirmEmail], [CustomerId], [BillingAddressId], [Subtotal], [PromoCode], [PromoCodeDiscount], [TaxesAndFees], [GrandTotal], [PriceCurrency], [SendOfferInMail], [TransactionId], [IsAnonymousOrder], [Status], [CreatedOn], [LastModifiedOn], [DiscountTotal], [DeliverableId]) VALUES (77, 264, N'tanvir14012@gmail.com', N'b82992cf-004f-464a-809d-3643385257c5', 1231, CAST(450.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(450.0000 AS Decimal(19, 4)), N'BDT', 0, NULL, 0, 4, CAST(N'2022-01-19T14:08:51.0682639' AS DateTime2), CAST(N'2022-01-19T14:08:53.3647005' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Orders] ([Id], [CartId], [ConfirmEmail], [CustomerId], [BillingAddressId], [Subtotal], [PromoCode], [PromoCodeDiscount], [TaxesAndFees], [GrandTotal], [PriceCurrency], [SendOfferInMail], [TransactionId], [IsAnonymousOrder], [Status], [CreatedOn], [LastModifiedOn], [DiscountTotal], [DeliverableId]) VALUES (81, 275, N'tanvir14012@gmail.com', N'b82992cf-004f-464a-809d-3643385257c5', 1239, CAST(10.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(10.0000 AS Decimal(19, 4)), N'BDT', 0, NULL, 0, 4, CAST(N'2022-01-26T14:07:15.6428948' AS DateTime2), CAST(N'2022-01-26T14:07:18.9393387' AS DateTime2), CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Orders] ([Id], [CartId], [ConfirmEmail], [CustomerId], [BillingAddressId], [Subtotal], [PromoCode], [PromoCodeDiscount], [TaxesAndFees], [GrandTotal], [PriceCurrency], [SendOfferInMail], [TransactionId], [IsAnonymousOrder], [Status], [CreatedOn], [LastModifiedOn], [DiscountTotal], [DeliverableId]) VALUES (82, 243, N'tanvir14012@gmail.com', N'b82992cf-004f-464a-809d-3643385257c5', 1241, CAST(455.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(455.0000 AS Decimal(19, 4)), N'BDT', 0, NULL, 0, 0, CAST(N'2022-01-26T14:37:40.6631787' AS DateTime2), CAST(N'2022-01-26T14:37:43.4461383' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Orders] ([Id], [CartId], [ConfirmEmail], [CustomerId], [BillingAddressId], [Subtotal], [PromoCode], [PromoCodeDiscount], [TaxesAndFees], [GrandTotal], [PriceCurrency], [SendOfferInMail], [TransactionId], [IsAnonymousOrder], [Status], [CreatedOn], [LastModifiedOn], [DiscountTotal], [DeliverableId]) VALUES (83, 256, N'tanvir14012@gmail.com', N'b82992cf-004f-464a-809d-3643385257c5', 1243, CAST(5.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(5.0000 AS Decimal(19, 4)), N'BDT', 0, NULL, 0, 3, CAST(N'2022-01-26T14:38:49.2803063' AS DateTime2), CAST(N'2022-01-26T14:38:51.1861362' AS DateTime2), CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Orders] ([Id], [CartId], [ConfirmEmail], [CustomerId], [BillingAddressId], [Subtotal], [PromoCode], [PromoCodeDiscount], [TaxesAndFees], [GrandTotal], [PriceCurrency], [SendOfferInMail], [TransactionId], [IsAnonymousOrder], [Status], [CreatedOn], [LastModifiedOn], [DiscountTotal], [DeliverableId]) VALUES (84, 257, N'tanvir14012@gmail.com', N'b82992cf-004f-464a-809d-3643385257c5', 1245, CAST(5.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(5.0000 AS Decimal(19, 4)), N'BDT', 0, NULL, 0, 3, CAST(N'2022-01-26T15:32:29.2067103' AS DateTime2), CAST(N'2022-01-26T15:32:41.4142580' AS DateTime2), CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Orders] ([Id], [CartId], [ConfirmEmail], [CustomerId], [BillingAddressId], [Subtotal], [PromoCode], [PromoCodeDiscount], [TaxesAndFees], [GrandTotal], [PriceCurrency], [SendOfferInMail], [TransactionId], [IsAnonymousOrder], [Status], [CreatedOn], [LastModifiedOn], [DiscountTotal], [DeliverableId]) VALUES (85, 258, N'tanvir14012@gmail.com', N'b82992cf-004f-464a-809d-3643385257c5', 1247, CAST(5.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(5.0000 AS Decimal(19, 4)), N'BDT', 0, NULL, 0, 4, CAST(N'2022-01-26T18:15:41.0779251' AS DateTime2), CAST(N'2022-01-26T18:15:43.7277207' AS DateTime2), CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Orders] ([Id], [CartId], [ConfirmEmail], [CustomerId], [BillingAddressId], [Subtotal], [PromoCode], [PromoCodeDiscount], [TaxesAndFees], [GrandTotal], [PriceCurrency], [SendOfferInMail], [TransactionId], [IsAnonymousOrder], [Status], [CreatedOn], [LastModifiedOn], [DiscountTotal], [DeliverableId]) VALUES (86, 260, N'tanvir14012@gmail.com', N'b82992cf-004f-464a-809d-3643385257c5', 1249, CAST(5.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(5.0000 AS Decimal(19, 4)), N'BDT', 0, NULL, 0, 0, CAST(N'2022-01-27T06:41:49.1714081' AS DateTime2), CAST(N'2022-01-27T06:41:53.2307897' AS DateTime2), CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Orders] ([Id], [CartId], [ConfirmEmail], [CustomerId], [BillingAddressId], [Subtotal], [PromoCode], [PromoCodeDiscount], [TaxesAndFees], [GrandTotal], [PriceCurrency], [SendOfferInMail], [TransactionId], [IsAnonymousOrder], [Status], [CreatedOn], [LastModifiedOn], [DiscountTotal], [DeliverableId]) VALUES (87, 278, N'tanvir14012@gmail.com', N'b82992cf-004f-464a-809d-3643385257c5', 1250, CAST(5.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(5.0000 AS Decimal(19, 4)), N'BDT', 0, NULL, 0, 4, CAST(N'2022-01-27T07:36:51.4693529' AS DateTime2), CAST(N'2022-01-27T07:36:51.4694428' AS DateTime2), CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Orders] ([Id], [CartId], [ConfirmEmail], [CustomerId], [BillingAddressId], [Subtotal], [PromoCode], [PromoCodeDiscount], [TaxesAndFees], [GrandTotal], [PriceCurrency], [SendOfferInMail], [TransactionId], [IsAnonymousOrder], [Status], [CreatedOn], [LastModifiedOn], [DiscountTotal], [DeliverableId]) VALUES (88, 261, N'tanvir14012@gmail.com', N'b82992cf-004f-464a-809d-3643385257c5', 1251, CAST(5.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(5.0000 AS Decimal(19, 4)), N'BDT', 0, NULL, 0, 4, CAST(N'2022-01-27T12:43:20.2528684' AS DateTime2), CAST(N'2022-01-27T12:43:20.2529538' AS DateTime2), CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Orders] ([Id], [CartId], [ConfirmEmail], [CustomerId], [BillingAddressId], [Subtotal], [PromoCode], [PromoCodeDiscount], [TaxesAndFees], [GrandTotal], [PriceCurrency], [SendOfferInMail], [TransactionId], [IsAnonymousOrder], [Status], [CreatedOn], [LastModifiedOn], [DiscountTotal], [DeliverableId]) VALUES (89, 290, N'tanvir14012@gmail.com', N'b82992cf-004f-464a-809d-3643385257c5', 1252, CAST(450.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(450.0000 AS Decimal(19, 4)), N'BDT', 0, NULL, 0, 0, CAST(N'2022-02-02T16:30:45.1971830' AS DateTime2), CAST(N'2022-02-02T16:30:45.1973171' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Orders] ([Id], [CartId], [ConfirmEmail], [CustomerId], [BillingAddressId], [Subtotal], [PromoCode], [PromoCodeDiscount], [TaxesAndFees], [GrandTotal], [PriceCurrency], [SendOfferInMail], [TransactionId], [IsAnonymousOrder], [Status], [CreatedOn], [LastModifiedOn], [DiscountTotal], [DeliverableId]) VALUES (90, 262, N'tanvir14012@gmail.com', N'b82992cf-004f-464a-809d-3643385257c5', 1253, CAST(5.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(5.0000 AS Decimal(19, 4)), N'BDT', 0, NULL, 0, 5, CAST(N'2022-02-06T07:08:55.3343199' AS DateTime2), CAST(N'2022-02-06T07:08:55.3344104' AS DateTime2), CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[Orders] ([Id], [CartId], [ConfirmEmail], [CustomerId], [BillingAddressId], [Subtotal], [PromoCode], [PromoCodeDiscount], [TaxesAndFees], [GrandTotal], [PriceCurrency], [SendOfferInMail], [TransactionId], [IsAnonymousOrder], [Status], [CreatedOn], [LastModifiedOn], [DiscountTotal], [DeliverableId]) VALUES (91, 263, N'tanvir14012@gmail.com', N'b82992cf-004f-464a-809d-3643385257c5', 1254, CAST(5.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(5.0000 AS Decimal(19, 4)), N'BDT', 0, NULL, 0, 5, CAST(N'2022-02-06T07:27:39.3323362' AS DateTime2), CAST(N'2022-02-06T07:27:39.3324776' AS DateTime2), CAST(0.00 AS Decimal(18, 2)), NULL)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[PaymentGwConfigs] ON 

INSERT [dbo].[PaymentGwConfigs] ([Id], [GwName], [Username], [Password], [RedirectUrl], [SuccessCallbackUrl], [CancelCallbackUrl], [FailCallbackUrl], [Data_a], [Data_b], [Data_c], [Data_d], [Data_e], [CreatedOn], [ModifiedOn], [ApiRoot]) VALUES (1, N'Surjopay', N'BWON8bNGx5QuMxV1QAJ0ww==', N'N1gC777zi02JCguD27KrjMCTuvLKzSeU2bsN66W2JAw=', N'https://engine.shurjopayment.com', N'https://www.niludigital.com/cart/payment', N'https://www.niludigital.com/cart/payment', N'https://www.niludigital.com/cart/payment', N'/api/get_token', N'/api/secret-pay', N'/api/verification', NULL, NULL, CAST(N'2021-06-03T17:23:33.0000000' AS DateTime2), CAST(N'2021-06-03T17:23:33.0000000' AS DateTime2), N'https://engine.shurjopayment.com')
SET IDENTITY_INSERT [dbo].[PaymentGwConfigs] OFF
GO
SET IDENTITY_INSERT [dbo].[PaymentTransactions] ON 

INSERT [dbo].[PaymentTransactions] ([Id], [Status], [OrderId], [SurjoPayMsg], [CardNo], [BankTrnxId], [CardIssuerBank], [CardIssuerCountry], [Phone], [TrnxMethod], [Amount], [RiskLevel], [CreatedOn], [LastModifiedOn], [SurjoPayOrderId], [Address], [AmountInUSD], [BankStatus], [CardHolderName], [City], [Currency], [Email], [InvoiceId], [Name], [RateOfUSD], [SurjoPayCode], [UserVerificationToken]) VALUES (39, N'', 68, N'Success', N'accoxxxxxxxx', N'61ddbfda', NULL, NULL, NULL, N'iBanking', CAST(5777.0000 AS Decimal(19, 4)), NULL, CAST(N'2022-01-11T17:35:02.2292584' AS DateTime2), CAST(N'2022-01-11T17:35:24.0587871' AS DateTime2), N'7SMWqpSueviuyQl+YjCnoHipSfDbGyfqFM6VKFaQqvU=', N'N/A ', CAST(0.00 AS Decimal(18, 2)), N'Success', N'', N'Dhaka', N'BDT', N'O9AXvQAQR0Cy2j2JAKV9c14d0z/Xhz9EMWKTeeoeqms=', N'NiluD61ddbfc5389bb', N'Anonymous', CAST(0.00 AS Decimal(18, 2)), 1000, N'E7pYbizjLVW6Dkzqti+Q+YZD6VZgwr9RbFK3zXwru+JZ5ns8HoDZosajkTXDjwIXYLk0i/PJBtHTI+jAyk1Vih5XePIjx+Dpi+E6W4A1o0zHBNFAnMYxtwFL2IT03CYJDNKbGCYq+H2Yhnmp4GLI0YLUE8WBIIBDJvQ59O/082ith6PTd9eXwne7svxJWTOQjKoD8eXz1NoNR1VWsUJnoQ==')
INSERT [dbo].[PaymentTransactions] ([Id], [Status], [OrderId], [SurjoPayMsg], [CardNo], [BankTrnxId], [CardIssuerBank], [CardIssuerCountry], [Phone], [TrnxMethod], [Amount], [RiskLevel], [CreatedOn], [LastModifiedOn], [SurjoPayOrderId], [Address], [AmountInUSD], [BankStatus], [CardHolderName], [City], [Currency], [Email], [InvoiceId], [Name], [RateOfUSD], [SurjoPayCode], [UserVerificationToken]) VALUES (40, N'', 69, N'Success', N'accoxxxxxxxx', N'61ddc0f9', NULL, NULL, NULL, N'iBanking', CAST(5777.0000 AS Decimal(19, 4)), NULL, CAST(N'2022-01-11T17:39:55.2936141' AS DateTime2), CAST(N'2022-01-11T17:40:11.2374526' AS DateTime2), N'iwFrp6MqSERd+HsAENdN705wI2uGFdiUSfXIV6dy6Aw=', N'N/A ', CAST(0.00 AS Decimal(18, 2)), N'Success', N'', N'Dhaka', N'BDT', N'O9AXvQAQR0Cy2j2JAKV9c14d0z/Xhz9EMWKTeeoeqms=', N'NiluD61ddc0ea4a24f', N'Anonymous', CAST(0.00 AS Decimal(18, 2)), 1000, N'E7pYbizjLVW6Dkzqti+Q+f5EzigpmloiRFT/gutAzK0vGmQGP6oOe8hhO126VazpsSJyIpRpjhFtxPImrSQb5QQe5AoEFcV5LxHDgZPKyklYmM3+/gebXBUyu4siuXTYegm3PQi29tnBrEoxcKJd61Xl2CEHNiFgdeBY+xahXZDiMB8aL3nc6HsbNvbYRGn8JFkaCBC3YRXpu3mvvqG60Q==')
INSERT [dbo].[PaymentTransactions] ([Id], [Status], [OrderId], [SurjoPayMsg], [CardNo], [BankTrnxId], [CardIssuerBank], [CardIssuerCountry], [Phone], [TrnxMethod], [Amount], [RiskLevel], [CreatedOn], [LastModifiedOn], [SurjoPayOrderId], [Address], [AmountInUSD], [BankStatus], [CardHolderName], [City], [Currency], [Email], [InvoiceId], [Name], [RateOfUSD], [SurjoPayCode], [UserVerificationToken]) VALUES (41, N'', 70, N'Success', N'accoxxxxxxxx', N'61ddc1df', NULL, NULL, NULL, N'iBanking', CAST(1800.0000 AS Decimal(19, 4)), NULL, CAST(N'2022-01-11T17:43:47.6958406' AS DateTime2), CAST(N'2022-01-11T17:44:00.9822047' AS DateTime2), N'LNQUcjolf5dhuGD/mXxXKqPt2G58YSLybOZ/uB5UnLU=', N'N/A ', CAST(0.00 AS Decimal(18, 2)), N'Success', N'', N'Dhaka', N'BDT', N'O9AXvQAQR0Cy2j2JAKV9c14d0z/Xhz9EMWKTeeoeqms=', N'NiluD61ddc1d2ac766', N'Anonymous', CAST(0.00 AS Decimal(18, 2)), 1000, N'E7pYbizjLVW6Dkzqti+Q+SNDn1Q66o1JAMupr93va5s0nH2g0VlPck06zIi1i8IMRuaxGrcy3kI6j5zYRtKTok0ePWVjE4sBFfz6do4QntDbbWECuQAYWiv+ce7ZteWwVQrIsHLz4l+UQ9xV1vUrPEjQP6KLDPufTu1Hos7jbSaoqY6zaV/wzL1JfN4M+NN0l0wXSHehtGe7Gjf6sy5s2g==')
INSERT [dbo].[PaymentTransactions] ([Id], [Status], [OrderId], [SurjoPayMsg], [CardNo], [BankTrnxId], [CardIssuerBank], [CardIssuerCountry], [Phone], [TrnxMethod], [Amount], [RiskLevel], [CreatedOn], [LastModifiedOn], [SurjoPayOrderId], [Address], [AmountInUSD], [BankStatus], [CardHolderName], [City], [Currency], [Email], [InvoiceId], [Name], [RateOfUSD], [SurjoPayCode], [UserVerificationToken]) VALUES (42, N'', 71, N'Success', N'accoxxxxxxxx', N'61ddc28e', NULL, NULL, NULL, N'iBanking', CAST(450.0000 AS Decimal(19, 4)), NULL, CAST(N'2022-01-11T17:46:46.7067749' AS DateTime2), CAST(N'2022-01-11T17:46:56.3737990' AS DateTime2), N'MHiGji9omW33N0drQb2CC2PUPrrMkCzmccPR9hsLVIo=', N'N/A ', CAST(0.00 AS Decimal(18, 2)), N'Success', N'', N'Dhaka', N'BDT', N'O9AXvQAQR0Cy2j2JAKV9c14d0z/Xhz9EMWKTeeoeqms=', N'NiluD61ddc285aece8', N'Anonymous', CAST(0.00 AS Decimal(18, 2)), 1000, N'E7pYbizjLVW6Dkzqti+Q+TmjYiHYQkTzkey8C6cqL5elQgHh2hBJqNzxrIkywDrJcL/TJtKI5dTv0Lkw1+dnHEjCXVhm9TyMxbQ411XfwkmVxn2NHxxDPsvR6mz4JA6v7xUcoZVuekcxbcWjKdSbVuyFs+wIIdjdBZKdrWK2bSaPQ2oBL1ZaqTxLB0GyfqXn+XcTxi9ghVwMhGOWngsjZw==')
INSERT [dbo].[PaymentTransactions] ([Id], [Status], [OrderId], [SurjoPayMsg], [CardNo], [BankTrnxId], [CardIssuerBank], [CardIssuerCountry], [Phone], [TrnxMethod], [Amount], [RiskLevel], [CreatedOn], [LastModifiedOn], [SurjoPayOrderId], [Address], [AmountInUSD], [BankStatus], [CardHolderName], [City], [Currency], [Email], [InvoiceId], [Name], [RateOfUSD], [SurjoPayCode], [UserVerificationToken]) VALUES (43, N'', 72, N'Success', N'accoxxxxxxxx', N'61ddc32f', NULL, NULL, NULL, N'iBanking', CAST(450.0000 AS Decimal(19, 4)), NULL, CAST(N'2022-01-11T17:49:22.1343278' AS DateTime2), CAST(N'2022-01-11T17:49:36.9397714' AS DateTime2), N'uN/3Tb24s8cLYaoTAK4rvuRjirEVubadqHvvMObkp9Q=', N'N/A ', CAST(0.00 AS Decimal(18, 2)), N'Success', N'', N'Dhaka', N'BDT', N'O9AXvQAQR0Cy2j2JAKV9c14d0z/Xhz9EMWKTeeoeqms=', N'NiluD61ddc32127941', N'Anonymous', CAST(0.00 AS Decimal(18, 2)), 1000, N'E7pYbizjLVW6Dkzqti+Q+c9G5oWo69nbEFX4LP3NxPSbZWyvaCuxyRYMa/EEU/KciLFzLUzpXzUgYQNqCfuHssfU3bxP8kapkD7H7LSa3+0TSmwVWWGZfw0dYJR1AN+hiiDakpEzFT/xyhRpnhVEjl65s74vCNoxwfJdH4I4Nlw8/4aEkUsHg2WraNejgPkQtC4bGp7ujP3HnUAlCTRZmg==')
INSERT [dbo].[PaymentTransactions] ([Id], [Status], [OrderId], [SurjoPayMsg], [CardNo], [BankTrnxId], [CardIssuerBank], [CardIssuerCountry], [Phone], [TrnxMethod], [Amount], [RiskLevel], [CreatedOn], [LastModifiedOn], [SurjoPayOrderId], [Address], [AmountInUSD], [BankStatus], [CardHolderName], [City], [Currency], [Email], [InvoiceId], [Name], [RateOfUSD], [SurjoPayCode], [UserVerificationToken]) VALUES (44, N'', 73, N'Success', N'accoxxxxxxxx', N'61ddc763', NULL, NULL, NULL, N'iBanking', CAST(450.0000 AS Decimal(19, 4)), NULL, CAST(N'2022-01-11T18:07:22.6302017' AS DateTime2), CAST(N'2022-01-11T18:07:32.6056379' AS DateTime2), N'Q5fnBLU76vjyMmsTPdyoxtvK1bz4Fu16J5LHCikVe84=', N'N/A ', CAST(0.00 AS Decimal(18, 2)), N'Success', N'', N'Dhaka', N'BDT', N'O9AXvQAQR0Cy2j2JAKV9c14d0z/Xhz9EMWKTeeoeqms=', N'NiluD61ddc759e62b9', N'Anonymous', CAST(0.00 AS Decimal(18, 2)), 1000, N'E7pYbizjLVW6Dkzqti+Q+Ttkasj22/s8Chwx/HQ6h5d7IPoygCodhQ8fnvZCCg6Y96zzwGOlTmuXW27gKWz2OJDvSRR9NXKOBOyzsyg32vc5iRM4D8fS78NhUvuecCrN6xoQDF/UfNegVpCgXx0IAnqqECo1/tHBuL2nq39Dov23xVeqADrafEQziGkU0fWSDyAvdz9insIhdnhXGfhZRQ==')
INSERT [dbo].[PaymentTransactions] ([Id], [Status], [OrderId], [SurjoPayMsg], [CardNo], [BankTrnxId], [CardIssuerBank], [CardIssuerCountry], [Phone], [TrnxMethod], [Amount], [RiskLevel], [CreatedOn], [LastModifiedOn], [SurjoPayOrderId], [Address], [AmountInUSD], [BankStatus], [CardHolderName], [City], [Currency], [Email], [InvoiceId], [Name], [RateOfUSD], [SurjoPayCode], [UserVerificationToken]) VALUES (45, N'', 74, N'Success', N'accoxxxxxxxx', N'61de7671', NULL, NULL, NULL, N'iBanking', CAST(5777.0000 AS Decimal(19, 4)), NULL, CAST(N'2022-01-12T06:34:15.8571799' AS DateTime2), CAST(N'2022-01-12T06:34:28.9543872' AS DateTime2), N'ocD+VQlywRuMbKo9OM2AqjY9CgHFQ+Z+J2Y0FCyIi+Q=', N'N/A ', CAST(0.00 AS Decimal(18, 2)), N'Success', N'', N'Dhaka', N'BDT', N'O9AXvQAQR0Cy2j2JAKV9c14d0z/Xhz9EMWKTeeoeqms=', N'NiluD61de7667e37ce', N'Anonymous', CAST(0.00 AS Decimal(18, 2)), 1000, N'E7pYbizjLVW6Dkzqti+Q+Vmiu/32w1oybPicYMGKSSD/I8AloKHoN7e1IHMDa91t5N+1ssgTeSdQQG9fSrqVeepSuShxAI2xvyh7srciIM8s0Vw/JjFbX9g+x/grM3VZMyd2IiKhjuu/23iTbX/fG0Qyxw37raRem8wHDtT3Re+SeRAzs247Z77/K3GpeUali/pfgNoQb995u4NlETkJAA==')
INSERT [dbo].[PaymentTransactions] ([Id], [Status], [OrderId], [SurjoPayMsg], [CardNo], [BankTrnxId], [CardIssuerBank], [CardIssuerCountry], [Phone], [TrnxMethod], [Amount], [RiskLevel], [CreatedOn], [LastModifiedOn], [SurjoPayOrderId], [Address], [AmountInUSD], [BankStatus], [CardHolderName], [City], [Currency], [Email], [InvoiceId], [Name], [RateOfUSD], [SurjoPayCode], [UserVerificationToken]) VALUES (46, N'', 76, N'Success', N'accoxxxxxxxx', N'61e816c2', NULL, NULL, NULL, N'iBanking', CAST(900.0000 AS Decimal(19, 4)), NULL, CAST(N'2022-01-19T13:48:40.3432100' AS DateTime2), CAST(N'2022-01-19T13:48:51.3417073' AS DateTime2), N'yH4LRx2Z2qI020/hb/ETYFF+7yqa/zYVH5WTn8J8G8Y=', N'N/A ', CAST(0.00 AS Decimal(18, 2)), N'Success', N'', N'Dhaka', N'BDT', N'O9AXvQAQR0Cy2j2JAKV9c14d0z/Xhz9EMWKTeeoeqms=', N'NiluD61e816b845e6f', N'Anonymous ', CAST(0.00 AS Decimal(18, 2)), 1000, N'E7pYbizjLVW6Dkzqti+Q+RvxYjMc8IYrvIC5WEdTHWz/TITVAvzgAKqtA9XkbzKh57urLVC+ATR/ZFULsTka5rz60uVEVUpFff2I56IfMMU2beR7IT/w/OvG8xMktebLMUfeE6BVlqUR1SWfVZDln4lKiGA88oN+PTq9bSgxjtqiOXfndeQ+MUUT+EHQrH+k0U/N/lwcv3M19BAC7mJr8A==')
INSERT [dbo].[PaymentTransactions] ([Id], [Status], [OrderId], [SurjoPayMsg], [CardNo], [BankTrnxId], [CardIssuerBank], [CardIssuerCountry], [Phone], [TrnxMethod], [Amount], [RiskLevel], [CreatedOn], [LastModifiedOn], [SurjoPayOrderId], [Address], [AmountInUSD], [BankStatus], [CardHolderName], [City], [Currency], [Email], [InvoiceId], [Name], [RateOfUSD], [SurjoPayCode], [UserVerificationToken]) VALUES (47, N'', 77, N'Success', N'accoxxxxxxxx', N'61e81b7e', NULL, NULL, NULL, N'iBanking', CAST(450.0000 AS Decimal(19, 4)), NULL, CAST(N'2022-01-19T14:08:54.2742872' AS DateTime2), CAST(N'2022-01-19T14:09:02.9088681' AS DateTime2), N'eVVVCYgseeyeI4himj/83NBW+jPVIv180vUr7EBGSPc=', N'N/A ', CAST(0.00 AS Decimal(18, 2)), N'Success', N'', N'Dhaka', N'BDT', N'O9AXvQAQR0Cy2j2JAKV9c14d0z/Xhz9EMWKTeeoeqms=', N'NiluD61e81b762f338', N'Anonymous ', CAST(0.00 AS Decimal(18, 2)), 1000, N'E7pYbizjLVW6Dkzqti+Q+fwaKcx2W+fOi54TdpDRMux+RC3/ijizwg6vD++zhpyx0vN5bg36zPKrtkq6g4rb2To5CWBodIhzEzB+jSOHTJhgNobKLGao8uqciS4zLX5evSEI5I6vipmWDjgIIRNBKY/DCv+Gde5XaWrJ/G/x5SJ2RW14SZo8RarTQDq46Ow6yBb7Nqv9zfAzYApY05UsfQ==')
INSERT [dbo].[PaymentTransactions] ([Id], [Status], [OrderId], [SurjoPayMsg], [CardNo], [BankTrnxId], [CardIssuerBank], [CardIssuerCountry], [Phone], [TrnxMethod], [Amount], [RiskLevel], [CreatedOn], [LastModifiedOn], [SurjoPayOrderId], [Address], [AmountInUSD], [BankStatus], [CardHolderName], [City], [Currency], [Email], [InvoiceId], [Name], [RateOfUSD], [SurjoPayCode], [UserVerificationToken]) VALUES (48, N'Completed', 81, N'Success', N'', N'9AQ4C1PNQ2', NULL, NULL, N'EQb31RkCyoExxUF1NbaVRg==', N'bkash', CAST(10.0000 AS Decimal(19, 4)), NULL, CAST(N'2022-01-26T14:07:21.4554069' AS DateTime2), CAST(N'2022-01-26T14:09:25.4850769' AS DateTime2), N'cqNPHgO/cp5tVxoFKVz1TMhu9YcznBgQ+gIkyQAqWZk=', N'N/A ', CAST(0.00 AS Decimal(18, 2)), N'The Payment was Successful', N'', N'Dhaka', N'BDT', N'O9AXvQAQR0Cy2j2JAKV9c14d0z/Xhz9EMWKTeeoeqms=', N'NLD61f155d75a516', N'Anonymous ', CAST(0.00 AS Decimal(18, 2)), 1000, N'E7pYbizjLVW6Dkzqti+Q+YH4G4KvAaa+Lb3Sko9wIs7B1HQ4IGn6GUphMWelr3hmtqhLzL1+dvwA3v9FLMnGpzs5FOJL/3LAMfOpoM4vgcnit5hst1cWjqF73UW8FCqWLQLZ0WUBjjgXtxDbHJ4rQkkNHh2PT9SLJ50DUx6BA87jO6UxVJxbt8JSLoDKhcnlXRUmqo+IkYMkYfGqC3O2qg==')
INSERT [dbo].[PaymentTransactions] ([Id], [Status], [OrderId], [SurjoPayMsg], [CardNo], [BankTrnxId], [CardIssuerBank], [CardIssuerCountry], [Phone], [TrnxMethod], [Amount], [RiskLevel], [CreatedOn], [LastModifiedOn], [SurjoPayOrderId], [Address], [AmountInUSD], [BankStatus], [CardHolderName], [City], [Currency], [Email], [InvoiceId], [Name], [RateOfUSD], [SurjoPayCode], [UserVerificationToken]) VALUES (49, N'Initiated', 82, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(455.0000 AS Decimal(19, 4)), NULL, CAST(N'2022-01-26T14:37:45.2360864' AS DateTime2), CAST(N'2022-01-26T14:37:45.2361750' AS DateTime2), N'GAlFulyASXA+zUKnur16hkDdcKa42kZUCh8cujmBcj0=', NULL, CAST(0.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), 0, NULL)
INSERT [dbo].[PaymentTransactions] ([Id], [Status], [OrderId], [SurjoPayMsg], [CardNo], [BankTrnxId], [CardIssuerBank], [CardIssuerCountry], [Phone], [TrnxMethod], [Amount], [RiskLevel], [CreatedOn], [LastModifiedOn], [SurjoPayOrderId], [Address], [AmountInUSD], [BankStatus], [CardHolderName], [City], [Currency], [Email], [InvoiceId], [Name], [RateOfUSD], [SurjoPayCode], [UserVerificationToken]) VALUES (50, N'Completed', 83, N'Success', N'', N'9AQ7C2UHBZ', NULL, NULL, N'EQb31RkCyoExxUF1NbaVRg==', N'bkash', CAST(5.0000 AS Decimal(19, 4)), NULL, CAST(N'2022-01-26T14:38:52.3711994' AS DateTime2), CAST(N'2022-01-26T14:40:10.1014063' AS DateTime2), N'JwMbJyKFiys8i6pzFnAdj4UinPt4DMShQXbnEctpriQ=', N'N/A ', CAST(0.00 AS Decimal(18, 2)), N'The Payment was Successful', N'', N'Dhaka', N'BDT', N'O9AXvQAQR0Cy2j2JAKV9c14d0z/Xhz9EMWKTeeoeqms=', N'NLD61f15d3a6141e', N'Anonymous ', CAST(0.00 AS Decimal(18, 2)), 1000, N'E7pYbizjLVW6Dkzqti+Q+Xww/nMmjmJZEKX+hbX40tF8Iqcyw9Jwz+FHZ0nKO3m5tGQuMs1olUSEW+ZGvg1tZd4uCa2Zig7sEIZy8xlsiCHJstRJDq2tXx+OVUyJisAXU940OEKXO6zGR6u6BE4JuuJza9QHaKw0f35kecIGkr4fmUAiDxmAoN8YEdpTjbkeP17RugHujLjFCBARuegebw==')
INSERT [dbo].[PaymentTransactions] ([Id], [Status], [OrderId], [SurjoPayMsg], [CardNo], [BankTrnxId], [CardIssuerBank], [CardIssuerCountry], [Phone], [TrnxMethod], [Amount], [RiskLevel], [CreatedOn], [LastModifiedOn], [SurjoPayOrderId], [Address], [AmountInUSD], [BankStatus], [CardHolderName], [City], [Currency], [Email], [InvoiceId], [Name], [RateOfUSD], [SurjoPayCode], [UserVerificationToken]) VALUES (51, N'Completed', 84, N'Success', N'', N'9AQ7C4KI0X', NULL, NULL, N'EQb31RkCyoExxUF1NbaVRg==', N'bkash', CAST(5.0000 AS Decimal(19, 4)), NULL, CAST(N'2022-01-26T15:32:45.0947465' AS DateTime2), CAST(N'2022-01-26T15:33:42.5348244' AS DateTime2), N'gLlUS5AaBxExQH4wkG7e9LAZrmBpzt0NkL6Ld8zdWw8=', N'N/A ', CAST(0.00 AS Decimal(18, 2)), N'The Payment was Successful', N'', N'Dhaka', N'BDT', N'O9AXvQAQR0Cy2j2JAKV9c14d0z/Xhz9EMWKTeeoeqms=', N'NLD61f169db05190', N'Anonymous ', CAST(0.00 AS Decimal(18, 2)), 1000, N'E7pYbizjLVW6Dkzqti+Q+bKeYpR755vCEXWFD2ZnmAy+l854pnWGS/RFZ1mm9ZyV3+VpmwYjRwKhm/jXQh8xdv3GcWgz8Uh3dvZo1ZCviE71T7fKO+ONkVLB15b2V7FWZw2ZATv3qpdvbIZluijNDGy1I/T1SwnfHUkPk4ePJ6Jr0P6Bfsd+2Bj/5AcsUtlBd1ohyRbTPPsvmBV28009+w==')
INSERT [dbo].[PaymentTransactions] ([Id], [Status], [OrderId], [SurjoPayMsg], [CardNo], [BankTrnxId], [CardIssuerBank], [CardIssuerCountry], [Phone], [TrnxMethod], [Amount], [RiskLevel], [CreatedOn], [LastModifiedOn], [SurjoPayOrderId], [Address], [AmountInUSD], [BankStatus], [CardHolderName], [City], [Currency], [Email], [InvoiceId], [Name], [RateOfUSD], [SurjoPayCode], [UserVerificationToken]) VALUES (52, N'Completed', 85, N'Success', N'', N'9AR0C775O0', NULL, NULL, N'EQb31RkCyoExxUF1NbaVRg==', N'bkash', CAST(5.0000 AS Decimal(19, 4)), NULL, CAST(N'2022-01-26T18:15:45.5560792' AS DateTime2), CAST(N'2022-01-26T18:20:14.4011588' AS DateTime2), N'cgokyeIvuHSEOpI54aRmnMDOmkcfRtT2lGPJ8RabYbk=', N'N/A ', CAST(0.00 AS Decimal(18, 2)), N'The Payment was Successful', N'', N'Dhaka', N'BDT', N'O9AXvQAQR0Cy2j2JAKV9c14d0z/Xhz9EMWKTeeoeqms=', N'NLD61f1900fa7667', N'Anonymous ', CAST(0.00 AS Decimal(18, 2)), 1000, N'E7pYbizjLVW6Dkzqti+Q+dG/vrgYQ6cR9UhO2q7/9tBBSxADhN1huIdF69I4D7+DlwBrv9Y5KhX6Ee+jOSDzPyTgjSzTvpDiySyRbk2RfPwY7mRbHi09l37/mT8yJWqu0EGeQHK8vRvLf1u6zYOyE240MGjbfYndM+6fc6Puw/qWDTqFbL5Mb9YidZ+oWnOUggN1loVAE1fjv2DcmTVsIA==')
INSERT [dbo].[PaymentTransactions] ([Id], [Status], [OrderId], [SurjoPayMsg], [CardNo], [BankTrnxId], [CardIssuerBank], [CardIssuerCountry], [Phone], [TrnxMethod], [Amount], [RiskLevel], [CreatedOn], [LastModifiedOn], [SurjoPayOrderId], [Address], [AmountInUSD], [BankStatus], [CardHolderName], [City], [Currency], [Email], [InvoiceId], [Name], [RateOfUSD], [SurjoPayCode], [UserVerificationToken]) VALUES (53, N'Initiated', 86, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(5.0000 AS Decimal(19, 4)), NULL, CAST(N'2022-01-27T06:41:55.2329469' AS DateTime2), CAST(N'2022-01-27T06:41:55.2331097' AS DateTime2), N'hIUW+dH79f1rXJkLBNzHBZWydQUHuf6Js3L+P7GGNHU=', NULL, CAST(0.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), 0, NULL)
INSERT [dbo].[PaymentTransactions] ([Id], [Status], [OrderId], [SurjoPayMsg], [CardNo], [BankTrnxId], [CardIssuerBank], [CardIssuerCountry], [Phone], [TrnxMethod], [Amount], [RiskLevel], [CreatedOn], [LastModifiedOn], [SurjoPayOrderId], [Address], [AmountInUSD], [BankStatus], [CardHolderName], [City], [Currency], [Email], [InvoiceId], [Name], [RateOfUSD], [SurjoPayCode], [UserVerificationToken]) VALUES (54, N'Completed', 87, N'Success', N'', N'9AR3CHDHT5', NULL, NULL, N'EQb31RkCyoExxUF1NbaVRg==', N'bkash', CAST(5.0000 AS Decimal(19, 4)), NULL, CAST(N'2022-01-27T07:36:56.1361809' AS DateTime2), CAST(N'2022-01-27T12:02:26.9813634' AS DateTime2), N'dBAKAX0tWVurZP2am2j/CWGMAorD+dQOdDfTplFZOyQ=', N'N/A ', CAST(0.00 AS Decimal(18, 2)), N'The Payment was Successful', N'', N'Dhaka', N'BDT', N'O9AXvQAQR0Cy2j2JAKV9c14d0z/Xhz9EMWKTeeoeqms=', N'NLD61f24bd694be2', N'Anonymous ', CAST(0.00 AS Decimal(18, 2)), 1000, N'E7pYbizjLVW6Dkzqti+Q+QmGl/bDLA1ehHXoySSH3bYcK29ql0DAv4lnfCr5+FhQXJ75nQDtwB8BEOXkN1BgOqFnyD6rEVcP/S3uqVeJusWaMr3VHB1gth+lhMZa3AzO3LJy3lEHvDiD8xkioG20GkgvA4DIQ7rqz7gxq+OMqQxm9kCjBHl+dXelBjv5LhqXzIWG97G8XPoWM2Y6SnUNcg==')
INSERT [dbo].[PaymentTransactions] ([Id], [Status], [OrderId], [SurjoPayMsg], [CardNo], [BankTrnxId], [CardIssuerBank], [CardIssuerCountry], [Phone], [TrnxMethod], [Amount], [RiskLevel], [CreatedOn], [LastModifiedOn], [SurjoPayOrderId], [Address], [AmountInUSD], [BankStatus], [CardHolderName], [City], [Currency], [Email], [InvoiceId], [Name], [RateOfUSD], [SurjoPayCode], [UserVerificationToken]) VALUES (55, N'Completed', 88, N'Success', N'', N'9AR3CQY3OJ', NULL, NULL, N'EQb31RkCyoExxUF1NbaVRg==', N'bkash', CAST(5.0000 AS Decimal(19, 4)), NULL, CAST(N'2022-01-27T12:43:28.4775404' AS DateTime2), CAST(N'2022-02-13T13:08:02.5190616' AS DateTime2), N'8cXN4/sXaRX7vUNLIa0Mrg21/af8uv9NQMLY5Y0cHEA=', N'N/A ', CAST(0.00 AS Decimal(18, 2)), N'The Payment was Successful', N'', N'Dhaka', N'BDT', N'O9AXvQAQR0Cy2j2JAKV9c14d0z/Xhz9EMWKTeeoeqms=', N'NLD61f293aeef24a', N'Anonymous ', CAST(0.00 AS Decimal(18, 2)), 1000, N'E7pYbizjLVW6Dkzqti+Q+ZOh3kk31qooWgDgdWa0a1rgVqoKcM/4ucvTJtNy0ihNJENUVynqSaaZphWlw1Aj2m4f0xn7aKKOeD6jYs3cEJC+tZ3OVOROmBoP9G+/l9hrm2RBXVlGjGHt5JEs8yuWSakrPsdu0avP4WZE6x0WwMgFo8jInVGk6Cg/5ZFBc6v86id975kWki/E5n8THhRuMg==')
INSERT [dbo].[PaymentTransactions] ([Id], [Status], [OrderId], [SurjoPayMsg], [CardNo], [BankTrnxId], [CardIssuerBank], [CardIssuerCountry], [Phone], [TrnxMethod], [Amount], [RiskLevel], [CreatedOn], [LastModifiedOn], [SurjoPayOrderId], [Address], [AmountInUSD], [BankStatus], [CardHolderName], [City], [Currency], [Email], [InvoiceId], [Name], [RateOfUSD], [SurjoPayCode], [UserVerificationToken]) VALUES (56, N'Initiated', 89, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(450.0000 AS Decimal(19, 4)), NULL, CAST(N'2022-02-02T16:30:49.3206041' AS DateTime2), CAST(N'2022-02-02T16:30:49.3206854' AS DateTime2), N'VT2FU2mgjOnph9OSSHs1XY5Tc5Z/FtP0I0oSe3nleDI=', NULL, CAST(0.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), 0, NULL)
INSERT [dbo].[PaymentTransactions] ([Id], [Status], [OrderId], [SurjoPayMsg], [CardNo], [BankTrnxId], [CardIssuerBank], [CardIssuerCountry], [Phone], [TrnxMethod], [Amount], [RiskLevel], [CreatedOn], [LastModifiedOn], [SurjoPayOrderId], [Address], [AmountInUSD], [BankStatus], [CardHolderName], [City], [Currency], [Email], [InvoiceId], [Name], [RateOfUSD], [SurjoPayCode], [UserVerificationToken]) VALUES (57, N'Completed', 90, N'Success', N'', N'9B68KC6R80', NULL, NULL, N'EQb31RkCyoExxUF1NbaVRg==', N'bkash', CAST(5.0000 AS Decimal(19, 4)), NULL, CAST(N'2022-02-06T07:09:04.1769289' AS DateTime2), CAST(N'2022-02-13T13:08:10.8112310' AS DateTime2), N'KvvNwGLUBe4MvdplV0mdHg12bpIJYHrUV9n9hZO3Smg=', N'N/A ', CAST(0.00 AS Decimal(18, 2)), N'The Payment was Successful', N'', N'Dhaka', N'BDT', N'O9AXvQAQR0Cy2j2JAKV9c14d0z/Xhz9EMWKTeeoeqms=', N'NLD61ff7454b25c0', N'Anonymous ', CAST(0.00 AS Decimal(18, 2)), 1000, N'E7pYbizjLVW6Dkzqti+Q+ctpaZaAXKXkmywYEFOfBdDnuthRoFBe7IfYLMPnHdn/ogCo/dHe/hFpR8jFwN8LP0GhxZcxe4oSk9yIM1DuX479GcuIAv8GXUjzA/5rIntjhr9cN8Moqz8ZxJb/gQa4h5mqRx+cdT/suY5pm5nrfwdStLaXG0xAxAffQhgj+fon5A5BPhmg7qOyk7G/K8d12A==')
INSERT [dbo].[PaymentTransactions] ([Id], [Status], [OrderId], [SurjoPayMsg], [CardNo], [BankTrnxId], [CardIssuerBank], [CardIssuerCountry], [Phone], [TrnxMethod], [Amount], [RiskLevel], [CreatedOn], [LastModifiedOn], [SurjoPayOrderId], [Address], [AmountInUSD], [BankStatus], [CardHolderName], [City], [Currency], [Email], [InvoiceId], [Name], [RateOfUSD], [SurjoPayCode], [UserVerificationToken]) VALUES (58, N'Completed', 91, N'Success', N'', N'9B60KCQ5MU', NULL, NULL, N'EQb31RkCyoExxUF1NbaVRg==', N'bkash', CAST(5.0000 AS Decimal(19, 4)), NULL, CAST(N'2022-02-06T07:27:44.1589474' AS DateTime2), CAST(N'2022-02-13T13:08:14.6824317' AS DateTime2), N'eNovi8fgOLnjk4vkz8Ag+a54F9NC7Z9lHooK6m8Hyk4=', N'N/A ', CAST(0.00 AS Decimal(18, 2)), N'The Payment was Successful', N'', N'Dhaka', N'BDT', N'O9AXvQAQR0Cy2j2JAKV9c14d0z/Xhz9EMWKTeeoeqms=', N'NLD61ff78b4b438a', N'Anonymous ', CAST(0.00 AS Decimal(18, 2)), 1000, N'E7pYbizjLVW6Dkzqti+Q+TlXIi3rXwnzurK5l4NuaW/EOZgLnPLmFYrac+neNfq5wWugEjA+mZcuF6pBW8hXBJT2biJD7op6mtQAUZ37ONHjI5JN5O4tTLM/qhaVSM6KP2U6V8Xj6+HQbdbiSwxMB8uYkOyNX+i8jqWOuCQx+tDk6CvWQg0lS4k3c32ViglnKTzlFwXlCLmgAjJVt+YvLQ==')
SET IDENTITY_INSERT [dbo].[PaymentTransactions] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductCategories] ON 

INSERT [dbo].[ProductCategories] ([Id], [Name], [ImageUrl], [Overview], [WhatCanBeDone], [HowToConsume], [Limitations], [CreatedOn], [LastModifiedOn]) VALUES (4, N'Amazon Gift Cards', N'ImageResources\ProductCategory\ProductCategory_1e0c8ae5-ce19-41ca-af14-b6524eb24d08.jpg', N'Buy gift cards and redeem on amazon.com', NULL, NULL, NULL, CAST(N'2020-10-11T02:43:49.6956183' AS DateTime2), CAST(N'2020-10-11T02:43:49.6958008' AS DateTime2))
INSERT [dbo].[ProductCategories] ([Id], [Name], [ImageUrl], [Overview], [WhatCanBeDone], [HowToConsume], [Limitations], [CreatedOn], [LastModifiedOn]) VALUES (5, N'Google Play Gift Cards', N'ImageResources\ProductCategory\ProductCategory_243086db-054d-4cd8-90a3-f407abd165d8.jpg', N'Buy gift cards and redeem on google play account', NULL, NULL, NULL, CAST(N'2020-10-11T02:45:24.0952658' AS DateTime2), CAST(N'2020-10-11T02:45:24.0952670' AS DateTime2))
INSERT [dbo].[ProductCategories] ([Id], [Name], [ImageUrl], [Overview], [WhatCanBeDone], [HowToConsume], [Limitations], [CreatedOn], [LastModifiedOn]) VALUES (6, N'Steam Wallet Codes', N'ImageResources\ProductCategory\ProductCategory_1cc687c6-50ed-4100-9c25-dd3a154b1aff.jpg', N'Buy steam wallet codes', NULL, NULL, NULL, CAST(N'2020-10-11T02:46:16.0128210' AS DateTime2), CAST(N'2020-10-11T02:46:16.0128221' AS DateTime2))
INSERT [dbo].[ProductCategories] ([Id], [Name], [ImageUrl], [Overview], [WhatCanBeDone], [HowToConsume], [Limitations], [CreatedOn], [LastModifiedOn]) VALUES (7, N'Miscellaneous Gift Cards', N'ImageResources\ProductCategory\ProductCategory_c219bbd5-5b6f-40ce-a3e3-94e01eeb5535.jpg', N'Buy iTunes, virtual visa gift cards', NULL, NULL, NULL, CAST(N'2020-10-11T08:46:32.7080786' AS DateTime2), CAST(N'2020-10-11T08:46:32.7080799' AS DateTime2))
INSERT [dbo].[ProductCategories] ([Id], [Name], [ImageUrl], [Overview], [WhatCanBeDone], [HowToConsume], [Limitations], [CreatedOn], [LastModifiedOn]) VALUES (8, N'Microsoft Software License', N'ImageResources\ProductCategory\ProductCategory_60336939-0737-4c7b-ad4c-d0b7a60fd24a.png', N'Buy MS office 2020, windows 10 license keys', NULL, NULL, NULL, CAST(N'2020-10-11T08:48:00.3613718' AS DateTime2), CAST(N'2020-10-11T08:48:00.3613730' AS DateTime2))
INSERT [dbo].[ProductCategories] ([Id], [Name], [ImageUrl], [Overview], [WhatCanBeDone], [HowToConsume], [Limitations], [CreatedOn], [LastModifiedOn]) VALUES (9, N'Antivirus Software', N'ImageResources\ProductCategory\ProductCategory_67d78f84-f92d-492e-acbe-24f96c3e21ef.jpg', N'Buy antivirus software like Kaspersky', NULL, NULL, NULL, CAST(N'2020-10-11T08:48:35.7169023' AS DateTime2), CAST(N'2020-10-11T08:48:35.7169034' AS DateTime2))
INSERT [dbo].[ProductCategories] ([Id], [Name], [ImageUrl], [Overview], [WhatCanBeDone], [HowToConsume], [Limitations], [CreatedOn], [LastModifiedOn]) VALUES (10, N'Steam Game Cd Keys', N'ImageResources\ProductCategory\ProductCategory_ac95c83b-98a3-4025-9cbe-ddd3eca03f83.jpg', N'Buy overwatch game activation key', NULL, NULL, NULL, CAST(N'2020-10-11T08:49:41.9373761' AS DateTime2), CAST(N'2020-10-11T08:49:41.9373771' AS DateTime2))
INSERT [dbo].[ProductCategories] ([Id], [Name], [ImageUrl], [Overview], [WhatCanBeDone], [HowToConsume], [Limitations], [CreatedOn], [LastModifiedOn]) VALUES (11, N'EA Sports Game Cd Keys', N'ImageResources\ProductCategory\ProductCategory_cb64c160-c3b9-4563-9051-8798023384ad.jpg', N'Buy Fifa 21 Game Cd Key', NULL, NULL, NULL, CAST(N'2020-10-11T08:50:20.9477819' AS DateTime2), CAST(N'2020-10-11T08:50:20.9477830' AS DateTime2))
SET IDENTITY_INSERT [dbo].[ProductCategories] OFF
GO
INSERT [dbo].[ProductCategoryJoinProductGroup] ([ProductCategoryId], [ProductGroupId]) VALUES (4, 4)
INSERT [dbo].[ProductCategoryJoinProductGroup] ([ProductCategoryId], [ProductGroupId]) VALUES (5, 4)
INSERT [dbo].[ProductCategoryJoinProductGroup] ([ProductCategoryId], [ProductGroupId]) VALUES (6, 4)
INSERT [dbo].[ProductCategoryJoinProductGroup] ([ProductCategoryId], [ProductGroupId]) VALUES (7, 4)
INSERT [dbo].[ProductCategoryJoinProductGroup] ([ProductCategoryId], [ProductGroupId]) VALUES (8, 6)
INSERT [dbo].[ProductCategoryJoinProductGroup] ([ProductCategoryId], [ProductGroupId]) VALUES (9, 6)
INSERT [dbo].[ProductCategoryJoinProductGroup] ([ProductCategoryId], [ProductGroupId]) VALUES (10, 5)
INSERT [dbo].[ProductCategoryJoinProductGroup] ([ProductCategoryId], [ProductGroupId]) VALUES (11, 5)
GO
SET IDENTITY_INSERT [dbo].[ProductGroups] ON 

INSERT [dbo].[ProductGroups] ([Id], [Name], [ImageUrl], [Overview], [WhatCanBeDone], [HowToConsume], [Limitations], [CreatedOn], [LastModifiedOn]) VALUES (4, N'Gift Cards', N'ImageResources\ProductGroup\ProductGroup_3d954a6d-4f5e-49d6-a94f-210c9405fd3c.jpg', N'Choose your gift card and avail desired services', NULL, NULL, NULL, CAST(N'2020-10-11T02:36:02.0000000' AS DateTime2), CAST(N'2020-10-11T08:55:44.8034846' AS DateTime2))
INSERT [dbo].[ProductGroups] ([Id], [Name], [ImageUrl], [Overview], [WhatCanBeDone], [HowToConsume], [Limitations], [CreatedOn], [LastModifiedOn]) VALUES (5, N'Game Cd Keys', N'ImageResources\ProductGroup\ProductGroup_955cca4b-4e6c-465e-85f9-520eeac045db.jpg', N'Enjoy video gaming', NULL, NULL, NULL, CAST(N'2020-10-11T02:36:27.0000000' AS DateTime2), CAST(N'2020-10-11T08:55:54.2041183' AS DateTime2))
INSERT [dbo].[ProductGroups] ([Id], [Name], [ImageUrl], [Overview], [WhatCanBeDone], [HowToConsume], [Limitations], [CreatedOn], [LastModifiedOn]) VALUES (6, N'Software License Keys', N'ImageResources\ProductGroup\ProductGroup_1df478bf-d24e-484f-af67-ad42659f54c2.jpg', N'Buy software licenses', NULL, NULL, NULL, CAST(N'2020-10-11T02:36:53.0000000' AS DateTime2), CAST(N'2020-10-11T08:56:04.2397781' AS DateTime2))
SET IDENTITY_INSERT [dbo].[ProductGroups] OFF
GO
INSERT [dbo].[ProductItemBundleJoinProductItems] ([ProductItemBundleId], [ProductItemId], [ProductItemQuantity]) VALUES (1, 11, 2)
INSERT [dbo].[ProductItemBundleJoinProductItems] ([ProductItemBundleId], [ProductItemId], [ProductItemQuantity]) VALUES (1, 12, 1)
INSERT [dbo].[ProductItemBundleJoinProductItems] ([ProductItemBundleId], [ProductItemId], [ProductItemQuantity]) VALUES (3, 11, 1)
INSERT [dbo].[ProductItemBundleJoinProductItems] ([ProductItemBundleId], [ProductItemId], [ProductItemQuantity]) VALUES (3, 13, 1)
INSERT [dbo].[ProductItemBundleJoinProductItems] ([ProductItemBundleId], [ProductItemId], [ProductItemQuantity]) VALUES (3, 14, 1)
INSERT [dbo].[ProductItemBundleJoinProductItems] ([ProductItemBundleId], [ProductItemId], [ProductItemQuantity]) VALUES (4, 10, 1)
INSERT [dbo].[ProductItemBundleJoinProductItems] ([ProductItemBundleId], [ProductItemId], [ProductItemQuantity]) VALUES (4, 11, 1)
INSERT [dbo].[ProductItemBundleJoinProductItems] ([ProductItemBundleId], [ProductItemId], [ProductItemQuantity]) VALUES (5, 1, 12)
INSERT [dbo].[ProductItemBundleJoinProductItems] ([ProductItemBundleId], [ProductItemId], [ProductItemQuantity]) VALUES (5, 4, 12)
INSERT [dbo].[ProductItemBundleJoinProductItems] ([ProductItemBundleId], [ProductItemId], [ProductItemQuantity]) VALUES (6, 1, 2)
INSERT [dbo].[ProductItemBundleJoinProductItems] ([ProductItemBundleId], [ProductItemId], [ProductItemQuantity]) VALUES (6, 2, 2)
INSERT [dbo].[ProductItemBundleJoinProductItems] ([ProductItemBundleId], [ProductItemId], [ProductItemQuantity]) VALUES (7, 11, 1)
INSERT [dbo].[ProductItemBundleJoinProductItems] ([ProductItemBundleId], [ProductItemId], [ProductItemQuantity]) VALUES (7, 13, 1)
GO
SET IDENTITY_INSERT [dbo].[ProductItemBundles] ON 

INSERT [dbo].[ProductItemBundles] ([Id], [Name], [BundleDiscount], [IsActiveNow], [CreatedOn]) VALUES (1, N'Windows and Visa', CAST(110.0000 AS Decimal(19, 4)), 1, CAST(N'2021-12-24T18:11:00.0000000' AS DateTime2))
INSERT [dbo].[ProductItemBundles] ([Id], [Name], [BundleDiscount], [IsActiveNow], [CreatedOn]) VALUES (3, N'Utility Apps and Visa', CAST(150.0000 AS Decimal(19, 4)), 1, CAST(N'2021-12-25T08:08:05.0000000' AS DateTime2))
INSERT [dbo].[ProductItemBundles] ([Id], [Name], [BundleDiscount], [IsActiveNow], [CreatedOn]) VALUES (4, N'Startech', CAST(250.0000 AS Decimal(19, 4)), 1, CAST(N'2021-12-25T16:04:45.5996179' AS DateTime2))
INSERT [dbo].[ProductItemBundles] ([Id], [Name], [BundleDiscount], [IsActiveNow], [CreatedOn]) VALUES (5, N'Boishaki Pack', CAST(1110.0000 AS Decimal(19, 4)), 1, CAST(N'2021-12-25T16:05:10.0000000' AS DateTime2))
INSERT [dbo].[ProductItemBundles] ([Id], [Name], [BundleDiscount], [IsActiveNow], [CreatedOn]) VALUES (6, N'Amazonia', CAST(22.0000 AS Decimal(19, 4)), 1, CAST(N'2021-12-25T16:06:05.0000000' AS DateTime2))
INSERT [dbo].[ProductItemBundles] ([Id], [Name], [BundleDiscount], [IsActiveNow], [CreatedOn]) VALUES (7, N'Ionic Bundle', CAST(33.0000 AS Decimal(19, 4)), 1, CAST(N'2021-12-25T16:06:17.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[ProductItemBundles] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductItemFeatures] ON 

INSERT [dbo].[ProductItemFeatures] ([Id], [ProductItemId], [Company], [Developer], [Publisher], [Description], [RegionCodes], [RegionCountries], [DeliveryInfo], [ValidityPeriod], [Genre], [Os], [Platform], [ReleaseDate], [RequirementCpu], [RequirementRam], [RequirementGpu], [RequirementDisk], [DownloadSize], [CreatedOn], [LastModifiedOn]) VALUES (1, 1, N'Amazon ', NULL, NULL, NULL, N'USA', N'', N'Digital', N'Lifetime', N'', N'', N'', NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2020-10-08T15:19:51.7560911' AS DateTime2), CAST(N'2020-10-08T15:19:51.7560915' AS DateTime2))
INSERT [dbo].[ProductItemFeatures] ([Id], [ProductItemId], [Company], [Developer], [Publisher], [Description], [RegionCodes], [RegionCountries], [DeliveryInfo], [ValidityPeriod], [Genre], [Os], [Platform], [ReleaseDate], [RequirementCpu], [RequirementRam], [RequirementGpu], [RequirementDisk], [DownloadSize], [CreatedOn], [LastModifiedOn]) VALUES (2, 2, N'Amazon ', NULL, NULL, NULL, N'USA', N'', N'Digital', N'Lifetime', N'', N'', N'', NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2020-10-08T15:58:29.1802860' AS DateTime2), CAST(N'2020-10-08T15:58:29.1802868' AS DateTime2))
INSERT [dbo].[ProductItemFeatures] ([Id], [ProductItemId], [Company], [Developer], [Publisher], [Description], [RegionCodes], [RegionCountries], [DeliveryInfo], [ValidityPeriod], [Genre], [Os], [Platform], [ReleaseDate], [RequirementCpu], [RequirementRam], [RequirementGpu], [RequirementDisk], [DownloadSize], [CreatedOn], [LastModifiedOn]) VALUES (3, 3, N'Amazon ', NULL, NULL, NULL, N'USA', N'', N'Digital', N'Lifetime', N'', N'', N'', NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2020-10-09T08:58:22.5464353' AS DateTime2), CAST(N'2020-10-09T08:58:22.5464356' AS DateTime2))
INSERT [dbo].[ProductItemFeatures] ([Id], [ProductItemId], [Company], [Developer], [Publisher], [Description], [RegionCodes], [RegionCountries], [DeliveryInfo], [ValidityPeriod], [Genre], [Os], [Platform], [ReleaseDate], [RequirementCpu], [RequirementRam], [RequirementGpu], [RequirementDisk], [DownloadSize], [CreatedOn], [LastModifiedOn]) VALUES (4, 4, N'Google Inc.', NULL, NULL, NULL, N'USA', N'', N'Digital', N'Lifetime', N'', N'', N'', NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2020-10-09T09:00:17.2499877' AS DateTime2), CAST(N'2020-10-09T09:00:17.2499885' AS DateTime2))
INSERT [dbo].[ProductItemFeatures] ([Id], [ProductItemId], [Company], [Developer], [Publisher], [Description], [RegionCodes], [RegionCountries], [DeliveryInfo], [ValidityPeriod], [Genre], [Os], [Platform], [ReleaseDate], [RequirementCpu], [RequirementRam], [RequirementGpu], [RequirementDisk], [DownloadSize], [CreatedOn], [LastModifiedOn]) VALUES (5, 5, N'Google Inc.', NULL, NULL, NULL, N'USA', N'', N'Digital', N'Lifetime', N'', N'', N'', NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2020-10-09T09:01:25.3825858' AS DateTime2), CAST(N'2020-10-09T09:01:25.3825866' AS DateTime2))
INSERT [dbo].[ProductItemFeatures] ([Id], [ProductItemId], [Company], [Developer], [Publisher], [Description], [RegionCodes], [RegionCountries], [DeliveryInfo], [ValidityPeriod], [Genre], [Os], [Platform], [ReleaseDate], [RequirementCpu], [RequirementRam], [RequirementGpu], [RequirementDisk], [DownloadSize], [CreatedOn], [LastModifiedOn]) VALUES (6, 6, N'Google Inc.', NULL, NULL, NULL, N'USA', N'', N'Digital', N'Lifetime', N'', N'', N'', NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2020-10-09T09:02:43.1808470' AS DateTime2), CAST(N'2020-10-09T09:02:43.1808477' AS DateTime2))
INSERT [dbo].[ProductItemFeatures] ([Id], [ProductItemId], [Company], [Developer], [Publisher], [Description], [RegionCodes], [RegionCountries], [DeliveryInfo], [ValidityPeriod], [Genre], [Os], [Platform], [ReleaseDate], [RequirementCpu], [RequirementRam], [RequirementGpu], [RequirementDisk], [DownloadSize], [CreatedOn], [LastModifiedOn]) VALUES (7, 7, N'Valve Co.', NULL, NULL, NULL, N'GLOBAL', N'', N'Digital', N'Lifetime', N'', N'', N'', NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2020-10-09T09:04:28.1497124' AS DateTime2), CAST(N'2020-10-09T09:04:28.1497127' AS DateTime2))
INSERT [dbo].[ProductItemFeatures] ([Id], [ProductItemId], [Company], [Developer], [Publisher], [Description], [RegionCodes], [RegionCountries], [DeliveryInfo], [ValidityPeriod], [Genre], [Os], [Platform], [ReleaseDate], [RequirementCpu], [RequirementRam], [RequirementGpu], [RequirementDisk], [DownloadSize], [CreatedOn], [LastModifiedOn]) VALUES (8, 8, N'Valve Co.', NULL, NULL, NULL, N'GLOBAL', N'', N'Digital', N'Lifetime', N'', N'', N'', NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2020-10-09T09:13:58.8368239' AS DateTime2), CAST(N'2020-10-09T09:13:58.8368243' AS DateTime2))
INSERT [dbo].[ProductItemFeatures] ([Id], [ProductItemId], [Company], [Developer], [Publisher], [Description], [RegionCodes], [RegionCountries], [DeliveryInfo], [ValidityPeriod], [Genre], [Os], [Platform], [ReleaseDate], [RequirementCpu], [RequirementRam], [RequirementGpu], [RequirementDisk], [DownloadSize], [CreatedOn], [LastModifiedOn]) VALUES (9, 9, N'Valve Co.', NULL, NULL, NULL, N'', N'', N'Digital', N'Lifetime', N'', N'', N'', NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2020-10-09T09:15:18.8008745' AS DateTime2), CAST(N'2020-10-09T09:15:18.8008748' AS DateTime2))
INSERT [dbo].[ProductItemFeatures] ([Id], [ProductItemId], [Company], [Developer], [Publisher], [Description], [RegionCodes], [RegionCountries], [DeliveryInfo], [ValidityPeriod], [Genre], [Os], [Platform], [ReleaseDate], [RequirementCpu], [RequirementRam], [RequirementGpu], [RequirementDisk], [DownloadSize], [CreatedOn], [LastModifiedOn]) VALUES (10, 10, N'Apple Inc.', NULL, NULL, NULL, N'USA', N'', N'Digital', N'Lifetime', N'', N'', N'', NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2020-10-09T09:22:06.8613295' AS DateTime2), CAST(N'2020-10-09T09:22:06.8613300' AS DateTime2))
INSERT [dbo].[ProductItemFeatures] ([Id], [ProductItemId], [Company], [Developer], [Publisher], [Description], [RegionCodes], [RegionCountries], [DeliveryInfo], [ValidityPeriod], [Genre], [Os], [Platform], [ReleaseDate], [RequirementCpu], [RequirementRam], [RequirementGpu], [RequirementDisk], [DownloadSize], [CreatedOn], [LastModifiedOn]) VALUES (11, 11, NULL, NULL, NULL, NULL, N'', N'', NULL, NULL, N'', N'', N'', NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2020-10-09T09:24:09.6141381' AS DateTime2), CAST(N'2020-10-09T09:24:09.6141389' AS DateTime2))
INSERT [dbo].[ProductItemFeatures] ([Id], [ProductItemId], [Company], [Developer], [Publisher], [Description], [RegionCodes], [RegionCountries], [DeliveryInfo], [ValidityPeriod], [Genre], [Os], [Platform], [ReleaseDate], [RequirementCpu], [RequirementRam], [RequirementGpu], [RequirementDisk], [DownloadSize], [CreatedOn], [LastModifiedOn]) VALUES (12, 12, N'Microsoft', NULL, NULL, NULL, N'', N'Worldwide', N'Digital', N'Lifetime', N'Operating System License', N'', N'', NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2020-10-09T09:27:16.5117743' AS DateTime2), CAST(N'2020-10-09T09:27:16.5117747' AS DateTime2))
INSERT [dbo].[ProductItemFeatures] ([Id], [ProductItemId], [Company], [Developer], [Publisher], [Description], [RegionCodes], [RegionCountries], [DeliveryInfo], [ValidityPeriod], [Genre], [Os], [Platform], [ReleaseDate], [RequirementCpu], [RequirementRam], [RequirementGpu], [RequirementDisk], [DownloadSize], [CreatedOn], [LastModifiedOn]) VALUES (13, 13, N'Microsoft', NULL, NULL, NULL, N'GLOBAL', N'Worldwide', N'Digital', N'Lifetime', N'Office Utility Software', N'', N'', NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2020-10-09T09:29:04.6342532' AS DateTime2), CAST(N'2020-10-09T09:29:04.6342536' AS DateTime2))
INSERT [dbo].[ProductItemFeatures] ([Id], [ProductItemId], [Company], [Developer], [Publisher], [Description], [RegionCodes], [RegionCountries], [DeliveryInfo], [ValidityPeriod], [Genre], [Os], [Platform], [ReleaseDate], [RequirementCpu], [RequirementRam], [RequirementGpu], [RequirementDisk], [DownloadSize], [CreatedOn], [LastModifiedOn]) VALUES (14, 14, N'Kaspersky Lab', NULL, NULL, NULL, N'', N'', N'Digital', N'Lifetime', N'', N'', N'', NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2020-10-09T09:40:31.7062814' AS DateTime2), CAST(N'2020-10-09T09:40:31.7062822' AS DateTime2))
INSERT [dbo].[ProductItemFeatures] ([Id], [ProductItemId], [Company], [Developer], [Publisher], [Description], [RegionCodes], [RegionCountries], [DeliveryInfo], [ValidityPeriod], [Genre], [Os], [Platform], [ReleaseDate], [RequirementCpu], [RequirementRam], [RequirementGpu], [RequirementDisk], [DownloadSize], [CreatedOn], [LastModifiedOn]) VALUES (15, 15, N'Blizzard Entertainment', N'Blizzard Entertainment, Iron Galazy', N'Blizzard Entertainment', N'Overwatch is a team-based multiplayer first-person shooter developed and published by Blizzard Entertainment.', N'GLOBAL', N'Worldwide', N'Digital', N'Lifetime', N'Online Multiplayer Video Game,Shooter', N'Windows', N'', CAST(N'2020-10-09T00:00:00.0000000' AS DateTime2), N'Intel core i3 3230 or Amd ryzen 3', N'4 GB', N'2 GB', N'20 GB', N'10 GB', CAST(N'2020-10-09T09:44:38.3428568' AS DateTime2), CAST(N'2020-10-09T09:44:38.3428571' AS DateTime2))
INSERT [dbo].[ProductItemFeatures] ([Id], [ProductItemId], [Company], [Developer], [Publisher], [Description], [RegionCodes], [RegionCountries], [DeliveryInfo], [ValidityPeriod], [Genre], [Os], [Platform], [ReleaseDate], [RequirementCpu], [RequirementRam], [RequirementGpu], [RequirementDisk], [DownloadSize], [CreatedOn], [LastModifiedOn]) VALUES (16, 16, N'Electronic Arts ', N'Electronic Arts ', N'Electronic Arts ', N'FIFA 21 is a football simulation video game published by Electronic Arts as part of the FIFA series. It is the 28th installment in the FIFA series, and will be released today for Microsoft Windows, Nintendo Switch, PlayStation 4 and Xbox One consoles.', N'GLOBAL', N'Worldwide', N'Digital', N'Lifetime', N'Online Multiplayer Video Game', N'Windows', N'', CAST(N'2020-10-06T00:00:00.0000000' AS DateTime2), N'Intel Core i5 or Amd ryzen 5', N'8 GB', N'4 GB', N'80 GB', N'50 GB', CAST(N'2020-10-09T09:47:26.4155643' AS DateTime2), CAST(N'2020-10-09T09:47:26.4155651' AS DateTime2))
INSERT [dbo].[ProductItemFeatures] ([Id], [ProductItemId], [Company], [Developer], [Publisher], [Description], [RegionCodes], [RegionCountries], [DeliveryInfo], [ValidityPeriod], [Genre], [Os], [Platform], [ReleaseDate], [RequirementCpu], [RequirementRam], [RequirementGpu], [RequirementDisk], [DownloadSize], [CreatedOn], [LastModifiedOn]) VALUES (18, 18, N'Test', NULL, NULL, N'Test', N'', N'', NULL, NULL, N'', N'', N'', NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2021-12-19T11:28:38.0000000' AS DateTime2), CAST(N'2022-01-26T14:34:04.8252957' AS DateTime2))
SET IDENTITY_INSERT [dbo].[ProductItemFeatures] OFF
GO
INSERT [dbo].[ProductItemJoinProductCategory] ([ProductItemId], [ProductCategoryId]) VALUES (1, 4)
INSERT [dbo].[ProductItemJoinProductCategory] ([ProductItemId], [ProductCategoryId]) VALUES (2, 4)
INSERT [dbo].[ProductItemJoinProductCategory] ([ProductItemId], [ProductCategoryId]) VALUES (3, 4)
INSERT [dbo].[ProductItemJoinProductCategory] ([ProductItemId], [ProductCategoryId]) VALUES (4, 5)
INSERT [dbo].[ProductItemJoinProductCategory] ([ProductItemId], [ProductCategoryId]) VALUES (5, 5)
INSERT [dbo].[ProductItemJoinProductCategory] ([ProductItemId], [ProductCategoryId]) VALUES (6, 5)
INSERT [dbo].[ProductItemJoinProductCategory] ([ProductItemId], [ProductCategoryId]) VALUES (8, 6)
INSERT [dbo].[ProductItemJoinProductCategory] ([ProductItemId], [ProductCategoryId]) VALUES (9, 6)
INSERT [dbo].[ProductItemJoinProductCategory] ([ProductItemId], [ProductCategoryId]) VALUES (10, 7)
INSERT [dbo].[ProductItemJoinProductCategory] ([ProductItemId], [ProductCategoryId]) VALUES (11, 7)
INSERT [dbo].[ProductItemJoinProductCategory] ([ProductItemId], [ProductCategoryId]) VALUES (12, 8)
INSERT [dbo].[ProductItemJoinProductCategory] ([ProductItemId], [ProductCategoryId]) VALUES (13, 8)
INSERT [dbo].[ProductItemJoinProductCategory] ([ProductItemId], [ProductCategoryId]) VALUES (14, 9)
INSERT [dbo].[ProductItemJoinProductCategory] ([ProductItemId], [ProductCategoryId]) VALUES (15, 10)
INSERT [dbo].[ProductItemJoinProductCategory] ([ProductItemId], [ProductCategoryId]) VALUES (16, 11)
INSERT [dbo].[ProductItemJoinProductCategory] ([ProductItemId], [ProductCategoryId]) VALUES (18, 7)
GO
SET IDENTITY_INSERT [dbo].[ProductItemPrices] ON 

INSERT [dbo].[ProductItemPrices] ([Id], [ProductItemId], [PriceCurrency], [Price], [Discount], [Vat], [CreatedOn], [LastModifiedOn]) VALUES (1, 1, N'BDT', CAST(460.0000 AS Decimal(19, 4)), CAST(10.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(N'2020-10-08T15:19:51.8900000' AS DateTime2), CAST(N'2020-10-08T15:19:51.8900000' AS DateTime2))
INSERT [dbo].[ProductItemPrices] ([Id], [ProductItemId], [PriceCurrency], [Price], [Discount], [Vat], [CreatedOn], [LastModifiedOn]) VALUES (2, 1, N'USD', CAST(5.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(N'2020-10-08T15:19:51.8966667' AS DateTime2), CAST(N'2020-10-08T15:19:51.8966667' AS DateTime2))
INSERT [dbo].[ProductItemPrices] ([Id], [ProductItemId], [PriceCurrency], [Price], [Discount], [Vat], [CreatedOn], [LastModifiedOn]) VALUES (3, 2, N'BDT', CAST(2350.0000 AS Decimal(19, 4)), CAST(150.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(N'2020-10-08T15:58:29.3033333' AS DateTime2), CAST(N'2020-10-08T15:58:29.3033333' AS DateTime2))
INSERT [dbo].[ProductItemPrices] ([Id], [ProductItemId], [PriceCurrency], [Price], [Discount], [Vat], [CreatedOn], [LastModifiedOn]) VALUES (4, 2, N'USD', CAST(25.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(N'2020-10-08T15:58:29.3066667' AS DateTime2), CAST(N'2020-10-08T15:58:29.3066667' AS DateTime2))
INSERT [dbo].[ProductItemPrices] ([Id], [ProductItemId], [PriceCurrency], [Price], [Discount], [Vat], [CreatedOn], [LastModifiedOn]) VALUES (5, 3, N'BDT', CAST(4700.0000 AS Decimal(19, 4)), CAST(200.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(N'2020-10-09T08:58:22.8100000' AS DateTime2), CAST(N'2020-10-09T08:58:22.8100000' AS DateTime2))
INSERT [dbo].[ProductItemPrices] ([Id], [ProductItemId], [PriceCurrency], [Price], [Discount], [Vat], [CreatedOn], [LastModifiedOn]) VALUES (6, 3, N'USD', CAST(50.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(N'2020-10-09T08:58:22.8166667' AS DateTime2), CAST(N'2020-10-09T08:58:22.8166667' AS DateTime2))
INSERT [dbo].[ProductItemPrices] ([Id], [ProductItemId], [PriceCurrency], [Price], [Discount], [Vat], [CreatedOn], [LastModifiedOn]) VALUES (7, 4, N'BDT', CAST(460.0000 AS Decimal(19, 4)), CAST(10.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(N'2020-10-09T09:00:17.2633333' AS DateTime2), CAST(N'2020-10-09T09:00:17.2666667' AS DateTime2))
INSERT [dbo].[ProductItemPrices] ([Id], [ProductItemId], [PriceCurrency], [Price], [Discount], [Vat], [CreatedOn], [LastModifiedOn]) VALUES (8, 4, N'USD', CAST(5.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(N'2020-10-09T09:00:17.2700000' AS DateTime2), CAST(N'2020-10-09T09:00:17.2700000' AS DateTime2))
INSERT [dbo].[ProductItemPrices] ([Id], [ProductItemId], [PriceCurrency], [Price], [Discount], [Vat], [CreatedOn], [LastModifiedOn]) VALUES (9, 5, N'BDT', CAST(2350.0000 AS Decimal(19, 4)), CAST(150.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(N'2020-10-09T09:01:25.3866667' AS DateTime2), CAST(N'2020-10-09T09:01:25.3866667' AS DateTime2))
INSERT [dbo].[ProductItemPrices] ([Id], [ProductItemId], [PriceCurrency], [Price], [Discount], [Vat], [CreatedOn], [LastModifiedOn]) VALUES (10, 5, N'USD', CAST(25.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(N'2020-10-09T09:01:25.3866667' AS DateTime2), CAST(N'2020-10-09T09:01:25.3866667' AS DateTime2))
INSERT [dbo].[ProductItemPrices] ([Id], [ProductItemId], [PriceCurrency], [Price], [Discount], [Vat], [CreatedOn], [LastModifiedOn]) VALUES (11, 6, N'BDT', CAST(4600.0000 AS Decimal(19, 4)), CAST(100.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(N'2020-10-09T09:02:43.1833333' AS DateTime2), CAST(N'2020-10-09T09:02:43.1833333' AS DateTime2))
INSERT [dbo].[ProductItemPrices] ([Id], [ProductItemId], [PriceCurrency], [Price], [Discount], [Vat], [CreatedOn], [LastModifiedOn]) VALUES (12, 6, N'USD', CAST(50.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(N'2020-10-09T09:02:43.1833333' AS DateTime2), CAST(N'2020-10-09T09:02:43.1833333' AS DateTime2))
INSERT [dbo].[ProductItemPrices] ([Id], [ProductItemId], [PriceCurrency], [Price], [Discount], [Vat], [CreatedOn], [LastModifiedOn]) VALUES (13, 7, N'BDT', CAST(460.0000 AS Decimal(19, 4)), CAST(10.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(N'2020-10-09T09:04:28.1500000' AS DateTime2), CAST(N'2020-10-09T09:04:28.1500000' AS DateTime2))
INSERT [dbo].[ProductItemPrices] ([Id], [ProductItemId], [PriceCurrency], [Price], [Discount], [Vat], [CreatedOn], [LastModifiedOn]) VALUES (14, 7, N'USD', CAST(5.0000 AS Decimal(19, 4)), CAST(5.0000 AS Decimal(19, 4)), CAST(5.0000 AS Decimal(19, 4)), CAST(N'2020-10-09T09:04:28.1500000' AS DateTime2), CAST(N'2020-10-09T09:04:28.1500000' AS DateTime2))
INSERT [dbo].[ProductItemPrices] ([Id], [ProductItemId], [PriceCurrency], [Price], [Discount], [Vat], [CreatedOn], [LastModifiedOn]) VALUES (15, 8, N'BDT', CAST(910.0000 AS Decimal(19, 4)), CAST(10.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(N'2020-10-09T09:13:59.0900000' AS DateTime2), CAST(N'2020-10-09T09:13:59.0900000' AS DateTime2))
INSERT [dbo].[ProductItemPrices] ([Id], [ProductItemId], [PriceCurrency], [Price], [Discount], [Vat], [CreatedOn], [LastModifiedOn]) VALUES (16, 8, N'USD', CAST(10.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(N'2020-10-09T09:13:59.0966667' AS DateTime2), CAST(N'2020-10-09T09:13:59.0966667' AS DateTime2))
INSERT [dbo].[ProductItemPrices] ([Id], [ProductItemId], [PriceCurrency], [Price], [Discount], [Vat], [CreatedOn], [LastModifiedOn]) VALUES (17, 9, N'BDT', CAST(4600.0000 AS Decimal(19, 4)), CAST(100.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(N'2020-10-09T09:15:18.8066667' AS DateTime2), CAST(N'2020-10-09T09:15:18.8066667' AS DateTime2))
INSERT [dbo].[ProductItemPrices] ([Id], [ProductItemId], [PriceCurrency], [Price], [Discount], [Vat], [CreatedOn], [LastModifiedOn]) VALUES (18, 9, N'USD', CAST(50.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(N'2020-10-09T09:15:18.8066667' AS DateTime2), CAST(N'2020-10-09T09:15:18.8066667' AS DateTime2))
INSERT [dbo].[ProductItemPrices] ([Id], [ProductItemId], [PriceCurrency], [Price], [Discount], [Vat], [CreatedOn], [LastModifiedOn]) VALUES (19, 10, N'BDT', CAST(4600.0000 AS Decimal(19, 4)), CAST(100.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(N'2020-10-09T09:22:06.8700000' AS DateTime2), CAST(N'2020-10-09T09:22:06.8700000' AS DateTime2))
INSERT [dbo].[ProductItemPrices] ([Id], [ProductItemId], [PriceCurrency], [Price], [Discount], [Vat], [CreatedOn], [LastModifiedOn]) VALUES (20, 10, N'USD', CAST(50.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(N'2020-10-09T09:22:06.8733333' AS DateTime2), CAST(N'2020-10-09T09:22:06.8733333' AS DateTime2))
INSERT [dbo].[ProductItemPrices] ([Id], [ProductItemId], [PriceCurrency], [Price], [Discount], [Vat], [CreatedOn], [LastModifiedOn]) VALUES (21, 11, N'BDT', CAST(4700.0000 AS Decimal(19, 4)), CAST(100.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(N'2020-10-09T09:24:09.6300000' AS DateTime2), CAST(N'2020-10-09T09:24:09.6300000' AS DateTime2))
INSERT [dbo].[ProductItemPrices] ([Id], [ProductItemId], [PriceCurrency], [Price], [Discount], [Vat], [CreatedOn], [LastModifiedOn]) VALUES (22, 11, N'USD', CAST(50.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(N'2020-10-09T09:24:09.6300000' AS DateTime2), CAST(N'2020-10-09T09:24:09.6300000' AS DateTime2))
INSERT [dbo].[ProductItemPrices] ([Id], [ProductItemId], [PriceCurrency], [Price], [Discount], [Vat], [CreatedOn], [LastModifiedOn]) VALUES (23, 12, N'BDT', CAST(990.0000 AS Decimal(19, 4)), CAST(90.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(N'2020-10-09T09:27:16.5166667' AS DateTime2), CAST(N'2020-10-09T09:27:16.5166667' AS DateTime2))
INSERT [dbo].[ProductItemPrices] ([Id], [ProductItemId], [PriceCurrency], [Price], [Discount], [Vat], [CreatedOn], [LastModifiedOn]) VALUES (24, 12, N'USD', CAST(10.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(N'2020-10-09T09:27:16.5166667' AS DateTime2), CAST(N'2020-10-09T09:27:16.5166667' AS DateTime2))
INSERT [dbo].[ProductItemPrices] ([Id], [ProductItemId], [PriceCurrency], [Price], [Discount], [Vat], [CreatedOn], [LastModifiedOn]) VALUES (25, 13, N'BDT', CAST(860.0000 AS Decimal(19, 4)), CAST(100.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(N'2020-10-09T09:29:04.6366667' AS DateTime2), CAST(N'2020-10-09T09:29:04.6366667' AS DateTime2))
INSERT [dbo].[ProductItemPrices] ([Id], [ProductItemId], [PriceCurrency], [Price], [Discount], [Vat], [CreatedOn], [LastModifiedOn]) VALUES (26, 13, N'USD', CAST(10.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(N'2020-10-09T09:29:04.6366667' AS DateTime2), CAST(N'2020-10-09T09:29:04.6366667' AS DateTime2))
INSERT [dbo].[ProductItemPrices] ([Id], [ProductItemId], [PriceCurrency], [Price], [Discount], [Vat], [CreatedOn], [LastModifiedOn]) VALUES (27, 14, N'BDT', CAST(1800.0000 AS Decimal(19, 4)), CAST(100.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(N'2020-10-09T09:40:31.8066667' AS DateTime2), CAST(N'2020-10-09T09:40:31.8066667' AS DateTime2))
INSERT [dbo].[ProductItemPrices] ([Id], [ProductItemId], [PriceCurrency], [Price], [Discount], [Vat], [CreatedOn], [LastModifiedOn]) VALUES (28, 14, N'USD', CAST(30.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(N'2020-10-09T09:40:31.8100000' AS DateTime2), CAST(N'2020-10-09T09:40:31.8100000' AS DateTime2))
INSERT [dbo].[ProductItemPrices] ([Id], [ProductItemId], [PriceCurrency], [Price], [Discount], [Vat], [CreatedOn], [LastModifiedOn]) VALUES (29, 15, N'BDT', CAST(1100.0000 AS Decimal(19, 4)), CAST(50.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(N'2020-10-09T09:44:38.3466667' AS DateTime2), CAST(N'2020-10-09T09:44:38.3466667' AS DateTime2))
INSERT [dbo].[ProductItemPrices] ([Id], [ProductItemId], [PriceCurrency], [Price], [Discount], [Vat], [CreatedOn], [LastModifiedOn]) VALUES (30, 15, N'USD', CAST(15.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(N'2020-10-09T09:44:38.3466667' AS DateTime2), CAST(N'2020-10-09T09:44:38.3466667' AS DateTime2))
INSERT [dbo].[ProductItemPrices] ([Id], [ProductItemId], [PriceCurrency], [Price], [Discount], [Vat], [CreatedOn], [LastModifiedOn]) VALUES (31, 16, N'BDT', CAST(4900.0000 AS Decimal(19, 4)), CAST(200.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(N'2020-10-09T09:47:26.4200000' AS DateTime2), CAST(N'2020-10-09T09:47:26.4200000' AS DateTime2))
INSERT [dbo].[ProductItemPrices] ([Id], [ProductItemId], [PriceCurrency], [Price], [Discount], [Vat], [CreatedOn], [LastModifiedOn]) VALUES (32, 16, N'USD', CAST(50.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(N'2020-10-09T09:47:26.4200000' AS DateTime2), CAST(N'2020-10-09T09:47:26.4200000' AS DateTime2))
INSERT [dbo].[ProductItemPrices] ([Id], [ProductItemId], [PriceCurrency], [Price], [Discount], [Vat], [CreatedOn], [LastModifiedOn]) VALUES (35, 18, N'BDT', CAST(5.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(N'2021-12-19T11:28:39.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ProductItemPrices] ([Id], [ProductItemId], [PriceCurrency], [Price], [Discount], [Vat], [CreatedOn], [LastModifiedOn]) VALUES (36, 18, N'USD', CAST(0.3000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(N'2021-12-19T11:28:39.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[ProductItemPrices] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductItems] ON 

INSERT [dbo].[ProductItems] ([Id], [Name], [ImageUrl], [Overview], [WhatCanBeDone], [HowToConsume], [Limitations], [IsActive], [IsShippable], [CreatedOn], [LastModifiedOn]) VALUES (1, N'Amazon 5$ Gift Card', N'ImageResources\ProductItem\ProductItem_96ee4b98-abb5-40e0-9870-25861ca2dbab.jpg', N'Amazon 5$ gift card can be added to your amazon.com account balance', N'Buy your item from thousands of products at amazon.com', NULL, NULL, 1, 0, CAST(N'2020-10-08T15:19:51.7560515' AS DateTime2), CAST(N'2020-10-08T15:19:51.7560908' AS DateTime2))
INSERT [dbo].[ProductItems] ([Id], [Name], [ImageUrl], [Overview], [WhatCanBeDone], [HowToConsume], [Limitations], [IsActive], [IsShippable], [CreatedOn], [LastModifiedOn]) VALUES (2, N'Amazon 25$ Gift Card', N'ImageResources\ProductItem\ProductItem_8acaecb9-0ae3-42ae-8de4-f9cbd0418d69.webp', N'Add 25$ balance to an amazon.com account', NULL, NULL, NULL, 1, 0, CAST(N'2020-10-08T15:58:29.1802820' AS DateTime2), CAST(N'2020-10-08T15:58:29.1802851' AS DateTime2))
INSERT [dbo].[ProductItems] ([Id], [Name], [ImageUrl], [Overview], [WhatCanBeDone], [HowToConsume], [Limitations], [IsActive], [IsShippable], [CreatedOn], [LastModifiedOn]) VALUES (3, N'Amazon 50$ Gift Card', N'ImageResources\ProductItem\ProductItem_71230ef7-ebf2-4710-9a0c-873ca4ad74ea.jpg', N'Add 50$ balance to your amazon.com account and avail your desired products and services', NULL, NULL, NULL, 1, 0, CAST(N'2020-10-09T08:58:22.5464048' AS DateTime2), CAST(N'2020-10-09T08:58:22.5464349' AS DateTime2))
INSERT [dbo].[ProductItems] ([Id], [Name], [ImageUrl], [Overview], [WhatCanBeDone], [HowToConsume], [Limitations], [IsActive], [IsShippable], [CreatedOn], [LastModifiedOn]) VALUES (4, N'Google Play 5$ Gift Card', N'ImageResources\ProductItem\ProductItem_b1fa7089-8cb0-4cd3-bfca-1b29c2e39a2e.jpeg', N'Add 5$ to your google account balance and avail your desired products and services', NULL, NULL, NULL, 1, 0, CAST(N'2020-10-09T09:00:17.2499838' AS DateTime2), CAST(N'2020-10-09T09:00:17.2499868' AS DateTime2))
INSERT [dbo].[ProductItems] ([Id], [Name], [ImageUrl], [Overview], [WhatCanBeDone], [HowToConsume], [Limitations], [IsActive], [IsShippable], [CreatedOn], [LastModifiedOn]) VALUES (5, N'Google Play 25$ Gift Card', N'ImageResources\ProductItem\ProductItem_6802cd09-d54a-47c7-9e6e-6319730ff4e9.jpg', N'Add 25$ to your google account balance and avail your desired products and services', NULL, NULL, NULL, 1, 0, CAST(N'2020-10-09T09:01:25.3825811' AS DateTime2), CAST(N'2020-10-09T09:01:25.3825838' AS DateTime2))
INSERT [dbo].[ProductItems] ([Id], [Name], [ImageUrl], [Overview], [WhatCanBeDone], [HowToConsume], [Limitations], [IsActive], [IsShippable], [CreatedOn], [LastModifiedOn]) VALUES (6, N'Google Play 50$ Gift Card', N'ImageResources\ProductItem\ProductItem_1183d016-59f5-4c2e-8065-40346fd302e1.jpeg', N'Add 50$ to your google account balance and avail your desired products and services', NULL, NULL, NULL, 1, 0, CAST(N'2020-10-09T09:02:43.1808437' AS DateTime2), CAST(N'2020-10-09T09:02:43.1808462' AS DateTime2))
INSERT [dbo].[ProductItems] ([Id], [Name], [ImageUrl], [Overview], [WhatCanBeDone], [HowToConsume], [Limitations], [IsActive], [IsShippable], [CreatedOn], [LastModifiedOn]) VALUES (7, N'Steam 5$ Wallet  Code', N'ImageResources\ProductItem\ProductItem_1023cadd-aad7-47a0-b7c8-1339a82734e6.jpg', N'Add 5$ to your steam account balance and avail your desired games and virtual items', NULL, NULL, NULL, 1, 0, CAST(N'2020-10-09T09:04:28.1497086' AS DateTime2), CAST(N'2020-10-09T09:04:28.1497120' AS DateTime2))
INSERT [dbo].[ProductItems] ([Id], [Name], [ImageUrl], [Overview], [WhatCanBeDone], [HowToConsume], [Limitations], [IsActive], [IsShippable], [CreatedOn], [LastModifiedOn]) VALUES (8, N'Steam 10$ Wallet Code', N'ImageResources\ProductItem\ProductItem_cde1e716-b0bb-4027-b0c6-a5b844b29961.jpg', N'Add 10$ to your steam account wallet and avail exciting games and virtual items', NULL, NULL, NULL, 1, 0, CAST(N'2020-10-09T09:13:58.8367996' AS DateTime2), CAST(N'2020-10-09T09:13:58.8368235' AS DateTime2))
INSERT [dbo].[ProductItems] ([Id], [Name], [ImageUrl], [Overview], [WhatCanBeDone], [HowToConsume], [Limitations], [IsActive], [IsShippable], [CreatedOn], [LastModifiedOn]) VALUES (9, N'Steam 50$ Wallet Code', N'ImageResources\ProductItem\ProductItem_76774dce-0bcf-4ef6-85d8-7f3966d7f1fd.jpg', N'Add 50$ to your steam account wallet and avail exciting games and virtual items', NULL, NULL, NULL, 1, 0, CAST(N'2020-10-09T09:15:18.8008673' AS DateTime2), CAST(N'2020-10-09T09:15:18.8008742' AS DateTime2))
INSERT [dbo].[ProductItems] ([Id], [Name], [ImageUrl], [Overview], [WhatCanBeDone], [HowToConsume], [Limitations], [IsActive], [IsShippable], [CreatedOn], [LastModifiedOn]) VALUES (10, N'iTunes 50$ Gift Card', N'ImageResources\ProductItem\ProductItem_532a8569-9b44-4377-88fa-04f134118a9e.jpg', N'Add %0$ to your apple account and avail exciting services', NULL, NULL, NULL, 1, 0, CAST(N'2020-10-09T09:22:06.8613165' AS DateTime2), CAST(N'2020-10-09T09:22:06.8613292' AS DateTime2))
INSERT [dbo].[ProductItems] ([Id], [Name], [ImageUrl], [Overview], [WhatCanBeDone], [HowToConsume], [Limitations], [IsActive], [IsShippable], [CreatedOn], [LastModifiedOn]) VALUES (11, N'Visa 50$ Virtual Gift Card', N'ImageResources\ProductItem\ProductItem_c4388eb0-4edd-4fec-bff8-51f5e2346457.jpg', N'Shop from around 2 million VISA supported merchants worldwide', NULL, NULL, NULL, 1, 0, CAST(N'2020-10-09T09:24:09.6141345' AS DateTime2), CAST(N'2020-10-09T09:24:09.6141372' AS DateTime2))
INSERT [dbo].[ProductItems] ([Id], [Name], [ImageUrl], [Overview], [WhatCanBeDone], [HowToConsume], [Limitations], [IsActive], [IsShippable], [CreatedOn], [LastModifiedOn]) VALUES (12, N'Windows 10 Pro OEM Cd Key', N'ImageResources\ProductItem\ProductItem_f0248f1c-fcd2-4f13-bb08-caf03548bc6e.webp', N'Activate your Windows 10 pro and get important security updates', NULL, NULL, NULL, 1, 0, CAST(N'2020-10-09T09:27:16.5117703' AS DateTime2), CAST(N'2020-10-09T09:27:16.5117739' AS DateTime2))
INSERT [dbo].[ProductItems] ([Id], [Name], [ImageUrl], [Overview], [WhatCanBeDone], [HowToConsume], [Limitations], [IsActive], [IsShippable], [CreatedOn], [LastModifiedOn]) VALUES (13, N'Microsoft Office 2019 Pro Plus Cd Key', N'ImageResources\ProductItem\ProductItem_b1b390e5-ab4f-4388-b196-663f4dcb0a75.png', N'Increase your productivity using Office suite', NULL, NULL, NULL, 1, 0, CAST(N'2020-10-09T09:29:04.6342488' AS DateTime2), CAST(N'2020-10-09T09:29:04.6342529' AS DateTime2))
INSERT [dbo].[ProductItems] ([Id], [Name], [ImageUrl], [Overview], [WhatCanBeDone], [HowToConsume], [Limitations], [IsActive], [IsShippable], [CreatedOn], [LastModifiedOn]) VALUES (14, N'Kaspersky Total Security 2020 1 Pc 1 Year', N'ImageResources\ProductItem\ProductItem_d820b85c-c573-42cb-aa0d-3344288758d8.jpg', N'Protect your browsing, shopping, chats & data across your PC, Mac & Android devices. Get award-winning antivirus plus a range of tools built to guard your private life and identity.', NULL, NULL, NULL, 1, 0, CAST(N'2020-10-09T09:40:31.7062776' AS DateTime2), CAST(N'2020-10-09T09:40:31.7062805' AS DateTime2))
INSERT [dbo].[ProductItems] ([Id], [Name], [ImageUrl], [Overview], [WhatCanBeDone], [HowToConsume], [Limitations], [IsActive], [IsShippable], [CreatedOn], [LastModifiedOn]) VALUES (15, N'Overwatch Steam Key Global', N'ImageResources\ProductItem\ProductItem_f88a8b4d-4f7b-4bc2-9680-d3c8da054579.jpg', N'Play Overwatch on Steam', NULL, NULL, NULL, 1, 0, CAST(N'2020-10-09T09:44:38.3428526' AS DateTime2), CAST(N'2020-10-09T09:44:38.3428565' AS DateTime2))
INSERT [dbo].[ProductItems] ([Id], [Name], [ImageUrl], [Overview], [WhatCanBeDone], [HowToConsume], [Limitations], [IsActive], [IsShippable], [CreatedOn], [LastModifiedOn]) VALUES (16, N'Fifa 21 PC Cd Key', N'ImageResources\ProductItem\ProductItem_12b85dc2-822d-4219-88c0-f16aa75f616c.jpg', N'FIFA 21 is a football simulation video game published by Electronic Arts as part of the FIFA series. ', NULL, NULL, NULL, 1, 0, CAST(N'2020-10-09T09:47:26.4155603' AS DateTime2), CAST(N'2020-10-09T09:47:26.4155635' AS DateTime2))
INSERT [dbo].[ProductItems] ([Id], [Name], [ImageUrl], [Overview], [WhatCanBeDone], [HowToConsume], [Limitations], [IsActive], [IsShippable], [CreatedOn], [LastModifiedOn]) VALUES (18, N'Test Product', N'ImageResources\ProductItem\ProductItem_13dc6b4d-1b0b-43b7-a1da-083cd113cdbc.PNG', N'Test category', NULL, NULL, NULL, 1, 0, CAST(N'2021-12-19T11:28:38.0000000' AS DateTime2), CAST(N'2022-01-26T14:34:04.8253083' AS DateTime2))
SET IDENTITY_INSERT [dbo].[ProductItems] OFF
GO
INSERT [dbo].[ProductSectionJoinProductItem] ([ProductSectionId], [ProductItemId]) VALUES (1, 1)
INSERT [dbo].[ProductSectionJoinProductItem] ([ProductSectionId], [ProductItemId]) VALUES (1, 2)
INSERT [dbo].[ProductSectionJoinProductItem] ([ProductSectionId], [ProductItemId]) VALUES (1, 3)
INSERT [dbo].[ProductSectionJoinProductItem] ([ProductSectionId], [ProductItemId]) VALUES (2, 4)
INSERT [dbo].[ProductSectionJoinProductItem] ([ProductSectionId], [ProductItemId]) VALUES (2, 5)
INSERT [dbo].[ProductSectionJoinProductItem] ([ProductSectionId], [ProductItemId]) VALUES (2, 6)
INSERT [dbo].[ProductSectionJoinProductItem] ([ProductSectionId], [ProductItemId]) VALUES (3, 7)
INSERT [dbo].[ProductSectionJoinProductItem] ([ProductSectionId], [ProductItemId]) VALUES (3, 8)
INSERT [dbo].[ProductSectionJoinProductItem] ([ProductSectionId], [ProductItemId]) VALUES (3, 9)
INSERT [dbo].[ProductSectionJoinProductItem] ([ProductSectionId], [ProductItemId]) VALUES (4, 10)
INSERT [dbo].[ProductSectionJoinProductItem] ([ProductSectionId], [ProductItemId]) VALUES (5, 12)
INSERT [dbo].[ProductSectionJoinProductItem] ([ProductSectionId], [ProductItemId]) VALUES (5, 13)
INSERT [dbo].[ProductSectionJoinProductItem] ([ProductSectionId], [ProductItemId]) VALUES (5, 14)
INSERT [dbo].[ProductSectionJoinProductItem] ([ProductSectionId], [ProductItemId]) VALUES (6, 15)
INSERT [dbo].[ProductSectionJoinProductItem] ([ProductSectionId], [ProductItemId]) VALUES (6, 16)
GO
SET IDENTITY_INSERT [dbo].[ProductSections] ON 

INSERT [dbo].[ProductSections] ([Id], [Title], [Overview], [Rank], [CreatedOn], [LastModifiedOn]) VALUES (1, N'Amazon Gift Card', N'Amazon gift cards can be added to an amazon.com account balance', 1, CAST(N'2020-10-09T09:49:43.0000000' AS DateTime2), CAST(N'2021-12-31T13:16:13.9870178' AS DateTime2))
INSERT [dbo].[ProductSections] ([Id], [Title], [Overview], [Rank], [CreatedOn], [LastModifiedOn]) VALUES (2, N'Google Play Gift Card', N'Add balance to your google account balance and avail your desired products and services', 2, CAST(N'2020-10-09T09:51:02.8995805' AS DateTime2), CAST(N'2020-10-09T09:51:02.8995832' AS DateTime2))
INSERT [dbo].[ProductSections] ([Id], [Title], [Overview], [Rank], [CreatedOn], [LastModifiedOn]) VALUES (3, N'Steam Gift Card', N'Add balance to your steam account and avail your desired products and services', 3, CAST(N'2020-10-09T09:51:42.8913858' AS DateTime2), CAST(N'2020-10-09T09:51:42.8913881' AS DateTime2))
INSERT [dbo].[ProductSections] ([Id], [Title], [Overview], [Rank], [CreatedOn], [LastModifiedOn]) VALUES (4, N'iTunes Gift Card', N'Add balance to your apple account and avail your desired products and services', 4, CAST(N'2020-10-09T09:52:35.9171222' AS DateTime2), CAST(N'2020-10-09T09:52:35.9171247' AS DateTime2))
INSERT [dbo].[ProductSections] ([Id], [Title], [Overview], [Rank], [CreatedOn], [LastModifiedOn]) VALUES (5, N'General Purpose Software License', N'Buy software license', 5, CAST(N'2020-10-09T09:54:11.9580102' AS DateTime2), CAST(N'2020-10-09T09:54:11.9580131' AS DateTime2))
INSERT [dbo].[ProductSections] ([Id], [Title], [Overview], [Rank], [CreatedOn], [LastModifiedOn]) VALUES (6, N'Game Keys', N'Buy game keys and activate on your desired platform', 6, CAST(N'2020-10-09T09:55:16.6052736' AS DateTime2), CAST(N'2020-10-09T09:55:16.6052765' AS DateTime2))
SET IDENTITY_INSERT [dbo].[ProductSections] OFF
GO
INSERT [dbo].[ProductStockCounts] ([ProductItemId], [Count], [LastUpdated]) VALUES (1, 1, CAST(N'2021-12-23T11:05:06.2600000' AS DateTime2))
INSERT [dbo].[ProductStockCounts] ([ProductItemId], [Count], [LastUpdated]) VALUES (2, 1, CAST(N'2021-12-23T11:05:06.2633333' AS DateTime2))
INSERT [dbo].[ProductStockCounts] ([ProductItemId], [Count], [LastUpdated]) VALUES (3, 0, CAST(N'2021-12-23T11:05:06.2633333' AS DateTime2))
INSERT [dbo].[ProductStockCounts] ([ProductItemId], [Count], [LastUpdated]) VALUES (4, 0, CAST(N'2021-12-23T11:05:06.2633333' AS DateTime2))
INSERT [dbo].[ProductStockCounts] ([ProductItemId], [Count], [LastUpdated]) VALUES (5, 0, CAST(N'2021-12-23T11:05:06.2633333' AS DateTime2))
INSERT [dbo].[ProductStockCounts] ([ProductItemId], [Count], [LastUpdated]) VALUES (6, 0, CAST(N'2021-12-23T11:05:06.2633333' AS DateTime2))
INSERT [dbo].[ProductStockCounts] ([ProductItemId], [Count], [LastUpdated]) VALUES (7, 0, CAST(N'2021-12-23T11:05:06.2633333' AS DateTime2))
INSERT [dbo].[ProductStockCounts] ([ProductItemId], [Count], [LastUpdated]) VALUES (8, 0, CAST(N'2021-12-23T11:05:06.2633333' AS DateTime2))
INSERT [dbo].[ProductStockCounts] ([ProductItemId], [Count], [LastUpdated]) VALUES (9, 0, CAST(N'2021-12-23T11:05:06.2633333' AS DateTime2))
INSERT [dbo].[ProductStockCounts] ([ProductItemId], [Count], [LastUpdated]) VALUES (10, 0, CAST(N'2021-12-23T11:05:06.2633333' AS DateTime2))
INSERT [dbo].[ProductStockCounts] ([ProductItemId], [Count], [LastUpdated]) VALUES (11, 0, CAST(N'2021-12-23T11:05:06.2633333' AS DateTime2))
INSERT [dbo].[ProductStockCounts] ([ProductItemId], [Count], [LastUpdated]) VALUES (12, 0, CAST(N'2021-12-23T11:05:06.2633333' AS DateTime2))
INSERT [dbo].[ProductStockCounts] ([ProductItemId], [Count], [LastUpdated]) VALUES (13, 0, CAST(N'2021-12-23T11:05:06.2633333' AS DateTime2))
INSERT [dbo].[ProductStockCounts] ([ProductItemId], [Count], [LastUpdated]) VALUES (14, 0, CAST(N'2021-12-23T11:05:06.2633333' AS DateTime2))
INSERT [dbo].[ProductStockCounts] ([ProductItemId], [Count], [LastUpdated]) VALUES (15, 0, CAST(N'2021-12-23T11:05:06.2633333' AS DateTime2))
INSERT [dbo].[ProductStockCounts] ([ProductItemId], [Count], [LastUpdated]) VALUES (16, 0, CAST(N'2021-12-23T11:05:06.2633333' AS DateTime2))
INSERT [dbo].[ProductStockCounts] ([ProductItemId], [Count], [LastUpdated]) VALUES (18, 0, CAST(N'2021-12-23T11:05:06.2633333' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[ProductStocks] ON 

INSERT [dbo].[ProductStocks] ([Id], [ProductItemId], [MainCode], [AuxiliaryCode], [OptionA], [OptionB], [OptionC], [DeliverableItemId], [VendorInfo], [Status], [CreateTime], [LastUpdateTime], [Remark], [DeliverableBundleItemId]) VALUES (62, 1, N'CgRDKajh7gcTfNlvGgD+RA==', NULL, NULL, NULL, NULL, 9, NULL, 2, CAST(N'2022-01-11T17:33:57.7390466' AS DateTime2), CAST(N'2022-01-11T17:33:57.7391123' AS DateTime2), NULL, NULL)
INSERT [dbo].[ProductStocks] ([Id], [ProductItemId], [MainCode], [AuxiliaryCode], [OptionA], [OptionB], [OptionC], [DeliverableItemId], [VendorInfo], [Status], [CreateTime], [LastUpdateTime], [Remark], [DeliverableBundleItemId]) VALUES (63, 12, N'MAf1ofBcrUdQWe3xym/wKSYSK/ggP0dy3qbe0gKOX40=', NULL, NULL, NULL, NULL, 11, NULL, 2, CAST(N'2022-01-11T17:34:09.0452153' AS DateTime2), CAST(N'2022-01-11T17:34:09.0452167' AS DateTime2), NULL, NULL)
INSERT [dbo].[ProductStocks] ([Id], [ProductItemId], [MainCode], [AuxiliaryCode], [OptionA], [OptionB], [OptionC], [DeliverableItemId], [VendorInfo], [Status], [CreateTime], [LastUpdateTime], [Remark], [DeliverableBundleItemId]) VALUES (64, 13, N'MAf1ofBcrUdQWe3xym/wKfHisEu3tc47XVGYBVlzI4c=', NULL, NULL, NULL, NULL, NULL, NULL, 2, CAST(N'2022-01-11T17:34:23.0841341' AS DateTime2), CAST(N'2022-01-11T17:34:23.0841357' AS DateTime2), NULL, 18)
INSERT [dbo].[ProductStocks] ([Id], [ProductItemId], [MainCode], [AuxiliaryCode], [OptionA], [OptionB], [OptionC], [DeliverableItemId], [VendorInfo], [Status], [CreateTime], [LastUpdateTime], [Remark], [DeliverableBundleItemId]) VALUES (65, 11, N'jg3GVvxL+G8UEn3qGUDucQ==', NULL, NULL, NULL, NULL, NULL, NULL, 2, CAST(N'2022-01-11T17:34:36.9557355' AS DateTime2), CAST(N'2022-01-11T17:34:36.9557368' AS DateTime2), NULL, 17)
INSERT [dbo].[ProductStocks] ([Id], [ProductItemId], [MainCode], [AuxiliaryCode], [OptionA], [OptionB], [OptionC], [DeliverableItemId], [VendorInfo], [Status], [CreateTime], [LastUpdateTime], [Remark], [DeliverableBundleItemId]) VALUES (66, 1, N'CgRDKajh7gcTfNlvGgD+RA==', NULL, NULL, NULL, NULL, 10, NULL, 2, CAST(N'2022-01-11T17:39:09.8925610' AS DateTime2), CAST(N'2022-01-11T17:39:09.8926157' AS DateTime2), NULL, NULL)
INSERT [dbo].[ProductStocks] ([Id], [ProductItemId], [MainCode], [AuxiliaryCode], [OptionA], [OptionB], [OptionC], [DeliverableItemId], [VendorInfo], [Status], [CreateTime], [LastUpdateTime], [Remark], [DeliverableBundleItemId]) VALUES (67, 12, N'MAf1ofBcrUdQWe3xym/wKSYSK/ggP0dy3qbe0gKOX40=', NULL, NULL, NULL, NULL, 12, NULL, 2, CAST(N'2022-01-11T17:39:17.9732090' AS DateTime2), CAST(N'2022-01-11T17:39:17.9732103' AS DateTime2), NULL, NULL)
INSERT [dbo].[ProductStocks] ([Id], [ProductItemId], [MainCode], [AuxiliaryCode], [OptionA], [OptionB], [OptionC], [DeliverableItemId], [VendorInfo], [Status], [CreateTime], [LastUpdateTime], [Remark], [DeliverableBundleItemId]) VALUES (68, 13, N'MAf1ofBcrUdQWe3xym/wKSYSK/ggP0dy3qbe0gKOX40=', NULL, NULL, NULL, NULL, NULL, NULL, 2, CAST(N'2022-01-11T17:39:25.2066454' AS DateTime2), CAST(N'2022-01-11T17:39:25.2066462' AS DateTime2), NULL, 20)
INSERT [dbo].[ProductStocks] ([Id], [ProductItemId], [MainCode], [AuxiliaryCode], [OptionA], [OptionB], [OptionC], [DeliverableItemId], [VendorInfo], [Status], [CreateTime], [LastUpdateTime], [Remark], [DeliverableBundleItemId]) VALUES (69, 11, N'MAf1ofBcrUdQWe3xym/wKUK+itGwZsJYkS7hFeoGa/0=', NULL, NULL, NULL, NULL, NULL, NULL, 2, CAST(N'2022-01-11T17:39:34.6994890' AS DateTime2), CAST(N'2022-01-11T17:39:34.6994900' AS DateTime2), NULL, 19)
INSERT [dbo].[ProductStocks] ([Id], [ProductItemId], [MainCode], [AuxiliaryCode], [OptionA], [OptionB], [OptionC], [DeliverableItemId], [VendorInfo], [Status], [CreateTime], [LastUpdateTime], [Remark], [DeliverableBundleItemId]) VALUES (70, 1, N'MAf1ofBcrUdQWe3xym/wKSYSK/ggP0dy3qbe0gKOX40=', NULL, NULL, NULL, NULL, 13, NULL, 2, CAST(N'2022-01-11T17:46:34.9419112' AS DateTime2), CAST(N'2022-01-11T17:46:34.9419676' AS DateTime2), NULL, NULL)
INSERT [dbo].[ProductStocks] ([Id], [ProductItemId], [MainCode], [AuxiliaryCode], [OptionA], [OptionB], [OptionC], [DeliverableItemId], [VendorInfo], [Status], [CreateTime], [LastUpdateTime], [Remark], [DeliverableBundleItemId]) VALUES (71, 1, N'MAf1ofBcrUdQWe3xym/wKSYSK/ggP0dy3qbe0gKOX40=', NULL, NULL, NULL, NULL, 14, NULL, 2, CAST(N'2022-01-11T17:49:11.6267396' AS DateTime2), CAST(N'2022-01-11T17:49:11.6267868' AS DateTime2), NULL, NULL)
INSERT [dbo].[ProductStocks] ([Id], [ProductItemId], [MainCode], [AuxiliaryCode], [OptionA], [OptionB], [OptionC], [DeliverableItemId], [VendorInfo], [Status], [CreateTime], [LastUpdateTime], [Remark], [DeliverableBundleItemId]) VALUES (72, 1, N'MAf1ofBcrUdQWe3xym/wKSYSK/ggP0dy3qbe0gKOX40=', NULL, NULL, NULL, NULL, 15, NULL, 2, CAST(N'2022-01-11T18:07:09.6641393' AS DateTime2), CAST(N'2022-01-11T18:07:09.6641939' AS DateTime2), NULL, NULL)
INSERT [dbo].[ProductStocks] ([Id], [ProductItemId], [MainCode], [AuxiliaryCode], [OptionA], [OptionB], [OptionC], [DeliverableItemId], [VendorInfo], [Status], [CreateTime], [LastUpdateTime], [Remark], [DeliverableBundleItemId]) VALUES (73, 1, N'CgRDKajh7gcTfNlvGgD+RA==', NULL, NULL, NULL, NULL, 16, NULL, 2, CAST(N'2022-01-12T06:33:12.8717876' AS DateTime2), CAST(N'2022-01-12T06:33:12.8718424' AS DateTime2), NULL, NULL)
INSERT [dbo].[ProductStocks] ([Id], [ProductItemId], [MainCode], [AuxiliaryCode], [OptionA], [OptionB], [OptionC], [DeliverableItemId], [VendorInfo], [Status], [CreateTime], [LastUpdateTime], [Remark], [DeliverableBundleItemId]) VALUES (74, 12, N'l62QSblXhvB/7NY7ENAB6Q==', NULL, NULL, NULL, NULL, 17, NULL, 2, CAST(N'2022-01-12T06:33:19.0718635' AS DateTime2), CAST(N'2022-01-12T06:33:19.0718646' AS DateTime2), NULL, NULL)
INSERT [dbo].[ProductStocks] ([Id], [ProductItemId], [MainCode], [AuxiliaryCode], [OptionA], [OptionB], [OptionC], [DeliverableItemId], [VendorInfo], [Status], [CreateTime], [LastUpdateTime], [Remark], [DeliverableBundleItemId]) VALUES (75, 13, N'MAf1ofBcrUdQWe3xym/wKTSBBaLwFiVAKMpNisoSP1o=', NULL, NULL, NULL, NULL, NULL, NULL, 2, CAST(N'2022-01-12T06:33:25.5671659' AS DateTime2), CAST(N'2022-01-12T06:33:25.5671665' AS DateTime2), NULL, 22)
INSERT [dbo].[ProductStocks] ([Id], [ProductItemId], [MainCode], [AuxiliaryCode], [OptionA], [OptionB], [OptionC], [DeliverableItemId], [VendorInfo], [Status], [CreateTime], [LastUpdateTime], [Remark], [DeliverableBundleItemId]) VALUES (76, 11, N'MAf1ofBcrUdQWe3xym/wKSYSK/ggP0dy3qbe0gKOX40=', NULL, NULL, NULL, NULL, NULL, NULL, 2, CAST(N'2022-01-12T06:33:36.6562705' AS DateTime2), CAST(N'2022-01-12T06:33:36.6562717' AS DateTime2), NULL, 21)
INSERT [dbo].[ProductStocks] ([Id], [ProductItemId], [MainCode], [AuxiliaryCode], [OptionA], [OptionB], [OptionC], [DeliverableItemId], [VendorInfo], [Status], [CreateTime], [LastUpdateTime], [Remark], [DeliverableBundleItemId]) VALUES (77, 1, N'le7Sw2DmCAzlS2c0sjgvZHXu2BIDIVWDN9AXZeG4UAY=', NULL, NULL, NULL, NULL, 18, NULL, 2, CAST(N'2022-01-19T14:08:38.5155844' AS DateTime2), CAST(N'2022-01-19T14:08:38.5156609' AS DateTime2), NULL, NULL)
INSERT [dbo].[ProductStocks] ([Id], [ProductItemId], [MainCode], [AuxiliaryCode], [OptionA], [OptionB], [OptionC], [DeliverableItemId], [VendorInfo], [Status], [CreateTime], [LastUpdateTime], [Remark], [DeliverableBundleItemId]) VALUES (78, 1, N'CgRDKajh7gcTfNlvGgD+RA==', NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2022-01-20T05:01:58.9282166' AS DateTime2), CAST(N'2022-01-20T05:01:58.9283132' AS DateTime2), NULL, NULL)
INSERT [dbo].[ProductStocks] ([Id], [ProductItemId], [MainCode], [AuxiliaryCode], [OptionA], [OptionB], [OptionC], [DeliverableItemId], [VendorInfo], [Status], [CreateTime], [LastUpdateTime], [Remark], [DeliverableBundleItemId]) VALUES (79, 2, N'l62QSblXhvB/7NY7ENAB6Q==', NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2022-01-20T05:02:06.8193741' AS DateTime2), CAST(N'2022-01-20T05:02:06.8194137' AS DateTime2), NULL, NULL)
INSERT [dbo].[ProductStocks] ([Id], [ProductItemId], [MainCode], [AuxiliaryCode], [OptionA], [OptionB], [OptionC], [DeliverableItemId], [VendorInfo], [Status], [CreateTime], [LastUpdateTime], [Remark], [DeliverableBundleItemId]) VALUES (80, 18, N'lmiIVNx10namNUwAts806Q==', NULL, NULL, NULL, NULL, 19, NULL, 2, CAST(N'2022-01-26T13:09:44.8122460' AS DateTime2), CAST(N'2022-01-26T13:09:44.8123279' AS DateTime2), NULL, NULL)
INSERT [dbo].[ProductStocks] ([Id], [ProductItemId], [MainCode], [AuxiliaryCode], [OptionA], [OptionB], [OptionC], [DeliverableItemId], [VendorInfo], [Status], [CreateTime], [LastUpdateTime], [Remark], [DeliverableBundleItemId]) VALUES (81, 18, N'3QYPPJSCSx4N/AzFNYUPoA==', NULL, NULL, NULL, NULL, 20, NULL, 2, CAST(N'2022-01-26T14:33:36.5899538' AS DateTime2), CAST(N'2022-01-26T14:33:36.5900307' AS DateTime2), NULL, NULL)
INSERT [dbo].[ProductStocks] ([Id], [ProductItemId], [MainCode], [AuxiliaryCode], [OptionA], [OptionB], [OptionC], [DeliverableItemId], [VendorInfo], [Status], [CreateTime], [LastUpdateTime], [Remark], [DeliverableBundleItemId]) VALUES (82, 18, N'EgcjODLB1Ly6ek7sLjzPIg==', NULL, NULL, NULL, NULL, 21, NULL, 2, CAST(N'2022-01-27T06:41:25.3279670' AS DateTime2), CAST(N'2022-01-27T06:41:25.3280483' AS DateTime2), NULL, NULL)
INSERT [dbo].[ProductStocks] ([Id], [ProductItemId], [MainCode], [AuxiliaryCode], [OptionA], [OptionB], [OptionC], [DeliverableItemId], [VendorInfo], [Status], [CreateTime], [LastUpdateTime], [Remark], [DeliverableBundleItemId]) VALUES (83, 18, N'1lrIOJbgkNkKKjPb1iGGxg==', NULL, NULL, NULL, NULL, 22, NULL, 2, CAST(N'2022-01-27T12:42:39.2964096' AS DateTime2), CAST(N'2022-01-27T12:42:39.2964917' AS DateTime2), NULL, NULL)
SET IDENTITY_INSERT [dbo].[ProductStocks] OFF
GO
SET IDENTITY_INSERT [dbo].[SmtpConfigs] ON 

INSERT [dbo].[SmtpConfigs] ([Id], [Server], [Username], [Password], [FromName], [FromAddress], [Port], [UseAuthentication], [UseSecureConnection], [CreatedUserId], [CreatedDateTime], [UpdatedUserId], [UpdatedDateTime]) VALUES (4, N'niludigital.com', N'zdozwHZVLfAx57oEYwUfEuRTYOvxX70oaR/hF7+Ricg=', N'rcV+zhnSIiv9nzVlzCS+9w==', N'Nilu Digital Store', N'support@niludigital.com', 465, 1, 1, NULL, CAST(N'2022-01-10T14:16:25.0000000' AS DateTime2), NULL, CAST(N'2022-01-10T14:16:25.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[SmtpConfigs] OFF
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsVerified]
GO
ALTER TABLE [dbo].[CartProductItemBundles] ADD  DEFAULT ((1)) FOR [Quantity]
GO
ALTER TABLE [dbo].[Deliverables] ADD  DEFAULT (CONVERT([bit],(0))) FOR [Completed]
GO
ALTER TABLE [dbo].[OrderProductItemBundle] ADD  DEFAULT ((1)) FOR [Quantity]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (CONVERT([bit],(0))) FOR [SendOfferInMail]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ((0.0)) FOR [DiscountTotal]
GO
ALTER TABLE [dbo].[PaymentGwConfigs] ADD  DEFAULT (getutcdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[PaymentGwConfigs] ADD  DEFAULT (getutcdate()) FOR [ModifiedOn]
GO
ALTER TABLE [dbo].[PaymentTransactions] ADD  DEFAULT ((0.0)) FOR [AmountInUSD]
GO
ALTER TABLE [dbo].[PaymentTransactions] ADD  DEFAULT ((0.0)) FOR [RateOfUSD]
GO
ALTER TABLE [dbo].[PaymentTransactions] ADD  DEFAULT ((0)) FOR [SurjoPayCode]
GO
ALTER TABLE [dbo].[ProductCategories] ADD  DEFAULT (getutcdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[ProductCategories] ADD  DEFAULT (getutcdate()) FOR [LastModifiedOn]
GO
ALTER TABLE [dbo].[ProductGroups] ADD  DEFAULT (getutcdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[ProductGroups] ADD  DEFAULT (getutcdate()) FOR [LastModifiedOn]
GO
ALTER TABLE [dbo].[ProductItemBundleJoinProductItems] ADD  DEFAULT ((1)) FOR [ProductItemQuantity]
GO
ALTER TABLE [dbo].[ProductItemPrices] ADD  DEFAULT (getutcdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[ProductItemPrices] ADD  DEFAULT (getutcdate()) FOR [LastModifiedOn]
GO
ALTER TABLE [dbo].[ProductItems] ADD  DEFAULT (getutcdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[ProductItems] ADD  DEFAULT (getutcdate()) FOR [LastModifiedOn]
GO
ALTER TABLE [dbo].[ProductStocks] ADD  DEFAULT (N'') FOR [MainCode]
GO
ALTER TABLE [dbo].[PromoOffers] ADD  DEFAULT (getutcdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[SmtpConfigs] ADD  DEFAULT (CONVERT([bit],(1))) FOR [UseAuthentication]
GO
ALTER TABLE [dbo].[SmtpConfigs] ADD  DEFAULT (CONVERT([bit],(1))) FOR [UseSecureConnection]
GO
ALTER TABLE [dbo].[SmtpConfigs] ADD  DEFAULT (getutcdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[SmtpConfigs] ADD  DEFAULT (getutcdate()) FOR [UpdatedDateTime]
GO
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Address_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Address_CustomerId]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[CarouselJoinCarouselImages]  WITH CHECK ADD  CONSTRAINT [FK_CarouselJoinCarouselImage_CarouselId] FOREIGN KEY([CarouselId])
REFERENCES [dbo].[Carousels] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CarouselJoinCarouselImages] CHECK CONSTRAINT [FK_CarouselJoinCarouselImage_CarouselId]
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD  CONSTRAINT [FK_CartItem_CartId] FOREIGN KEY([CartId])
REFERENCES [dbo].[Carts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CartItems] CHECK CONSTRAINT [FK_CartItem_CartId]
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD  CONSTRAINT [FK_CartItems_ProductItems_ProductItemId] FOREIGN KEY([ProductItemId])
REFERENCES [dbo].[ProductItems] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CartItems] CHECK CONSTRAINT [FK_CartItems_ProductItems_ProductItemId]
GO
ALTER TABLE [dbo].[CartProductItemBundles]  WITH CHECK ADD  CONSTRAINT [FK_CartJoinProductItemBundle_CartId] FOREIGN KEY([CartId])
REFERENCES [dbo].[Carts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CartProductItemBundles] CHECK CONSTRAINT [FK_CartJoinProductItemBundle_CartId]
GO
ALTER TABLE [dbo].[CartProductItemBundles]  WITH CHECK ADD  CONSTRAINT [FK_CartJoinProductItemBundle_ProductItemBundleId] FOREIGN KEY([ProductItemBundleId])
REFERENCES [dbo].[ProductItemBundles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CartProductItemBundles] CHECK CONSTRAINT [FK_CartJoinProductItemBundle_ProductItemBundleId]
GO
ALTER TABLE [dbo].[DeliverableBundleItems]  WITH CHECK ADD  CONSTRAINT [FK_DeliverableBundleItem_DeliverableBundleId] FOREIGN KEY([DeliverableBundleId])
REFERENCES [dbo].[DeliverableBundles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DeliverableBundleItems] CHECK CONSTRAINT [FK_DeliverableBundleItem_DeliverableBundleId]
GO
ALTER TABLE [dbo].[DeliverableBundleItems]  WITH CHECK ADD  CONSTRAINT [FK_DeliverableBundleItem_ProductStockId] FOREIGN KEY([ProductStockId])
REFERENCES [dbo].[ProductStocks] ([Id])
GO
ALTER TABLE [dbo].[DeliverableBundleItems] CHECK CONSTRAINT [FK_DeliverableBundleItem_ProductStockId]
GO
ALTER TABLE [dbo].[DeliverableBundles]  WITH CHECK ADD  CONSTRAINT [FK_DeliverableBundle_DeliverableId] FOREIGN KEY([DeliverableId])
REFERENCES [dbo].[Deliverables] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DeliverableBundles] CHECK CONSTRAINT [FK_DeliverableBundle_DeliverableId]
GO
ALTER TABLE [dbo].[DeliverableBundles]  WITH CHECK ADD  CONSTRAINT [FK_DeliverableBundles_ProductItemBundles_ProductItemBundleId] FOREIGN KEY([ProductItemBundleId])
REFERENCES [dbo].[ProductItemBundles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DeliverableBundles] CHECK CONSTRAINT [FK_DeliverableBundles_ProductItemBundles_ProductItemBundleId]
GO
ALTER TABLE [dbo].[DeliverableItems]  WITH CHECK ADD  CONSTRAINT [FK_DeliverableItem_DeliverableId] FOREIGN KEY([DeliverableId])
REFERENCES [dbo].[Deliverables] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DeliverableItems] CHECK CONSTRAINT [FK_DeliverableItem_DeliverableId]
GO
ALTER TABLE [dbo].[DeliverableItems]  WITH CHECK ADD  CONSTRAINT [FK_DeliverableItem_OrderItemId] FOREIGN KEY([OrderItemId])
REFERENCES [dbo].[OrderItem] ([Id])
GO
ALTER TABLE [dbo].[DeliverableItems] CHECK CONSTRAINT [FK_DeliverableItem_OrderItemId]
GO
ALTER TABLE [dbo].[DeliverableItems]  WITH CHECK ADD  CONSTRAINT [FK_DeliverableItem_ProductStockId] FOREIGN KEY([ProductStockId])
REFERENCES [dbo].[ProductStocks] ([Id])
GO
ALTER TABLE [dbo].[DeliverableItems] CHECK CONSTRAINT [FK_DeliverableItem_ProductStockId]
GO
ALTER TABLE [dbo].[Deliverables]  WITH CHECK ADD  CONSTRAINT [FK_Deliverable_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Deliverables] CHECK CONSTRAINT [FK_Deliverable_OrderId]
GO
ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD  CONSTRAINT [FK_OrderItem_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderItem] CHECK CONSTRAINT [FK_OrderItem_OrderId]
GO
ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD  CONSTRAINT [FK_OrderItem_ProductItems_ProductItemId] FOREIGN KEY([ProductItemId])
REFERENCES [dbo].[ProductItems] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderItem] CHECK CONSTRAINT [FK_OrderItem_ProductItems_ProductItemId]
GO
ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD  CONSTRAINT [FK_OrderItem_ProductStocks_ProductStockId] FOREIGN KEY([ProductStockId])
REFERENCES [dbo].[ProductStocks] ([Id])
GO
ALTER TABLE [dbo].[OrderItem] CHECK CONSTRAINT [FK_OrderItem_ProductStocks_ProductStockId]
GO
ALTER TABLE [dbo].[OrderProductItemBundle]  WITH CHECK ADD  CONSTRAINT [FK_OrderJoinProductItemBundle_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[OrderProductItemBundle] CHECK CONSTRAINT [FK_OrderJoinProductItemBundle_OrderId]
GO
ALTER TABLE [dbo].[OrderProductItemBundle]  WITH CHECK ADD  CONSTRAINT [FK_OrderJoinProductItemBundle_ProductItemBundleId] FOREIGN KEY([ProductItemBundleId])
REFERENCES [dbo].[ProductItemBundles] ([Id])
GO
ALTER TABLE [dbo].[OrderProductItemBundle] CHECK CONSTRAINT [FK_OrderJoinProductItemBundle_ProductItemBundleId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Order_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Order_CustomerId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Addresses_BillingAddressId] FOREIGN KEY([BillingAddressId])
REFERENCES [dbo].[Addresses] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Addresses_BillingAddressId]
GO
ALTER TABLE [dbo].[PaymentTransactions]  WITH CHECK ADD  CONSTRAINT [FK_PaymentTransaction_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PaymentTransactions] CHECK CONSTRAINT [FK_PaymentTransaction_OrderId]
GO
ALTER TABLE [dbo].[ProductCategoryJoinProductGroup]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategoryJoinProductGroup_ProductCategoryId] FOREIGN KEY([ProductCategoryId])
REFERENCES [dbo].[ProductCategories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductCategoryJoinProductGroup] CHECK CONSTRAINT [FK_ProductCategoryJoinProductGroup_ProductCategoryId]
GO
ALTER TABLE [dbo].[ProductCategoryJoinProductGroup]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategoryJoinProductGroup_ProductGroupId] FOREIGN KEY([ProductGroupId])
REFERENCES [dbo].[ProductGroups] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductCategoryJoinProductGroup] CHECK CONSTRAINT [FK_ProductCategoryJoinProductGroup_ProductGroupId]
GO
ALTER TABLE [dbo].[ProductItemBundleJoinProductItems]  WITH CHECK ADD  CONSTRAINT [FK_ProductItemBundleJoinProductItem_ProductItemBundleId] FOREIGN KEY([ProductItemBundleId])
REFERENCES [dbo].[ProductItemBundles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductItemBundleJoinProductItems] CHECK CONSTRAINT [FK_ProductItemBundleJoinProductItem_ProductItemBundleId]
GO
ALTER TABLE [dbo].[ProductItemBundleJoinProductItems]  WITH CHECK ADD  CONSTRAINT [FK_ProductItemBundleJoinProductItem_ProductItemId] FOREIGN KEY([ProductItemId])
REFERENCES [dbo].[ProductItems] ([Id])
GO
ALTER TABLE [dbo].[ProductItemBundleJoinProductItems] CHECK CONSTRAINT [FK_ProductItemBundleJoinProductItem_ProductItemId]
GO
ALTER TABLE [dbo].[ProductItemCustomFields]  WITH CHECK ADD  CONSTRAINT [FK_ProductItemCustomField_ProductItemId] FOREIGN KEY([ProductItemId])
REFERENCES [dbo].[ProductItems] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductItemCustomFields] CHECK CONSTRAINT [FK_ProductItemCustomField_ProductItemId]
GO
ALTER TABLE [dbo].[ProductItemFeatures]  WITH CHECK ADD  CONSTRAINT [FK_ProductItemFeatures_ProductItems_ProductItemId] FOREIGN KEY([ProductItemId])
REFERENCES [dbo].[ProductItems] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductItemFeatures] CHECK CONSTRAINT [FK_ProductItemFeatures_ProductItems_ProductItemId]
GO
ALTER TABLE [dbo].[ProductItemJoinProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProductItemJoinProductCategory_ProductCategoryId] FOREIGN KEY([ProductCategoryId])
REFERENCES [dbo].[ProductCategories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductItemJoinProductCategory] CHECK CONSTRAINT [FK_ProductItemJoinProductCategory_ProductCategoryId]
GO
ALTER TABLE [dbo].[ProductItemJoinProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProductItemJoinProductCategory_ProductItemId] FOREIGN KEY([ProductItemId])
REFERENCES [dbo].[ProductItems] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductItemJoinProductCategory] CHECK CONSTRAINT [FK_ProductItemJoinProductCategory_ProductItemId]
GO
ALTER TABLE [dbo].[ProductItemJoinPromoOffer]  WITH CHECK ADD  CONSTRAINT [FK_ProductItemJoinPromoOffer_ProductItemId] FOREIGN KEY([ProductItemId])
REFERENCES [dbo].[ProductItems] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductItemJoinPromoOffer] CHECK CONSTRAINT [FK_ProductItemJoinPromoOffer_ProductItemId]
GO
ALTER TABLE [dbo].[ProductItemJoinPromoOffer]  WITH CHECK ADD  CONSTRAINT [FK_ProductItemJoinPromoOffer_PromoOfferId] FOREIGN KEY([PromoOfferId])
REFERENCES [dbo].[PromoOffers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductItemJoinPromoOffer] CHECK CONSTRAINT [FK_ProductItemJoinPromoOffer_PromoOfferId]
GO
ALTER TABLE [dbo].[ProductItemJoinSearchTagProductItem]  WITH CHECK ADD  CONSTRAINT [FK_ProductItemJoinSearchTagProductItem_ProductItemId] FOREIGN KEY([ProductItemId])
REFERENCES [dbo].[ProductItems] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductItemJoinSearchTagProductItem] CHECK CONSTRAINT [FK_ProductItemJoinSearchTagProductItem_ProductItemId]
GO
ALTER TABLE [dbo].[ProductItemJoinSearchTagProductItem]  WITH CHECK ADD  CONSTRAINT [FK_ProductItemJoinSearchTagProductItem_SearchTagProductItemId] FOREIGN KEY([SearchTagProductItemId])
REFERENCES [dbo].[SearchTagProductItems] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductItemJoinSearchTagProductItem] CHECK CONSTRAINT [FK_ProductItemJoinSearchTagProductItem_SearchTagProductItemId]
GO
ALTER TABLE [dbo].[ProductItemPrices]  WITH CHECK ADD  CONSTRAINT [FK_ProductItemPrice_ProductId] FOREIGN KEY([ProductItemId])
REFERENCES [dbo].[ProductItems] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductItemPrices] CHECK CONSTRAINT [FK_ProductItemPrice_ProductId]
GO
ALTER TABLE [dbo].[ProductSectionJoinProductItem]  WITH CHECK ADD  CONSTRAINT [FK_ProductSectionJoinProductItem_ProductItemId] FOREIGN KEY([ProductItemId])
REFERENCES [dbo].[ProductItems] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductSectionJoinProductItem] CHECK CONSTRAINT [FK_ProductSectionJoinProductItem_ProductItemId]
GO
ALTER TABLE [dbo].[ProductSectionJoinProductItem]  WITH CHECK ADD  CONSTRAINT [FK_ProductSectionJoinProductItem_ProductSectionId] FOREIGN KEY([ProductSectionId])
REFERENCES [dbo].[ProductSections] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductSectionJoinProductItem] CHECK CONSTRAINT [FK_ProductSectionJoinProductItem_ProductSectionId]
GO
ALTER TABLE [dbo].[ProductStockCounts]  WITH CHECK ADD  CONSTRAINT [FK_ProductStockCount_ProductItemId] FOREIGN KEY([ProductItemId])
REFERENCES [dbo].[ProductItems] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductStockCounts] CHECK CONSTRAINT [FK_ProductStockCount_ProductItemId]
GO
ALTER TABLE [dbo].[ProductStocks]  WITH CHECK ADD  CONSTRAINT [FK_ProductStock_ProductItemId] FOREIGN KEY([ProductItemId])
REFERENCES [dbo].[ProductItems] ([Id])
GO
ALTER TABLE [dbo].[ProductStocks] CHECK CONSTRAINT [FK_ProductStock_ProductItemId]
GO
USE [master]
GO
ALTER DATABASE [StoreDb] SET  READ_WRITE 
GO
