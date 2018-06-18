using MicroBolt.Stock.Products.Dto;

namespace MicroBolt.Stock.Bolts.Dto
{
    public class BaseBoltDto: BaseProductDto
    {
        public int LenthMm { get; set; }
        public int StepMm { get; set; }
        public int DiameterMm { get; set; }
    }
}
