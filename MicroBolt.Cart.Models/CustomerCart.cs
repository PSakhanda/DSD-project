﻿using System.Collections.Generic;

namespace MicroBolt.Cart.Models
{
    public class CustomerCart
    {
        public string BuyerId { get; set; }
        public List<CartItem> Items { get; set; }

        public CustomerCart(string customerId)
        {
            BuyerId = customerId;
            Items = new List<CartItem>();
        }
    }
}
