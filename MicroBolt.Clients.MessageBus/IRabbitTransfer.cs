﻿using MicroBolt.Clients.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBolt.Clients.MessageBus
{
    public interface IRabbitTransfer
    {
        void Start(ClientModel entity);
    }
}
