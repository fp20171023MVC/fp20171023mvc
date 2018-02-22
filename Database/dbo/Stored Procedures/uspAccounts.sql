 CREATE PROCEDURE [dbo].[uspAccounts] 
    @varPersonCode int
AS 
    SET NOCOUNT ON;
    SELECT a.[code], a.[account_number], a.[outstanding_balance], a.[person_code]
    FROM [dbo].[Accounts] a
    WHERE a.[person_code] = @varPersonCode;
