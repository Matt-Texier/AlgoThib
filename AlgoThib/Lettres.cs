using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoThib
{
    internal class Lettres
    {
        public char[] charactère;
        public int[] score;
        public int[] positionnement;

        public Lettres()
        {
            string filePath = "C:\\Users\\matth\\source\\data\\AlgoThib\\Lettres.txt";
            string[] content = File.ReadAllLines(filePath);
            char[] charac = new char[26];
            int[] score = new int[26];
            int[] positionnement = new int[26];
            for (int i = 0; i < content.Length; i++)
            {
                if (i == 4)
                {
                    charac[i] = content[i][0];
                    score[i] = int.Parse(content[i][2].ToString());
                    positionnement[i] = int.Parse(content[i][4].ToString() + content[i][5].ToString());
                }
                else if (i == 10)
                {
                    charac[i] = content[i][0];
                    score[i] = int.Parse(content[i][2].ToString() + content[i][3].ToString());
                    positionnement[i] = int.Parse(content[i][5].ToString());
                }
                else if (i >= 22)
                {
                    charac[i] = content[i][0];
                    score[i] = int.Parse(content[i][2].ToString() + content[i][3].ToString());
                    positionnement[i] = int.Parse(content[i][5].ToString());
                }
                else
                {
                    charac[i] = content[i][0];
                    score[i] = int.Parse(content[i][2].ToString());
                    positionnement[i] = int.Parse(content[i][4].ToString());
                }
            }
            this.charactère = charac;
            this.score = score;
            this.positionnement = positionnement;
        }
        public string toString()
        {
            string a = "";
            for (int i = 0; i < this.charactère.Length; i++)
            {

                a = a + this.charactère[i] + " , ";
            }
            a = a + "\n";
            string b = "";

            for (int i = 0; i < this.score.Length; i++)
            {
                b = b + this.score[i] + " , ";
            }
            b = b + "\n";
            string c = "";
            for (int i = 0; i < this.positionnement.Length; i++)
            {
                c = c + this.positionnement[i] + " , ";
            }
            c = c + "\n";
            return a + b + c;
        }
        public char[] Charactère
        {
            get { return charactère; }
            set { charactère = value; }
        }
        public int[] Score
        {
            get { return score; }
            set { score = value; }
        }
        public int[] Positionnement
        {
            get { return positionnement; }
            set { positionnement = value; }
        }
    }
}
