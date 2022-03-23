# School Management System 
This is third semester project School Management System implemented with C# Windows Forms and Microsoft Access DataBase.
The project is build using Object Oriented Programming Paradigm.

# Introduction
The software School Management System is designed to facilitate the work of school management. 

The management system will provide ease to maintain the record of students and teachers. 

It will provide the day to day automated functionality of school management.

# Product Architecture
The School Management System is a new system product that is going to replace the old paper based system. 

It have the two layers that is the Database Layer and the Application layer through which the user will interact. 

The records of teachers and students will be recorded in the database and through it can be retrieved for the data process and functions. 

# Features
There are four users of the system that are Admin, Account, Teacher and Student. 

The Features included are:

### Admin
The functionalities of Admin are:

* Login with an ID and Password
* Add Details of new student 
* Add Details of new teacher
* View the details of student and teacher
* Add Announcement that can be viewed as per selection that is for teacher, students or account or to every user
* View the announcement
* Set the timetable for every class and for teachers
* View the timetable
* Logout from the system

### Accounts
The functionalities of Accounts are:

* Login with an ID and Password
* View the details of student which include student-id, name, class, previous fee and fee status
* Add announcement that can only be viewed by specific student and Admin
* Generate the fee for individual student
* Submit the fee
* Logout from the system

### Teacher
The functionalities of Teacher are:

* Login with an ID and Password
* A teacher can view its details
* View the details of only those student to whom the teacher teach as per classes according to timetable
* The detail of student to view include student-id, name, class, attendance and marks
* Add the Attendance of the student
* Update the attendance of the student
* View the attendance of the student
* Add the marks of quiz, mid-term and finals of students
* Update the marks
* View the marks of students
* View the teacher timetable
* Add Announcement that can only be viewed by students and Admin
* View the Announcement set by that teacher and of Admin
* Logout from the system

### Student
The functionalities of Student are:

* Login with an ID and Password
* A student can view its details
* A student can view and print the fee challan in order to submit to the accounts
* A student can view the status of its fee
* A  student can view its attendance set by teacher 
* A student can view the timetable of its class
* A student can view the announcement set by teacher, Admin or Account
* A student can view its marks of quiz, mid-term and final
* Logout from the system