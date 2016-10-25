using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MiniProfilerDemo.Models;
using System.Data.Entity;

namespace MiniProfilerDemo.DAL
{
  public class EFDbContext: DbContext
  {
    public DbSet<Product> Products { get; set; }
  }
}