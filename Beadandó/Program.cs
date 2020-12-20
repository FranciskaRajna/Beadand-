using System;

namespace Beadandó
{
    class Program
    {
        static void Main(string[] args)
        {
            Automata A = new Automata("i*i+1");
            A.OpenFileToRead(@"C:\Users\Lenovo\Desktop\Beadandó\Beadandó\bin\Debug\netcoreapp3.1\rule.txt");
            A.process();
        }
    }
}
