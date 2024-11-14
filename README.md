This Bulk Reversal App is built with ASP.NET Core MVC and designed to handle bulk reversal requests in a financial setting. The application includes two main user roles, Maker and Checker, who manage and approve reversal requests through a streamlined workflow.

Table of Contents
Features
Technologies Used
Setup and Installation
Database Schema
Roles and Workflow
Endpoints
Usage
Future Enhancements

Features
Role-based Access Control:
Maker users can create bulk reversal requests.
Checker users review and approve/decline requests.
Session Management: User sessions are managed through cookies for secure access control.
Request Status Tracking: Requests have statuses such as Pending, Approved, or Rejected.
Password Hashing: User passwords are securely hashed with BCrypt for added security.

Technologies Used
Backend: ASP.NET Core MVC
Database: MySQL with Entity Framework Core
Session Management: ASP.NET Core Session
Password Hashing: BCrypt
View Templates: Razor views for creating dynamic HTML pages

Setup and Installation
Prerequisites
.NET SDK 6.0+
MySQL Server
Visual Studio or Visual Studio Code
MySQL Workbench (optional, for database management)
