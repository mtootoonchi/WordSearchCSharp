using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Search
{
    class Solver
    {
        private string[,] crossword = null;
        private List<string> words = null;
        private string[,] solved = null;
        private string[,] LeftChecked = null;
        private string[,] RightChecked = null;
        private string[,] UpChecked = null;
        private string[,] DownChecked = null;
        private string[,] LeftUpChecked = null;
        private string[,] RightUpChecked = null;
        private string[,] LeftDownChecked = null;
        private string[,] RightDownChecked = null;

        public Solver(string[,] crossword, List<string> words)
        {
            this.crossword = crossword;
            this.words = words;
            solved = new string[crossword.GetLength(0), crossword.GetLength(1)];
            LeftChecked = new string[crossword.GetLength(0), crossword.GetLength(1)];
            RightChecked = new string[crossword.GetLength(0), crossword.GetLength(1)];
            UpChecked = new string[crossword.GetLength(0), crossword.GetLength(1)];
            DownChecked = new string[crossword.GetLength(0), crossword.GetLength(1)];
            LeftUpChecked = new string[crossword.GetLength(0), crossword.GetLength(1)];
            RightUpChecked = new string[crossword.GetLength(0), crossword.GetLength(1)];
            LeftDownChecked = new string[crossword.GetLength(0), crossword.GetLength(1)];
            RightDownChecked = new string[crossword.GetLength(0), crossword.GetLength(1)];
            for (int i = 0; i < crossword.GetLength(0); i++)
            {
                for (int j = 0; j < crossword.GetLength(1); j++)
                {
                    solved[i, j] = "-";
                    LeftChecked[i, j] = "-";
                    RightChecked[i, j] = "-";
                    UpChecked[i, j] = "-";
                    DownChecked[i, j] = "-";
                    LeftUpChecked[i, j] = "-";
                    RightUpChecked[i, j] = "-";
                    LeftDownChecked[i, j] = "-";
                    RightDownChecked[i, j] = "-";
                }
            }
        }
        public void Solve()
        {
            for (int i = 0; i < words.Count; i++)
            {
                for (int j = 0; j < crossword.GetLength(0); j++)
                {
                    for (int k = 0; k < crossword.GetLength(1); k++)
                    {
                        Check(j, k, words.ElementAt(i));
                    }
                }
            }
        }
        private void Check(int a, int b, string c)
        {
            if (crossword[a, b].Equals(c.Substring(0, crossword[a, b].Length)))
            {
                LeftChecked[a, b] = c.Substring(0, crossword[a, b].Length);
                RightChecked[a, b] = c.Substring(0, crossword[a, b].Length);
                UpChecked[a, b] = c.Substring(0, crossword[a, b].Length);
                DownChecked[a, b] = c.Substring(0, crossword[a, b].Length);
                LeftUpChecked[a, b] = c.Substring(0, crossword[a, b].Length);
                RightUpChecked[a, b] = c.Substring(0, crossword[a, b].Length);
                LeftDownChecked[a, b] = c.Substring(0, crossword[a, b].Length);
                RightDownChecked[a, b] = c.Substring(0, crossword[a, b].Length);
                LeftCheck(a, b - 1, c, crossword[a, b].Length);
                RightCheck(a, b + 1, c, crossword[a, b].Length);
                UpCheck(a + 1, b, c, crossword[a, b].Length);
                DownCheck(a - 1, b, c, crossword[a, b].Length);
                LeftUpCheck(a - 1, b + 1, c, crossword[a, b].Length);
                RightUpCheck(a + 1, b + 1, c, crossword[a, b].Length);
                LeftDownCheck(a - 1, b - 1, c, crossword[a, b].Length);
                RightDownCheck(a + 1, b - 1, c, crossword[a, b].Length);
            }

        }
        private void LeftCheck(int a, int b, string c, int d)
        {
            if (c.Length <= d)
            {
                for (int i = 0; i < solved.GetLength(0); i++)
                {
                    for (int j = 0; j < solved.GetLength(1); j++)
                    {
                        if (solved[i, j].Equals("-"))
                        {
                            solved[i, j] = LeftChecked[i, j];
                        }
                        LeftChecked[i, j] = "-";
                    }
                }
            }
            else if (a < 0 || b < 0 || a > crossword.GetLength(0) - 1 || b > crossword.GetLength(1) - 1 || !crossword[a, b].Equals(c.Substring(d, crossword[a, b].Length)))
            {
                for (int i = 0; i < LeftChecked.GetLength(0); i++)
                {
                    for (int j = 0; j < LeftChecked.GetLength(1); j++)
                    {
                        LeftChecked[i, j] = "-";
                    }
                }
            }
            else
            {
                LeftChecked[a, b] = c.Substring(d, crossword[a, b].Length);
                LeftCheck(a, b - 1, c, d + crossword[a, b].Length);
            }
        }
        private void RightCheck(int a, int b, string c, int d)
        {
            if (c.Length <= d)
            {
                for (int i = 0; i < solved.GetLength(0); i++)
                {
                    for (int j = 0; j < solved.GetLength(1); j++)
                    {
                        if (solved[i, j].Equals("-"))
                        {
                            solved[i, j] = RightChecked[i, j];
                        }
                        LeftChecked[i, j] = "-";
                    }
                }
            }
            else if (a < 0 || b < 0 || a > crossword.GetLength(0) - 1 || b > crossword.GetLength(1) - 1 || !crossword[a, b].Equals(c.Substring(d, crossword[a, b].Length)))
            {
                for (int i = 0; i < RightChecked.GetLength(0); i++)
                {
                    for (int j = 0; j < RightChecked.GetLength(1); j++)
                    {
                        RightChecked[i, j] = "-";
                    }
                }
            }
            else
            {
                RightChecked[a, b] = c.Substring(d, crossword[a, b].Length);
                RightCheck(a, b + 1, c, d + crossword[a, b].Length);
            }
        }
        private void UpCheck(int a, int b, string c, int d)
        {
            if (c.Length <= d)
            {
                for (int i = 0; i < solved.GetLength(0); i++)
                {
                    for (int j = 0; j < solved.GetLength(1); j++)
                    {
                        if (solved[i, j].Equals("-"))
                        {
                            solved[i, j] = UpChecked[i, j];
                        }
                        LeftChecked[i, j] = "-";
                    }
                }
            }
            else if (a < 0 || b < 0 || a > crossword.GetLength(0) - 1 || b > crossword.GetLength(1) - 1 || !crossword[a, b].Equals(c.Substring(d, crossword[a, b].Length)))
            {
                for (int i = 0; i < UpChecked.GetLength(0); i++)
                {
                    for (int j = 0; j < UpChecked.GetLength(1); j++)
                    {
                        UpChecked[i, j] = "-";
                    }
                }
            }
            else
            {
                UpChecked[a, b] = c.Substring(d, crossword[a, b].Length);
                UpCheck(a + 1, b, c, d + crossword[a, b].Length);
            }
        }
        private void DownCheck(int a, int b, string c, int d)

        {
            if (c.Length <= d)
            {
                for (int i = 0; i < solved.GetLength(0); i++)
                {
                    for (int j = 0; j < solved.GetLength(1); j++)
                    {
                        if (solved[i, j].Equals("-"))
                        {
                            solved[i, j] = DownChecked[i, j];
                        }
                        DownChecked[i, j] = "-";
                    }
                }
            }
            else if (a < 0 || b < 0 || a > crossword.GetLength(0) - 1 || b > crossword.GetLength(1) - 1 || !crossword[a, b].Equals(c.Substring(d, crossword[a, b].Length)))
            {
                for (int i = 0; i < DownChecked.GetLength(0); i++)
                {
                    for (int j = 0; j < DownChecked.GetLength(1); j++)
                    {
                        DownChecked[i, j] = "-";
                    }
                }
            }
            else
            {
                DownChecked[a, b] = c.Substring(d, crossword[a, b].Length);
                DownCheck(a - 1, b, c, d + crossword[a, b].Length);
            }
        }
        private void LeftUpCheck(int a, int b, string c, int d)
        {
            if (c.Length <= d)
            {
                for (int i = 0; i < solved.GetLength(0); i++)
                {
                    for (int j = 0; j < solved.GetLength(1); j++)
                    {
                        if (solved[i, j].Equals("-"))
                        {
                            solved[i, j] = LeftUpChecked[i, j];
                        }
                        LeftUpChecked[i, j] = "-";
                    }
                }
            }
            else if (a < 0 || b < 0 || a > crossword.GetLength(0) - 1 || b > crossword.GetLength(1) - 1 || !crossword[a, b].Equals(c.Substring(d, crossword[a, b].Length)))
            {
                for (int i = 0; i < LeftUpChecked.GetLength(0); i++)
                {
                    for (int j = 0; j < LeftUpChecked.GetLength(1); j++)
                    {
                        LeftUpChecked[i, j] = "-";
                    }
                }
            }
            else
            {
                LeftUpChecked[a, b] = c.Substring(d, crossword[a, b].Length);
                LeftUpCheck(a - 1, b + 1, c, d + crossword[a, b].Length);
            }
        }
        private void RightUpCheck(int a, int b, string c, int d)
        {
            if (c.Length <= d)
            {
                for (int i = 0; i < solved.GetLength(0); i++)
                {
                    for (int j = 0; j < solved.GetLength(1); j++)
                    {
                        if (solved[i, j].Equals("-"))
                        {
                            solved[i, j] = RightUpChecked[i, j];
                        }
                        LeftChecked[i,j] = "-";
                    }
                }
            }
            else if (a < 0 || b < 0 || a > crossword.GetLength(0) - 1 || b > crossword.GetLength(1) - 1 || !crossword[a, b].Equals(c.Substring(d, crossword[a, b].Length)))
            {
                for (int i = 0; i < RightUpChecked.GetLength(0); i++)
                {
                    for (int j = 0; j < RightUpChecked.GetLength(1); j++)
                    {
                        RightUpChecked[i, j] = "-";
                    }
                }
            }
            else
            {
                RightUpChecked[a, b] = c.Substring(d, crossword[a, b].Length);
                RightUpCheck(a + 1, b + 1, c, d + crossword[a, b].Length);
            }
        }
        private void LeftDownCheck(int a, int b, string c, int d)
        {
            if (c.Length <= d)
            {
                for (int i = 0; i < solved.GetLength(0); i++)
                {
                    for (int j = 0; j < solved.GetLength(1); j++)
                    {
                        if (solved[i, j].Equals("-"))
                        {
                            solved[i, j] = LeftDownChecked[i, j];
                        }
                        LeftChecked[i, j] = "-";
                    }
                }
            }
            else if (a < 0 || b < 0 || a > crossword.GetLength(0) - 1 || b > crossword.GetLength(1) - 1 || !crossword[a, b].Equals(c.Substring(d, crossword[a, b].Length)))
            {
                for (int i = 0; i < LeftDownChecked.GetLength(0); i++)
                {
                    for (int j = 0; j < LeftDownChecked.GetLength(1); j++)
                    {
                        LeftDownChecked[i, j] = "-";
                    }
                }
            }
            else
            {
                LeftDownChecked[a, b] = c.Substring(d, crossword[a, b].Length);
                LeftDownCheck(a - 1, b - 1, c, d + crossword[a, b].Length);
            }
        }
        private void RightDownCheck(int a, int b, string c, int d)
        {
            if (c.Length <= d)
            {
                for (int i = 0; i < solved.GetLength(0); i++)
                {
                    for (int j = 0; j < solved.GetLength(1); j++)
                    {
                        if (solved[i, j].Equals("-"))
                        {
                            solved[i, j] = RightDownChecked[i, j];
                        }
                        RightDownChecked[i, j] = "-";
                    }
                }
            }
            else if (a < 0 || b < 0 || a > crossword.GetLength(0) - 1 || b > crossword.GetLength(1) - 1 || !crossword[a, b].Equals(c.Substring(d, crossword[a, b].Length)))
            {
                for (int i = 0; i < RightDownChecked.GetLength(0); i++)
                {
                    for (int j = 0; j < RightDownChecked.GetLength(1); j++)
                    {
                        RightDownChecked[i, j] = "-";
                    }
                }
            }
            else
            {
                RightDownChecked[a, b] = c.Substring(d, crossword[a, b].Length);
                RightDownCheck(a + 1, b - 1, c, d + crossword[a, b].Length);
            }
        }
        public void Solved()
        {
            for (int i = 0; i < solved.GetLength(0); i++)
            {
                Console.Write("|");
                for (int j = 0; j < solved.GetLength(1); j++)
                {
                    Console.Write(solved[i, j]);
                }
                Console.WriteLine("|");
            }
        }
        public string toString()
        {
            return "";
        }
    }
}
