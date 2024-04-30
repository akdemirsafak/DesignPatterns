namespace BuilderPattern.Methods.Method2
{
    public class ExternalEmployeeBuilder : EmployeeBuilderM2
    {
        //Internal
        public override void SetEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override void SetFullName(string fullName)
        {
            throw new NotImplementedException();
        }

        public override void SetUserName(string userName)
        {
            throw new NotImplementedException();
        }
    }
}