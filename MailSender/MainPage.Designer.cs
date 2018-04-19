namespace OutLookMail
{
    partial class MainPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.To_lebel = new System.Windows.Forms.Label();
            this.Subject_lebel = new System.Windows.Forms.Label();
            this.To_textbox = new System.Windows.Forms.TextBox();
            this.Subject_textbox = new System.Windows.Forms.TextBox();
            this.Message_textbox = new System.Windows.Forms.TextBox();
            this.Send_button = new System.Windows.Forms.Button();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Message_lebel = new System.Windows.Forms.Label();
            this.parse_msg = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // To_lebel
            // 
            this.To_lebel.AutoSize = true;
            this.To_lebel.Location = new System.Drawing.Point(18, 9);
            this.To_lebel.Name = "To_lebel";
            this.To_lebel.Size = new System.Drawing.Size(20, 13);
            this.To_lebel.TabIndex = 0;
            this.To_lebel.Text = "To";
            // 
            // Subject_lebel
            // 
            this.Subject_lebel.AutoSize = true;
            this.Subject_lebel.Location = new System.Drawing.Point(11, 45);
            this.Subject_lebel.Name = "Subject_lebel";
            this.Subject_lebel.Size = new System.Drawing.Size(43, 13);
            this.Subject_lebel.TabIndex = 1;
            this.Subject_lebel.Text = "Subject";
            this.Subject_lebel.Click += new System.EventHandler(this.Subject_lebel_Click);
            // 
            // To_textbox
            // 
            this.To_textbox.Location = new System.Drawing.Point(74, 7);
            this.To_textbox.Multiline = true;
            this.To_textbox.Name = "To_textbox";
            this.To_textbox.Size = new System.Drawing.Size(596, 19);
            this.To_textbox.TabIndex = 2;
            // 
            // Subject_textbox
            // 
            this.Subject_textbox.Location = new System.Drawing.Point(74, 45);
            this.Subject_textbox.Multiline = true;
            this.Subject_textbox.Name = "Subject_textbox";
            this.Subject_textbox.Size = new System.Drawing.Size(596, 19);
            this.Subject_textbox.TabIndex = 3;
            this.Subject_textbox.TextChanged += new System.EventHandler(this.Subject_textbox_TextChanged);
            // 
            // Message_textbox
            // 
            this.Message_textbox.Location = new System.Drawing.Point(74, 86);
            this.Message_textbox.Multiline = true;
            this.Message_textbox.Name = "Message_textbox";
            this.Message_textbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Message_textbox.Size = new System.Drawing.Size(596, 72);
            this.Message_textbox.TabIndex = 4;
            // 
            // Send_button
            // 
            this.Send_button.Location = new System.Drawing.Point(595, 156);
            this.Send_button.Name = "Send_button";
            this.Send_button.Size = new System.Drawing.Size(75, 23);
            this.Send_button.TabIndex = 6;
            this.Send_button.Text = "Send";
            this.Send_button.UseVisualStyleBackColor = true;
            this.Send_button.Click += new System.EventHandler(this.Send_button_Click);
            // 
            // webBrowser
            // 
            this.webBrowser.Location = new System.Drawing.Point(674, 12);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(174, 382);
            this.webBrowser.TabIndex = 7;
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Subject,
            this.Sender,
            this.DateTime});
            this.dataGridView.Location = new System.Drawing.Point(14, 185);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(347, 207);
            this.dataGridView.TabIndex = 8;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // Subject
            // 
            this.Subject.DataPropertyName = "Subject";
            this.Subject.HeaderText = "Subject";
            this.Subject.Name = "Subject";
            // 
            // Sender
            // 
            this.Sender.DataPropertyName = "Sender";
            this.Sender.HeaderText = "Sender";
            this.Sender.Name = "Sender";
            // 
            // DateTime
            // 
            this.DateTime.DataPropertyName = "Date";
            this.DateTime.HeaderText = "DateTime";
            this.DateTime.Name = "DateTime";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(595, 398);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Receive";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 400);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(555, 12);
            this.progressBar1.TabIndex = 10;
            // 
            // Message_lebel
            // 
            this.Message_lebel.AutoSize = true;
            this.Message_lebel.Location = new System.Drawing.Point(11, 86);
            this.Message_lebel.Name = "Message_lebel";
            this.Message_lebel.Size = new System.Drawing.Size(50, 13);
            this.Message_lebel.TabIndex = 5;
            this.Message_lebel.Text = "Message";
            // 
            // parse_msg
            // 
            this.parse_msg.Location = new System.Drawing.Point(367, 185);
            this.parse_msg.Multiline = true;
            this.parse_msg.Name = "parse_msg";
            this.parse_msg.Size = new System.Drawing.Size(301, 207);
            this.parse_msg.TabIndex = 11;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 433);
            this.Controls.Add(this.parse_msg);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.Send_button);
            this.Controls.Add(this.Message_lebel);
            this.Controls.Add(this.Message_textbox);
            this.Controls.Add(this.Subject_textbox);
            this.Controls.Add(this.To_textbox);
            this.Controls.Add(this.Subject_lebel);
            this.Controls.Add(this.To_lebel);
            this.MaximizeBox = false;
            this.Name = "MainPage";
            this.Text = "OutLookMail";
            this.Load += new System.EventHandler(this.MainPage_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label To_lebel;
        private System.Windows.Forms.Label Subject_lebel;
        private System.Windows.Forms.TextBox To_textbox;
        private System.Windows.Forms.TextBox Subject_textbox;
        private System.Windows.Forms.TextBox Message_textbox;
        private System.Windows.Forms.Button Send_button;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subject;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sender;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateTime;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label Message_lebel;
        private System.Windows.Forms.TextBox parse_msg;
    }
}

