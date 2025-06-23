namespace RockShooter2 
{ 

    partial class GameWindow
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameWindow));
            this.ResumeButton = new System.Windows.Forms.Button();
            this.QuitButton = new System.Windows.Forms.Button();
            this.StartB = new System.Windows.Forms.Button();
            this.PreferencesButton = new System.Windows.Forms.PictureBox();
            this.PauseButton = new System.Windows.Forms.PictureBox();
            this.HelpButton = new System.Windows.Forms.PictureBox();
            this.StopWindow = new System.Windows.Forms.PictureBox();
            this.InformationLabel = new System.Windows.Forms.Label();
            this.MainLabel = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.MediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.RankingButton = new System.Windows.Forms.PictureBox();
            this.DifficultLevelEasyButton = new System.Windows.Forms.Button();
            this.DifficultLevelMediumButton = new System.Windows.Forms.Button();
            this.DifficultLevelHardButton = new System.Windows.Forms.Button();
            this.DifficultLevelImpossibleButton = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            ((System.ComponentModel.ISupportInitialize)(this.PreferencesButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PauseButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StopWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MediaPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RankingButton)).BeginInit();
            this.SuspendLayout();
            // 
            // ResumeButton
            // 
            this.ResumeButton.BackColor = System.Drawing.Color.Transparent;
            this.ResumeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ResumeButton.Location = new System.Drawing.Point(310, 299);
            this.ResumeButton.Name = "ResumeButton";
            this.ResumeButton.Size = new System.Drawing.Size(269, 41);
            this.ResumeButton.TabIndex = 11;
            this.ResumeButton.Text = "RESUME";
            this.ResumeButton.UseVisualStyleBackColor = false;
            this.ResumeButton.Visible = false;
            this.ResumeButton.Click += new System.EventHandler(this.ResumeButton_Click);
            // 
            // QuitButton
            // 
            this.QuitButton.BackColor = System.Drawing.Color.Transparent;
            this.QuitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.QuitButton.Location = new System.Drawing.Point(27, 299);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(277, 41);
            this.QuitButton.TabIndex = 10;
            this.QuitButton.Text = "QUIT";
            this.QuitButton.UseVisualStyleBackColor = false;
            this.QuitButton.Visible = false;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // StartB
            // 
            this.StartB.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.StartB.Location = new System.Drawing.Point(68, 678);
            this.StartB.Name = "StartB";
            this.StartB.Size = new System.Drawing.Size(596, 50);
            this.StartB.TabIndex = 2;
            this.StartB.Text = "START";
            this.StartB.UseVisualStyleBackColor = true;
            this.StartB.Click += new System.EventHandler(this.StartB_Click);
            // 
            // PreferencesButton
            // 
            this.PreferencesButton.BackColor = System.Drawing.Color.Transparent;
            this.PreferencesButton.BackgroundImage = global::RockShooter2.Properties.Resources.PreferencesIcon;
            this.PreferencesButton.Location = new System.Drawing.Point(12, 678);
            this.PreferencesButton.Name = "PreferencesButton";
            this.PreferencesButton.Size = new System.Drawing.Size(50, 50);
            this.PreferencesButton.TabIndex = 3;
            this.PreferencesButton.TabStop = false;
            this.PreferencesButton.Click += new System.EventHandler(this.PreferencesButton_Click);
            // 
            // PauseButton
            // 
            this.PauseButton.BackColor = System.Drawing.Color.Transparent;
            this.PauseButton.BackgroundImage = global::RockShooter2.Properties.Resources.PauseIcon;
            this.PauseButton.Location = new System.Drawing.Point(12, 622);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(50, 50);
            this.PauseButton.TabIndex = 4;
            this.PauseButton.TabStop = false;
            this.PauseButton.Visible = false;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // HelpButton
            // 
            this.HelpButton.BackColor = System.Drawing.Color.Transparent;
            this.HelpButton.BackgroundImage = global::RockShooter2.Properties.Resources.HelpIcon;
            this.HelpButton.Location = new System.Drawing.Point(670, 678);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(50, 50);
            this.HelpButton.TabIndex = 5;
            this.HelpButton.TabStop = false;
            this.HelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // StopWindow
            // 
            this.StopWindow.BackColor = System.Drawing.Color.Gainsboro;
            this.StopWindow.Location = new System.Drawing.Point(68, 162);
            this.StopWindow.Name = "StopWindow";
            this.StopWindow.Size = new System.Drawing.Size(596, 352);
            this.StopWindow.TabIndex = 6;
            this.StopWindow.TabStop = false;
            this.StopWindow.Visible = false;
            // 
            // InformationLabel
            // 
            this.InformationLabel.BackColor = System.Drawing.Color.Transparent;
            this.InformationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.InformationLabel.Location = new System.Drawing.Point(27, 59);
            this.InformationLabel.Name = "InformationLabel";
            this.InformationLabel.Size = new System.Drawing.Size(552, 237);
            this.InformationLabel.TabIndex = 9;
            this.InformationLabel.Text = "Some informtion";
            this.InformationLabel.Visible = false;
            // 
            // MainLabel
            // 
            this.MainLabel.BackColor = System.Drawing.Color.Transparent;
            this.MainLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MainLabel.Location = new System.Drawing.Point(10, 10);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(557, 49);
            this.MainLabel.TabIndex = 8;
            this.MainLabel.Text = "Game Over";
            this.MainLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MainLabel.Visible = false;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 50;
            this.timer.Tick += new System.EventHandler(this.timer_Tick_1);
            // 
            // MediaPlayer
            // 
            this.MediaPlayer.Enabled = true;
            this.MediaPlayer.Location = new System.Drawing.Point(27, 538);
            this.MediaPlayer.Name = "MediaPlayer";
            this.MediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MediaPlayer.OcxState")));
            this.MediaPlayer.Size = new System.Drawing.Size(98, 61);
            this.MediaPlayer.TabIndex = 9;
            this.MediaPlayer.Visible = false;
            // 
            // RankingButton
            // 
            this.RankingButton.BackColor = System.Drawing.Color.Transparent;
            this.RankingButton.BackgroundImage = global::RockShooter2.Properties.Resources.RankingIcon;
            this.RankingButton.Location = new System.Drawing.Point(670, 622);
            this.RankingButton.Name = "RankingButton";
            this.RankingButton.Size = new System.Drawing.Size(50, 50);
            this.RankingButton.TabIndex = 12;
            this.RankingButton.TabStop = false;
            this.RankingButton.Click += new System.EventHandler(this.RankingButton_Click);
            // 
            // DifficultLevelEasyButton
            // 
            this.DifficultLevelEasyButton.BackColor = System.Drawing.Color.Chartreuse;
            this.DifficultLevelEasyButton.Location = new System.Drawing.Point(281, 600);
            this.DifficultLevelEasyButton.Name = "DifficultLevelEasyButton";
            this.DifficultLevelEasyButton.Size = new System.Drawing.Size(187, 40);
            this.DifficultLevelEasyButton.TabIndex = 13;
            this.DifficultLevelEasyButton.Text = "EASY";
            this.DifficultLevelEasyButton.UseVisualStyleBackColor = false;
            this.DifficultLevelEasyButton.Visible = false;
            this.DifficultLevelEasyButton.Click += new System.EventHandler(this.DifficultLevelEasyButton_Click);
            // 
            // DifficultLevelMediumButton
            // 
            this.DifficultLevelMediumButton.BackColor = System.Drawing.Color.Yellow;
            this.DifficultLevelMediumButton.Location = new System.Drawing.Point(281, 550);
            this.DifficultLevelMediumButton.Name = "DifficultLevelMediumButton";
            this.DifficultLevelMediumButton.Size = new System.Drawing.Size(187, 40);
            this.DifficultLevelMediumButton.TabIndex = 14;
            this.DifficultLevelMediumButton.Text = "MEDIUM";
            this.DifficultLevelMediumButton.UseVisualStyleBackColor = false;
            this.DifficultLevelMediumButton.Visible = false;
            this.DifficultLevelMediumButton.Click += new System.EventHandler(this.DifficultLevelMediumButton_Click);
            // 
            // DifficultLevelHardButton
            // 
            this.DifficultLevelHardButton.BackColor = System.Drawing.Color.Red;
            this.DifficultLevelHardButton.Location = new System.Drawing.Point(281, 500);
            this.DifficultLevelHardButton.Name = "DifficultLevelHardButton";
            this.DifficultLevelHardButton.Size = new System.Drawing.Size(187, 40);
            this.DifficultLevelHardButton.TabIndex = 15;
            this.DifficultLevelHardButton.Text = "HARD";
            this.DifficultLevelHardButton.UseVisualStyleBackColor = false;
            this.DifficultLevelHardButton.Visible = false;
            this.DifficultLevelHardButton.Click += new System.EventHandler(this.DifficultLevelHardButton_Click);
            // 
            // DifficultLevelImpossibleButton
            // 
            this.DifficultLevelImpossibleButton.BackColor = System.Drawing.Color.Black;
            this.DifficultLevelImpossibleButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DifficultLevelImpossibleButton.Location = new System.Drawing.Point(281, 450);
            this.DifficultLevelImpossibleButton.Name = "DifficultLevelImpossibleButton";
            this.DifficultLevelImpossibleButton.Size = new System.Drawing.Size(187, 40);
            this.DifficultLevelImpossibleButton.TabIndex = 16;
            this.DifficultLevelImpossibleButton.Text = "IMPOSSIBLE";
            this.DifficultLevelImpossibleButton.UseVisualStyleBackColor = false;
            this.DifficultLevelImpossibleButton.Visible = false;
            this.DifficultLevelImpossibleButton.Click += new System.EventHandler(this.DifficultLevelImpossibleButton_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 753);
            this.splitter1.TabIndex = 17;
            this.splitter1.TabStop = false;
            // 
            // GameWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackgroundImage = global::RockShooter2.Properties.Resources.Background;
            this.ClientSize = new System.Drawing.Size(732, 753);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.DifficultLevelImpossibleButton);
            this.Controls.Add(this.DifficultLevelHardButton);
            this.Controls.Add(this.DifficultLevelMediumButton);
            this.Controls.Add(this.DifficultLevelEasyButton);
            this.Controls.Add(this.RankingButton);
            this.Controls.Add(this.MediaPlayer);
            this.Controls.Add(this.MainLabel);
            this.Controls.Add(this.InformationLabel);
            this.Controls.Add(this.StopWindow);
            this.Controls.Add(this.HelpButton);
            this.Controls.Add(this.PauseButton);
            this.Controls.Add(this.PreferencesButton);
            this.Controls.Add(this.StartB);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.ResumeButton);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(750, 800);
            this.Name = "GameWindow";
            this.Text = "Game";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PreferencesButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PauseButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StopWindow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MediaPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RankingButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ResumeButton;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.Button StartB;
        private System.Windows.Forms.PictureBox PreferencesButton;
        private System.Windows.Forms.PictureBox PauseButton;
        private System.Windows.Forms.PictureBox HelpButton;
        private System.Windows.Forms.PictureBox StopWindow;
        private System.Windows.Forms.Label InformationLabel;
        private System.Windows.Forms.Label MainLabel;
        private System.Windows.Forms.Timer timer;
        private AxWMPLib.AxWindowsMediaPlayer MediaPlayer;
        private System.Windows.Forms.PictureBox RankingButton;
        private System.Windows.Forms.Button DifficultLevelEasyButton;
        private System.Windows.Forms.Button DifficultLevelMediumButton;
        private System.Windows.Forms.Button DifficultLevelHardButton;
        private System.Windows.Forms.Button DifficultLevelImpossibleButton;
        private System.Windows.Forms.Splitter splitter1;
    }
}

