INSERT INTO Professors (NationalNumber, LastName, FirstName, Birthdate, AdCity, AdPostalCode, 
						AdStreet, AdNumber, AdBox, MobilePhone, [Login],[Password], Gender,
						Photo, PersonalNote, StartDate, EndDate, FirstLogin, Email, IsActive) 
	VALUES
	('592-3924660-24', 'Clarke', 'Emilia', '1988-12-25', 'Sart-Dames-Avelines', 1495, 
	'Rue du Try', 20,'D','+32477469214', 'EClarke',HASHBYTES('SHA2_512',dbo.PreSalt()+'test1234='+dbo.PostSalt()), 'F', 
	'https://media.virginradio.fr/article-3808966-head-f10/emilia-clarke-photoshoot.jpg', 
	'Très bon Feedback de la part des élèves.', '2015-09-01', null, '2015-09-01', 'EmiliaClark@daenerysTargaryen.com', 1),

	('592-3924660-24', 'Swann', 'Elisabeth', '1985-03-26', 'Marbais', 1495,
	'Rue du Black Pearl', 1, null, '+32485421546', 'ESwann', HASHBYTES('SHA2_512',dbo.PreSalt()+'test1234='+dbo.PostSalt()), 'F',
	'https://vignette.wikia.nocookie.net/lemondededisney/images/8/85/Elizabeth_Swann_Headshot.jpg/revision/latest?cb=20161220132134&path-prefix=fr',
	null, '2016-09-01', null, '2016-09-02', 'ElisabethSwann@blackpearl.com', 1),

	('592-3924660-24', 'Miller', 'John', '1967-10-12', 'Villers-La-Ville', 1495,
	'Route d''Omaha Beach', 47, 'C', '+32496547845', 'JMiller', HASHBYTES('SHA2_512',dbo.PreSalt()+'test1234='+dbo.PostSalt()), 'M',
	'https://vignette.wikia.nocookie.net/savingprivateryan/images/9/95/Miller.jpg/revision/latest?cb=20160412130225',
	'A de grande aptitudes à mener une classe au front', '2000-09-01', '2018-06-06', '2000-09-02', 'JohnMilleur@doggreen.be', 0),

	('592-3924660-24', 'Everdeen', 'Katniss', '1996-07-02', 'Bruxelles', 1000, 
	'Chemin du District', 12, null, '+32465521489', 'KEverdeen',HASHBYTES('SHA2_512',dbo.PreSalt()+'test1234='+dbo.PostSalt()), 'F',
	'https://vignette.wikia.nocookie.net/hungergamesfrance/images/4/42/Jennifer-lawrence-interprete-katniss-everdeen.jpg/revision/latest?cb=20150830195605&path-prefix=fr',
	'Sait unir les élèves dans une cours de récréation', '2018-09-01', null, '2018-09-02','KatnissEverdeen@mokingJay.com', 1),

	('592-21457845-24', 'Proudmoore','Jaina', '1975-04-01', 'Dalaran', 4541, 
	'Port de Theramore', 427, null,	'+64451223568', 'JProudmoore', HASHBYTES('SHA2_512',dbo.PreSalt()+'test1234='+dbo.PostSalt()), 'F',
	'https://cogconnected.com/wp-content/uploads/2020/03/JainaProudmooreWOW.2-1024x680.jpg',
	null, '2010-09-01', null, '2010-09-02', 'JainaProudmoore@Azeroth.com',1);


INSERT INTO Classes (ClassName, ClassInfos, ProfessorId) 
	VALUES
	('1A', '', 1),
	('2A', '', 2),
	('3A', '', 4),
	('4A', '', 5);