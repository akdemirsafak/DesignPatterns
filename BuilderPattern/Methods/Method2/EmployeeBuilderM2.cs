namespace BuilderPattern.Methods.Method2
{
    public abstract class EmployeeBuilderM2 : IEmployeeBuilderM2
    {
        protected EmployeeM2 Employee { get; set; }
        public EmployeeBuilderM2()
        {
            Employee = new EmployeeM2();
        }
        public abstract void SetFullName(string fullName);
        public abstract void SetEmail(string email);
        public abstract void SetUserName(string userName);
        public EmployeeM2 BuildEmployee() => Employee;
    }
    public interface IEmployeeBuilderM2
    {
        EmployeeM2 BuildEmployee();
        void SetEmail(string email);
        void SetFullName(string fullName);
        void SetUserName(string userName);
    }
}