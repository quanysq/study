using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniProfilerDemo.Models
{
  public class Product
  {
    public int ID { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
  }
}