using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Annotations;

namespace WpfApp2
{
    public class StudentBook
    {

            int id;
            string FullName;
            private int n = 0;

            struct Item
            {
                public string type;
                public int result;
                public int numberS;
                public string ItemName;
            }

            List<Item> Predmets = new List<Item>();

            public StudentBook(int id, string FullName)
            {
                this.id = id;
                this.FullName = FullName;
            }

            public StudentBook()
            {

            }
            public void Add(string type, int result, int numberS, string ItemName)
            {
                Item temp = new Item();
                temp.type = type;
                temp.result = result;
                temp.numberS = numberS;
                temp.ItemName = ItemName;
                Predmets.Add(temp);
                n++;
            }

            public void Vivod()
            {
                for (int i = 0; i < n; i++)
                    Console.WriteLine(Predmets[i].numberS + " " + Predmets[i].result + " " + Predmets[i].type + " " + Predmets[i].ItemName);

            }

            public float average()
            {
            float average = 0;
            float summ = 0;
            for (int i = 0; i < n; i++)
            {
                summ += Predmets[i].result;
            }
            average = summ / n;
            return average;
            }
            public string Stipendia()
            {

                int min = 5;
                int max = 0;

                for (int i = 0; i < n; i++)
                {
                    if ((Predmets[i].numberS > max))
                    {
                        max = Predmets[i].numberS;
                    }
                }

            for (int i = 0; i < n; i++)
                { 
                    if (((Predmets[i].result < min) && ((Predmets[i].type=="Экзамен") || (Predmets[i].type=="Диф зачёт")) && (Predmets[i].numberS==max)))
                    {
                        min = Predmets[i].result;
                    }
                    else
                    {
                        return "Нет оценок, чтобы определить стипендию";
                    }
                }

                if (min == 5)
                {
                    return "Повышенная стипендия";
                }
                if (min == 4)
                {
                    return "Стипендия не повышенная";
                }
                else
                {
                    return "Стипендии нет";
                }


            }


            public string Diplom()
            {
                int max = 0;
                float average = 0;
                for (int i = 0; i < n; i++)
                {
                    if (Predmets[i].numberS > max)
                    {
                        max = Predmets[i].numberS;
                    }
                }
                if (max < 10)
                {
                    for (int i = 0; i < n; i++)
                    {
                        if ((Predmets[i].result == 3) && ((Predmets[i].type=="Экзамен") || (Predmets[i].type=="Диф зачёт")))
                        {
                            return "Возможен только синий Диплом";
                        }

                        average += Predmets[i].result;

                    }

                    average = average / n;
                    if (average >= 4.75)
                    {
                        return "Может быть красный диплом";
                    }
                    else
                    {
                        return "Возможет только синий Диплом";
                    }
                }
                else
                {
                    return "Диплом уже есть";
                }
            }
        }
}
