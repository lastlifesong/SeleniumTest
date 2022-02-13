using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chromium;
using System.IO;
using System.Reflection;
using System.Collections.Generic;


namespace ConsoleApp6
{
    class Program
    {

         static void Main(string[] args)
        {
            Program program = new Program();
            string formFirstName = "id_first_name";
            string formLastName = "id_last_name";
            string formEmail = "id_email";
            string formPhone = "id_phone";
            string formPesel = "id_pesel";
            string formId = "id_id_numer";
            string formDate = "id_date";
            string formButton = "form_button_next";
         

            List<IWebElement> formElements = new List<IWebElement>();
            string myUrl = @"https://app.bluealert.pl/ba/form/formularz-testowy";
            ChromeDriver chromeDriver = new ChromeDriver();
           // IJavaScriptExecutor javaScriptE = (JavaScriptExecutor)chromeDriver;
          
            chromeDriver.Navigate().GoToUrl(myUrl);
          
            formElements = program.FormElementById(chromeDriver,formElements,formFirstName,formLastName,formEmail,formPhone,formPesel,formId,formDate);
            program.InputProperData(chromeDriver, formElements, "Test", "Test2", "dawid@gmail.com", "123123123", "67101325175", "NVT182194", "2002-02-10");
           


            foreach (var item in formElements)
            { 
               Console.WriteLine(item.ToString());
            }
            var formButtonElement = chromeDriver.FindElement(By.Id(formButton));

            formElements[6].Click();
            formElements[0].Click();
            formButtonElement.Click();
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
    
            //chromeDriver.Navigate().GoToUrl(myUrl);
            // IWebElement element = chromeDriver.FindElement(By.Id("id_first_name"));
            //List<IWebElement> elements;
         
            //element.SendKeys("Test");
           

        }




        public void InputProperData(ChromeDriver driver, List<IWebElement> elements, string name, string surname, string email, string number, string pesel, string yourId, string date)
        {
            elements[0].SendKeys(name);
            elements[1].SendKeys(surname);
            elements[2].SendKeys(email);
            elements[3].SendKeys(number);
            elements[4].SendKeys(pesel.ToString());
            elements[5].SendKeys(yourId);
            elements[6].SendKeys(date.ToString());
        }

        public List<IWebElement> FormElementById(WebDriver driver, List<IWebElement> elements, string name, string surname, string email, string number, string pesel, string yourId, string date)
        {

            elements.Add(driver.FindElement(By.Id(name)));
            elements.Add(driver.FindElement(By.Id(surname)));
            elements.Add(driver.FindElement(By.Id(email)));
            elements.Add(driver.FindElement(By.Id(number)));
            elements.Add(driver.FindElement(By.Id(pesel.ToString())));
            elements.Add(driver.FindElement(By.Id(yourId)));
            elements.Add(driver.FindElement(By.Id(date)));


            List<IWebElement> temp = elements;

      

            return temp;
        }
        
    }
}
