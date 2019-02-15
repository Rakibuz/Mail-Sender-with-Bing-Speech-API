using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OutLook = Microsoft.Office.Interop.Outlook;
using System.Threading;
using System.Configuration;
using Microsoft.CognitiveServices.SpeechRecognition;
using System.Speech;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Media;
using System.Windows;
using System.Text.RegularExpressions;

namespace OutLookMail
{
    public partial class MainPage : Form
    {
        AutoResetEvent _FinalResponceEvent;
        MicrophoneRecognitionClient _microphoneRecognitionClient;


        //Instance Creation  for  MSAPI and SpeechSynthesizer,SpeechRecognitionEngine class
        SpeechSynthesizer speechsynth = new SpeechSynthesizer();
        SpeechRecognitionEngine receng = new SpeechRecognitionEngine();
        Choices choice = new Choices();



        public MainPage()
        {
            InitializeComponent();

            _FinalResponceEvent = new AutoResetEvent(false);


        }

        private void ConvertSpeechToText()
        {
            // Converting speech method for Subject text box
            var speechRecognitionMode = SpeechRecognitionMode.ShortPhrase;
            string language = "en-us";
            string subscriptionKey = ConfigurationManager.AppSettings["MicrosoftSpeechApiKey"].ToString();
            _microphoneRecognitionClient = SpeechRecognitionServiceFactory.CreateMicrophoneClient(
                speechRecognitionMode,
                language,
                subscriptionKey
                 );
            _microphoneRecognitionClient.OnPartialResponseReceived += ResponseReceived;
            _microphoneRecognitionClient.OnResponseReceived += OnMicShortPhraseResponceReceivedHandler;
            _microphoneRecognitionClient.StartMicAndRecognition();
        }

        private void ConvertSpeechToTextnew()
        {
            // Converting speech method for Message_textbox
            var speechRecognitionMode = SpeechRecognitionMode.ShortPhrase;
            string language = "en-us";
            string subscriptionKey = ConfigurationManager.AppSettings["MicrosoftSpeechApiKey"].ToString();
            _microphoneRecognitionClient = SpeechRecognitionServiceFactory.CreateMicrophoneClient(
                speechRecognitionMode,
                language,
                subscriptionKey
                 );
            _microphoneRecognitionClient.OnPartialResponseReceived += ResponseReceivednew;
            _microphoneRecognitionClient.OnResponseReceived += OnMicShortPhraseResponceReceivedHandlernew;
            _microphoneRecognitionClient.StartMicAndRecognition();
        }

        private void OnMicShortPhraseResponceReceivedHandlernew(object sender, SpeechResponseEventArgs e)
        {
            //Message textbox Eesponsed received invoke
            Invoke((Action)(() =>
            {
                Message_textbox.BackColor = Color.White;
                Message_textbox.ForeColor = Color.Black;
            }));
        }

        private void ResponseReceivednew(object sender, PartialSpeechResponseEventArgs e)
        {
            //Message textbox Eesponsed received invoke
            string result = e.PartialResult;

            Message_textbox.BeginInvoke((Action)(() =>

            Message_textbox.Text = result));

        }

        private void OnMicShortPhraseResponceReceivedHandler(object sender, SpeechResponseEventArgs e)
        {
            //Subject textbox Eesponsed received invoke
            //btn_record.Enabled = true;
            //textBox1.BackColor = Color.White;
            //textBox1.ForeColor = Color.Black;
            Invoke((Action)(() =>
            {
                Subject_textbox.BackColor = Color.White;
                Subject_textbox.ForeColor = Color.Black;
            }));
        }

        private void ResponseReceived(object sender, PartialSpeechResponseEventArgs e)
        {
            // Subject textbox Eesponsed received invoke
            string result = e.PartialResult;

            Subject_textbox.BeginInvoke((Action)(() =>

            Subject_textbox.Text = result));



        }

        private void MainPage_Load_1(object sender, EventArgs e)
        {

            //nothing will be done here
            choice.Add(new string[] { "hello", "Subject", "write body", "send mail", "Load Inbox", "wake up", "sleep mode", "Close OutlookMail", "Close Application", "Read Mail", "Append receiver" });
            Grammar gr = new Grammar(new GrammarBuilder(choice));
            try
            {
                receng.RequestRecognizerUpdate();
                receng.LoadGrammar(gr);
                receng.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(receng_SpeechRecognized);
                receng.AudioLevelUpdated += new EventHandler<AudioLevelUpdatedEventArgs>(receng_AudioLevelUpdated);
                receng.SetInputToDefaultAudioDevice();
                receng.RecognizeAsync(RecognizeMode.Multiple);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }
        private void receng_AudioLevelUpdated(object sender, AudioLevelUpdatedEventArgs e)
        {
            //throw new NotImplementedException();
            progressBar1.Value = e.AudioLevel;

        }

        private void receng_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            String Speech = e.Result.Text;


            if (Speech == "wake up") global.wake = true;
            if (Speech == "sleep mode") global.wake = false;


            if (global.wake == true)
            {
                
                //throw new NotImplementedException();
                switch (Speech)
                {
                    case "hello":
                        speechsynth.SelectVoiceByHints(VoiceGender.Female);
                        speechsynth.SpeakAsync("hey master what can i do for you Now");
                        break;
                    case "Append receiver":
                        speechsynth.SpeakAsync("ok alright");
                        string address = "pranto055@gmail.com";
                        To_textbox.Text += address; //appending the string to To_textbox

                        break;
                    case "Subject":
                        Subject_textbox.Focus();
                        Subject_textbox.BackColor = Color.Green;
                        Subject_textbox.ForeColor = Color.White;
                        ConvertSpeechToText(); // calling method for subject textbox
                        break;
                    case "write body":
                        Message_textbox.Focus();
                        Message_textbox.BackColor = Color.Green;
                        Message_textbox.ForeColor = Color.White;
                        ConvertSpeechToTextnew();//calling method for Message text box
                        break;
                    case "send mail":
                        global.wake = false;
                        speechsynth.SpeakAsync("Alright you said to sending mail");
                        Send_button.PerformClick();
                        //speechsynth.SpeakAsync("sending mail be patient please");
                        break;
                    case "Load Inbox":
                        global.wake = false;
                        speechsynth.SpeakAsync("Give me a few second i am working over it");
                        button1.PerformClick();
                        break;
                    case "Close OutlookMail":
                        speechsynth.SpeakAsyncCancelAll();
                        this.Close();
                        speechsynth.SpeakAsync("Ok sir");
                        break;
                    case "Close Application":
                        speechsynth.SpeakAsyncCancelAll();
                        this.Close();
                        speechsynth.SpeakAsync("Ok sir");
                        break;
                    case "Read Mail":
                        speechsynth.SpeakAsync("");

                        readmessage();

                        break;

                }

            }

        }

        private void readmessage()
        {
            global.wake = false;//turn on sleep mode to prevent garbage input at reading time

            button1.PerformClick();//load inbox from gemail
             //dataGridView.Rows[1].Selected = true;
            dataGridView.Rows[dataGridView.Rows.Count - 1].Selected = true;

            webBrowser.DocumentText = dt.Rows[dataGridView.Rows.Count - 1]["Body"].ToString();

            Int32 index = dataGridView.Rows.Count - 1;


            speechsynth.SpeakAsync("Sender");
            speechsynth.SpeakAsync(dt.Rows[index]["Sender"].ToString());

            speechsynth.SpeakAsync("Subject");
            speechsynth.SpeakAsync(dt.Rows[index]["Subject"].ToString());

             
            speechsynth.SpeakAsync("Date and time");
            // dt.Rows[index]["Date"].ToString().Trim();
            
            speechsynth.SpeakAsync(dt.Rows[index]["Date"].ToString());

            parse_msg.Text = dt.Rows[index]["Body"].ToString();
            parse_msg.Text = parse_msg.Text.Replace("<br />", Environment.NewLine);
            parse_msg.Text = Regex.Replace(parse_msg.Text, "<.*?>", String.Empty);
            speechsynth.SpeakAsync("Mail Body");
            speechsynth.SpeakAsync(parse_msg.Text);

            dt.Rows[index]["Date"].ToString().Trim();


            //string Value = dataGridView.Rows[0].Cells[0].Value.ToString();
            //speechsynth.SpeakAsync("Sender");
            //speechsynth.SpeakAsync(Value);

            //string Date = dataGridView.Rows[0].Cells[3].Value.ToString();
            //speechsynth.SpeakAsync("Date and time");
            //speechsynth.SpeakAsync(Date);




        }

        public void readmessage(object sender, DataGridViewCellEventArgs e)
        {
            button1.PerformClick();//load inbox from gemail
         
            //callcellclick
            //dataGridView.Rows[dataGridView.Rows.Count - 1].Selected = true;
            // dataGridView.Rows[1].Selected = true;

            // dataGridView.Rows[0].
            dataGridView_CellClick(sender, e);

        }
        private void Send_button_Click(object sender, EventArgs e)
        {
            try
            {
                OutLook._Application _app = new OutLook.Application();
                OutLook.MailItem mail = (OutLook.MailItem)_app.CreateItem(OutLook.OlItemType.olMailItem);
                mail.To = To_textbox.Text;
                mail.Subject = Subject_textbox.Text;
                mail.Body = Message_textbox.Text;
                mail.Importance = OutLook.OlImportance.olImportanceNormal;
                ((OutLook.MailItem)mail).Send();
                // MessageBox.Show("Your Message hasbeen successfully sent.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                speechsynth.SpeakAsync("your mail sending has been successfully done ");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                speechsynth.SpeakAsync("Sorry sir i failed to sending mail check the email address please");
            }
        }

        DataTable dt;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OutLook.Application _app = new OutLook.Application();
                OutLook.NameSpace _ns = _app.GetNamespace("MAPI");
                OutLook.MAPIFolder inbox = _ns.GetDefaultFolder(OutLook.OlDefaultFolders.olFolderInbox);
                _ns.SendAndReceive(true);
                dt = new DataTable("Inbox");
                dt.Columns.Add("Subject", typeof(String));
                dt.Columns.Add("Sender", typeof(String));
                dt.Columns.Add("Body", typeof(String));
                dt.Columns.Add("Date", typeof(String));

                dataGridView.DataSource = dt;

                foreach (OutLook.MailItem item in inbox.Items)
                    dt.Rows.Add(new object[] { item.Subject, item.SenderName, item.HTMLBody, item.SentOn.ToLongDateString() + "" + item.SentOn.ToLongTimeString() });
                 
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < dt.Rows.Count && e.RowIndex >= 0)
                webBrowser.DocumentText = dt.Rows[e.RowIndex]["Body"].ToString();//showing parsed content in web browser

                speechsynth.SpeakAsync("Sender");
                speechsynth.SpeakAsync(dt.Rows[e.RowIndex]["Sender"].ToString());
                speechsynth.SpeakAsync("Sending time");
                speechsynth.SpeakAsync(dt.Rows[e.RowIndex]["Date"].ToString());

            speechsynth.SpeakAsync("Message is");
            parse_msg.Text = dt.Rows[e.RowIndex]["Body"].ToString();
            parse_msg.Text = parse_msg.Text.Replace("<br />", Environment.NewLine);
            parse_msg.Text = Regex.Replace(parse_msg.Text, "<.*?>", String.Empty);
            speechsynth.SpeakAsync(parse_msg.Text);


        }
    }
}
