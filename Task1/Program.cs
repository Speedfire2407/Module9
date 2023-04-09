using System.Runtime.InteropServices;

namespace Task1
{
    public class MyException : Exception
    {
        public MyException()
        {
        }
        public MyException(string message) : base(message)
        {
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Exception[] arrayOfExcep = { new RankException(), 
                new MyException(), 
                new DivideByZeroException(), 
                new ArgumentNullException(),
                new TimeoutException()};
            foreach (var excep in arrayOfExcep)
            {
                try
                {
                    Console.WriteLine(excep.GetType());
                    throw excep;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }
        }
    }
}