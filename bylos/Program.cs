using System;
using Microsoft;
using System.IO;
using System.Text;

namespace byla
{
    class byla
    {
        //VISKAS YRA SURASYTA KA TURIME PASIIMTI IR KA TURIME ISSIUSTI KLASEJ, KAD GALETU TOLIAU SUKTIS CIKLAS
        public static void Main(string[] args)
        {
            Console.WriteLine("Pasirinktie skaiciu kiek norite sukurti failu : ");
            int kiekis = Convert.ToInt32(Console.ReadLine());
            string dir = "bylos";
            string dir2 = "ataskaita";
            string atsname = "ataskaita";
            klase.klase myObj = new klase.klase(kiekis, dir);
            myObj.failas();
            Console.ReadLine();
            Console.Clear();
            myObj.kurimas();
            Console.ReadLine();
            Console.Clear();
            myObj.ataskaitos(dir2, atsname);
            Console.ReadLine();
            Console.Clear();
            myObj.trynimas();
            Console.ReadLine();
        }
    }
}