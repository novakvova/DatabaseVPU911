
namespace BlogForm
{
    partial class FilterTestForm
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
            this.btnFilterBrand = new System.Windows.Forms.Button();
            this.btnFilterPower = new System.Windows.Forms.Button();
            this.btnClosedBrand = new System.Windows.Forms.Button();
            this.btnClosedPower = new System.Windows.Forms.Button();
            this.pnlFilterBrand = new System.Windows.Forms.Panel();
            this.pnlFilterPower = new System.Windows.Forms.Panel();
            this.btnSaveChoiceBrand = new System.Windows.Forms.Button();
            this.btnSaveChoicePower = new System.Windows.Forms.Button();
            this.btnAddFilterValue = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // btnFilterBrand
            // 
            this.btnFilterBrand.Location = new System.Drawing.Point(12, 11);
            this.btnFilterBrand.Name = "btnFilterBrand";
            this.btnFilterBrand.Size = new System.Drawing.Size(131, 38);
            this.btnFilterBrand.TabIndex = 0;
            this.btnFilterBrand.Text = "Виробник";
            this.btnFilterBrand.UseVisualStyleBackColor = true;
            this.btnFilterBrand.Click += new System.EventHandler(this.btnFilterBrand_Click);
            // 
            // btnFilterPower
            // 
            this.btnFilterPower.Location = new System.Drawing.Point(12, 198);
            this.btnFilterPower.Name = "btnFilterPower";
            this.btnFilterPower.Size = new System.Drawing.Size(131, 38);
            this.btnFilterPower.TabIndex = 1;
            this.btnFilterPower.Text = "Потужність";
            this.btnFilterPower.UseVisualStyleBackColor = true;
            this.btnFilterPower.Click += new System.EventHandler(this.btnFilterPower_Click);
            // 
            // btnClosedBrand
            // 
            this.btnClosedBrand.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClosedBrand.Location = new System.Drawing.Point(149, 12);
            this.btnClosedBrand.Name = "btnClosedBrand";
            this.btnClosedBrand.Size = new System.Drawing.Size(36, 38);
            this.btnClosedBrand.TabIndex = 2;
            this.btnClosedBrand.Text = "X";
            this.btnClosedBrand.UseVisualStyleBackColor = true;
            this.btnClosedBrand.Click += new System.EventHandler(this.btnClosedBrand_Click);
            // 
            // btnClosedPower
            // 
            this.btnClosedPower.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClosedPower.Location = new System.Drawing.Point(149, 198);
            this.btnClosedPower.Name = "btnClosedPower";
            this.btnClosedPower.Size = new System.Drawing.Size(36, 38);
            this.btnClosedPower.TabIndex = 3;
            this.btnClosedPower.Text = "X";
            this.btnClosedPower.UseVisualStyleBackColor = true;
            this.btnClosedPower.Click += new System.EventHandler(this.btnClosedPower_Click);
            // 
            // pnlFilterBrand
            // 
            this.pnlFilterBrand.BackColor = System.Drawing.Color.Transparent;
            this.pnlFilterBrand.Location = new System.Drawing.Point(12, 55);
            this.pnlFilterBrand.Name = "pnlFilterBrand";
            this.pnlFilterBrand.Size = new System.Drawing.Size(173, 100);
            this.pnlFilterBrand.TabIndex = 4;
            // 
            // pnlFilterPower
            // 
            this.pnlFilterPower.BackColor = System.Drawing.SystemColors.Control;
            this.pnlFilterPower.Location = new System.Drawing.Point(12, 242);
            this.pnlFilterPower.Name = "pnlFilterPower";
            this.pnlFilterPower.Size = new System.Drawing.Size(173, 106);
            this.pnlFilterPower.TabIndex = 5;
            // 
            // btnSaveChoiceBrand
            // 
            this.btnSaveChoiceBrand.Location = new System.Drawing.Point(12, 163);
            this.btnSaveChoiceBrand.Name = "btnSaveChoiceBrand";
            this.btnSaveChoiceBrand.Size = new System.Drawing.Size(172, 29);
            this.btnSaveChoiceBrand.TabIndex = 6;
            this.btnSaveChoiceBrand.Text = "Застосувати фільтр";
            this.btnSaveChoiceBrand.UseVisualStyleBackColor = true;
            this.btnSaveChoiceBrand.Visible = false;
            // 
            // btnSaveChoicePower
            // 
            this.btnSaveChoicePower.Location = new System.Drawing.Point(12, 354);
            this.btnSaveChoicePower.Name = "btnSaveChoicePower";
            this.btnSaveChoicePower.Size = new System.Drawing.Size(172, 29);
            this.btnSaveChoicePower.TabIndex = 6;
            this.btnSaveChoicePower.Text = "Застосувати фільтр";
            this.btnSaveChoicePower.UseVisualStyleBackColor = true;
            this.btnSaveChoicePower.Visible = false;
            // 
            // btnAddFilterValue
            // 
            this.btnAddFilterValue.Location = new System.Drawing.Point(12, 572);
            this.btnAddFilterValue.Name = "btnAddFilterValue";
            this.btnAddFilterValue.Size = new System.Drawing.Size(173, 37);
            this.btnAddFilterValue.TabIndex = 7;
            this.btnAddFilterValue.Text = "Додати параметр в фільтр";
            this.btnAddFilterValue.UseVisualStyleBackColor = true;
            this.btnAddFilterValue.Click += new System.EventHandler(this.btnAddFilterValue_Click);
            // 
            // FilterTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 621);
            this.Controls.Add(this.btnAddFilterValue);
            this.Controls.Add(this.btnSaveChoicePower);
            this.Controls.Add(this.btnSaveChoiceBrand);
            this.Controls.Add(this.pnlFilterPower);
            this.Controls.Add(this.pnlFilterBrand);
            this.Controls.Add(this.btnClosedPower);
            this.Controls.Add(this.btnFilterBrand);
            this.Controls.Add(this.btnFilterPower);
            this.Controls.Add(this.btnClosedBrand);
            this.Name = "FilterTestForm";
            this.Text = "FilterTestForm";
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button btnFilterBrand;
        private System.Windows.Forms.Button btnFilterPower;
        private System.Windows.Forms.Button btnClosedBrand;
        private System.Windows.Forms.Button btnClosedPower;
        private System.Windows.Forms.Panel pnlFilterBrand;
        private System.Windows.Forms.Panel pnlFilterPower;
        private System.Windows.Forms.Button btnSaveChoiceBrand;
        private System.Windows.Forms.Button btnSaveChoicePower;
        private System.Windows.Forms.Button btnAddFilterValue;

        #endregion
    }
}