using System;

namespace MicroBolt.Stock.Models
{
    public class BoltModel : ProductModel
    {
        public int LenthMm { get; set; }
        public int StepMm { get; set; }
        public int DiameterMm { get; set; }
    }
}
