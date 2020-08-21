INSERT INTO [Status] (StatusName)
	VALUES
	('Student'),
	('Professor'),
	('Manager'),
	('Admin');

INSERT INTO Classes (ClassName, ClassInfos) 
	VALUES
	('1A', 'Classe rouge'),
	('2A', 'Classe jaune'),
	('3A', 'Classe mauve'),
	('4A', 'Classe bleue');

/*INSERT PROFESSORS*/
INSERT INTO Users (NationalNumber, LastName, FirstName, Birthdate, AdCity, AdPostalCode, 
						AdStreet, AdNumber, AdBox, MobilePhone, [Login],[Password], Gender,
						Photo, PersonalNote, StartDate, EndDate, FirstLogin, Email, IsActive, ClassId) 
	VALUES
	('592-3924660-24', 'Clarke', 'Emilia', '1988-12-25', 'Sart-Dames-Avelines', 1495, 
	'Rue du Try', 20,'D','+32477469214', 'EClarke',HASHBYTES('SHA2_512',dbo.PreSalt()+'test1234='+dbo.PostSalt()), 'F', 
	'https://media.virginradio.fr/article-3808966-head-f10/emilia-clarke-photoshoot.jpg', 
	'Très bon Feedback de la part des élèves.', '2015-09-01', null, '2015-09-01', 
	'EmiliaClark@daenerysTargaryen.com', DEFAULT, 1),

	('592-3925660-24', 'Swann', 'Elisabeth', '1985-03-26', 'Marbais', 1495,
	'Rue du Black Pearl', 1, null, '+32485421546', 'ESwann', HASHBYTES('SHA2_512',dbo.PreSalt()+'test1234='+dbo.PostSalt()), 'F',
	'https://vignette.wikia.nocookie.net/lemondededisney/images/8/85/Elizabeth_Swann_Headshot.jpg/revision/latest?cb=20161220132134&path-prefix=fr',
	null, '2016-09-01', null, '2016-09-02', 'ElisabethSwann@blackpearl.com', DEFAULT, 2),

	('592-3424660-24', 'Miller', 'John', '1967-10-12', 'Villers-La-Ville', 1495,
	'Route d''Omaha Beach', 47, 'C', '+32496547845', 'JMiller', HASHBYTES('SHA2_512',dbo.PreSalt()+'test1234='+dbo.PostSalt()), 'M',
	'https://vignette.wikia.nocookie.net/savingprivateryan/images/9/95/Miller.jpg/revision/latest?cb=20160412130225',
	'A de grande aptitudes à mener une classe au front', '2000-09-01', '2018-06-06', '2000-09-02', 
	'JohnMilleur@doggreen.be', 0, null),

	('592-2924660-24', 'Everdeen', 'Katniss', '1996-07-02', 'Bruxelles', 1000, 
	'Chemin du District', 12, null, '+32465521489', 'KEverdeen',HASHBYTES('SHA2_512',dbo.PreSalt()+'test1234='+dbo.PostSalt()), 'F',
	'https://vignette.wikia.nocookie.net/hungergamesfrance/images/4/42/Jennifer-lawrence-interprete-katniss-everdeen.jpg/revision/latest?cb=20150830195605&path-prefix=fr',
	'Sait unir les élèves dans une cours de récréation', '2018-09-01', null, '2018-09-02',
	'KatnissEverdeen@mokingJay.com', DEFAULT, 3),

	('592-21457845-24', 'Proudmoore','Jaina', '1975-04-01', 'Dalaran', 4541, 
	'Port de Theramore', 427, null,	'+64451223568', 'JProudmoore', HASHBYTES('SHA2_512',dbo.PreSalt()+'test1234='+dbo.PostSalt()), 'F',
	'https://cogconnected.com/wp-content/uploads/2020/03/JainaProudmooreWOW.2-1024x680.jpg',
	null, '2010-09-01', null, '2010-09-02', 'JainaProudmoore@Azeroth.com',DEFAULT, 4);

/*INSERT ADMIN*/
INSERT INTO Users(NationalNumber, LastName, FirstName, Birthdate, AdCity, AdPostalCode, 
						AdStreet, AdNumber, AdBox, MobilePhone, [Login],[Password], Gender,
						Photo, PersonalNote, StartDate, EndDate, FirstLogin, Email )
	VALUES
	('592-3912340-24', 'Tournay', 'Michael', '1985-07-02', 'Sart-Dames-Avelines', 1495,
	'Rue du Try', 20, 'D', '+32477469326', 'mikatournay', HASHBYTES('SHA2_512',dbo.PreSalt()+'test1234='+dbo.PostSalt()), 'M',
	'https://i.ebayimg.com/images/g/zrAAAOSwsFJeNN5S/s-l300.jpg',
	'Master Of This Code', '2020-08-19', null, '2020-08-20', 'mikatournay@gmail.com');

/*SET PROFESSORS STATUS & ADMIN STATUS*/
INSERT INTO User_Status(UserId, StatusId)
	VALUES
	(1,2),(2,2),(3,2),(4,2),(5,2),(6,4)

/*INSERT STUDENTS*/
/*CLASS 1*/
EXEC dbo.CreateUser '1234','Lefou','Arnold','1985-07-02','Sart-Dames-Avelines',1495,'Rue du Try',20, null,null,'M',null,null,'2020-08-21',null,'test1234=', 1;
EXEC dbo.CreateUser '1235','Jamine','Pierrot','1985-07-02','Sart-Dames-Avelines',1495,'Rue du Try',20, null,null,'M',null,null,'2020-08-21',null,'test1234=', 1;
EXEC dbo.CreateUser '1236','Pourtouf','Jean-Marc','1985-07-02','Sart-Dames-Avelines',1495,'Rue du Try',20, null,null,'M',null,null,'2020-08-21',null,'test1234=', 1;
EXEC dbo.CreateUser '1237','Lafouri','Karim','1986-09-27','Sart-Dames-Avelines',1495,'Rue du Try',20, null,null,'M',null,null,'2020-08-21',null,'test1234=', 1;
EXEC dbo.CreateUser '1238','Charlier','Luc','1985-07-02','Sart-Dames-Avelines',1495,'Rue du Try',20, null,null,'M',null,null,'2020-08-21',null,'test1234=', 1;
EXEC dbo.CreateUserStatus 7,1;
EXEC dbo.CreateUserStatus 8,1;
EXEC dbo.CreateUserStatus 9,1;
EXEC dbo.CreateUserStatus 10,1;
EXEC dbo.CreateUserStatus 11,1;
/*CLASS 2*/
EXEC dbo.CreateUser '12341','Bourdon','Laurent','1985-07-02','Sart-Dames-Avelines',1495,'Rue du Try',20, null,null,'M',null,null,'2020-08-21',null,'test1234=', 2;
EXEC dbo.CreateUser '12342','Fernandez','Daniel','1985-07-02','Sart-Dames-Avelines',1495,'Rue du Try',20, null,null,'M',null,null,'2020-08-21',null,'test1234=', 2;
EXEC dbo.CreateUser '12343','Lafouri','Karim','1985-07-02','Sart-Dames-Avelines',1495,'Rue du Try',20, null,null,'M',null,null,'2020-08-21',null,'test1234=', 2;
EXEC dbo.CreateUser '12344','Charlier','Luc','1985-07-02','Sart-Dames-Avelines',1495,'Rue du Try',20, null,null,'M',null,null,'2020-08-21',null,'test1234=', 2;
EXEC dbo.CreateUser '12345','Lefou','Pierrot','1985-07-02','Sart-Dames-Avelines',1495,'Rue du Try',20, null,null,'M',null,null,'2020-08-21',null,'test1234=', 2;
EXEC dbo.CreateUserStatus 12,1;
EXEC dbo.CreateUserStatus 13,1;
EXEC dbo.CreateUserStatus 14,1;
EXEC dbo.CreateUserStatus 15,1;
EXEC dbo.CreateUserStatus 16,1;
/*CLASS 3*/
EXEC dbo.CreateUser '123411','Livin','Caroline','1985-07-02','Sart-Dames-Avelines',1495,'Rue du Try',20, null,null,'F',null,null,'2020-08-21',null,'test1234=', 3;
EXEC dbo.CreateUser '123422','Fernandez','Daniela','1985-07-02','Sart-Dames-Avelines',1495,'Rue du Try',20, null,null,'F',null,null,'2020-08-21',null,'test1234=', 3;
EXEC dbo.CreateUser '123433','Vanderlinden','Laura','1985-07-02','Sart-Dames-Avelines',1495,'Rue du Try',20, null,null,'F',null,null,'2020-08-21',null,'test1234=', 3;
EXEC dbo.CreateUser '123444','Foullon','Sarah','1985-07-02','Sart-Dames-Avelines',1495,'Rue du Try',20, null,null,'F',null,null,'2020-08-21',null,'test1234=', 3;
EXEC dbo.CreateUser '123455','Bultreys','Nancy','1985-07-02','Sart-Dames-Avelines',1495,'Rue du Try',20, null,null,'F',null,null,'2020-08-21',null,'test1234=', 3;
EXEC dbo.CreateUserStatus 17,1;
EXEC dbo.CreateUserStatus 18,1;
EXEC dbo.CreateUserStatus 19,1;
EXEC dbo.CreateUserStatus 20,1;
EXEC dbo.CreateUserStatus 21,1;
/*CLASS 4*/
EXEC dbo.CreateUser '1234111','Star','Stacy','1985-07-02','Sart-Dames-Avelines',1495,'Rue du Try',20, null,null,'F',null,null,'2020-08-21',null,'test1234=', 4;
EXEC dbo.CreateUser '1234222','Neury','Valery','1985-07-02','Sart-Dames-Avelines',1495,'Rue du Try',20, null,null,'M',null,null,'2020-08-21',null,'test1234=', 4;
EXEC dbo.CreateUser '1234333','Matthys','Clea','1985-07-02','Sart-Dames-Avelines',1495,'Rue du Try',20, null,null,'F',null,null,'2020-08-21',null,'test1234=', 4;
EXEC dbo.CreateUser '1234444','Vandersteen','Steve','1985-07-02','Sart-Dames-Avelines',1495,'Rue du Try',20, null,null,'M',null,null,'2020-08-21',null,'test1234=', 4;
EXEC dbo.CreateUser '1234555','Bultreys','Pascaline','1985-07-02','Sart-Dames-Avelines',1495,'Rue du Try',20, null,null,'F',null,null,'2020-08-21',null,'test1234=', 4;
EXEC dbo.CreateUserStatus 22,1;
EXEC dbo.CreateUserStatus 23,1;
EXEC dbo.CreateUserStatus 24,1;
EXEC dbo.CreateUserStatus 25,1;
EXEC dbo.CreateUserStatus 26,1;



