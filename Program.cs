using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Kyrcu
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            string text;

            //Считываем данные
            using (StreamReader sr = File.OpenText("in.txt"))
            {
                string s = "";

                s = sr.ReadLine();
                n = Int32.Parse(s);

                text = sr.ReadLine();
            }

            using (StreamWriter sw = File.CreateText("out.txt"))
            {
                string[] answer = text.Split(' ');
                int countWord = 1;

                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] == ' ')
                        countWord++;
                }

                for (int i = 0; i < countWord; i++)
                {
                    sw.WriteLine(answer[i]);
                }
            }
        }
    }
}
