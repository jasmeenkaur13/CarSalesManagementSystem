USE [CarSales]
GO

/****** Object:  Table [dbo].[Owners]    Script Date: 5/09/2018 2:13:47 PM ******/
DROP TABLE [dbo].[Owners]
GO

/****** Object:  Table [dbo].[Owners]    Script Date: 5/09/2018 2:13:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Owners](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[PhoneNumber] [varchar](10) NULL,
	[Email] [varchar](50) NULL,
	[DealerABN] [varchar](50) NULL,
	[OwnerType] [varchar](50) NOT NULL,
	[Comments] [nvarchar](max) NULL,
 CONSTRAINT [PK_Owners] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


