namespace BuilderPattern.Methods.Method2
{
    public class InternalEmployeeBuilder : EmployeeBuilderM2
    {
        //Internal
        public override void SetEmail(string email)
        {
            //endswith @company.com.tr
            var arr = email.Split('@');
            Employee.Email = arr[0] + "@company.com.tr";
        }

        public override void SetFullName(string fullName)
        {
            var arr = fullName.Split(new[] { ' ', '_', '.' });
            Employee.Name = arr[0];
            Employee.LastName = arr[1];
        }

        public override void SetUserName(string userName)
        {
            throw new NotImplementedException();
        }
    }
}