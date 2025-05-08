use CMSystem
go
create proc uspGetUserType
	@Username varchar(50),
	@UserPassword varchar(50)
as
begin 
	select UserType from UserInfo where Username = @Username and UserPassword = @UserPassword
end
