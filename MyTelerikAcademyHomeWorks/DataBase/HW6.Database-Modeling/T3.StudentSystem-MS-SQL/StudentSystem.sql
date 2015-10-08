USE [master]
GO
/****** Object:  Database [StudentSystem]    Script Date: 28-Sep-15 12:56:30 AM ******/
CREATE DATABASE [StudentSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StudentSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.ANGE\MSSQL\DATA\StudentSystem.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'StudentSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.ANGE\MSSQL\DATA\StudentSystem_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [StudentSystem] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StudentSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StudentSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StudentSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StudentSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StudentSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StudentSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [StudentSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StudentSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StudentSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StudentSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StudentSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StudentSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StudentSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StudentSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StudentSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StudentSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StudentSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StudentSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StudentSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StudentSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StudentSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StudentSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StudentSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StudentSystem] SET RECOVERY FULL 
GO
ALTER DATABASE [StudentSystem] SET  MULTI_USER 
GO
ALTER DATABASE [StudentSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StudentSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StudentSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StudentSystem] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [StudentSystem] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'StudentSystem', N'ON'
GO
USE [StudentSystem]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 28-Sep-15 12:56:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [nvarchar](50) NOT NULL,
	[TrainigHours] [int] NULL,
 CONSTRAINT [PK_COURSE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Departments]    Script Date: 28-Sep-15 12:56:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [nvarchar](50) NOT NULL,
	[FacultyId] [int] NULL,
 CONSTRAINT [PK_DEPARTMENT] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Departments_Courses]    Script Date: 28-Sep-15 12:56:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments_Courses](
	[DepartmentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Faculties]    Script Date: 28-Sep-15 12:56:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculties](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FacultyName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_FACULTY] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Professors]    Script Date: 28-Sep-15 12:56:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[DepartmentId] [int] NULL,
 CONSTRAINT [PK_PROFESSOR] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Professors_Titles]    Script Date: 28-Sep-15 12:56:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professors_Titles](
	[ProfessorId] [int] NOT NULL,
	[TitleId] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Students]    Script Date: 28-Sep-15 12:56:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nchar](25) NULL,
	[LastName] [nchar](25) NOT NULL,
	[AdmissionDate] [date] NULL,
	[FacultyId] [int] NULL,
 CONSTRAINT [PK_STUDENT] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Students_Courses]    Script Date: 28-Sep-15 12:56:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students_Courses](
	[StudentId] [int] NOT NULL,
	[CourseId] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Titles]    Script Date: 28-Sep-15 12:56:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Titles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_TITLE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Departments]  WITH CHECK ADD  CONSTRAINT [FK_DEPARTMENT_FACULTY] FOREIGN KEY([FacultyId])
REFERENCES [dbo].[Faculties] ([Id])
GO
ALTER TABLE [dbo].[Departments] CHECK CONSTRAINT [FK_DEPARTMENT_FACULTY]
GO
ALTER TABLE [dbo].[Departments_Courses]  WITH CHECK ADD  CONSTRAINT [FK_DEPARTMENTS_COURSES_COURSE] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])
GO
ALTER TABLE [dbo].[Departments_Courses] CHECK CONSTRAINT [FK_DEPARTMENTS_COURSES_COURSE]
GO
ALTER TABLE [dbo].[Departments_Courses]  WITH CHECK ADD  CONSTRAINT [FK_DEPARTMENTS_COURSES_DEPARTMENT] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([Id])
GO
ALTER TABLE [dbo].[Departments_Courses] CHECK CONSTRAINT [FK_DEPARTMENTS_COURSES_DEPARTMENT]
GO
ALTER TABLE [dbo].[Professors]  WITH CHECK ADD  CONSTRAINT [FK_PROFESSOR_DEPARTMENT] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([Id])
GO
ALTER TABLE [dbo].[Professors] CHECK CONSTRAINT [FK_PROFESSOR_DEPARTMENT]
GO
ALTER TABLE [dbo].[Professors_Titles]  WITH CHECK ADD  CONSTRAINT [FK_PROFESSORS_TITLES_PROFESSOR] FOREIGN KEY([ProfessorId])
REFERENCES [dbo].[Professors] ([Id])
GO
ALTER TABLE [dbo].[Professors_Titles] CHECK CONSTRAINT [FK_PROFESSORS_TITLES_PROFESSOR]
GO
ALTER TABLE [dbo].[Professors_Titles]  WITH CHECK ADD  CONSTRAINT [FK_PROFESSORS_TITLES_TITLE] FOREIGN KEY([TitleId])
REFERENCES [dbo].[Titles] ([Id])
GO
ALTER TABLE [dbo].[Professors_Titles] CHECK CONSTRAINT [FK_PROFESSORS_TITLES_TITLE]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_STUDENT_FACULTY] FOREIGN KEY([FacultyId])
REFERENCES [dbo].[Faculties] ([Id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_STUDENT_FACULTY]
GO
ALTER TABLE [dbo].[Students_Courses]  WITH CHECK ADD  CONSTRAINT [FK_STUDENTS_COURSES_COURSE] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])
GO
ALTER TABLE [dbo].[Students_Courses] CHECK CONSTRAINT [FK_STUDENTS_COURSES_COURSE]
GO
ALTER TABLE [dbo].[Students_Courses]  WITH CHECK ADD  CONSTRAINT [FK_STUDENTS_COURSES_STUDENT] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
GO
ALTER TABLE [dbo].[Students_Courses] CHECK CONSTRAINT [FK_STUDENTS_COURSES_STUDENT]
GO
USE [master]
GO
ALTER DATABASE [StudentSystem] SET  READ_WRITE 
GO
