USE [Retail]
GO
SET IDENTITY_INSERT [dbo].[Emp_details] ON 

INSERT [dbo].[Emp_details] ([EmployeeID], [EmployeeName], [Address], [Mobile_No]) VALUES (26, N'Brian Murphy', N'Cork', 892145615)
INSERT [dbo].[Emp_details] ([EmployeeID], [EmployeeName], [Address], [Mobile_No]) VALUES (27, N'Ted Scully', N'Dublin', 892141456)
INSERT [dbo].[Emp_details] ([EmployeeID], [EmployeeName], [Address], [Mobile_No]) VALUES (28, N'Luke smith', N'Cork', 892422467)
INSERT [dbo].[Emp_details] ([EmployeeID], [EmployeeName], [Address], [Mobile_No]) VALUES (29, N'John smith', N'Dublin', 892141464)
SET IDENTITY_INSERT [dbo].[Emp_details] OFF
GO
SET IDENTITY_INSERT [dbo].[Revenue_details] ON 

INSERT [dbo].[Revenue_details] ([ID], [EmployeeID], [Shits], [work_date], [hrs_worked], [Revenue]) VALUES (4, 6, 1, N'2021-08-07', N'2         ', 20)
INSERT [dbo].[Revenue_details] ([ID], [EmployeeID], [Shits], [work_date], [hrs_worked], [Revenue]) VALUES (5, 7, 1, N'2021-08-06', N'2         ', 20)
INSERT [dbo].[Revenue_details] ([ID], [EmployeeID], [Shits], [work_date], [hrs_worked], [Revenue]) VALUES (6, 22, 2, N'2021-08-07', N'5         ', 55)
INSERT [dbo].[Revenue_details] ([ID], [EmployeeID], [Shits], [work_date], [hrs_worked], [Revenue]) VALUES (7, 23, 1, N'2021-08-07', N'4         ', 40)
INSERT [dbo].[Revenue_details] ([ID], [EmployeeID], [Shits], [work_date], [hrs_worked], [Revenue]) VALUES (8, 24, 2, N'2021-08-05', N'2         ', 22)
INSERT [dbo].[Revenue_details] ([ID], [EmployeeID], [Shits], [work_date], [hrs_worked], [Revenue]) VALUES (9, 25, 1, N'2021-08-05', N'1         ', 10)
INSERT [dbo].[Revenue_details] ([ID], [EmployeeID], [Shits], [work_date], [hrs_worked], [Revenue]) VALUES (10, 25, 1, N'2021-08-04', N'6         ', 60)
INSERT [dbo].[Revenue_details] ([ID], [EmployeeID], [Shits], [work_date], [hrs_worked], [Revenue]) VALUES (11, 24, 1, N'2021-08-04', N'1         ', 10)
INSERT [dbo].[Revenue_details] ([ID], [EmployeeID], [Shits], [work_date], [hrs_worked], [Revenue]) VALUES (12, 26, 1, N'2021-08-03', N'4         ', 40)
INSERT [dbo].[Revenue_details] ([ID], [EmployeeID], [Shits], [work_date], [hrs_worked], [Revenue]) VALUES (13, 27, 2, N'2021-08-05', N'5         ', 55)
INSERT [dbo].[Revenue_details] ([ID], [EmployeeID], [Shits], [work_date], [hrs_worked], [Revenue]) VALUES (14, 28, 1, N'2021-08-10', N'4         ', 40)
INSERT [dbo].[Revenue_details] ([ID], [EmployeeID], [Shits], [work_date], [hrs_worked], [Revenue]) VALUES (15, 29, 2, N'2021-08-03', N'3         ', 33)
SET IDENTITY_INSERT [dbo].[Revenue_details] OFF
GO
INSERT [dbo].[WorkShifts] ([ID], [Shifts], [MiniBreak], [LongBreak], [per_hr_pay]) VALUES (1, N'DayShift', 10, 20, 10)
INSERT [dbo].[WorkShifts] ([ID], [Shifts], [MiniBreak], [LongBreak], [per_hr_pay]) VALUES (2, N'NightShift', 15, 30, 11)
GO
