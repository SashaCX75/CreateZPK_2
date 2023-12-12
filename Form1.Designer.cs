namespace CreateZPK_2
{
    partial class Form1
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
            this.button_Create_Zpk = new System.Windows.Forms.Button();
            this.radioButton_WinRar = new System.Windows.Forms.RadioButton();
            this.radioButton_7Zip = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // button_Create_Zpk
            // 
            this.button_Create_Zpk.Enabled = false;
            this.button_Create_Zpk.Location = new System.Drawing.Point(12, 12);
            this.button_Create_Zpk.Name = "button_Create_Zpk";
            this.button_Create_Zpk.Size = new System.Drawing.Size(173, 23);
            this.button_Create_Zpk.TabIndex = 0;
            this.button_Create_Zpk.Text = "Create *.zpk file";
            this.button_Create_Zpk.UseVisualStyleBackColor = true;
            this.button_Create_Zpk.Click += new System.EventHandler(this.button_Create_Zpk_Click);
            // 
            // radioButton_WinRar
            // 
            this.radioButton_WinRar.AutoSize = true;
            this.radioButton_WinRar.Enabled = false;
            this.radioButton_WinRar.Location = new System.Drawing.Point(13, 42);
            this.radioButton_WinRar.Name = "radioButton_WinRar";
            this.radioButton_WinRar.Size = new System.Drawing.Size(61, 17);
            this.radioButton_WinRar.TabIndex = 1;
            this.radioButton_WinRar.TabStop = true;
            this.radioButton_WinRar.Text = "WinRar";
            this.radioButton_WinRar.UseVisualStyleBackColor = true;
            // 
            // radioButton_7Zip
            // 
            this.radioButton_7Zip.AutoSize = true;
            this.radioButton_7Zip.Enabled = false;
            this.radioButton_7Zip.Location = new System.Drawing.Point(124, 41);
            this.radioButton_7Zip.Name = "radioButton_7Zip";
            this.radioButton_7Zip.Size = new System.Drawing.Size(49, 17);
            this.radioButton_7Zip.TabIndex = 2;
            this.radioButton_7Zip.TabStop = true;
            this.radioButton_7Zip.Text = "7-Zip";
            this.radioButton_7Zip.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(198, 64);
            this.Controls.Add(this.radioButton_7Zip);
            this.Controls.Add(this.radioButton_WinRar);
            this.Controls.Add(this.button_Create_Zpk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create *.zpk file";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Create_Zpk;
        private System.Windows.Forms.RadioButton radioButton_WinRar;
        private System.Windows.Forms.RadioButton radioButton_7Zip;
    }
}

