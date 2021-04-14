using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stone1
{
    class GraphModel
    {
        public static void makeANewGrahp(SimulationRunner runner, int index)
        {
            int x = 1;
            runner.last30Points = new ObservableCollection<DataPoint>();
            for (int i = int.Parse(runner.CurrentLine); i > int.Parse(runner.CurrentLine) - 30; i--)
            {
                if (i < 0)
                {
                    runner.last30Points.Add(new DataPoint( 0, 0));
                }
                else
                {
                    runner.last30Points.Add(new DataPoint(runner.data[i][index], x));
                    x++;
                }
            }
        }
        public static PlotModel updateGraph(SimulationRunner runner, double newVal)
        {
            ObservableCollection<DataPoint> newList = new ObservableCollection<DataPoint>();
            if (runner.last30Points.Count == 30)
            {
                foreach (DataPoint point in runner.last30Points)
                {
                    double y = point.Y - 1, x = point.X;
                    if (point.Y == 0)
                    {
                        y = 30;
                        newList.Add (new DataPoint(x, newVal));
                    }
                }
                runner.last30Points = newList;
            }
            else
            {
                runner.last30Points.Add(new DataPoint (newVal , runner.last30Points.Count + 1));
            }
            PlotModel plot = new PlotModel();
            var lineSeries = new LineSeries();
            foreach(DataPoint p in runner.last30Points)
            {
                lineSeries.Points.Add(p);
            }
            plot.Series.Add(lineSeries);
            return plot;
        }
        public static PlotModel makePlot ()
        {
            var plot = new PlotModel();
            var linearAxes1 = new LinearAxis();
            linearAxes1.MajorGridlineStyle = LineStyle.Solid;
            linearAxes1.MinorGridlineStyle = LineStyle.Dot;
            plot.Axes.Add(linearAxes1);
            var linearAxes2 = new LinearAxis();
            linearAxes2.MajorGridlineStyle = LineStyle.Solid;
            linearAxes2.MinorGridlineStyle = LineStyle.Dot;
            linearAxes2.Position = AxisPosition.Bottom;
            plot.Axes.Add(linearAxes2);
            return plot;
        }
    }
}
