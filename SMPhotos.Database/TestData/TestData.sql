--User
INSERT INTO [smp].[User] ([Email], [Password], [FirstName], [LastName], [Location], [IsAdmin], [IsActive], [IsUploader]) VALUES ('mail@mail.com', 'password', 'Adminka', 'Super', 'Ukraine', 1, 1, 1);
INSERT INTO [smp].[User] ([Email], [Password], [FirstName], [LastName], [Location], [IsAdmin], [IsActive], [IsUploader]) VALUES ('uploader@mail.com', 'uploader', 'Dorothy', 'Murray', 'Honduras', 0, 1, 1);
INSERT INTO [smp].[User] ([Email], [Password], [FirstName], [LastName], [Location], [IsAdmin], [IsActive], [IsUploader]) VALUES ('user@user.com', 'user', 'Ashley', 'Austin', 'Cameroon', 0, 1, 0);
INSERT INTO [smp].[User] ([Email], [Password], [FirstName], [LastName], [Location], [IsAdmin], [IsActive], [IsUploader]) VALUES ('awalker3@archive.org', 'HLcHDA0', 'Anna', 'Walker', 'China', 0, 0, 0);
INSERT INTO [smp].[User] ([Email], [Password], [FirstName], [LastName], [Location], [IsAdmin], [IsActive], [IsUploader]) VALUES ('bhart4@npr.org', 'F39BhZTBbKk', 'Brenda', 'Hart', 'Japan', 0, 0, 0);
INSERT INTO [smp].[User] ([Email], [Password], [FirstName], [LastName], [Location], [IsAdmin], [IsActive], [IsUploader]) VALUES ('pjacobs5@storify.com', 'gnTVJON', 'Phyllis', 'Jacobs', 'France', 0, 0, 0);
INSERT INTO [smp].[User] ([Email], [Password], [FirstName], [LastName], [Location], [IsAdmin], [IsActive], [IsUploader]) VALUES ('afowler6@rakuten.co.jp', 'fWncRcDtZ7Iv', 'Angela', 'Fowler', 'China', 0, 0, 0);
INSERT INTO [smp].[User] ([Email], [Password], [FirstName], [LastName], [Location], [IsAdmin], [IsActive], [IsUploader]) VALUES ('ipalmer7@vistaprint.com', '4kBffvl', 'Irene', 'Palmer', 'France', 0, 0, 0);
INSERT INTO [smp].[User] ([Email], [Password], [FirstName], [LastName], [Location], [IsAdmin], [IsActive], [IsUploader]) VALUES ('cmeyer8@techcrunch.com', 'LupMMea0', 'Carol', 'Meyer', 'China', 0, 0, 0);
INSERT INTO [smp].[User] ([Email], [Password], [FirstName], [LastName], [Location], [IsAdmin], [IsActive], [IsUploader]) VALUES ('glane9@rakuten.co.jp', 'DOvLk0w0n1n', 'George', 'Lane', 'Indonesia', 0, 0, 0);
INSERT INTO [smp].[User] ([Email], [Password], [FirstName], [LastName], [Location], [IsAdmin], [IsActive], [IsUploader]) VALUES ('drobinsona@uiuc.edu', 'cyDfWXiVu8c', 'Douglas', 'Robinson', 'Czech Republic', 0, 0, 0);
INSERT INTO [smp].[User] ([Email], [Password], [FirstName], [LastName], [Location], [IsAdmin], [IsActive], [IsUploader]) VALUES ('cgutierrezb@pcworld.com', 'L9EiLwOiZn', 'Carl', 'Gutierrez', 'Sweden', 0, 0, 0);
INSERT INTO [smp].[User] ([Email], [Password], [FirstName], [LastName], [Location], [IsAdmin], [IsActive], [IsUploader]) VALUES ('pgrahamc@flickr.com', 'ERxlSpCQg0X', 'Phillip', 'Graham', 'China', 0, 0, 0);
INSERT INTO [smp].[User] ([Email], [Password], [FirstName], [LastName], [Location], [IsAdmin], [IsActive], [IsUploader]) VALUES ('kevansd@pcworld.com', 'SuCBZEO', 'Karen', 'Evans', 'Bolivia', 0, 0, 0);
INSERT INTO [smp].[User] ([Email], [Password], [FirstName], [LastName], [Location], [IsAdmin], [IsActive], [IsUploader]) VALUES ('dolsone@hubpages.com', 'gN634zx', 'Debra', 'Olson', 'China', 0, 0, 0);
INSERT INTO [smp].[User] ([Email], [Password], [FirstName], [LastName], [Location], [IsAdmin], [IsActive], [IsUploader]) VALUES ('jriveraf@miitbeian.gov.cn', 'a415Oi', 'Juan', 'Rivera', 'Brazil', 0, 0, 0);
INSERT INTO [smp].[User] ([Email], [Password], [FirstName], [LastName], [Location], [IsAdmin], [IsActive], [IsUploader]) VALUES ('wbowmanu@fastcompany.com', 'lgtdw1LQmdf', 'Wayne', 'Bowman', 'New Zealand', 0, 1, 1);

--Album
SET IDENTITY_INSERT [smp].[Album] ON
	INSERT INTO [smp].[Album] ([Id], [Name], [Description], [Path], [Guid]) VALUES (1, 'Nature', 'Nature', 'App_Data', 'DE78FD3C-4534-4A68-ADC4-EFCC72F89363');
	INSERT INTO [smp].[Album] ([Id], [Name], [Description], [Path], [Guid]) VALUES (2, 'Students', 'C# IT Academy 2016', 'App_Data', '39D09D90-B53C-47D8-BAB6-F96630F9BC9B');
	INSERT INTO [smp].[Album] ([Id], [Name], [Description], [Path], [Guid]) VALUES (3, 'Animals', 'Animals', 'App_Data', 'FB3840F6-67B5-4F49-A0DD-707895F680CB');
	INSERT INTO [smp].[Album] ([Id], [Name], [Description], [Path], [Guid]) VALUES (4, 'Amsterdam', 'Amsterdam', 'App_Data', 'E5AF00CC-726E-4252-A13E-459C6567454A');
	INSERT INTO [smp].[Album] ([Id], [Name], [Description], [Path], [Guid]) VALUES (5, 'Hannover', 'Hannover', 'App_Data', 'F56BD610-5320-48DD-B4CD-2825438A70BE');
	INSERT INTO [smp].[Album] ([Id], [Name], [Description], [Path], [Guid]) VALUES (6, 'Old man', 'Old man', 'App_Data', '2D62A4DB-EC30-41D6-A9D9-C1E037B44A17');
	INSERT INTO [smp].[Album] ([Id], [Name], [Description], [Path], [Guid]) VALUES (7, 'Dog', 'Dog', 'App_Data', '70B9EF63-F689-4CFB-9D6F-5ED125D491B2');
	INSERT INTO [smp].[Album] ([Id], [Name], [Description], [Path], [Guid]) VALUES (8, 'Cat', 'Cat', 'App_Data', '421ACA62-F921-4C0A-B212-D0B5081E0A25');
	INSERT INTO [smp].[Album] ([Id], [Name], [Description], [Path], [Guid]) VALUES (9, 'Horse', 'Horse', 'App_Data', 'FF2FE1F2-7B29-4910-83DB-FD7E0A86D116');
	INSERT INTO [smp].[Album] ([Id], [Name], [Description], [Path], [Guid]) VALUES (10,'Artist', 'Artist', 'App_Data', '4485B513-7817-4483-B7C9-AF99BD0F15EA');
SET IDENTITY_INSERT [smp].[Album] OFF

--Image
INSERT INTO [smp].[Image] ([Name], [Description], [AlbumId]) VALUES ('1.jpg', 'C# is the best', 1);
INSERT INTO [smp].[Image] ([Name], [Description], [AlbumId]) VALUES ('3.jpg', 'my desc of photos', 1);
INSERT INTO [smp].[Image] ([Name], [Description], [AlbumId]) VALUES ('4.jpg', 'First Album', 1);
INSERT INTO [smp].[Image] ([Name], [Description], [AlbumId]) VALUES ('5.jpg', 'First Album', 1);
INSERT INTO [smp].[Image] ([Name], [Description], [AlbumId]) VALUES ('2.jpg', 'First Album', 3);
INSERT INTO [smp].[Image] ([Name], [Description], [AlbumId]) VALUES ('1.jpg', 'Third Album', 3);
INSERT INTO [smp].[Image] ([Name], [Description], [AlbumId]) VALUES ('1.jpg', 'Fourth Album', 4);
INSERT INTO [smp].[Image] ([Name], [Description], [AlbumId]) VALUES ('1.jpg', 'Fifth Album', 5);
INSERT INTO [smp].[Image] ([Name], [Description], [AlbumId]) VALUES ('1.jpg', 'Sixth Album', 6);
INSERT INTO [smp].[Image] ([Name], [Description], [AlbumId]) VALUES ('1.jpg', 'Seventh Album', 7);
INSERT INTO [smp].[Image] ([Name], [Description], [AlbumId]) VALUES ('1.jpg', 'Eighth Album', 8);
INSERT INTO [smp].[Image] ([Name], [Description], [AlbumId]) VALUES ('1.jpg', 'Ninth Album', 9);
INSERT INTO [smp].[Image] ([Name], [Description], [AlbumId]) VALUES ('1.jpg', 'Tenth Album', 10);
INSERT INTO [smp].[Image] ([Name], [Description], [AlbumId]) VALUES ('20161128_163219_2016-11-2815.30.00.jpg', 'Tenth Album', 2);
INSERT INTO [smp].[Image] ([Name], [Description], [AlbumId]) VALUES ('20161128_163221_2016-11-2815.47.59.jpg', 'Tenth Album', 2);
INSERT INTO [smp].[Image] ([Name], [Description], [AlbumId]) VALUES ('20161128_163221_2016-11-2815.47.48.jpg', 'Tenth Album', 2);
INSERT INTO [smp].[Image] ([Name], [Description], [AlbumId]) VALUES ('20161128_163220_2016-11-2815.47.43.jpg', 'Tenth Album', 2);
INSERT INTO [smp].[Image] ([Name], [Description], [AlbumId]) VALUES ('20161128_163220_2016-11-2815.30.12.jpg', 'Tenth Album', 2);
INSERT INTO [smp].[Image] ([Name], [Description], [AlbumId]) VALUES ('20161128_163209_2016-11-2815.30.08.jpg', 'Tenth Album', 2);
INSERT INTO [smp].[Image] ([Name], [Description], [AlbumId]) VALUES ('2.jpg', 'new photos', 1);
INSERT INTO [smp].[Image] ([Name], [Description], [AlbumId]) VALUES ('7.jpg', 'First Album', 2);
INSERT INTO [smp].[Image] ([Name], [Description], [AlbumId]) VALUES ('1.jpg', 'Second Album', 2);