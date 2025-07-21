ALTER TABLE Credit ADD created_by INT;

ALTER TABLE Credit
ADD CONSTRAINT FK_Credit_UserBO_CreatedBy
FOREIGN KEY (created_by) REFERENCES user_bo(id);

-------------------------------------------------------

ALTER TABLE Client ADD created_by INT;

ALTER TABLE Client
ADD CONSTRAINT FK_Client_UserBO_CreatedBy
FOREIGN KEY (created_by) REFERENCES user_bo(id);

ALTER TABLE Client ALTER COLUMN created_by INT NULL;
ALTER TABLE Credit ALTER COLUMN created_by INT NULL;

----------------------------------------------------------------

ALTER TABLE Credit ADD credit_statut INT NULL;

ALTER TABLE Credit ADD is_submit bit NULL;

------------------------------------------------------------------

ALTER TABLE CreditStatus ADD created_by INT NULL;

ALTER TABLE CreditStatus
add user_bo_id INT NULL;

ALTER TABLE CreditStatus
ADD CONSTRAINT FK_CreditStatus_UserBO_user_bo_id
FOREIGN KEY (user_bo_id) REFERENCES user_bo(id);