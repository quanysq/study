using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutofacSample.Services
{
    public class GreeterImpl : IGreeter
    {
        public string Greet(string name)
        {
            return $"Hello, {name}! Welcome to Autofac world!";
        }
    }
}