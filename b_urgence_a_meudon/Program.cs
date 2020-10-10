using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b_urgence_a_meudon
{
    class Program
    {
        static void Main(string[] args)
        {
            var line1 = new Line(Console.ReadLine());
            var line2 = new Line(Console.ReadLine());
            int xr = line1.GetWordAsInt(0);
            int xm = line1.GetWordAsInt(1);
            int n = line2.GetWordAsInt(0);

            int nbPvoiture = 0;
            int nbPbus = 0;

            int placesBus = 0;

            for (int i = 0; i < n; i++)
            {
                var line = new Line(Console.ReadLine());
                string vehicule = line.GetWord(0);

                if (vehicule == "v")
                {
                    string couleur = line.GetWord(1);
                    int capacite = line.GetWordAsInt(2);

                    if (couleur == "m")
                    {
                        if (xm > 0)
                        {
                            if (xm > capacite)
                            {
                                xm -= capacite;
                                nbPvoiture += capacite;
                            }
                            else
                            {
                                nbPvoiture += xm;
                                xm = 0;
                            }
                        }
                    }
                    else
                    {
                        if (xr > 0)
                        {
                            if (xr > capacite)
                            {
                                xr -= capacite;
                                nbPvoiture += capacite;
                            }
                            else
                            {
                                nbPvoiture += xr;
                                xr = 0;
                            }
                        }
                    }
                }
                else
                {
                    int capacite = line.GetWordAsInt(1);

                    placesBus += capacite;                    
                }
            }

            if (placesBus > 0)
            {
                if (xm > 0)
                {
                    if (placesBus > xm)
                    {
                        placesBus -= xm;
                        nbPbus += xm;
                        xm = 0;
                    }
                    else
                    {
                        xm -= placesBus;
                        nbPbus += placesBus;
                        placesBus = 0;
                    }
                }

                if (placesBus > 0 && xr > 0)
                {
                    if (placesBus > xr)
                    {
                        placesBus -= xr;
                        nbPbus += xr;
                        xr = 0;
                    }
                    else
                    {
                        xr -= placesBus;
                        nbPbus += placesBus;
                        placesBus = 0;
                    }
                }
            }

            int nbPsansTransport = xr + xm;

            Console.WriteLine($"{nbPsansTransport} {nbPvoiture} {nbPbus}");
        }
    }

    public class Line
    {
        private readonly string line;
        private string[] t;

        public Line(string line)
        {
            this.line = line;
            t = line.Split(' ');
        }

        public string GetWord(int index)
        {
            return t[index];
        }

        public int GetWordAsInt(int index)
        {
            string word = GetWord(index);

            return int.Parse(word);
        }
    }
}
