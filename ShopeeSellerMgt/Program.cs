using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using OpenQA.Selenium.Chrome;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using PuppeteerSharp;


namespace ShopeeSellerMgt
{
    class Program
    {

        static void Main(string[] args)
        {

            if (args.Length == 0)
            {
                args = new string[1];
                // args[0] = "5899659";  // DEFAULT AGENT USER ID
                //args[1] = "Tiger@ge118";  // DEFAULT AGENT USER PASSWORD

                Console.WriteLine("Scrapping Started:" + DateTime.Now.ToString());
                //OpenBrowser();
                Scrapping_Chorme("engkian", "UATeam@20210801");
            }

            Console.WriteLine("Hello World!");
        }


        static void OpenBrowser()
        {
            String url = "http://www.google.com";
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments(new List<string>() {
             "--silent-launch",
               "--no-startup-window",
             "no-sandbox",
                 "headless",});

            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;    // This is to hidden the console.
            ChromeDriver driver = new ChromeDriver(chromeDriverService, chromeOptions);
            driver.Navigate().GoToUrl(url);
        }


        static void Scrapping_Chorme(string userID, string userPw)
        {
            try
            {


                Console.WriteLine("Scrapping Function Started:" + DateTime.Now.ToString());
                //==================== SHOW CHROME
                #region
                IWebDriver driver;
                var driverService = ChromeDriverService.CreateDefaultService();
                driverService.HideCommandPromptWindow = true;
                driver = new ChromeDriver(driverService);

                #endregion

                //================HIDE CHROME
                #region
                //var chromeOptions = new ChromeOptions();
                //chromeOptions.AddArguments(new List<string>() {
                // "--silent-launch",
                //   "--no-startup-window",
                // "no-sandbox",
                //     "headless",});
                //var chromeDriverService = ChromeDriverService.CreateDefaultService();
                //chromeDriverService.HideCommandPromptWindow = true;    // This is to hidden the console.
                //ChromeDriver driver = new ChromeDriver(chromeDriverService, chromeOptions);
                #endregion

                Console.WriteLine("Scrapping Driver Updated Properly:" + DateTime.Now.ToString());
                try
                {

                    for (int i = 0; i <= 0; i++)
                    {

                        bool statusFind_Login = false;
                        bool statusFind_Verify = true;

                        try
                        {
                            driver.Navigate().GoToUrl("https://seller.shopee.com.my/account/signin");
                            System.Threading.Thread.Sleep(3000);
                            while (statusFind_Login == false)
                            {
                                try
                                {
                                    driver.FindElement(By.XPath("//*[@id='shop-login']/div[1]/div/div[1]/div/div/input"));
                                    statusFind_Login = true;
                                    System.Threading.Thread.Sleep(2000);
                                }
                                catch
                                {
                                    statusFind_Login = false;
                                    System.Threading.Thread.Sleep(3000);
                                }

                            }
                            
                            try
                            {
                                try
                                {
                                    Console.WriteLine("Tool Entering Login Details:" + DateTime.Now.ToString());
                                    driver.FindElement(By.XPath("//*[@id='shop-login']/div[1]/div/div[1]/div/div/input")).SendKeys(userID);
                                    driver.FindElement(By.XPath("//*[@id='shop-login']/div[2]/div/div[1]/div/div/input")).SendKeys(userPw);
                                    driver.FindElement(By.XPath("//*[@id='shop-login']/div[4]/div/div/button")).Click();
                                    Console.WriteLine("Successfully Login." + DateTime.Now.ToString());

                                }
                                catch
                                {

                                }

                                try
                                {
                                    System.Threading.Thread.Sleep(3000);
                                    List<IWebElement> t1 = new List<IWebElement>(driver.FindElements(By.ClassName("language-selection__list-item")));
                                    t1[0].Click();
                                    Console.WriteLine("Language Selected" + DateTime.Now.ToString());

                                }
                                catch
                                {


                                }

                                while (statusFind_Verify == true)
                                {
                                    try
                                    {
                                        driver.FindElement(By.ClassName("_1e6qWr"));
                                        statusFind_Verify = false;
                                    }
                                    catch
                                    {
                                        statusFind_Verify = false;
                                        System.Threading.Thread.Sleep(2000);
                                    }

                                }

                                try
                                {
                                    System.Threading.Thread.Sleep(1000);
                                    Console.WriteLine("Verification Details :" + DateTime.Now.ToString());
                                    driver.FindElement(By.ClassName("_1e6qWr")).Click();
                                    System.Threading.Thread.Sleep(3000);
                                    driver.FindElement(By.ClassName("_3_offS")).Click();


                                }
                                catch
                                {

                                }

                                int cnt = 0;
                                while(statusFind_Verify==true)
                                {
                                    try
                                    {
                                        driver.FindElement(By.ClassName("RNrGkN"));
                                        statusFind_Verify = true;
                                         if(cnt<3) try { driver.FindElement(By.ClassName("_3mabcy")).Click(); cnt++; } catch { }
                                    }
                                    catch
                                    {
                                        statusFind_Verify = false;
                                        try { driver.FindElement(By.ClassName("_3mabcy")).Click(); } catch { }
                                    }
                                }

                            }
                            catch
                            {
                                Console.WriteLine("User Alredy Logged In:" + DateTime.Now.ToString());
                            }
                            System.Threading.Thread.Sleep(3000);
                            driver.Close();
                        }
                        catch
                        {
                            string ab = "";
                        }
                    }

                }
                catch
                {
                    Console.WriteLine("Check your Internet Connection", "Internet Connection Problem");

                }
                Console.WriteLine("Data Has Been Downloaded in Console Application Folder:" + DateTime.Now.ToString());
                driver.Quit();
            }

            catch (Exception ex)
            {
                Console.WriteLine("ERROR :" + ex.ToString());
            }

        }




    }
}
