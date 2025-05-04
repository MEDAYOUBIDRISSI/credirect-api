-- Table for InfoProfessional
CREATE TABLE InfoProfessional (
    InfoProfessionalID INT IDENTITY(1,1) PRIMARY KEY,
    ClientID INT, -- Foreign key to Client
	IsSalarie BIT NULL,
	-- Salarie Information
	Position NVARCHAR(255) NULL,
	Employer NVARCHAR(255) NULL,
	HiringDate DATE NULL,
	Salary decimal(18,2) NULL,
	-- Commerçant Personne Physique Information
    IsCommercant BIT NULL,
    TradeName NVARCHAR(255) NULL,
    CreationDate DATE NULL,
    BusinessAddressCommercant NVARCHAR(500) NULL, -- Address + City + Country
    -- Profession Libérale Information
    IsProfessionLiberale BIT NULL,
    ActivityName NVARCHAR(255) NULL,
    TaxID NVARCHAR(100) NULL,
    OfficeAddress NVARCHAR(500) NULL, -- Address + City + Country
    -- Gérant de Société Information
    IsGerantSociete BIT NULL,
    CompanyName NVARCHAR(255) NULL,
    CompanyCreationDate DATE NULL,
    BusinessAddressGerantSociete NVARCHAR(500) NULL, -- Address + City + Country
    LastYearRevenue DECIMAL(18, 2) NULL,
    SecondLastYearRevenue DECIMAL(18, 2) NULL,
    -- Retraité ou Pensionnaire Information
    IsRetraite BIT NULL,
    PensionAmount DECIMAL(18, 2) NULL,
    RetireeType NVARCHAR(255) NULL, -- Example: CNSS, Retraite Militaire, etc.
    -- Common Attributes
    PropertyNature NVARCHAR(255) NULL, -- Plateau bureau, Villa, etc.
    PropertyLocation NVARCHAR(500) NULL, -- Address
    PropertyValue DECIMAL(18, 2) NULL,
	-- Foreign Key Constraints
	CONSTRAINT FK_InfoProfessional_Client FOREIGN KEY (ClientID) REFERENCES Client(ClientID)
);

-- Table for AgencyBank
CREATE TABLE AgencyBank (
    AgencyBankID INT IDENTITY(1,1) PRIMARY KEY,
    AgencyBankLabel NVARCHAR(255) NULL
);

-- Table for InfosBank
CREATE TABLE InfosBank (
    InfoBankID INT IDENTITY(1,1) PRIMARY KEY,
	AgencyBankID INT, -- Foreign key to AgencyBank
	ClientID INT, -- Foreign key to Client
	Balance decimal(18,2) NULL,
	CumulativeCreditMovement decimal(18,2) NULL,
	IsPrincipal BIT NULL,
	-- Foreign Key Constraints
    CONSTRAINT FK_InfosBank_AgencyBank FOREIGN KEY (AgencyBankID) REFERENCES AgencyBank(AgencyBankID),
	CONSTRAINT FK_InfosBank_Client FOREIGN KEY (ClientID) REFERENCES Client(ClientID)
);

-- Table for NatureCommitment
CREATE TABLE NatureCommitment (
    NatureCommitmentID INT IDENTITY(1,1) PRIMARY KEY,
    NatureCommitmentLabel NVARCHAR(255) NULL

);
-- Table for BankCommitmentsCharges
CREATE TABLE BankCommitmentsCharges (
    BankCommitmentChargeID INT IDENTITY(1,1) PRIMARY KEY,
    NatureCommitmentID INT, -- Foreign key to AgencyBank
	AgencyBankID INT NULL, -- Foreign key to AgencyBank
	OtherAgency NVARCHAR(255) NULL,
	ClientID INT, -- Foreign key to Client
	Maturity decimal(18,2) NULL, --Echéance 
	Outstanding BIT NULL, --Encours 
	RepayableEarly BIT NULL, --Remboursable par anticipation OUI/NON
	-- Foreign Key Constraints
    CONSTRAINT FK_BankCommitmentsCharges_NatureCommitment FOREIGN KEY (NatureCommitmentID) REFERENCES NatureCommitment(NatureCommitmentID),
	CONSTRAINT FK_BankCommitmentsCharges_AgencyBank FOREIGN KEY (AgencyBankID) REFERENCES AgencyBank(AgencyBankID),
	CONSTRAINT FK_BankCommitmentsCharges_Client FOREIGN KEY (ClientID) REFERENCES Client(ClientID)
);

-- Table for CreditType
CREATE TABLE CreditType (
    TypeID INT IDENTITY(1,1) PRIMARY KEY,
    TypeLabel NVARCHAR(255) NULL
);


-- Table for Credit
CREATE TABLE Credit(
    CreditID INT IDENTITY(1,1) PRIMARY KEY,
    Matricule NVARCHAR(50), -- Unique identifier for the Credit
);

-- Table for LignCreditClient
CREATE TABLE LignCreditClient(
    LignCreditClientID INT IDENTITY(1,1) PRIMARY KEY,
	ClientID INT, -- Foreign key to Client
	CreditID INT, -- Foreign key to Credit
	IsPrincipal BIT NULL, --Rang du tiers
	PercentageClient INT NULL, --the sum of the % ownership of all third parties involved in a single credit file must not exceed 100%
	-- Foreign Key Constraints
	CONSTRAINT FK_LignCreditClient_Client FOREIGN KEY (ClientID) REFERENCES Client(ClientID),
	CONSTRAINT FK_LignCreditClient_Credit FOREIGN KEY (CreditID) REFERENCES Credit(CreditID)
);

-- Table for ObjectCredit
CREATE TABLE ObjectCredit(
    ObjectCreditID INT IDENTITY(1,1) PRIMARY KEY,
    ObjectCreditLabel NVARCHAR(250), -- Objet du crédit 
);

-- Table for NatureProperty 
CREATE TABLE NatureProperty(
    NaturePropertyID INT IDENTITY(1,1) PRIMARY KEY,
    NaturePropertyLabel NVARCHAR(250), -- Nature du bien
);

-- Table for AssignmentProperty 
CREATE TABLE AssignmentProperty(
    AssignmentPropertyID INT IDENTITY(1,1) PRIMARY KEY,
    AssignmentPropertyLabel NVARCHAR(250), -- Affectation du bien
);

-- Table for UseProperty 
CREATE TABLE UseProperty(
    UsePropertyID INT IDENTITY(1,1) PRIMARY KEY,
    UsePropertyLabel NVARCHAR(250), -- Use of the property
);

-- Table for ConditionProperty 
CREATE TABLE ConditionProperty(
    ConditionPropertyID INT IDENTITY(1,1) PRIMARY KEY,
    ConditionPropertyLabel NVARCHAR(250), -- Etat du bien
);

-- Table for Property 
CREATE TABLE Property(
    PropertyID INT IDENTITY(1,1) PRIMARY KEY,
    Adress NVARCHAR(250) NULL, --Adresse du bien
	PropertyArea NVARCHAR(250) NULL, --Superficie du bien 
	LandTitle NVARCHAR(250) NULL, --Titre foncier 
	SalePriceProperty decimal(18,2) NULL, --Prix de vente du bien 
	RealValueProperty decimal(18,2) NULL, --Valeur réelle du bien 
	AmountWork decimal(18,2) NULL, --Montant des travaux
	EstimatedValue decimal(18,2) NULL, --Valeur estimative --only for crédit hypothécaire
	NaturePropertyID INT NULL,
	AssignmentPropertyID INT NULL,
	UsePropertyID INT NULL,
	ConditionPropertyID INT NULL,
	-- Foreign Key Constraints
	CONSTRAINT FK_Property_NatureProperty FOREIGN KEY (NaturePropertyID) REFERENCES NatureProperty(NaturePropertyID),
	CONSTRAINT FK_Property_AssignmentProperty FOREIGN KEY (AssignmentPropertyID) REFERENCES AssignmentProperty(AssignmentPropertyID),
	CONSTRAINT FK_Property_UseProperty FOREIGN KEY (UsePropertyID) REFERENCES UseProperty(UsePropertyID),
	CONSTRAINT FK_Property_ConditionProperty FOREIGN KEY (ConditionPropertyID) REFERENCES ConditionProperty(ConditionPropertyID),
);

-- Table for LignCreditProperty
CREATE TABLE LignCreditProperty(
    LignCreditPropertyID INT IDENTITY(1,1) PRIMARY KEY,
	CreditID INT, -- Foreign key to Credit
	ObjectCreditID INT NULL, -- Foreign key to Credit
	PropertyID INT NULL, -- Foreign key to Credit
	IsPrincipal BIT NULL, --Rang du tiers
	IsObjectCredit BIT NULL,
	IsAdditional BIT NULL,
	IsSubstitution BIT NULL,
	-- Foreign Key Constraints
	CONSTRAINT FK_LignCreditProperty_Credit FOREIGN KEY (CreditID) REFERENCES Credit(CreditID),
	CONSTRAINT FK_LignCreditProperty_ObjectCredit FOREIGN KEY (ObjectCreditID) REFERENCES ObjectCredit(ObjectCreditID),
	CONSTRAINT FK_LignCreditProperty_Property FOREIGN KEY (PropertyID) REFERENCES Property(PropertyID)
);