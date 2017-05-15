using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormSample01.DataGridViewSample
{
  class Customer
  {
    public int ID { get; set; }
    public string CName { get; set; }
    public string Sex { get; set; }

    public List<Address> AddressList { get; set; }
  }

  class Address
  {
    public string Street { get; set; }
    public string City { get; set; }
  }
}
