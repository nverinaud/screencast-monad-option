using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var contact = CarnetDAdresse.TrouverContact("Tim");

            var taille = contact.Bind(c => c.Email).Map(e => e.Length);

            if (taille.IsSome)
            {
                Console.WriteLine("Taille = {0}", taille);
            }
        }
    }
}