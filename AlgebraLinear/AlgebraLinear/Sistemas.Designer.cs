namespace AlgebraLinear
{
    partial class Sistemas
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
            this.button1 = new System.Windows.Forms.Button();
            this.variaveis = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxSistema = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.equacoes = new System.Windows.Forms.TextBox();
            this.gerarSistema = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.Gainsboro;
            this.button1.Location = new System.Drawing.Point(956, 541);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Fechar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // variaveis
            // 
            this.variaveis.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.variaveis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.variaveis.Location = new System.Drawing.Point(298, 21);
            this.variaveis.Multiline = true;
            this.variaveis.Name = "variaveis";
            this.variaveis.Size = new System.Drawing.Size(52, 28);
            this.variaveis.TabIndex = 7;
            this.variaveis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "Quantidade de variáveis";
            // 
            // groupBoxSistema
            // 
            this.groupBoxSistema.BackColor = System.Drawing.Color.LightGray;
            this.groupBoxSistema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxSistema.Location = new System.Drawing.Point(66, 133);
            this.groupBoxSistema.Name = "groupBoxSistema";
            this.groupBoxSistema.Size = new System.Drawing.Size(828, 213);
            this.groupBoxSistema.TabIndex = 9;
            this.groupBoxSistema.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Gainsboro;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(62, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 24);
            this.label2.TabIndex = 10;
            this.label2.Text = "Quantidade de equações";
            // 
            // equacoes
            // 
            this.equacoes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.equacoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.equacoes.Location = new System.Drawing.Point(298, 72);
            this.equacoes.Multiline = true;
            this.equacoes.Name = "equacoes";
            this.equacoes.Size = new System.Drawing.Size(52, 28);
            this.equacoes.TabIndex = 11;
            this.equacoes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gerarSistema
            // 
            this.gerarSistema.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.gerarSistema.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gerarSistema.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gerarSistema.ForeColor = System.Drawing.Color.Gainsboro;
            this.gerarSistema.Location = new System.Drawing.Point(371, 21);
            this.gerarSistema.Name = "gerarSistema";
            this.gerarSistema.Size = new System.Drawing.Size(91, 79);
            this.gerarSistema.TabIndex = 12;
            this.gerarSistema.Text = "Gerar";
            this.gerarSistema.UseVisualStyleBackColor = false;
            this.gerarSistema.Click += new System.EventHandler(this.gerarSistema_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightGray;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(620, 381);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 190);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Gainsboro;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(707, 358);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 29);
            this.label3.TabIndex = 14;
            this.label3.Text = "Resultado";
            // 
            // Sistemas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1074, 591);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gerarSistema);
            this.Controls.Add(this.equacoes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBoxSistema);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.variaveis);
            this.Controls.Add(this.button1);
            this.Name = "Sistemas";
            this.Text = "Sistemas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox variaveis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxSistema;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox equacoes;
        private System.Windows.Forms.Button gerarSistema;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
    }
}