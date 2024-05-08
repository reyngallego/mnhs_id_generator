using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Http;

namespace WebApplication4.Controllers
{
    public class StudentsController : ApiController
    {
        // Get the connection string from the configuration file
        private string connectionString = ConfigurationManager.ConnectionStrings["StudentRecords"].ConnectionString;

        // GET: api/students
        public IHttpActionResult Get()
        {
            List<Student> students = new List<Student>();

            // SQL query to select all students from the database
            string query = "SELECT * FROM Students";

            // Create connection and command objects
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        // Open connection
                        connection.Open();

                        // Execute the query
                        SqlDataReader reader = command.ExecuteReader();

                        // Read the data and populate the students list
                        while (reader.Read())
                        {
                            Student student = new Student
                            {
                                LRN = reader["STUD_LRN"].ToString(),
                                FirstName = reader["STUD_FNAME"].ToString(),
                                MiddleName = reader["STUD_MNAME"].ToString(),
                                LastName = reader["STUD_LNAME"].ToString(),
                                Extension = reader["STUD_EXT"].ToString(),
                                GradeSection = reader["STUD_GRADE_SECTION"].ToString(),
                                Birthdate = Convert.ToDateTime(reader["STUD_BIRTHDATE"]),
                                Sex = reader["STUD_SEX"].ToString(),
                                Address = reader["STUD_ADDRESS"].ToString(),
                                ParentFullName = reader["PARENT_FULLNAME"].ToString(),
                                ParentContact = reader["PARENT_CONTACT"].ToString()
                            };

                            students.Add(student);
                        }

                        // Close data reader
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions
                        return InternalServerError(ex);
                    }
                }
            }

            // Return the list of students
            return Ok(students);
        }

        // POST: api/students
        public IHttpActionResult Post(Student student)
        {
            // SQL query to insert a student into the database
            string query = @"INSERT INTO Students (STUD_LRN, STUD_FNAME, STUD_MNAME, STUD_LNAME, STUD_EXT, STUD_GRADE_SECTION, STUD_BIRTHDATE, STUD_SEX, STUD_ADDRESS, PARENT_FULLNAME, PARENT_CONTACT)
                             VALUES (@LRN, @FirstName, @MiddleName, @LastName, @Extension, @GradeSection, @Birthdate, @Sex, @Address, @ParentFullName, @ParentContact)";

            // Create connection and command objects
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Set parameters
                    command.Parameters.AddWithValue("@LRN", student.LRN);
                    command.Parameters.AddWithValue("@FirstName", student.FirstName);
                    command.Parameters.AddWithValue("@MiddleName", student.MiddleName);
                    command.Parameters.AddWithValue("@LastName", student.LastName);
                    command.Parameters.AddWithValue("@Extension", student.Extension);
                    command.Parameters.AddWithValue("@GradeSection", student.GradeSection);
                    command.Parameters.AddWithValue("@Birthdate", student.Birthdate);
                    command.Parameters.AddWithValue("@Sex", student.Sex);
                    command.Parameters.AddWithValue("@Address", student.Address);
                    command.Parameters.AddWithValue("@ParentFullName", student.ParentFullName);
                    command.Parameters.AddWithValue("@ParentContact", student.ParentContact);

                    try
                    {
                        // Open connection
                        connection.Open();

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return Ok("Student added successfully.");
                        }
                        else
                        {
                            return BadRequest("Failed to add student.");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions
                        return InternalServerError(ex);
                    }
                }
            }
        }

     
        public class Student
        {
            public string LRN { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public string Extension { get; set; }
            public string GradeSection { get; set; }
            public DateTime Birthdate { get; set; }
            public string Sex { get; set; }
            public string Address { get; set; }
            public string ParentFullName { get; set; }
            public string ParentContact { get; set; }
        }
       
    }
}
