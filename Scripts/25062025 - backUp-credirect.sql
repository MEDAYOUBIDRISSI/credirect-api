USE [IDX]
GO
/****** Object:  Table [dbo].[AgencyBank]    Script Date: 25/06/2025 00:49:13 ******/
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
/****** Object:  Table [dbo].[AssignmentProperty]    Script Date: 25/06/2025 00:49:14 ******/
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
/****** Object:  Table [dbo].[BankCommitmentsCharges]    Script Date: 25/06/2025 00:49:14 ******/
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
	[info_locataire] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[BankCommitmentChargeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BusinessActivity]    Script Date: 25/06/2025 00:49:14 ******/
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
/****** Object:  Table [dbo].[Client]    Script Date: 25/06/2025 00:49:14 ******/
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
	[Profession] [int] NULL,
	[Nature_activity] [nvarchar](max) NULL,
	[IfOrTp] [nvarchar](max) NULL,
	[Adress_activity] [nvarchar](max) NULL,
	[Honoraires] [decimal](18, 2) NULL,
	[Date_debut_exercice] [datetime] NULL,
	[Fonction] [nvarchar](max) NULL,
	[Employeur] [nvarchar](max) NULL,
	[Date_Embauche] [datetime] NULL,
	[Salaire] [decimal](18, 2) NULL,
	[NRC] [nvarchar](max) NULL,
	[Date_Creation_RC] [datetime] NULL,
	[Revenu] [decimal](18, 2) NULL,
	[Denomination] [nvarchar](max) NULL,
	[Date_Creation_Company] [datetime] NULL,
	[ActivityCompany] [nvarchar](max) NULL,
	[Capital_Social] [decimal](18, 2) NULL,
	[ResultatYearN] [decimal](18, 2) NULL,
	[ChiffreAffaireYearN] [decimal](18, 2) NULL,
	[ResultatYearN_1] [decimal](18, 2) NULL,
	[ChiffreAffaireYearN_1] [decimal](18, 2) NULL,
	[PartsParticipationSociete] [decimal](18, 2) NULL,
	[Nature_Bail] [int] NULL,
	[Rent] [decimal](18, 2) NULL,
	[created_at] [datetime2](7) NULL,
	[updated_at] [datetime2](7) NULL,
	[deleted_at] [datetime2](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientCountry]    Script Date: 25/06/2025 00:49:14 ******/
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
/****** Object:  Table [dbo].[ClientIdentity]    Script Date: 25/06/2025 00:49:14 ******/
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
/****** Object:  Table [dbo].[ClientLegalForm]    Script Date: 25/06/2025 00:49:14 ******/
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
/****** Object:  Table [dbo].[ClientManager]    Script Date: 25/06/2025 00:49:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientManager](
	[ClientManagerID] [int] IDENTITY(1,1) NOT NULL,
	[ClientID] [int] NOT NULL,
	[ManagerID] [int] NOT NULL,
	[created_at] [datetime2](7) NULL,
	[updated_at] [datetime2](7) NULL,
	[deleted_at] [datetime2](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[ClientManagerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientOrigin]    Script Date: 25/06/2025 00:49:14 ******/
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
/****** Object:  Table [dbo].[ClientRole]    Script Date: 25/06/2025 00:49:14 ******/
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
/****** Object:  Table [dbo].[ClientTitle]    Script Date: 25/06/2025 00:49:14 ******/
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
/****** Object:  Table [dbo].[ConditionProperty]    Script Date: 25/06/2025 00:49:14 ******/
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
/****** Object:  Table [dbo].[Credit]    Script Date: 25/06/2025 00:49:14 ******/
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
/****** Object:  Table [dbo].[CreditDepot]    Script Date: 25/06/2025 00:49:14 ******/
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
/****** Object:  Table [dbo].[CreditStatus]    Script Date: 25/06/2025 00:49:14 ******/
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
	[is_accord] [int] NULL,
	[is_accord_client] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CreditStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CreditType]    Script Date: 25/06/2025 00:49:14 ******/
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
/****** Object:  Table [dbo].[DepotStatus]    Script Date: 25/06/2025 00:49:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepotStatus](
	[DepotStatusID] [int] IDENTITY(1,1) NOT NULL,
	[CreditDepotID] [int] NULL,
	[CreditID] [int] NULL,
	[statusDepot] [int] NULL,
	[is_Accord] [int] NULL,
	[dateEnvoi] [datetime] NULL,
	[comment] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[DepotStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GarantieCredit]    Script Date: 25/06/2025 00:49:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GarantieCredit](
	[GarantieCreditID] [int] IDENTITY(1,1) NOT NULL,
	[Label] [nvarchar](255) NULL,
	[CreditID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[GarantieCreditID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InfoProfessional]    Script Date: 25/06/2025 00:49:14 ******/
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
/****** Object:  Table [dbo].[InfosBank]    Script Date: 25/06/2025 00:49:14 ******/
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
	[AgencyName] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[InfoBankID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LignCreditClient]    Script Date: 25/06/2025 00:49:14 ******/
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
/****** Object:  Table [dbo].[LignCreditProperty]    Script Date: 25/06/2025 00:49:14 ******/
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
	[MontantCredit] [decimal](18, 2) NULL,
	[DureeCredit] [decimal](18, 2) NULL,
	[FrequenceRemboursement] [int] NULL,
	[DureeFranchise] [decimal](18, 2) NULL,
	[TauxCredit] [decimal](18, 4) NULL,
	[DerogationSouhaite] [bit] NULL,
	[AssuranceDeczsInvalidite] [int] NULL,
	[CommentCredit] [nvarchar](max) NULL,
	[honorairesFactures] [decimal](18, 2) NULL,
	[DerogationSouhaiteeText] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[LignCreditPropertyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ManagerInformation]    Script Date: 25/06/2025 00:49:14 ******/
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
	[created_at] [datetime2](7) NULL,
	[updated_at] [datetime2](7) NULL,
	[deleted_at] [datetime2](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[ManagerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaritalStatus]    Script Date: 25/06/2025 00:49:14 ******/
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
/****** Object:  Table [dbo].[NatureCommitment]    Script Date: 25/06/2025 00:49:14 ******/
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
/****** Object:  Table [dbo].[NatureProperty]    Script Date: 25/06/2025 00:49:14 ******/
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
/****** Object:  Table [dbo].[ObjectCredit]    Script Date: 25/06/2025 00:49:14 ******/
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
/****** Object:  Table [dbo].[Pensionnaire]    Script Date: 25/06/2025 00:49:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pensionnaire](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[NaturePension] [nvarchar](max) NULL,
	[OrganismePension] [int] NULL,
	[TypePension] [int] NULL,
	[Montant] [decimal](18, 2) NULL,
	[ClientID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Property]    Script Date: 25/06/2025 00:49:14 ******/
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
	[CreditID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PropertyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ResidencyStatus]    Script Date: 25/06/2025 00:49:14 ******/
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
/****** Object:  Table [dbo].[role_bo]    Script Date: 25/06/2025 00:49:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[role_bo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[libelle] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentDetail]    Script Date: 25/06/2025 00:49:14 ******/
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
/****** Object:  Table [dbo].[UseProperty]    Script Date: 25/06/2025 00:49:14 ******/
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
/****** Object:  Table [dbo].[user_bo]    Script Date: 25/06/2025 00:49:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_bo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [nvarchar](100) NOT NULL,
	[last_name] [nvarchar](100) NOT NULL,
	[email] [nvarchar](255) NOT NULL,
	[password] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user_bo_role_bo]    Script Date: 25/06/2025 00:49:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_bo_role_bo](
	[user_id] [int] NOT NULL,
	[role_id] [int] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_user_bo_role_bo_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AgencyBank] ON 

INSERT [dbo].[AgencyBank] ([AgencyBankID], [AgencyBankLabel]) VALUES (1, N'Attijariwafa Bank')
INSERT [dbo].[AgencyBank] ([AgencyBankID], [AgencyBankLabel]) VALUES (2, N'Banque Populaire')
INSERT [dbo].[AgencyBank] ([AgencyBankID], [AgencyBankLabel]) VALUES (3, N'BMCE Bank')
INSERT [dbo].[AgencyBank] ([AgencyBankID], [AgencyBankLabel]) VALUES (4, N'Crédit du Maroc')
INSERT [dbo].[AgencyBank] ([AgencyBankID], [AgencyBankLabel]) VALUES (5, N'Société Générale Maroc')
SET IDENTITY_INSERT [dbo].[AgencyBank] OFF
GO
SET IDENTITY_INSERT [dbo].[AssignmentProperty] ON 

INSERT [dbo].[AssignmentProperty] ([AssignmentPropertyID], [AssignmentPropertyLabel]) VALUES (1, N'Bien objet du crédit')
INSERT [dbo].[AssignmentProperty] ([AssignmentPropertyID], [AssignmentPropertyLabel]) VALUES (2, N'Bien supplémentaire')
INSERT [dbo].[AssignmentProperty] ([AssignmentPropertyID], [AssignmentPropertyLabel]) VALUES (3, N'Bien de substitution')
SET IDENTITY_INSERT [dbo].[AssignmentProperty] OFF
GO
SET IDENTITY_INSERT [dbo].[BankCommitmentsCharges] ON 

INSERT [dbo].[BankCommitmentsCharges] ([BankCommitmentChargeID], [NatureCommitmentID], [AgencyBankID], [OtherAgency], [ClientID], [Maturity], [Outstanding], [RepayableEarly], [info_locataire]) VALUES (3, 3, 2, N'agdal', 1005, CAST(6000.00 AS Decimal(18, 2)), 0, 1, NULL)
INSERT [dbo].[BankCommitmentsCharges] ([BankCommitmentChargeID], [NatureCommitmentID], [AgencyBankID], [OtherAgency], [ClientID], [Maturity], [Outstanding], [RepayableEarly], [info_locataire]) VALUES (2003, 2, 3, N'wdgdxf', 4005, CAST(12222.00 AS Decimal(18, 2)), 1, 0, NULL)
INSERT [dbo].[BankCommitmentsCharges] ([BankCommitmentChargeID], [NatureCommitmentID], [AgencyBankID], [OtherAgency], [ClientID], [Maturity], [Outstanding], [RepayableEarly], [info_locataire]) VALUES (3003, 2, 3, N'DQSFDSG', 5004, CAST(10000.00 AS Decimal(18, 2)), 1, 1, CAST(0.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[BankCommitmentsCharges] OFF
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

INSERT [dbo].[Client] ([ClientID], [VIP], [Matricule], [LastName], [FirstName], [BirthDate], [ClientTitleID], [Nationality], [IdentityID], [Address], [City], [CountryID], [ResidenceCountryID], [MaritalStatusID], [MobilePhone], [LandlinePhone], [WorkPhone], [Email], [ResidencyStatusID], [IsOwner], [IsTenant], [RequestedAmount], [CompanyName], [CreationDate], [RegistrationNumber], [CompanyAddress], [CompanyCity], [CompanyCountryID], [SocialCapital], [BusinessActivityID], [is_individual], [is_organisation], [RoleID], [CIN], [ResidencePermit], [PassportNumber], [OriginID], [LegalFormID], [originDetails], [Profession], [Nature_activity], [IfOrTp], [Adress_activity], [Honoraires], [Date_debut_exercice], [Fonction], [Employeur], [Date_Embauche], [Salaire], [NRC], [Date_Creation_RC], [Revenu], [Denomination], [Date_Creation_Company], [ActivityCompany], [Capital_Social], [ResultatYearN], [ChiffreAffaireYearN], [ResultatYearN_1], [ChiffreAffaireYearN_1], [PartsParticipationSociete], [Nature_Bail], [Rent], [created_at], [updated_at], [deleted_at]) VALUES (1, NULL, N'00001', N'IDRISSI', N'Med Ayoub', CAST(N'1996-08-09' AS Date), NULL, N'Marocain', NULL, N'Adress 1', N'Marrakech', NULL, NULL, NULL, N'066006006', N'066006007', N'066006008', N'medayoub.idrissi@gmail.com', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, 1, N'TT565656', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Client] ([ClientID], [VIP], [Matricule], [LastName], [FirstName], [BirthDate], [ClientTitleID], [Nationality], [IdentityID], [Address], [City], [CountryID], [ResidenceCountryID], [MaritalStatusID], [MobilePhone], [LandlinePhone], [WorkPhone], [Email], [ResidencyStatusID], [IsOwner], [IsTenant], [RequestedAmount], [CompanyName], [CreationDate], [RegistrationNumber], [CompanyAddress], [CompanyCity], [CompanyCountryID], [SocialCapital], [BusinessActivityID], [is_individual], [is_organisation], [RoleID], [CIN], [ResidencePermit], [PassportNumber], [OriginID], [LegalFormID], [originDetails], [Profession], [Nature_activity], [IfOrTp], [Adress_activity], [Honoraires], [Date_debut_exercice], [Fonction], [Employeur], [Date_Embauche], [Salaire], [NRC], [Date_Creation_RC], [Revenu], [Denomination], [Date_Creation_Company], [ActivityCompany], [Capital_Social], [ResultatYearN], [ChiffreAffaireYearN], [ResultatYearN_1], [ChiffreAffaireYearN_1], [PartsParticipationSociete], [Nature_Bail], [Rent], [created_at], [updated_at], [deleted_at]) VALUES (2, NULL, N'string', N'Yassine', N'Othman', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Client] ([ClientID], [VIP], [Matricule], [LastName], [FirstName], [BirthDate], [ClientTitleID], [Nationality], [IdentityID], [Address], [City], [CountryID], [ResidenceCountryID], [MaritalStatusID], [MobilePhone], [LandlinePhone], [WorkPhone], [Email], [ResidencyStatusID], [IsOwner], [IsTenant], [RequestedAmount], [CompanyName], [CreationDate], [RegistrationNumber], [CompanyAddress], [CompanyCity], [CompanyCountryID], [SocialCapital], [BusinessActivityID], [is_individual], [is_organisation], [RoleID], [CIN], [ResidencePermit], [PassportNumber], [OriginID], [LegalFormID], [originDetails], [Profession], [Nature_activity], [IfOrTp], [Adress_activity], [Honoraires], [Date_debut_exercice], [Fonction], [Employeur], [Date_Embauche], [Salaire], [NRC], [Date_Creation_RC], [Revenu], [Denomination], [Date_Creation_Company], [ActivityCompany], [Capital_Social], [ResultatYearN], [ChiffreAffaireYearN], [ResultatYearN_1], [ChiffreAffaireYearN_1], [PartsParticipationSociete], [Nature_Bail], [Rent], [created_at], [updated_at], [deleted_at]) VALUES (1002, NULL, N'GG676555', N'Kell', N'Oummm', CAST(N'2025-01-23' AS Date), NULL, N'Marocain', NULL, NULL, N'Sidi Kassem', NULL, NULL, NULL, N'066345676', NULL, NULL, N'oum@gmail.com', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, 2, N'KK56456', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Client] ([ClientID], [VIP], [Matricule], [LastName], [FirstName], [BirthDate], [ClientTitleID], [Nationality], [IdentityID], [Address], [City], [CountryID], [ResidenceCountryID], [MaritalStatusID], [MobilePhone], [LandlinePhone], [WorkPhone], [Email], [ResidencyStatusID], [IsOwner], [IsTenant], [RequestedAmount], [CompanyName], [CreationDate], [RegistrationNumber], [CompanyAddress], [CompanyCity], [CompanyCountryID], [SocialCapital], [BusinessActivityID], [is_individual], [is_organisation], [RoleID], [CIN], [ResidencePermit], [PassportNumber], [OriginID], [LegalFormID], [originDetails], [Profession], [Nature_activity], [IfOrTp], [Adress_activity], [Honoraires], [Date_debut_exercice], [Fonction], [Employeur], [Date_Embauche], [Salaire], [NRC], [Date_Creation_RC], [Revenu], [Denomination], [Date_Creation_Company], [ActivityCompany], [Capital_Social], [ResultatYearN], [ChiffreAffaireYearN], [ResultatYearN_1], [ChiffreAffaireYearN_1], [PartsParticipationSociete], [Nature_Bail], [Rent], [created_at], [updated_at], [deleted_at]) VALUES (1005, NULL, N'GG676556', N'Issa', N'Yassine', CAST(N'2025-01-23' AS Date), 1002, N'Marocain', 1002, NULL, NULL, NULL, NULL, NULL, N'089876556', NULL, NULL, N'yas@gmail.com', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, N'RR987654', NULL, NULL, 4, NULL, NULL, 6, N'Cola', N'srhdr', N'aqfafcqc zvzv zrfvrzv ', CAST(122333.00 AS Decimal(18, 2)), CAST(N'2025-05-04T23:00:00.000' AS DateTime), N'qfq', N'qsfqsfvqs', CAST(N'2025-05-19T23:00:00.000' AS DateTime), CAST(122222.00 AS Decimal(18, 2)), N'aefezvzv ', CAST(N'2025-05-18T23:00:00.000' AS DateTime), CAST(100000.00 AS Decimal(18, 2)), N'Hidden Clouders', CAST(N'2025-05-21T23:00:00.000' AS DateTime), N'aefezlcfz', CAST(11111111111.00 AS Decimal(18, 2)), CAST(1111111111.00 AS Decimal(18, 2)), CAST(11111111.00 AS Decimal(18, 2)), CAST(111111111.00 AS Decimal(18, 2)), CAST(11111111.00 AS Decimal(18, 2)), CAST(1111111.00 AS Decimal(18, 2)), 2, CAST(23333.00 AS Decimal(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[Client] ([ClientID], [VIP], [Matricule], [LastName], [FirstName], [BirthDate], [ClientTitleID], [Nationality], [IdentityID], [Address], [City], [CountryID], [ResidenceCountryID], [MaritalStatusID], [MobilePhone], [LandlinePhone], [WorkPhone], [Email], [ResidencyStatusID], [IsOwner], [IsTenant], [RequestedAmount], [CompanyName], [CreationDate], [RegistrationNumber], [CompanyAddress], [CompanyCity], [CompanyCountryID], [SocialCapital], [BusinessActivityID], [is_individual], [is_organisation], [RoleID], [CIN], [ResidencePermit], [PassportNumber], [OriginID], [LegalFormID], [originDetails], [Profession], [Nature_activity], [IfOrTp], [Adress_activity], [Honoraires], [Date_debut_exercice], [Fonction], [Employeur], [Date_Embauche], [Salaire], [NRC], [Date_Creation_RC], [Revenu], [Denomination], [Date_Creation_Company], [ActivityCompany], [Capital_Social], [ResultatYearN], [ChiffreAffaireYearN], [ResultatYearN_1], [ChiffreAffaireYearN_1], [PartsParticipationSociete], [Nature_Bail], [Rent], [created_at], [updated_at], [deleted_at]) VALUES (2002, NULL, NULL, N'Fulla', N'da7mani', CAST(N'2025-04-17' AS Date), 1003, N'Marocain', 1002, N'ZERKTOUNI N 622, MHAMID, MARRAKECH, Morocco.', N'sidi kacem', 1003, 1002, 1003, N'0606988480', N'0606988480', N'0606988480', N'fulla@gmail.com', 3, 1, 0, CAST(20000.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, 2, NULL, NULL, NULL, 2, NULL, N'detail ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Client] ([ClientID], [VIP], [Matricule], [LastName], [FirstName], [BirthDate], [ClientTitleID], [Nationality], [IdentityID], [Address], [City], [CountryID], [ResidenceCountryID], [MaritalStatusID], [MobilePhone], [LandlinePhone], [WorkPhone], [Email], [ResidencyStatusID], [IsOwner], [IsTenant], [RequestedAmount], [CompanyName], [CreationDate], [RegistrationNumber], [CompanyAddress], [CompanyCity], [CompanyCountryID], [SocialCapital], [BusinessActivityID], [is_individual], [is_organisation], [RoleID], [CIN], [ResidencePermit], [PassportNumber], [OriginID], [LegalFormID], [originDetails], [Profession], [Nature_activity], [IfOrTp], [Adress_activity], [Honoraires], [Date_debut_exercice], [Fonction], [Employeur], [Date_Embauche], [Salaire], [NRC], [Date_Creation_RC], [Revenu], [Denomination], [Date_Creation_Company], [ActivityCompany], [Capital_Social], [ResultatYearN], [ChiffreAffaireYearN], [ResultatYearN_1], [ChiffreAffaireYearN_1], [PartsParticipationSociete], [Nature_Bail], [Rent], [created_at], [updated_at], [deleted_at]) VALUES (2013, NULL, N'Client-003', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Coton', CAST(N'2025-05-14' AS Date), N'3434343434', N'QFsf', N'sDCQSD', NULL, CAST(4554.00 AS Decimal(18, 2)), 2, 0, 1, 5, NULL, NULL, NULL, NULL, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Client] ([ClientID], [VIP], [Matricule], [LastName], [FirstName], [BirthDate], [ClientTitleID], [Nationality], [IdentityID], [Address], [City], [CountryID], [ResidenceCountryID], [MaritalStatusID], [MobilePhone], [LandlinePhone], [WorkPhone], [Email], [ResidencyStatusID], [IsOwner], [IsTenant], [RequestedAmount], [CompanyName], [CreationDate], [RegistrationNumber], [CompanyAddress], [CompanyCity], [CompanyCountryID], [SocialCapital], [BusinessActivityID], [is_individual], [is_organisation], [RoleID], [CIN], [ResidencePermit], [PassportNumber], [OriginID], [LegalFormID], [originDetails], [Profession], [Nature_activity], [IfOrTp], [Adress_activity], [Honoraires], [Date_debut_exercice], [Fonction], [Employeur], [Date_Embauche], [Salaire], [NRC], [Date_Creation_RC], [Revenu], [Denomination], [Date_Creation_Company], [ActivityCompany], [Capital_Social], [ResultatYearN], [ChiffreAffaireYearN], [ResultatYearN_1], [ChiffreAffaireYearN_1], [PartsParticipationSociete], [Nature_Bail], [Rent], [created_at], [updated_at], [deleted_at]) VALUES (2014, NULL, N'Client-004', N'IDRISSI', N'MOHAMED AYOUB', NULL, NULL, NULL, 1002, N'ZERKTOUNI N 622, MHAMID, MARRAKECH, Morocco.', N'Marrakech', 1002, NULL, 1003, N'0606988480', NULL, NULL, N'medayoub.idrissi@gmail.com', 2, 1, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, 1, N'ooommm', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Client] ([ClientID], [VIP], [Matricule], [LastName], [FirstName], [BirthDate], [ClientTitleID], [Nationality], [IdentityID], [Address], [City], [CountryID], [ResidenceCountryID], [MaritalStatusID], [MobilePhone], [LandlinePhone], [WorkPhone], [Email], [ResidencyStatusID], [IsOwner], [IsTenant], [RequestedAmount], [CompanyName], [CreationDate], [RegistrationNumber], [CompanyAddress], [CompanyCity], [CompanyCountryID], [SocialCapital], [BusinessActivityID], [is_individual], [is_organisation], [RoleID], [CIN], [ResidencePermit], [PassportNumber], [OriginID], [LegalFormID], [originDetails], [Profession], [Nature_activity], [IfOrTp], [Adress_activity], [Honoraires], [Date_debut_exercice], [Fonction], [Employeur], [Date_Embauche], [Salaire], [NRC], [Date_Creation_RC], [Revenu], [Denomination], [Date_Creation_Company], [ActivityCompany], [Capital_Social], [ResultatYearN], [ChiffreAffaireYearN], [ResultatYearN_1], [ChiffreAffaireYearN_1], [PartsParticipationSociete], [Nature_Bail], [Rent], [created_at], [updated_at], [deleted_at]) VALUES (2015, NULL, N'Client-005', N'IDRISSI', N'MOHAMED AYOUB yyyy', CAST(N'1996-04-23' AS Date), 1003, NULL, 1004, N'ZERKTOUNI N 622, MHAMID, MARRAKECH, Morocco.', N'Marrakech', 1002, 1003, 1003, N'0606988480', N'0606988480', N'0606988480', N'medayoub.idrissi@gmail.com', 3, 0, 1, CAST(1000000.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, 5, NULL, NULL, N'RRRRRR', 3, NULL, N'YTDUGFJV /HKLHN', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Client] ([ClientID], [VIP], [Matricule], [LastName], [FirstName], [BirthDate], [ClientTitleID], [Nationality], [IdentityID], [Address], [City], [CountryID], [ResidenceCountryID], [MaritalStatusID], [MobilePhone], [LandlinePhone], [WorkPhone], [Email], [ResidencyStatusID], [IsOwner], [IsTenant], [RequestedAmount], [CompanyName], [CreationDate], [RegistrationNumber], [CompanyAddress], [CompanyCity], [CompanyCountryID], [SocialCapital], [BusinessActivityID], [is_individual], [is_organisation], [RoleID], [CIN], [ResidencePermit], [PassportNumber], [OriginID], [LegalFormID], [originDetails], [Profession], [Nature_activity], [IfOrTp], [Adress_activity], [Honoraires], [Date_debut_exercice], [Fonction], [Employeur], [Date_Embauche], [Salaire], [NRC], [Date_Creation_RC], [Revenu], [Denomination], [Date_Creation_Company], [ActivityCompany], [Capital_Social], [ResultatYearN], [ChiffreAffaireYearN], [ResultatYearN_1], [ChiffreAffaireYearN_1], [PartsParticipationSociete], [Nature_Bail], [Rent], [created_at], [updated_at], [deleted_at]) VALUES (3002, NULL, N'Client-006', N'Test 1', N'Test 2', CAST(N'2025-05-16' AS Date), NULL, N'Marocain', NULL, N'ZERKTOUNI N 622, MHAMID, MARRAKECH, Morocco.', N'Marrakech', NULL, NULL, NULL, N'0606988480', N'0606988480', N'0606988480', N'test@ht.com', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, 5, N'TT565656', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Client] ([ClientID], [VIP], [Matricule], [LastName], [FirstName], [BirthDate], [ClientTitleID], [Nationality], [IdentityID], [Address], [City], [CountryID], [ResidenceCountryID], [MaritalStatusID], [MobilePhone], [LandlinePhone], [WorkPhone], [Email], [ResidencyStatusID], [IsOwner], [IsTenant], [RequestedAmount], [CompanyName], [CreationDate], [RegistrationNumber], [CompanyAddress], [CompanyCity], [CompanyCountryID], [SocialCapital], [BusinessActivityID], [is_individual], [is_organisation], [RoleID], [CIN], [ResidencePermit], [PassportNumber], [OriginID], [LegalFormID], [originDetails], [Profession], [Nature_activity], [IfOrTp], [Adress_activity], [Honoraires], [Date_debut_exercice], [Fonction], [Employeur], [Date_Embauche], [Salaire], [NRC], [Date_Creation_RC], [Revenu], [Denomination], [Date_Creation_Company], [ActivityCompany], [Capital_Social], [ResultatYearN], [ChiffreAffaireYearN], [ResultatYearN_1], [ChiffreAffaireYearN_1], [PartsParticipationSociete], [Nature_Bail], [Rent], [created_at], [updated_at], [deleted_at]) VALUES (3003, NULL, N'Client-007', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(20000.00 AS Decimal(18, 2)), N'testtt', CAST(N'2025-05-11' AS Date), N'khkhlk', N'rzgfver', N'fezfe', 1003, CAST(4554.00 AS Decimal(18, 2)), 4, 0, 1, 3, NULL, NULL, NULL, NULL, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Client] ([ClientID], [VIP], [Matricule], [LastName], [FirstName], [BirthDate], [ClientTitleID], [Nationality], [IdentityID], [Address], [City], [CountryID], [ResidenceCountryID], [MaritalStatusID], [MobilePhone], [LandlinePhone], [WorkPhone], [Email], [ResidencyStatusID], [IsOwner], [IsTenant], [RequestedAmount], [CompanyName], [CreationDate], [RegistrationNumber], [CompanyAddress], [CompanyCity], [CompanyCountryID], [SocialCapital], [BusinessActivityID], [is_individual], [is_organisation], [RoleID], [CIN], [ResidencePermit], [PassportNumber], [OriginID], [LegalFormID], [originDetails], [Profession], [Nature_activity], [IfOrTp], [Adress_activity], [Honoraires], [Date_debut_exercice], [Fonction], [Employeur], [Date_Embauche], [Salaire], [NRC], [Date_Creation_RC], [Revenu], [Denomination], [Date_Creation_Company], [ActivityCompany], [Capital_Social], [ResultatYearN], [ChiffreAffaireYearN], [ResultatYearN_1], [ChiffreAffaireYearN_1], [PartsParticipationSociete], [Nature_Bail], [Rent], [created_at], [updated_at], [deleted_at]) VALUES (4004, NULL, N'Client-008', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'QQQ', CAST(N'2025-05-17' AS Date), N'45454545', N'lnkldkakn', N'Casablanca', 1002, CAST(200000.00 AS Decimal(18, 2)), 1002, 0, 1, 2, NULL, NULL, NULL, NULL, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2025-05-13T21:54:51.4733333' AS DateTime2), NULL, NULL)
INSERT [dbo].[Client] ([ClientID], [VIP], [Matricule], [LastName], [FirstName], [BirthDate], [ClientTitleID], [Nationality], [IdentityID], [Address], [City], [CountryID], [ResidenceCountryID], [MaritalStatusID], [MobilePhone], [LandlinePhone], [WorkPhone], [Email], [ResidencyStatusID], [IsOwner], [IsTenant], [RequestedAmount], [CompanyName], [CreationDate], [RegistrationNumber], [CompanyAddress], [CompanyCity], [CompanyCountryID], [SocialCapital], [BusinessActivityID], [is_individual], [is_organisation], [RoleID], [CIN], [ResidencePermit], [PassportNumber], [OriginID], [LegalFormID], [originDetails], [Profession], [Nature_activity], [IfOrTp], [Adress_activity], [Honoraires], [Date_debut_exercice], [Fonction], [Employeur], [Date_Embauche], [Salaire], [NRC], [Date_Creation_RC], [Revenu], [Denomination], [Date_Creation_Company], [ActivityCompany], [Capital_Social], [ResultatYearN], [ChiffreAffaireYearN], [ResultatYearN_1], [ChiffreAffaireYearN_1], [PartsParticipationSociete], [Nature_Bail], [Rent], [created_at], [updated_at], [deleted_at]) VALUES (4005, NULL, N'Client-009', N'Othman', N'othman', CAST(N'1981-05-14' AS Date), NULL, N'Marocain', NULL, N'ZERKTOUNI N 622, MHAMID, MARRAKECH, Morocco.', N'Marrakech', NULL, NULL, NULL, N'0606988480', N'0606988480', N'0606988480', N'othman@cre.com', 3, 0, 1, CAST(20000.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, 1, N'EE4444', NULL, NULL, 1, NULL, N';,KJLSCNLKQS', 1, NULL, NULL, NULL, NULL, NULL, N'TTEAIEFHJ', N'JBBSJFNVS', CAST(N'2025-05-07T23:00:00.000' AS DateTime), CAST(12000.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2025-05-14T18:49:45.7566667' AS DateTime2), NULL, NULL)
INSERT [dbo].[Client] ([ClientID], [VIP], [Matricule], [LastName], [FirstName], [BirthDate], [ClientTitleID], [Nationality], [IdentityID], [Address], [City], [CountryID], [ResidenceCountryID], [MaritalStatusID], [MobilePhone], [LandlinePhone], [WorkPhone], [Email], [ResidencyStatusID], [IsOwner], [IsTenant], [RequestedAmount], [CompanyName], [CreationDate], [RegistrationNumber], [CompanyAddress], [CompanyCity], [CompanyCountryID], [SocialCapital], [BusinessActivityID], [is_individual], [is_organisation], [RoleID], [CIN], [ResidencePermit], [PassportNumber], [OriginID], [LegalFormID], [originDetails], [Profession], [Nature_activity], [IfOrTp], [Adress_activity], [Honoraires], [Date_debut_exercice], [Fonction], [Employeur], [Date_Embauche], [Salaire], [NRC], [Date_Creation_RC], [Revenu], [Denomination], [Date_Creation_Company], [ActivityCompany], [Capital_Social], [ResultatYearN], [ChiffreAffaireYearN], [ResultatYearN_1], [ChiffreAffaireYearN_1], [PartsParticipationSociete], [Nature_Bail], [Rent], [created_at], [updated_at], [deleted_at]) VALUES (5004, NULL, N'Client-010', N'Saad', N'saad', CAST(N'1993-06-14' AS Date), NULL, N'Marocain', NULL, N'ZERKTOUNI N 622, MHAMID, MARRAKECH, Morocco.', N'Casa', 1002, 1003, 1003, N'0606988480', N'0606988480', N'0606988480', N'saad@gmail.com', 3, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, 1, N'FF453423', NULL, NULL, NULL, NULL, NULL, 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2025-06-14T09:45:16.3966667' AS DateTime2), NULL, NULL)
INSERT [dbo].[Client] ([ClientID], [VIP], [Matricule], [LastName], [FirstName], [BirthDate], [ClientTitleID], [Nationality], [IdentityID], [Address], [City], [CountryID], [ResidenceCountryID], [MaritalStatusID], [MobilePhone], [LandlinePhone], [WorkPhone], [Email], [ResidencyStatusID], [IsOwner], [IsTenant], [RequestedAmount], [CompanyName], [CreationDate], [RegistrationNumber], [CompanyAddress], [CompanyCity], [CompanyCountryID], [SocialCapital], [BusinessActivityID], [is_individual], [is_organisation], [RoleID], [CIN], [ResidencePermit], [PassportNumber], [OriginID], [LegalFormID], [originDetails], [Profession], [Nature_activity], [IfOrTp], [Adress_activity], [Honoraires], [Date_debut_exercice], [Fonction], [Employeur], [Date_Embauche], [Salaire], [NRC], [Date_Creation_RC], [Revenu], [Denomination], [Date_Creation_Company], [ActivityCompany], [Capital_Social], [ResultatYearN], [ChiffreAffaireYearN], [ResultatYearN_1], [ChiffreAffaireYearN_1], [PartsParticipationSociete], [Nature_Bail], [Rent], [created_at], [updated_at], [deleted_at]) VALUES (5005, NULL, N'Client-011', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Coton', CAST(N'2025-06-12' AS Date), N'3434343434', N'FJNFGNH', N'Casablanca', 1002, CAST(4554.00 AS Decimal(18, 2)), 2, 0, 1, 1, NULL, NULL, NULL, NULL, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2025-06-14T09:51:41.5800000' AS DateTime2), NULL, NULL)
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
SET IDENTITY_INSERT [dbo].[ClientManager] ON 

INSERT [dbo].[ClientManager] ([ClientManagerID], [ClientID], [ManagerID], [created_at], [updated_at], [deleted_at]) VALUES (1, 3003, 1, NULL, NULL, NULL)
INSERT [dbo].[ClientManager] ([ClientManagerID], [ClientID], [ManagerID], [created_at], [updated_at], [deleted_at]) VALUES (3, 2013, 3, CAST(N'2025-05-13T22:27:24.8766667' AS DateTime2), NULL, NULL)
INSERT [dbo].[ClientManager] ([ClientManagerID], [ClientID], [ManagerID], [created_at], [updated_at], [deleted_at]) VALUES (4, 4004, 4, CAST(N'2025-05-14T06:38:49.5166667' AS DateTime2), NULL, NULL)
INSERT [dbo].[ClientManager] ([ClientManagerID], [ClientID], [ManagerID], [created_at], [updated_at], [deleted_at]) VALUES (1002, 5005, 1002, CAST(N'2025-06-14T09:53:34.8133333' AS DateTime2), NULL, NULL)
SET IDENTITY_INSERT [dbo].[ClientManager] OFF
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
SET IDENTITY_INSERT [dbo].[ConditionProperty] ON 

INSERT [dbo].[ConditionProperty] ([ConditionPropertyID], [ConditionPropertyLabel]) VALUES (1, N'Neuf')
INSERT [dbo].[ConditionProperty] ([ConditionPropertyID], [ConditionPropertyLabel]) VALUES (2, N'Récent')
INSERT [dbo].[ConditionProperty] ([ConditionPropertyID], [ConditionPropertyLabel]) VALUES (3, N'Ancien')
SET IDENTITY_INSERT [dbo].[ConditionProperty] OFF
GO
SET IDENTITY_INSERT [dbo].[Credit] ON 

INSERT [dbo].[Credit] ([CreditID], [Matricule], [CreditTypeID], [amount]) VALUES (5, N'DOS-001', 3, CAST(50000.00 AS Decimal(18, 2)))
INSERT [dbo].[Credit] ([CreditID], [Matricule], [CreditTypeID], [amount]) VALUES (6, N'DOS-002', 4, CAST(20000.00 AS Decimal(18, 2)))
INSERT [dbo].[Credit] ([CreditID], [Matricule], [CreditTypeID], [amount]) VALUES (7, N'DOS-003', 2, CAST(12000000.00 AS Decimal(18, 2)))
INSERT [dbo].[Credit] ([CreditID], [Matricule], [CreditTypeID], [amount]) VALUES (8, N'DOS-004', 4, CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[Credit] ([CreditID], [Matricule], [CreditTypeID], [amount]) VALUES (9, N'DOS-005', 2, CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[Credit] ([CreditID], [Matricule], [CreditTypeID], [amount]) VALUES (10, N'DOS-006', 2, CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[Credit] ([CreditID], [Matricule], [CreditTypeID], [amount]) VALUES (11, N'DOS-007', 5, CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[Credit] ([CreditID], [Matricule], [CreditTypeID], [amount]) VALUES (12, N'DOS-008', 4, CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[Credit] ([CreditID], [Matricule], [CreditTypeID], [amount]) VALUES (13, N'DOS-009', 5, CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[Credit] ([CreditID], [Matricule], [CreditTypeID], [amount]) VALUES (14, N'DOS-010', 2, CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[Credit] ([CreditID], [Matricule], [CreditTypeID], [amount]) VALUES (15, N'DOS-011', 2, CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[Credit] ([CreditID], [Matricule], [CreditTypeID], [amount]) VALUES (16, N'DOS-012', 3, CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[Credit] ([CreditID], [Matricule], [CreditTypeID], [amount]) VALUES (17, N'DOS-013', 1, CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[Credit] ([CreditID], [Matricule], [CreditTypeID], [amount]) VALUES (1008, N'DOS-014', 2, CAST(0.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Credit] OFF
GO
SET IDENTITY_INSERT [dbo].[CreditDepot] ON 

INSERT [dbo].[CreditDepot] ([CreditDepotId], [id_credit], [id_agency_bank], [interlocutor], [agence], [created_at], [created_by], [updated_at], [updated_by], [deleted_at], [deleted_by], [date_sent]) VALUES (5, 6, 4, N'oioioi', N'ojoijo', CAST(N'2025-05-11T22:37:31.053' AS DateTime), NULL, NULL, NULL, NULL, NULL, CAST(N'2025-05-19T00:00:00.000' AS DateTime))
INSERT [dbo].[CreditDepot] ([CreditDepotId], [id_credit], [id_agency_bank], [interlocutor], [agence], [created_at], [created_by], [updated_at], [updated_by], [deleted_at], [deleted_by], [date_sent]) VALUES (6, 7, 2, N'dszdcezed', N'dazjdlazjd', CAST(N'2025-05-13T20:35:00.343' AS DateTime), NULL, NULL, NULL, NULL, NULL, CAST(N'2025-05-13T00:00:00.000' AS DateTime))
INSERT [dbo].[CreditDepot] ([CreditDepotId], [id_credit], [id_agency_bank], [interlocutor], [agence], [created_at], [created_by], [updated_at], [updated_by], [deleted_at], [deleted_by], [date_sent]) VALUES (7, 7, 3, N'DFEZFZEF', N'ZEFEZFZE', CAST(N'2025-05-13T20:35:00.343' AS DateTime), NULL, NULL, NULL, NULL, NULL, CAST(N'2025-05-14T00:00:00.000' AS DateTime))
INSERT [dbo].[CreditDepot] ([CreditDepotId], [id_credit], [id_agency_bank], [interlocutor], [agence], [created_at], [created_by], [updated_at], [updated_by], [deleted_at], [deleted_by], [date_sent]) VALUES (8, 8, 2, N'klnakldqk', N'dnlazdkna', CAST(N'2025-05-14T05:56:36.963' AS DateTime), NULL, NULL, NULL, NULL, NULL, CAST(N'2025-05-20T00:00:00.000' AS DateTime))
INSERT [dbo].[CreditDepot] ([CreditDepotId], [id_credit], [id_agency_bank], [interlocutor], [agence], [created_at], [created_by], [updated_at], [updated_by], [deleted_at], [deleted_by], [date_sent]) VALUES (9, 17, 3, N'KHMZEFEZ', N'IHYQHDLQK/Z', CAST(N'2025-05-14T19:24:34.523' AS DateTime), NULL, NULL, NULL, NULL, NULL, CAST(N'2025-05-14T00:00:00.000' AS DateTime))
INSERT [dbo].[CreditDepot] ([CreditDepotId], [id_credit], [id_agency_bank], [interlocutor], [agence], [created_at], [created_by], [updated_at], [updated_by], [deleted_at], [deleted_by], [date_sent]) VALUES (1006, 1008, 1, N'FGSDG', N'XFGXFG', CAST(N'2025-06-14T10:43:44.503' AS DateTime), NULL, NULL, NULL, NULL, NULL, CAST(N'2025-06-18T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[CreditDepot] OFF
GO
SET IDENTITY_INSERT [dbo].[CreditStatus] ON 

INSERT [dbo].[CreditStatus] ([CreditStatusID], [id_credit], [id_depot], [message], [status], [created_at], [created_by], [updated_at], [updated_by], [deleted_at], [deleted_by], [is_accord], [is_accord_client]) VALUES (1002, 7, 7, N'aqfipqzfpazm', 5, CAST(N'2025-05-13T20:36:07.210' AS DateTime), NULL, NULL, NULL, NULL, NULL, 4, NULL)
INSERT [dbo].[CreditStatus] ([CreditStatusID], [id_credit], [id_depot], [message], [status], [created_at], [created_by], [updated_at], [updated_by], [deleted_at], [deleted_by], [is_accord], [is_accord_client]) VALUES (1003, 7, 7, N'fgiqefkql', 9, CAST(N'2025-05-13T20:36:21.683' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[CreditStatus] ([CreditStatusID], [id_credit], [id_depot], [message], [status], [created_at], [created_by], [updated_at], [updated_by], [deleted_at], [deleted_by], [is_accord], [is_accord_client]) VALUES (1004, 7, 7, N'feezfzef', 10, CAST(N'2025-05-13T20:36:32.650' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, 5)
INSERT [dbo].[CreditStatus] ([CreditStatusID], [id_credit], [id_depot], [message], [status], [created_at], [created_by], [updated_at], [updated_by], [deleted_at], [deleted_by], [is_accord], [is_accord_client]) VALUES (1005, 7, 7, NULL, 11, CAST(N'2025-05-13T20:36:41.770' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[CreditStatus] ([CreditStatusID], [id_credit], [id_depot], [message], [status], [created_at], [created_by], [updated_at], [updated_by], [deleted_at], [deleted_by], [is_accord], [is_accord_client]) VALUES (1006, 7, 7, NULL, 9, CAST(N'2025-05-13T20:38:05.587' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[CreditStatus] ([CreditStatusID], [id_credit], [id_depot], [message], [status], [created_at], [created_by], [updated_at], [updated_by], [deleted_at], [deleted_by], [is_accord], [is_accord_client]) VALUES (1007, 17, 9, N'UHJSKLDVDS§', 4, CAST(N'2025-05-14T19:27:28.480' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[CreditStatus] ([CreditStatusID], [id_credit], [id_depot], [message], [status], [created_at], [created_by], [updated_at], [updated_by], [deleted_at], [deleted_by], [is_accord], [is_accord_client]) VALUES (1008, 17, 9, NULL, 5, CAST(N'2025-05-14T19:27:39.077' AS DateTime), NULL, NULL, NULL, NULL, NULL, 4, NULL)
INSERT [dbo].[CreditStatus] ([CreditStatusID], [id_credit], [id_depot], [message], [status], [created_at], [created_by], [updated_at], [updated_by], [deleted_at], [deleted_by], [is_accord], [is_accord_client]) VALUES (1009, 17, 9, N'QSFKHCFQESD', 9, CAST(N'2025-05-14T19:27:49.943' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[CreditStatus] ([CreditStatusID], [id_credit], [id_depot], [message], [status], [created_at], [created_by], [updated_at], [updated_by], [deleted_at], [deleted_by], [is_accord], [is_accord_client]) VALUES (1010, 17, 9, N'YKHGJ', 10, CAST(N'2025-05-14T19:28:11.387' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, 4)
INSERT [dbo].[CreditStatus] ([CreditStatusID], [id_credit], [id_depot], [message], [status], [created_at], [created_by], [updated_at], [updated_by], [deleted_at], [deleted_by], [is_accord], [is_accord_client]) VALUES (1011, 17, 9, NULL, 11, CAST(N'2025-05-14T19:28:19.137' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[CreditStatus] ([CreditStatusID], [id_credit], [id_depot], [message], [status], [created_at], [created_by], [updated_at], [updated_by], [deleted_at], [deleted_by], [is_accord], [is_accord_client]) VALUES (2002, 1008, 1006, N'WDBDXB', 4, CAST(N'2025-06-14T10:51:05.360' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[CreditStatus] ([CreditStatusID], [id_credit], [id_depot], [message], [status], [created_at], [created_by], [updated_at], [updated_by], [deleted_at], [deleted_by], [is_accord], [is_accord_client]) VALUES (2003, 1008, 1006, N'SDGSDG', 10, CAST(N'2025-06-14T10:51:23.633' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, 2)
SET IDENTITY_INSERT [dbo].[CreditStatus] OFF
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
SET IDENTITY_INSERT [dbo].[GarantieCredit] ON 

INSERT [dbo].[GarantieCredit] ([GarantieCreditID], [Label], [CreditID]) VALUES (6, N'Hypothèque en 1er rang au profit de la banque sur le TF ', 5)
INSERT [dbo].[GarantieCredit] ([GarantieCreditID], [Label], [CreditID]) VALUES (1002, N'Engagement de domiciliation des transferts ', 7)
INSERT [dbo].[GarantieCredit] ([GarantieCreditID], [Label], [CreditID]) VALUES (1003, N'Engagement de domiciliation des revenus ', 7)
INSERT [dbo].[GarantieCredit] ([GarantieCreditID], [Label], [CreditID]) VALUES (1004, N'RAT crédit de okkkkk', 7)
INSERT [dbo].[GarantieCredit] ([GarantieCreditID], [Label], [CreditID]) VALUES (1005, N'Caution hypothécaire de …… au profit de la banque ', 8)
INSERT [dbo].[GarantieCredit] ([GarantieCreditID], [Label], [CreditID]) VALUES (1006, N'Hypothèque en 1er rang au profit de la banque sur le TF HFK?J', 17)
INSERT [dbo].[GarantieCredit] ([GarantieCreditID], [Label], [CreditID]) VALUES (2002, N'Hypothèque en 1er rang au profit de la banque sur le TF TFJTFJ', 1008)
INSERT [dbo].[GarantieCredit] ([GarantieCreditID], [Label], [CreditID]) VALUES (2003, N'AUTRE', 1008)
SET IDENTITY_INSERT [dbo].[GarantieCredit] OFF
GO
SET IDENTITY_INSERT [dbo].[InfosBank] ON 

INSERT [dbo].[InfosBank] ([InfoBankID], [AgencyBankID], [ClientID], [Balance], [CumulativeCreditMovement], [IsPrincipal], [AgencyName]) VALUES (6, 3, 1005, CAST(2000.00 AS Decimal(18, 2)), CAST(676767.00 AS Decimal(18, 2)), 1, N'Rondaaaaaaaz')
INSERT [dbo].[InfosBank] ([InfoBankID], [AgencyBankID], [ClientID], [Balance], [CumulativeCreditMovement], [IsPrincipal], [AgencyName]) VALUES (7, 4, 1005, CAST(1222.00 AS Decimal(18, 2)), CAST(333333333.00 AS Decimal(18, 2)), 0, N'zqrfqrz')
INSERT [dbo].[InfosBank] ([InfoBankID], [AgencyBankID], [ClientID], [Balance], [CumulativeCreditMovement], [IsPrincipal], [AgencyName]) VALUES (1002, 1, 4005, CAST(13333.00 AS Decimal(18, 2)), CAST(16666.00 AS Decimal(18, 2)), 1, N'tedtduqidhgiu')
INSERT [dbo].[InfosBank] ([InfoBankID], [AgencyBankID], [ClientID], [Balance], [CumulativeCreditMovement], [IsPrincipal], [AgencyName]) VALUES (2002, 1, 5004, CAST(12222.00 AS Decimal(18, 2)), CAST(12222.00 AS Decimal(18, 2)), 1, N'SGSD')
SET IDENTITY_INSERT [dbo].[InfosBank] OFF
GO
SET IDENTITY_INSERT [dbo].[LignCreditClient] ON 

INSERT [dbo].[LignCreditClient] ([LignCreditClientID], [ClientID], [CreditID], [IsPrincipal], [PercentageClient]) VALUES (3, 1005, 5, 1, 0)
INSERT [dbo].[LignCreditClient] ([LignCreditClientID], [ClientID], [CreditID], [IsPrincipal], [PercentageClient]) VALUES (4, 2, 6, 1, 0)
INSERT [dbo].[LignCreditClient] ([LignCreditClientID], [ClientID], [CreditID], [IsPrincipal], [PercentageClient]) VALUES (5, 1, 7, 1, 70)
INSERT [dbo].[LignCreditClient] ([LignCreditClientID], [ClientID], [CreditID], [IsPrincipal], [PercentageClient]) VALUES (6, 1002, 7, 0, 30)
INSERT [dbo].[LignCreditClient] ([LignCreditClientID], [ClientID], [CreditID], [IsPrincipal], [PercentageClient]) VALUES (1003, 2013, 8, 0, 0)
INSERT [dbo].[LignCreditClient] ([LignCreditClientID], [ClientID], [CreditID], [IsPrincipal], [PercentageClient]) VALUES (1004, 1, 8, 1, 100)
INSERT [dbo].[LignCreditClient] ([LignCreditClientID], [ClientID], [CreditID], [IsPrincipal], [PercentageClient]) VALUES (1005, 1002, 8, 0, 0)
INSERT [dbo].[LignCreditClient] ([LignCreditClientID], [ClientID], [CreditID], [IsPrincipal], [PercentageClient]) VALUES (1006, 1002, 9, 0, 0)
INSERT [dbo].[LignCreditClient] ([LignCreditClientID], [ClientID], [CreditID], [IsPrincipal], [PercentageClient]) VALUES (1007, 2013, 9, 0, 0)
INSERT [dbo].[LignCreditClient] ([LignCreditClientID], [ClientID], [CreditID], [IsPrincipal], [PercentageClient]) VALUES (1008, 1002, 10, 0, 0)
INSERT [dbo].[LignCreditClient] ([LignCreditClientID], [ClientID], [CreditID], [IsPrincipal], [PercentageClient]) VALUES (1009, 2013, 11, 0, 0)
INSERT [dbo].[LignCreditClient] ([LignCreditClientID], [ClientID], [CreditID], [IsPrincipal], [PercentageClient]) VALUES (1010, 2013, 12, 0, 0)
INSERT [dbo].[LignCreditClient] ([LignCreditClientID], [ClientID], [CreditID], [IsPrincipal], [PercentageClient]) VALUES (1011, 2013, 13, 0, 0)
INSERT [dbo].[LignCreditClient] ([LignCreditClientID], [ClientID], [CreditID], [IsPrincipal], [PercentageClient]) VALUES (1012, 4004, 14, 0, 0)
INSERT [dbo].[LignCreditClient] ([LignCreditClientID], [ClientID], [CreditID], [IsPrincipal], [PercentageClient]) VALUES (1013, 4004, 15, 0, 0)
INSERT [dbo].[LignCreditClient] ([LignCreditClientID], [ClientID], [CreditID], [IsPrincipal], [PercentageClient]) VALUES (1014, 4004, 16, 0, 0)
INSERT [dbo].[LignCreditClient] ([LignCreditClientID], [ClientID], [CreditID], [IsPrincipal], [PercentageClient]) VALUES (1015, 4005, 17, 1, 100)
INSERT [dbo].[LignCreditClient] ([LignCreditClientID], [ClientID], [CreditID], [IsPrincipal], [PercentageClient]) VALUES (2003, 5004, 1008, 1, 100)
SET IDENTITY_INSERT [dbo].[LignCreditClient] OFF
GO
SET IDENTITY_INSERT [dbo].[LignCreditProperty] ON 

INSERT [dbo].[LignCreditProperty] ([LignCreditPropertyID], [CreditID], [ObjectCreditID], [PropertyID], [IsPrincipal], [IsObjectCredit], [IsAdditional], [IsSubstitution], [MontantCredit], [DureeCredit], [FrequenceRemboursement], [DureeFranchise], [TauxCredit], [DerogationSouhaite], [AssuranceDeczsInvalidite], [CommentCredit], [honorairesFactures], [DerogationSouhaiteeText]) VALUES (1, 5, 4, NULL, NULL, NULL, NULL, NULL, CAST(1000.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), 4, CAST(222.00 AS Decimal(18, 2)), CAST(122.0000 AS Decimal(18, 4)), 1, 2, N'tetttttttttttttt <sup><u><b>yyyyyy</b></u></sup>', CAST(7777.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[LignCreditProperty] ([LignCreditPropertyID], [CreditID], [ObjectCreditID], [PropertyID], [IsPrincipal], [IsObjectCredit], [IsAdditional], [IsSubstitution], [MontantCredit], [DureeCredit], [FrequenceRemboursement], [DureeFranchise], [TauxCredit], [DerogationSouhaite], [AssuranceDeczsInvalidite], [CommentCredit], [honorairesFactures], [DerogationSouhaiteeText]) VALUES (2, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(12.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[LignCreditProperty] ([LignCreditPropertyID], [CreditID], [ObjectCreditID], [PropertyID], [IsPrincipal], [IsObjectCredit], [IsAdditional], [IsSubstitution], [MontantCredit], [DureeCredit], [FrequenceRemboursement], [DureeFranchise], [TauxCredit], [DerogationSouhaite], [AssuranceDeczsInvalidite], [CommentCredit], [honorairesFactures], [DerogationSouhaiteeText]) VALUES (1002, 7, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LignCreditProperty] ([LignCreditPropertyID], [CreditID], [ObjectCreditID], [PropertyID], [IsPrincipal], [IsObjectCredit], [IsAdditional], [IsSubstitution], [MontantCredit], [DureeCredit], [FrequenceRemboursement], [DureeFranchise], [TauxCredit], [DerogationSouhaite], [AssuranceDeczsInvalidite], [CommentCredit], [honorairesFactures], [DerogationSouhaiteeText]) VALUES (1003, 8, 2, NULL, NULL, NULL, NULL, NULL, CAST(120000.00 AS Decimal(18, 2)), CAST(33.00 AS Decimal(18, 2)), 2, CAST(12.00 AS Decimal(18, 2)), CAST(4.0000 AS Decimal(18, 4)), 1, 1, N'NEFLKENF', CAST(20000.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[LignCreditProperty] ([LignCreditPropertyID], [CreditID], [ObjectCreditID], [PropertyID], [IsPrincipal], [IsObjectCredit], [IsAdditional], [IsSubstitution], [MontantCredit], [DureeCredit], [FrequenceRemboursement], [DureeFranchise], [TauxCredit], [DerogationSouhaite], [AssuranceDeczsInvalidite], [CommentCredit], [honorairesFactures], [DerogationSouhaiteeText]) VALUES (1004, 17, 2, NULL, NULL, NULL, NULL, NULL, CAST(13333.00 AS Decimal(18, 2)), CAST(12.00 AS Decimal(18, 2)), 1, CAST(122.00 AS Decimal(18, 2)), CAST(5.0000 AS Decimal(18, 4)), 1, 1, N'<h2>TESTTTT</h2>', CAST(100.00 AS Decimal(18, 2)), N'test')
INSERT [dbo].[LignCreditProperty] ([LignCreditPropertyID], [CreditID], [ObjectCreditID], [PropertyID], [IsPrincipal], [IsObjectCredit], [IsAdditional], [IsSubstitution], [MontantCredit], [DureeCredit], [FrequenceRemboursement], [DureeFranchise], [TauxCredit], [DerogationSouhaite], [AssuranceDeczsInvalidite], [CommentCredit], [honorairesFactures], [DerogationSouhaiteeText]) VALUES (2002, 1008, 1, NULL, NULL, NULL, NULL, NULL, CAST(10000.00 AS Decimal(18, 2)), CAST(12.00 AS Decimal(18, 2)), 2, CAST(12.00 AS Decimal(18, 2)), CAST(2.0000 AS Decimal(18, 4)), 0, 1, NULL, CAST(10000.00 AS Decimal(18, 2)), NULL)
SET IDENTITY_INSERT [dbo].[LignCreditProperty] OFF
GO
SET IDENTITY_INSERT [dbo].[ManagerInformation] ON 

INSERT [dbo].[ManagerInformation] ([ManagerID], [ManagerTitleID], [ManagerLastName], [ManagerFirstName], [ManagerBirthDate], [ManagerNationality], [Id_Identity], [ManagerAddress], [ManagerCity], [ManagerCountryID], [ManagerResidenceCountryID], [Id_ManagerMaritalStatus], [CIN], [CarteSejour], [Passeport], [created_at], [updated_at], [deleted_at]) VALUES (1, 1003, N'efklnleznf', N'ljenfleznf', CAST(N'2025-05-15' AS Date), N'enfled', NULL, N'lezjflezn', N'ijfezilf', 1003, 1003, 1003, N'', N'', N'', NULL, NULL, NULL)
INSERT [dbo].[ManagerInformation] ([ManagerID], [ManagerTitleID], [ManagerLastName], [ManagerFirstName], [ManagerBirthDate], [ManagerNationality], [Id_Identity], [ManagerAddress], [ManagerCity], [ManagerCountryID], [ManagerResidenceCountryID], [Id_ManagerMaritalStatus], [CIN], [CarteSejour], [Passeport], [created_at], [updated_at], [deleted_at]) VALUES (2, 1002, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'EEDD445', NULL, NULL, CAST(N'2025-05-13T22:25:32.0233333' AS DateTime2), NULL, NULL)
INSERT [dbo].[ManagerInformation] ([ManagerID], [ManagerTitleID], [ManagerLastName], [ManagerFirstName], [ManagerBirthDate], [ManagerNationality], [Id_Identity], [ManagerAddress], [ManagerCity], [ManagerCountryID], [ManagerResidenceCountryID], [Id_ManagerMaritalStatus], [CIN], [CarteSejour], [Passeport], [created_at], [updated_at], [deleted_at]) VALUES (3, 1002, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'SDSSQ', NULL, NULL, CAST(N'2025-05-13T22:27:24.8633333' AS DateTime2), NULL, NULL)
INSERT [dbo].[ManagerInformation] ([ManagerID], [ManagerTitleID], [ManagerLastName], [ManagerFirstName], [ManagerBirthDate], [ManagerNationality], [Id_Identity], [ManagerAddress], [ManagerCity], [ManagerCountryID], [ManagerResidenceCountryID], [Id_ManagerMaritalStatus], [CIN], [CarteSejour], [Passeport], [created_at], [updated_at], [deleted_at]) VALUES (4, 1004, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'EE565656', NULL, NULL, CAST(N'2025-05-14T06:38:49.4666667' AS DateTime2), NULL, NULL)
INSERT [dbo].[ManagerInformation] ([ManagerID], [ManagerTitleID], [ManagerLastName], [ManagerFirstName], [ManagerBirthDate], [ManagerNationality], [Id_Identity], [ManagerAddress], [ManagerCity], [ManagerCountryID], [ManagerResidenceCountryID], [Id_ManagerMaritalStatus], [CIN], [CarteSejour], [Passeport], [created_at], [updated_at], [deleted_at]) VALUES (1002, 1003, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'EE565656', NULL, NULL, CAST(N'2025-06-14T09:53:34.7300000' AS DateTime2), NULL, NULL)
SET IDENTITY_INSERT [dbo].[ManagerInformation] OFF
GO
SET IDENTITY_INSERT [dbo].[MaritalStatus] ON 

INSERT [dbo].[MaritalStatus] ([MaritalStatusID], [MaritalStatusLabel]) VALUES (1002, N'Célibataire')
INSERT [dbo].[MaritalStatus] ([MaritalStatusID], [MaritalStatusLabel]) VALUES (1003, N'Marié(e)')
INSERT [dbo].[MaritalStatus] ([MaritalStatusID], [MaritalStatusLabel]) VALUES (1004, N'Veuf(e)')
INSERT [dbo].[MaritalStatus] ([MaritalStatusID], [MaritalStatusLabel]) VALUES (2002, N'Divorcé(e)')
SET IDENTITY_INSERT [dbo].[MaritalStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[NatureProperty] ON 

INSERT [dbo].[NatureProperty] ([NaturePropertyID], [NaturePropertyLabel]) VALUES (1, N'Appartement')
INSERT [dbo].[NatureProperty] ([NaturePropertyID], [NaturePropertyLabel]) VALUES (2, N'Terrain')
INSERT [dbo].[NatureProperty] ([NaturePropertyID], [NaturePropertyLabel]) VALUES (3, N'Villa')
INSERT [dbo].[NatureProperty] ([NaturePropertyID], [NaturePropertyLabel]) VALUES (4, N'Maison Individuelle')
INSERT [dbo].[NatureProperty] ([NaturePropertyID], [NaturePropertyLabel]) VALUES (5, N'Duplex')
INSERT [dbo].[NatureProperty] ([NaturePropertyID], [NaturePropertyLabel]) VALUES (6, N'Studio')
INSERT [dbo].[NatureProperty] ([NaturePropertyID], [NaturePropertyLabel]) VALUES (7, N'Plateau Bureau')
INSERT [dbo].[NatureProperty] ([NaturePropertyID], [NaturePropertyLabel]) VALUES (8, N'Magasin')
INSERT [dbo].[NatureProperty] ([NaturePropertyID], [NaturePropertyLabel]) VALUES (9, N'Dépôt')
INSERT [dbo].[NatureProperty] ([NaturePropertyID], [NaturePropertyLabel]) VALUES (10, N'Pavillon')
SET IDENTITY_INSERT [dbo].[NatureProperty] OFF
GO
SET IDENTITY_INSERT [dbo].[ObjectCredit] ON 

INSERT [dbo].[ObjectCredit] ([ObjectCreditID], [ObjectCreditLabel]) VALUES (1, N'Acquisition')
INSERT [dbo].[ObjectCredit] ([ObjectCreditID], [ObjectCreditLabel]) VALUES (2, N'Acquisition + Construction')
INSERT [dbo].[ObjectCredit] ([ObjectCreditID], [ObjectCreditLabel]) VALUES (3, N'Acquisition + Aménagement')
INSERT [dbo].[ObjectCredit] ([ObjectCreditID], [ObjectCreditLabel]) VALUES (4, N'Acquisition de part')
INSERT [dbo].[ObjectCredit] ([ObjectCreditID], [ObjectCreditLabel]) VALUES (5, N'Acquisition de part + Travaux de Construction')
INSERT [dbo].[ObjectCredit] ([ObjectCreditID], [ObjectCreditLabel]) VALUES (6, N'Acquisition de part + Travaux d’Aménagement')
INSERT [dbo].[ObjectCredit] ([ObjectCreditID], [ObjectCreditLabel]) VALUES (7, N'Acquisition de part + Rachat de Crédit')
INSERT [dbo].[ObjectCredit] ([ObjectCreditID], [ObjectCreditLabel]) VALUES (8, N'Travaux de Construction')
INSERT [dbo].[ObjectCredit] ([ObjectCreditID], [ObjectCreditLabel]) VALUES (9, N'Travaux d’Aménagement')
INSERT [dbo].[ObjectCredit] ([ObjectCreditID], [ObjectCreditLabel]) VALUES (10, N'Travaux de Finition')
INSERT [dbo].[ObjectCredit] ([ObjectCreditID], [ObjectCreditLabel]) VALUES (11, N'Rachat de Crédit')
INSERT [dbo].[ObjectCredit] ([ObjectCreditID], [ObjectCreditLabel]) VALUES (12, N'Rachat + Travaux d’Aménagement')
INSERT [dbo].[ObjectCredit] ([ObjectCreditID], [ObjectCreditLabel]) VALUES (13, N'Rachat + Travaux de Construction')
INSERT [dbo].[ObjectCredit] ([ObjectCreditID], [ObjectCreditLabel]) VALUES (14, N'Crédit in-fine')
INSERT [dbo].[ObjectCredit] ([ObjectCreditID], [ObjectCreditLabel]) VALUES (15, N'VEFA')
INSERT [dbo].[ObjectCredit] ([ObjectCreditID], [ObjectCreditLabel]) VALUES (16, N'Relais')
SET IDENTITY_INSERT [dbo].[ObjectCredit] OFF
GO
SET IDENTITY_INSERT [dbo].[Pensionnaire] ON 

INSERT [dbo].[Pensionnaire] ([id], [NaturePension], [OrganismePension], [TypePension], [Montant], [ClientID]) VALUES (6, N'SHSEGS', 2, 2, CAST(1000.00 AS Decimal(18, 2)), 1005)
INSERT [dbo].[Pensionnaire] ([id], [NaturePension], [OrganismePension], [TypePension], [Montant], [ClientID]) VALUES (2003, N'DHDFH', 6, 1, CAST(10000.00 AS Decimal(18, 2)), 5004)
SET IDENTITY_INSERT [dbo].[Pensionnaire] OFF
GO
SET IDENTITY_INSERT [dbo].[Property] ON 

INSERT [dbo].[Property] ([PropertyID], [Adress], [PropertyArea], [LandTitle], [SalePriceProperty], [RealValueProperty], [AmountWork], [EstimatedValue], [NaturePropertyID], [AssignmentPropertyID], [UsePropertyID], [ConditionPropertyID], [CreditID]) VALUES (18, N'kufcvjv kjgkjbk', NULL, N'UTRUFFGJK', CAST(12.00 AS Decimal(18, 2)), CAST(12.00 AS Decimal(18, 2)), CAST(122222.00 AS Decimal(18, 2)), NULL, 4, 1, 4, 3, 5)
INSERT [dbo].[Property] ([PropertyID], [Adress], [PropertyArea], [LandTitle], [SalePriceProperty], [RealValueProperty], [AmountWork], [EstimatedValue], [NaturePropertyID], [AssignmentPropertyID], [UsePropertyID], [ConditionPropertyID], [CreditID]) VALUES (2002, N'Adress', NULL, N'title', CAST(122222.00 AS Decimal(18, 2)), CAST(1222.00 AS Decimal(18, 2)), CAST(12222.00 AS Decimal(18, 2)), NULL, 2, 2, 2, 1, 7)
INSERT [dbo].[Property] ([PropertyID], [Adress], [PropertyArea], [LandTitle], [SalePriceProperty], [RealValueProperty], [AmountWork], [EstimatedValue], [NaturePropertyID], [AssignmentPropertyID], [UsePropertyID], [ConditionPropertyID], [CreditID]) VALUES (2003, N'KF', NULL, N'DTJGHG', CAST(12222.00 AS Decimal(18, 2)), CAST(12222.00 AS Decimal(18, 2)), CAST(12222222.00 AS Decimal(18, 2)), NULL, 2, 1, 2, 2, 17)
INSERT [dbo].[Property] ([PropertyID], [Adress], [PropertyArea], [LandTitle], [SalePriceProperty], [RealValueProperty], [AmountWork], [EstimatedValue], [NaturePropertyID], [AssignmentPropertyID], [UsePropertyID], [ConditionPropertyID], [CreditID]) VALUES (4002, N'SGSDG', NULL, N'SDFSD', CAST(1222.00 AS Decimal(18, 2)), CAST(1222.00 AS Decimal(18, 2)), CAST(122222.00 AS Decimal(18, 2)), NULL, 1, 1, 1, 1, 1008)
SET IDENTITY_INSERT [dbo].[Property] OFF
GO
SET IDENTITY_INSERT [dbo].[ResidencyStatus] ON 

INSERT [dbo].[ResidencyStatus] ([ResidencyStatusID], [ResidencyStatusLabel]) VALUES (2, N'Résident ')
INSERT [dbo].[ResidencyStatus] ([ResidencyStatusID], [ResidencyStatusLabel]) VALUES (3, N'MRE ')
INSERT [dbo].[ResidencyStatus] ([ResidencyStatusID], [ResidencyStatusLabel]) VALUES (4, N'ENR ')
SET IDENTITY_INSERT [dbo].[ResidencyStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[UseProperty] ON 

INSERT [dbo].[UseProperty] ([UsePropertyID], [UsePropertyLabel]) VALUES (1, N'Résidence principale')
INSERT [dbo].[UseProperty] ([UsePropertyID], [UsePropertyLabel]) VALUES (2, N'Résidence secondaire')
INSERT [dbo].[UseProperty] ([UsePropertyID], [UsePropertyLabel]) VALUES (3, N'Commercial')
INSERT [dbo].[UseProperty] ([UsePropertyID], [UsePropertyLabel]) VALUES (4, N'Professionnel')
SET IDENTITY_INSERT [dbo].[UseProperty] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Client__0FB9FB43D87CB9C6]    Script Date: 25/06/2025 00:49:15 ******/
ALTER TABLE [dbo].[Client] ADD UNIQUE NONCLUSTERED 
(
	[Matricule] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__user_bo__AB6E6164EC691FE3]    Script Date: 25/06/2025 00:49:15 ******/
ALTER TABLE [dbo].[user_bo] ADD UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Client] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[ClientManager] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[Credit] ADD  DEFAULT ((0)) FOR [amount]
GO
ALTER TABLE [dbo].[ManagerInformation] ADD  DEFAULT (getdate()) FOR [created_at]
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
ALTER TABLE [dbo].[BankCommitmentsCharges]  WITH CHECK ADD  CONSTRAINT [FK_BankCommitmentsCharges_CreditType] FOREIGN KEY([NatureCommitmentID])
REFERENCES [dbo].[CreditType] ([TypeID])
GO
ALTER TABLE [dbo].[BankCommitmentsCharges] CHECK CONSTRAINT [FK_BankCommitmentsCharges_CreditType]
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
ALTER TABLE [dbo].[DepotStatus]  WITH CHECK ADD  CONSTRAINT [FK_DepotStatus_Credit] FOREIGN KEY([CreditID])
REFERENCES [dbo].[Credit] ([CreditID])
GO
ALTER TABLE [dbo].[DepotStatus] CHECK CONSTRAINT [FK_DepotStatus_Credit]
GO
ALTER TABLE [dbo].[DepotStatus]  WITH CHECK ADD  CONSTRAINT [FK_DepotStatus_CreditDepot] FOREIGN KEY([CreditDepotID])
REFERENCES [dbo].[CreditDepot] ([CreditDepotId])
GO
ALTER TABLE [dbo].[DepotStatus] CHECK CONSTRAINT [FK_DepotStatus_CreditDepot]
GO
ALTER TABLE [dbo].[GarantieCredit]  WITH CHECK ADD  CONSTRAINT [FK_GarantieCredit_Credit] FOREIGN KEY([CreditID])
REFERENCES [dbo].[Credit] ([CreditID])
GO
ALTER TABLE [dbo].[GarantieCredit] CHECK CONSTRAINT [FK_GarantieCredit_Credit]
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
ALTER TABLE [dbo].[Pensionnaire]  WITH CHECK ADD FOREIGN KEY([ClientID])
REFERENCES [dbo].[Client] ([ClientID])
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
ALTER TABLE [dbo].[Property]  WITH CHECK ADD  CONSTRAINT [FK_Property_Credit] FOREIGN KEY([CreditID])
REFERENCES [dbo].[Credit] ([CreditID])
GO
ALTER TABLE [dbo].[Property] CHECK CONSTRAINT [FK_Property_Credit]
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
ALTER TABLE [dbo].[user_bo_role_bo]  WITH CHECK ADD  CONSTRAINT [FK_role] FOREIGN KEY([role_id])
REFERENCES [dbo].[role_bo] ([id])
GO
ALTER TABLE [dbo].[user_bo_role_bo] CHECK CONSTRAINT [FK_role]
GO
ALTER TABLE [dbo].[user_bo_role_bo]  WITH CHECK ADD  CONSTRAINT [FK_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[user_bo] ([id])
GO
ALTER TABLE [dbo].[user_bo_role_bo] CHECK CONSTRAINT [FK_user]
GO
