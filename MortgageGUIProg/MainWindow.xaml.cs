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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MortgageGUIProg
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    MortgageModel model = new MortgageModel();

    public MainWindow()
    {
      InitializeComponent();
      DataContext = model;
    }

    private void Submit(object sender, RoutedEventArgs e)
    {
      model.Evaluate();
    }
  }
}
