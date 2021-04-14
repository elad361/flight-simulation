using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.IO;
using System.Collections.ObjectModel;

namespace stone1
{
    class FlightData
    {
        public FlightData(out string[] par1)
        {
            par1 = new string[]{ "aileron","elevator","rudder","flaps","slats","speedbrake","throttle0","throttle1","engine-pump0","engine-pump1", "electric-pump0", "electric-pump1", "external-power","APU-generator" , "latitude-deg",
                                      "longitude-deg", "altitude-ft", "roll-deg", "pitch-deg", "heading-deg", "side-slip-deg", "airspeed-kt", "glideslope", "vertical-speed-fps", "airspeed-indicator_indicated-speed-kt", "altimeter_indicated-altitude-ft",
                                      "altimeter_pressure-alt-ft", "attitude-indicator_indicated-pitch-deg", "attitude-indicator_indicated-roll-deg", "attitude-indicator_internal-pitch-deg", "attitude-indicator_internal-roll-deg", "encoder_indicated-altitude-ft",
                                      "encoder_pressure-alt-ft", "gps_indicated-altitude-ft", "gps_indicated-ground-speed-kt", "gps_indicated-vertical-speed", "indicated-heading-deg", "magnetic-compass_indicated-heading-deg", "slip-skid-ball_indicated-slip-skid",
                                      "turn-indicator_indicated-turn-rate", "vertical-speed-indicator_indicated-speed-fpm", "engine_rpm"};
        }

        public void read_data(string path, out double[][] dat)
        {
            string[] lines = System.IO.File.ReadAllLines(path);
            dat = new double[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                dat [i] = Array.ConvertAll(lines[i].Split(','), Double.Parse);
            }
        }
    }
}
