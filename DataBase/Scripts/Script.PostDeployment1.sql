
/*HARDCODE STATUS*/
INSERT INTO [Status] (StatusName)
	VALUES ('Student'),('Professor'),('Manager'),('Admin');


/*HARDCODE des SchoolYearCategories*/
INSERT INTO SchoolYearCategoryNames
	VALUES ('Acceuil'),('Maternelle'),('Primaire'),('Aucune');

/*INSERT DES CLASSES*/
INSERT INTO Classes (ClassName, ClassDescription, SchoolYear, SchoolYearCategoryId) 
	VALUES
	('0','Classe tempon',0,4),
	('3A', 'Classe rouge', 3, 2),
	('4A', 'Classe jaune', 4, 3),
	('5A', 'Classe mauve', 5, 3),
	('5B', 'Classe bleue', 5, 3);


/*INSERT PROFESSORS*/
INSERT INTO Users (NationalNumber, LastName, FirstName, Birthdate, AdCity, AdPostalCode, 
						AdStreet, AdNumber, AdBox, MobilePhone, [Login],[Password], Gender,
						Photo, PersonalNote, StartDate, EndDate, Email, IsActive, ClassId) 
	VALUES
	('592-3924660-24', 'Clarke', 'Emilia', '1988-12-25', 'Sart-Dames-Avelines', 1495, 
	'Rue du Try', 20,'D','+32477469214', 'EClarke',HASHBYTES('SHA2_512',dbo.PreSalt()+'test1234='+dbo.PostSalt()), 'F', 
	'https://media.virginradio.fr/article-3808966-head-f10/emilia-clarke-photoshoot.jpg', 
	'Très bon Feedback de la part des élèves.', '2015-09-01', null, 
	'EmiliaClark@daenerysTargaryen.com', DEFAULT, 2),

	('592-3925660-24', 'Swann', 'Elisabeth', '1985-03-26', 'Marbais', 1495,
	'Rue du Black Pearl', 1, null, '+32485421546', 'ESwann', HASHBYTES('SHA2_512',dbo.PreSalt()+'test1234='+dbo.PostSalt()), 'F',
	'https://vignette.wikia.nocookie.net/lemondededisney/images/8/85/Elizabeth_Swann_Headshot.jpg/revision/latest?cb=20161220132134&path-prefix=fr',
	null, '2016-09-01', null, 'ElisabethSwann@blackpearl.com', DEFAULT, 3),

	('592-3424660-24', 'Miller', 'John', '1967-10-12', 'Villers-La-Ville', 1495,
	'Route d''Omaha Beach', 47, 'C', '+32496547845', 'JMiller', HASHBYTES('SHA2_512',dbo.PreSalt()+'test1234='+dbo.PostSalt()), 'M',
	'https://vignette.wikia.nocookie.net/savingprivateryan/images/9/95/Miller.jpg/revision/latest?cb=20160412130225',
	'A de grande aptitudes à mener une classe au front', '2000-09-01', '2018-06-06', 
	'JohnMilleur@doggreen.be', 0, null),

	('592-2924660-24', 'Everdeen', 'Katniss', '1996-07-02', 'Bruxelles', 1000, 
	'Chemin du District', 12, null, '+32465521489', 'KEverdeen',HASHBYTES('SHA2_512',dbo.PreSalt()+'test1234='+dbo.PostSalt()), 'F',
	'https://vignette.wikia.nocookie.net/hungergamesfrance/images/4/42/Jennifer-lawrence-interprete-katniss-everdeen.jpg/revision/latest?cb=20150830195605&path-prefix=fr',
	'Sait unir les élèves dans une cours de récréation', '2018-09-01', null,
	'KatnissEverdeen@mokingJay.com', DEFAULT, 4),

	('592-21457845-24', 'Proudmoore','Jaina', '1975-04-01', 'Dalaran', 4541, 
	'Port de Theramore', 427, null,	'+64451223568', 'JProudmoore', HASHBYTES('SHA2_512',dbo.PreSalt()+'test1234='+dbo.PostSalt()), 'F',
	'https://cogconnected.com/wp-content/uploads/2020/03/JainaProudmooreWOW.2-1024x680.jpg',
	null, '2010-09-01', null, 'JainaProudmoore@Azeroth.com',DEFAULT, 5);

/*INSERT ADMIN*/
INSERT INTO Users(NationalNumber, LastName, FirstName, Birthdate, AdCity, AdPostalCode, 
						AdStreet, AdNumber, AdBox, MobilePhone, [Login],[Password], Gender,
						Photo, PersonalNote, StartDate, EndDate, Email )
	VALUES
	('592-3912340-24', 'Tournay', 'Michael', '1985-07-02', 'Sart-Dames-Avelines', 1495,
	'Rue du Try', 20, 'D', '+32477469326', 'mikatournay', HASHBYTES('SHA2_512',dbo.PreSalt()+'test1234='+dbo.PostSalt()), 'M',
	'https://i.ebayimg.com/images/g/zrAAAOSwsFJeNN5S/s-l300.jpg',
	'Master Of This Code', '2020-08-19', null, 'mikatournay@gmail.com');

/*SET PROFESSORS STATUS & ADMIN STATUS*/
INSERT INTO User_Status(UserId, StatusId)
	VALUES
	(1,2),(2,2),(3,2),(4,2),(5,2),(6,4)

/*INSERT STUDENTS*/
/*CLASS 1*/
EXEC dbo.CreateUser '1234','Frozen','Elsa','1985-07-02','Sart-Dames-Avelines',1495,'Rue du Try',20, null,null,'F','https://lumiere-a.akamaihd.net/v1/images/ct_frozen_elsa_18466_22a50822.jpeg?region=0,0,600,600',null,'2020-08-21',null,'test1234=', 2;
EXEC dbo.CreateUser '1235','Frozen','Anna','1985-07-02','Sart-Dames-Avelines',1495,'Rue du Try',20, null,null,'F','https://lumiere-a.akamaihd.net/v1/images/ct_frozen_anna_18466_6775584b.jpeg?region=0,0,600,600&width=480',null,'2020-08-21',null,'test1234=', 2;
EXEC dbo.CreateUser '1236','Son','Goku','1985-07-02','Sart-Dames-Avelines',1495,'Rue du Try',20, null,null,'M','https://www.wallpapertip.com/wmimgs/75-755237_dragon-ball-z-goku-kid.jpg',null,'2020-08-21',null,'test1234=', 2;
EXEC dbo.CreateUser '1237','Lightyear','Buzz','1986-09-27','Sart-Dames-Avelines',1495,'Rue du Try',20, null,null,'M','https://vignette.wikia.nocookie.net/disney/images/7/74/Profile_-_Buzz_Lightyear.jpeg/revision/latest/top-crop/width/360/height/360?cb=20190623020017',null,'2020-08-21',null,'test1234=', 2;
EXEC dbo.CreateUser '1238','Rivera','Miguel','1985-07-02','Sart-Dames-Avelines',1495,'Rue du Try',20, null,null,'M','https://vignette.wikia.nocookie.net/disney/images/0/00/Profile_-_Miguel_Rivera.jpg/revision/latest?cb=20190315012208',null,'2020-08-21',null,'test1234=', 2;
EXEC dbo.CreateUserStatus 7,1;
EXEC dbo.CreateUserStatus 8,1;
EXEC dbo.CreateUserStatus 9,1;
EXEC dbo.CreateUserStatus 10,1;
EXEC dbo.CreateUserStatus 11,1;
/*CLASS 2*/
EXEC dbo.CreateUser '12341','Bourdon','Laurent','1985-07-02','Sart-Dames-Avelines',1495,'Rue du Try',20, null,null,'M',null,null,'2020-08-21',null,'test1234=', 3;
EXEC dbo.CreateUser '12342','Fernandez','Daniel','1985-07-02','Sart-Dames-Avelines',1495,'Rue du Try',20, null,null,'M',null,null,'2020-08-21',null,'test1234=', 3;
EXEC dbo.CreateUser '12343','Lafouri','Karim','1985-07-02','Sart-Dames-Avelines',1495,'Rue du Try',20, null,null,'M',null,null,'2020-08-21',null,'test1234=', 3;
EXEC dbo.CreateUser '12344','Charlier','Luc','1985-07-02','Sart-Dames-Avelines',1495,'Rue du Try',20, null,null,'M',null,null,'2020-08-21',null,'test1234=', 3;
EXEC dbo.CreateUser '12345','Lefou','Pierrot','1985-07-02','Sart-Dames-Avelines',1495,'Rue du Try',20, null,null,'M',null,null,'2020-08-21',null,'test1234=', 3;
EXEC dbo.CreateUserStatus 12,1;
EXEC dbo.CreateUserStatus 13,1;
EXEC dbo.CreateUserStatus 14,1;
EXEC dbo.CreateUserStatus 15,1;
EXEC dbo.CreateUserStatus 16,1;
/*CLASS 3*/
EXEC dbo.CreateUser '123411','Livin','Caroline','1985-07-02','Sart-Dames-Avelines',1495,'Rue du Try',20, null,null,'F',null,null,'2020-08-21',null,'test1234=', 4;
EXEC dbo.CreateUser '123422','Fernandez','Daniela','1985-07-02','Sart-Dames-Avelines',1495,'Rue du Try',20, null,null,'F',null,null,'2020-08-21',null,'test1234=', 4;
EXEC dbo.CreateUser '123433','Vanderlinden','Laura','1985-07-02','Sart-Dames-Avelines',1495,'Rue du Try',20, null,null,'F',null,null,'2020-08-21',null,'test1234=', 4;
EXEC dbo.CreateUser '123444','Foullon','Sarah','1985-07-02','Sart-Dames-Avelines',1495,'Rue du Try',20, null,null,'F',null,null,'2020-08-21',null,'test1234=', 4;
EXEC dbo.CreateUser '123455','Bultreys','Nancy','1985-07-02','Sart-Dames-Avelines',1495,'Rue du Try',20, null,null,'F',null,null,'2020-08-21',null,'test1234=', 4;
EXEC dbo.CreateUserStatus 17,1;
EXEC dbo.CreateUserStatus 18,1;
EXEC dbo.CreateUserStatus 19,1;
EXEC dbo.CreateUserStatus 20,1;
EXEC dbo.CreateUserStatus 21,1;
/*CLASS 4*/
EXEC dbo.CreateUser '1234111','Star','Stacy','1985-07-02','Sart-Dames-Avelines',1495,'Rue du Try',20, null,null,'F',null,null,'2020-08-21',null,'test1234=', 5;
EXEC dbo.CreateUser '1234222','Neury','Valery','1985-07-02','Sart-Dames-Avelines',1495,'Rue du Try',20, null,null,'M',null,null,'2020-08-21',null,'test1234=', 5;
EXEC dbo.CreateUser '1234333','Matthys','Clea','1985-07-02','Sart-Dames-Avelines',1495,'Rue du Try',20, null,null,'F',null,null,'2020-08-21',null,'test1234=', 5;
EXEC dbo.CreateUser '1234444','Vandersteen','Steve','1985-07-02','Sart-Dames-Avelines',1495,'Rue du Try',20, null,null,'M',null,null,'2020-08-21',null,'test1234=', 5;
EXEC dbo.CreateUser '1234555','Bultreys','Pascaline','1985-07-02','Sart-Dames-Avelines',1495,'Rue du Try',20, null,null,'F',null,null,'2020-08-21',null,'test1234=', 5;
EXEC dbo.CreateUserStatus 22,1;
EXEC dbo.CreateUserStatus 23,1;
EXEC dbo.CreateUserStatus 24,1;
EXEC dbo.CreateUserStatus 25,1;
EXEC dbo.CreateUserStatus 26,1;

/*INSERT CONTACTS + LIENS AVEC USERS*/
EXEC dbo.CreateContact '1111','Père1','Papa1','1985-07-02', 'Sart-Dames-Avelines',1495,'Rue du Try',20, null, '0477/493214','M','Frozen@papa.com','un papa !';
EXEC dbo.CreateUserContact 7,1;
EXEC dbo.CreateUserContact 8,1;
EXEC dbo.CreateContact '11112','Père2','Papa2','1985-07-02', 'Sart-Dames-Avelines',1495,'Rue du Try',20, null, '0477/493214','M','SaïanGod@papa.com','un papa !';
EXEC dbo.CreateUserContact 9,2;
EXEC dbo.CreateContact '11113','Père3','Papa3','1985-07-02', 'Sart-Dames-Avelines',1495,'Rue du Try',20, null, '0477/493214','M','ToyStory@papa.com','un papa !';
EXEC dbo.CreateUserContact 10,3;

EXEC dbo.CreateContact '11114','Père4','Papa4','1985-07-02', 'Sart-Dames-Avelines',1495,'Rue du Try',20, null, '0477/493214','M','Coco@papa.com','un papa !';
EXEC dbo.CreateUserContact 11,4;

EXEC dbo.CreateContact '11115','Père5','Papa5','1985-07-02', 'Sart-Dames-Avelines',1495,'Rue du Try',20, null, '0477/493214','M','Pere5@papa.com','un papa !';
EXEC dbo.CreateUserContact 12,5;

EXEC dbo.CreateContact '11116','Mère1','Maman1','1985-07-02', 'Sart-Dames-Avelines',1495,'Rue du Try',20, null, '0477/493214','F','Frozen@maman.com','une maman !';
EXEC dbo.CreateUserContact 8,6;
EXEC dbo.CreateUserContact 7,6;

EXEC dbo.CreateContact '11117','Mère2','Maman2','1985-07-02', 'Sart-Dames-Avelines',1495,'Rue du Try',20, null, '0477/493214','F','Mere2@maman.com','une maman !';
EXEC dbo.CreateUserContact 13,7;

EXEC dbo.CreateContact '11118','Mère3','Maman3','1985-07-02', 'Sart-Dames-Avelines',1495,'Rue du Try',20, null, '0477/493214','F','Mere3@maman.com','une maman !';
EXEC dbo.CreateUserContact 15,8;

EXEC dbo.CreateContact '11119','Mère4','Maman4','1985-07-02', 'Sart-Dames-Avelines',1495,'Rue du Try',20, null, '0477/493214','F','Mere4@maman.com','une maman !';
EXEC dbo.CreateUserContact 18,9;

EXEC dbo.CreateContact '111110','Mère5','Maman5','1985-07-02', 'Sart-Dames-Avelines',1495,'Rue du Try',20, null, '0477/493214','F','Mere5@maman.com','une maman !';
EXEC dbo.CreateUserContact 21,10;

/*INSERT EVENTS*/
EXEC dbo.CreateSchoolEvent 'Fancyfair','ça va être fun dis donc !','2021-06-01';
EXEC dbo.CreateSchoolEvent 'Rentrée scolaire','blablabla','2020-09-02';
EXEC dbo.CreateSchoolEvent 'Noel','Chants à l''église','2020-12-25';

/*INSERT RULES*/

EXEC dbo.CreateSchoolRule 'Commandement 1', 'JE SUIS LE ­SEIGNEUR, Blabla ! TU N’AURAS PAS ­D’AUTRES DIEUX À CÔTÉ DE MOI (que toto)!';
EXEC dbo.CreateSchoolRule 'Commandement 2', 'TU N’ABUSERAS PAS DU NOM DU SEIGNEUR (donc de moi), TON DIEU !';
EXEC dbo.CreateSchoolRule 'Commandement 3', 'TU ­SANCTIFIERAS LE JOUR DU REPOS ! (en gros tu bosseras tous les jours)';
EXEC dbo.CreateSchoolRule 'Commandement 4', 'TU ­HONORERAS PÈRE ET MÈRE (c''est important un papa et une maman effectivement !)!';
EXEC dbo.CreateSchoolRule 'Commandement 5', 'TU NE ­TUERAS PAS (c''est mal !!)!';
EXEC dbo.CreateSchoolRule 'Commandement 6', 'TU NE ­COMMETTRAS PAS D’ADULTÈRE (ha ben non)!';
EXEC dbo.CreateSchoolRule 'Commandement 7', 'TU NE ­VOLERAS PAS (sauf pour moi)!';
EXEC dbo.CreateSchoolRule 'Commandement 8', 'TU NE ­PORTERAS PAS DE FAUX ­TÉMOIGNAGE ­CONTRE TON PRO­CHAIN (sauf il est républicain) !!';
EXEC dbo.CreateSchoolRule 'Commandement 9', 'TU NE ­CONVOITERAS PAS LA FEMME DE TON PRO­CHAIN (c''est pas parcequ''on regarde la carte que ... bon ok j''arrête)!';
EXEC dbo.CreateSchoolRule 'Commandement 10', 'TU NE CONVOITERAS PAS LA MAISON DE TON PROCHAIN, NI SON DOMAINE, NI SON BÉTAIL, NI RIEN QUI LUI APPARTIENNE (non mais ça dépend vraiment de la superficie, de la dernière rénovation et surtout si il a une piscine) ! ';

/*INSERT TRIMESTRIALINFO*/

EXEC dbo.CreateTrimestrialInfo 'D''où vient-il? Contrairement à une opinion répandue, le Lorem Ipsum n''est pas simplement du texte aléatoire. Il trouve ses racines dans une oeuvre de la littérature latine classique datant de 45 av. J.-C., le rendant vieux de 2000 ans. Un professeur du Hampden-Sydney College, en Virginie, s''est intéressé à un des mots latins les plus obscurs, consectetur, extrait d''un passage du Lorem Ipsum, et en étudiant tous les usages de ce mot dans la littérature classique, découvrit la source incontestable du Lorem Ipsum. Il provient en fait des sections 1.10.32 et 1.10.33 du "De Finibus Bonorum et Malorum" (Des Suprêmes Biens et des Suprêmes Maux) de Cicéron. Cet ouvrage, très populaire pendant la Renaissance, est un traité sur la théorie de l''éthique. Les premières lignes du Lorem Ipsum, "Lorem ipsum dolor sit amet...", proviennent de la section 1.10.32.
L''extrait standard de Lorem Ipsum utilisé depuis le XVIè siècle est reproduit ci-dessous pour les curieux. Les sections 1.10.32 et 1.10.33 du "De Finibus Bonorum et Malorum" de Cicéron sont aussi reproduites dans leur version originale, accompagnée de la traduction anglaise de H. Rackham (1914).', 1,7;
EXEC dbo.CreateTrimestrialInfo 'D''où vient-il? Contrairement à une opinion répandue, le Lorem Ipsum n''est pas simplement du texte aléatoire. Il trouve ses racines dans une oeuvre de la littérature latine classique datant de 45 av. J.-C., le rendant vieux de 2000 ans. Un professeur du Hampden-Sydney College, en Virginie, s''est intéressé à un des mots latins les plus obscurs, consectetur, extrait d''un passage du Lorem Ipsum, et en étudiant tous les usages de ce mot dans la littérature classique, découvrit la source incontestable du Lorem Ipsum. Il provient en fait des sections 1.10.32 et 1.10.33 du "De Finibus Bonorum et Malorum" (Des Suprêmes Biens et des Suprêmes Maux) de Cicéron. Cet ouvrage, très populaire pendant la Renaissance, est un traité sur la théorie de l''éthique. Les premières lignes du Lorem Ipsum, "Lorem ipsum dolor sit amet...", proviennent de la section 1.10.32.
L''extrait standard de Lorem Ipsum utilisé depuis le XVIè siècle est reproduit ci-dessous pour les curieux. Les sections 1.10.32 et 1.10.33 du "De Finibus Bonorum et Malorum" de Cicéron sont aussi reproduites dans leur version originale, accompagnée de la traduction anglaise de H. Rackham (1914).', 2,7;
EXEC dbo.CreateTrimestrialInfo 'D''où vient-il? Contrairement à une opinion répandue, le Lorem Ipsum n''est pas simplement du texte aléatoire. Il trouve ses racines dans une oeuvre de la littérature latine classique datant de 45 av. J.-C., le rendant vieux de 2000 ans. Un professeur du Hampden-Sydney College, en Virginie, s''est intéressé à un des mots latins les plus obscurs, consectetur, extrait d''un passage du Lorem Ipsum, et en étudiant tous les usages de ce mot dans la littérature classique, découvrit la source incontestable du Lorem Ipsum. Il provient en fait des sections 1.10.32 et 1.10.33 du "De Finibus Bonorum et Malorum" (Des Suprêmes Biens et des Suprêmes Maux) de Cicéron. Cet ouvrage, très populaire pendant la Renaissance, est un traité sur la théorie de l''éthique. Les premières lignes du Lorem Ipsum, "Lorem ipsum dolor sit amet...", proviennent de la section 1.10.32.
L''extrait standard de Lorem Ipsum utilisé depuis le XVIè siècle est reproduit ci-dessous pour les curieux. Les sections 1.10.32 et 1.10.33 du "De Finibus Bonorum et Malorum" de Cicéron sont aussi reproduites dans leur version originale, accompagnée de la traduction anglaise de H. Rackham (1914).', 1,8;
EXEC dbo.CreateTrimestrialInfo 'D''où vient-il? Contrairement à une opinion répandue, le Lorem Ipsum n''est pas simplement du texte aléatoire. Il trouve ses racines dans une oeuvre de la littérature latine classique datant de 45 av. J.-C., le rendant vieux de 2000 ans. Un professeur du Hampden-Sydney College, en Virginie, s''est intéressé à un des mots latins les plus obscurs, consectetur, extrait d''un passage du Lorem Ipsum, et en étudiant tous les usages de ce mot dans la littérature classique, découvrit la source incontestable du Lorem Ipsum. Il provient en fait des sections 1.10.32 et 1.10.33 du "De Finibus Bonorum et Malorum" (Des Suprêmes Biens et des Suprêmes Maux) de Cicéron. Cet ouvrage, très populaire pendant la Renaissance, est un traité sur la théorie de l''éthique. Les premières lignes du Lorem Ipsum, "Lorem ipsum dolor sit amet...", proviennent de la section 1.10.32.
L''extrait standard de Lorem Ipsum utilisé depuis le XVIè siècle est reproduit ci-dessous pour les curieux. Les sections 1.10.32 et 1.10.33 du "De Finibus Bonorum et Malorum" de Cicéron sont aussi reproduites dans leur version originale, accompagnée de la traduction anglaise de H. Rackham (1914).', 2,8;
EXEC dbo.CreateTrimestrialInfo 'D''où vient-il? Contrairement à une opinion répandue, le Lorem Ipsum n''est pas simplement du texte aléatoire. Il trouve ses racines dans une oeuvre de la littérature latine classique datant de 45 av. J.-C., le rendant vieux de 2000 ans. Un professeur du Hampden-Sydney College, en Virginie, s''est intéressé à un des mots latins les plus obscurs, consectetur, extrait d''un passage du Lorem Ipsum, et en étudiant tous les usages de ce mot dans la littérature classique, découvrit la source incontestable du Lorem Ipsum. Il provient en fait des sections 1.10.32 et 1.10.33 du "De Finibus Bonorum et Malorum" (Des Suprêmes Biens et des Suprêmes Maux) de Cicéron. Cet ouvrage, très populaire pendant la Renaissance, est un traité sur la théorie de l''éthique. Les premières lignes du Lorem Ipsum, "Lorem ipsum dolor sit amet...", proviennent de la section 1.10.32.
L''extrait standard de Lorem Ipsum utilisé depuis le XVIè siècle est reproduit ci-dessous pour les curieux. Les sections 1.10.32 et 1.10.33 du "De Finibus Bonorum et Malorum" de Cicéron sont aussi reproduites dans leur version originale, accompagnée de la traduction anglaise de H. Rackham (1914).', 1,9;
EXEC dbo.CreateTrimestrialInfo 'D''où vient-il? Contrairement à une opinion répandue, le Lorem Ipsum n''est pas simplement du texte aléatoire. Il trouve ses racines dans une oeuvre de la littérature latine classique datant de 45 av. J.-C., le rendant vieux de 2000 ans. Un professeur du Hampden-Sydney College, en Virginie, s''est intéressé à un des mots latins les plus obscurs, consectetur, extrait d''un passage du Lorem Ipsum, et en étudiant tous les usages de ce mot dans la littérature classique, découvrit la source incontestable du Lorem Ipsum. Il provient en fait des sections 1.10.32 et 1.10.33 du "De Finibus Bonorum et Malorum" (Des Suprêmes Biens et des Suprêmes Maux) de Cicéron. Cet ouvrage, très populaire pendant la Renaissance, est un traité sur la théorie de l''éthique. Les premières lignes du Lorem Ipsum, "Lorem ipsum dolor sit amet...", proviennent de la section 1.10.32.
L''extrait standard de Lorem Ipsum utilisé depuis le XVIè siècle est reproduit ci-dessous pour les curieux. Les sections 1.10.32 et 1.10.33 du "De Finibus Bonorum et Malorum" de Cicéron sont aussi reproduites dans leur version originale, accompagnée de la traduction anglaise de H. Rackham (1914).', 2,9;

/*INSERT LUNCHES*/


EXEC dbo.CreateLunch 'CHoux','avec son accompagnement de pomme de terre bio !','2020-10-19';
EXEC dbo.CreateLunch 'Boulette sauce tomate','avec son accompagnement de pomme de terre bio !','2020-10-20';
EXEC dbo.CreateLunch 'Poulet mariné','avec son accompagnement de frites bio !','2020-10-22';
EXEC dbo.CreateLunch 'Spaggetti bolognaise','Sans accompagnement','2020-10-23';
EXEC dbo.CreateUserLunch 7,1;
EXEC dbo.CreateUserLunch 7,2;
EXEC dbo.CreateUserLunch 7,3;
EXEC dbo.CreateUserLunch 7,4;
EXEC dbo.CreateUserLunch 8,1;
EXEC dbo.CreateUserLunch 8,2;
EXEC dbo.CreateUserLunch 8,3;
EXEC dbo.CreateUserLunch 8,4;
EXEC dbo.CreateUserLunch 9,1;
EXEC dbo.CreateUserLunch 9,2;
EXEC dbo.CreateUserLunch 9,3;
EXEC dbo.CreateUserLunch 9,4;

/*INSERT CATEGORIES*/

EXEC dbo.CreateCategory 'Français';
EXEC dbo.CreateCategory 'Anglais';
EXEC dbo.CreateCategory 'Néerlandais';
EXEC dbo.CreateCategory 'Mathématique';
EXEC dbo.CreateCategory 'Géographie';
EXEC dbo.CreateCategory 'Histoire';

/*INSERT TESTRESULTS*/
						/*STUDENT 1*/
					/*Student 1 / CAT 1*/
EXEC dbo.CreateTestResult '2020-08-24',12, 'test passé avec succès !', 1, 7,null;
EXEC dbo.CreateTestResult '2020-09-24',15, 'test passé avec succès !', 1, 7, null;
EXEC dbo.CreateTestResult '2020-10-24',9, 'test passé avec succès !', 1, 7, null;
EXEC dbo.CreateTestResult '2020-11-24',4, 'test passé avec succès !', 1, 7, null;
EXEC dbo.CreateTestResult '2020-12-24',19, 'test passé avec succès !', 1, 7, null;
					/*Student 1 / CAT 2*/
EXEC dbo.CreateTestResult '2020-08-24',0, 'test passé avec succès !', 2, 7, null;
EXEC dbo.CreateTestResult '2020-09-24',5, 'test passé avec succès !', 2, 7, null;
EXEC dbo.CreateTestResult '2020-10-24',8, 'test passé avec succès !', 2, 7, null;
EXEC dbo.CreateTestResult '2020-11-24',12, 'test passé avec succès !', 2, 7, null;
EXEC dbo.CreateTestResult '2020-12-24',15, 'test passé avec succès !', 2, 7, null;
					/*Student 1 / CAT 3*/
EXEC dbo.CreateTestResult '2020-08-24',20, 'test passé avec succès !', 3, 7, null;
EXEC dbo.CreateTestResult '2020-09-24',16, 'test passé avec succès !', 3, 7, null;
EXEC dbo.CreateTestResult '2020-10-24',14, 'test passé avec succès !', 3, 7, null;
EXEC dbo.CreateTestResult '2020-11-24',12, 'test passé avec succès !', 3, 7, null;
EXEC dbo.CreateTestResult '2020-12-24',15, 'test passé avec succès !', 3, 7, null;
					/*Student 1 / CAT 4*/
EXEC dbo.CreateTestResult '2020-08-24',19, 'test passé avec succès !', 4, 7, null;
EXEC dbo.CreateTestResult '2020-09-24',17, 'test passé avec succès !', 4, 7, null;
EXEC dbo.CreateTestResult '2020-10-24',13, 'test passé avec succès !', 4, 7, null;
EXEC dbo.CreateTestResult '2020-11-24',15, 'test passé avec succès !', 4, 7, null;
EXEC dbo.CreateTestResult '2020-12-24',16, 'test passé avec succès !', 4, 7, null;
					/*Student 1 / CAT 5*/
EXEC dbo.CreateTestResult '2020-08-24',4, 'test passé avec succès !', 5, 7, null;
EXEC dbo.CreateTestResult '2020-09-24',9, 'test passé avec succès !', 5, 7, null;
EXEC dbo.CreateTestResult '2020-10-24',12, 'test passé avec succès !', 5, 7, null;
EXEC dbo.CreateTestResult '2020-11-24',9, 'test passé avec succès !', 5, 7, null;
EXEC dbo.CreateTestResult '2020-12-24',19, 'test passé avec succès !', 5, 7, null;
					/*Student 1 / CAT 6*/
EXEC dbo.CreateTestResult '2020-08-24',0, 'test passé avec succès !', 6, 7, null;
EXEC dbo.CreateTestResult '2020-09-24',5, 'test passé avec succès !', 6, 7, null;
EXEC dbo.CreateTestResult '2020-10-24',8, 'test passé avec succès !', 6, 7, null;
EXEC dbo.CreateTestResult '2020-11-24',9, 'test passé avec succès !', 6, 7, null;
EXEC dbo.CreateTestResult '2020-12-24',4, 'test passé avec succès !', 6, 7, null;

						/*STUDENT 2*/
					/*Student 2 / CAT 1*/
EXEC dbo.CreateTestResult '2020-08-24',0, 'test passé avec succès !', 1, 8, null;
EXEC dbo.CreateTestResult '2020-09-24',20, 'test passé avec succès !', 1, 8, null;
EXEC dbo.CreateTestResult '2020-10-24',15, 'test passé avec succès !', 1, 8, null;
EXEC dbo.CreateTestResult '2020-11-24',12, 'test passé avec succès !', 1, 8, null;
EXEC dbo.CreateTestResult '2020-12-24',17, 'test passé avec succès !', 1, 8, null
					/*Student 2 / CAT 2*/
EXEC dbo.CreateTestResult '2020-08-24',18, 'test passé avec succès !', 2, 8, null;
EXEC dbo.CreateTestResult '2020-09-24',15, 'test passé avec succès !', 2, 8, null;
EXEC dbo.CreateTestResult '2020-10-24',16, 'test passé avec succès !', 2, 8, null;
EXEC dbo.CreateTestResult '2020-11-24',14, 'test passé avec succès !', 2, 8, null;
EXEC dbo.CreateTestResult '2020-12-24',17, 'test passé avec succès !', 2, 8, null;
					/*Student 1 / CAT 3*/
EXEC dbo.CreateTestResult '2020-08-24',12, 'test passé avec succès !', 3, 8, null;
EXEC dbo.CreateTestResult '2020-09-24',13, 'test passé avec succès !', 3, 8, null;
EXEC dbo.CreateTestResult '2020-10-24',14, 'test passé avec succès !', 3, 8, null;
EXEC dbo.CreateTestResult '2020-11-24',15, 'test passé avec succès !', 3, 8, null;
EXEC dbo.CreateTestResult '2020-12-24',18, 'test passé avec succès !', 3, 8, null;
					/*Student 2 / CAT 4*/
EXEC dbo.CreateTestResult '2020-08-24',10, 'test passé avec succès !', 4, 8, null;
EXEC dbo.CreateTestResult '2020-09-24',11, 'test passé avec succès !', 4, 8, null;
EXEC dbo.CreateTestResult '2020-10-24',13, 'test passé avec succès !', 4, 8, null;
EXEC dbo.CreateTestResult '2020-11-24',9, 'test passé avec succès !', 4, 8, null;
EXEC dbo.CreateTestResult '2020-12-24',12, 'test passé avec succès !', 4, 8, null;
					/*Student 2 / CAT 5*/
EXEC dbo.CreateTestResult '2020-08-24',12, 'test passé avec succès !', 5, 8, null;
EXEC dbo.CreateTestResult '2020-09-24',9, 'test passé avec succès !', 5, 8, null;
EXEC dbo.CreateTestResult '2020-10-24',17, 'test passé avec succès !', 5, 8, null;
EXEC dbo.CreateTestResult '2020-11-24',11, 'test passé avec succès !', 5, 8, null;
EXEC dbo.CreateTestResult '2020-12-24',5, 'test passé avec succès !', 5, 8, null;
					/*Student 2 / CAT 6*/
EXEC dbo.CreateTestResult '2020-08-24',0, 'test passé avec succès !', 6, 8, null;
EXEC dbo.CreateTestResult '2020-09-24',5, 'test passé avec succès !', 6, 8, null;
EXEC dbo.CreateTestResult '2020-10-24',8, 'test passé avec succès !', 6, 8, null;
EXEC dbo.CreateTestResult '2020-11-24',9, 'test passé avec succès !', 6, 8, null;
EXEC dbo.CreateTestResult '2020-12-24',4, 'test passé avec succès !', 6, 8, null;

						/*STUDENT 3*/
					/*Student 2 / CAT 1*/
EXEC dbo.CreateTestResult '2020-08-24',8, 'test passé avec succès !', 1, 9, null;
EXEC dbo.CreateTestResult '2020-09-24',4, 'test passé avec succès !', 1, 9, null;
EXEC dbo.CreateTestResult '2020-10-24',12, 'test passé avec succès !', 1, 9, null;
EXEC dbo.CreateTestResult '2020-11-24',19, 'test passé avec succès !', 1, 9, null;
EXEC dbo.CreateTestResult '2020-12-24',9, 'test passé avec succès !', 1, 9, null;
					/*Student 2 / CAT 2*/
EXEC dbo.CreateTestResult '2020-08-24',3, 'test passé avec succès !', 2, 9, null;
EXEC dbo.CreateTestResult '2020-09-24',7, 'test passé avec succès !', 2, 9, null;
EXEC dbo.CreateTestResult '2020-10-24',1, 'test passé avec succès !', 2, 9, null;
EXEC dbo.CreateTestResult '2020-11-24',19, 'test passé avec succès !', 2, 9, null;
EXEC dbo.CreateTestResult '2020-12-24',16, 'test passé avec succès !', 2, 9, null;
					/*Student 1 / CAT 3*/
EXEC dbo.CreateTestResult '2020-08-24',9, 'test passé avec succès !', 3, 9, null;
EXEC dbo.CreateTestResult '2020-09-24',20, 'test passé avec succès !', 3, 9, null;
EXEC dbo.CreateTestResult '2020-10-24',16, 'test passé avec succès !', 3, 9, null;
EXEC dbo.CreateTestResult '2020-11-24',12, 'test passé avec succès !', 3, 9, null;
EXEC dbo.CreateTestResult '2020-12-24',15, 'test passé avec succès !', 3, 9, null;
					/*Student 2 / CAT 4*/
EXEC dbo.CreateTestResult '2020-08-24',10, 'test passé avec succès !', 4, 9, null;
EXEC dbo.CreateTestResult '2020-09-24',11, 'test passé avec succès !', 4, 9, null;
EXEC dbo.CreateTestResult '2020-10-24',13, 'test passé avec succès !', 4, 9, null;
EXEC dbo.CreateTestResult '2020-11-24',9, 'test passé avec succès !', 4, 9, null;
EXEC dbo.CreateTestResult '2020-12-24',12, 'test passé avec succès !', 4, 9, null;
					/*Student 2 / CAT 5*/
EXEC dbo.CreateTestResult '2020-08-24',7, 'test passé avec succès !', 5, 9, null;
EXEC dbo.CreateTestResult '2020-09-24',10, 'test passé avec succès !', 5, 9, null;
EXEC dbo.CreateTestResult '2020-10-24',13, 'test passé avec succès !', 5, 9, null;
EXEC dbo.CreateTestResult '2020-11-24',17, 'test passé avec succès !', 5, 9, null;
EXEC dbo.CreateTestResult '2020-12-24',20, 'test passé avec succès !', 5, 9, null;
					/*Student 2 / CAT 6*/
EXEC dbo.CreateTestResult '2020-08-24',2, 'test passé avec succès !', 6, 9, null;
EXEC dbo.CreateTestResult '2020-09-24',7, 'test passé avec succès !', 6, 9, null;
EXEC dbo.CreateTestResult '2020-10-24',12, 'test passé avec succès !', 6, 9, null;
EXEC dbo.CreateTestResult '2020-11-24',11, 'test passé avec succès !', 6, 9, null;
EXEC dbo.CreateTestResult '2020-12-24',9, 'test passé avec succès !', 6, 9, null;

/*INSERT QUESTIONS*/
/*CAT 4 TRIM 1 SCHOOLYEAR 3eme MAT*/
EXEC dbo.CreateQuestion 'Que fait 2+2 ?','4','2+2 = 4','2 pommes + 1 pomme = ... + 1 pomme = ... ?',null,3,4,1,3, 'Addition';
EXEC dbo.CreateQuestion 'Que fait 3-2 ?','1','3-2 = 1','3 poires - 1 poire = ... - 1 poire = ... ?','3 poires - 1 poire = 2 poires - 1 poire = ... ?',3,4,1,3, 'Soustraction';
EXEC dbo.CreateQuestion 'Quel est la capitale de la Belgique ?','Bruxelles','Bxl','c''est comme les choux de ...',null,3,5,1,3, 'Les Capitales';
EXEC dbo.CreateQuestion 'Quel est la capitale de la France','Paris','Paris','l''endroit où l''on trouve la tour Eifel','leurs supporters disent "... c''est magique"',3,5,1,3, 'Les Capitales';
EXEC dbo.CreateQuestion 'Que fait 7+4 ?','11','7+3 = 10 + 1 = 11','7+4 = ... + 1 = ...','7 + 4 = 10+1 = ...',3,4,1,3, 'Addition';
EXEC dbo.CreateQuestion 'Que fait 12+9 ?','21','12+9 = (12+8) + (9-8) = 21','12+9 = ... + (9-8) = ...','12+9 = 20 + (9-1) = ...',3,4,1,3, 'Addition';
EXEC dbo.CreateQuestion 'Que fait 10-4 ?','6','10-4 = 6','10-4 = (10-2) - ... =  ...',null,3,4,1,3, 'Soustraction';
EXEC dbo.CreateQuestion 'Que fait 47+38 ?','85','47+38 = (40 + 30) + (7 + 8) = 85','47+38 = (40 + ...) + (... + 8) = ... ','47+38 = (40 + 30 + (... + 8) = ... ',3,4,2,3, 'Addition';
EXEC dbo.CreateQuestion 'Quel est la capitale de l''Inde ?','New Delhi','Why not ?','Good Luck:-)','Google can be your best friend',3,5,2,3, 'Les Capitales';
EXEC dbo.CreateQuestion 'Quel est la capite de l''Italie ?','Rome','Rome (en italien : Roma) est la capitale de l''Italie. Située au centre-ouest de la péninsule italienne.','La où pleins de gladiateurs ont combattus dans l''arène','La où vivait les Romains ...',3,5,2,3, 'Les Capitales';
EXEC dbo.CreateQuestion 'Que fait 29+41 ?','70','29+41 = (29+1) + 40 = 70','29+41 = (29+...) + ... = ...','29+41 = (29+1) + ... = ...',3,4,2,3, 'Addition';
EXEC dbo.CreateQuestion 'Que fait 49-11 ?','38','49-11 = (49-10) - 1 = 38','49-11 = (49-...) - ... = ...','49-11 = (49-10-) - ... =',3,4,2,3, 'Soustraction';
EXEC dbo.CreateQuestion 'Quel est la capitale des USA ?','Washington D.C.','Washington, D.C. est la capitale fédérale des États-Unis depuis 1800.','L''endroit où se trouve la maison blanche !','Le président Americain réside dans la maison blanche',3,5,3,3, 'Les Capitales';
EXEC dbo.CreateQuestion 'Quel est la capitale du Canada ?','Ottawa','Why not ?','Good luck','Google can be your best friend',3,5,3,3, 'Les Capitales';
EXEC dbo.CreateQuestion 'Que fait 127+42 ?','169','127+42 = (100+20+40) + (7+2) = 169','127+42 = (100+...+...) + (...+2) = ...','127+42 = (100+...+40) + (...+2) = ...',3,4,3,3, 'Addition';
EXEC dbo.CreateQuestion 'Que fait 143-14 ?','129','143-14 = (143-10) - 4 = 129','143-14 = (143-...) - ... = ...','143-14 = (143-...) - 4 = ...',3,4,3,3, 'Soustraction';

/*INSERT DOCUMENTS*/








