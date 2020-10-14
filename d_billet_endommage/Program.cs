using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d_billet_endommage
{
    class Program
    {
        static int L;
        static int C;
        static char[,] codeBarre;

        static void Main(string[] args)
        {
            var line1 = new Line(Console.ReadLine());
            L = line1.GetWordAsInt(0);
            C = line1.GetWordAsInt(1);
            codeBarre = new char[L, C];

            for (int i = 0; i < L; i++)
            {
                var line = Console.ReadLine();

                for (int j = 0; j < C; j++)
                {
                    codeBarre[i, j] = line[j];
                }
            }

            var line3 = new Line(Console.ReadLine());
            var line4 = new Line(Console.ReadLine());

            var tTiretsLi = line3.GetAllWordsAsInt().ToArray();
            var tTiretsCj = line4.GetAllWordsAsInt().ToArray();

            for (int i = 0; i < L; i++)
            {
                int li = tTiretsLi[i];
                int cli = CountTiretLi(i);

                if (li != cli)
                {
                    int candidats = 0;
                    List<int> jCandidat = new List<int>();

                    for (int j = 0; j < C; j++)
                    {
                        int cj = tTiretsCj[j];
                        int ccj = CountTiretCj(j);

                        if (cj != ccj && codeBarre[i, j] != '-')
                        {
                            candidats++;
                            jCandidat.Add(j);
                        }
                    }

                    if (candidats > li - cli || candidats == 0)
                    {
                        Console.WriteLine("NON");
                        Console.ReadLine();
                        return;
                    }
                    else
                    {
                        foreach (var j in jCandidat)
                        {
                            codeBarre[i, j] = '-';
                        }
                    }
                }
            }

            for (int i = 0; i < L; i++)
            {
                for (int j = 0; j < C; j++)
                {
                    Console.Write(codeBarre[i, j]);
                }

                Console.WriteLine();
            }

            Console.ReadLine();
        }

        private static int CountTiretCj(int j)
        {
            int c = 0;

            for (int i = 0; i < L; i++)
            {
                if (codeBarre[i, j] == '-')
                {
                    c++;
                }
            }

            return c;
        }

        private static int CountTiretLi(int i)
        {
            int c = 0;

            for (int j = 0; j < C; j++)
            {
                if (codeBarre[i, j] == '-')
                {
                    c++;
                }
            }

            return c;
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

        public IEnumerable<int> GetAllWordsAsInt()
        {
            return t.Select(_ => int.Parse(_));
        }
    }
}
