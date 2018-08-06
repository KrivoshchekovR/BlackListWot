using System;
using System.Collections.Generic;
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

namespace BlackListWot
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<MEMBER> ListAlliace;
        public List<MEMBER> ListEnemy;
        public const int QTY_PARTY = 15;
        public MainWindow()
        {
            InitializeComponent();
        }
        public List<MEMBER> genereted_List(List<MEMBER> List, int kol_men)
        {
            Random rand = new Random();
            for (int h = 0; h < kol_men; h++)
            {
                Bans b = new Bans(h, "Нарушение законов зоны");
                SortedSet<Bans> bans = new SortedSet<Bans>();
                byte[] s = new byte[6];
                
                MEMBER mbr = new MEMBER();
                b.AddBan();
                StringBuilder str = new StringBuilder();
                int rnd_char = rand.Next(65, 90);
                str.Append((char)rnd_char);
                int rnd_qty_char = rand.Next(3, 16);
                for (int i = 0; i < rnd_qty_char-1; i++)
                {
                    if(i<6)
                    s[i] = Convert.ToByte((Convert.ToInt16(rand.Next(0,99))));
                    rnd_char = rand.Next(65, 90);
                    str.Append((char)rnd_char);
                }
                bans.Add(b);
                mbr.Add(str.ToString(), bans, s);
                List.Add(mbr);
            }
            return List;
        }
        private void Click_button(object sender, RoutedEventArgs e)
        {
            ListAlliace = new List<MEMBER>();
            ListEnemy = new List<MEMBER>();
            genereted_List(ListAlliace, QTY_PARTY);
            genereted_List(ListEnemy, QTY_PARTY);
            foreach (MEMBER Lis in ListAlliace)
            {
                ListBoxItem itm = new ListBoxItem();
                itm.Content = Lis.nickname;
               // itm.Selected += new RoutedEventHandler(ListItemSelect);
                ListViewAlliace.Items.Add(itm);
            }
            foreach (MEMBER Lis in ListEnemy)
            {
                ListBoxItem itm = new ListBoxItem();
                itm.Content = Lis.nickname;
              //  itm.Selected += new RoutedEventHandler(ListItemSelect);
                ListViewEnemy.Items.Add(itm);
            }
            
        }
        private void ListItemSelect(object sender, EventArgs e)
        {
            ComboBox cmb = new ComboBox();
            object item = ListViewAlliace.SelectedItem;
            string s = item.ToString();
            string result = s.Substring(0, s.LastIndexOf(' '));

            foreach (MEMBER Lis in ListAlliace)
            {
                if (s==Lis.nickname)
                foreach (Bans b in Lis.ssBans)
                {
                    ComboBoxItem ci = new ComboBoxItem();
                    ci.Content =
                    cmb.Items.Add(ci);
                }
            }
        }

        private void ListViewAlliace_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = ListViewAlliace.SelectedItem;
            ComboBox cmb = new ComboBox();
            if (item == null)
            {
                MessageBox.Show("000");
            }
            else
            {
                //MessageBox.Show("ФАК");
                string s = item.ToString();
                string result = s.Substring(s.LastIndexOf(' ')+1);
                foreach (MEMBER Lis in ListAlliace)
                {
                    if (result == Lis.nickname)
                        foreach (Bans b in Lis.ssBans)
                        {
                            ComboBoxItem ci = new ComboBoxItem();
                            ci.Content = b.nameban + " " + b.qty;
                            cmb.Items.Add(ci);
                        }
                }

            }
            
        }

    }
}
