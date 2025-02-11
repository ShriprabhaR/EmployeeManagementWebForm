using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeManagementWebForm.Model;

namespace EmployeeManagementWebForm
{
    public partial class EmpPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindView(); 
            }
        }

        private void BindView()
        {
            EmployeeDAL empDAL = new EmployeeDAL();
            List<Employee> employees = empDAL.GetEmployees();

            GridViewEmployees.DataSource = employees;
            GridViewEmployees.DataBind();

        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee
            {
                Name = txtName.Text,
                Age = Convert.ToInt32(txtAge.Text),
                Salary = Convert.ToInt32(txtSalary.Text),
                Email = txtEmail.Text,
                City = txtCity.Text,
                Department = txtDepartment.Text,
                Gender = txtGender.Text

            };
            EmployeeDAL employeeDAL = new EmployeeDAL();
            employeeDAL.AddEmp(emp);
            BindView();
            Clear();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int EmployeeId = Convert.ToInt32(txtEmployeeId.Text);
            Employee emp = new Employee
            {
                EmployeeId = EmployeeId,
                Name = txtName.Text,
                Age = Convert.ToInt32(txtAge.Text),
                Salary = Convert.ToInt32(txtSalary.Text),
                Email = txtEmail.Text,
                City = txtCity.Text,
                Department = txtDepartment.Text,
                Gender = txtGender.Text
            };

            EmployeeDAL empDAL = new EmployeeDAL();
            empDAL.UpdateEmp(emp);
            BindView();
            Clear();

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int empId = Convert.ToInt32(txtEmployeeId.Text);
            EmployeeDAL empDAL = new EmployeeDAL();
            empDAL.DeleteEmp(empId);

            BindView();
            Clear();
        }

        public void Clear()
        {
            txtEmployeeId.Text = "";
            txtName.Text = "";
            txtAge.Text = "";
            txtSalary.Text = "";
            txtEmail.Text = "";
            txtCity.Text = "";
            txtDepartment.Text = "";
            txtGender.Text = "";

        }
    }
}