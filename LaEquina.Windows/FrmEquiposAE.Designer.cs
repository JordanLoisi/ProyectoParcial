namespace LaEquina.Windows
{
    partial class FrmEquiposAE
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
            this.components = new System.ComponentModel.Container();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtNombreEquipos = new System.Windows.Forms.TextBox();
            this.Equipos = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(321, 145);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 49);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(27, 145);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 49);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "OK";
            this.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtNombreEquipos
            // 
            this.txtNombreEquipos.Location = new System.Drawing.Point(80, 91);
            this.txtNombreEquipos.MaxLength = 100;
            this.txtNombreEquipos.Name = "txtNombreEquipos";
            this.txtNombreEquipos.Size = new System.Drawing.Size(300, 20);
            this.txtNombreEquipos.TabIndex = 8;
            // 
            // Equipos
            // 
            this.Equipos.AutoSize = true;
            this.Equipos.Location = new System.Drawing.Point(24, 91);
            this.Equipos.Name = "Equipos";
            this.Equipos.Size = new System.Drawing.Size(48, 13);
            this.Equipos.TabIndex = 7;
            this.Equipos.Text = "Equipos:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmEquiposAE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 329);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtNombreEquipos);
            this.Controls.Add(this.Equipos);
            this.Name = "FrmEquiposAE";
            this.Text = "FrmEquiposAE";
            this.Load += new System.EventHandler(this.FrmEquiposAE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtNombreEquipos;
        private System.Windows.Forms.Label Equipos;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}