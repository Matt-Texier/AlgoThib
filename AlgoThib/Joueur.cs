using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoThib
{
    internal class Joueur
    {
        public string nom;
        public int score;
        public string[] mots;

        public Joueur(string nom, int score, string[] mots)
        {
            this.nom = nom;
            this.score = score;
            this.mots = mots;
        }

        public bool Contain(string mot)
        {
            bool res = false;
            for (int i = 0; i < this.mots.Length; i++)
            {
                if (mot == this.mots[i])
                {
                    res = true;
                }
            }
            return res;
        }

        public void Add_Mot(string mot)
        {
            string[] nvtab = new string[this.mots.Length];
            for (int i = 0; i < this.mots.Length; i++)
            {
                nvtab[i] = this.mots[i];
            }
            nvtab[nvtab.Length - 1] = mot;
            this.mots = nvtab;
        }

        public string toString()
        {
            string a = "Le  joueur nommé" + this.nom + "\n";
            string b = "possède les mots suivants : " + "\n";
            string c = string.Empty;
            for (int i = 0; i < this.mots.Length; i++)
            {
                c = c + this.mots[i] + "\n";
            }
            string d = "Ce qui correspond à un score de : " + this.score + "\n";
            return a + b + c + d;
        }
    }
}
