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
                string formatText = ""; // Cтрока без лишних пробелов
                int countWord = 1; // Количество слов
                bool checkOneWorld = false;

                //Cчитаем кол-во слов и записываем formatText
                for (int i = 0; i < text.Length; i++)
                {
                    checkOneWorld = false;
                    formatText += text[i].ToString();

                    if (text[i] == ' ')
                    {
                        checkOneWorld = true;

                        countWord++;

                        //Несколько пробелов
                        while (i < text.Length - 1 && text[i] == text[i + 1])
                        {
                            i++;
                        }
                    }
                }

                

                if (checkOneWorld != true)
                {
                    string[] answer = formatText.Split(' '); // Массив слов
                    int index = 0; // Кол-во использованых слов

                    while (index < countWord) // Пока есть слова, которыми нужно заполнять 
                    {
                        int suma = 0;
                        int countNeedSub = 0;
                        bool checkFirstWord = false; // Проверка на первое слово в строке

                        if (answer[index].Length > n) // Если первое слово полностью не влезает в строку
                        {
                            int buff = 0;
                            for(int k = 0; k + n < answer[index].Length; k+=n)
                            {
                                for (int i = 0; i < n; i++)
                                {
                                    buff++;
                                    sw.Write(answer[index][i + k]);
                                }

                                sw.Write(Environment.NewLine);
                            }

                            string kostil = "";
                            for (int i = 0; i < answer[index].Length - buff; i++)// Костыль
                            {
                                suma++;
                                kostil += answer[index][i+buff].ToString();    
                            }

                            answer[index] = kostil;
                            index++;
                            countNeedSub++;
                            checkFirstWord = true;
                        }

                        if (index == countWord) // Выйти если слово заняло всё место
                            break;

                        int spaseNeedSub = 0;

                        while (suma + answer[index].Length < n)
                        {


                            if (checkFirstWord == false)
                            {
                                checkFirstWord = true;
                            }
                            else
                            {
                                suma += 1;
                                spaseNeedSub++;
                            }

                            suma += answer[index].Length;
                            countNeedSub++;
                            index++;

                            if (index == countWord)
                                break;
                        }

                        int neededSpace = n - suma + spaseNeedSub;// Недостающие пробелы
                        int[] masSpace = new int[countNeedSub-1];

                        if (countNeedSub != 1)
                        {
                            for (int i = 0, k = 0; i < neededSpace; i++, k++)// Расчитать пробелы между словами
                            {
                                masSpace[k]++;

                                if (k + 1 == countNeedSub - 1)
                                    k = -1;
                            }
                        }

                        // Записать слова в файл
                        sw.Write(answer[index - countNeedSub]);

                        for (int i = 0; i < countNeedSub-1; i++)
                        {
                            for (int j = 0; j < masSpace[i]; j++)
                            {
                                sw.Write(" ");
                            }

                            sw.Write(answer[index - countNeedSub + i + 1]);
                        }

                        sw.Write(Environment.NewLine);

                    }
                }
                else 
                {
                    int buff = 0;
                    for (int k = 0; k + n < formatText.Length; k += n)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            buff++;
                            sw.Write(formatText[i + k]);
                        }

                        sw.Write(Environment.NewLine);
                    }

                    for (int i = 0; i < formatText.Length - buff; i++)
                    {
                        sw.Write(formatText[i + buff]);
                    }
                }
                
            }
        }
    }
}
