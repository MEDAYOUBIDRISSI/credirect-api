ALTER TABLE [Client]
	ADD Profession INT NULL, 
	[Nature_activity] nvarchar(max) NULL, 
	[IfOrTp] nvarchar(max) NULL,
	Adress_activity nvarchar(max) NULL,
	Honoraires decimal(18,2) NULL,
	Date_debut_exercice DATETIME NULL,
	Fonction nvarchar(max) NULL,
	Employeur nvarchar(max) NULL,
	Date_Embauche DATETIME NULL,
	Salaire decimal(18,2) NULL,
	NRC nvarchar(max) NULL,
	Date_Creation_RC DATETIME NULL,
	Revenu decimal(18,2) NULL,
	Denomination nvarchar(max) NULL,
	Date_Creation_Company DATETIME NULL,
	ActivityCompany nvarchar(max) NULL,
	Capital_Social decimal(18,2) NULL,
	ResultatYearN decimal(18,2) NULL,
	ChiffreAffaireYearN decimal(18,2) NULL,
	ResultatYearN_1 decimal(18,2) NULL,
	ChiffreAffaireYearN_1 decimal(18,2) NULL,
	PartsParticipationSociete decimal(18,2) NULL,
	Nature_Bail INT NULL,
	Rent decimal(18,2) NULL
Go

Create table Pensionnaire(
	id INT IDENTITY(1, 1) PRIMARY KEY,
	NaturePension nvarchar(max) NULL,
	OrganismePension INT NULL, 
	TypePension INT NULL, 
	Montant decimal(18,2) NULL,
	[ClientID] INT NULL,
	FOREIGN KEY (ClientID) REFERENCES [Client](ClientID),
)

ALTER TABLE [InfosBank] ADD AgencyName nvarchar(max) NULL