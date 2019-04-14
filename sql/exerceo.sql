/* CREATE TABLE User (
    username CHAR(50) PRIMARY KEY, 
    userPassword CHAR(50) NOT NULL, 
    userEmail CHAR(50), 
    userDOB DATE
); */

CREATE TABLE dbo.UserLogin (
    username varCHAR(50) PRIMARY KEY, 
    userPassword VARCHAR(50) NOT NULL, 
    userEmail VARCHAR(50), 
    userDOB DATE
);

CREATE TABLE Enroll (
    username CHAR(50), 
    courseNum CHAR(7),
    PRIMARY KEY (username, courseNum),
    FOREIGN KEY (username) REFERENCES User ON DELETE CASCADE, /* We need to verify ON DELETE and ON UPDATE constraints */
    FOREIGN KEY (courseNum) REFERENCES Enroll ON DELETE CASCADE /* We need to verify ON DELETE and ON UPDATE constraints */
);

CREATE TABLE Course {
    courseNum CHAR(7) PRIMARY KEY,
    courseName CHAR(50) NOT NULL,
    courseDescription CHAR(150), 

}

CREATE TABLE Score {
    username CHAR(50) PRIMARY KEY, 
    score NUMBER(12) DEFAULT 0, 
}