using System;

namespace MicroBolt.Clients.Models
{
    public class ClientModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDay { get; set; }
        public string CardNumber { get; set; }
        public string Adress { get; set; }
        public bool IsAdult { get; set; }
        public string Currency { get; set; }
    }
}
