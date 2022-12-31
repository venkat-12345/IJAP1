CREATE DATABASE "EmpSkillDB";

\c "EmpSkillDB"
CREATE TABLE "EmpSkill"(
"EmpId" CHAR(4) REFERENCES "Employee"("EmpId"),
"SkillId" CHAR(4) REFERENCES "Skill"("SkillId"),
"Experience" INT NOT NULL,
PRIMARY KEY("EmpId","SkillId")
);
CREATE TABLE "Employee"(
"EmpId" CHAR(4) Primary key
);
CREATE TABLE "Skill"(
"SkillId" CHAR(4) Primary key
);

 

CREATE DATABASE "JobPostDB"

\c "JobPostDB"

 

 

CREATE TABLE "JobPost"(
"PostId" INT GENERATED ALWAYS AS IDENTITY Primary Key,
"JobId" CHAR(4) REFERENCES "Job"("JobId"),
"DateOfPost" DATE NOT NULL,
"LastDateToApply" DATE NOT NULL,
"Vacancies" INT NOT NULL
)

CREATE TABLE "Job"(
"JobId" CHAR(4) Primary Key

)

//EmpPost
create table "Employee"(
    "EmpId" char(4) primary key
);
create table "JobPost"(
    "PostId" int primary key
);
create table "EmployeePost"(
    "PostId" int references "JobPost"("PostId"),
    "EmpId" char(4) references "Employee"("EmpId"), 
    "AppliedDate" date, 
    "ApplicationStatus" text check("ApplicationStatus" in ('Reviewing','Accepted','Rejected')),
    primary key("PostId","EmpId")
);

//Static DB
CREATE DATABASE "StaticDB";



 



CREATE TABLE "Job"(

"JobId" CHAR(4) PRIMARY KEY,

"Title" TEXT NOT NULL,

"Description" TEXT NOT NULL,

"Salary" DECIMAL NOT NULL 

);



 



CREATE TABLE "Skill"(

"SkillId" CHAR(4) PRIMARY KEY,

"Name" TEXT NOT NULL,

"Level" CHAR(1) CHECK ("Level" IN ('B','I','A'))

);


CREATE TABLE "JobSkill"(

"JobId" CHAR(4) REFERENCES "Job"("JobId"),

"SkillId" CHAR(4) REFERENCES "Skill"("SkillId"), 

"Experience" INT NOT NULL,

PRIMARY KEY ("JobId" , "SkillId")

);


CREATE TABLE "Employee"(

"EmpId" CHAR(4) PRIMARY KEY,

"EName" TEXT NOT NULL,

"Email" TEXT NOT NULL,

"PhoneNo" CHAR(10) NOT NULL,

"Experience" INT NOT NULL,

"Password" Text NOT NULL,

"JobId" CHAR(4) REFERENCES "Job"("JobId")

);



Insert Commands
//Skill

INSERT INTO public."Skill"(

"SkillId","Name","Level")

VALUES('S101','Csharp', 'A'),

('S102','React','I'),

('S103','Java','A'),

('S104','SpringBoot', 'I'),

('S105','Angular Js', 'I'),

('S106','Python', 'B'),

('S107','SQL', 'I'),

('S108','AWS', 'B'),

('S109','Machine Learning', 'B'),

('S110','Artificial Intelligence', 'B');



 



//JobSkill

INSERT INTO public."JobSkill"(

"JobId","SkillId","Experience")

VALUES('J101','S109', '2'),

('J102','S102','4'),

('J103','S106','2'),

('J104','S101', '10'),

('J105','S107', '14'),

('J106','S107', '12'),

('J107','S107', '9'),

('J108','S108', '12'),

('J109','S105', '8'),

('J110','S108', '10');


INSERT INTO public."Job"(
    "JobId", "Title", "Description", "Salary")
    VALUES ('J101','Data Analyst','Something',10000),
('J102','Web Designer','Something',20000),
('J103','Project Manager','Something',30000),
('J104','Software Arcitect','Something',40000),
('J105','Database Arcitect','Something',50000),
('J106','Database Engineer','Something',60000),
('J107','Sql Developer','Something',70000),
('J108','Cloud Arcitect','Something',80000),
('J109','Web Developer','Something',20000),
('J110','Devops Engineer','Something',10000);

 

INSERT INTO public."Employee"(
    "EmpId", "EName", "Email", "PhoneNo", "Experience", "Password", "JobId")
VALUES ('E101','Suresh','suresh@gmail.com','9234567890',5,'password','J101'),
('E102','Ramesh','ramesh@gmail.com','9234567891',3,'password','J104'),
('E103','Venkat','venkat@gmail.com','9234567892',5,'password','J101'),
('E104','Keerthi','keerthi@gmail.com','9234567893',4,'password','J105'),
('E105','Neha','neha@gmail.com','9234567894',4,'password','J102'),
('E106','Aakash','aakash@gmail.com','9234567895',4,'password','J107');