using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using OxyPlot;

namespace stone1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class SimulationWindow : Window
    {
        SimulationRunner runner;

        public SimulationWindow(string path, int port)
        {
            InitializeComponent();
            try
            {
                runner = new SimulationRunner(path, this, port);
            }
            catch (Exception e)
            {
                throw e;
            }
            graph1.Model = GraphModel.makePlot();
            controllers.DataContext = runner;
            controllingButtons.DataContext = runner;
            listOfParameters.DataContext = runner.parameter;
            graph1.DataContext = runner;
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            runner.IsStoped = false;
        }

        private void pauseButton_Click(object sender, RoutedEventArgs e)
        {
            runner.IsStoped = true;
        }

        private void playSpeed_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            runner.TimeControl = (double)(1 / ((Slider)sender).Value);
        }

        private void backwardButton_Click(object sender, RoutedEventArgs e)
        {
            runner.CurrentLine = "-5";
        }

        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            runner.videoPaused();
        }

        private void forwardButton_Click(object sender, RoutedEventArgs e)
        {
            runner.CurrentLine = "5";
        }

        private void listOfParameters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            runner.SelectedItemIndex = ((Parameter)(listOfParameters.SelectedItem)).Index;
        }
        private void UpdateGraph()
        {
            
        }
    }
}
