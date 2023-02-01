using HolmesglenStudentManagementSystem.PresentationLayer;
using HolmesglenStudentManagementSystem.DataAccessLayer;
using System;
using HolmesglenStudentManagementSystem.PresentationLayer.StudentPL;
using HolmesglenStudentManagementSystem.Models;
using HolmesglenStudentManagementSystem.BusinessLogicLayer;
using Microsoft.Data.Sqlite;
using HolmesglenStudentManagementSystem.PresentationLayer.RecordPL;
using HolmesglenStudentManagementSystem.DisconnectedDataAccessLayer;
using HolmesglenStudentManagementSystem.EntityModels;

namespace HolmesglenStudentManagementSystem
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("Enter number for function you would like to open:");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("1. View Student Options");
                Console.WriteLine("2. View Subject Options");
                Console.WriteLine("3. View Enrollment Options");
                Console.WriteLine("4. Create a report of Student and Subject Details");
                Console.WriteLine("5. Create an email for a specific student");
                Console.WriteLine("6. Import CSV file to database");
                Console.WriteLine("7. Export Database to CSV file");
                Console.WriteLine("8. Exit Program");
                string command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        bool student = false;
                        while (!student)
                        {
                            Console.WriteLine("----------------------------------------------------");
                            Console.WriteLine("Enter number for what function of student you would like to perform:");
                            Console.WriteLine("----------------------------------------------------");
                            Console.WriteLine("1. Read All Students");
                            Console.WriteLine("2. Read a specific Student");
                            Console.WriteLine("3. Create a student");
                            Console.WriteLine("4. Update a student");
                            Console.WriteLine("5. Delete a student");
                            Console.WriteLine("6. Go back to main menu");
                            string type = Console.ReadLine();
                            switch (type)
                            {
                                case "1":
                                    (new GetAllStudents()).Run();
                                    break;
                                case "2":
                                    (new GetOneStudent()).Run();
                                    break;
                                case "3":
                                    (new CreateStudent()).Run();
                                    break;
                                case "4":
                                    (new UpdateStudent()).Run();
                                    break;
                                case "5":
                                    (new DeleteStudent()).Run();
                                    break;
                                case "6":
                                    student = true;
                                    break;
                                default:
                                    Console.WriteLine("Wrong Selection. Please try again");
                                    break;
                            }
                        }
                        break;
                    case "2":
                        bool subject = false;
                        while (!subject)
                        {
                            Console.WriteLine("----------------------------------------------------");
                            Console.WriteLine("Enter number for what function of subject you would like to perform:");
                            Console.WriteLine("----------------------------------------------------");
                            Console.WriteLine("1. Read All Subjects");
                            Console.WriteLine("2. Read a specific Subjects");
                            Console.WriteLine("3. Create a subject");
                            Console.WriteLine("4. Update a subject");
                            Console.WriteLine("5. Delete a subject");
                            Console.WriteLine("6. Go back to main menu");
                            string type = Console.ReadLine();
                            switch (type)
                            {
                                case "1":
                                    (new GetAllSubjects()).Run();
                                    break;
                                case "2":
                                    (new GetOneSubject()).Run();
                                    break;
                                case "3":
                                    (new CreateSubject()).Run();
                                    break;
                                case "4":
                                    (new UpdateSubject()).Run();
                                    break;
                                case "5":
                                    (new DeleteSubject()).Run();
                                    break;
                                case "6":
                                    subject = true;
                                    break;
                                default:
                                    Console.WriteLine("Wrong Selection. Please try again");
                                    break;
                            }
                        }
                        break;
                    case "3":
                        bool enrollment = false;
                        while (!enrollment)
                        {
                            Console.WriteLine("----------------------------------------------------");
                            Console.WriteLine("Enter number for what function of enrollment you would like to perform:");
                            Console.WriteLine("----------------------------------------------------");
                            Console.WriteLine("1. Read All Enrollments");
                            Console.WriteLine("2. Read a specific Enrollment");
                            Console.WriteLine("3. Create a enrollment");
                            Console.WriteLine("4. Update a enrollment");
                            Console.WriteLine("5. Delete a enrollment");
                            Console.WriteLine("6. Go back to main menu");
                            string type = Console.ReadLine();
                            switch (type)
                            {
                                case "1":
                                    (new GetAllEnrollment()).Run();
                                    break;
                                case "2":
                                    (new GetOneEnrollment()).Run();
                                    break;
                                case "3":
                                    (new CreateEnrollment()).Run();
                                    break;
                                case "4":
                                    (new UpdateEnrollment()).Run();
                                    break;
                                case "5":
                                    (new DeleteEnrollment()).Run();
                                    break;
                                case "6":
                                    enrollment = true;
                                    break;
                                default:
                                    Console.WriteLine("Wrong Selection. Please try again");
                                    break;
                            }
                        }
                        break;
                    case "4":
                        (new GetReport()).Run();
                        break;
                    case "5":
                        (new GenerateEmail()).Run();
                        break;
                    case "6":
                        (new ImportStudents()).Run();
                        break;
                    case "7":
                        (new ExportStudents()).Run();
                        break;
                    case "8":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Wrong Selection. Please try again");
                        break;
                }
            }

            // Student Testing

            //(new GetAllStudents()).Run();
            //(new GetOneStudent()).Run();
            //(new CreateStudent()).Run();
            //(new UpdateStudent()).Run();
            //(new DeleteStudent()).Run();

            // Subject Testing

            //(new GetAllSubjects()).Run();
            //(new GetOneSubject()).Run();
            //(new CreateSubject()).Run();
            //(new UpdateSubject()).Run();
            //(new DeleteSubject()).Run();

            // Enrollment Testing

            //(new GetAllEnrollment()).Run();
            //(new GetOneEnrollment()).Run();
            //(new CreateEnrollment()).Run();
            //(new UpdateEnrollment()).Run();
            //(new DeleteEnrollment()).Run();

            // Report Testing

            // (new GetReport()).Run();

            // Email testing

            // (new GenerateEmail()).Run();

            // Record Testing

            //(new ImportStudents()).Run();
            //(new ExportStudents()).Run();

            //  Disconnected Testing

            //string connectionString = @"Data Source=C:\Users\saint\Downloads\data-driven-at2-202220\HolmesglenStudentManagementSystem.db";
            //var disconnectedDAL = new DisconnectedDAL(connectionString);
            //Console.WriteLine("Reading all students using disconnected mode");
            //foreach (var student in disconnectedDAL.StudentReadAll())
            //{
            //    Console.WriteLine($"{student.Id} - {student.FirstName} {student.LastName} - {student.Email}");
            //}
        }

    }
}
