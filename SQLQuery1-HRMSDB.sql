/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [ecode]
      ,[ename]
      ,[salary]
      ,[deptid]
  FROM [HRMSDB].[dbo].[tbl_employee]
--====================================
--For SQL Server Provider connectivity, we need:
--System.Data.SqlClient--->connected mode of operation
	--SqlConnection--->Details for connecting database server
	--SqlCommand--->for SQL statements for INSERT, DELETE, UPDATE, SELECT, Stored Procedure
		--ExecuteNonQuery()--->INSERT, DELETE and UPDATE--->returns int records affect
		--ExecuteReader()--->SELECT--->returns result of the query--->SqlDataReader
		--																	.Read()--true if traversed
		--ExecuteScalar()--->SELECT--->returns first column of first row--->object--->no need to Read() it
				--select sum(salary) from tbl_employee
		--Parameters--->used for binding the parameters with stored procedure


--=====================here
/*connected Mode of ADO.NET: connection object must always be opened or active till u are not done with the records.
All the SQL operations like INSERT,DELETE,UPDATE,SELECT,SP etc has to be done in database.

Disconnected Mode of ADO.NET: (do this inside the memory... After completion of all the operations then all 
the changes pushed back to the database.. only for that time connection is built.. just for fraction of seconds)
*/
