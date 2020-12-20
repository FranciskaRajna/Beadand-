using System;

namespace Beadandó
{
    class Program
    {
        static void Main(string[] args)
        {
            Automata A = new Automata("(32*6)+213");
            A.OpenFileToRead(@"C:\Users\Lenovo\Desktop\Beadandó\Beadandó\bin\Debug\netcoreapp3.1\rule.txt");
            A.process();
        }
    }
}
