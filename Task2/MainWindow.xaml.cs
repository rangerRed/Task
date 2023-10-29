using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Linq;
using Task2.Model;
using System.Xml;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Documents;

namespace Task2
{

    public partial class MainWindow : Window
    {
        private MainView m_mainView;

        public MainWindow()
        {
            InitializeComponent();

            AllTextFile.lineS = new List<string>(File.ReadAllLines("../../../24_21_1003001_2017-05-29_kpt11.xml")); // копируем весь файл в список

            for (int i = 0; i < AllTextFile.lineS.Count; i++)
                AllTextFile.lineS[i] = AllTextFile.lineS[i].Trim();
            //коздание категории
            m_mainView = new MainView(this);

            for (int i = 0; i < 6; i++)
            {
                BaseItem item1 = new BaseItem()
                {
                    Name = AllTextFile.type_object.Keys.ElementAt(i),
                    Parent = ModelView,
                    Visible = Visibility.Hidden,
                };
                AllTextFile.item0.Add(item1);
                int lineIndex = 0, endLineIndex = 0;
                while (lineIndex != -1)
                {
                    // поиск id для дерева
                    string temp_s = "";
                    lineIndex = AllTextFile.lineS.FindIndex(line => line.StartsWith(AllTextFile.type_object[AllTextFile.type_object.Keys.ElementAt(i)])); //первая строка отрывка
                    endLineIndex = AllTextFile.lineS.FindIndex(line => line.StartsWith(AllTextFile.s_end[i])); //последняя строка отрывка
                    if (lineIndex != -1)
                    {
                        AllTextFile.temp_list = AllTextFile.lineS.GetRange(lineIndex, endLineIndex - lineIndex); //отрывок целиком
                        int cd_id = 0, ind = 0;
                        bool b = true;
                        for (; cd_id < 3 && b; cd_id++)
                        {
                            ind = 0;
                            for (; ind < AllTextFile.temp_list.Count; ind++)
                            {
                                if (AllTextFile.temp_list[ind].Contains(AllTextFile.code[cd_id]))
                                {
                                    b = false;
                                    break;
                                }
                            }
                        }
                        if (cd_id == 3 && b) break;
                        cd_id -= 1;
                        temp_s = AllTextFile.temp_list[ind];
                        temp_s = temp_s.Substring(temp_s.IndexOf('>') + 1, (temp_s.LastIndexOf('<') - temp_s.IndexOf('>')) - 1); // оставляем из строки только номер
                        AllTextFile.go_back.Add(temp_s, i.ToString() + cd_id.ToString() + (cd_id + 3).ToString()); // добавляем номер что бы его можно было достать
                        BaseItem child0 = new BaseItem() // создание элемента категории
                        {
                            Name = temp_s,
                            Parent = AllTextFile.item0[i], // это прародитель
                            Visible = Visibility.Visible
                        };
                        AllTextFile.item0[i].Children.Add(child0);
                        AllTextFile.lineS = AllTextFile.lineS.Skip(endLineIndex + 1).ToList();
                        cd_id = 0;
                    }
                }

                m_mainView.Children.Add(AllTextFile.item0[i]);
            }
            DataContext = m_mainView;
            AllTextFile.lineS = new List<string>();
        }

        public MainView ModelView
        {
            get { return m_mainView; }
        }

        private void Trv_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            try
            {
                if (e.NewValue is BaseItem)
                {
                    ModelView.SelectedItem = (BaseItem)e.NewValue; // достает номер
                    AllTextFile.lineS = new List<string>(File.ReadAllLines("../../../24_21_1003001_2017-05-29_kpt11.xml")); // копируем весь файл в список
                    for (int i = 0; i < AllTextFile.lineS.Count; i++)
                        AllTextFile.lineS[i] = AllTextFile.lineS[i].Trim();

                    string nums = AllTextFile.go_back[ModelView.SelectedItem.Name];
                    int index_top = 0, index_bottom = 0, index = 0, i0 = Convert.ToInt32(nums[0]) - 48, i1 = Convert.ToInt32(nums[1]) - 48, i2 = Convert.ToInt32(nums[2]) - 48;
                    string str = AllTextFile.code[i1] + ModelView.SelectedItem.Name + AllTextFile.code[i2];
                    index = AllTextFile.lineS.FindIndex(line => line.StartsWith(str));
                    string top_line = AllTextFile.type_object[AllTextFile.item0[i0].Name];
                    string bottom_line = AllTextFile.s_end[i0];
                    for (index_top = index; !(AllTextFile.lineS[index_top].Contains(top_line)); index_top--) { };
                    for (index_bottom = index; !(AllTextFile.lineS[index_bottom].Contains(bottom_line)); index_bottom++) { };
                    AllTextFile.temp_list = AllTextFile.lineS.GetRange(index_top, (index_bottom + 1) - index_top);
                    string long_str = "";
                    foreach (string s in AllTextFile.temp_list)
                    {
                        long_str += s;
                        long_str += "\n";
                    }
                    txBl.Text = long_str;
                    AllTextFile.lineS = new List<string>();
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                SaveFileDialog fdlg = new SaveFileDialog();
                fdlg.Title = "C# Corner Open File Dialog";
                fdlg.InitialDirectory = @"c:\";
                fdlg.Filter = "Files XML (*.xml)|*.xml*";
                fdlg.FilterIndex = 2;
                fdlg.RestoreDirectory = true;
                fdlg.ShowDialog();

                AllTextFile.lineS = new List<string>(File.ReadAllLines("../../../24_21_1003001_2017-05-29_kpt11.xml")); // копируем весь файл в список
                string long_str = "";
                for (int f = 0; f < AllTextFile.list_io.Count; f++)
                {
                    for (int i = 0; i < AllTextFile.lineS.Count; i++)
                        AllTextFile.lineS[i] = AllTextFile.lineS[i].Trim();

                    string nums = AllTextFile.go_back[AllTextFile.list_io[f]];
                    int index_top = 0, index_bottom = 0, index = 0, i0 = Convert.ToInt32(nums[0]) - 48, i1 = Convert.ToInt32(nums[1]) - 48, i2 = Convert.ToInt32(nums[2]) - 48;
                    string str = AllTextFile.code[i1] + AllTextFile.list_io[f] + AllTextFile.code[i2];
                    index = AllTextFile.lineS.FindIndex(line => line.StartsWith(str));
                    string top_line = AllTextFile.type_object[AllTextFile.item0[i0].Name];
                    string bottom_line = AllTextFile.s_end[i0];
                    for (index_top = index; !(AllTextFile.lineS[index_top].Contains(top_line)); index_top--) { };
                    for (index_bottom = index; !(AllTextFile.lineS[index_bottom].Contains(bottom_line)); index_bottom++) { };
                    AllTextFile.temp_list = AllTextFile.lineS.GetRange(index_top, (index_bottom + 1) - index_top);
                    long_str += String.Join("\n", AllTextFile.temp_list);
                    
                }


                XmlDocument doc = new XmlDocument();
                long_str = "<base_data>" + long_str + "</base_data>";
                doc.LoadXml(long_str);
                string path = Convert.ToString(new Uri(fdlg.FileName));
                path = path.Substring(8, path.Length - 8);
                if(path.Substring(path.Length - 4, 4) != ".xml")
                    path = path + ".xml";
                doc.PreserveWhitespace = false;
                doc.Save(path);
                AllTextFile.lineS = new List<string>();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
