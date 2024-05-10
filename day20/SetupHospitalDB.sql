Create DataBase dbHospital;

use dbHospital;

drop table Appointments
drop table Doctors
drop table Patients


create table Doctors(
	DoctorID int identity (1,1) constraint PK_DoctorID primary key,
	DoctorName varchar(30),
	DoctorSpecialization varchar(30)
)

Create table Patients(
	PatientID int identity(100,1) Constraint PK_PatientID primary key,
	PatientName varchar(30),
	PatientAge int,
	PatientGender varchar(5),
	PatientAddress varchar(50),
	PatientPhoneNumber varchar(30)
)
go
create table Appointments(
	AppointmentID int identity(1000,1) Constraint PK_AppintmentID primary key,
	PatientID int Constraint FK_PatientID Foreign key References Patients(PatientID),
	DoctorID int Constraint FK_DoctorID Foreign key References Doctors(DoctorID),
	_AppointmentDate date,
	AppointmentBookDateTime date
)

select * from Doctors
select * from Patients
select * from  Appointments

delete Appointments








