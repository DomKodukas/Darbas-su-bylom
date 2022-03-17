using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace klase
{
    internal class klase
    {
        //PRISKIRIAM VISOM KLASEM SIUOS KINTAMUUOSIUS KURIE KELIAUJA PER VISAS KALSES
        public int kiekis;
        public string dir;
        public klase(int skaicius, string kelias)//PASIDAROM KLASE KURI ZINOS KOKI SKACIU ASMUO SUVEDA
        {
            kiekis = skaicius;
            dir = kelias;
        }
        public void failas()//SUKURIAM FAILA I KURI BUS KURIAMI VISI KITI FAILIUKAI
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
                Console.WriteLine("Sekimgai sukurtas bylos katalogas");
            }
        }
        public void kurimas()//KURIAMAS TXT FAILAS I FOLDERI KURIS BUVO SUKURTAS, ZMOGUS GALI PASIRINKTI KIEK TXT FAILU NORES SUKURTI
        {
            int sukrkiek = 0, pervkiek = 0;
            if (!File.Exists(dir))
            {
                for (int i = 1; i <= kiekis; i++)
                {
                    string FileName = "pugacius" + i + ".txt";
                    string path = dir + "/" + FileName;
                    Random rd = new Random();
                    if (!File.Exists(path))
                    {
                        int rand_num = rd.Next(0, 2);//SUGENERUOJAMA ATSITIKTINIAI SKAICIAI I SUKURTUS .TXT FAILUS
                        File.WriteAllText(path, Convert.ToString(rand_num));
                        sukrkiek++;
                    }
                    else
                    {
                        string data = DateTime.Now.ToString("yyyy-MM-dd");//JEIGU TOKS KIEKI JAU EGZISTUOJA TADA TUOS EGZISTUOJANCIUS TXT FAILIUS PERVADINS I SIANDIENOS DATA, JEIGU TARKIME ZMOGUS SUSIKURE 5 TXT FAILUS, BET DAR KURIA 7, TADA TUOS 5 PERVADINS, O JAU PO 6 NUMERIUKO KURS NORMALIAI
                        string FileNameNew = "pugacius" + i + "_" + data + ".txt";
                        File.Move(path, dir + "/" + FileNameNew);
                        pervkiek++;
                        Console.WriteLine(FileName + " persivadina i " + FileNameNew);
                    }
                }
                Console.WriteLine("Sekmingai sukurta " + sukrkiek + " failu/-ai");//PAPRASTAS PRANESIMAS, KAD SUKURE TIEK FAILU KIEK ASMUO BUVO IVEDES
                Console.WriteLine("Sekmingai pervadinta " + pervkiek + " failu/-ai");
            }
        }
        public void ataskaitos(string dir2, string atsname)//KURIAMAS ATASKAITOS KATALOGAS KURIAME BUS REPORTUOJAMAS VISOS SUKURTOS BYLOS REZULTATAS KIEK YRA NULIU IR VIENETU
        {
            int kieknulis = 0, kiekvienas = 0;
            if (!Directory.Exists(dir + "/" + dir2))
            {
                Directory.CreateDirectory(dir + "/" + dir2);
                Console.WriteLine("Sekmingai sukurtas ataskaitos katalogas");
            }
            foreach (string sakitymas in FileSystem.GetFiles(dir + "/"))
            {
                string failas = FileSystem.ReadAllText(sakitymas);
                if (failas == "0")
                {
                    kieknulis++;
                }
                else if (failas == "1") { kiekvienas++; }
            }
            using (StreamWriter sw = File.CreateText(dir + "/" + dir2 + "/" + atsname + ".txt"))
            {
                Console.WriteLine("Is viso vienetu buvo irasyta - " + kiekvienas + ", o nuliu - " + kieknulis);
                sw.WriteLine("Is viso vienetu buvo irasyta - " + kiekvienas + ", o nuliu - " + kieknulis, false);
            }
        }
        public void trynimas()//SUKURIAMAS TRINIMAS SU KURIU NUSKAITYS FAILUS KURIE TURI 0 JUOSE IR JUOS ISTRINS
        {
            Console.WriteLine("Norint istrinti failus kuriuose yra nuliai spauskite 'enter'");
            Console.ReadLine();
            Console.Clear();
            int trinkiekis = 0;
            string[] files = Directory.GetFiles(dir + "/");
            foreach (var file in files)
            {
                string trinam = File.ReadAllText(file);
                if (trinam == "0")
                {
                    File.Delete(file);
                    trinkiekis++;
                }
            }
            Console.WriteLine("Buvo istrinta " + trinkiekis + " failu/-ai kurie irasyti su nuliu");
        }
    }
}