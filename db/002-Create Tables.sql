USE LeanMaint
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Config].[Countries](
	[ID_Country] [int] NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Code] [varchar](2) NOT NULL,
	[Language] [varchar](3) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Country] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [Config].[Regions]    Script Date: 31-Dec-18 1:27:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Config].[Regions](
	[ID_Region] [int] NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[ID_Country] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Region] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [Config].[Regions]  WITH CHECK ADD  CONSTRAINT [FK_Regions_Countries] FOREIGN KEY([ID_Country])
REFERENCES [Config].[Countries] ([ID_Country])
GO

ALTER TABLE [Config].[Regions] CHECK CONSTRAINT [FK_Regions_Countries]
GO

/****** Object:  Table [Config].[Cities]    Script Date: 31-Dec-18 1:27:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Config].[Cities](
	[ID_City] [int] NOT NULL,
	[ID_Region] [int] NOT NULL,
	[Name] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_City] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [Config].[Cities]  WITH CHECK ADD  CONSTRAINT [FK_Cities_Regions] FOREIGN KEY([ID_Region])
REFERENCES [Config].[Regions] ([ID_Region])
GO

ALTER TABLE [Config].[Cities] CHECK CONSTRAINT [FK_Cities_Regions]
GO