USE credirect; -- Ensure you are in the correct database
GO

-- Table for Identity
CREATE TABLE ClientIdentity (
    IdentityID INT IDENTITY(1,1) PRIMARY KEY,
    IdentityLabel NVARCHAR(255)
);

-- Table for Marital Status
CREATE TABLE MaritalStatus (
    MaritalStatusID INT IDENTITY(1,1) PRIMARY KEY,
    MaritalStatusLabel NVARCHAR(255)
);

-- Table for Residency Status
CREATE TABLE ResidencyStatus (
    ResidencyStatusID INT IDENTITY(1,1) PRIMARY KEY,
    ResidencyStatusLabel NVARCHAR(255)
);

-- Table for Business Activity
CREATE TABLE BusinessActivity (
    BusinessActivityID INT IDENTITY(1,1) PRIMARY KEY,
    BusinessActivityLabel NVARCHAR(255)
);

CREATE TABLE ClientTitle (
    ClientTitleID INT IDENTITY(1,1) PRIMARY KEY,
    ClientTitleLabel NVARCHAR(255)
);

CREATE TABLE ClientCountry (
    ClientCountryID INT IDENTITY(1,1) PRIMARY KEY,
    ClientCountryLabel NVARCHAR(255)
);

CREATE TABLE dbo.Client (
    ClientID INT IDENTITY(1,1) PRIMARY KEY, -- Auto-incrementing primary key
    VIP BIT, -- Boolean flag for VIP status (0 or 1)
    Matricule NVARCHAR(50) UNIQUE, -- Unique identifier for the client
    LastName NVARCHAR(255), -- Client's last name (max 255 characters)
    FirstName NVARCHAR(255), -- Client's first name (max 255 characters)
    BirthDate DATE, -- Date of birth
    ClientTitleID INT, -- Foreign key to ClientTitle
    Nationality NVARCHAR(255), -- Nationality of the client
    IdentityID INT, -- Foreign key to ClientIdentity
    Address NVARCHAR(MAX), -- Client's address (longer text allowed)
    City NVARCHAR(255), -- City of residence (short text)
    CountryID INT, -- Foreign key to ClientCountry for client's country
    ResidenceCountryID INT, -- Foreign key to ClientCountry for residence country
    MaritalStatusID INT, -- Foreign key to MaritalStatus
    MobilePhone NVARCHAR(50), -- Mobile phone number (increased size)
    LandlinePhone NVARCHAR(50), -- Landline phone number (increased size)
    WorkPhone NVARCHAR(50), -- Work phone number (increased size)
    Email NVARCHAR(255), -- Email address (short text)
    ResidencyStatusID INT, -- Foreign key to ResidencyStatus
    IsOwner BIT, -- Boolean flag indicating property ownership
    IsTenant BIT, -- Boolean flag indicating tenancy
    RequestedAmount DECIMAL(18, 2), -- Requested loan or credit amount
    CompanyName NVARCHAR(255), -- Name of the company (short text)
    LegalForm NVARCHAR(MAX), -- Legal form of the company (now NVARCHAR(MAX))
    CreationDate DATE, -- Company creation date
    RegistrationNumber NVARCHAR(50), -- Company registration number
    CompanyAddress NVARCHAR(MAX), -- Company address (longer text allowed)
    CompanyCity NVARCHAR(255), -- City where the company is located (short text)
    CompanyCountryID INT, -- Foreign key to ClientCountry for company country
    SocialCapital DECIMAL(18, 2), -- Social capital of the company
    BusinessActivityID INT, -- Foreign key to BusinessActivity
    -- Foreign Key Constraints
    CONSTRAINT FK_Client_Identity FOREIGN KEY (IdentityID) REFERENCES ClientIdentity(IdentityID),
    CONSTRAINT FK_Client_MaritalStatus FOREIGN KEY (MaritalStatusID) REFERENCES MaritalStatus(MaritalStatusID),
    CONSTRAINT FK_Client_ResidencyStatus FOREIGN KEY (ResidencyStatusID) REFERENCES ResidencyStatus(ResidencyStatusID),
    CONSTRAINT FK_Client_BusinessActivity FOREIGN KEY (BusinessActivityID) REFERENCES BusinessActivity(BusinessActivityID),
    CONSTRAINT FK_Client_ClientTitle FOREIGN KEY (ClientTitleID) REFERENCES ClientTitle(ClientTitleID),
    CONSTRAINT FK_Client_Country FOREIGN KEY (CountryID) REFERENCES ClientCountry(ClientCountryID),
    CONSTRAINT FK_Client_ResidenceCountry FOREIGN KEY (ResidenceCountryID) REFERENCES ClientCountry(ClientCountryID),
    CONSTRAINT FK_Client_CompanyCountry FOREIGN KEY (CompanyCountryID) REFERENCES ClientCountry(ClientCountryID)
);

CREATE TABLE dbo.ManagerInformation (
    ManagerID INT IDENTITY(1,1) PRIMARY KEY, -- Auto-incrementing primary key for Manager
    ManagerTitleID INT, -- Foreign key to ClientTitle for manager's title
    ManagerLastName NVARCHAR(50), -- Manager's last name (max 50 characters)
    ManagerFirstName NVARCHAR(50), -- Manager's first name (max 50 characters)
    ManagerBirthDate DATE, -- Manager's birth date
    ManagerNationality NVARCHAR(50), -- Manager's nationality (max 50 characters)
    Id_Identity INT, -- Foreign key to ClientIdentity for manager's identity
    ManagerAddress NVARCHAR(MAX), -- Manager's address (max length allowed)
    ManagerCity NVARCHAR(50), -- Manager's city of residence (max 50 characters)
    ManagerCountryID INT, -- Foreign key to ClientCountry for manager's country
    ManagerResidenceCountryID INT, -- Foreign key to ClientCountry for manager's residence country
    Id_ManagerMaritalStatus INT, -- Foreign key to MaritalStatus for manager's marital status
    -- Foreign Key Constraints
    CONSTRAINT FK_Manager_ClientTitle FOREIGN KEY (ManagerTitleID) REFERENCES dbo.ClientTitle(ClientTitleID),
    CONSTRAINT FK_Manager_Identity FOREIGN KEY (Id_Identity) REFERENCES dbo.ClientIdentity(IdentityID),
    CONSTRAINT FK_Manager_Country FOREIGN KEY (ManagerCountryID) REFERENCES dbo.ClientCountry(ClientCountryID),
    CONSTRAINT FK_Manager_ResidenceCountry FOREIGN KEY (ManagerResidenceCountryID) REFERENCES dbo.ClientCountry(ClientCountryID),
    CONSTRAINT FK_Manager_MaritalStatus FOREIGN KEY (Id_ManagerMaritalStatus) REFERENCES dbo.MaritalStatus(MaritalStatusID)
);

ALTER TABLE dbo.Client
ADD ManagerID INT; -- Add the ManagerID column

-- Add Foreign Key Relationship between Client and ManagerInformation
ALTER TABLE dbo.Client
ADD CONSTRAINT FK_Client_Manager FOREIGN KEY (ManagerID) REFERENCES dbo.ManagerInformation(ManagerID);
GO