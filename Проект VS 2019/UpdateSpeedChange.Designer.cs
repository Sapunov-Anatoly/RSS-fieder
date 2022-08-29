
namespace RSS_fider
{
    partial class UpdateSpeedChange
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
            this.textBoxSpeedUpdateTip = new System.Windows.Forms.TextBox();
            this.textBoxSpeedUpdate = new System.Windows.Forms.TextBox();
            this.buttonSpeedSetting = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxSpeedUpdateTip
            // 
            this.textBoxSpeedUpdateTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSpeedUpdateTip.HideSelection = false;
            this.textBoxSpeedUpdateTip.Location = new System.Drawing.Point(2, 3);
            this.textBoxSpeedUpdateTip.Name = "textBoxSpeedUpdateTip";
            this.textBoxSpeedUpdateTip.ReadOnly = true;
            this.textBoxSpeedUpdateTip.ShortcutsEnabled = false;
            this.textBoxSpeedUpdateTip.Size = new System.Drawing.Size(451, 29);
            this.textBoxSpeedUpdateTip.TabIndex = 0;
            this.textBoxSpeedUpdateTip.TabStop = false;
            this.textBoxSpeedUpdateTip.Text = "Введите частоту обновления ленты (в секундах)";
            // 
            // textBoxSpeedUpdate
            // 
            this.textBoxSpeedUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSpeedUpdate.Location = new System.Drawing.Point(2, 38);
            this.textBoxSpeedUpdate.Multiline = true;
            this.textBoxSpeedUpdate.Name = "textBoxSpeedUpdate";
            this.textBoxSpeedUpdate.Size = new System.Drawing.Size(451, 100);
            this.textBoxSpeedUpdate.TabIndex = 1;
            this.textBoxSpeedUpdate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonSpeedSetting
            // 
            this.buttonSpeedSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSpeedSetting.Location = new System.Drawing.Point(2, 144);
            this.buttonSpeedSetting.Name = "buttonSpeedSetting";
            this.buttonSpeedSetting.Size = new System.Drawing.Size(451, 102);
            this.buttonSpeedSetting.TabIndex = 2;
            this.buttonSpeedSetting.Text = "Сохранить";
            this.buttonSpeedSetting.UseVisualStyleBackColor = true;
            this.buttonSpeedSetting.Click += new System.EventHandler(this.buttonSpeedSetting_Click);
            // 
            // UpdateSpeedChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 246);
            this.Controls.Add(this.buttonSpeedSetting);
            this.Controls.Add(this.textBoxSpeedUpdate);
            this.Controls.Add(this.textBoxSpeedUpdateTip);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateSpeedChange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpdateSpeedChange";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSpeedUpdateTip;
        private System.Windows.Forms.TextBox textBoxSpeedUpdate;
        private System.Windows.Forms.Button buttonSpeedSetting;
    }
}