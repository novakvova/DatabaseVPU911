
namespace BlogForm
{
    partial class AddValueForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblGetName = new System.Windows.Forms.Label();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.tbValue = new System.Windows.Forms.TextBox();
            this.btnAddParameter = new System.Windows.Forms.Button();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(12, 21);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(248, 42);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Виберіть фільтр, до якого\r\nбажаєте додати новий параметр:";
            // 
            // lblGetName
            // 
            this.lblGetName.AutoSize = true;
            this.lblGetName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblGetName.Location = new System.Drawing.Point(12, 126);
            this.lblGetName.Name = "lblGetName";
            this.lblGetName.Size = new System.Drawing.Size(191, 21);
            this.lblGetName.TabIndex = 0;
            this.lblGetName.Text = "Введіть назву параметра:";
            // 
            // cbFilter
            // 
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Location = new System.Drawing.Point(16, 74);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(281, 23);
            this.cbFilter.TabIndex = 1;
            // 
            // tbValue
            // 
            this.tbValue.Location = new System.Drawing.Point(16, 160);
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(280, 23);
            this.tbValue.TabIndex = 2;
            // 
            // btnAddParameter
            // 
            this.btnAddParameter.Location = new System.Drawing.Point(16, 214);
            this.btnAddParameter.Name = "btnAddParameter";
            this.btnAddParameter.Size = new System.Drawing.Size(280, 53);
            this.btnAddParameter.TabIndex = 3;
            this.btnAddParameter.Text = "Додати параметр";
            this.btnAddParameter.UseVisualStyleBackColor = true;
            this.btnAddParameter.Click += new System.EventHandler(this.btnAddParameter_Click);
            // 
            // AddValueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 283);
            this.Controls.Add(this.btnAddParameter);
            this.Controls.Add(this.tbValue);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.lblGetName);
            this.Controls.Add(this.lblTitle);
            this.Name = "AddValueForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Додати новий параметр в фільтр";
        }

        #endregion
        
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblGetName;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.TextBox tbValue;
        private System.Windows.Forms.Button btnAddParameter;
    }
}