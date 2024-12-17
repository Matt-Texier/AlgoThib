using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoThib
{
    internal class Dictionnaire
    {
        public string langue;
        public string Dico;
        public List<string> dictionnaire;
        public List<List<string>> dictionnaireList;
        public string alphabet;
        public Dictionnaire(string langue)
        {
            this.langue = langue;
            string content = string.Empty;
            if (this.langue == "Française" || this.langue == "Francaise")
            {
                string filePath = "C:\\Users\\matth\\source\\data\\AlgoThib\\MotsPossiblesFR.txt";
                content = File.ReadAllText(filePath);
            }
            else if (this.langue == "Anglaise" || this.langue == "Anglais")
            {
                string filePath = "C:\\Users\\matth\\source\\data\\AlgoThib\\MotsPossiblesEN.txt";
                content = File.ReadAllText(filePath);
            }
            this.Dico = content;
            List<string> Dicolist = new List<string>();
            List<List<string>> DicoWithLen = new List<List<string>>();
            // on assume que le taille maximum d'un mot est de 30 carateres
            // on initialise la list de lits de string
            for (int i = 0; i < 30; i++)
            {
                List<string> ListDeMots = new List<string>();
                DicoWithLen.Add(ListDeMots);
            }
            string a = string.Empty;
            for (int i = 0; i < content.Length; i++)
            {
                if (content[i] != ' ')
                {
                    a = a + content[i];
                }
                if (content[i] == ' ')
                {
                    Dicolist.Add(a);
                    // on range les mots dans la tableau à lindex correspondant à sa taille
                    DicoWithLen[a.Length].Add(a);
                    a = string.Empty;
                }
            }
            this.dictionnaire = Dicolist;
            this.dictionnaireList = DicoWithLen;
            string g = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            this.alphabet = g;
        }

        static List<string> TriFusion(List<string> list)
        {
            if (list.Count == 1)
            {
                return list;
            }

            int milieu = list.Count / 2;
            List<string> gauche = new List<string>();
            List<string> droite = new List<string>();
            for (int i = 0; i < milieu; i++)
            {
                gauche.Add(list[i]);
            }
            for (int i = milieu; i < list.Count; i++)
            {
                droite.Add(list[i]);
            }
            gauche = TriFusion(gauche);
            droite = TriFusion(droite);

            return Fusionner(gauche, droite);
        }

        static List<string> Fusionner(List<string> left, List<string> right)
        {
            List<string> result = new List<string>();
            int i = 0;
            int j = 0;

            while (i < left.Count && j < right.Count)
            {
                if (string.Compare(left[i], right[j]) < 0)
                {
                    result.Add(left[i]);
                    i++;
                }
                else
                {
                    result.Add(right[j]);
                    j++;
                }
            }
            while (i < left.Count)
            {
                result.Add(left[i]);
                i++;
            }

            while (j < right.Count)
            {
                result.Add(right[j]);
                j++;
            }

            return result;
        }

        public void TriList()
        {
            List<string> dicotrie = TriFusion(this.dictionnaire);
            this.dictionnaire = dicotrie;
        }

        public void TriListOfList()
        {
            for (int i = 0; i < this.dictionnaireList.Count; i++)
            {
                if(this.dictionnaireList[i].Count > 0)
                {
                    List<string> SortedList = TriFusion(this.dictionnaireList[i]);
                    this.dictionnaireList[i] = SortedList;
                }
            }

        }
        /*public void FirstPutDicoList()
        {
            List<List<string>> ListdeList = new List<List<string>>();
            string a = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for (int j = 0; j < a.Length; j++)
            {
                List<string> sublist = new List<string>();
                for (int i = 0; i < this.dictionnaire.Count; i++)
                {
                    if (this.dictionnaire[i] != null && this.dictionnaire[i].Length != 0 && this.dictionnaire[i][0] == a[j])
                    {
                        sublist.Add(this.dictionnaire[i]);
                    }
                }
                int n = sublist.Count;
                for (int i = 0; i < n - 1; i++)
                {
                    int minIndex = i;
                    for (int k = i + 1; k < n; k++)
                    {
                        if (sublist[k].Length < sublist[minIndex].Length)
                        {
                            minIndex = k;
                        }
                    }
                    if (minIndex != i)
                    {
                        string temp = sublist[i];
                        sublist[i] = sublist[minIndex];
                        sublist[minIndex] = temp;
                    }
                }
                ListdeList.Add(sublist);
            }
            this.dictionnaireList = ListdeList;
        }
        */



        public string toString()
        {
            int c = 0;
            int[] nombredoccurences = new int[24];
            /// <summary>
            /// nombredoccurences sont les occurences des longueurs en question.
            /// Le mot le plus long de la langue française fait 25 lettres donc un tableau de 24 de Length (la première longueur commençant à 1).
            /// </summary>
            /// <returns></returns>


            for (int i = 0; i < this.Dico.Length; i++)
            {
                if (this.Dico[i] != ' ')
                {
                    c++;
                }
                if (this.Dico[i] == ' ')
                {
                    for (int j = 0; j < nombredoccurences.Length; j++)
                    {
                        if (c == j + 1)
                        {
                            nombredoccurences[j]++;
                        }
                    }
                    c = 0;
                }
            }
            int c2 = 0;
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int[] occurences2 = new int[26];
            int[] nouvellesoccurences2 = new int[26];

            for (int i = 0; i < this.Dico.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (this.Dico[i] == alphabet[j])
                    {
                        nouvellesoccurences2[j]++;
                    }
                    if (this.Dico[i] == ' ')
                    {
                        for (int k = 0; k < alphabet.Length; k++)
                        {
                            if (nouvellesoccurences2[k] > 0)
                            {
                                occurences2[k]++;
                            }
                        }
                        for (int o = 0; o < nouvellesoccurences2.Length; o++)
                        {
                            nouvellesoccurences2[o] = 0;
                        }
                    }
                }
            }
            string b = "Voici le nombre de mots par longueur : \n";
            string a = string.Empty;
            for (int i = 0; i < nombredoccurences.Length; i++)
            {
                a = a + "Il y a " + nombredoccurences[i] + " mots de longueur " + (i + 1) + "\n";
            }
            string d = "Voici le nombre de mots par lettre : \n";
            string e = string.Empty;
            for (int i = 0; i < alphabet.Length; i++)
            {
                e = e + "Il y a " + occurences2[i] + " mots qui possèdent la lettre " + alphabet[i] + "\n";
            }
            return b + a + d + e;

        }


        public bool RechDicoRecursif(string mot, int debut = 0, int fin = -3)
        {
            if (fin == -3)
            { fin = this.dictionnaire.Count; }
            if (debut == fin)
            { return false; }

            int milieu = (debut + fin) / 2;

            int comparaison = string.Compare(mot, this.dictionnaire[milieu], StringComparison.Ordinal);

            if (comparaison == 0)
            {
                return true;
            }
            else if (comparaison < 0)
            {
                return RechDicoRecursif(mot, debut, milieu - 1);
            }
            else if (comparaison > 0)
            {
                return RechDicoRecursif(mot, milieu + 1, fin);
            }
            else
            {
                return false;
            }
        }

        public bool RechDicoOpt(string mot, int debut = 0, int fin = -3)
        {
            if (fin == -3)
            { fin = this.dictionnaireList[mot.Length].Count; }
            if (debut > fin)
            { return false; }

            int milieu = (debut + fin) / 2;

            int comparaison = string.Compare(mot, this.dictionnaireList[mot.Length][milieu], StringComparison.Ordinal);

            if (comparaison == 0)
            {
                return true;
            }
            else if (comparaison < 0)
            {
                return RechDicoRecursif(mot, debut, milieu - 1);
            }
            else if (comparaison > 0)
            {
                return RechDicoRecursif(mot, milieu + 1, fin);
            }
            else
            {
                return false;
            }
        }
        /*public bool RechDicoRecursif2(string mot, int debut = 0, int fin = -3)
        {
            List <string> listCherche = new List <string>();
            for(int i = 0; i < this.alphabet.Length;i++)
            {
                if (mot[0] == this.alphabet[i])
                { listCherche = this.dictionnaireList[i]; }
            }
            if (fin == -3)
            { fin = listCherche.Count-1; }
            if (debut == fin)
            { return false; }

            int milieu = (debut + fin) / 2;

            if (listCherche[milieu]== mot)
            {
                return true;
            }
            else if (mot.Length <= listCherche[milieu].Length)
            {
                return RechDicoRecursif2(mot, debut, milieu - 1);
            }
            else if (mot.Length >= listCherche[milieu].Length)
            {
                return RechDicoRecursif2(mot, milieu + 1, fin);
            }
            else
            {
                return false;
            }
        }
        */
    }

}
