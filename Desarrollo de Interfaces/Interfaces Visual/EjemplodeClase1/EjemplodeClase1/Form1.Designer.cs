namespace EjemplodeClase1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblname = new System.Windows.Forms.Label();
            this.btnReservar = new System.Windows.Forms.Button();
            this.lbl = new System.Windows.Forms.Label();
            this.lbldate = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnVer = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F);
            this.lblname.Location = new System.Drawing.Point(77, 57);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(118, 31);
            this.lblname.TabIndex = 0;
            this.lblname.Text = "Nombre:";
            this.lblname.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnReservar
            // 
            this.btnReservar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.875F);
            this.btnReservar.Location = new System.Drawing.Point(131, 188);
            this.btnReservar.Name = "btnReservar";
            this.btnReservar.Size = new System.Drawing.Size(171, 44);
            this.btnReservar.TabIndex = 1;
            this.btnReservar.Text = "Reservar";
            this.btnReservar.UseVisualStyleBackColor = true;
            this.btnReservar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F);
            this.lbl.Location = new System.Drawing.Point(77, 139);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(81, 31);
            this.lbl.TabIndex = 3;
            this.lbl.Text = "Hora:";
            // 
            // lbldate
            // 
            this.lbldate.AutoSize = true;
            this.lbldate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F);
            this.lbldate.Location = new System.Drawing.Point(77, 97);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(98, 31);
            this.lbldate.TabIndex = 4;
            this.lbldate.Text = "Fecha:";
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(201, 105);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(200, 22);
            this.datePicker.TabIndex = 5;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(202, 65);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 22);
            this.txtNombre.TabIndex = 6;
            this.txtNombre.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnVer
            // 
            this.btnVer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.875F);
            this.btnVer.Location = new System.Drawing.Point(414, 188);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(171, 44);
            this.btnVer.TabIndex = 7;
            this.btnVer.Text = "Ver";
            this.btnVer.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(131, 297);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(454, 97);
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(201, 139);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnVer);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.lbldate);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.btnReservar);
            this.Controls.Add(this.lblname);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Button btnReservar;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label lbldate;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

