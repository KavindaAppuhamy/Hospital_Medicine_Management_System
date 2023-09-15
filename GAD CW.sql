Create database pharmacy;
use pharmacy;

create table Users
(id int identity (1,1) primary key,
Userid varchar (20) not null,
userRole varchar (20) not null,
uname varchar (30)not null,
mobile bigint not null,
email varchar (20)not null,
username varchar(20)not null,
pass varchar (20)not null,
cpass varchar (20) not null,
otp bigint not null,
);

select*from Users;
Truncate table Users;
drop table Users;



create table medicine
(id int identity (1,1) primary key,
srNo bigint not null,
medi_name varchar (30) not null,
manufacturer varchar (30) not null,
Mdate varchar (30) not null,
Exdate varchar (30) not null,
qty bigint not null,
Uprice bigint not null,
Entrydate varchar (30)not null,
);

select*from medicine;
truncate table medicine;

drop table medicine;

create table Bill
(Bill_No int not null,
Bill_Date varchar (30) not null,
Bill_Amount bigint not null,
Dis_Amount bigint not null,
Net_Pay varchar (10) not null
);

select*from Bill;
drop table Bill;
truncate table Bill;

create table fullbill
(fbName varchar (30) not null,
unitP bigint not null,
qty bigint not null,
amt bigint not null,
billNo int not null,
billDate varchar(30) not null
);
truncate table fullbill;
select*from fullbill;
select*from Bill;