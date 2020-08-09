namespace Server
{
    partial class Chat_privado
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
            this.btEnviar = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.msgRecebidas = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btEnviar
            // 
            this.btEnviar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEnviar.Location = new System.Drawing.Point(309, 299);
            this.btEnviar.Name = "btEnviar";
            this.btEnviar.Size = new System.Drawing.Size(91, 44);
            this.btEnviar.TabIndex = 6;
            this.btEnviar.Text = "Enviar";
            this.btEnviar.UseVisualStyleBackColor = true;
            this.btEnviar.Click += new System.EventHandler(this.btEnviar_Click);
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.Location = new System.Drawing.Point(17, 299);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(286, 44);
            this.txtInput.TabIndex = 5;
            this.txtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyDown);
            // 
            // msgRecebidas
            // 
            this.msgRecebidas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.msgRecebidas.BackColor = System.Drawing.Color.White;
            this.msgRecebidas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.msgRecebidas.HideSelection = false;
            this.msgRecebidas.Location = new System.Drawing.Point(17, 12);
            this.msgRecebidas.Name = "msgRecebidas";
            this.msgRecebidas.ReadOnly = true;
            this.msgRecebidas.Size = new System.Drawing.Size(383, 279);
            this.msgRecebidas.TabIndex = 4;
            this.msgRecebidas.Text = "";
            this.msgRecebidas.TextChanged += new System.EventHandler(this.txtRecebido_Mudatexto);
            // 
            // Chat_privado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 354);
            this.Controls.Add(this.btEnviar);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.msgRecebidas);
            this.Name = "Chat_privado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chat Privado";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btEnviar;
        private System.Windows.Forms.TextBox txtInput;
        public System.Windows.Forms.RichTextBox msgRecebidas;
    }
}