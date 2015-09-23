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

                    bool check = false;

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

                        check = true;

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

                    while (suma + answer[i].Length <= n)
                    {
                        suma += answer[i].Length;
                        if(index != 0)
                        {
                            suma += 1;
                        }

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


                    int probely = n - suma;
                    if (probely == 0)
                    {
                        for (int z = 0; z < index; z++)
                        {
                            if (z != 0)
                            {
                                sw.Write(" " + answer[i - index + z]);
                            }
                            else
                                sw.Write(answer[i - index + z]);

                        }
                    }
                    else 
                    {
                        int addProbely = probely / (index - 1);

                        for (int z = 0; z < index; z++)
                        {
                            if (z != 0)
                            {
                                if (z != index - 1)
                                {
                                    for (int y = 0; y < addProbely; y++)
                                    {
                                        sw.Write(" ");
                                    }
                                }
                                else 
                                {
                                    for (int y = 0; y < addProbely + probely % (index - 1); y++)
                                    {
                                        sw.Write(" ");
                                    }
                                }
                                sw.Write(answer[i - index + z]);
                            }
                            else
                                sw.Write(answer[i - index + z]);

                        }
                    }

                    sw.Write(Environment.NewLine);
                }
            }
        }
    }
}
