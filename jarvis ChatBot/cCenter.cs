using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Speech.Synthesis;

namespace jarvis_ChatBot
{
    internal class cCenter
    {
        public string feadback;
        private SpeechSynthesizer Chatbot = new SpeechSynthesizer();
        public cCenter(string C)
        {
            Console.WriteLine(C.ToString());
            switch (C.ToLower())
            {
                case "hi":
                case "hello":
                    Hellow();
                    break;
                case "tellmedate":
                case "today":
                    Chatbot.SpeakAsync(DateTime.Now.ToLongDateString());
                    break;
                case "tellmetime":
                case "what time is it":
                case "time":

                    Chatbot.SpeakAsync(DateTime.Now.Hour.ToString());
                    Chatbot.SpeakAsync("And");
                    Chatbot.SpeakAsync(DateTime.Now.Minute.ToString());
                    Chatbot.SpeakAsync("Minute");



                    break;
                case "howareyou":
                    Chatbot.SpeakAsync("im fine");
                    break;
                case "whoisyourcreator":
                    Chatbot.SpeakAsync("Parsa latifi");
                    break;
                case "open google":
                    System.Diagnostics.Process.Start("chrome.exe");
                    Chatbot.SpeakAsync("opening google");
                    break;
                case "open c m d":
                    Process.Start("cmd.exe");
                    Chatbot.SpeakAsync("opening cmd");
                    break;
                case "open facebook":

                    try
                    {
                        using (Process myProcess = new Process())
                        {
                            myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                            myProcess.StartInfo.FileName = "chrome.exe";
                            myProcess.StartInfo.Arguments = "https://www.facebook.com/";
                            myProcess.Start();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }

                    Chatbot.SpeakAsync("opening facebook");
                    break;
                case "open youtube":

                    try
                    {
                        using (Process myProcess = new Process())
                        {
                            myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                            myProcess.StartInfo.FileName = "chrome.exe";
                            myProcess.StartInfo.Arguments = "https://youtube.com";
                            myProcess.Start();
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                    Chatbot.SpeakAsync("opening youtube");
                    break;
                default:
                    Chatbot.SpeakAsync("Please Try again");
                    break;

            }

            C = "";
        }

        private void Hellow()
        {
            Random random = new Random();
            int x = random.Next(4);
            switch (x)
            {
                case 0:
                    Chatbot.SpeakAsync("hello Welcome");
                    break;
                case 1:
                    Chatbot.SpeakAsync("Welcome Back ");
                    break;
                case 2:
                    Chatbot.SpeakAsync("I am at your service ");
                    break;
                case 3:
                    Chatbot.SpeakAsync("hello How can i Help You? ");
                    break;
            }
        }
    }
}
