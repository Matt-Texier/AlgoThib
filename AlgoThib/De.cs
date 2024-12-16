using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoThib
{
    internal class De
    {
        char[] lettres;
        int numéroduDe;
        char lettrechoisi;
        public De(int numéroduDe)
        {
            Lettres LettresEntiere = new Lettres();
            this.numéroduDe = numéroduDe;
            char[] lettres = new char[6];
            Random r = new Random();
            for (int i = 0; i < lettres.Length; i++)
            {
                int ra = r.Next(0, LettresEntiere.Charactère.Length);
                lettres[i] = LettresEntiere.Charactère[ra];
            }
            this.lettres = lettres;
        }
        public void Lance()
        {
            Random r = new Random();
            int num = r.Next(0, this.lettres.Length);
            char a = this.lettres[num];
            this.lettrechoisi = a;
        }

        public string toString()
        {
            string a = "Le dé numéro " + this.numéroduDe.ToString() + " contient les lettres : \n";
            string b = string.Empty;
            for (int i = 0; i < this.lettres.Length; i++)
            {
                b = b + this.lettres[i] + " ";
            }
            string c = "La lettre choisi au hasard est la lettre : ";
            return a + b + c;
        }
        public char LettreChoisi
        {
            get { return lettrechoisi; }
            set { lettrechoisi = value; }
        }
    }
}
