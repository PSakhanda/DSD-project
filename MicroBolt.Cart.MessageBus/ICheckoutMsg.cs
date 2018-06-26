using System;
using System.Collections.Generic;
using System.Text;

using MicroBolt.Cart.Models;

namespace MicroBolt.Cart.MessageBus
{
    public interface ICheckoutMsg
    {
        void Send(CustomerCart entity);
    }
}
