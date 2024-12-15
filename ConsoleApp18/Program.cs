using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        // Replace this with the path to your chromedriver executable
        string webdriverPath = @"C:\Users\User\Downloads\chromedriver-win64\chromedriver.exe";

        // URL of the Google Form
        string formUrl = "https://forms.gle/D5dHneWKouiEDAh38";

        // Number of times to fill the form
        Console.Write("Enter the number of times to fill the form: ");
        int times = int.Parse(Console.ReadLine());

        // Initialize ChromeDriver
        ChromeOptions options = new ChromeOptions();
        options.AddArgument("--start-maximized"); // Maximize the browser window
        IWebDriver driver = new ChromeDriver(webdriverPath, options);

        // Navigate to the Google Form
        driver.Navigate().GoToUrl(formUrl);
        Thread.Sleep(500); // Let the page load

        // Fill out the form 'times' number of times
        for (int i = 0; i < times; i++)
        {
            // Detect question types and fill out the form accordingly
            FillOutForm(driver);
            // Go back to the form for the next entry
            driver.Navigate().GoToUrl(formUrl);
            Thread.Sleep(500); // Let the page load
        }

        // Close the browser
        driver.Quit();
    }

    static void FillOutForm(IWebDriver driver)
    {
        // Get all question elements
        IReadOnlyCollection<IWebElement> questionElements = driver.FindElements(By.XPath("//div[@role='radiogroup' or @role='checkbox' or @role='slider']"));
        int times = 0;
        foreach (IWebElement questionElement in questionElements)
        {
            times++;
            SelectLinearScaleOption(driver, questionElement, times);
        }

        // After filling out all questions, find and click the "Submit" button
        IWebElement submitButton = driver.FindElement(By.XPath("//span[text()='שליחה']"));
        submitButton.Click();
    }
    static void SelectLinearScaleOption(IWebDriver driver, IWebElement questionElement, int times)
    {
        // Find all labels within the question element
        IReadOnlyCollection<IWebElement> labels = questionElement.FindElements(By.TagName("label"));

        // Randomly select one of the labels
        Random random = new Random();
        int index = random.Next(0, labels.Count); //random
        if (times==9)
        {
            index =random.Next(0,labels.Count-3);// lowers
        }else if(times!=0)
        {
            index = random.Next(2, labels.Count);//highers the value
        }
        IWebElement selectedLabel = labels.ElementAt(index);

        // Click on the selected label
        selectedLabel.Click();

        // Optional: You might want to add a brief delay to ensure the selection is made before proceeding
    }

}