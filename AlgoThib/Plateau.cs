using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoThib
{
    internal class Plateau
    {
        int plateaunum;
        public De[,] des;
        public char[,] faces;
        int taille;
        Lettres lettres;
        public Plateau(int numéroplateau, int taille)
        {
            this.plateaunum = numéroplateau;
            this.lettres = new Lettres();
            this.taille = taille;
            char[,] faces = new char[taille, taille];
            De[,] des1 = new De[taille, taille];
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int[] tabmax = new int[alphabet.Length];
            int[] itérations = new int[alphabet.Length];
            for (int i = 0; i < tabmax.Length; i++)
            {
                tabmax[i] = lettres.Positionnement[i];
            }
            for (int i = 0; i < des1.GetLength(0); i++)
            {
                for (int j = 0; j < des1.GetLength(1); j++)
                {
                    des1[i, j] = new De(i + j);
                }
            }
            for (int i = 0; i < des1.GetLength(0); i++)
            {
                for (int j = 0; j < des1.GetLength(1); j++)
                {
                    faces[i, j] = ' ';
                }
            }
            for (int i = 0; i < faces.GetLength(0); i++)
            {
                for (int j = 0; j < faces.GetLength(1); j++)
                {
                    while (faces[i, j] == ' ')
                    {
                        des1[i, j].Lance();
                        for (int k = 0; k < alphabet.Length; k++)
                        {
                            if (des1[i, j].LettreChoisi == alphabet[k] && itérations[k] < tabmax[k])
                            {
                                faces[i, j] = des1[i, j].LettreChoisi;
                                itérations[k]++;
                            }
                        }
                    }
                }
            }
            this.des = des1;
            this.faces = faces;
        }

        public string ToString()
        {
            string a = "Voici le plateau numéro " + this.plateaunum + ", il est de taille " + this.taille + " : \n";
            string b = string.Empty;
            for (int i = 0; i < this.faces.GetLength(0); i++)
            {
                for (int j = 0; j < this.faces.GetLength(1); j++)
                {
                    b = b + " " + this.faces[i, j].ToString();
                }
                b = b + "\n";
            }
            return a + b;
        }
        public bool FormeMot(string mot)
        {
            int rows = this.faces.GetLength(0);
            int cols = this.faces.GetLength(1);
            bool[,] visité = new bool[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (this.faces[i, j] == mot[0])
                    {
                        if (ChercheMot(mot, 0, i, j, visité))
                            return true;
                    }
                }
            }

            return false;
        }

        public bool ChercheMot(string mot, int index, int x, int y, bool[,] visité)
        {
            if (index == mot.Length)
            { return true; }
            if (x < 0 || x >= this.faces.GetLength(0) || y < 0 || y >= this.faces.GetLength(1) ||
                visité[x, y] || this.faces[x, y] != mot[index])
            {
                return false;
            }
            visité[x, y] = true;
            bool trouvé =
                ChercheMot(mot, index + 1, x - 1, y, visité) ||
                ChercheMot(mot, index + 1, x + 1, y, visité) ||
                ChercheMot(mot, index + 1, x, y - 1, visité) ||
                ChercheMot(mot, index + 1, x, y + 1, visité) ||
                ChercheMot(mot, index + 1, x - 1, y - 1, visité) ||
                ChercheMot(mot, index + 1, x + 1, y - 1, visité) ||
                ChercheMot(mot, index + 1, x - 1, y + 1, visité) ||
                ChercheMot(mot, index + 1, x + 1, y + 1, visité);

            visité[x, y] = false;

            return trouvé;
        }
    }
}
