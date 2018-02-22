CREATE VIEW [dbo].[PersonAccount] 
AS   
SELECT p.[id_number], p.[surname], p.[name], a.[account_number]  
FROM [dbo].[Accounts] a   
JOIN [dbo].[Persons] AS p ON a.[person_code] = p.[code];
