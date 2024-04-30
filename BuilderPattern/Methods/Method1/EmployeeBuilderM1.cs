namespace BuilderPattern.Methods.Method1
{
    public class EmployeeBuilderM1
    {
        private EmployeeM1 employee { get; set; }

        public EmployeeBuilderM1()
        {
            employee = new();
        }
        public EmployeeBuilderM1 SetFullName(string fullName)
        {
            //validations
            var splitedName = fullName.Split(' ');
            employee.Name = splitedName[0];
            employee.LastName = splitedName[1];
            return this;
        }
        public EmployeeBuilderM1 SetEmail(string email)
        {
            employee.Email = email;
            return this;
        }
        public EmployeeBuilderM1 SetUserName(string userName)
        {
            employee.UserName = userName;
            return this;
        }
        public EmployeeM1 BuildEmployee()
        {
            return employee;
        }
    }
}