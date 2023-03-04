using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading;

namespace TesteTraducao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Idiomas idioma = new Idiomas("en-US");
            Console.WriteLine(idioma.GetMensagem("Welcome"));
            Console.ReadKey();
        }
    }
}
