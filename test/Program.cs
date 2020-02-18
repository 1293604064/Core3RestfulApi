using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Guid guid = new Guid();
            
            for (int i = 0; i < 5; i++)
            {
                guid = Guid.NewGuid();
                Console.WriteLine(guid);

            }

            Console.ReadKey();
        }
    }
}
