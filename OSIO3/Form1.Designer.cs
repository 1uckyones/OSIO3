namespace OSIO3
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
            this.button_file = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_file
            // 
            this.button_file.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.button_file.Location = new System.Drawing.Point(32, 66);
            this.button_file.Name = "button_file";
            this.button_file.Size = new System.Drawing.Size(163, 76);
            this.button_file.TabIndex = 1;
            this.button_file.Text = "Данные о файле";
            this.button_file.UseVisualStyleBackColor = true;
            this.button_file.Click += new System.EventHandler(this.button_file_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.button3.Location = new System.Drawing.Point(318, 41);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(171, 101);
            this.button3.TabIndex = 3;
            this.button3.Text = "Запуск интерпретатора";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 267);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button_file);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_file;
        private System.Windows.Forms.Button button3;
    }
}

