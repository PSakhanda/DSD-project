using System;

namespace MicroBolt.Clients.Dto
{
    public class BaseClientDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDay { get; set; }
        public string CardNumber { get; set; }
        public string Adress { get; set; }
        public bool IsAdult { get; set; }
        public string Currency { get; set; }
    }
}
