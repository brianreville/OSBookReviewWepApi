-- Stored Procedure to Get Top 50 Authors
Create Procedure dbo.spGetTop50Authors
as
Begin
	Select Top 50 a.AID,a.AuthorName,p.PublisherName,Sum(r.Rating)/Count(Rating) as OverAllRating from BookReview r
	Inner Join BookDetail b
	on b.BDID = r.BDID
	Inner Join Author a
	on a.AID = b.AID
	Inner Join Publisher p
	On p.PID = b.PID
	Group by a.AID,a.AuthorName,p.PublisherName
	Order By Sum(r.Rating)/Count(Rating) desc
End
Go

Create Procedure dbo.spGetAuthorsByName
	@aname varchar(250)
as
Begin	
	Select  a.AID,a.AuthorName,p.PublisherName,Sum(r.Rating)/Count(Rating) as OverAllRating from BookReview r
	Inner Join BookDetail b
	on b.BDID = r.BDID
	Inner Join Author a
	on a.AID = b.AID
	Inner Join Publisher p
	On p.PID = b.PID
	Where a.Authorname Like '%' + @aname + '%'
	Group by  a.AID,a.AuthorName,p.PublisherName
End

Go
-- Stored Procedure to return a list of books belonging to an author
Create Procedure dbo.spGetAuthorBooks 
	@AID int
as
Begin
	Select B.BDID,a.AuthorName,p.PublisherName,b.ISBN,b.BookName,b.ImageUrlS,b.ImageUrlM,b.ImageUrlL,Sum(r.Rating)/Count(Rating) as OverAllRating from BookDetail b
	Left Join BookReview r
	On b.BDID = r.BDID
	Inner Join Author a
	on a.AID = b.AID
	Inner Join Publisher p
	On p.PID = b.PID
	Where b.AID = @AID
	Group By B.BDID,a.AuthorName,p.PublisherName,b.ISBN,b.BookName,b.ImageUrlS,b.ImageUrlM,b.ImageUrlL
End
Go

Create Procedure dbo.spDeviceRegistered
    @devid nvarchar(400),
	@userid int 
as
Begin
	Declare @RDID int
	Set @RDID = (Select RDID from RegisteredDevice where RegiseredDevice = @devid)
	Begin		
		Begin
			Insert into DeviceLog (rdid,userid) Values(@RDID,@userid)
		End
	End
End
Go

Create Procedure dbo.spLoginVerify
	@username nvarchar(100),
	@password nvarchar(200)
as
Begin
	Declare @Userid int
	Declare @Uaid int
	Declare @AccessLevel int
	Declare @AccessToken nvarchar(max)
	Declare @ValidUser bit
	Declare @DeviceRegistered bit

	Select @Userid = userid,@Uaid = uaid from users
	where username = @username and UserPassword = @password ;

	Select @AccessLevel = accesslevel from UserAccess
	where UAID = @Uaid

	Select @Userid as Userid,@Uaid as Uaid,@AccessLevel as AccessLevel,@username as UserName,@password as UserPword,
		  @AccessToken as AccessToken,@ValidUser as ValidUser,@DeviceRegistered as DeviceRegistered

End
Go

Create Procedure dbo.spGetAuthorsByID 
	@aid int
As
Begin
	Select b.BDID,0 as Userid,0 as Rating,b.OverallRating,p.PublisherName,a.AuthorName,b.ImageUrlS,b.ImageUrlM,b.ImageUrlL from BookDetail b
	Inner Join Author a
	On a.aid = b.aid
	Inner Join publisher p
	On p.PID = b.PID
	Where b.aid = @aid
End
Go

Create Procedure dbo.spInsertBookReview 
	@BDID int,
	@Userid int,
	@Rating int,
	@ReviewRemarks varchar(400)
As
Begin
Insert Into BookReview (BDID,Userid,Rating,Remarks) 
Values(@BDID,@Userid,@Rating,@ReviewRemarks) ;
End
Go

Create Procedure dbo.spGetSingleBook 
	@bdid int
As
Begin
Select b.BDID,0 as Userid,0 as Rating,b.OverallRating,p.PublisherName,a.AuthorName,b.ImageUrlS,b.ImageUrlM,b.ImageUrlL from BookDetail b
	Inner Join Author a
	On a.aid = b.aid
	Inner Join publisher p
	On p.PID = b.PID
	Where b.BDID = @bdid
End
Go



-- Grant User Permission to execute stored procedures
GRANT EXECUTE ON dbo.spGetTop50Authors TO bookreview
GRANT EXECUTE ON dbo.spGetAuthorBooks TO bookreview
GRANT EXECUTE ON dbo.spDeviceRegistered TO bookreview
GRANT EXECUTE ON dbo.spLoginVerify TO bookreview
GRANT EXECUTE ON dbo.spGetAuthorsByName TO bookreview
GRANT EXECUTE ON dbo.spInsertBookReview  TO bookreview
GRANT EXECUTE ON dbo.spGetAuthorsByID  TO bookreview
GRANT EXECUTE ON dbo.spGetSingleBook  TO bookreview
 

 