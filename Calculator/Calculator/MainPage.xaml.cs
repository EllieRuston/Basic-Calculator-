using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Syncfusion.Calculate;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {  
            InitializeComponent();
        }
        CalcQuickBase calcQuick = new CalcQuickBase();

        public void FastMath()
        {
            string forumla = LblCalc.Text;
            string result = calcQuick.ParseAndCompute (forumla);
            LblResult.Text = result;
           
        }

        // variables  for calulation
        
        private string operatorName;
        //private bool isOperatorClicked;
        bool calculationsExecuted = false;
        // input numbers
        private void BtnCommon_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
                
                

            if (calculationsExecuted)
            {
                LblCalc.Text = String.Empty;
                LblCalc.Text = button.Text;
                LblResult.Text = String.Empty;
                calculationsExecuted = false;
            }
            else
            {
                if (LblCalc.Text == "0")
                {
                    LblCalc.Text = button.Text;
                }
                else
                {
                    LblCalc.Text += button.Text;
                }
            }
        }

        private void BtnClear_Clicked(object sender, EventArgs e)
        {
            LblResult.Text = "";
            LblCalc.Text = "0";
        }

        private async void BtnDel_Clicked(object sender, EventArgs e)
        {
            try
            {
                string number = LblCalc.Text;
                if (number != "0")
                {
                    number = number.Remove(number.Length - 1, 1);
                    if (string.IsNullOrEmpty(number))
                    {
                        LblResult.Text = "0";
                        LblCalc.Text = "";
                    }
                    else
                    {
                        LblCalc.Text = number;
                    }
                }
            }
            catch(Exception ex)
            {
                await DisplayAlert("Nothing to delete", ex.Message, "OK");
            }
        }   
            
        private async void BtnPercent_Clicked(object sender, EventArgs e)
        {
            try
            {
                string number= LblResult.Text;
                if (number != "0")
                {
                    decimal percentValue= Convert.ToDecimal(number);
                    string result = (percentValue / 100).ToString("0.##");
                    LblResult.Text = result;
                }
            }
            catch(Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        public void BtnOperator_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
           
            if (LblCalc.Text != "0" )
            {
                if (LblResult.Text == "" )
                {
                    LblCalc.Text += button.Text;
                }
                else 
                {   
                    LblCalc.Text = String.Empty;
                    LblCalc.Text = (LblResult.Text + button.Text);
                    LblResult.Text = String.Empty;
                }
            }  
                
            else
            {
                LblCalc.Text += button.Text; 
            }
        } 
        
        private void BtnEquals_Clicked(object sender, EventArgs e)
        {
            try
            {
                FastMath();

            }
            catch(Exception ex)
            {
                DisplayAlert("Error", ex.Message, "OK");
            }
        }
        
        public decimal Calculate(decimal firstNum, decimal secondNum)
        {
            decimal result = 0;

            if(operatorName=="+")
            {
                result = firstNum + secondNum;
            }
            else if (operatorName == "-")
            {
                result = firstNum - secondNum;
            }
            else if (operatorName == "*")
            {
                result = firstNum * secondNum;
            }
            else if (operatorName == "/")
            {
                result = firstNum / secondNum;
            }
            return result;
        }
    }
}

        