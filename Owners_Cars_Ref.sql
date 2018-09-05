USE [CarSales]
GO

ALTER TABLE [dbo].[Owners_Cars_Ref] DROP CONSTRAINT [FK_Owner_Car_Ref]
GO

ALTER TABLE [dbo].[Owners_Cars_Ref] DROP CONSTRAINT [FK_Car_Owner_Ref]
GO

/****** Object:  Table [dbo].[Owners_Cars_Ref]    Script Date: 5/09/2018 2:14:10 PM ******/
DROP TABLE [dbo].[Owners_Cars_Ref]
GO

/****** Object:  Table [dbo].[Owners_Cars_Ref]    Script Date: 5/09/2018 2:14:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Owners_Cars_Ref](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OwnerId] [int] NOT NULL,
	[CarId] [int] NOT NULL,
 CONSTRAINT [PK_Owners_Cars_Ref] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Owners_Cars_Ref]  WITH CHECK ADD  CONSTRAINT [FK_Car_Owner_Ref] FOREIGN KEY([CarId])
REFERENCES [dbo].[AdvertisedCars] ([ID])
GO

ALTER TABLE [dbo].[Owners_Cars_Ref] CHECK CONSTRAINT [FK_Car_Owner_Ref]
GO

ALTER TABLE [dbo].[Owners_Cars_Ref]  WITH CHECK ADD  CONSTRAINT [FK_Owner_Car_Ref] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[Owners] ([Id])
GO

ALTER TABLE [dbo].[Owners_Cars_Ref] CHECK CONSTRAINT [FK_Owner_Car_Ref]
GO


