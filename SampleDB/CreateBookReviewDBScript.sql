
Create Table Author (
AID Int Identity(1,1) Primary Key,
AuthorName varchar(400)
);

Create Table Publisher (
PID Int Identity(1,1) Primary Key,
PublisherName varchar(400)
);

Create Table BookDetail (
BDID Int Identity (1,1) Primary Key,
ISBN varchar(20),
AID Int References Author(AID),
PID Int References Publisher(PID),
BookName varchar(400),
PublishedYear int,
ImageUrlS varchar(400),
ImageUrlM varchar(400),
ImageUrlL varchar(400),
OverAllRating int default 0
)

Create Table UserAccess(
UAID Int Identity(1,1) Primary Key,
AccessType varchar(250),
AccessLevel int
)


Create Table Users (
UserID Int Identity(1,1) Primary Key,
Username varchar(200),
Userpassword varchar(25),
Useremailaddress varchar(200),
UAID Int References UserAccess(UAID)
)

Create Table BookReview
(
BRID Int Identity(1,1) Primary kEY,
BDID Int References BookDetail(BDID),
UserID Int References Users(Userid),
Rating Int default 0,
Remarks varchar(400)
)


Create Table RegisteredDevice
(RDID Int Identity(1,1) Primary key,
 RegiseredDevice varchar(200),
 Remarks varchar(200)
)

Create Table DeviceLog
(
Userid int References Users(userid),
RDID int References RegisteredDevice(RDID),
LogDate DateTime default GetDate()
)