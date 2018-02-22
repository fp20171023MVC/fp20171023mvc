 CREATE PROCEDURE [dbo].[uspTransactions] 
    @varAccountCode int
AS 
    SET NOCOUNT ON;
    SELECT t.[code], t.[transaction_date], t.[capture_date], t.[description], t.[amount], t.[account_code] 
    FROM [dbo].[Transactions] t
    WHERE t.[account_code] = @varAccountCode;
