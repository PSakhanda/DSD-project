using MicroBolt.Stock.Product.Dto;

namespace MicroBolt.Stock.Bolt.Dto
{
    public class BaseBoltDto: BaseProductDto
    {
        public int LenthMm { get; set; }
        public int StepMm { get; set; }
        public int DiameterMm { get; set; }
    }
}
