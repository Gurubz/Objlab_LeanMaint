USE [LeanMaint]
GO
/****** Object:  Schema [Accountancy]    Script Date: 8/16/2020 5:34:24 PM ******/
CREATE SCHEMA [Accountancy]
GO
/****** Object:  Schema [Config]    Script Date: 8/16/2020 5:34:24 PM ******/
CREATE SCHEMA [Config]
GO
/****** Object:  Schema [Device]    Script Date: 8/16/2020 5:34:24 PM ******/
CREATE SCHEMA [Device]
GO
/****** Object:  Schema [Maintenance]    Script Date: 8/16/2020 5:34:24 PM ******/
CREATE SCHEMA [Maintenance]
GO
/****** Object:  Table [Accountancy].[Billings]    Script Date: 8/16/2020 5:34:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Accountancy].[Billings](
	[ID_Billing] [int] IDENTITY(1,1) NOT NULL,
	[ID_Operator] [int] NULL,
	[Activation] [datetime] NOT NULL,
	[End] [datetime] NULL,
	[HourlyCost] [decimal](9, 4) NULL,
	[Year] [int] NULL,
	[Month] [int] NULL,
	[StartDay] [datetime] NULL,
	[EndDay] [datetime] NULL,
	[Value] [decimal](19, 4) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Billing] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Accountancy].[CostCenters]    Script Date: 8/16/2020 5:34:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Accountancy].[CostCenters](
	[ID_CostCenter] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[ID_Company] [int] NOT NULL,
 CONSTRAINT [PK_ConfigCostCenter] PRIMARY KEY CLUSTERED 
(
	[ID_CostCenter] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Config].[Branches]    Script Date: 8/16/2020 5:34:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Config].[Branches](
	[ID_Branch] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[ID_Company] [int] NOT NULL,
 CONSTRAINT [PK_ConfigBranch] PRIMARY KEY CLUSTERED 
(
	[ID_Branch] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Config].[Companies]    Script Date: 8/16/2020 5:34:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Config].[Companies](
	[ID_Company] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_ConfigCompany] PRIMARY KEY CLUSTERED 
(
	[ID_Company] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Config].[Countries]    Script Date: 8/16/2020 5:34:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Config].[Countries](
	[ID_Country] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[TwoCharCode] [nchar](2) NOT NULL,
	[ThreeCharCode] [nchar](3) NOT NULL,
 CONSTRAINT [PK_ConfigCountries] PRIMARY KEY CLUSTERED 
(
	[ID_Country] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Config].[Departments]    Script Date: 8/16/2020 5:34:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Config].[Departments](
	[ID_Department] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[ID_Branch] [int] NOT NULL,
 CONSTRAINT [PK_ConfigDivision] PRIMARY KEY CLUSTERED 
(
	[ID_Department] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Config].[FailureStatuses]    Script Date: 8/16/2020 5:34:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Config].[FailureStatuses](
	[ID_FailureStatus] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_FailureStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Config].[ObjStatuses]    Script Date: 8/16/2020 5:34:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Config].[ObjStatuses](
	[ID_ObjStatus] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_ObjStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Config].[Operators]    Script Date: 8/16/2020 5:34:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Config].[Operators](
	[ID_Operator] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[MiddleName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Description] [nvarchar](200) NULL,
	[Coded] [int] NULL,
	[ID_Supplier] [int] NULL,
	[CDC_Riferimento] [varchar](20) NULL,
	[HourlyCost] [decimal](5, 4) NULL,
	[ID_ObjStatus] [int] NULL,
 CONSTRAINT [PK_HR_Manut] PRIMARY KEY CLUSTERED 
(
	[ID_Operator] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Config].[OperatorsPermission]    Script Date: 8/16/2020 5:34:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Config].[OperatorsPermission](
	[ID_Operator] [int] NOT NULL,
	[LVL_User] [int] NULL,
	[Auth_Code] [varchar](15) NULL,
	[Started] [datetime] NULL,
	[Ended] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Operator] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Config].[Plants]    Script Date: 8/16/2020 5:34:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Config].[Plants](
	[ID_Plant] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](200) NULL,
	[ID_ObjStatus] [int] NULL,
	[ID_PlantType] [int] NULL,
	[ID_PlantRisk] [int] NULL,
	[ID_Department] [int] NOT NULL,
	[ID_CostCenter] [int] NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [PK_Anagrafico Impianti] PRIMARY KEY CLUSTERED 
(
	[ID_Plant] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Config].[Suppliers]    Script Date: 8/16/2020 5:34:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Config].[Suppliers](
	[ID_Supplier] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](200) NULL,
	[Address1] [varchar](200) NULL,
	[Address2] [varchar](200) NULL,
	[ID_CostCenter] [int] NULL,
	[HourlyCost] [decimal](5, 4) NULL,
	[Town] [varchar](200) NULL,
	[Zip] [varchar](7) NULL,
	[ID_Country] [int] NULL,
	[ValidFrom] [datetime] NULL,
	[ID_ObjStatus] [int] NULL,
 CONSTRAINT [PK_ConfigSuppliers] PRIMARY KEY CLUSTERED 
(
	[ID_Supplier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Config].[SupplierToPlants]    Script Date: 8/16/2020 5:34:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Config].[SupplierToPlants](
	[ID_Supplier] [int] NOT NULL,
	[ID_Plant] [int] NOT NULL,
 CONSTRAINT [PK_SupplierToPlants] PRIMARY KEY CLUSTERED 
(
	[ID_Supplier] ASC,
	[ID_Plant] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Device].[Interfaces]    Script Date: 8/16/2020 5:34:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Device].[Interfaces](
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Maintenance].[Failures]    Script Date: 8/16/2020 5:34:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Maintenance].[Failures](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](200) NULL,
	[ID_FailureClass] [int] NULL,
	[ID_ObjStatus] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Maintenance].[Interventions]    Script Date: 8/16/2020 5:34:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Maintenance].[Interventions](
	[ID_Intervention] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[ID_Operator] [int] NULL,
	[ID_Plant] [int] NULL,
	[RequestedAt] [datetime] NULL,
	[Tarif_Inter] [int] NULL,
	[Tipo_Risorsa] [varchar](100) NULL,
	[Desc_Risorsa] [varchar](100) NULL,
	[CDC_Risorsa] [varchar](20) NULL,
	[Tipo_Plant] [varchar](20) NULL,
	[DT_Conf_Int] [int] NULL,
	[DT_Eff_Int] [int] NULL,
	[DT_Ultimo_Guasto] [int] NULL,
	[DT_Ultima_Riparazione] [int] NULL,
	[ID_Outcome] [int] NULL,
	[ID_ObjStatus] [int] NULL,
	[Hours] [int] NULL,
	[TotalCost] [int] NULL,
	[Probability] [int] NULL,
	[Gravity] [int] NULL,
	[Rilevability] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Intervention] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Maintenance].[Materials]    Script Date: 8/16/2020 5:34:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Maintenance].[Materials](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[ID_Plant] [int] NOT NULL,
	[Coded] [int] NOT NULL,
	[ID_Supplier] [int] NOT NULL,
	[UsedFrom] [datetime] NOT NULL,
	[ID_CostCenter] [int] NOT NULL,
	[Cost] [decimal](19, 4) NOT NULL,
	[ID_ObjStatus] [int] NOT NULL,
 CONSTRAINT [PK__Material__3214EC27EEECC794] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Maintenance].[Outcomes]    Script Date: 8/16/2020 5:34:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Maintenance].[Outcomes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Maintenance].[RepairClasses]    Script Date: 8/16/2020 5:34:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Maintenance].[RepairClasses](
	[ID_RepairClass] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_RepairClass] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Maintenance].[Repairs]    Script Date: 8/16/2020 5:34:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Maintenance].[Repairs](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[ID_RepairClass] [int] NULL,
	[ID_ObjStatus] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [Accountancy].[Billings]  WITH CHECK ADD  CONSTRAINT [FK_Billings_Operators] FOREIGN KEY([ID_Operator])
REFERENCES [Config].[Operators] ([ID_Operator])
GO
ALTER TABLE [Accountancy].[Billings] CHECK CONSTRAINT [FK_Billings_Operators]
GO
ALTER TABLE [Config].[Branches]  WITH CHECK ADD  CONSTRAINT [FK_Branches_Companies] FOREIGN KEY([ID_Company])
REFERENCES [Config].[Companies] ([ID_Company])
GO
ALTER TABLE [Config].[Branches] CHECK CONSTRAINT [FK_Branches_Companies]
GO
ALTER TABLE [Config].[Departments]  WITH CHECK ADD  CONSTRAINT [FK_Departments_Branches] FOREIGN KEY([ID_Branch])
REFERENCES [Config].[Branches] ([ID_Branch])
GO
ALTER TABLE [Config].[Departments] CHECK CONSTRAINT [FK_Departments_Branches]
GO
ALTER TABLE [Config].[Operators]  WITH CHECK ADD  CONSTRAINT [FK_Operators_ObjStatuses] FOREIGN KEY([ID_ObjStatus])
REFERENCES [Config].[ObjStatuses] ([ID_ObjStatus])
GO
ALTER TABLE [Config].[Operators] CHECK CONSTRAINT [FK_Operators_ObjStatuses]
GO
ALTER TABLE [Config].[Operators]  WITH CHECK ADD  CONSTRAINT [FK_Operators_OperatorsPermission] FOREIGN KEY([ID_Operator])
REFERENCES [Config].[OperatorsPermission] ([ID_Operator])
GO
ALTER TABLE [Config].[Operators] CHECK CONSTRAINT [FK_Operators_OperatorsPermission]
GO
ALTER TABLE [Config].[Operators]  WITH CHECK ADD  CONSTRAINT [FK_Operators_Suppliers] FOREIGN KEY([ID_Supplier])
REFERENCES [Config].[Suppliers] ([ID_Supplier])
GO
ALTER TABLE [Config].[Operators] CHECK CONSTRAINT [FK_Operators_Suppliers]
GO
ALTER TABLE [Config].[Plants]  WITH CHECK ADD  CONSTRAINT [FK_Plants_Companies] FOREIGN KEY([ID_CostCenter])
REFERENCES [Config].[Companies] ([ID_Company])
GO
ALTER TABLE [Config].[Plants] CHECK CONSTRAINT [FK_Plants_Companies]
GO
ALTER TABLE [Config].[Plants]  WITH CHECK ADD  CONSTRAINT [FK_Plants_Departments] FOREIGN KEY([ID_Department])
REFERENCES [Config].[Departments] ([ID_Department])
GO
ALTER TABLE [Config].[Plants] CHECK CONSTRAINT [FK_Plants_Departments]
GO
ALTER TABLE [Config].[Suppliers]  WITH CHECK ADD  CONSTRAINT [FK_Suppliers_Countries] FOREIGN KEY([ID_Country])
REFERENCES [Config].[Countries] ([ID_Country])
GO
ALTER TABLE [Config].[Suppliers] CHECK CONSTRAINT [FK_Suppliers_Countries]
GO
ALTER TABLE [Config].[Suppliers]  WITH CHECK ADD  CONSTRAINT [FK_Suppliers_ObjStatuses] FOREIGN KEY([ID_ObjStatus])
REFERENCES [Config].[ObjStatuses] ([ID_ObjStatus])
GO
ALTER TABLE [Config].[Suppliers] CHECK CONSTRAINT [FK_Suppliers_ObjStatuses]
GO
ALTER TABLE [Maintenance].[Interventions]  WITH CHECK ADD  CONSTRAINT [FK_Interventions_ObjStatuses] FOREIGN KEY([ID_ObjStatus])
REFERENCES [Config].[ObjStatuses] ([ID_ObjStatus])
GO
ALTER TABLE [Maintenance].[Interventions] CHECK CONSTRAINT [FK_Interventions_ObjStatuses]
GO
ALTER TABLE [Maintenance].[Interventions]  WITH CHECK ADD  CONSTRAINT [FK_Interventions_Operators] FOREIGN KEY([ID_Operator])
REFERENCES [Config].[Operators] ([ID_Operator])
GO
ALTER TABLE [Maintenance].[Interventions] CHECK CONSTRAINT [FK_Interventions_Operators]
GO
ALTER TABLE [Maintenance].[Interventions]  WITH CHECK ADD  CONSTRAINT [FK_Interventions_Plants] FOREIGN KEY([ID_Plant])
REFERENCES [Config].[Plants] ([ID_Plant])
GO
ALTER TABLE [Maintenance].[Interventions] CHECK CONSTRAINT [FK_Interventions_Plants]
GO
ALTER TABLE [Maintenance].[Materials]  WITH CHECK ADD  CONSTRAINT [FK_Materials_CostCenters] FOREIGN KEY([ID_CostCenter])
REFERENCES [Accountancy].[CostCenters] ([ID_CostCenter])
GO
ALTER TABLE [Maintenance].[Materials] CHECK CONSTRAINT [FK_Materials_CostCenters]
GO
ALTER TABLE [Maintenance].[Materials]  WITH CHECK ADD  CONSTRAINT [FK_Materials_ObjStatuses] FOREIGN KEY([ID_ObjStatus])
REFERENCES [Config].[ObjStatuses] ([ID_ObjStatus])
GO
ALTER TABLE [Maintenance].[Materials] CHECK CONSTRAINT [FK_Materials_ObjStatuses]
GO
ALTER TABLE [Maintenance].[Materials]  WITH CHECK ADD  CONSTRAINT [FK_Materials_Plants] FOREIGN KEY([ID_Plant])
REFERENCES [Config].[Plants] ([ID_Plant])
GO
ALTER TABLE [Maintenance].[Materials] CHECK CONSTRAINT [FK_Materials_Plants]
GO
ALTER TABLE [Maintenance].[Materials]  WITH CHECK ADD  CONSTRAINT [FK_Materials_Plants1] FOREIGN KEY([ID_Plant])
REFERENCES [Config].[Plants] ([ID_Plant])
GO
ALTER TABLE [Maintenance].[Materials] CHECK CONSTRAINT [FK_Materials_Plants1]
GO
ALTER TABLE [Maintenance].[Materials]  WITH CHECK ADD  CONSTRAINT [FK_Materials_Suppliers] FOREIGN KEY([ID_Supplier])
REFERENCES [Config].[Suppliers] ([ID_Supplier])
GO
ALTER TABLE [Maintenance].[Materials] CHECK CONSTRAINT [FK_Materials_Suppliers]
GO
ALTER TABLE [Maintenance].[Repairs]  WITH CHECK ADD  CONSTRAINT [FK_Repairs_ObjStatuses] FOREIGN KEY([ID_ObjStatus])
REFERENCES [Config].[ObjStatuses] ([ID_ObjStatus])
GO
ALTER TABLE [Maintenance].[Repairs] CHECK CONSTRAINT [FK_Repairs_ObjStatuses]
GO
ALTER TABLE [Maintenance].[Repairs]  WITH CHECK ADD  CONSTRAINT [FK_Repairs_RepairClasses] FOREIGN KEY([ID_RepairClass])
REFERENCES [Maintenance].[RepairClasses] ([ID_RepairClass])
GO
ALTER TABLE [Maintenance].[Repairs] CHECK CONSTRAINT [FK_Repairs_RepairClasses]
GO
