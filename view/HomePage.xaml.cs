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
using System.Windows.Shapes;
using System.Threading;

namespace stone1
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        SimulationWindow simulationWindow;
        public HomePage()
        {
            InitializeComponent();
        }

        private void Regression_based(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(() =>
            {
                            }
            );
            t.Start();
        }

        private void Show_simulaion(object sender, RoutedEventArgs e)
        {
            try
            {
                simulationWindow = new SimulationWindow(CSVPath.Text, int.Parse(portToFS.Text));
                simulationWindow.Show();
            }
            catch (Exception a)
            {
                ReadingFail failPage = new ReadingFail(a.Message);
                failPage.Show();
            }
        }
    }
}
