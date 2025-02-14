use [DB-Disneydle]
go

-- Testing: 
--select * from Quote
--select * from Character

-- Select all infos from character 1 + his citations
select  * from Character 
			Join Quote 
				on [Quote].[Character_Id] = [Character].[Character_Id]
				where Character.Character_Id =1

