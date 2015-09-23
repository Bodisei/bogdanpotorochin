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

                for (int i = 0; i < countWord; )
                {
                    int index = 0, suma = 0;

                    if (answer[i].Length > n)
                    {
                        for (int z = 0; z < answer[i].Length; z++)
                        {
                            suma++;

                            sw.Write(answer[i][z]);

                            if (suma % n == 0)
                            {
                                suma = 0;
                                sw.Write(Environment.NewLine);
                            }
                        }

                        if (i < countWord - 1)
                        {
                            i++;
                        }
                        else
                        {
                            i++;
                            break;
                        }

                        index = 1;
                    }

                    while (suma + answer[i].Length < n)
                    {
                        suma += answer[i].Length;
                        if(index != 0)
                        {
                            sw.Write(" " + answer[i]);
                            suma += 1;
                        }
                        else
                            sw.Write(answer[i]);

                        index++;
                        if (i < countWord - 1)
                        {
                            i++;
                        }
                        else
                        {
                            i++;
                            break;
                        }
                      
                        
                    }

                    sw.Write(Environment.NewLine);
                }
            }
        }
    }
}
