CREATE TABLE User (
    username CHAR(50) PRIMARY KEY, 
    userPassword CHAR(50) NOT NULL
)

CREATE TABLE Enroll (
    username CHAR(50), 
    courseNum CHAR(7),
    PRIMARY KEY (username, courseNum),
    FOREIGN KEY (username) REFERENCES User ON DELETE CASCADE, 
    FOREIGN KEY (courseNum) REFERENCES Enroll ON DELETE CASCADE
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