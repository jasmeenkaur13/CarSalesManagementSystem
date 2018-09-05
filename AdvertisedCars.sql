USE [CarSales]
GO

/****** Object:  Table [dbo].[AdvertisedCars]    Script Date: 5/09/2018 2:12:56 PM ******/
DROP TABLE [dbo].[AdvertisedCars]
GO

/****** Object:  Table [dbo].[AdvertisedCars]    Script Date: 5/09/2018 2:12:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AdvertisedCars](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Year] [varchar](4) NOT NULL,
	[Make] [varchar](50) NOT NULL,
	[Model] [varchar](50) NOT NULL,
	[AdvertisedPriceType] [varchar](4) NOT NULL,
	[ECGAmount] [numeric](10, 2) NULL,
	[DAPAmount] [numeric](10, 2) NULL,
	[AdvertisedAmount] [numeric](16, 2) NULL,
 CONSTRAINT [PK_AdvertisedCars] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


