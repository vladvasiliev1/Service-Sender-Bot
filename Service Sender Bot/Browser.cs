using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.Runtime.CompilerServices;

namespace Service_Sender_Bot
{
    static class Browser
    {
        static IWebDriver driver = null;

        static List<string> tumbnails = new List<string>();

        static Thread thread;

        static int Sleep1 = 1000;

        static int Sleep2 = 1000;

        static int Sleep3 = 1000;

        public static void Start()
        {
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.arabiandate.com/");

        }

        public static void StartWork(int sleep1, int sleep2, int sleep3)
        {
            Sleep1 *= sleep1;
            Sleep2 *= sleep2;
            Sleep3 *= sleep3;

            if (thread.ThreadState != ThreadState.Running)
            {
                thread = new Thread(new ThreadStart(Work));

                thread.Start();
            }
            
        }

        static void Work()
        {
            driver.FindElement(By.CssSelector("section.account-options > ul > li.mingle")).Click();

            Thread.Sleep(3000); //5 min

            while (true)
            {
                try
                {
                    System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> elems = driver.FindElements(
                    By.CssSelector("a.thumbnail"));



                    foreach (IWebElement elem in elems)
                    {
                        try
                        {
                            Thread.Sleep(Sleep1);
                            if (tumbnails.Contains(elem.GetAttribute("href")) == false)
                            {
                                tumbnails.Add(elem.GetAttribute("href"));

                                elem.Click();

                                try
                                {
                                    Thread.Sleep(Sleep2);
                                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                                    driver.FindElement(By.CssSelector("form.message-form > button.chat")).Click();

                                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);



                                    driver.FindElement(By.CssSelector("section.chat > div.chat > div.close")).Click();
                                }
                                catch { }

                                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5000);

                                Thread.Sleep(Sleep3);

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
                            
                        }

                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }

        }

        static void Restart()
        {
            Stop();

            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                driver.FindElement(By.CssSelector("span.close")).Click();
            }
            catch
            {

            }

            StartWork(Sleep1,Sleep2, Sleep3);


        }

        public static void Stop()
        {
            if(thread.ThreadState == ThreadState.Running)
            {
                try
                {
                    thread.Abort();
                }
                catch (ThreadAbortException)
                {

                }

                thread = null;
            }
        }
    }
}
