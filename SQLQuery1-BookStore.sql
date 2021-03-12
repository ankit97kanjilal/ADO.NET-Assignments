/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [BookCode]
      ,[BookName]
      ,[Publisher]
      ,[AuthorName]
      ,[Price]
  FROM [BOOKSTORE].[dbo].[BookTable]

insert into BookTable values('ASPNA','ASP.Net Professional', 'Wrox','Bill Evjen Matt Gibbs',750)
insert into BookTable values('ASPNB','Beginning ASP.Net', 'TechMedia ','Dan Wahlin, Dave Reed',545)
insert into BookTable values('LNQA','Learning LINQ', 'APress','Steve Eichert ',400)
insert into BookTable values('CSPN','C# Developers Guide', 'Tata McGraw ','Dan Maharry',675)
