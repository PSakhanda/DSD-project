using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace MicroBolt.Clients.Data.Contracts.Entity
{
    public class Client
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Surname")]
        public string Surname { get; set; }
        [Display(Name = "Date of Birthday")]
        public DateTime BirthDay { get; set; }
        [Display(Name = "Card Number")]
        public string CardNumber { get; set; }
        [Display(Name = "Adress of live")]
        public string Adress { get; set; }
        [Display(Name = "Age greatest 18?")]
        public bool IsAdult { get; set; }
        [Display(Name = "Currency")]
        public string Currency { get; set; }
    }
}
