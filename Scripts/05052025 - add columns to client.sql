Create table CreditRemark(
	id INT IDENTITY(1, 1) PRIMARY KEY,
	remark nvarchar(max) NULL,
	[userID] INT NULL,
	FOREIGN KEY (userID) REFERENCES [user_bo](id),

	[id_credit] INT NULL,
	FOREIGN KEY (id_credit) REFERENCES [Credit](CreditID),
)
