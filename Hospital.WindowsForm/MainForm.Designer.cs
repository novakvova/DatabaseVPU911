
namespace Hospital.WindowsForm
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.btnShowProfile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(922, 460);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 63);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColName,
            this.ColStage,
            this.ColDepartment});
            this.dataGridView1.Location = new System.Drawing.Point(344, 143);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(760, 286);
            this.dataGridView1.TabIndex = 1;
            // 
            // ColName
            // 
            this.ColName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColName.HeaderText = "Ім\'я";
            this.ColName.MinimumWidth = 6;
            this.ColName.Name = "ColName";
            // 
            // ColStage
            // 
            this.ColStage.HeaderText = "Стаж";
            this.ColStage.MinimumWidth = 6;
            this.ColStage.Name = "ColStage";
            this.ColStage.Width = 200;
            // 
            // ColDepartment
            // 
            this.ColDepartment.HeaderText = "Відділ";
            this.ColDepartment.MinimumWidth = 6;
            this.ColDepartment.Name = "ColDepartment";
            this.ColDepartment.Width = 200;
            // 
            // pbImage
            // 
            this.pbImage.Location = new System.Drawing.Point(41, 70);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(211, 211);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImage.TabIndex = 2;
            this.pbImage.TabStop = false;
            // 
            // btnShowProfile
            // 
            this.btnShowProfile.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnShowProfile.ForeColor = System.Drawing.Color.Blue;
            this.btnShowProfile.Location = new System.Drawing.Point(41, 472);
            this.btnShowProfile.Name = "btnShowProfile";
            this.btnShowProfile.Size = new System.Drawing.Size(173, 51);
            this.btnShowProfile.TabIndex = 3;
            this.btnShowProfile.Text = "Профіль";
            this.btnShowProfile.UseVisualStyleBackColor = true;
            this.btnShowProfile.Click += new System.EventHandler(this.btnShowProfile_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 563);
            this.Controls.Add(this.btnShowProfile);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDepartment;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Button btnShowProfile;
    }
}

