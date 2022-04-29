
namespace kargoTakip
{
    partial class User
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblLat = new System.Windows.Forms.Label();
            this.lblLng = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtLat = new System.Windows.Forms.TextBox();
            this.txtLng = new System.Windows.Forms.TextBox();
            this.Table = new System.Windows.Forms.DataGridView();
            this.btnRota = new System.Windows.Forms.Button();
            this.btnYol = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblName.Location = new System.Drawing.Point(24, 12);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(66, 32);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "İSİM";
            // 
            // lblLat
            // 
            this.lblLat.AutoSize = true;
            this.lblLat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblLat.Location = new System.Drawing.Point(24, 116);
            this.lblLat.Name = "lblLat";
            this.lblLat.Size = new System.Drawing.Size(94, 32);
            this.lblLat.TabIndex = 1;
            this.lblLat.Text = "ENLEM";
            // 
            // lblLng
            // 
            this.lblLng.AutoSize = true;
            this.lblLng.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLng.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblLng.Location = new System.Drawing.Point(24, 208);
            this.lblLng.Name = "lblLng";
            this.lblLng.Size = new System.Drawing.Size(115, 32);
            this.lblLng.TabIndex = 2;
            this.lblLng.Text = "BOYLAM";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnAdd.Location = new System.Drawing.Point(24, 299);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(209, 82);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "TESLİMAT ADRESİ EKLE";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnDelete.Location = new System.Drawing.Point(24, 387);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(208, 82);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "TESLİMAT ADRESİ SİL";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(24, 47);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(209, 31);
            this.txtName.TabIndex = 6;
            // 
            // txtLat
            // 
            this.txtLat.Location = new System.Drawing.Point(24, 151);
            this.txtLat.Name = "txtLat";
            this.txtLat.Size = new System.Drawing.Size(209, 31);
            this.txtLat.TabIndex = 7;
            // 
            // txtLng
            // 
            this.txtLng.Location = new System.Drawing.Point(24, 243);
            this.txtLng.Name = "txtLng";
            this.txtLng.Size = new System.Drawing.Size(209, 31);
            this.txtLng.TabIndex = 8;
            // 
            // Table
            // 
            this.Table.AllowUserToAddRows = false;
            this.Table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Table.Location = new System.Drawing.Point(284, 12);
            this.Table.Name = "Table";
            this.Table.RowHeadersWidth = 62;
            this.Table.RowTemplate.Height = 33;
            this.Table.Size = new System.Drawing.Size(1125, 634);
            this.Table.TabIndex = 9;
            this.Table.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Select);
            // 
            // btnRota
            // 
            this.btnRota.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnRota.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRota.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnRota.Location = new System.Drawing.Point(24, 475);
            this.btnRota.Name = "btnRota";
            this.btnRota.Size = new System.Drawing.Size(208, 90);
            this.btnRota.TabIndex = 10;
            this.btnRota.Text = "KUŞ BAKIŞI";
            this.btnRota.UseVisualStyleBackColor = false;
            this.btnRota.Click += new System.EventHandler(this.btnRota_Click);
            // 
            // btnYol
            // 
            this.btnYol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnYol.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnYol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnYol.Location = new System.Drawing.Point(24, 571);
            this.btnYol.Name = "btnYol";
            this.btnYol.Size = new System.Drawing.Size(208, 90);
            this.btnYol.TabIndex = 11;
            this.btnYol.Text = "YOL TARİFİ";
            this.btnYol.UseVisualStyleBackColor = false;
            this.btnYol.Click += new System.EventHandler(this.btnYol_Click);
            // 
            // User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1448, 728);
            this.Controls.Add(this.btnYol);
            this.Controls.Add(this.btnRota);
            this.Controls.Add(this.Table);
            this.Controls.Add(this.txtLng);
            this.Controls.Add(this.txtLat);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblLng);
            this.Controls.Add(this.lblLat);
            this.Controls.Add(this.lblName);
            this.Name = "User";
            this.Text = "Teslimat Düzenleme Ekranı";
            this.Load += new System.EventHandler(this.User_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblLat;
        private System.Windows.Forms.Label lblLng;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtLat;
        private System.Windows.Forms.TextBox txtLng;
        private System.Windows.Forms.DataGridView Table;
        private System.Windows.Forms.Button btnRota;
        private System.Windows.Forms.Button btnYol;
    }
}