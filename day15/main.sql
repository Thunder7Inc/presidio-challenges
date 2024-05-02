-- Creating the EMP table without foreign key constraints
CREATE TABLE EMP (
    empno INTEGER PRIMARY KEY,
    empname VARCHAR(255),
    salary INTEGER,
    deptname VARCHAR(255),
    bossno INTEGER
);

-- Creating the ITEM table
CREATE TABLE ITEM (
    itemname VARCHAR(255) PRIMARY KEY,
    itemtype CHAR(1),
    itemcolor VARCHAR(255)
);

-- Creating the DEPARTMENT table
CREATE TABLE DEPARTMENT (
    deptname VARCHAR(255) PRIMARY KEY,
    floor INTEGER,
    phone INTEGER,
    mgrId INTEGER NOT NULL,
    FOREIGN KEY (mgrId) REFERENCES EMP(empno)
);

-- Adding foreign key constraints to EMP
ALTER TABLE EMP
ADD CONSTRAINT fk_deptname FOREIGN KEY (deptname) REFERENCES DEPARTMENT(deptname),
ADD CONSTRAINT fk_bossno FOREIGN KEY (bossno) REFERENCES EMP(empno);

-- Creating the SALES table
CREATE TABLE SALES (
    salesno INTEGER PRIMARY KEY,
    saleqty INTEGER,
    itemname VARCHAR(255) NOT NULL,
    deptname VARCHAR(255) NOT NULL,
    FOREIGN KEY (itemname) REFERENCES ITEM(itemname),
    FOREIGN KEY (deptname) REFERENCES DEPARTMENT(deptname)
);
