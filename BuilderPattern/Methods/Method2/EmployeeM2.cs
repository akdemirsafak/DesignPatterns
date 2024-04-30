namespace BuilderPattern.Methods.Method2
{
    public class EmployeeM2
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }

        public override string ToString()
        {
            return $"{Name} {LastName} - Username: {UserName}";
        }
    }
}