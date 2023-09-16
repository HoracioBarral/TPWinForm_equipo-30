namespace WindowsFormsApp
{
    partial class Administracion
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
            this.saludo = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnListaArticulo = new System.Windows.Forms.Button();
            this.btnBusquedaArticulo = new System.Windows.Forms.Button();
            this.btnAgregarArticulo = new System.Windows.Forms.Button();
            this.btnDetalleArticulo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // saludo
            // 
            this.saludo.AutoSize = true;
            this.saludo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saludo.Location = new System.Drawing.Point(48, 40);
            this.saludo.Name = "saludo";
            this.saludo.Size = new System.Drawing.Size(183, 31);
            this.saludo.TabIndex = 0;
            this.saludo.Text = "Bienvenido , ";
            this.saludo.Click += new System.EventHandler(this.Administracion_load);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(706, 404);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(86, 45);
            this.btnVolver.TabIndex = 1;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnListaArticulo
            // 
            this.btnListaArticulo.BackColor = System.Drawing.Color.Silver;
            this.btnListaArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListaArticulo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnListaArticulo.Location = new System.Drawing.Point(316, 119);
            this.btnListaArticulo.Name = "btnListaArticulo";
            this.btnListaArticulo.Size = new System.Drawing.Size(130, 43);
            this.btnListaArticulo.TabIndex = 2;
            this.btnListaArticulo.Text = "Listado de articulos";
            this.btnListaArticulo.UseVisualStyleBackColor = false;
            this.btnListaArticulo.Click += new System.EventHandler(this.btnListaArticulo_Click);
            // 
            // btnBusquedaArticulo
            // 
            this.btnBusquedaArticulo.BackColor = System.Drawing.Color.Silver;
            this.btnBusquedaArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBusquedaArticulo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBusquedaArticulo.Location = new System.Drawing.Point(316, 180);
            this.btnBusquedaArticulo.Name = "btnBusquedaArticulo";
            this.btnBusquedaArticulo.Size = new System.Drawing.Size(130, 40);
            this.btnBusquedaArticulo.TabIndex = 3;
            this.btnBusquedaArticulo.Text = "Busqueda de articulos";
            this.btnBusquedaArticulo.UseVisualStyleBackColor = false;
            // 
            // btnAgregarArticulo
            // 
            this.btnAgregarArticulo.BackColor = System.Drawing.Color.Silver;
            this.btnAgregarArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarArticulo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAgregarArticulo.Location = new System.Drawing.Point(316, 248);
            this.btnAgregarArticulo.Name = "btnAgregarArticulo";
            this.btnAgregarArticulo.Size = new System.Drawing.Size(130, 36);
            this.btnAgregarArticulo.TabIndex = 4;
            this.btnAgregarArticulo.Text = "Agregar articulo";
            this.btnAgregarArticulo.UseVisualStyleBackColor = false;
            this.btnAgregarArticulo.Click += new System.EventHandler(this.btnAgregarArticulo_Click);
            // 
            // btnDetalleArticulo
            // 
            this.btnDetalleArticulo.BackColor = System.Drawing.Color.Silver;
            this.btnDetalleArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalleArticulo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDetalleArticulo.Location = new System.Drawing.Point(316, 307);
            this.btnDetalleArticulo.Name = "btnDetalleArticulo";
            this.btnDetalleArticulo.Size = new System.Drawing.Size(130, 45);
            this.btnDetalleArticulo.TabIndex = 7;
            this.btnDetalleArticulo.Text = "Detalle de articulo";
            this.btnDetalleArticulo.UseVisualStyleBackColor = false;
            // 
            // Administracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Peru;
            this.ClientSize = new System.Drawing.Size(804, 481);
            this.Controls.Add(this.btnDetalleArticulo);
            this.Controls.Add(this.btnAgregarArticulo);
            this.Controls.Add(this.btnBusquedaArticulo);
            this.Controls.Add(this.btnListaArticulo);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.saludo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Administracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administracion";
            this.Load += new System.EventHandler(this.Administracion_load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label saludo;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnListaArticulo;
        private System.Windows.Forms.Button btnBusquedaArticulo;
        private System.Windows.Forms.Button btnAgregarArticulo;
        private System.Windows.Forms.Button btnDetalleArticulo;
    }
}