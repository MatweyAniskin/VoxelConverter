using Microsoft.Win32;
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

namespace VoxelConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public delegate void PageDelegate(Page page);
        public static PageDelegate SetPage;
        public MainWindow()
        {
            InitializeComponent();
            SetPage = SetPageContent;
            SetPage(new StartPage());           
        }
        void SetPageContent(Page page)
        {
            Main.Content = page;
        }
    }
}
