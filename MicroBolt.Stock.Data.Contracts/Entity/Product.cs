using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace MicroBolt.Stock.Data.Contracts.Entity
{
    public class Product
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Product Price")]
        public double Price { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
    }
}
