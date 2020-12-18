using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Lib.Helpers
{
    public static class VelocityUnitConverter
    {
        public static double KmphToKnots(double kmph)
        {
            return kmph / 1.852;
        }

        public static double KmphToMps(double kmph)
        {
            return kmph * 1000 / 3600;
        }

        public static double MpsToKmph(double mps)
        {
            return mps / 1000 * 3600;
        }

        public static double MpsToKnots(double mps)
        {
            return mps / 1852 * 3600;
        }

        public static double KnotsToMps(double knots)
        {
            return knots * 1852 / 3600;
        }

        public static double KnotsToKmph(double knots)
        {
            return knots * 1.852;
        }
    }
}
