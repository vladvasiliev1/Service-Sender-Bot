using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Service_Sender_Bot
{
    static class Browser
    {
        static IWebDriver driver = null;

        static List<string> tumbnails = new List<string>();

        public static bool IsWork = false;

        public static void Start()
        {
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.arabiandate.com/");

            
        }

        public async static void Work()
        {
            await Task.Run(() => 
            {
                if (!IsWork)
                {
                    IsWork = true;

                    driver.FindElement(By.CssSelector("section.account-options > ul > li.mingle")).Click();

                    Thread.Sleep(3000); //5 min

                    while (IsWork)
                    {
                        try
                        {
                            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> elems = driver.FindElements(
                            By.CssSelector("a.thumbnail"));

                            

                            foreach (IWebElement elem in elems)
                            {
                                try
                                {
                                    if (tumbnails.Contains(elem.GetAttribute("href")) == false)
                                    {
                                        tumbnails.Add(elem.GetAttribute("href"));

                                        elem.Click();

                                        try
                                        {

                                            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                                            driver.FindElement(By.CssSelector("form.message-form > button.chat")).Click();

                                            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);



                                            driver.FindElement(By.CssSelector("section.chat > div.chat > div.close")).Click(); }
                                        catch { }

                                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5000);

                                        driver.FindElement(By.CssSelector("section.account-options > ul > li.mingle")).Click();
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                }
                                catch (Exception ex)
                                {
                                    break;
                                    Thread.Sleep(3000);

                                    driver.FindElement(By.CssSelector("section.account-options > ul > li.mingle")).Click();
                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.Message);
                        }
                    }
                }
            });
            

        }

        public static void StopWork()
        {
            IsWork = false;
        }
    }
}
