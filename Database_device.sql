USE [device]
GO
/****** Object:  Table [dbo].[Newdevices]    Script Date: 6/26/2021 2:32:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Newdevices](
	[Deviceid] [int] IDENTITY(1,1) NOT NULL,
	[Devicename] [nvarchar](150) NULL,
	[Temperature] [nvarchar](150) NULL,
	[Humidity] [nvarchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[Deviceid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
