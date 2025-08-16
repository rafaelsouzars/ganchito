using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ganchito.Prompito.ConsoleScreen
{
    class AppScreenLetter
    {
        public char Character { get; private set; }
        public int[,] Font { get; private set; }

        // Lista de fontes estática na classe AppScreenLetter
        private static List<AppScreenLetter> alfabeto = new List<AppScreenLetter>();

        public static void Init()
        {
            // Populando a lista de fontes no construtor estático
            alfabeto = Alfabeto();
        }

        public AppScreenLetter(char character, int[,] font)
        {
            Character = character;
            Font = font;
        }

        public static void Display()
        {
            foreach (var letra in alfabeto)
            {
                int height = letra.Font.GetLength(0);
                int width = letra.Font.GetLength(1);

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        Console.Write(letra.Font[i, j] == 0 ? " " : "█"); // " " para espaços em branco, "█" para espaços preenchidos
                    }
                    Console.Write("  "); // Espaço entre letras
                }
                Console.WriteLine(); // Nova linha para a próxima linha da letra
            }

        }

        public static void DrawString(string input)
        {
            int height = alfabeto[0].Font.GetLength(0);

            for (int i = 0; i < height; i++)
            {
                foreach (var character in input)
                {
                    var letter = alfabeto.Find(l => char.ToLower(l.Character) == char.ToLower(character));
                    if (letter != null)
                    {
                        for (int j = 0; j < letter.Font.GetLength(1); j++)
                        {
                            Console.Write(letter.Font[i, j] == 0 ? " " : "█");
                        }
                        Console.Write("  "); // Espaço entre letras
                    }
                    else
                    {
                        Console.Write("     "); // Se a letra não estiver disponível, espaço em branco
                    }
                }
                Console.WriteLine(); // Nova linha para a próxima linha da letra
            }
        }

        private static List<AppScreenLetter> Alfabeto()
        {
            List<AppScreenLetter> alfabeto = new List<AppScreenLetter>();

            // Representações em matriz para cada letra de "a" a "z" com array 5x5
            int[,] fontA = {
            { 0, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 1 },
            { 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 1 }
        };
            alfabeto.Add(new AppScreenLetter('a', fontA));

            int[,] fontB = {
            { 1, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 0 }
        };
            alfabeto.Add(new AppScreenLetter('b', fontB));

            int[,] fontC = {
            { 0, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0 },
            { 0, 1, 1, 1, 0 }
        };
            alfabeto.Add(new AppScreenLetter('c', fontC));

            int[,] fontD = {
            { 1, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 0 }
        };
            alfabeto.Add(new AppScreenLetter('d', fontD));

            int[,] fontE = {
            { 1, 1, 1, 1, 1 },
            { 1, 0, 0, 0, 0 },
            { 1, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 0 },
            { 1, 1, 1, 1, 1 }
        };
            alfabeto.Add(new AppScreenLetter('e', fontE));

            int[,] fontF = {
            { 1, 1, 1, 1, 1 },
            { 1, 0, 0, 0, 0 },
            { 1, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0 }
        };
            alfabeto.Add(new AppScreenLetter('f', fontF));

            int[,] fontG = {
            { 0, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 0 },
            { 1, 0, 1, 1, 1 },
            { 1, 0, 0, 0, 1 },
            { 0, 1, 1, 1, 0 }
        };
            alfabeto.Add(new AppScreenLetter('g', fontG));

            int[,] fontH = {
            { 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 1 },
            { 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 1 }
        };
            alfabeto.Add(new AppScreenLetter('h', fontH));

            int[,] fontI = {
            { 1, 1, 1, 1, 1 },
            { 0, 1, 0, 1, 0 },
            { 0, 1, 0, 1, 0 },
            { 0, 1, 0, 1, 0 },
            { 1, 1, 1, 1, 1 }
        };
            alfabeto.Add(new AppScreenLetter('i', fontI));

            int[,] fontJ = {
            { 0, 0, 0, 0, 1 },
            { 0, 0, 0, 0, 1 },
            { 0, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 1 },
            { 0, 1, 1, 1, 0 }
        };
            alfabeto.Add(new AppScreenLetter('j', fontJ));

            int[,] fontK = {
            { 1, 0, 0, 0, 1 },
            { 1, 0, 0, 1, 0 },
            { 1, 1, 1, 0, 0 },
            { 1, 0, 0, 1, 0 },
            { 1, 0, 0, 0, 1 }
        };
            alfabeto.Add(new AppScreenLetter('k', fontK));

            int[,] fontL = {
            { 1, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0 },
            { 1, 1, 1, 1, 1 }
        };
            alfabeto.Add(new AppScreenLetter('l', fontL));

            int[,] fontM = {
            { 1, 0, 0, 0, 1 },
            { 1, 1, 0, 1, 1 },
            { 1, 0, 1, 0, 1 },
            { 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 1 }
        };
            alfabeto.Add(new AppScreenLetter('m', fontM));

            int[,] fontN = {
            { 1, 0, 0, 0, 1 },
            { 1, 1, 0, 0, 1 },
            { 1, 0, 1, 0, 1 },
            { 1, 0, 0, 1, 1 },
            { 1, 0, 0, 0, 1 }
        };
            alfabeto.Add(new AppScreenLetter('n', fontN));

            int[,] fontO = {
            { 0, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 1 },
            { 0, 1, 1, 1, 0 }
        };
            alfabeto.Add(new AppScreenLetter('o', fontO));

            int[,] fontP = {
            { 1, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0 }
        };
            alfabeto.Add(new AppScreenLetter('p', fontP));

            int[,] fontQ = {
            { 0, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 1 },
            { 1, 0, 1, 0, 1 },
            { 1, 0, 0, 1, 0 },
            { 0, 1, 1, 0, 1 }
        };
            alfabeto.Add(new AppScreenLetter('q', fontQ));

            int[,] fontR = {
            { 1, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 0 },
            { 1, 0, 1, 0, 1 },
            { 1, 0, 0, 1, 0 }
        };
            alfabeto.Add(new AppScreenLetter('r', fontR));

            int[,] fontS = {
            { 0, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 0 },
            { 0, 1, 1, 1, 0 },
            { 0, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 0 }
        };
            alfabeto.Add(new AppScreenLetter('s', fontS));

            int[,] fontT = {
            { 1, 1, 1, 1, 1 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0 }
        };
            alfabeto.Add(new AppScreenLetter('t', fontT));

            int[,] fontU = {
            { 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 1 },
            { 0, 1, 1, 1, 0 }
        };
            alfabeto.Add(new AppScreenLetter('u', fontU));

            int[,] fontV = {
            { 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 1 },
            { 0, 1, 0, 1, 0 },
            { 0, 1, 0, 1, 0 },
            { 0, 0, 1, 0, 0 }
        };
            alfabeto.Add(new AppScreenLetter('v', fontV));

            int[,] fontW = {
            { 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 1 },
            { 1, 0, 1, 0, 1 },
            { 1, 1, 0, 1, 1 },
            { 1, 0, 0, 0, 1 }
        };
            alfabeto.Add(new AppScreenLetter('w', fontW));

            int[,] fontX = {
            { 1, 0, 0, 0, 1 },
            { 0, 1, 0, 1, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 1, 0, 1, 0 },
            { 1, 0, 0, 0, 1 }
        };
            alfabeto.Add(new AppScreenLetter('x', fontX));

            int[,] fontY = {
            { 1, 0, 0, 0, 1 },
            { 0, 1, 0, 1, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0 }
        };
            alfabeto.Add(new AppScreenLetter('y', fontY));

            int[,] fontZ = {
            { 1, 1, 1, 1, 1 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 1, 0, 0, 0 },
            { 1, 1, 1, 1, 1 }
        };
            alfabeto.Add(new AppScreenLetter('z', fontZ));

            // Representações em matriz para os números de 0 a 9 com array 5x5
            int[,] font0 = {
            { 0, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 1 },
            { 0, 1, 1, 1, 0 }
        };
            alfabeto.Add(new AppScreenLetter('0', font0));

            int[,] font1 = {
            { 0, 0, 1, 0, 0 },
            { 0, 1, 1, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 1, 1, 1, 0 }
        };
            alfabeto.Add(new AppScreenLetter('1', font1));

            int[,] font2 = {
            { 0, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 1 },
            { 0, 0, 1, 1, 0 },
            { 0, 1, 0, 0, 0 },
            { 1, 1, 1, 1, 1 }
        };
            alfabeto.Add(new AppScreenLetter('2', font2));

            int[,] font3 = {
            { 1, 1, 1, 1, 0 },
            { 0, 0, 0, 0, 1 },
            { 0, 1, 1, 1, 0 },
            { 0, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 0 }
        };
            alfabeto.Add(new AppScreenLetter('3', font3));

            int[,] font4 = {
            { 1, 0, 0, 1, 0 },
            { 1, 0, 0, 1, 0 },
            { 1, 1, 1, 1, 1 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 }
        };
            alfabeto.Add(new AppScreenLetter('4', font4));

            int[,] font5 = {
            { 1, 1, 1, 1, 1 },
            { 1, 0, 0, 0, 0 },
            { 1, 1, 1, 1, 0 },
            { 0, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 0 }
        };
            alfabeto.Add(new AppScreenLetter('5', font5));

            int[,] font6 = {
            { 0, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 0 },
            { 1, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 1 },
            { 0, 1, 1, 1, 0 }
        };
            alfabeto.Add(new AppScreenLetter('6', font6));

            int[,] font7 = {
            { 1, 1, 1, 1, 1 },
            { 0, 0, 0, 0, 1 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0 }
        };
            alfabeto.Add(new AppScreenLetter('7', font7));

            int[,] font8 = {
            { 0, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 1 },
            { 0, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 1 },
            { 0, 1, 1, 1, 0 }
        };
            alfabeto.Add(new AppScreenLetter('8', font8));

            int[,] font9 = {
            { 0, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 1 },
            { 0, 1, 1, 1, 1 },
            { 0, 0, 0, 0, 1 },
            { 0, 1, 1, 1, 0 }
        };
            alfabeto.Add(new AppScreenLetter('9', font9));

            return alfabeto;
        }

        public static List<AppScreenLetter> GetAlphabet()
        {
            return alfabeto;
        }

    }
}
