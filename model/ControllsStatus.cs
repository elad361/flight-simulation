using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace stone1
{
    class ControllsStatus
    {
        SimulationRunner runner;
        string[] parameters;
        double pixelsFromLeft;
        double pixelsFromTop;
        public string KnobPixelsFromLeft
        {
            set
            {
                double x = double.Parse(value);
                pixelsFromLeft = 205 + ((x - AileronMinVal)  / (AileronMaxVal - AileronMinVal))*(90);
                runner.KnobPixelsFromLeft = KnobPixelsFromLeft;
            }
            get
            {
                return pixelsFromLeft.ToString();
            }
        }

        public string KnobPixelsFromTop
        {
            set
            {
                double x = double.Parse(value);
                pixelsFromTop = 105 + ((x - ElevatorMinVal) / ElevatorMaxVal - ElevatorMinVal) * 60;
                runner.KnobPixelsFromTop = KnobPixelsFromTop;
            }
            get
            {
                return pixelsFromTop.ToString();
            }
        }
        
        public double ElevatorMinVal { set; get; }
        public double ElevatorMaxVal { set; get; }
        public double AileronMinVal { get; set; }
        public double AileronMaxVal { get; set; }
        public ControllsStatus(SimulationRunner sr, double ailMax, double ailMin, double elMax, double elMin, string[] par)
        {
            runner = sr;
            AileronMinVal = ailMax;
            AileronMaxVal = ailMin;
            ElevatorMaxVal = elMax;
            ElevatorMinVal = elMin;
            parameters = par;
            pixelsFromTop = 105;
            runner.KnobPixelsFromTop = "105";
            pixelsFromLeft = 245;
            runner.KnobPixelsFromLeft = "245";
            runner.RubberVal = "0";
            runner.ThrottleVal = "0";
            runner.Altitude = "0";
            runner.AirSpeed = "0";
            runner.HeadingDeg = "0";
            runner.PitchDeg = "0";
            runner.Yaw = "0";
        }
        public void updateControllers(double[] line)
        {
            KnobPixelsFromLeft = line[Array.IndexOf(parameters, "aileron")].ToString();
            KnobPixelsFromTop = line[Array.IndexOf(parameters, "elevator")].ToString();
            runner.RubberVal = line[Array.IndexOf(parameters, "rudder")].ToString();
            runner.ThrottleVal = line[Array.IndexOf(parameters, "throttle0")].ToString();
            runner.Altitude = line[Array.IndexOf(parameters, "altitude-ft")].ToString();
            runner.AirSpeed = line[Array.IndexOf(parameters, "airspeed-kt")].ToString();
            runner.HeadingDeg = line[Array.IndexOf(parameters, "heading-deg")].ToString();
            runner.PitchDeg = line[Array.IndexOf(parameters, "pitch-deg")].ToString();
            runner.RollDeg = line[Array.IndexOf(parameters, "roll-deg")].ToString();
            runner.Yaw = line[Array.IndexOf(parameters, "side-slip-deg")].ToString();
        }

        internal ThreadStart updateControllers()
        {
            throw new NotImplementedException();
        }
    }
}
