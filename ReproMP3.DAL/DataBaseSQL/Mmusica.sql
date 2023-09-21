create database Mmusica
go
use Mmusica
create table Dmusica(
Id int not null primary key identity (1,1),
Nombre varchar(50) NOT NULL,
Autor varchar(50) NOT NULL,
Icono varchar(100) NOT NULL,
Url varchar(1000) NOT NULL
);
select*From Dmusica

INSERT INTO Dmusica VALUES('Caracoles','caracolito',
'https://thumbs.dreamstime.com/z/mariposa-18-4429435.jpg?w=768',
'https://firebasestorage.googleapis.com/v0/b/applicacion-811d4.appspot.com/o/_los%20ciegos%20me%20llaman%20por%20videollamada%20y%20dicen%20que%20me%20veo%20duro_%20--(MP3_320K).mp3?alt=media&token=89ef1a29-4acc-4c7f-918d-ab57044fae2c ')
        
		
		alter table Dmusica alter column Url varchar(1000);