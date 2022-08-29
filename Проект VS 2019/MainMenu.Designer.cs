
namespace RSS_fider
{
    partial class MainMenu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.tableLayoutPanelRSS = new System.Windows.Forms.TableLayoutPanel();
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.textBoxUpdateInfo = new System.Windows.Forms.TextBox();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonUpdateSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tableLayoutPanelRSS
            // 
            this.tableLayoutPanelRSS.AutoScroll = true;
            this.tableLayoutPanelRSS.ColumnCount = 3;
            this.tableLayoutPanelRSS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelRSS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelRSS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelRSS.Location = new System.Drawing.Point(0, 26);
            this.tableLayoutPanelRSS.Name = "tableLayoutPanelRSS";
            this.tableLayoutPanelRSS.RowCount = 1;
            this.tableLayoutPanelRSS.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelRSS.Size = new System.Drawing.Size(1264, 655);
            this.tableLayoutPanelRSS.TabIndex = 0;
            // 
            // timerUpdate
            // 
            this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // textBoxUpdateInfo
            // 
            this.textBoxUpdateInfo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBoxUpdateInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxUpdateInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxUpdateInfo.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.textBoxUpdateInfo.Location = new System.Drawing.Point(12, 3);
            this.textBoxUpdateInfo.Multiline = true;
            this.textBoxUpdateInfo.Name = "textBoxUpdateInfo";
            this.textBoxUpdateInfo.ReadOnly = true;
            this.textBoxUpdateInfo.ShortcutsEnabled = false;
            this.textBoxUpdateInfo.Size = new System.Drawing.Size(149, 23);
            this.textBoxUpdateInfo.TabIndex = 1;
            this.textBoxUpdateInfo.TabStop = false;
            this.textBoxUpdateInfo.Text = " Не обновлено";
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonUpdate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonUpdate.BackgroundImage")));
            this.buttonUpdate.ForeColor = System.Drawing.SystemColors.Highlight;
            this.buttonUpdate.Location = new System.Drawing.Point(167, 3);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(32, 23);
            this.buttonUpdate.TabIndex = 2;
            this.buttonUpdate.UseVisualStyleBackColor = false;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonUpdateSettings
            // 
            this.buttonUpdateSettings.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonUpdateSettings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonUpdateSettings.BackgroundImage")));
            this.buttonUpdateSettings.ForeColor = System.Drawing.SystemColors.Highlight;
            this.buttonUpdateSettings.Location = new System.Drawing.Point(205, 3);
            this.buttonUpdateSettings.Name = "buttonUpdateSettings";
            this.buttonUpdateSettings.Size = new System.Drawing.Size(32, 23);
            this.buttonUpdateSettings.TabIndex = 3;
            this.buttonUpdateSettings.UseVisualStyleBackColor = false;
            this.buttonUpdateSettings.Click += new System.EventHandler(this.buttonUpdateSettings_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.buttonUpdateSettings);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.textBoxUpdateInfo);
            this.Controls.Add(this.tableLayoutPanelRSS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rss-читалка";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRSS;
        private System.Windows.Forms.TextBox textBoxUpdateInfo;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonUpdateSettings;
        private System.Windows.Forms.Timer timerUpdate;
    }
}

