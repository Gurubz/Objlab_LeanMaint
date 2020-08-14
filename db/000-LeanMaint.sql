USE [LeanMaint]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [LeanMaint]
GO
/****** Object:  Table [dbo].[Anagrafico Impianti]    Script Date: 25/07/2020 21:31:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Anagrafico Impianti](
	[ID_PLant] [varchar](30) NOT NULL,
	[Desc_Plant] [varchar](200) NULL,
	[DT_Install_Plant] [datetime] NOT NULL,
	[Costo_Plant] [int] NULL,
	[Azienda] [varchar](100) NULL,
	[Divisione] [varchar](100) NULL,
	[CDC_Plant] [varchar](20) NULL,
	[Tipo_Plant] [varchar](20) NULL,
	[DT_Lastmaint] [int] NULL,
	[DT_Nextmaint] [int] NULL,
	[Esito_maint] [varchar](10) NULL,
	[Grado_risk_plant] [int] NULL,
	[Stato] [varchar](3) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_PLant] ASC,
	[DT_Install_Plant] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Anagrafico Interventi]    Script Date: 25/07/2020 21:31:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Anagrafico Interventi](
	[ID_PLant] [varchar](30) NOT NULL,
	[Desc_Inter] [varchar](200) NULL,
	[DT_Chiamata] [datetime] NULL,
	[Tarif_Inter] [int] NULL,
	[Tipo_Risorsa] [varchar](100) NULL,
	[Desc_Risorsa] [varchar](100) NULL,
	[CDC_Risorsa] [varchar](20) NULL,
	[Tipo_Plant] [varchar](20) NULL,
	[DT_Conf_Int] [int] NULL,
	[DT_Eff_Int] [int] NULL,
	[DT_Ultimo_Guasto] [int] NULL,
	[DT_Ultima_Riparazione] [int] NULL,
	[Esito_maint] [varchar](10) NULL,
	[Stato] [varchar](3) NULL,
	[ID_Inter] [varchar](50) NOT NULL,
	[ID_Persona] [varchar](100) NULL,
	[ORE_Inter] [int] NULL,
	[Costo_Inter] [int] NULL,
	[Probabil] [int] NULL,
	[Gravity] [int] NULL,
	[Rilevabil] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_PLant] ASC,
	[ID_Inter] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Anagrafico_Fornitori]    Script Date: 25/07/2020 21:31:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Anagrafico_Fornitori](
	[ID_PLant] [varchar](30) NOT NULL,
	[ID_Fornitore] [varchar](100) NOT NULL,
	[Desc_Fornitore] [varchar](300) NULL,
	[Indirizzo1] [varchar](200) NULL,
	[Indirizzo2] [varchar](200) NULL,
	[CDC_Riferimento] [varchar](20) NULL,
	[Costo_Orario] [int] NULL,
	[CityFrazione] [varchar](200) NULL,
	[Nazione] [varchar](100) NULL,
	[CAP_Forn] [varchar](7) NULL,
	[DT_Valid_Forn] [datetime] NULL,
	[DT_Last_Inter] [datetime] NULL,
	[Stato] [varchar](3) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_PLant] ASC,
	[ID_Fornitore] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Autorizzazioni]    Script Date: 25/07/2020 21:31:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Autorizzazioni](
	[ID_User] [varchar](50) NOT NULL,
	[DT_Ins_User] [datetime] NULL,
	[LVL_User] [int] NULL,
	[Auth_Code] [varchar](15) NULL,
	[DT_End_Auth] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_User] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BILLING]    Script Date: 25/07/2020 21:31:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BILLING](
	[ID_USER] [varchar](50) NOT NULL,
	[DESC_USER] [varchar](300) NULL,
	[DT_ATTIVAZIONE] [datetime] NOT NULL,
	[DT_TERMINE] [datetime] NULL,
	[TARIFFA] [numeric](21, 0) NULL,
	[ANNO] [varchar](4) NULL,
	[MESE] [varchar](20) NULL,
	[GIORNO_INIZIO] [numeric](2, 0) NULL,
	[GIORNO_FINE] [numeric](2, 0) NULL,
	[VALORE] [numeric](21, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_USER] ASC,
	[DT_ATTIVAZIONE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GUASTI]    Script Date: 25/07/2020 21:31:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GUASTI](
	[ID_Guasto] [varchar](30) NOT NULL,
	[Desc_Guasto] [varchar](300) NULL,
	[Classe_Guasto] [varchar](1) NULL,
	[Stato] [varchar](3) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Guasto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HR_Manut]    Script Date: 25/07/2020 21:31:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HR_Manut](
	[ID_PLant] [varchar](30) NOT NULL,
	[ID_Persona] [varchar](100) NOT NULL,
	[Desc_Persona] [varchar](300) NULL,
	[Codificato] [int] NULL,
	[ID_Fornitore] [varchar](100) NULL,
	[DT_Ultima_Att] [datetime] NULL,
	[CDC_Riferimento] [varchar](20) NULL,
	[Costo_Orario] [int] NULL,
	[Stato] [varchar](3) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_PLant] ASC,
	[ID_Persona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Interfaccie]    Script Date: 25/07/2020 21:31:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Interfaccie](
	[SISTEMA] [varchar](50) NOT NULL,
	[DT_Attivazione] [datetime] NULL,
	[Dt_disattivazione] [datetime] NULL,
	[Auth_Code] [varchar](15) NOT NULL,
	[Parametri1] [varchar](100) NULL,
	[Parametri2] [varchar](100) NULL,
	[Parametri3] [varchar](100) NULL,
	[Host_abilitato] [varchar](400) NULL,
	[IP_Host_Abilitato] [varchar](50) NULL,
	[IPV4_IPV6] [numeric](1, 0) NULL,
	[Stato] [varchar](3) NULL,
PRIMARY KEY CLUSTERED 
(
	[SISTEMA] ASC,
	[Auth_Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materiali_Manut]    Script Date: 25/07/2020 21:31:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materiali_Manut](
	[ID_PLant] [varchar](30) NOT NULL,
	[ID_Mater] [varchar](100) NOT NULL,
	[Desc_Mater] [varchar](300) NULL,
	[Codificato] [int] NULL,
	[ID_Fornitore] [varchar](100) NULL,
	[DT_Uso _Mater] [datetime] NULL,
	[CDC_Riferimento] [varchar](20) NULL,
	[Costo_Mater] [int] NULL,
	[Stato] [varchar](3) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_PLant] ASC,
	[ID_Mater] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RIPARAZIONI]    Script Date: 25/07/2020 21:31:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RIPARAZIONI](
	[ID_Ripar] [varchar](30) NOT NULL,
	[Desc_Ripar] [varchar](300) NULL,
	[Classe_Ripar] [varchar](1) NULL,
	[Stato] [varchar](3) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Ripar] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[STATI]    Script Date: 25/07/2020 21:31:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STATI](
	[ID_STATO] [varchar](3) NOT NULL,
	[Desc_Guasto] [varchar](300) NULL,
	[Stato] [varchar](3) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_STATO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [LeanMaint] SET  READ_WRITE 
GO
