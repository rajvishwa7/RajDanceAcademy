create table tbl_danceStudent
(
	Id int primary key Identity(1,1),
	StuName varchar(50),
	StuAge int,
	StuParentName varchar(50),
	StuEmail varchar(50),
	StuMobile varchar(50)
)

--------------------------------------

create procedure sp_danceInsert
(
	@stuName varchar(50),
	@stuAge int,
	@stuParentName varchar(50),
	@stuEmail varchar(50),
	@stuMobile varchar(50)
)
as
begin
	insert into tbl_danceStudent
	values (@stuName,@stuAge,@stuParentName,@stuEmail,@stuMobile)
end

------------------------------------------

create procedure sp_danceUpdate
(
	@stuName varchar(50),
	@stuAge int,
	@stuParentName varchar(50),
	@stuEmail varchar(50),
	@stuMobile varchar(50),
	@stuId int
)
as
begin
	update tbl_danceStudent 
	set StuName=@stuName,StuAge=@stuAge,StuParentName=@stuParentName,StuEmail=@stuEmail,StuMobile=@stuMobile
	where Id = @stuId
end


-----------------------------------------

create procedure sp_danceDelete
(
	@stuId int
)
as
begin
	delete from tbl_danceStudent 
	where Id = @stuId
end

-----------------------------------------

create procedure sp_danceSelect
as
begin
	select * from tbl_danceStudent 
end