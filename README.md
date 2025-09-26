# Clinic Management System

## Overview
This project is a **Clinic Management System** developed as part of a university course project.  
The system aims to support clinic operations such as patient registration, appointment scheduling, medical record management, billing, and reporting.  
It applies software engineering principles (OOP, 3-tier architecture) and modern technologies to deliver a maintainable and scalable solution.  

## Features
- Patient registration and profile management  
- Appointment booking and scheduling  
- Medical record management (diagnosis, treatment, prescriptions)  
- Billing and payment tracking  
- Reporting and statistics (appointments, patients, revenue)  
- User-friendly interface for clinic staff  

## Technologies Used
- **Programming Languages:** C#, Python  
- **Frameworks:** .NET, Flask  
- **Architecture:** 3-Tier (Data Layer, Business Layer, Presentation Layer)  
- **Database:** SQL Server / MySQL  
- **Other Tools:** REST API, DTO pattern, GitHub for version control  

## Project Structure
- **/DataLayer**: Database models, data access objects  
- **/BusinessLayer**: Business logic, validation, workflows  
- **/PresentationLayer**: User interface (WinForms/WPF or Web UI)  
- **/API**: RESTful services for integration  

## Installation & Usage
1. Clone the repository:
   ```bash
   git clone https://github.com/Truong-Thai-Bao/Clinic.git
   cd Clinic
   ```
2. Set up the database (SQL script included in /Database folder).

3. Configure connection string in the app configuration file.

4. Run the project in Visual Studio (for .NET) or Flask server (for Python services).
  
## Results & Evaluation

- Successfully implemented key functions of a clinic management system.

- Improved system modularity using OOP and layered architecture.

- Provided a foundation for future extension such as online booking, multi-branch support, and cloud deployment.
