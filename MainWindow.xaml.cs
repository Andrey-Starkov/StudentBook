using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;
using System.Security.Policy;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Allname="";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("Students.txt", true))
            {
                sw.WriteLine(Student.Text+ ';' +Itemname.Text + ';' +Semester.Text + ';' + result.Text + ';' + Itemtype.Text + ';' + Fullname.Text +';');
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Student1.Text == "")
            {
                MessageBox.Show("Нет введённых данных");
                return;
            }
            Allname = "";
            string str;
            bool temp = false;
            using (StreamReader sw = new StreamReader("Students.txt"))
            {
                string FullName = "";
                char c;
                StudentBook studentBook = new StudentBook();
                while (!sw.EndOfStream)
                {

                    str = "";
                    while ((c = Convert.ToChar(sw.Read())) != ';')
                    {
                        str += c;
                    }


                    if (str == Student1.Text)
                    {
                        temp = true;
                        string type="";
                        string result="";
                        string NumberS="";
                        string Name="";
                        FullName = "";

                        while ((c = Convert.ToChar(sw.Read())) != ';')
                        {
                            Name += c;
                        }

                        while ((c = Convert.ToChar(sw.Read())) != ';')
                        {
                            NumberS += c;
                        }

                        while ((c = Convert.ToChar(sw.Read())) != ';')
                        {
                            result += c;
                        }

                        while ((c = Convert.ToChar(sw.Read())) != ';')
                        {
                            type += c;
                        }

                        studentBook.Add(type,Convert.ToInt32(result),Convert.ToInt32(NumberS),Name);
                        Allname += "Тип: " + type +" " + "Оценка: " + result + " " + "Номер семестра: " + NumberS + " " + "Название предмета: " + Name + " " + "\n";


                        while ((c = Convert.ToChar(sw.Read())) != ';')
                        {
                            FullName += c;
                        }
                        sw.ReadLine();
                        
                    }
                    else
                    {

                        sw.ReadLine();
                    }
                }

                if (!temp)
                {
                    MessageBox.Show("Данный студент не был найден");
                    return;
                }
                Dyplom.Content = studentBook.Diplom()  ;
                Stipendia.Content = studentBook.Stipendia();
                Average.Content = "Средний бал: "+studentBook.average();
                LbFullname.Content = "Полное Имя: " + FullName;

            }

            Info.IsEnabled = true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string name = Allname;
            new Window1(name).ShowDialog();
        }

        private void Allid_Click(object sender, RoutedEventArgs e)
        {
            List<string> ForId = new List<string>();
            List<string> ForName = new List<string>();
            string name = "";
            using (StreamReader sw = new StreamReader("Students.txt"))
            {
                char c;
                name = "";
                while (!sw.EndOfStream)
                { 
                    while ((c = Convert.ToChar(sw.Read())) != ';')
                    {
                        name += c;
                    }

                    ForId.Add(name);
                    name = "";

                    while ((c = Convert.ToChar(sw.Read())) != ';')
                    {
                    }

                    while ((c = Convert.ToChar(sw.Read())) != ';')
                    {
                    }

                    while ((c = Convert.ToChar(sw.Read())) != ';')
                    {
                    }

                    while ((c = Convert.ToChar(sw.Read())) != ';')
                    {
                    }


                    while ((c = Convert.ToChar(sw.Read())) != ';')
                    {
                        name += c;
                    }

                    ForName.Add(name);
                    name = "";
                    sw.ReadLine();
                }
            }

            ForName = ForName.Distinct().ToList();
            ForId= ForId.Distinct().ToList();
            name = "";
            for (int i = 0; i < ForId.Count; i++)
            {
                name += ForId[i] + "\t" + ForName[i] + "\n";
            }
            new Window1(name).ShowDialog();
        }

        private void currentid_Click(object sender, RoutedEventArgs e)
        {

            using (StreamReader sw = new StreamReader("Students.txt"))
            {
                string FullName = "";
                char c;
                StudentBook Clown = new StudentBook();
                string str = "";
                bool temp=false;
                while (!sw.EndOfStream)
                {

                    str = "";
                    while ((c = Convert.ToChar(sw.Read())) != ';')
                    {
                        str += c;
                    }


                    if (str == inputid.Text)
                    {
                        temp = true;
                        FullName = "";

                        while ((c = Convert.ToChar(sw.Read())) != ';')
                        {
                        }

                        while ((c = Convert.ToChar(sw.Read())) != ';')
                        {
                        }

                        while ((c = Convert.ToChar(sw.Read())) != ';')
                        {
                        }

                        while ((c = Convert.ToChar(sw.Read())) != ';')
                        {
                        }


                        while ((c = Convert.ToChar(sw.Read())) != ';')
                        {
                            FullName += c;
                        }
                        sw.ReadLine();

                        Student.Text = str;
                        Fullname.Text = FullName;
                    }
                    else
                    {
                        sw.ReadLine();
                    }
                }

                if (!temp)
                {
                    MessageBox.Show("Данный студент не был найден");
                    return;
                }


            }

        }
    }
}
