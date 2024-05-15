USE [master]
GO
/****** Object:  Database [Телефонный справочник]    Script Date: 15.05.2024 14:34:44 Часы ******/
CREATE DATABASE [Телефонный справочник]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Телефонный справочник', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Телефонный справочник.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Телефонный справочник_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Телефонный справочник_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Телефонный справочник] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Телефонный справочник].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Телефонный справочник] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Телефонный справочник] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Телефонный справочник] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Телефонный справочник] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Телефонный справочник] SET ARITHABORT OFF 
GO
ALTER DATABASE [Телефонный справочник] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Телефонный справочник] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Телефонный справочник] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Телефонный справочник] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Телефонный справочник] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Телефонный справочник] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Телефонный справочник] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Телефонный справочник] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Телефонный справочник] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Телефонный справочник] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Телефонный справочник] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Телефонный справочник] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Телефонный справочник] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Телефонный справочник] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Телефонный справочник] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Телефонный справочник] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Телефонный справочник] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Телефонный справочник] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Телефонный справочник] SET  MULTI_USER 
GO
ALTER DATABASE [Телефонный справочник] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Телефонный справочник] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Телефонный справочник] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Телефонный справочник] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Телефонный справочник] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Телефонный справочник]
GO
/****** Object:  Table [dbo].[Данные о контактах]    Script Date: 15.05.2024 14:34:44 Часы ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Данные о контактах](
	[код контакта] [int] IDENTITY(1,1) NOT NULL,
	[фамилия] [nvarchar](50) NULL,
	[имя] [nvarchar](50) NULL,
	[отчество] [nvarchar](50) NULL,
	[номер телефона] [nvarchar](50) NULL,
	[e-mail] [nvarchar](50) NULL,
	[компания] [int] NULL,
	[должность] [int] NULL,
	[группа контактов] [nvarchar](50) NULL,
	[дата рождения] [date] NULL,
 CONSTRAINT [PK_Данные о контактах] PRIMARY KEY CLUSTERED 
(
	[код контакта] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Должности]    Script Date: 15.05.2024 14:34:44 Часы ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Должности](
	[код должности] [int] IDENTITY(1,1) NOT NULL,
	[название должности] [nvarchar](50) NULL,
 CONSTRAINT [PK_Должности] PRIMARY KEY CLUSTERED 
(
	[код должности] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Компании]    Script Date: 15.05.2024 14:34:44 Часы ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Компании](
	[код компании] [int] IDENTITY(1,1) NOT NULL,
	[название] [nvarchar](50) NULL,
	[адрес] [nvarchar](50) NULL,
	[телефон] [nvarchar](50) NULL,
 CONSTRAINT [PK_Компании] PRIMARY KEY CLUSTERED 
(
	[код компании] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Данные о контактах] ON 

INSERT [dbo].[Данные о контактах] ([код контакта], [фамилия], [имя], [отчество], [номер телефона], [e-mail], [компания], [должность], [группа контактов], [дата рождения]) VALUES (1, N'Кочкин', N'Валентин', N'Андреевич', N'+79125759634', N'val@mail.ru', 1, 1, N'Родственники', CAST(N'2000-08-14' AS Date))
INSERT [dbo].[Данные о контактах] ([код контакта], [фамилия], [имя], [отчество], [номер телефона], [e-mail], [компания], [должность], [группа контактов], [дата рождения]) VALUES (2, N'Абатуров', N'Константин', N'Павлович', N'+79194226519', N'kon@mail.ru', 2, 2, N'Коллеги', CAST(N'1998-06-10' AS Date))
INSERT [dbo].[Данные о контактах] ([код контакта], [фамилия], [имя], [отчество], [номер телефона], [e-mail], [компания], [должность], [группа контактов], [дата рождения]) VALUES (3, N'Матвеев', N'Степан', N'Юрьевич', N'+79153229117', N'step@mail.ru', 3, 3, N'Коллеги', CAST(N'1999-02-03' AS Date))
INSERT [dbo].[Данные о контактах] ([код контакта], [фамилия], [имя], [отчество], [номер телефона], [e-mail], [компания], [должность], [группа контактов], [дата рождения]) VALUES (4, N'Валуев', N'Владимир', N'Васильевич', N'+79136742981', N'vlad@mail.ru', 2, 2, N'Друзья', CAST(N'2000-02-02' AS Date))
INSERT [dbo].[Данные о контактах] ([код контакта], [фамилия], [имя], [отчество], [номер телефона], [e-mail], [компания], [должность], [группа контактов], [дата рождения]) VALUES (6, N'Хохрин', N'Никита', N'Владимирович', N'+79123447965', N'nikita@mail.ru', 3, 4, N'Родственники', CAST(N'2005-02-13' AS Date))
SET IDENTITY_INSERT [dbo].[Данные о контактах] OFF
SET IDENTITY_INSERT [dbo].[Должности] ON 

INSERT [dbo].[Должности] ([код должности], [название должности]) VALUES (1, N'программист')
INSERT [dbo].[Должности] ([код должности], [название должности]) VALUES (2, N'менеджер')
INSERT [dbo].[Должности] ([код должности], [название должности]) VALUES (3, N'backend-разработчик')
INSERT [dbo].[Должности] ([код должности], [название должности]) VALUES (4, N'frontend-разработчик')
SET IDENTITY_INSERT [dbo].[Должности] OFF
SET IDENTITY_INSERT [dbo].[Компании] ON 

INSERT [dbo].[Компании] ([код компании], [название], [адрес], [телефон]) VALUES (1, N'ЭлектронСофт', N'ул. Пушкина', N'8883344')
INSERT [dbo].[Компании] ([код компании], [название], [адрес], [телефон]) VALUES (2, N'МастерСофт', N'ул. Зелёная', N'4455772')
INSERT [dbo].[Компании] ([код компании], [название], [адрес], [телефон]) VALUES (3, N'ТрэйдСофт', N'ул. Профсоюзная', N'6848941')
SET IDENTITY_INSERT [dbo].[Компании] OFF
ALTER TABLE [dbo].[Данные о контактах]  WITH CHECK ADD  CONSTRAINT [FK_Данные о контактах_Должности] FOREIGN KEY([должность])
REFERENCES [dbo].[Должности] ([код должности])
GO
ALTER TABLE [dbo].[Данные о контактах] CHECK CONSTRAINT [FK_Данные о контактах_Должности]
GO
ALTER TABLE [dbo].[Данные о контактах]  WITH CHECK ADD  CONSTRAINT [FK_Данные о контактах_Компании] FOREIGN KEY([компания])
REFERENCES [dbo].[Компании] ([код компании])
GO
ALTER TABLE [dbo].[Данные о контактах] CHECK CONSTRAINT [FK_Данные о контактах_Компании]
GO
USE [master]
GO
ALTER DATABASE [Телефонный справочник] SET  READ_WRITE 
GO
