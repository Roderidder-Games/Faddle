namespace FaddleEngine
{
    [System.AttributeUsage(System.AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public sealed class LogNameAttribute : System.Attribute
    {
        private readonly string name;

        public LogNameAttribute(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }
    }
}
