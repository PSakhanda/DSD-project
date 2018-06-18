using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace MicroBolt.Stock.Data.Contracts.Entity
{
    public class Bolt: Product
    {
        [Display(Name = "Lenth (mm)")]
        public int LenthMm { get; set; }

        [Display(Name = "Step (mm)")]
        public int StepMm { get; set; }

        [Display(Name = "Diameter (mm)")]
        public int DiameterMm { get; set; }
    }
}
