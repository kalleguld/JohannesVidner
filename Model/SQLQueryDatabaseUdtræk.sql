﻿USE [JohannesVidner];
GO


INSERT INTO PublicationSet (Name,ShortName) VALUES ('VisioLink','visiolink');

INSERT INTO PublicationSet (Name,ParentPublicationId,ShortName) VALUES 
	('Mhn',1,'mhn'),
	('Shz',2,'shzmain'),
	('Der Insel-Bote',3,'derinselbote'),
	('Eckernförder Zeitung',3,'eckernforderzeitung'),
	('Flensburger Tageblatt',3,'flensburgertageblatt'),
	('Norddeutsche Rundschau',3,'norddeutscherundschau');

INSERT INTO EditionSet (RunningStarted,MaxMissingPages,Running,LogText,ErrorMessage,PublicationId, NumberOfPages, LastLogCheck, CurrentStatus) VALUES 
	(
		'2014-11-16 22:39:41',
		2,
		0,
		'Checking: flensburgertageblatt\nLog generated: 2014-11-16 22:39\nUsing XML to determine run date\nNext release version - for current run_date: 1\n\nSkipping (flensburgertageblatt_20141107.xml): xml->releaseversion: 2\nSkipping (flensburgertageblatt_20141111.xml): xml->releaseversion: 2\nSkipping (flensburgertageblatt_20141108.xml): xml->releaseversion: 1\nSkipping (flensburgertageblatt_20141106.xml): xml->releaseversion: 1\nflensburgertageblatt_20141117.xml triggers a run - new run date from xml 2014-11-17:\n<?xml version=\"1.0\" encoding=\"UTF-8\"?><data><pdfdate>17.11.14<\/pdfdate><releasedate>17.11.14<\/releasedate><releasetime>00:01<\/releasetime><pages><\/pages><releaseversion>1<\/releaseversion><\/data>\nrelease_version for new run date: 1\nCopying 28 files "\/data\/ftp\/upload_shzmain\/FLT" => "\/data\/ftp\/upload_shzmain\/FLT_current"\nFLT_20141117_s01_p001.pdf => flensburgertageblatt_20141117_s01_p001.pdf\nFLT_20141117_s01_p002.pdf => flensburgertageblatt_20141117_s01_p002.pdf\nFLT_20141117_s01_p003.pdf => flensburgertageblatt_20141117_s01_p003.pdf\nFLT_20141117_s01_p004.pdf => flensburgertageblatt_20141117_s01_p004.pdf\nFLT_20141117_s01_p005.pdf => flensburgertageblatt_20141117_s01_p005.pdf\nFLT_20141117_s01_p006.pdf => flensburgertageblatt_20141117_s01_p006.pdf\nFLT_20141117_s01_p007.pdf => flensburgertageblatt_20141117_s01_p007.pdf\nFLT_20141117_s01_p008.pdf => flensburgertageblatt_20141117_s01_p008.pdf\nFLT_20141117_s02_p009.pdf => flensburgertageblatt_20141117_s02_p001.pdf\nFLT_20141117_s02_p010.pdf => flensburgertageblatt_20141117_s02_p002.pdf\nFLT_20141117_s02_p011.pdf => flensburgertageblatt_20141117_s02_p003.pdf\nFLT_20141117_s02_p012.pdf => flensburgertageblatt_20141117_s02_p004.pdf\nFLT_20141117_s02_p013.pdf => flensburgertageblatt_20141117_s02_p005.pdf\nFLT_20141117_s02_p014.pdf => flensburgertageblatt_20141117_s02_p006.pdf\nFLT_20141117_s03_p015.pdf => flensburgertageblatt_20141117_s03_p001.pdf\nFLT_20141117_s03_p016.pdf => flensburgertageblatt_20141117_s03_p002.pdf\nFLT_20141117_s03_p017.pdf => flensburgertageblatt_20141117_s03_p003.pdf\nFLT_20141117_s03_p018.pdf => flensburgertageblatt_20141117_s03_p004.pdf\nFLT_20141117_s03_p019.pdf => flensburgertageblatt_20141117_s03_p005.pdf\nFLT_20141117_s03_p020.pdf => flensburgertageblatt_20141117_s03_p006.pdf\nFLT_20141117_s03_p021.pdf => flensburgertageblatt_20141117_s03_p007.pdf\nFLT_20141117_s03_p022.pdf => flensburgertageblatt_20141117_s03_p008.pdf\nFLT_20141117_s04_p023.pdf => flensburgertageblatt_20141117_s04_p001.pdf\nFLT_20141117_s04_p024.pdf => flensburgertageblatt_20141117_s04_p002.pdf\nFLT_20141117_s04_p025.pdf => flensburgertageblatt_20141117_s04_p003.pdf\nFLT_20141117_s04_p026.pdf => flensburgertageblatt_20141117_s04_p004.pdf\nFLT_20141117_s04_p027.pdf => flensburgertageblatt_20141117_s04_p005.pdf\nFLT_20141117_s04_p028.pdf => flensburgertageblatt_20141117_s04_p006.pdf\nSuccess - catalog was queued for generation\n\n',
		'Success catalog queued for 2014-11-17 release version 1',
		6,
		28,
		'2014-11-16 23:08:41',
		3
	),
	(
		'2014-11-16 22:45:52',
		1,
		0,
		'Checking: eckernförderzeitung\nLog generated: 2014-11-16 22:39\nUsing XML to determine run date\nNext release version - for current run_date: 1\n\nSkipping (eckernförderzeitung_20141107.xml): xml->releaseversion: 2\nSkipping (eckernförderzeitung_20141111.xml): xml->releaseversion: 2\nSkipping (eckernförderzeitung_20141108.xml): xml->releaseversion: 1\nSkipping (eckernförderzeitung_20141106.xml): xml->releaseversion: 1\neckernförderzeitung_20141117.xml triggers a run - new run date from xml 2014-11-17:\n<?xml version=\"1.0\" encoding=\"UTF-8\"?><data><pdfdate>17.11.14<\/pdfdate><releasedate>17.11.14<\/releasedate><releasetime>00:01<\/releasetime><pages><\/pages><releaseversion>1<\/releaseversion><\/data>\nrelease_version for new run date: 1\nCopying 28 files "\/data\/ftp\/upload_shzmain\/FLT" => "\/data\/ftp\/upload_shzmain\/FLT_current"\nFLT_20141117_s01_p001.pdf => eckernförderzeitung_20141117_s01_p001.pdf\nFLT_20141117_s01_p002.pdf => eckernförderzeitung_20141117_s01_p002.pdf\nFLT_20141117_s01_p003.pdf => eckernförderzeitung_20141117_s01_p003.pdf\nFLT_20141117_s01_p004.pdf => eckernförderzeitung_20141117_s01_p004.pdf\nFLT_20141117_s01_p005.pdf => eckernförderzeitung_20141117_s01_p005.pdf\nFLT_20141117_s01_p006.pdf => eckernförderzeitung_20141117_s01_p006.pdf\nFLT_20141117_s01_p007.pdf => eckernförderzeitung_20141117_s01_p007.pdf\nFLT_20141117_s01_p008.pdf => eckernförderzeitung_20141117_s01_p008.pdf\nFLT_20141117_s02_p009.pdf => eckernförderzeitung_20141117_s02_p001.pdf\nFLT_20141117_s02_p010.pdf =>eckernförderzeitung_20141117_s02_p002.pdf\nFLT_20141117_s02_p011.pdf => eckernförderzeitung_20141117_s02_p003.pdf\nFLT_20141117_s02_p012.pdf => eckernförderzeitung_20141117_s02_p004.pdf\nFLT_20141117_s02_p013.pdf => eckernförderzeitung_20141117_s02_p005.pdf\nFLT_20141117_s02_p014.pdf => eckernförderzeitung_20141117_s02_p006.pdf\nFLT_20141117_s03_p015.pdf => eckernförderzeitung_20141117_s03_p001.pdf\nFLT_20141117_s03_p016.pdf => eckernförderzeitung_20141117_s03_p002.pdf\nFLT_20141117_s03_p017.pdf => eckernförderzeitung_20141117_s03_p003.pdf\nFLT_20141117_s03_p018.pdf => eckernförderzeitung_20141117_s03_p004.pdf\nFLT_20141117_s03_p019.pdf => eckernförderzeitung_20141117_s03_p005.pdf\nFLT_20141117_s03_p020.pdf => eckernförderzeitung_20141117_s03_p006.pdf\nFLT_20141117_s03_p021.pdf => eckernförderzeitung_20141117_s03_p007.pdf\nFLT_20141117_s03_p022.pdf => eckernförderzeitung_20141117_s03_p008.pdf\nFLT_20141117_s04_p023.pdf => eckernförderzeitung_20141117_s04_p001.pdf\nFLT_20141117_s04_p024.pdf => eckernförderzeitung_20141117_s04_p002.pdf\nFLT_20141117_s04_p025.pdf => eckernförderzeitung_20141117_s04_p003.pdf\nFLT_20141117_s04_p026.pdf => eckernförderzeitung_20141117_s04_p004.pdf\nFLT_20141117_s04_p027.pdf => eckernförderzeitung_20141117_s04_p005.pdf\nFLT_20141117_s04_p028.pdf => eckernförderzeitung_20141117_s04_p006.pdf\nSuccess - catalog was queued for generation\n\n',
		'Failed for 2014-11-17 release version 1, Too many pages missing',
		5,
		25,
		'2014-11-17 01:32:25',
		4
	),
	(
		'2014-11-16 23:39:10',
		0,
		1,
		'Checking: derinselbote\nLog generated: 2014-11-16 22:39\nUsing XML to determine run date\nNext release version - for current run_date: 1\n\nSkipping (derinselbote _20141107.xml): xml->releaseversion: 2\nSkipping (derinselbote _20141111.xml): xml->releaseversion: 2\nSkipping (derinselbote _20141108.xml): xml->releaseversion: 1\nSkipping (derinselbote _20141106.xml): xml->releaseversion: 1\ derinselbote _20141117.xml triggers a run - new run date from xml 2014-11-17:\n<?xml version=\"1.0\" encoding=\"UTF-8\"?><data><pdfdate>17.11.14<\/pdfdate><releasedate>17.11.14<\/releasedate><releasetime>00:01<\/releasetime><pages><\/pages><releaseversion>1<\/releaseversion><\/data>\nrelease_version for new run date: 1\nCopying 28 files "\/data\/ftp\/upload_shzmain\/FLT" => "\/data\/ftp\/upload_shzmain\/FLT_current"\nFLT_20141117_s01_p001.pdf => derinselbote _20141117_s01_p001.pdf\nFLT_20141117_s01_p002.pdf => derinselbote _20141117_s01_p002.pdf\nFLT_20141117_s01_p003.pdf => derinselbote _20141117_s01_p003.pdf\nFLT_20141117_s01_p004.pdf => derinselbote _20141117_s01_p004.pdf\nFLT_20141117_s01_p005.pdf => derinselbote _20141117_s01_p005.pdf\nFLT_20141117_s01_p006.pdf => derinselbote _20141117_s01_p006.pdf\nFLT_20141117_s01_p007.pdf => derinselbote _20141117_s01_p007.pdf\nFLT_20141117_s01_p008.pdf => derinselbote _20141117_s01_p008.pdf\nFLT_20141117_s02_p009.pdf => derinselbote _20141117_s02_p001.pdf\nFLT_20141117_s02_p010.pdf => derinselbote _20141117_s02_p002.pdf\nFLT_20141117_s02_p011.pdf => derinselbote _20141117_s02_p003.pdf\nFLT_20141117_s02_p012.pdf => derinselbote _20141117_s02_p004.pdf\nFLT_20141117_s02_p013.pdf => derinselbote _20141117_s02_p005.pdf\nFLT_20141117_s02_p014.pdf => derinselbote _20141117_s02_p006.pdf\nFLT_20141117_s03_p015.pdf => derinselbote _20141117_s03_p001.pdf\nFLT_20141117_s03_p016.pdf => derinselbote _20141117_s03_p002.pdf\nFLT_20141117_s03_p017.pdf => derinselbote _20141117_s03_p003.pdf\nFLT_20141117_s03_p018.pdf => derinselbote _20141117_s03_p004.pdf\nFLT_20141117_s03_p019.pdf => derinselbote _20141117_s03_p005.pdf\nFLT_20141117_s03_p020.pdf => derinselbote _20141117_s03_p006.pdf\nFLT_20141117_s03_p021.pdf => derinselbote _20141117_s03_p007.pdf\nFLT_20141117_s03_p022.pdf => derinselbote _20141117_s03_p008.pdf\nFLT_20141117_s04_p023.pdf => derinselbote _20141117_s04_p001.pdf\nFLT_20141117_s04_p024.pdf => derinselbote _20141117_s04_p002.pdf\nFLT_20141117_s04_p025.pdf => derinselbote _20141117_s04_p003.pdf...\n',
		'Running...',
		4,
		28,
		'2014-11-16 23:49:10',
		1
	);

INSERT INTO EditionSet (RunningStarted,MaxMissingPages,Running,LogText,ErrorMessage,PublicationId, NumberOfPages, LastLogCheck, ExpectedReleaseTime, CurrentStatus) VALUES 
	(
		'2014-11-16 23:02:21',
		0,
		0,
		'Checking: norddeutscherundschau\nLog generated: 2014-11-16 22:39\nUsing XML to determine run date\nNext release version - for current run_date: 1\n\nSkipping (norddeutscherundschau_20141107.xml): xml->releaseversion: 2\nSkipping (norddeutscherundschau_20141111.xml): xml->releaseversion: 2\nSkipping (norddeutscherundschau_20141108.xml): xml->releaseversion: 1\nSkipping (norddeutscherundschau_20141106.xml): xml->releaseversion: 1\nnorddeutscherundschau_20141117.xml triggers a run - new run date from xml 2014-11-17:\n<?xml version=\"1.0\" encoding=\"UTF-8\"?><data><pdfdate>17.11.14<\/pdfdate><releasedate>17.11.14<\/releasedate><releasetime>00:01<\/releasetime><pages><\/pages><releaseversion>1<\/releaseversion><\/data>\nrelease_version for new run date: 1\nCopying 28 files “\/data\/ftp\/upload_shzmain\/FLT”=>”\/data\/ftp\/upload_shzmain\/FLT_current”\nFLT_20141117_s01_p001.pdf => norddeutscherundschau_20141117_s01_p001.pdf\nFLT_20141117_s01_p002.pdf => norddeutscherundschau_20141117_s01_p002.pdf\nFLT_20141117_s01_p003.pdf => norddeutscherundschau_20141117_s01_p003.pdf\nFLT_20141117_s01_p004.pdf => norddeutscherundschau_20141117_s01_p004.pdf\nFLT_20141117_s01_p005.pdf => norddeutscherundschau_20141117_s01_p005.pdf\nFLT_20141117_s01_p006.pdf => norddeutscherundschau_20141117_s01_p006.pdf\nFLT_20141117_s01_p007.pdf => norddeutscherundschau_20141117_s01_p007.pdf\nFLT_20141117_s01_p008.pdf => norddeutscherundschau_20141117_s01_p008.pdf\nFLT_20141117_s02_p009.pdf => norddeutscherundschau_20141117_s02_p001.pdf\nFLT_20141117_s02_p010.pdf => norddeutscherundschau_20141117_s02_p002.pdf\nFLT_20141117_s02_p011.pdf => norddeutscherundschau_20141117_s02_p003.pdf\nFLT_20141117_s02_p012.pdf => norddeutscherundschau_20141117_s02_p004.pdf\nFLT_20141117_s02_p013.pdf => norddeutscherundschau_20141117_s02_p005.pdf\nFLT_20141117_s02_p014.pdf => norddeutscherundschau_20141117_s02_p006.pdf\nFLT_20141117_s03_p015.pdf => norddeutscherundschau_20141117_s03_p001.pdf\nFLT_20141117_s03_p016.pdf => norddeutscherundschau_20141117_s03_p002.pdf\nFLT_20141117_s03_p017.pdf => norddeutscherundschau_20141117_s03_p003.pdf\nFLT_20141117_s03_p018.pdf => norddeutscherundschau_20141117_s03_p004.pdf\nFLT_20141117_s03_p019.pdf => norddeutscherundschau_20141117_s03_p005.pdf\nFLT_20141117_s03_p020.pdf => norddeutscherundschau_20141117_s03_p006.pdf\nFLT_20141117_s03_p021.pdf => norddeutscherundschau_20141117_s03_p007.pdf\nFLT_20141117_s03_p022.pdf => norddeutscherundschau_20141117_s03_p008.pdf\nFLT_20141117_s04_p023.pdf => norddeutscherundschau_20141117_s04_p001.pdf\nFLT_20141117_s04_p024.pdf => norddeutscherundschau_20141117_s04_p002.pdf\nFLT_20141117_s04_p025.pdf => norddeutscherundschau_20141117_s04_p003.pdf\nFLT_20141117_s04_p026.pdf => norddeutscherundschau_20141117_s04_p004.pdf\nFLT_20141117_s04_p027.pdf => norddeutscherundschau_20141117_s04_p005.pdf\nFLT_20141117_s04_p028.pdf => norddeutscherundschau_20141117_s04_p006.pdf\nSuccess - catalog was queued for generation\n\n',
		'Success catalog queued for 2014-11-17 release version 1',
		7,
		28,
		'2014-11-16 23:30:24','2014-11-17 03:00:00',
		2
	);


INSERT INTO UserSet (Username,PasswordText,Name,WriteAccess,UserAdminAccess,PublicationId,CultureName) VALUES 
	('VisioLinkAdmin','1234','VisioLink administrator',1,1,1,'da'),
	('MhnAdmin','1234','Mhn administrator',1,1,2, 'de'),
	('MhnManager','1234','Mhn manager',1,0,2, 'de'),
	('MhnWorker','1234','Mhn sequrity worker',0,0,2,'de'),
	('ShzAdmin','1234','Shz administrator',1,1,3,'en'),
	('ShzManager','1234','Shz manager',1,0,3,'en'),
	('ShzWorker','1234','Shz sequrity worker',0,0,3,'en'),
	('DerInselBoteAdmin','1234','Der Insel-Bote administrator',1,1,4,''),
	('DerInselBoteManager','1234','Der Insel-Bote manager',1,0,4,''),
	('DerInselBoteWorker','1234','Der Insel-Bote sequrity worker',0,0,4,''),
	('FlensburgerTageblattAdmin','1234','Flensburger Tageblatt administrator',1,1,6,'de'),
	('FlensburgerTageblattManager','1234','Flensburger Tageblatt manager',1,0,6,'de'),
	('FlensburgerTageblattWorker','1234','Flensburger Tageblatt sequrity worker',0,0,6,'de'),
	('asd','1234','asd administrator',1,1,1,'da');

INSERT INTO PageSet (Section,PageNumber,EditionId) VALUES 
	(2,3,2),
	(3,1,2),
	(4,5,2);
