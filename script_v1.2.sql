USE [DemoIdentity]
GO
/****** Object:  Table [dbo].[Permissions]    Script Date: 9/6/2022 5:31:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PermissionName] [nvarchar](50) NOT NULL,
	[PermissionCode] [varchar](50) NOT NULL,
	[PermissionOrder] [int] NOT NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[Status] [int] NULL,
	[Description] [text] NULL,
 CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolePermission]    Script Date: 9/6/2022 5:31:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolePermission](
	[RoleId] [int] NOT NULL,
	[PermissionId] [int] NOT NULL,
 CONSTRAINT [PK_RolePermission] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC,
	[PermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 9/6/2022 5:31:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[Status] [int] NULL,
	[Description] [text] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserNotification]    Script Date: 9/6/2022 5:31:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserNotification](
	[ReceiverId] [bigint] NOT NULL,
	[NotiId] [bigint] NOT NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[Status] [int] NULL,
	[Description] [text] NULL,
 CONSTRAINT [PK_UserNotification_1] PRIMARY KEY CLUSTERED 
(
	[ReceiverId] ASC,
	[NotiId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 9/6/2022 5:31:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[UserId] [bigint] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 9/6/2022 5:31:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[Phone] [varchar](15) NULL,
	[Address] [nvarchar](50) NULL,
	[Gender] [int] NOT NULL,
	[DateOfBirth] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedOn] [datetime] NULL,
	[Status] [int] NULL,
	[Description] [text] NULL,
	[Token] [varchar](200) NULL,
	[TokenExpired] [datetime] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Permissions] ON 

INSERT [dbo].[Permissions] ([Id], [PermissionName], [PermissionCode], [PermissionOrder], [CreatedBy], [CreatedOn], [ModifiedOn], [ModifiedBy], [Status], [Description]) VALUES (1, N'View User', N'ViewUser', 0, 1, CAST(N'2022-01-01T00:00:00.000' AS DateTime), NULL, NULL, 1, NULL)
INSERT [dbo].[Permissions] ([Id], [PermissionName], [PermissionCode], [PermissionOrder], [CreatedBy], [CreatedOn], [ModifiedOn], [ModifiedBy], [Status], [Description]) VALUES (2, N'Create User', N'CreateUser', 1, 1, CAST(N'2022-01-01T00:00:00.000' AS DateTime), NULL, NULL, 1, NULL)
INSERT [dbo].[Permissions] ([Id], [PermissionName], [PermissionCode], [PermissionOrder], [CreatedBy], [CreatedOn], [ModifiedOn], [ModifiedBy], [Status], [Description]) VALUES (3, N'Update User', N'UpdateUser', 2, 1, CAST(N'2022-01-01T00:00:00.000' AS DateTime), NULL, NULL, 1, NULL)
INSERT [dbo].[Permissions] ([Id], [PermissionName], [PermissionCode], [PermissionOrder], [CreatedBy], [CreatedOn], [ModifiedOn], [ModifiedBy], [Status], [Description]) VALUES (5, N'Delete User', N'DeleteUser', 3, 1, CAST(N'2022-01-01T00:00:00.000' AS DateTime), NULL, NULL, 1, NULL)
INSERT [dbo].[Permissions] ([Id], [PermissionName], [PermissionCode], [PermissionOrder], [CreatedBy], [CreatedOn], [ModifiedOn], [ModifiedBy], [Status], [Description]) VALUES (7, N'View Role', N'ViewRole', 4, 1, CAST(N'2022-01-01T00:00:00.000' AS DateTime), NULL, NULL, 1, NULL)
INSERT [dbo].[Permissions] ([Id], [PermissionName], [PermissionCode], [PermissionOrder], [CreatedBy], [CreatedOn], [ModifiedOn], [ModifiedBy], [Status], [Description]) VALUES (8, N'Create Role', N'CreateRole', 5, 1, CAST(N'2022-01-01T00:00:00.000' AS DateTime), NULL, NULL, 1, NULL)
INSERT [dbo].[Permissions] ([Id], [PermissionName], [PermissionCode], [PermissionOrder], [CreatedBy], [CreatedOn], [ModifiedOn], [ModifiedBy], [Status], [Description]) VALUES (9, N'Update Role', N'UpdateRole', 6, 1, CAST(N'2022-01-01T00:00:00.000' AS DateTime), NULL, NULL, 1, NULL)
INSERT [dbo].[Permissions] ([Id], [PermissionName], [PermissionCode], [PermissionOrder], [CreatedBy], [CreatedOn], [ModifiedOn], [ModifiedBy], [Status], [Description]) VALUES (10, N'Delete Role', N'DeleteRole', 7, 1, CAST(N'2022-01-01T00:00:00.000' AS DateTime), NULL, NULL, 1, NULL)
SET IDENTITY_INSERT [dbo].[Permissions] OFF
GO
INSERT [dbo].[RolePermission] ([RoleId], [PermissionId]) VALUES (1, 1)
INSERT [dbo].[RolePermission] ([RoleId], [PermissionId]) VALUES (1, 2)
INSERT [dbo].[RolePermission] ([RoleId], [PermissionId]) VALUES (1, 3)
INSERT [dbo].[RolePermission] ([RoleId], [PermissionId]) VALUES (2, 2)
INSERT [dbo].[RolePermission] ([RoleId], [PermissionId]) VALUES (3, 2)
INSERT [dbo].[RolePermission] ([RoleId], [PermissionId]) VALUES (3, 3)
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [RoleName], [Status], [Description], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (1, N'Super Admin', 1, NULL, 1, CAST(N'2020-01-01T00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[Roles] ([Id], [RoleName], [Status], [Description], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (2, N'Admin', 1, NULL, 1, CAST(N'2022-01-01T00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[Roles] ([Id], [RoleName], [Status], [Description], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (3, N'User', 1, NULL, 1, CAST(N'2022-01-01T00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
INSERT [dbo].[UserRole] ([UserId], [RoleId]) VALUES (1, 2)
INSERT [dbo].[UserRole] ([UserId], [RoleId]) VALUES (2, 1)
INSERT [dbo].[UserRole] ([UserId], [RoleId]) VALUES (3, 3)
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [UserName], [Password], [Email], [FullName], [Phone], [Address], [Gender], [DateOfBirth], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [Status], [Description], [Token], [TokenExpired]) VALUES (1, N'useraccount', N'123456', N'user@gmail.com', N'User 1', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[Users] ([Id], [UserName], [Password], [Email], [FullName], [Phone], [Address], [Gender], [DateOfBirth], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [Status], [Description], [Token], [TokenExpired]) VALUES (2, N'adminaccount', N'123456', N'admin@gmail.com', N'Admin', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[Users] ([Id], [UserName], [Password], [Email], [FullName], [Phone], [Address], [Gender], [DateOfBirth], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [Status], [Description], [Token], [TokenExpired]) VALUES (3, N'useraccount1', N'123456', N'user2@gmail.com', N'User 2', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[Users] ([Id], [UserName], [Password], [Email], [FullName], [Phone], [Address], [Gender], [DateOfBirth], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [Status], [Description], [Token], [TokenExpired]) VALUES (4, N'useraccount2', N'123456', N'user3@gmail.com', N'User 3', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[RolePermission]  WITH CHECK ADD  CONSTRAINT [FK_RolePermission_Permissions] FOREIGN KEY([PermissionId])
REFERENCES [dbo].[Permissions] ([Id])
GO
ALTER TABLE [dbo].[RolePermission] CHECK CONSTRAINT [FK_RolePermission_Permissions]
GO
ALTER TABLE [dbo].[RolePermission]  WITH CHECK ADD  CONSTRAINT [FK_RolePermission_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[RolePermission] CHECK CONSTRAINT [FK_RolePermission_Roles]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_Roles]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Users1] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_Users1]
GO
