﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HostedServiceSample.Core
{
    public interface IBackgroundTask
    {
        Task ExecuteAsync(CancellationToken stoppingToken);
    }
}
