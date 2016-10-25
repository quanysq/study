using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF002
{
  /// <summary>
  /// Interaction logic for Window05.xaml
  /// </summary>
  public partial class Window05 : Window
  {
    public Window05()
    {
      InitializeComponent();

      List<City> gdList = new List<City>()
      {
        new City(){ Name="CZ" },
        new City(){ Name="ST" },
        new City(){ Name="JY" }
      };
      List<City> bjList = new List<City>()
      {
        new City(){ Name="DC" },
        new City(){ Name="CC" },
        new City(){ Name="TZ" }
      };
      List<City> ucList1 = new List<City>()
      {
        new City(){ Name="CZ1" },
        new City(){ Name="ST1" },
        new City(){ Name="JY1" }
      };
      List<City> ucList2 = new List<City>()
      {
        new City(){ Name="CZ2" },
        new City(){ Name="ST2" },
        new City(){ Name="JY2" }
      };
      List<Province> chinaList = new List<Province>()
      {
        new Province(){ Name="GD", CityList=gdList },
        new Province(){ Name="BJ", CityList=bjList },
      };
      List<Province> usList = new List<Province>()
      {
        new Province(){ Name="UC1", CityList=ucList1 },
        new Province(){ Name="UC2", CityList=ucList2 },
      };
      List<Country> countryList = new List<Country>()
      {
        new Country(){ Name="China", ProvinceList=chinaList},
        new Country(){ Name="US", ProvinceList=usList},
      };

      this.textbox1.SetBinding(TextBox.TextProperty, new Binding("/Name") { Source = countryList });
      this.textbox2.SetBinding(TextBox.TextProperty, new Binding("/ProvinceList/Name") { Source = countryList });
      this.textbox3.SetBinding(TextBox.TextProperty, new Binding("/ProvinceList/CityList/Name") { Source = countryList });
    }
  }

  class City
  {
    public string Name { get; set; }
  }

  class Province
  {
    public string Name { get; set; }
    public List<City> CityList { get; set; }
  }

  class Country
  {
    public string Name { get; set; }
    public List<Province> ProvinceList { get; set; }
  }
}
