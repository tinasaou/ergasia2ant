
namespace Battleship
{
    partial class Form3
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
            this.btnAutoCreate = new System.Windows.Forms.Button();
            this.btnChooseOwn = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.btnCloseApp = new System.Windows.Forms.Button();
            this.btnAudioToggle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAutoCreate
            // 
            this.btnAutoCreate.Font = new System.Drawing.Font("Rockwell Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoCreate.ForeColor = System.Drawing.Color.Black;
            this.btnAutoCreate.Location = new System.Drawing.Point(372, 322);
            this.btnAutoCreate.Name = "btnAutoCreate";
            this.btnAutoCreate.Size = new System.Drawing.Size(167, 38);
            this.btnAutoCreate.TabIndex = 41;
            this.btnAutoCreate.Text = "Auto Create";
            this.btnAutoCreate.UseVisualStyleBackColor = true;
            this.btnAutoCreate.Click += new System.EventHandler(this.btnAutoCreate_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Rockwell Condensed", 40F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.White;
            this.label26.Location = new System.Drawing.Point(112, 127);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(427, 64);
            this.label26.TabIndex = 0;
            this.label26.Text = "Welcome to Battleship!";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Rockwell Condensed", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.White;
            this.label27.Location = new System.Drawing.Point(80, 228);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(495, 41);
            this.label27.TabIndex = 42;
            this.label27.Text = "How would you like to select your ships?";
            // 
            // btnCloseApp
            // 
            this.btnCloseApp.Font = new System.Drawing.Font("Rockwell Condensed", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseApp.Location = new System.Drawing.Point(1182, 12);
            this.btnCloseApp.Name = "btnCloseApp";
            this.btnCloseApp.Size = new System.Drawing.Size(104, 28);
            this.btnCloseApp.TabIndex = 43;
            this.btnCloseApp.Text = "Close Game";
            this.btnCloseApp.UseVisualStyleBackColor = true;
            this.btnCloseApp.Click += new System.EventHandler(this.btnCloseApp_Click);
            // 
            // btnAudioToggle
            // 
            this.btnAudioToggle.Font = new System.Drawing.Font("Rockwell Condensed", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAudioToggle.Location = new System.Drawing.Point(1182, 835);
            this.btnAudioToggle.Name = "btnAudioToggle";
            this.btnAudioToggle.Size = new System.Drawing.Size(104, 28);
            this.btnAudioToggle.TabIndex = 44;
            this.btnAudioToggle.Text = "Audio Toggle";
            this.btnAudioToggle.UseVisualStyleBackColor = true;
            this.btnAudioToggle.Click += new System.EventHandler(this.btnAudioToggle_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.BackgroundImage = global::Battleship.Properties.Resources.BattleShip;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1298, 875);
            this.Controls.Add(this.btnAudioToggle);
            this.Controls.Add(this.btnCloseApp);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.btnAutoCreate);
            this.Controls.Add(this.btnChooseOwn);
            this.Controls.Add(this.label26);
            this.DoubleBuffered = true;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAutoCreate;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button btnCloseApp;
        private System.Windows.Forms.Button btnAudioToggle;
    }
}