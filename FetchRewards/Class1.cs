using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            try
            {
                ChromeDriver driver = new ChromeDriver();
                driver.Navigate().GoToUrl("http://ec2-54-208-152-154.compute-1.amazonaws.com/");
                driver.Manage().Window.Maximize();
                Thread.Sleep(2000);
                //Enter value in the left 
                driver.FindElementByXPath("//input[@id='left_0']").SendKeys("0");
                Thread.Sleep(2000);
                List<int> Num = new List<int>();
                for (int i = 1; i <= 8; i++)
                {
                    driver.FindElementByXPath("//input[@id='right_0']").Clear();
                    driver.FindElementByXPath("//input[@id='right_0']").SendKeys(i.ToString());
                    Thread.Sleep(2000);

                    //click on weigh button
                    driver.FindElementByXPath("//*[@id='weigh']").Click();
                    //Verify the Weigh result
                    string result = driver.FindElementByXPath("//button[@id='reset']").Text;
                    if (result.Contains("="))
                    {

                    }
                    else
                    {
                        Num.Add(i);
                    }
                    
                }

                if (Num.Count > 2)
                {

                    driver.FindElementByXPath("(//div[@class='coins']/button)[1]").Click();
                }
                else
                {                 
                    driver.FindElementByXPath("//div[@class='coins']/button[contains(text(),'"+Num[0]+"')]").Click();
                }

            }
            catch (Exception ex)
            {

            }
        }
    }

}



