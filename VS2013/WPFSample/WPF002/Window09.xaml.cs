﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
  /// Interaction logic for Window09.xaml
  /// </summary>
  public partial class Window09 : Window
  {
    public Window09()
    {
      InitializeComponent();

      ObservableCollection<Student02> stuList = new ObservableCollection<Student02>()
      {
        new Student02(){ Id=0, Name="Tim", Age=29 },
        new Student02(){ Id=1, Name="Tom", Age=28 },
        new Student02(){ Id=2, Name="Tam", Age=27 },
        new Student02(){ Id=3, Name="Tbm", Age=26 },
        new Student02(){ Id=4, Name="Tcm", Age=25 },
        new Student02(){ Id=5, Name="Tdm", Age=24 },
      };

      this.listBoxStudents.ItemsSource = stuList;

      Binding binding = new Binding("SelectedItem.Id") { Source = this.listBoxStudents };
      this.textBoxId.SetBinding(TextBox.TextProperty, binding);
    }
  }
}
