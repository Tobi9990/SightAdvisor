DROP TABLE stadtplan CASCADE CONSTRAINTS;
DROP TABLE stadtplanAdmin CASCADE CONSTRAINTS;
DROP TABLE stadtplanUser CASCADE CONSTRAINTS;
DROP TABLE strassenabschnitt CASCADE CONSTRAINTS;
DROP TABLE sehenswurdigkeit CASCADE CONSTRAINTS;

create table Person( 
Pid number(4) primary key, 
pname varchar(30) 
);

create table Stadtplan( 
Stid number(4) primary key, 
bez varchar(30) 
);

create table stadtplanadmin( 
Pid number(4) primary key, 
pname varchar(30), 
adminrechte varchar(30),
Stid number(4),

foreign key (pid) references Person(Pid), 
foreign key (Stid) references Stadtplan(Stid) 
);

create table stadtplanUser( 
Pid number(4) primary key, 
uname varchar(30), 
userrechte varchar(30),
Stid number(4),

foreign key (pid) references Person(Pid), 
foreign key (Stid) references Stadtplan(Stid) );

create table strassenabschnitt( 
aid number(4) primary key, 
aBezeichnung varchar(30),
Stid number(4),
objekt SDO_GEOMETRY, 

foreign key (Stid) references Stadtplan(Stid) 
);

INSERT INTO user_sdo_geom_metadata
( TABLE_NAME,
COLUMN_NAME,
DIMINFO,
SRID
)
VALUES
( 'strassenabschnitt',
  'objekt',
  SDO_DIM_ARRAY( -- 20X20 grid
  SDO_DIM_ELEMENT('X', 0, 20, 0.005),
  SDO_DIM_ELEMENT('Y', 0, 20, 0.005)
),
NULL -- SRID
);

CREATE INDEX index_strassenabschnitt ON strassenabschnitt(objekt) INDEXTYPE IS MDSYS.SPATIAL_INDEX;

create table sehenswurdigkeit( 
swid number(4) primary key, 
swname varchar(30), 
beschreibung varchar(30),
aid number(4),

foreign key (aid) references strassenabschnitt(aid) 
);

create table sehenswurdigkeit_angesehen( 
pid number(4), 
swid number(4), 
unique (pid, swid),

foreign key (pid) references Person(pid), 
foreign key (swid) references sehenswurdigkeit(swid)
);

-- Person

-- Stadtplan 
Insert Into stadtplan values(1, 'Villach');

-- Person
Insert Into Person values (1, 'Name');
Insert Into Person values (2, 'Name');
Insert Into Person values (3, 'Name');
Insert Into Person values (4, 'Name');

-- Administrator
Insert Into stadtplanadmin values(1, 'Peter', 'Verwaltungsrecht', 1);

-- User
Insert Into stadtplanUser values(1, 'John', 'Anwendungsrecht', 1);
Insert Into stadtplanUser values(2, 'Phillip', 'Anwendungsrecht', 1);
Insert Into stadtplanUser values(3, 'Stefan', 'Anwendungsrecht', 1);
Insert Into stadtplanUser values(4, 'Karl', 'Anwendungsrecht', 1);

-- Strassenabschnitt
--1
INSERT INTO strassenabschnitt VALUES(
  1, 'A1', 1, 
	SDO_GEOMETRY(
		2002,
		NULL,
		NULL,
		SDO_ELEM_INFO_ARRAY(1,2,1), -- compound line string
		SDO_ORDINATE_ARRAY(10,10, 300,10)
	)
);
--2
INSERT INTO strassenabschnitt VALUES(
  2, 'A2', 1, 
	SDO_GEOMETRY(
		2002,
		NULL,
		NULL,
		SDO_ELEM_INFO_ARRAY(1,2,1), -- compound line string
		SDO_ORDINATE_ARRAY(300,10, 450,10)
	)
);
--3
INSERT INTO strassenabschnitt VALUES(
  3, 'A3', 1,
	SDO_GEOMETRY(
		2002,
		NULL,
		NULL,
		SDO_ELEM_INFO_ARRAY(1,2,1), -- compound line string
		SDO_ORDINATE_ARRAY(500,150, 450,10)
	)
);
--4
INSERT INTO strassenabschnitt VALUES(
  4, 'A4', 1,
	SDO_GEOMETRY(
		2002,
		NULL,
		NULL,
		SDO_ELEM_INFO_ARRAY(1,2,1), -- compound line string
		SDO_ORDINATE_ARRAY(300,10, 250,200)
	)
);
--5
INSERT INTO strassenabschnitt VALUES(
  5, 'A5', 1,
	SDO_GEOMETRY(
		2002,
		NULL,
		NULL,
		SDO_ELEM_INFO_ARRAY(1,2,1), -- compound line string
		SDO_ORDINATE_ARRAY(100,200, 250,200)
	)
);
--6
INSERT INTO strassenabschnitt VALUES(
  6, 'A6', 1,
	SDO_GEOMETRY(
		2002,
		NULL,
		NULL,
		SDO_ELEM_INFO_ARRAY(1,2,1), -- compound line string
		SDO_ORDINATE_ARRAY(10,10, 100,200)
	)
);
--7
INSERT INTO strassenabschnitt VALUES(
  7, 'A7', 1,
	SDO_GEOMETRY(
		2002,
		NULL,
		NULL,
		SDO_ELEM_INFO_ARRAY(1,2,1), -- compound line string
		SDO_ORDINATE_ARRAY(300,300, 250,200)
	)
);

--8
INSERT INTO strassenabschnitt VALUES(
  8, 'A8', 1,
	SDO_GEOMETRY(
		2002,
		NULL,
		NULL,
		SDO_ELEM_INFO_ARRAY(1,2,1), -- compound line string
		SDO_ORDINATE_ARRAY(400,200, 300,300)
	)
);
--9
INSERT INTO strassenabschnitt VALUES(
  9, 'A9', 1,
	SDO_GEOMETRY(
		2002,
		NULL,
		NULL,
		SDO_ELEM_INFO_ARRAY(1,2,1), -- compound line string
		SDO_ORDINATE_ARRAY(400,200, 350,1000)
	)
);
--10
INSERT INTO strassenabschnitt VALUES(
  10, 'A10', 1,
	SDO_GEOMETRY(
		2002,
		NULL,
		NULL,
		SDO_ELEM_INFO_ARRAY(1,2,1), -- compound line string
		SDO_ORDINATE_ARRAY(500,150, 400,200)
	)
);

-- Sehenswürdigkeiten
Insert Into sehenswurdigkeit values (1, 'S1', 'Beschreibung', 1);
Insert Into sehenswurdigkeit values (2, 'S2', 'Beschreibung', 10);

SELECT * FROM sehenswurdigkeit
WHERE swid = (
    SELECT MAX(swid) FROM sehenswurdigkeit);  

Select * from stadtplan;
Select * from stadtplanAdmin;
Select * from stadtplanUser;
Select * from strassenabschnitt;
Select * from sehenswurdigkeit;
