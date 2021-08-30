SET IDENTITY_INSERT [dbo].[IssuedBooks] ON
INSERT INTO [dbo].[IssuedBooks] ([IssuedBookId], [ReaderId], [BookId], [DateOfIssue], [DateOfReturn], [BookReturn], [BookCondition]) VALUES (1, 4, 2, N'2021-02-21', N'2021-04-01', 1, 3)
INSERT INTO [dbo].[IssuedBooks] ([IssuedBookId], [ReaderId], [BookId], [DateOfIssue], [DateOfReturn], [BookReturn], [BookCondition]) VALUES (2, 4, 3, N'2021-01-22', N'2021-03-15', 1, 2)
INSERT INTO [dbo].[IssuedBooks] ([IssuedBookId], [ReaderId], [BookId], [DateOfIssue], [DateOfReturn], [BookReturn], [BookCondition]) VALUES (3, 1, 4, N'2021-06-02', N'2021-09-21', 0, 4)
INSERT INTO [dbo].[IssuedBooks] ([IssuedBookId], [ReaderId], [BookId], [DateOfIssue], [DateOfReturn], [BookReturn], [BookCondition]) VALUES (4, 5, 1, N'2021-06-06', N'2021-10-30', 0, 5)
INSERT INTO [dbo].[IssuedBooks] ([IssuedBookId], [ReaderId], [BookId], [DateOfIssue], [DateOfReturn], [BookReturn], [BookCondition]) VALUES (5, 2, 3, N'2021-05-21', N'2021-06-05', 1, 5)
INSERT INTO [dbo].[IssuedBooks] ([IssuedBookId], [ReaderId], [BookId], [DateOfIssue], [DateOfReturn], [BookReturn], [BookCondition]) VALUES (6, 3, 5, N'2021-04-05', N'2021-07-03', 0, 4)
SET IDENTITY_INSERT [dbo].[IssuedBooks] OFF
