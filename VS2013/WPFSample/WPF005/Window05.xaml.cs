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

namespace WPF005
{
  /// <summary>
  /// Interaction logic for Window05.xaml
  /// </summary>
  public partial class Window05 : Window
  {
    public Window05()
    {
      InitializeComponent();
      this.textBlockPassword.Text = Properties.Resources.Password;
    }
  }
}
