<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmpPage.aspx.cs" Inherits="EmployeeManagementWebForm.EmpPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class ="container">
        <div class =" "row">
            <div class ="col-md-6">

        <asp:GridView ID="GridViewEmployees" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="EmployeeId" HeaderText="EmployeeId" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Age" HeaderText="Age" />
                <asp:BoundField DataField="Salary" HeaderText="Salary" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="City" HeaderText="City" />
                <asp:BoundField DataField="Department" HeaderText="Department" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" />

            </Columns>
        </asp:GridView>
     </div>

                <div class ="col-md-6">
                    EmployeeId: <asp:TextBox ID="txtEmployeeId" runat="server" CssClass="form-control"></asp:TextBox><br />
                   Name: <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox><br />
                    Age: <asp:TextBox ID="txtAge" runat="server" CssClass="form-control"></asp:TextBox><br />
                   Salary: <asp:TextBox ID="txtSalary" runat="server" CssClass="form-control"></asp:TextBox><br />
                   Email: <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox><br />
                    City: <asp:TextBox ID="txtCity" runat="server" CssClass="form-control"></asp:TextBox><br />
                   Department: <asp:TextBox ID="txtDepartment" runat="server" CssClass="form-control"></asp:TextBox><br />
                 Gender: <asp:TextBox ID="txtGender" runat="server" CssClass="form-control"></asp:TextBox><br />

                 <asp:Button ID="btnAdd" runat="server" Text=" Add Employee" OnClick="btnAdd_Click" CssClass="btn btn-primary" />
                 <asp:Button ID="btnUpdate" runat="server" Text=" Update Employee" OnClick="btnUpdate_Click" CssClass="btn btn-primary" />
                 <asp:Button ID="btnDelete" runat="server" Text=" Delete Employee" OnClick="btnDelete_Click" CssClass ="btn btn-danger"/>

               </div>
            </div>
    </div>
</asp:Content>
