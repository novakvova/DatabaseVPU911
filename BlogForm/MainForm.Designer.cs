
namespace BlogForm
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
            this.dgvPosts = new System.Windows.Forms.DataGridView();
            this.btnEdit = new System.Windows.Forms.Button();
            this.ColId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCategory = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPosts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPosts
            // 
            this.dgvPosts.AllowUserToAddRows = false;
            this.dgvPosts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPosts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColId,
            this.ColText,
            this.ColCategory});
            this.dgvPosts.Location = new System.Drawing.Point(32, 135);
            this.dgvPosts.Name = "dgvPosts";
            this.dgvPosts.RowTemplate.Height = 25;
            this.dgvPosts.Size = new System.Drawing.Size(697, 274);
            this.dgvPosts.TabIndex = 0;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(32, 454);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(116, 41);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Редагувати";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // ColId
            // 
            this.ColId.HeaderText = "Id";
            this.ColId.Name = "ColId";
            this.ColId.Visible = false;
            // 
            // ColText
            // 
            this.ColText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColText.HeaderText = "Назва";
            this.ColText.Name = "ColText";
            // 
            // ColCategory
            // 
            this.ColCategory.HeaderText = "Категорія";
            this.ColCategory.Name = "ColCategory";
            this.ColCategory.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColCategory.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 557);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.dgvPosts);
            this.Name = "MainForm";
            this.Text = "Привіт козак";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPosts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPosts;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColText;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColCategory;
    }
}

