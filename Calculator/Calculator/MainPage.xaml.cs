using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private decimal firstNum;
        private string operatorName;
        private bool isOperatorClicked;

        private void BtnCommon_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (LblCalc.Text == "0" || isOperatorClicked)
            {
                isOperatorClicked = false;
                LblCalc.Text = button.Text;
            }
            else
            {
                LblCalc.Text += button.Text;
            }
        }
       

         private void BtnClear_Clicked(object sender, EventArgs e)
        {
            LblResult.Text = "";
            LblCalc.Text = "0";
            isOperatorClicked=false;
            firstNum = 0;
        }

        private void BtnCE_Clicked(object sender, EventArgs e)
        {
            string number = LblCalc.Text;
            if (number != "0")
            { 
                number = number.Remove(number.Length-1, 1);
                if (string.IsNullOrEmpty(number))
                {
                    LblResult.Text = "0";
                    isOperatorClicked=!false;
                }
                else
                {
                    LblCalc.Text = number;
                }
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
            isOperatorClicked = true;
            operatorName= button.Text;
            firstNum = Convert.ToDecimal(LblCalc.Text);
            //LblCalc.Text += button.Text;


        }

        private void BtnEquals_Clicked(object sender, EventArgs e)
        {
            try
            {
                decimal secondNum = Convert.ToDecimal(LblCalc.Text);
                string finalResult = Calculate(firstNum, secondNum).ToString("0.##");
                LblResult.Text = finalResult;
                
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

        