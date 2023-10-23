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
using VoxelConverter.VoxConverter.ModelObject;

namespace VoxelConverter.Pages
{
    /// <summary>
    /// Логика взаимодействия для DeletePage.xaml
    /// </summary>
    public partial class DeletePage : Page
    {
        SimpleObject simpleObject;        
        public delegate void RemoveDelegate(SimpleObject obj);
        RemoveDelegate Remove;
        public DeletePage(SimpleObject simpleObject, RemoveDelegate Remove)
        {
            InitializeComponent();
            this.simpleObject = simpleObject;
            this.Remove = Remove;
            InfoLabel.Content = $"Удалить элемент {simpleObject}?";
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            Remove(simpleObject);
            ToWork();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            ToWork();
        }
        void ToWork() => MainWindow.SetPage(new WorkPage());
    }
}
