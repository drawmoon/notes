﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkflowSample.Services
{
    public class MyService : IMyService
    {
        public void DoTheThings()
        {
            Console.WriteLine("Doing stuff...");
        }
    }
}
