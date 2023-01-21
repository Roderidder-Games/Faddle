using System;

namespace FaddleEngine
{
    public static class Log
    {
        public static void Info(object message, object sender = null)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Write(message, sender);
        }

        public static void Warn(object message, object sender = null)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Write(message, sender);
        }

        public static void Error(object message, object sender = null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Write(message, sender);
        }

        private static void Write(object message)
        {
            Console.WriteLine(message);
        }

        private static void Write(object message, object sender)
        {
            if (sender == null)
            {
                Write(message);
                return;
            }

            string final = "";

            Attribute logNameAttr = Attribute.GetCustomAttribute(sender.GetType(), typeof(LogNameAttribute));


            if (logNameAttr != null)
            {
                LogNameAttribute logName = logNameAttr as LogNameAttribute;

                final += $"[{logName.Name}] ";
            }

            final += message;

            Write(final);
        }
    }
}
