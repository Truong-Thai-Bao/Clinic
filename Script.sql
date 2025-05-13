use CMSystem
go
create proc uspInsertSymptom
	@Name nchar(50),
	@PatientId int,
	@AddedDate datetime,
	@AddedBy int
as
begin 
	Insert into Symptom(Name,PatientId,AddedDate,AddedBy) values(@Name,@PatientId,@AddedDate,@AddedBy)
end