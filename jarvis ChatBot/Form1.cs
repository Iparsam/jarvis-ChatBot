using System;
using System.Drawing;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Threading;

namespace jarvis_ChatBot
{
    public partial class Form1 : Form
    {
        private SpeechRecognitionEngine engine = new SpeechRecognitionEngine();
        private SpeechSynthesizer Chatbot = new SpeechSynthesizer();
        private bool SetOnline = false;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.ImageLocation = "mainbc.gif";
            Chatbot.SpeakAsync("Welcome");
            Chatbot.SpeakAsync("Say Hello To check if everything is Online");
            Thread.Sleep(400);
            engine.SetInputToDefaultAudioDevice();
            string[] comStrings = new string[]
            {
                "today","hello"
                ,"howareyou","tellmedate","whoisyourcreator","open google","open c m d"
                ,"what time is it","time","tellmetime","open facebook","open youtube",
                "close the app","off",
            };
            Choices choices = new Choices(comStrings);
            GrammarBuilder builder = new GrammarBuilder(choices);
            Grammar grammar = new Grammar(choices);
            engine.LoadGrammar(grammar);
            engine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Engine_SpeechRecognized);
            engine.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void Engine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            engine.RecognizeAsyncStop();
            string res = e.Result.Text;

            if (e.Result.Text.Equals("close the app"))
            {
                this.Close();
            }
            if (e.Result.Text.Equals("hi") || e.Result.Text.Equals("hello"))
            {
                SetOnline = true;
                label1.Text = "Online";
                label1.ForeColor = Color.Green;

            }
            if (e.Result.Text.Equals("off"))
            {
                SetOnline = false;
                label1.Text = "Offline";
                label1.ForeColor = Color.Red;
            }

            while (SetOnline)
            {

                cCenter cCenter = new cCenter(res);
                break;
            }
        A:
            try
            {
                engine.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch
            {
                goto A;
            }
        }


    }
}
