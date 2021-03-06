USE [master]
GO
/****** Object:  Database [Wyposazenie dla silowni]    Script Date: 15.02.2021 16:21:31 ******/
CREATE DATABASE [Wyposazenie dla silowni]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Wyposazenie dla silowni', FILENAME = N'H:\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Wyposazenie dla silowni.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Wyposazenie dla silowni_log', FILENAME = N'H:\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Wyposazenie dla silowni_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Wyposazenie dla silowni] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Wyposazenie dla silowni].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Wyposazenie dla silowni] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Wyposazenie dla silowni] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Wyposazenie dla silowni] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Wyposazenie dla silowni] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Wyposazenie dla silowni] SET ARITHABORT OFF 
GO
ALTER DATABASE [Wyposazenie dla silowni] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Wyposazenie dla silowni] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Wyposazenie dla silowni] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Wyposazenie dla silowni] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Wyposazenie dla silowni] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Wyposazenie dla silowni] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Wyposazenie dla silowni] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Wyposazenie dla silowni] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Wyposazenie dla silowni] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Wyposazenie dla silowni] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Wyposazenie dla silowni] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Wyposazenie dla silowni] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Wyposazenie dla silowni] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Wyposazenie dla silowni] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Wyposazenie dla silowni] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Wyposazenie dla silowni] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Wyposazenie dla silowni] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Wyposazenie dla silowni] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Wyposazenie dla silowni] SET  MULTI_USER 
GO
ALTER DATABASE [Wyposazenie dla silowni] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Wyposazenie dla silowni] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Wyposazenie dla silowni] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Wyposazenie dla silowni] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Wyposazenie dla silowni] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Wyposazenie dla silowni] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Wyposazenie dla silowni] SET QUERY_STORE = OFF
GO
USE [Wyposazenie dla silowni]
GO
/****** Object:  Table [dbo].[DaneLogin]    Script Date: 15.02.2021 16:21:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DaneLogin](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NazwaUzytkownika] [varchar](50) NOT NULL,
	[Haslo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_DaneLogin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Klienci]    Script Date: 15.02.2021 16:21:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Klienci](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Imie] [varchar](50) NOT NULL,
	[Nazwisko] [varchar](50) NOT NULL,
	[Miasto] [varchar](50) NOT NULL,
	[ObslugujacyPracownik] [int] NOT NULL,
 CONSTRAINT [PK_Klienci] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pracownicy]    Script Date: 15.02.2021 16:21:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pracownicy](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Imie] [varchar](50) NOT NULL,
	[Nazwisko] [varchar](50) NOT NULL,
	[Wiek] [int] NOT NULL,
 CONSTRAINT [PK_Pracownicy] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produkty]    Script Date: 15.02.2021 16:21:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produkty](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nazwa] [varchar](50) NOT NULL,
	[Cena] [int] NOT NULL,
	[WagaKG] [int] NOT NULL,
 CONSTRAINT [PK_Produkty] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Zamowienia]    Script Date: 15.02.2021 16:21:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zamowienia](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Produkt] [int] NOT NULL,
	[DataZlozeniaZamowienia] [date] NOT NULL,
	[Klient] [int] NOT NULL,
 CONSTRAINT [PK_Zamowienia] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Klienci]  WITH CHECK ADD  CONSTRAINT [FK_Klienci_Pracownicy] FOREIGN KEY([ObslugujacyPracownik])
REFERENCES [dbo].[Pracownicy] ([ID])
GO
ALTER TABLE [dbo].[Klienci] CHECK CONSTRAINT [FK_Klienci_Pracownicy]
GO
ALTER TABLE [dbo].[Zamowienia]  WITH CHECK ADD  CONSTRAINT [FK_Zamowienia_Klienci] FOREIGN KEY([Klient])
REFERENCES [dbo].[Klienci] ([ID])
GO
ALTER TABLE [dbo].[Zamowienia] CHECK CONSTRAINT [FK_Zamowienia_Klienci]
GO
ALTER TABLE [dbo].[Zamowienia]  WITH CHECK ADD  CONSTRAINT [FK_Zamowienia_Produkty] FOREIGN KEY([Produkt])
REFERENCES [dbo].[Produkty] ([ID])
GO
ALTER TABLE [dbo].[Zamowienia] CHECK CONSTRAINT [FK_Zamowienia_Produkty]
GO
USE [master]
GO
ALTER DATABASE [Wyposazenie dla silowni] SET  READ_WRITE 
GO
