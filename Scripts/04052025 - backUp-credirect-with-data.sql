USE [IDX]
GO
/****** Object:  Table [dbo].[AgencyBank]    Script Date: 04/05/2025 21:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AgencyBank](
	[AgencyBankID] [int] IDENTITY(1,1) NOT NULL,
	[AgencyBankLabel] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[AgencyBankID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssignmentProperty]    Script Date: 04/05/2025 21:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssignmentProperty](
	[AssignmentPropertyID] [int] IDENTITY(1,1) NOT NULL,
	[AssignmentPropertyLabel] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[AssignmentPropertyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BankCommitmentsCharges]    Script Date: 04/05/2025 21:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BankCommitmentsCharges](
	[BankCommitmentChargeID] [int] IDENTITY(1,1) NOT NULL,
	[NatureCommitmentID] [int] NULL,
	[AgencyBankID] [int] NULL,
	[OtherAgency] [nvarchar](255) NULL,
	[ClientID] [int] NULL,
	[Maturity] [decimal](18, 2) NULL,
	[Outstanding] [bit] NULL,
	[RepayableEarly] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[BankCommitmentChargeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BusinessActivity]    Script Date: 04/05/2025 21:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessActivity](
	[BusinessActivityID] [int] IDENTITY(1,1) NOT NULL,
	[BusinessActivityLabel] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[BusinessActivityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 04/05/2025 21:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[ClientID] [int] IDENTITY(1,1) NOT NULL,
	[VIP] [bit] NULL,
	[Matricule] [nvarchar](50) NULL,
	[LastName] [nvarchar](255) NULL,
	[FirstName] [nvarchar](255) NULL,
	[BirthDate] [date] NULL,
	[ClientTitleID] [int] NULL,
	[Nationality] [nvarchar](255) NULL,
	[IdentityID] [int] NULL,
	[Address] [nvarchar](max) NULL,
	[City] [nvarchar](255) NULL,
	[CountryID] [int] NULL,
	[ResidenceCountryID] [int] NULL,
	[MaritalStatusID] [int] NULL,
	[MobilePhone] [nvarchar](50) NULL,
	[LandlinePhone] [nvarchar](50) NULL,
	[WorkPhone] [nvarchar](50) NULL,
	[Email] [nvarchar](255) NULL,
	[ResidencyStatusID] [int] NULL,
	[IsOwner] [bit] NULL,
	[IsTenant] [bit] NULL,
	[RequestedAmount] [decimal](18, 2) NULL,
	[CompanyName] [nvarchar](255) NULL,
	[CreationDate] [date] NULL,
	[RegistrationNumber] [nvarchar](50) NULL,
	[CompanyAddress] [nvarchar](max) NULL,
	[CompanyCity] [nvarchar](255) NULL,
	[CompanyCountryID] [int] NULL,
	[SocialCapital] [decimal](18, 2) NULL,
	[BusinessActivityID] [int] NULL,
	[is_individual] [bit] NULL,
	[is_organisation] [bit] NULL,
	[RoleID] [int] NULL,
	[CIN] [nvarchar](50) NULL,
	[ResidencePermit] [nvarchar](50) NULL,
	[PassportNumber] [nvarchar](50) NULL,
	[OriginID] [int] NULL,
	[LegalFormID] [int] NULL,
	[originDetails] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientCountry]    Script Date: 04/05/2025 21:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientCountry](
	[ClientCountryID] [int] IDENTITY(1,1) NOT NULL,
	[ClientCountryLabel] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ClientCountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientIdentity]    Script Date: 04/05/2025 21:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientIdentity](
	[IdentityID] [int] IDENTITY(1,1) NOT NULL,
	[IdentityLabel] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdentityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientLegalForm]    Script Date: 04/05/2025 21:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientLegalForm](
	[LegalFormID] [int] IDENTITY(1,1) NOT NULL,
	[LegalFormLabel] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[LegalFormID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientManager]    Script Date: 04/05/2025 21:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientManager](
	[ClientManagerID] [int] IDENTITY(1,1) NOT NULL,
	[ClientID] [int] NOT NULL,
	[ManagerID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ClientManagerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientOrigin]    Script Date: 04/05/2025 21:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientOrigin](
	[OriginID] [int] IDENTITY(1,1) NOT NULL,
	[OriginLabel] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[OriginID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientRole]    Script Date: 04/05/2025 21:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientRole](
	[RoleID] [int] NOT NULL,
	[RoleLabel] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientTitle]    Script Date: 04/05/2025 21:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientTitle](
	[ClientTitleID] [int] IDENTITY(1,1) NOT NULL,
	[ClientTitleLabel] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ClientTitleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConditionProperty]    Script Date: 04/05/2025 21:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConditionProperty](
	[ConditionPropertyID] [int] IDENTITY(1,1) NOT NULL,
	[ConditionPropertyLabel] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[ConditionPropertyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Credit]    Script Date: 04/05/2025 21:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Credit](
	[CreditID] [int] IDENTITY(1,1) NOT NULL,
	[Matricule] [nvarchar](50) NULL,
	[CreditTypeID] [int] NULL,
	[amount] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CreditID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CreditDepot]    Script Date: 04/05/2025 21:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreditDepot](
	[CreditDepotId] [int] IDENTITY(1,1) NOT NULL,
	[id_credit] [int] NULL,
	[id_agency_bank] [int] NULL,
	[interlocutor] [nvarchar](max) NULL,
	[agence] [nvarchar](max) NULL,
	[created_at] [datetime] NULL,
	[created_by] [nvarchar](50) NULL,
	[updated_at] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[deleted_at] [datetime] NULL,
	[deleted_by] [nvarchar](50) NULL,
	[date_sent] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[CreditDepotId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CreditStatus]    Script Date: 04/05/2025 21:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreditStatus](
	[CreditStatusID] [int] IDENTITY(1,1) NOT NULL,
	[id_credit] [int] NULL,
	[id_depot] [int] NULL,
	[message] [nvarchar](max) NULL,
	[status] [int] NULL,
	[created_at] [datetime] NULL,
	[created_by] [nvarchar](50) NULL,
	[updated_at] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[deleted_at] [datetime] NULL,
	[deleted_by] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[CreditStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CreditType]    Script Date: 04/05/2025 21:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreditType](
	[TypeID] [int] IDENTITY(1,1) NOT NULL,
	[TypeLabel] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[TypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InfoProfessional]    Script Date: 04/05/2025 21:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InfoProfessional](
	[InfoProfessionalID] [int] IDENTITY(1,1) NOT NULL,
	[ClientID] [int] NULL,
	[IsSalarie] [bit] NULL,
	[Position] [nvarchar](255) NULL,
	[Employer] [nvarchar](255) NULL,
	[HiringDate] [date] NULL,
	[Salary] [decimal](18, 2) NULL,
	[IsCommercant] [bit] NULL,
	[TradeName] [nvarchar](255) NULL,
	[CreationDate] [date] NULL,
	[BusinessAddressCommercant] [nvarchar](500) NULL,
	[IsProfessionLiberale] [bit] NULL,
	[ActivityName] [nvarchar](255) NULL,
	[TaxID] [nvarchar](100) NULL,
	[OfficeAddress] [nvarchar](500) NULL,
	[IsGerantSociete] [bit] NULL,
	[CompanyName] [nvarchar](255) NULL,
	[CompanyCreationDate] [date] NULL,
	[BusinessAddressGerantSociete] [nvarchar](500) NULL,
	[LastYearRevenue] [decimal](18, 2) NULL,
	[SecondLastYearRevenue] [decimal](18, 2) NULL,
	[IsRetraite] [bit] NULL,
	[PensionAmount] [decimal](18, 2) NULL,
	[RetireeType] [nvarchar](255) NULL,
	[PropertyNature] [nvarchar](255) NULL,
	[PropertyLocation] [nvarchar](500) NULL,
	[PropertyValue] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[InfoProfessionalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InfosBank]    Script Date: 04/05/2025 21:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InfosBank](
	[InfoBankID] [int] IDENTITY(1,1) NOT NULL,
	[AgencyBankID] [int] NULL,
	[ClientID] [int] NULL,
	[Balance] [decimal](18, 2) NULL,
	[CumulativeCreditMovement] [decimal](18, 2) NULL,
	[IsPrincipal] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[InfoBankID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LignCreditClient]    Script Date: 04/05/2025 21:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LignCreditClient](
	[LignCreditClientID] [int] IDENTITY(1,1) NOT NULL,
	[ClientID] [int] NULL,
	[CreditID] [int] NULL,
	[IsPrincipal] [bit] NULL,
	[PercentageClient] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[LignCreditClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LignCreditProperty]    Script Date: 04/05/2025 21:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LignCreditProperty](
	[LignCreditPropertyID] [int] IDENTITY(1,1) NOT NULL,
	[CreditID] [int] NULL,
	[ObjectCreditID] [int] NULL,
	[PropertyID] [int] NULL,
	[IsPrincipal] [bit] NULL,
	[IsObjectCredit] [bit] NULL,
	[IsAdditional] [bit] NULL,
	[IsSubstitution] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[LignCreditPropertyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ManagerInformation]    Script Date: 04/05/2025 21:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManagerInformation](
	[ManagerID] [int] IDENTITY(1,1) NOT NULL,
	[ManagerTitleID] [int] NULL,
	[ManagerLastName] [nvarchar](50) NULL,
	[ManagerFirstName] [nvarchar](50) NULL,
	[ManagerBirthDate] [date] NULL,
	[ManagerNationality] [nvarchar](50) NULL,
	[Id_Identity] [int] NULL,
	[ManagerAddress] [nvarchar](max) NULL,
	[ManagerCity] [nvarchar](50) NULL,
	[ManagerCountryID] [int] NULL,
	[ManagerResidenceCountryID] [int] NULL,
	[Id_ManagerMaritalStatus] [int] NULL,
	[CIN] [nvarchar](50) NULL,
	[CarteSejour] [nvarchar](50) NULL,
	[Passeport] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ManagerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaritalStatus]    Script Date: 04/05/2025 21:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaritalStatus](
	[MaritalStatusID] [int] IDENTITY(1,1) NOT NULL,
	[MaritalStatusLabel] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaritalStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NatureCommitment]    Script Date: 04/05/2025 21:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NatureCommitment](
	[NatureCommitmentID] [int] IDENTITY(1,1) NOT NULL,
	[NatureCommitmentLabel] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[NatureCommitmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NatureProperty]    Script Date: 04/05/2025 21:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NatureProperty](
	[NaturePropertyID] [int] IDENTITY(1,1) NOT NULL,
	[NaturePropertyLabel] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[NaturePropertyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ObjectCredit]    Script Date: 04/05/2025 21:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ObjectCredit](
	[ObjectCreditID] [int] IDENTITY(1,1) NOT NULL,
	[ObjectCreditLabel] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[ObjectCreditID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Property]    Script Date: 04/05/2025 21:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Property](
	[PropertyID] [int] IDENTITY(1,1) NOT NULL,
	[Adress] [nvarchar](250) NULL,
	[PropertyArea] [nvarchar](250) NULL,
	[LandTitle] [nvarchar](250) NULL,
	[SalePriceProperty] [decimal](18, 2) NULL,
	[RealValueProperty] [decimal](18, 2) NULL,
	[AmountWork] [decimal](18, 2) NULL,
	[EstimatedValue] [decimal](18, 2) NULL,
	[NaturePropertyID] [int] NULL,
	[AssignmentPropertyID] [int] NULL,
	[UsePropertyID] [int] NULL,
	[ConditionPropertyID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PropertyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ResidencyStatus]    Script Date: 04/05/2025 21:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResidencyStatus](
	[ResidencyStatusID] [int] IDENTITY(1,1) NOT NULL,
	[ResidencyStatusLabel] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ResidencyStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentDetail]    Script Date: 04/05/2025 21:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentDetail](
	[Id] [int] NOT NULL,
	[Name] [nchar](50) NOT NULL,
	[RollNumber] [nchar](10) NOT NULL,
	[Country] [nchar](25) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UseProperty]    Script Date: 04/05/2025 21:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UseProperty](
	[UsePropertyID] [int] IDENTITY(1,1) NOT NULL,
	[UsePropertyLabel] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[UsePropertyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BusinessActivity] ON 

INSERT [dbo].[BusinessActivity] ([BusinessActivityID], [BusinessActivityLabel]) VALUES (2, N'Activity 1')
INSERT [dbo].[BusinessActivity] ([BusinessActivityID], [BusinessActivityLabel]) VALUES (3, N'Activity 2')
INSERT [dbo].[BusinessActivity] ([BusinessActivityID], [BusinessActivityLabel]) VALUES (4, N'Activity 3')
INSERT [dbo].[BusinessActivity] ([BusinessActivityID], [BusinessActivityLabel]) VALUES (1002, N'Machines')
INSERT [dbo].[BusinessActivity] ([BusinessActivityID], [BusinessActivityLabel]) VALUES (1003, N'Distributeurs automatiques')
INSERT [dbo].[BusinessActivity] ([BusinessActivityID], [BusinessActivityLabel]) VALUES (1004, N'Concessions')
INSERT [dbo].[BusinessActivity] ([BusinessActivityID], [BusinessActivityLabel]) VALUES (1005, N'Opérations de vente au détail')
SET IDENTITY_INSERT [dbo].[BusinessActivity] OFF
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([ClientID], [VIP], [Matricule], [LastName], [FirstName], [BirthDate], [ClientTitleID], [Nationality], [IdentityID], [Address], [City], [CountryID], [ResidenceCountryID], [MaritalStatusID], [MobilePhone], [LandlinePhone], [WorkPhone], [Email], [ResidencyStatusID], [IsOwner], [IsTenant], [RequestedAmount], [CompanyName], [CreationDate], [RegistrationNumber], [CompanyAddress], [CompanyCity], [CompanyCountryID], [SocialCapital], [BusinessActivityID], [is_individual], [is_organisation], [RoleID], [CIN], [ResidencePermit], [PassportNumber], [OriginID], [LegalFormID], [originDetails]) VALUES (1, 0, N'00001', N'IDRISSI', N'Med Ayoub', CAST(N'1996-08-09' AS Date), 1002, N'Marocain', 1002, N'Adress 1', N'Marrakech', 1002, 1002, 1002, N'066006006', N'066006007', N'066006008', N'medayoub.idrissi@gmail.com', 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, N'EE453456', NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Client] ([ClientID], [VIP], [Matricule], [LastName], [FirstName], [BirthDate], [ClientTitleID], [Nationality], [IdentityID], [Address], [City], [CountryID], [ResidenceCountryID], [MaritalStatusID], [MobilePhone], [LandlinePhone], [WorkPhone], [Email], [ResidencyStatusID], [IsOwner], [IsTenant], [RequestedAmount], [CompanyName], [CreationDate], [RegistrationNumber], [CompanyAddress], [CompanyCity], [CompanyCountryID], [SocialCapital], [BusinessActivityID], [is_individual], [is_organisation], [RoleID], [CIN], [ResidencePermit], [PassportNumber], [OriginID], [LegalFormID], [originDetails]) VALUES (2, NULL, N'string', N'Yassine', N'Othman', NULL, NULL, NULL, NULL, NULL, N'string', NULL, NULL, NULL, N'066006056', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, N'BK786543', NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[Client] ([ClientID], [VIP], [Matricule], [LastName], [FirstName], [BirthDate], [ClientTitleID], [Nationality], [IdentityID], [Address], [City], [CountryID], [ResidenceCountryID], [MaritalStatusID], [MobilePhone], [LandlinePhone], [WorkPhone], [Email], [ResidencyStatusID], [IsOwner], [IsTenant], [RequestedAmount], [CompanyName], [CreationDate], [RegistrationNumber], [CompanyAddress], [CompanyCity], [CompanyCountryID], [SocialCapital], [BusinessActivityID], [is_individual], [is_organisation], [RoleID], [CIN], [ResidencePermit], [PassportNumber], [OriginID], [LegalFormID], [originDetails]) VALUES (1002, NULL, N'GG676555', N'Kell', N'Oummm', CAST(N'2025-01-23' AS Date), 1002, N'Marocain', 1002, NULL, NULL, NULL, NULL, NULL, N'066345676', NULL, NULL, N'oum@gmail.com', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, N'SD444448', NULL, NULL, 3, NULL, NULL)
INSERT [dbo].[Client] ([ClientID], [VIP], [Matricule], [LastName], [FirstName], [BirthDate], [ClientTitleID], [Nationality], [IdentityID], [Address], [City], [CountryID], [ResidenceCountryID], [MaritalStatusID], [MobilePhone], [LandlinePhone], [WorkPhone], [Email], [ResidencyStatusID], [IsOwner], [IsTenant], [RequestedAmount], [CompanyName], [CreationDate], [RegistrationNumber], [CompanyAddress], [CompanyCity], [CompanyCountryID], [SocialCapital], [BusinessActivityID], [is_individual], [is_organisation], [RoleID], [CIN], [ResidencePermit], [PassportNumber], [OriginID], [LegalFormID], [originDetails]) VALUES (1005, NULL, N'GG676556', N'Issa', N'Yassine', CAST(N'2025-01-23' AS Date), 1002, N'Marocain', 1002, NULL, NULL, NULL, NULL, NULL, N'089876556', NULL, NULL, N'yas@gmail.com', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, N'RR987654', NULL, NULL, 4, NULL, NULL)
INSERT [dbo].[Client] ([ClientID], [VIP], [Matricule], [LastName], [FirstName], [BirthDate], [ClientTitleID], [Nationality], [IdentityID], [Address], [City], [CountryID], [ResidenceCountryID], [MaritalStatusID], [MobilePhone], [LandlinePhone], [WorkPhone], [Email], [ResidencyStatusID], [IsOwner], [IsTenant], [RequestedAmount], [CompanyName], [CreationDate], [RegistrationNumber], [CompanyAddress], [CompanyCity], [CompanyCountryID], [SocialCapital], [BusinessActivityID], [is_individual], [is_organisation], [RoleID], [CIN], [ResidencePermit], [PassportNumber], [OriginID], [LegalFormID], [originDetails]) VALUES (2002, NULL, NULL, N'Fulla', N'da7mani', CAST(N'2025-04-17' AS Date), 1003, N'Marocain', 1002, N'ZERKTOUNI N 622, MHAMID, MARRAKECH, Morocco.', N'sidi kacem', 1003, 1002, 1003, N'0606988480', N'0606988480', N'0606988480', N'fulla@gmail.com', 3, 1, 0, CAST(20000.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, 2, NULL, NULL, NULL, 2, NULL, N'detail ')
INSERT [dbo].[Client] ([ClientID], [VIP], [Matricule], [LastName], [FirstName], [BirthDate], [ClientTitleID], [Nationality], [IdentityID], [Address], [City], [CountryID], [ResidenceCountryID], [MaritalStatusID], [MobilePhone], [LandlinePhone], [WorkPhone], [Email], [ResidencyStatusID], [IsOwner], [IsTenant], [RequestedAmount], [CompanyName], [CreationDate], [RegistrationNumber], [CompanyAddress], [CompanyCity], [CompanyCountryID], [SocialCapital], [BusinessActivityID], [is_individual], [is_organisation], [RoleID], [CIN], [ResidencePermit], [PassportNumber], [OriginID], [LegalFormID], [originDetails]) VALUES (2008, NULL, N'Client-001', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, 5, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Client] ([ClientID], [VIP], [Matricule], [LastName], [FirstName], [BirthDate], [ClientTitleID], [Nationality], [IdentityID], [Address], [City], [CountryID], [ResidenceCountryID], [MaritalStatusID], [MobilePhone], [LandlinePhone], [WorkPhone], [Email], [ResidencyStatusID], [IsOwner], [IsTenant], [RequestedAmount], [CompanyName], [CreationDate], [RegistrationNumber], [CompanyAddress], [CompanyCity], [CompanyCountryID], [SocialCapital], [BusinessActivityID], [is_individual], [is_organisation], [RoleID], [CIN], [ResidencePermit], [PassportNumber], [OriginID], [LegalFormID], [originDetails]) VALUES (2012, NULL, N'Client-002', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, 4, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Client] ([ClientID], [VIP], [Matricule], [LastName], [FirstName], [BirthDate], [ClientTitleID], [Nationality], [IdentityID], [Address], [City], [CountryID], [ResidenceCountryID], [MaritalStatusID], [MobilePhone], [LandlinePhone], [WorkPhone], [Email], [ResidencyStatusID], [IsOwner], [IsTenant], [RequestedAmount], [CompanyName], [CreationDate], [RegistrationNumber], [CompanyAddress], [CompanyCity], [CompanyCountryID], [SocialCapital], [BusinessActivityID], [is_individual], [is_organisation], [RoleID], [CIN], [ResidencePermit], [PassportNumber], [OriginID], [LegalFormID], [originDetails]) VALUES (2013, NULL, N'Client-003', NULL, NULL, NULL, NULL, NULL, 1004, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, 3, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Client] ([ClientID], [VIP], [Matricule], [LastName], [FirstName], [BirthDate], [ClientTitleID], [Nationality], [IdentityID], [Address], [City], [CountryID], [ResidenceCountryID], [MaritalStatusID], [MobilePhone], [LandlinePhone], [WorkPhone], [Email], [ResidencyStatusID], [IsOwner], [IsTenant], [RequestedAmount], [CompanyName], [CreationDate], [RegistrationNumber], [CompanyAddress], [CompanyCity], [CompanyCountryID], [SocialCapital], [BusinessActivityID], [is_individual], [is_organisation], [RoleID], [CIN], [ResidencePermit], [PassportNumber], [OriginID], [LegalFormID], [originDetails]) VALUES (2014, NULL, N'Client-004', N'IDRISSI', N'MOHAMED AYOUB', NULL, NULL, NULL, 1002, N'ZERKTOUNI N 622, MHAMID, MARRAKECH, Morocco.', N'Marrakech', 1002, NULL, 1003, N'0606988480', NULL, NULL, N'medayoub.idrissi@gmail.com', 2, 1, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, 1, N'ooommm', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Client] ([ClientID], [VIP], [Matricule], [LastName], [FirstName], [BirthDate], [ClientTitleID], [Nationality], [IdentityID], [Address], [City], [CountryID], [ResidenceCountryID], [MaritalStatusID], [MobilePhone], [LandlinePhone], [WorkPhone], [Email], [ResidencyStatusID], [IsOwner], [IsTenant], [RequestedAmount], [CompanyName], [CreationDate], [RegistrationNumber], [CompanyAddress], [CompanyCity], [CompanyCountryID], [SocialCapital], [BusinessActivityID], [is_individual], [is_organisation], [RoleID], [CIN], [ResidencePermit], [PassportNumber], [OriginID], [LegalFormID], [originDetails]) VALUES (2015, NULL, N'Client-005', N'IDRISSI', N'MOHAMED AYOUB yyyy', CAST(N'1996-04-23' AS Date), 1003, NULL, 1004, N'ZERKTOUNI N 622, MHAMID, MARRAKECH, Morocco.', N'Marrakech', 1002, 1003, 1003, N'0606988480', N'0606988480', N'0606988480', N'medayoub.idrissi@gmail.com', 3, 0, 1, CAST(1000000.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, 5, NULL, NULL, N'RRRRRR', 3, NULL, N'YTDUGFJV /HKLHN')
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
SET IDENTITY_INSERT [dbo].[ClientCountry] ON 

INSERT [dbo].[ClientCountry] ([ClientCountryID], [ClientCountryLabel]) VALUES (1002, N'Maroc')
INSERT [dbo].[ClientCountry] ([ClientCountryID], [ClientCountryLabel]) VALUES (1003, N'France')
INSERT [dbo].[ClientCountry] ([ClientCountryID], [ClientCountryLabel]) VALUES (1004, N'Italie')
SET IDENTITY_INSERT [dbo].[ClientCountry] OFF
GO
SET IDENTITY_INSERT [dbo].[ClientIdentity] ON 

INSERT [dbo].[ClientIdentity] ([IdentityID], [IdentityLabel]) VALUES (1002, N'CIN')
INSERT [dbo].[ClientIdentity] ([IdentityID], [IdentityLabel]) VALUES (1003, N'Carte Séjour
')
INSERT [dbo].[ClientIdentity] ([IdentityID], [IdentityLabel]) VALUES (1004, N'Passeport')
SET IDENTITY_INSERT [dbo].[ClientIdentity] OFF
GO
SET IDENTITY_INSERT [dbo].[ClientLegalForm] ON 

INSERT [dbo].[ClientLegalForm] ([LegalFormID], [LegalFormLabel]) VALUES (1, N'Société à Responsabilité Limitée')
INSERT [dbo].[ClientLegalForm] ([LegalFormID], [LegalFormLabel]) VALUES (2, N'Association')
INSERT [dbo].[ClientLegalForm] ([LegalFormID], [LegalFormLabel]) VALUES (3, N'Fondation')
INSERT [dbo].[ClientLegalForm] ([LegalFormID], [LegalFormLabel]) VALUES (4, N'Société en commandite par actions')
INSERT [dbo].[ClientLegalForm] ([LegalFormID], [LegalFormLabel]) VALUES (5, N'Société Civil Immobilière')
INSERT [dbo].[ClientLegalForm] ([LegalFormID], [LegalFormLabel]) VALUES (6, N'Société en Nom Collectif')
INSERT [dbo].[ClientLegalForm] ([LegalFormID], [LegalFormLabel]) VALUES (7, N'Société anonyme')
INSERT [dbo].[ClientLegalForm] ([LegalFormID], [LegalFormLabel]) VALUES (8, N'Société en commandite simple')
INSERT [dbo].[ClientLegalForm] ([LegalFormID], [LegalFormLabel]) VALUES (9, N'Groupement d''interêt économique')
SET IDENTITY_INSERT [dbo].[ClientLegalForm] OFF
GO
SET IDENTITY_INSERT [dbo].[ClientOrigin] ON 

INSERT [dbo].[ClientOrigin] ([OriginID], [OriginLabel]) VALUES (1, N'Site Web')
INSERT [dbo].[ClientOrigin] ([OriginID], [OriginLabel]) VALUES (2, N'Compagne Facebook/Instagram')
INSERT [dbo].[ClientOrigin] ([OriginID], [OriginLabel]) VALUES (3, N'Promoteur Immobilier')
INSERT [dbo].[ClientOrigin] ([OriginID], [OriginLabel]) VALUES (4, N'Agence Immobilière')
INSERT [dbo].[ClientOrigin] ([OriginID], [OriginLabel]) VALUES (5, N'Mandataires')
INSERT [dbo].[ClientOrigin] ([OriginID], [OriginLabel]) VALUES (6, N'Apporteurs d''Affaire Individuel (AAI)')
INSERT [dbo].[ClientOrigin] ([OriginID], [OriginLabel]) VALUES (7, N'Parrainage')
SET IDENTITY_INSERT [dbo].[ClientOrigin] OFF
GO
INSERT [dbo].[ClientRole] ([RoleID], [RoleLabel]) VALUES (1, N'Emprunteur')
INSERT [dbo].[ClientRole] ([RoleID], [RoleLabel]) VALUES (2, N'Co-emprunteur')
INSERT [dbo].[ClientRole] ([RoleID], [RoleLabel]) VALUES (3, N'Caution personnelle et solidaire')
INSERT [dbo].[ClientRole] ([RoleID], [RoleLabel]) VALUES (4, N'Caution hypothécaire')
INSERT [dbo].[ClientRole] ([RoleID], [RoleLabel]) VALUES (5, N'Propriétaire')
INSERT [dbo].[ClientRole] ([RoleID], [RoleLabel]) VALUES (6, N'Propriétaire dans l''indivision')
INSERT [dbo].[ClientRole] ([RoleID], [RoleLabel]) VALUES (7, N'Usufruitier')
INSERT [dbo].[ClientRole] ([RoleID], [RoleLabel]) VALUES (8, N'Nu-propriétaire')
GO
SET IDENTITY_INSERT [dbo].[ClientTitle] ON 

INSERT [dbo].[ClientTitle] ([ClientTitleID], [ClientTitleLabel]) VALUES (1002, N'M')
INSERT [dbo].[ClientTitle] ([ClientTitleID], [ClientTitleLabel]) VALUES (1003, N'Mme')
INSERT [dbo].[ClientTitle] ([ClientTitleID], [ClientTitleLabel]) VALUES (1004, N'Melle')
SET IDENTITY_INSERT [dbo].[ClientTitle] OFF
GO
SET IDENTITY_INSERT [dbo].[Credit] ON 

INSERT [dbo].[Credit] ([CreditID], [Matricule], [CreditTypeID], [amount]) VALUES (5, N'DOS-001', 3, CAST(50000.00 AS Decimal(18, 2)))
INSERT [dbo].[Credit] ([CreditID], [Matricule], [CreditTypeID], [amount]) VALUES (6, N'DOS-002', 4, CAST(20000.00 AS Decimal(18, 2)))
INSERT [dbo].[Credit] ([CreditID], [Matricule], [CreditTypeID], [amount]) VALUES (7, N'DOS-003', 2, CAST(12000000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Credit] OFF
GO
SET IDENTITY_INSERT [dbo].[CreditType] ON 

INSERT [dbo].[CreditType] ([TypeID], [TypeLabel]) VALUES (1, N'Crédit Crédit immobilier')
INSERT [dbo].[CreditType] ([TypeID], [TypeLabel]) VALUES (2, N'Crédit consommation')
INSERT [dbo].[CreditType] ([TypeID], [TypeLabel]) VALUES (3, N'Crédit hypothécaire')
INSERT [dbo].[CreditType] ([TypeID], [TypeLabel]) VALUES (4, N'Crédit-Bail Immobilier')
INSERT [dbo].[CreditType] ([TypeID], [TypeLabel]) VALUES (5, N'Crédit-Bail Mobilier')
INSERT [dbo].[CreditType] ([TypeID], [TypeLabel]) VALUES (6, N'Crédit à la promotion')
INSERT [dbo].[CreditType] ([TypeID], [TypeLabel]) VALUES (7, N'Crédit d’investissement')
SET IDENTITY_INSERT [dbo].[CreditType] OFF
GO
SET IDENTITY_INSERT [dbo].[LignCreditClient] ON 

INSERT [dbo].[LignCreditClient] ([LignCreditClientID], [ClientID], [CreditID], [IsPrincipal], [PercentageClient]) VALUES (3, 1005, 5, 1, 0)
INSERT [dbo].[LignCreditClient] ([LignCreditClientID], [ClientID], [CreditID], [IsPrincipal], [PercentageClient]) VALUES (4, 2, 6, 1, 0)
INSERT [dbo].[LignCreditClient] ([LignCreditClientID], [ClientID], [CreditID], [IsPrincipal], [PercentageClient]) VALUES (5, 1, 7, 1, 70)
INSERT [dbo].[LignCreditClient] ([LignCreditClientID], [ClientID], [CreditID], [IsPrincipal], [PercentageClient]) VALUES (6, 1002, 7, 0, 30)
SET IDENTITY_INSERT [dbo].[LignCreditClient] OFF
GO
SET IDENTITY_INSERT [dbo].[MaritalStatus] ON 

INSERT [dbo].[MaritalStatus] ([MaritalStatusID], [MaritalStatusLabel]) VALUES (1002, N'Célibataire')
INSERT [dbo].[MaritalStatus] ([MaritalStatusID], [MaritalStatusLabel]) VALUES (1003, N'Marié(e)')
INSERT [dbo].[MaritalStatus] ([MaritalStatusID], [MaritalStatusLabel]) VALUES (1004, N'Veuf(e)')
INSERT [dbo].[MaritalStatus] ([MaritalStatusID], [MaritalStatusLabel]) VALUES (2002, N'Divorcé(e)')
SET IDENTITY_INSERT [dbo].[MaritalStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[ResidencyStatus] ON 

INSERT [dbo].[ResidencyStatus] ([ResidencyStatusID], [ResidencyStatusLabel]) VALUES (2, N'Résident ')
INSERT [dbo].[ResidencyStatus] ([ResidencyStatusID], [ResidencyStatusLabel]) VALUES (3, N'MRE ')
INSERT [dbo].[ResidencyStatus] ([ResidencyStatusID], [ResidencyStatusLabel]) VALUES (4, N'ENR ')
SET IDENTITY_INSERT [dbo].[ResidencyStatus] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Client__0FB9FB43D87CB9C6]    Script Date: 04/05/2025 21:44:31 ******/
ALTER TABLE [dbo].[Client] ADD UNIQUE NONCLUSTERED 
(
	[Matricule] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Credit] ADD  DEFAULT ((0)) FOR [amount]
GO
ALTER TABLE [dbo].[BankCommitmentsCharges]  WITH CHECK ADD  CONSTRAINT [FK_BankCommitmentsCharges_AgencyBank] FOREIGN KEY([AgencyBankID])
REFERENCES [dbo].[AgencyBank] ([AgencyBankID])
GO
ALTER TABLE [dbo].[BankCommitmentsCharges] CHECK CONSTRAINT [FK_BankCommitmentsCharges_AgencyBank]
GO
ALTER TABLE [dbo].[BankCommitmentsCharges]  WITH CHECK ADD  CONSTRAINT [FK_BankCommitmentsCharges_Client] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Client] ([ClientID])
GO
ALTER TABLE [dbo].[BankCommitmentsCharges] CHECK CONSTRAINT [FK_BankCommitmentsCharges_Client]
GO
ALTER TABLE [dbo].[BankCommitmentsCharges]  WITH CHECK ADD  CONSTRAINT [FK_BankCommitmentsCharges_NatureCommitment] FOREIGN KEY([NatureCommitmentID])
REFERENCES [dbo].[NatureCommitment] ([NatureCommitmentID])
GO
ALTER TABLE [dbo].[BankCommitmentsCharges] CHECK CONSTRAINT [FK_BankCommitmentsCharges_NatureCommitment]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_BusinessActivity] FOREIGN KEY([BusinessActivityID])
REFERENCES [dbo].[BusinessActivity] ([BusinessActivityID])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_BusinessActivity]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_ClientLegalForm] FOREIGN KEY([LegalFormID])
REFERENCES [dbo].[ClientLegalForm] ([LegalFormID])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_ClientLegalForm]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_ClientTitle] FOREIGN KEY([ClientTitleID])
REFERENCES [dbo].[ClientTitle] ([ClientTitleID])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_ClientTitle]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_CompanyCountry] FOREIGN KEY([CompanyCountryID])
REFERENCES [dbo].[ClientCountry] ([ClientCountryID])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_CompanyCountry]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_Country] FOREIGN KEY([CountryID])
REFERENCES [dbo].[ClientCountry] ([ClientCountryID])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_Country]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_Identity] FOREIGN KEY([IdentityID])
REFERENCES [dbo].[ClientIdentity] ([IdentityID])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_Identity]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_MaritalStatus] FOREIGN KEY([MaritalStatusID])
REFERENCES [dbo].[MaritalStatus] ([MaritalStatusID])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_MaritalStatus]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_Origin] FOREIGN KEY([OriginID])
REFERENCES [dbo].[ClientOrigin] ([OriginID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_Origin]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_ResidenceCountry] FOREIGN KEY([ResidenceCountryID])
REFERENCES [dbo].[ClientCountry] ([ClientCountryID])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_ResidenceCountry]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_ResidencyStatus] FOREIGN KEY([ResidencyStatusID])
REFERENCES [dbo].[ResidencyStatus] ([ResidencyStatusID])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_ResidencyStatus]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_RoleID] FOREIGN KEY([RoleID])
REFERENCES [dbo].[ClientRole] ([RoleID])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_RoleID]
GO
ALTER TABLE [dbo].[ClientManager]  WITH CHECK ADD  CONSTRAINT [FK_ClientManager_Client] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Client] ([ClientID])
GO
ALTER TABLE [dbo].[ClientManager] CHECK CONSTRAINT [FK_ClientManager_Client]
GO
ALTER TABLE [dbo].[ClientManager]  WITH CHECK ADD  CONSTRAINT [FK_ClientManager_Manager] FOREIGN KEY([ManagerID])
REFERENCES [dbo].[ManagerInformation] ([ManagerID])
GO
ALTER TABLE [dbo].[ClientManager] CHECK CONSTRAINT [FK_ClientManager_Manager]
GO
ALTER TABLE [dbo].[Credit]  WITH CHECK ADD FOREIGN KEY([CreditTypeID])
REFERENCES [dbo].[CreditType] ([TypeID])
GO
ALTER TABLE [dbo].[CreditDepot]  WITH CHECK ADD FOREIGN KEY([id_agency_bank])
REFERENCES [dbo].[AgencyBank] ([AgencyBankID])
GO
ALTER TABLE [dbo].[CreditDepot]  WITH CHECK ADD FOREIGN KEY([id_credit])
REFERENCES [dbo].[Credit] ([CreditID])
GO
ALTER TABLE [dbo].[CreditStatus]  WITH CHECK ADD FOREIGN KEY([id_credit])
REFERENCES [dbo].[Credit] ([CreditID])
GO
ALTER TABLE [dbo].[CreditStatus]  WITH CHECK ADD FOREIGN KEY([id_depot])
REFERENCES [dbo].[CreditDepot] ([CreditDepotId])
GO
ALTER TABLE [dbo].[InfoProfessional]  WITH CHECK ADD  CONSTRAINT [FK_InfoProfessional_Client] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Client] ([ClientID])
GO
ALTER TABLE [dbo].[InfoProfessional] CHECK CONSTRAINT [FK_InfoProfessional_Client]
GO
ALTER TABLE [dbo].[InfosBank]  WITH CHECK ADD  CONSTRAINT [FK_InfosBank_AgencyBank] FOREIGN KEY([AgencyBankID])
REFERENCES [dbo].[AgencyBank] ([AgencyBankID])
GO
ALTER TABLE [dbo].[InfosBank] CHECK CONSTRAINT [FK_InfosBank_AgencyBank]
GO
ALTER TABLE [dbo].[InfosBank]  WITH CHECK ADD  CONSTRAINT [FK_InfosBank_Client] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Client] ([ClientID])
GO
ALTER TABLE [dbo].[InfosBank] CHECK CONSTRAINT [FK_InfosBank_Client]
GO
ALTER TABLE [dbo].[LignCreditClient]  WITH CHECK ADD  CONSTRAINT [FK_LignCreditClient_Client] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Client] ([ClientID])
GO
ALTER TABLE [dbo].[LignCreditClient] CHECK CONSTRAINT [FK_LignCreditClient_Client]
GO
ALTER TABLE [dbo].[LignCreditClient]  WITH CHECK ADD  CONSTRAINT [FK_LignCreditClient_Credit] FOREIGN KEY([CreditID])
REFERENCES [dbo].[Credit] ([CreditID])
GO
ALTER TABLE [dbo].[LignCreditClient] CHECK CONSTRAINT [FK_LignCreditClient_Credit]
GO
ALTER TABLE [dbo].[LignCreditProperty]  WITH CHECK ADD  CONSTRAINT [FK_LignCreditProperty_Credit] FOREIGN KEY([CreditID])
REFERENCES [dbo].[Credit] ([CreditID])
GO
ALTER TABLE [dbo].[LignCreditProperty] CHECK CONSTRAINT [FK_LignCreditProperty_Credit]
GO
ALTER TABLE [dbo].[LignCreditProperty]  WITH CHECK ADD  CONSTRAINT [FK_LignCreditProperty_ObjectCredit] FOREIGN KEY([ObjectCreditID])
REFERENCES [dbo].[ObjectCredit] ([ObjectCreditID])
GO
ALTER TABLE [dbo].[LignCreditProperty] CHECK CONSTRAINT [FK_LignCreditProperty_ObjectCredit]
GO
ALTER TABLE [dbo].[LignCreditProperty]  WITH CHECK ADD  CONSTRAINT [FK_LignCreditProperty_Property] FOREIGN KEY([PropertyID])
REFERENCES [dbo].[Property] ([PropertyID])
GO
ALTER TABLE [dbo].[LignCreditProperty] CHECK CONSTRAINT [FK_LignCreditProperty_Property]
GO
ALTER TABLE [dbo].[ManagerInformation]  WITH CHECK ADD  CONSTRAINT [FK_Manager_ClientTitle] FOREIGN KEY([ManagerTitleID])
REFERENCES [dbo].[ClientTitle] ([ClientTitleID])
GO
ALTER TABLE [dbo].[ManagerInformation] CHECK CONSTRAINT [FK_Manager_ClientTitle]
GO
ALTER TABLE [dbo].[ManagerInformation]  WITH CHECK ADD  CONSTRAINT [FK_Manager_Country] FOREIGN KEY([ManagerCountryID])
REFERENCES [dbo].[ClientCountry] ([ClientCountryID])
GO
ALTER TABLE [dbo].[ManagerInformation] CHECK CONSTRAINT [FK_Manager_Country]
GO
ALTER TABLE [dbo].[ManagerInformation]  WITH CHECK ADD  CONSTRAINT [FK_Manager_Identity] FOREIGN KEY([Id_Identity])
REFERENCES [dbo].[ClientIdentity] ([IdentityID])
GO
ALTER TABLE [dbo].[ManagerInformation] CHECK CONSTRAINT [FK_Manager_Identity]
GO
ALTER TABLE [dbo].[ManagerInformation]  WITH CHECK ADD  CONSTRAINT [FK_Manager_MaritalStatus] FOREIGN KEY([Id_ManagerMaritalStatus])
REFERENCES [dbo].[MaritalStatus] ([MaritalStatusID])
GO
ALTER TABLE [dbo].[ManagerInformation] CHECK CONSTRAINT [FK_Manager_MaritalStatus]
GO
ALTER TABLE [dbo].[ManagerInformation]  WITH CHECK ADD  CONSTRAINT [FK_Manager_ResidenceCountry] FOREIGN KEY([ManagerResidenceCountryID])
REFERENCES [dbo].[ClientCountry] ([ClientCountryID])
GO
ALTER TABLE [dbo].[ManagerInformation] CHECK CONSTRAINT [FK_Manager_ResidenceCountry]
GO
ALTER TABLE [dbo].[Property]  WITH CHECK ADD  CONSTRAINT [FK_Property_AssignmentProperty] FOREIGN KEY([AssignmentPropertyID])
REFERENCES [dbo].[AssignmentProperty] ([AssignmentPropertyID])
GO
ALTER TABLE [dbo].[Property] CHECK CONSTRAINT [FK_Property_AssignmentProperty]
GO
ALTER TABLE [dbo].[Property]  WITH CHECK ADD  CONSTRAINT [FK_Property_ConditionProperty] FOREIGN KEY([ConditionPropertyID])
REFERENCES [dbo].[ConditionProperty] ([ConditionPropertyID])
GO
ALTER TABLE [dbo].[Property] CHECK CONSTRAINT [FK_Property_ConditionProperty]
GO
ALTER TABLE [dbo].[Property]  WITH CHECK ADD  CONSTRAINT [FK_Property_NatureProperty] FOREIGN KEY([NaturePropertyID])
REFERENCES [dbo].[NatureProperty] ([NaturePropertyID])
GO
ALTER TABLE [dbo].[Property] CHECK CONSTRAINT [FK_Property_NatureProperty]
GO
ALTER TABLE [dbo].[Property]  WITH CHECK ADD  CONSTRAINT [FK_Property_UseProperty] FOREIGN KEY([UsePropertyID])
REFERENCES [dbo].[UseProperty] ([UsePropertyID])
GO
ALTER TABLE [dbo].[Property] CHECK CONSTRAINT [FK_Property_UseProperty]
GO
