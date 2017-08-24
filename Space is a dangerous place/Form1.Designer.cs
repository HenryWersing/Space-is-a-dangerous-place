namespace Space_is_a_dangerous_place
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.geländetimer = new System.Windows.Forms.Timer(this.components);
            this.raumschifftimer = new System.Windows.Forms.Timer(this.components);
            this.labelraumschiff = new System.Windows.Forms.Label();
            this.buttonstart = new System.Windows.Forms.Button();
            this.textboxtimer = new System.Windows.Forms.TextBox();
            this.textboxschuss = new System.Windows.Forms.TextBox();
            this.textboxscore = new System.Windows.Forms.TextBox();
            this.labelmunition = new System.Windows.Forms.Label();
            this.labelscore = new System.Windows.Forms.Label();
            this.labeltutorial = new System.Windows.Forms.Label();
            this.labelrecklinks = new System.Windows.Forms.Label();
            this.labelrecklinks2 = new System.Windows.Forms.Label();
            this.labelrecklinks3 = new System.Windows.Forms.Label();
            this.labelrecklinks1 = new System.Windows.Forms.Label();
            this.labelreckrechts = new System.Windows.Forms.Label();
            this.labelreckrechts1 = new System.Windows.Forms.Label();
            this.labelreckrechts2 = new System.Windows.Forms.Label();
            this.labelreckrechts3 = new System.Windows.Forms.Label();
            this.labelalien = new System.Windows.Forms.Label();
            this.labelalienlootmuni = new System.Windows.Forms.Label();
            this.labelalienlootscore = new System.Windows.Forms.Label();
            this.labelalienlootbombe = new System.Windows.Forms.Label();
            this.labelmessage = new System.Windows.Forms.Label();
            this.pictureBoxende = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxende)).BeginInit();
            this.SuspendLayout();
            // 
            // geländetimer
            // 
            this.geländetimer.Interval = 14;
            this.geländetimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // raumschifftimer
            // 
            this.raumschifftimer.Interval = 20;
            this.raumschifftimer.Tick += new System.EventHandler(this.raumschifftimer_Tick);
            // 
            // labelraumschiff
            // 
            this.labelraumschiff.Location = new System.Drawing.Point(300, 500);
            this.labelraumschiff.Name = "labelraumschiff";
            this.labelraumschiff.Size = new System.Drawing.Size(35, 13);
            this.labelraumschiff.TabIndex = 0;
            // 
            // buttonstart
            // 
            this.buttonstart.Location = new System.Drawing.Point(281, 574);
            this.buttonstart.Name = "buttonstart";
            this.buttonstart.Size = new System.Drawing.Size(75, 23);
            this.buttonstart.TabIndex = 1;
            this.buttonstart.Text = "Start";
            this.buttonstart.UseVisualStyleBackColor = true;
            this.buttonstart.Click += new System.EventHandler(this.buttonstart_Click);
            // 
            // textboxtimer
            // 
            this.textboxtimer.Location = new System.Drawing.Point(377, 576);
            this.textboxtimer.Name = "textboxtimer";
            this.textboxtimer.ReadOnly = true;
            this.textboxtimer.Size = new System.Drawing.Size(80, 20);
            this.textboxtimer.TabIndex = 2;
            // 
            // textboxschuss
            // 
            this.textboxschuss.Location = new System.Drawing.Point(225, 576);
            this.textboxschuss.Name = "textboxschuss";
            this.textboxschuss.ReadOnly = true;
            this.textboxschuss.Size = new System.Drawing.Size(39, 20);
            this.textboxschuss.TabIndex = 3;
            this.textboxschuss.Text = "Mu:";
            // 
            // textboxscore
            // 
            this.textboxscore.Location = new System.Drawing.Point(178, 576);
            this.textboxscore.Name = "textboxscore";
            this.textboxscore.ReadOnly = true;
            this.textboxscore.Size = new System.Drawing.Size(41, 20);
            this.textboxscore.TabIndex = 4;
            this.textboxscore.Text = "Sc:";
            // 
            // labelmunition
            // 
            this.labelmunition.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelmunition.Location = new System.Drawing.Point(-100, 0);
            this.labelmunition.Name = "labelmunition";
            this.labelmunition.Size = new System.Drawing.Size(100, 23);
            this.labelmunition.TabIndex = 5;
            // 
            // labelscore
            // 
            this.labelscore.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelscore.Location = new System.Drawing.Point(-100, 0);
            this.labelscore.Name = "labelscore";
            this.labelscore.Size = new System.Drawing.Size(100, 23);
            this.labelscore.TabIndex = 6;
            // 
            // labeltutorial
            // 
            this.labeltutorial.AutoSize = true;
            this.labeltutorial.ForeColor = System.Drawing.Color.White;
            this.labeltutorial.Location = new System.Drawing.Point(238, 329);
            this.labeltutorial.Name = "labeltutorial";
            this.labeltutorial.Size = new System.Drawing.Size(171, 104);
            this.labeltutorial.TabIndex = 7;
            this.labeltutorial.Text = "Links/Rechts - bewegen\r\nRunter - Schießen\r\n\r\nMu steht für Munition\r\nSc steht für " +
    "den Score.\r\n\r\nSammle möglichst viel Score, ohne\r\nin die Hindernisse zu fliegen.";
            // 
            // labelrecklinks
            // 
            this.labelrecklinks.Location = new System.Drawing.Point(0, -10);
            this.labelrecklinks.Name = "labelrecklinks";
            this.labelrecklinks.Size = new System.Drawing.Size(100, 23);
            this.labelrecklinks.TabIndex = 8;
            // 
            // labelrecklinks2
            // 
            this.labelrecklinks2.Location = new System.Drawing.Point(700, 0);
            this.labelrecklinks2.Name = "labelrecklinks2";
            this.labelrecklinks2.Size = new System.Drawing.Size(100, 23);
            this.labelrecklinks2.TabIndex = 9;
            // 
            // labelrecklinks3
            // 
            this.labelrecklinks3.Location = new System.Drawing.Point(700, 0);
            this.labelrecklinks3.Name = "labelrecklinks3";
            this.labelrecklinks3.Size = new System.Drawing.Size(100, 23);
            this.labelrecklinks3.TabIndex = 10;
            // 
            // labelrecklinks1
            // 
            this.labelrecklinks1.Location = new System.Drawing.Point(700, 0);
            this.labelrecklinks1.Name = "labelrecklinks1";
            this.labelrecklinks1.Size = new System.Drawing.Size(100, 23);
            this.labelrecklinks1.TabIndex = 11;
            // 
            // labelreckrechts
            // 
            this.labelreckrechts.Location = new System.Drawing.Point(438, -10);
            this.labelreckrechts.Name = "labelreckrechts";
            this.labelreckrechts.Size = new System.Drawing.Size(100, 23);
            this.labelreckrechts.TabIndex = 12;
            // 
            // labelreckrechts1
            // 
            this.labelreckrechts1.Location = new System.Drawing.Point(700, 0);
            this.labelreckrechts1.Name = "labelreckrechts1";
            this.labelreckrechts1.Size = new System.Drawing.Size(100, 23);
            this.labelreckrechts1.TabIndex = 13;
            // 
            // labelreckrechts2
            // 
            this.labelreckrechts2.Location = new System.Drawing.Point(700, 0);
            this.labelreckrechts2.Name = "labelreckrechts2";
            this.labelreckrechts2.Size = new System.Drawing.Size(100, 23);
            this.labelreckrechts2.TabIndex = 14;
            // 
            // labelreckrechts3
            // 
            this.labelreckrechts3.Location = new System.Drawing.Point(700, 0);
            this.labelreckrechts3.Name = "labelreckrechts3";
            this.labelreckrechts3.Size = new System.Drawing.Size(100, 23);
            this.labelreckrechts3.TabIndex = 15;
            // 
            // labelalien
            // 
            this.labelalien.BackColor = System.Drawing.Color.Transparent;
            this.labelalien.Location = new System.Drawing.Point(-100, 0);
            this.labelalien.Name = "labelalien";
            this.labelalien.Size = new System.Drawing.Size(100, 23);
            this.labelalien.TabIndex = 16;
            // 
            // labelalienlootmuni
            // 
            this.labelalienlootmuni.BackColor = System.Drawing.Color.Black;
            this.labelalienlootmuni.Location = new System.Drawing.Point(-100, 0);
            this.labelalienlootmuni.Name = "labelalienlootmuni";
            this.labelalienlootmuni.Size = new System.Drawing.Size(100, 23);
            this.labelalienlootmuni.TabIndex = 17;
            // 
            // labelalienlootscore
            // 
            this.labelalienlootscore.BackColor = System.Drawing.Color.Black;
            this.labelalienlootscore.Location = new System.Drawing.Point(-100, 0);
            this.labelalienlootscore.Name = "labelalienlootscore";
            this.labelalienlootscore.Size = new System.Drawing.Size(100, 23);
            this.labelalienlootscore.TabIndex = 18;
            // 
            // labelalienlootbombe
            // 
            this.labelalienlootbombe.BackColor = System.Drawing.Color.Transparent;
            this.labelalienlootbombe.Location = new System.Drawing.Point(-100, 0);
            this.labelalienlootbombe.Name = "labelalienlootbombe";
            this.labelalienlootbombe.Size = new System.Drawing.Size(100, 23);
            this.labelalienlootbombe.TabIndex = 19;
            // 
            // labelmessage
            // 
            this.labelmessage.AutoSize = true;
            this.labelmessage.BackColor = System.Drawing.Color.Transparent;
            this.labelmessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.labelmessage.ForeColor = System.Drawing.Color.White;
            this.labelmessage.Location = new System.Drawing.Point(265, -1);
            this.labelmessage.Name = "labelmessage";
            this.labelmessage.Size = new System.Drawing.Size(70, 26);
            this.labelmessage.TabIndex = 20;
            this.labelmessage.Text = "label1";
            // 
            // pictureBoxende
            // 
            this.pictureBoxende.Image = global::Space_is_a_dangerous_place.Properties.Resources.endebild;
            this.pictureBoxende.InitialImage = null;
            this.pictureBoxende.Location = new System.Drawing.Point(-2000, -2000);
            this.pictureBoxende.Name = "pictureBoxende";
            this.pictureBoxende.Size = new System.Drawing.Size(614, 584);
            this.pictureBoxende.TabIndex = 21;
            this.pictureBoxende.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(638, 609);
            this.Controls.Add(this.pictureBoxende);
            this.Controls.Add(this.textboxscore);
            this.Controls.Add(this.textboxschuss);
            this.Controls.Add(this.textboxtimer);
            this.Controls.Add(this.buttonstart);
            this.Controls.Add(this.labelmessage);
            this.Controls.Add(this.labelalienlootbombe);
            this.Controls.Add(this.labelalienlootscore);
            this.Controls.Add(this.labelalienlootmuni);
            this.Controls.Add(this.labelalien);
            this.Controls.Add(this.labeltutorial);
            this.Controls.Add(this.labelreckrechts3);
            this.Controls.Add(this.labelreckrechts2);
            this.Controls.Add(this.labelreckrechts1);
            this.Controls.Add(this.labelreckrechts);
            this.Controls.Add(this.labelrecklinks1);
            this.Controls.Add(this.labelrecklinks3);
            this.Controls.Add(this.labelrecklinks2);
            this.Controls.Add(this.labelrecklinks);
            this.Controls.Add(this.labelscore);
            this.Controls.Add(this.labelmunition);
            this.Controls.Add(this.labelraumschiff);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form1";
            this.Text = "Space is a dangerous place";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxende)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer geländetimer;
        private System.Windows.Forms.Timer raumschifftimer;
        private System.Windows.Forms.Label labelraumschiff;
        private System.Windows.Forms.Button buttonstart;
        private System.Windows.Forms.TextBox textboxtimer;
        private System.Windows.Forms.TextBox textboxschuss;
        private System.Windows.Forms.TextBox textboxscore;
        private System.Windows.Forms.Label labelmunition;
        private System.Windows.Forms.Label labelscore;
        private System.Windows.Forms.Label labeltutorial;
        private System.Windows.Forms.Label labelrecklinks;
        private System.Windows.Forms.Label labelrecklinks2;
        private System.Windows.Forms.Label labelrecklinks3;
        private System.Windows.Forms.Label labelrecklinks1;
        private System.Windows.Forms.Label labelreckrechts;
        private System.Windows.Forms.Label labelreckrechts1;
        private System.Windows.Forms.Label labelreckrechts2;
        private System.Windows.Forms.Label labelreckrechts3;
        private System.Windows.Forms.Label labelalien;
        private System.Windows.Forms.Label labelalienlootmuni;
        private System.Windows.Forms.Label labelalienlootscore;
        private System.Windows.Forms.Label labelalienlootbombe;
        private System.Windows.Forms.Label labelmessage;
        private System.Windows.Forms.PictureBox pictureBoxende;
    }
}

