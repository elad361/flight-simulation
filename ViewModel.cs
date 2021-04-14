using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using OxyPlot;
using OxyPlot.Axes;

namespace stone1
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        ControllsStatus controllsStatus;
        string[] parameters;
        public double[][] data;
        int currentLine;
        Thread t;
        FlightData fd;
        int lastLine;
        MyClient client;
        public ObservableCollection<Parameter> parameter;
        public ObservableCollection<DataPoint> last30Points;
        double knobPixelsFromLeft;
        public string KnobPixelsFromLeft
        {
            set
            {
                knobPixelsFromLeft = double.Parse(value);
                OnPropertyChanged();
            }
            get
            {
                return knobPixelsFromLeft.ToString();
            }
        }
        double knobPixelsFromTop;
        public string KnobPixelsFromTop
        {
            set
            {
                knobPixelsFromTop = double.Parse(value);
                OnPropertyChanged();
            }
            get
            {
                return knobPixelsFromTop.ToString();
            }
        }
        double rubberVal;
        public string RubberVal
        {
            set
            {
                rubberVal = double.Parse(value);
                OnPropertyChanged();
            }
            get
            {
                return rubberVal.ToString();
            }
        }
        double throttleVal;
        public string ThrottleVal
        {
            set
            {
                throttleVal = double.Parse(value);
                OnPropertyChanged();
            }
            get
            {
                return throttleVal.ToString();
            }
        }
        public string CurrentLine
        { 
            get
            {
                return currentLine.ToString();
            }
            set
            {
                double x = double.Parse(value);
                if (currentLine + x > lastLine)
                {
                    currentLine = lastLine;
                }
                else if (currentLine + x < 0)
                {
                    currentLine = 0;
                }
                else
                {
                    currentLine += (int)x;
                }
                OnPropertyChanged();
                controllsStatus.updateControllers(data[currentLine]);
            }
        }

        public bool IsStoped  { get; set;  }
        public string LastLine
        {
            get
            {
                return lastLine.ToString();
            }
            set
            {
                lastLine = int.Parse(value);
                OnPropertyChanged();
            }
        }
        public double TimeControl { get; set; }

        double altitude;

        public string Altitude
        {
            get
            {
                return altitude.ToString();
            }
            set
            {
                altitude = double.Parse(value);
                OnPropertyChanged();
            }
        }
        double airSpeed;
        public string AirSpeed
        {
            set
            {
                airSpeed = double.Parse(value);
                OnPropertyChanged();
            }
            get
            {
                return airSpeed.ToString();
            }
        }
        double headingDeg;
        public string HeadingDeg
        {
            get
            {
                return headingDeg.ToString();
            }
            set
            {
                headingDeg = double.Parse(value);
                OnPropertyChanged();
            }
        }
        double pitch;
        public string PitchDeg
        {
            get
            {
                return pitch.ToString();
            }
            set
            {
                pitch = double.Parse(value);
                OnPropertyChanged();
            }
        }
        double roll;
        public string RollDeg
        {
            get
            {
                return roll.ToString();
            }
            set
            {
                roll = double.Parse(value);
                OnPropertyChanged();
            }
        }
        double yaw;
        public string Yaw
        {
            get
            {
                return yaw.ToString();
            }
            set
            {
                yaw = double.Parse(value);
                OnPropertyChanged();
            }
        }
        int selectedItemIndex;
        public int SelectedItemIndex
        {
            get
            {
                return selectedItemIndex;
            }
            set
            {
                selectedItemIndex = value;
                GraphModel.makeANewGrahp(this, selectedItemIndex);
            }
        }

        PlotModel plotModel;
        public PlotModel PlotModel
        {
            get
            {
                return plotModel;
            }
            set
            {
                plotModel = value;
                OnPropertyChanged();
            }
        }

        public ViewModel(string path, SimulationWindow window, int port)
        {

            fd = new FlightData(out parameters);
            try
            {

                fd.read_data(path, out data);
            }
            catch
            {
                throw (new Exception("could not open CSV file"));
            }
            new Thread(syncParametersLists).Start();
            new Thread(() =>GraphModel.makeANewGrahp(this, 1)).Start();
            PlotModel = GraphModel.makePlot();
            lastLine = data.Length - 1;
            currentLine = 0;
            controllsStatus = new ControllsStatus(this, 0.4, -0.4, 0.2, -0.2, parameters);
            TimeControl = 1;
            IsStoped = true;
            KnobPixelsFromTop = controllsStatus.KnobPixelsFromTop;
            KnobPixelsFromLeft = controllsStatus.KnobPixelsFromLeft;
            client = new MyClient();
            try
            {
                client.Connect("localhost", port);
            }
            catch (Exception e)
            {
                throw e;
            }
            t = new Thread(run);
            t.Start();
        }
        public void run()
        {
            while (true)
            {
                while (IsStoped || currentLine >= lastLine)
                {
                    Thread.Sleep(1000);
                }
                CurrentLine = "1";
                client.SendArrayAsLine(data[currentLine]);
                controllsStatus.updateControllers(data[currentLine]);
                PlotModel = GraphModel.updateGraph(this, data[currentLine][SelectedItemIndex]);
                Thread.Sleep((int)(100 * TimeControl));
            }
        }
        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public void videoPaused()
        {
            currentLine = 0;
            CurrentLine = "0";
            IsStoped = true;
            controllsStatus.updateControllers(data[currentLine]);
        }
        private void syncParametersLists()
        {
            ObservableCollection<Parameter>  par = new ObservableCollection<Parameter>();
            for (int i = 0; i < parameters.Length; i++)
            {
                par.Add(new Parameter { Index = i, Name = parameters[i] });
            }
            parameter = par;
        }
        
    }
}
