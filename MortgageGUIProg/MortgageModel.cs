using System;
using System.ComponentModel;

namespace MortgageGUIProg
{
  class MortgageModel : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;
    private Payment[] _payments = { };
    private double INTEREST_DIVISOR = 1200;
    private int MONTHS_IN_YEAR = 12;
    private double _principle = 0;
    private double _rate = 0;
    private int _term = 0;
    public double Principle
    {
      get
      {
        return _principle;
      }
      set
      {
        if (_principle != double.Parse(value.ToString()))
        {
          _principle = double.Parse(value.ToString());
          RaisePropertyChanged("Principle");
        }
      }
    }

    public double Rate
    {
      get
      {
        return _rate;
      }
      set
      {
        if (_rate != double.Parse(value.ToString()) / INTEREST_DIVISOR)
        {
          _rate = double.Parse(value.ToString()) / INTEREST_DIVISOR;
          RaisePropertyChanged("Rate");
        }
      }
    }

    public int Term
    {
      get
      {
        return _term;
      }
      set
      {
        if (_term != int.Parse(value.ToString()))
        {
          _term = int.Parse(value.ToString());
          RaisePropertyChanged("Term");
        }
      }
    }

    public Payment[] Payments
    {
      get
      {
        return _payments;
      }
      set
      {
        _payments = value;
        RaisePropertyChanged("Payments");
      }
    }

    private void RaisePropertyChanged(string propertyName)
    {
      // take a copy to prevent thread issues
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Evaluate()
    {
      Payments = new Payment[Term * MONTHS_IN_YEAR];
      var monthlyPayment = Principle * ((Rate * Math.Pow(1 + Rate, Term * 12)) / (Math.Pow(1 + Rate, Term * 12) - 1));
      var balance = Principle;
      for (int i = 0; i < Term * MONTHS_IN_YEAR; i++)
      {
        var beginBalance = balance;
        var ratePayment = balance * Rate;
        var principlePayment = monthlyPayment - ratePayment;
        balance -= principlePayment;
        Payments[i] = new Payment(beginBalance, ratePayment, monthlyPayment, balance);
      }
    }

    public class Payment
    {
      public double BeginBalance { get; set; } = 0;
      public double RatePayment { get; set; } = 0;
      public double MonthlyPayment { get; set; } = 0;
      public double EndBalance { get; set; } = 0;

      public Payment(double beginBalance, double ratePayment, double monthlyPayment, double endBalance)
      {
        BeginBalance = beginBalance;
        RatePayment = ratePayment;
        MonthlyPayment = monthlyPayment;
        EndBalance = endBalance;
      }
    }
  }
}
