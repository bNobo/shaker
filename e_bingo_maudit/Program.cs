using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_bingo_maudit
{
    class Program
    {
        static void Main(string[] args)
        {
            var line1 = new Line(Console.ReadLine());
            int N = line1.GetWordAsInt(0);
            int E = line1.GetWordAsInt(1);

            var couloirs = new HashSet<Couloir>();
            var salles = new HashSet<int>();

            for (int i = 0; i < E; i++)
            {
                var line = new Line(Console.ReadLine());
                int a = line.GetWordAsInt(0);
                int b = line.GetWordAsInt(1);

                couloirs.Add(new Couloir { Salles = { a, b } });
                salles.Add(a);
                salles.Add(b);
            }

            for (int i = 0; i < couloirs.Count; i++)
            {
                var copy = couloirs.Skip(i);

                for (int j = 0; j < salles.Count; j++)
                {
                    if (!copy.Any(c => c.Salles.Any(s => s == j)))
                    {
                        Console.WriteLine(j+1);
                        Console.ReadLine();
                        return;
                    }
                }
            }

            Console.WriteLine(couloirs);
            Console.ReadLine();
        }
    }

    public class Couloir
    {
        public HashSet<int> Salles = new HashSet<int>();
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
