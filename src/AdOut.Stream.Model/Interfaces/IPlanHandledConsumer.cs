﻿using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdOut.Stream.Model.Interfaces
{
    public interface IPlanHandledConsumer : IBasicConsumer
    {
    }
}
