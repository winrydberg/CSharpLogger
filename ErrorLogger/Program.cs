using System;

namespace ErrorLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            //Logger logger = new Logger();
            //logger.LogError("Message");

            Logger.LogError("Hello New Message Here !!!!!", LogType.Debug);

            Console.ReadKey();
        }
    }
}
