---Create Database approach with multiple tables.
---Step1:- create database 
CREATE DATABASE University
use University
---Step2:- 
--student table 
CREATE TABLE [dbo].[Student] (
    [StudentID] INT IDENTITY (1, 1) NOT NULL,
    [LastName] NVARCHAR (50) NULL,
    [FirstName] NVARCHAR (50) NULL,
    [EnrollmentDate] DATETIME NULL,
    PRIMARY KEY CLUSTERED ([StudentID] ASC)
)

--course table 
CREATE TABLE [dbo].[Course] (
    [CourseID] INT           IDENTITY (1, 1) NOT NULL,
    [Title]    NVARCHAR (50) NULL,
    [Credits]  INT           NULL,
    PRIMARY KEY CLUSTERED ([CourseID] ASC)
)

--enrollment table
CREATE TABLE [dbo].[Enrollment] (
    [EnrollmentID] INT IDENTITY (1, 1) NOT NULL,
    [Grade]        DECIMAL(3, 2) NULL,
    [CourseID]     INT NOT NULL,
    [StudentID]    INT NOT NULL,
    PRIMARY KEY CLUSTERED ([EnrollmentID] ASC))
	drop database University