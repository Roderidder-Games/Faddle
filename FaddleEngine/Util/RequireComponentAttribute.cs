using System;

namespace FaddleEngine
{
    [System.AttributeUsage(System.AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public sealed class RequireComponentAttribute : Attribute
    {
        internal readonly Type type;

        public RequireComponentAttribute(Type type) 
        {
            this.type = type;
        }
    }
}
