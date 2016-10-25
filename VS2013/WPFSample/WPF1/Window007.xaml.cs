﻿using System;
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

namespace WPF001
{
  /// <summary>
  /// Interaction logic for Window007.xaml
  /// </summary>
  public partial class Window007 : Window
  {
    public Window007()
    {
      InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      string str = this.FindResource("myString") as string;
      this.text.Text = str;
    }
  }
}
