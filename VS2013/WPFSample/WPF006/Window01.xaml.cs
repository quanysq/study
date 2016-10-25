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

namespace WPF006
{
  /// <summary>
  /// Interaction logic for Window01.xaml
  /// </summary>
  public partial class Window01 : Window
  {
    public Window01()
    {
      InitializeComponent();
      InitializeCarList();
    }

    /// <summary>
    /// Initializes the car list.
    /// </summary>
    private void InitializeCarList()
    {
      List<Car> carList = new List<Car>()
      {
        new Car(){ Automaker="Lamborhini", Name="Car1", Year="1990", TopSpeed="340" },
        new Car(){ Automaker="Lamborhini", Name="Car2", Year="2001", TopSpeed="353" },
        new Car(){ Automaker="Lamborhini", Name="Car3", Year="2003", TopSpeed="325" },
        new Car(){ Automaker="Lamborhini", Name="Car4", Year="2008", TopSpeed="356" },
        new Car(){ Automaker="Lamborhini", Name="Car5", Year="2015", TopSpeed="800" },
      };

      this.listBoxCars.ItemsSource = carList;
    }
  }
}
