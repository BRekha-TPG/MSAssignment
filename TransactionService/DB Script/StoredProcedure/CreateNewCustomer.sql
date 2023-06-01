IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'CreateNewCustomer')
	DROP PROCEDURE CreateNewCustomer
GO
CREATE PROCEDURE CreateNewCustomer
(
	@AccountNumber varchar(50),
	@Name varchar(50),
	@balance decimal(18,0),
	@Address varchar(50)
)
AS
BEGIN

	INSERT INTO AccountInformation
	(AccountNo,
	Address,
	CurrentBalance,
	Name)
	VALUES
	(
	@AccountNumber,
	@Address,
	@balance,
	@Name
	)

END