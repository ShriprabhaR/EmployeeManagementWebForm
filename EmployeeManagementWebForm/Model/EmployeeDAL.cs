using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.UI;
namespace EmployeeManagementWebForm.Model
{
    public class EmployeeDAL
    {
        private readonly string connString = ConfigurationManager.ConnectionStrings["EmpConnection"].ConnectionString;

        //Get All Employees
        public List<Employee> GetEmployees() 
        { 
            List<Employee> employees = new List<Employee>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("select * from Employee", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Employee emp = new Employee()
                    {
                        EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                        Name = reader["Name"].ToString(),
                        Age = Convert.ToInt32(reader["Age"]),
                        Salary = Convert.ToInt32(reader["Salary"]),
                        Email = reader["Email"].ToString(),
                        City = reader["City"].ToString(),
                        Department = reader["Department"].ToString(),
                        Gender = reader["Gender"].ToString(),
                    };
                    employees.Add(emp);
                }
                return employees;
            }
        }

        //Create method
        public int AddEmp(Employee emp)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("Insert into Employee(Name, Age, Salary, Email, City, Department, Gender) values(@Name, @Age, @Salary, @Email, @City, @Department, @Gender)", conn);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Age", emp.Age);
                cmd.Parameters.AddWithValue("@Salary", emp.Salary);
                cmd.Parameters.AddWithValue("@Email", emp.Email);
                cmd.Parameters.AddWithValue("@City", emp.City);
                cmd.Parameters.AddWithValue("@Department", emp.Department);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());

            }
        }
        //Update method
        public void UpdateEmp(Employee emp)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("Update Employee SET Name =@Name, Age= @Age, Salary= @Salary, Email = @Email, City=@City, Department = @Department, Gender=@Gender where EmployeeId = @EmployeeId", conn);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Age", emp.Age);
                cmd.Parameters.AddWithValue("@Salary", emp.Salary);
                cmd.Parameters.AddWithValue("@Email", emp.Email);
                cmd.Parameters.AddWithValue("@City", emp.City);
                cmd.Parameters.AddWithValue("@Department", emp.Department);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                cmd.Parameters.AddWithValue("@EmployeeId", emp.EmployeeId);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }

        //Delete method
        public void DeleteEmp(int empId)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("Delete from Employee where EmployeeId = @EmployeeId", conn);
                cmd.Parameters.AddWithValue("@EmployeeId", empId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //Get Data By id

        public Employee GetEmpById(int empId)
        {
            Employee emp = null;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("Select * from Employee where EmployeeId= @EmployeeId", conn);
                cmd.Parameters.AddWithValue("@EmployeeId", empId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    emp = new Employee();
                    emp.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                    emp.Name = reader["Name"].ToString();
                    emp.Age = Convert.ToInt32(reader["Age"]);
                    emp.Salary = Convert.ToInt32(reader["Salary"]);
                    emp.Email = reader["Email"].ToString();
                    emp.City = reader["City"].ToString();
                    emp.Department = reader["Department"].ToString();
                    emp.Gender = reader["Gender"].ToString();
                }
            }
            return emp;
        }
        


    }
}