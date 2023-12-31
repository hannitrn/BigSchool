USE [BigSchool]
GO
/****** Object:  Table [dbo].[Attendance]    Script Date: 10/06/2023 4:19:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attendance](
	[CourseId] [int] NOT NULL,
	[Attendee] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_Attendance] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC,
	[Attendee] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 10/06/2023 4:19:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 10/06/2023 4:19:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LectureId] [nvarchar](128) NOT NULL,
	[Place] [nvarchar](255) NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[LectureName] [nvarchar](250) NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Following]    Script Date: 10/06/2023 4:19:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Following](
	[FollowerId] [nvarchar](128) NOT NULL,
	[FolloweeId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_Following] PRIMARY KEY CLUSTERED 
(
	[FollowerId] ASC,
	[FolloweeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FK_Attendance_AspNetUsers] FOREIGN KEY([Attendee])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [FK_Attendance_AspNetUsers]
GO
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FK_Attendance_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [FK_Attendance_Course]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_AspNetUsers] FOREIGN KEY([LectureId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_AspNetUsers]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Category]
GO
ALTER TABLE [dbo].[Following]  WITH CHECK ADD  CONSTRAINT [FK_Following_AspNetUsers] FOREIGN KEY([FollowerId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Following] CHECK CONSTRAINT [FK_Following_AspNetUsers]
GO
ALTER TABLE [dbo].[Following]  WITH CHECK ADD  CONSTRAINT [FK_Following_AspNetUsers1] FOREIGN KEY([FolloweeId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Following] CHECK CONSTRAINT [FK_Following_AspNetUsers1]
GO
