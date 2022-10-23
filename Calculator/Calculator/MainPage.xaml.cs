﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
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
        
        // variables  for calulation
        private decimal firstNum;
        private string operatorName;
        private bool isOperatorClicked;
        bool operationExecuted = false;
        // input numbers
        private void BtnCommon_Clicked(object sender, EventArgs e)
        {
           var button = sender as Button;
            if (operationExecuted)
            {
                LblCalc.Text= String.Empty;
                LblCalc.Text = button.Text;
                LblResult.Text = String.Empty;
                operationExecuted = false;
            }
            else
            { 
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
        }
       

         private void BtnClear_Clicked(object sender, EventArgs e)
        {
            LblResult.Text = "";
            LblCalc.Text = "0";
            isOperatorClicked=false;
            firstNum = 0;
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
                        isOperatorClicked = !false;
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
            isOperatorClicked = true;
            if (operationExecuted)
            {
                firstNum = Convert.ToDecimal(LblResult.Text);
                operatorName = button.Text;
                operationExecuted = false;
            }
            else
            {
                operatorName = button.Text;
                firstNum = Convert.ToDecimal(LblCalc.Text);
            }
        }
        
        private void BtnEquals_Clicked(object sender, EventArgs e)
        {
            try
            {
                decimal secondNum = Convert.ToDecimal(LblCalc.Text);
                string finalResult = Calculate(firstNum, secondNum).ToString("0.##");
                LblResult.Text = finalResult;
                operationExecuted = true;

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

        