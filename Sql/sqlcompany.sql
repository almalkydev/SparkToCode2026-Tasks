/*part 1 db creation */

IF DB_ID('CompanyDB') IS NOT NULL
BEGIN
    ALTER DATABASE CompanyDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE CompanyDB;
END
GO

CREATE DATABASE CompanyDB;
GO

USE CompanyDB;
GO


/* part 1&2 table constarts */


CREATE TABLE Department (
    Dnumber            INT             NOT NULL,
    Dname              VARCHAR(30)     NOT NULL,
    Mgr_ssn            CHAR(9)         NULL,     
    Mgr_start_date     DATE            NULL DEFAULT GETDATE(),
    NumberOfEmployees  INT             NOT NULL DEFAULT 0,
    CONSTRAINT PK_Department PRIMARY KEY (Dnumber),
    CONSTRAINT UQ_Department_Name UNIQUE (Dname)
);
GO

CREATE TABLE Employee (
    Ssn         CHAR(9)         NOT NULL,
    Fname       VARCHAR(20)     NOT NULL,
    Minit       CHAR(1)         NULL,
    Lname       VARCHAR(20)     NOT NULL,
    Address     VARCHAR(100)    NULL,
    Sex         CHAR(1)         NOT NULL,
    Bdate       DATE            NULL,
    Salary      DECIMAL(10,2)   NOT NULL,
    Super_ssn   CHAR(9)         NULL,       
    Dno         INT             NOT NULL,   
    CONSTRAINT PK_Employee PRIMARY KEY (Ssn),
    CONSTRAINT CK_Employee_Sex CHECK (Sex IN ('M','F')),
    CONSTRAINT CK_Employee_Salary CHECK (Salary > 0),
    CONSTRAINT FK_Employee_Supervisor FOREIGN KEY (Super_ssn)
        REFERENCES Employee(Ssn),
    CONSTRAINT FK_Employee_Department FOREIGN KEY (Dno)
        REFERENCES Department(Dnumber)
);
GO

ALTER TABLE Department
    ADD CONSTRAINT FK_Department_Manager FOREIGN KEY (Mgr_ssn)
        REFERENCES Employee(Ssn);
GO

CREATE TABLE Dept_Locations (
    Dnumber     INT             NOT NULL,
    Dlocation   VARCHAR(30)     NOT NULL,
    CONSTRAINT PK_Dept_Locations PRIMARY KEY (Dnumber, Dlocation),
    CONSTRAINT FK_DeptLocations_Department FOREIGN KEY (Dnumber)
        REFERENCES Department(Dnumber) ON DELETE CASCADE
);
GO

CREATE TABLE Project (
    Pnumber     INT             NOT NULL,
    Pname       VARCHAR(30)     NOT NULL,
    Plocation   VARCHAR(30)     NULL,
    Dnum        INT             NOT NULL,   
    CONSTRAINT PK_Project PRIMARY KEY (Pnumber),
    CONSTRAINT UQ_Project_Name UNIQUE (Pname),
    CONSTRAINT FK_Project_Department FOREIGN KEY (Dnum)
        REFERENCES Department(Dnumber)
);
GO


CREATE TABLE Works_On (
    Essn    CHAR(9)         NOT NULL,
    Pno     INT             NOT NULL,
    Hours   DECIMAL(4,1)    NOT NULL,
    CONSTRAINT PK_Works_On PRIMARY KEY (Essn, Pno),
    CONSTRAINT CK_WorksOn_Hours CHECK (Hours > 0),
    CONSTRAINT FK_WorksOn_Employee FOREIGN KEY (Essn)
        REFERENCES Employee(Ssn) ON DELETE CASCADE,
    CONSTRAINT FK_WorksOn_Project FOREIGN KEY (Pno)
        REFERENCES Project(Pnumber)
);
GO

CREATE TABLE Dependent (
    Essn            CHAR(9)         NOT NULL,
    Dependent_name  VARCHAR(30)     NOT NULL,   
    Sex             CHAR(1)         NULL,
    Bdate           DATE            NULL,
    Relationship    VARCHAR(20)     NULL,
    CONSTRAINT PK_Dependent PRIMARY KEY (Essn, Dependent_name),
    CONSTRAINT CK_Dependent_Sex CHECK (Sex IN ('M','F')),
    CONSTRAINT FK_Dependent_Employee FOREIGN KEY (Essn)
        REFERENCES Employee(Ssn) ON DELETE CASCADE
);
GO


INSERT INTO Department (Dnumber, Dname) VALUES
    (1, 'Research'),
    (2, 'Administration');

INSERT INTO Employee (Ssn, Fname, Minit, Lname, Address, Sex, Bdate, Salary, Super_ssn, Dno) VALUES
    ('111111111', 'Ahmed',   'S', 'Al-Almalki',  'Al Ansab, Muscat, Oman',   'M', '1965-01-09', 55000.00, NULL,        1),
    ('222222222', 'Salim',   'M', 'Al-Harthy',   'Ruwi, Muscat, Oman',         'M', '1975-12-08', 40000.00, '111111111', 1),
    ('333333333', 'Fatma',   'A', 'Al-Kindi',    'Seeb, Muscat, Oman',         'F', '1988-07-19', 25000.00, '111111111', 2),
    ('444444444', 'Mariam',  'H', 'Al-Riyami',   'Al Khoud, Muscat, Oman',     'F', '1971-06-20', 43000.00, '111111111', 2),
    ('555555555', 'Yousuf',  'K', 'Al-Habsi',    'Bausher, Muscat, Oman',      'M', '1992-09-15', 38000.00, '222222222', 1);
	
	
INSERT INTO Project (Pnumber, Pname, Plocation, Dnum) VALUES
    (1, 'ProductX', 'Bellaire',  1),
    (2, 'ProductY', 'Sugarland', 2);

INSERT INTO Works_On (Essn, Pno, Hours) VALUES
    ('222222222', 1, 20.0),
    ('555555555', 1, 30.0),
    ('333333333', 2, 15.5);

INSERT INTO Dependent (Essn, Dependent_name, Sex, Bdate, Relationship) VALUES
    ('222222222', 'Aya', 'F', '2005-04-05', 'Daughter'),
    ('555555555', 'Malak', 'F', '2018-02-11', 'Daughter');

-- bootstrap step: now that employees exist, give each department a manager
-- (not counted as part of the 5 required updates below)
UPDATE Department SET Mgr_ssn = '111111111', Mgr_start_date = '2010-05-01' WHERE Dnumber = 1;
UPDATE Department SET Mgr_ssn = '444444444', Mgr_start_date = '2012-08-15' WHERE Dnumber = 2;
GO


UPDATE Employee
SET Salary = Salary + 3000.00
WHERE Ssn = '555555555';


UPDATE Employee
SET Dno = 2
WHERE Ssn = '333333333';


UPDATE Project
SET Plocation = 'Muscat'
WHERE Pnumber = 2;

UPDATE Works_On
SET Hours = 25.0
WHERE Essn = '222222222' AND Pno = 1;


UPDATE Dependent
SET Relationship = 'Spouse'
WHERE Essn = '222222222' AND Dependent_name = 'Amna';
GO



DELETE FROM Employee WHERE Ssn = '555555555';


SELECT * FROM Dependent  WHERE Essn = '555555555';
SELECT * FROM Works_On   WHERE Essn = '555555555';


BEGIN TRY
    DELETE FROM Department WHERE Dnumber = 2;
END TRY
BEGIN CATCH
    PRINT 'Delete blocked as expected: ' + ERROR_MESSAGE();
    PRINT 'Department 2 still has employees assigned to it (FK constraint), so it cannot be deleted until they are reassigned or removed first.';
END CATCH
GO