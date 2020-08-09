namespace Server
{
    partial class Main
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
        private void InitializaComponente()
        {
            this.components = new System.ComponentModel.Container();
            this.tabelaClientes = new System.Windows.Forms.ListView();
            this.coluna1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.coluna2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.coluna3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chatWithClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.area_txt = new System.Windows.Forms.TextBox();
            this.btEnviar = new System.Windows.Forms.Button();
            this.msgRecebidas = new System.Windows.Forms.RichTextBox();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabelaClientes
            // 
            this.tabelaClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tabelaClientes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.coluna1,
            this.coluna2,
            this.coluna3});
            this.tabelaClientes.ContextMenuStrip = this.menu;
            this.tabelaClientes.FullRowSelect = true;
            this.tabelaClientes.GridLines = true;
            this.tabelaClientes.Location = new System.Drawing.Point(179, 11);
            this.tabelaClientes.Name = "tabelaClientes";
            this.tabelaClientes.Size = new System.Drawing.Size(429, 189);
            this.tabelaClientes.TabIndex = 0;
            this.tabelaClientes.UseCompatibleStateImageBehavior = false;
            this.tabelaClientes.View = System.Windows.Forms.View.Details;
            // 
            // coluna1
            // 
            this.coluna1.Text = "Endereço IP";
            this.coluna1.Width = 140;
            // 
            // coluna2
            // 
            this.coluna2.Text = "Apelido";
            this.coluna2.Width = 138;
            // 
            // coluna3
            // 
            this.coluna3.Text = "Status";
            this.coluna3.Width = 146;
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disconnectToolStripMenuItem,
            this.chatWithClientToolStripMenuItem});
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(168, 48);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.disconnectToolStripMenuItem.Text = "Disconnect Client";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // chatWithClientToolStripMenuItem
            // 
            this.chatWithClientToolStripMenuItem.Name = "chatWithClientToolStripMenuItem";
            this.chatWithClientToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.chatWithClientToolStripMenuItem.Text = "Chat With Client";
            this.chatWithClientToolStripMenuItem.Click += new System.EventHandler(this.chatWithClientToolStripMenuItem_Click);
            // 
            // area_txt
            // 
            this.area_txt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.area_txt.Location = new System.Drawing.Point(179, 206);
            this.area_txt.Name = "area_txt";
            this.area_txt.Size = new System.Drawing.Size(348, 20);
            this.area_txt.TabIndex = 2;
            this.area_txt.Text = "Digite algo aqui";
            this.area_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.area_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyDown);
            // 
            // btEnviar
            // 
            this.btEnviar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btEnviar.Location = new System.Drawing.Point(533, 204);
            this.btEnviar.Name = "btEnviar";
            this.btEnviar.Size = new System.Drawing.Size(75, 23);
            this.btEnviar.TabIndex = 3;
            this.btEnviar.Text = "Enviar";
            this.btEnviar.UseVisualStyleBackColor = true;
            this.btEnviar.Click += new System.EventHandler(this.btEnviar_Click);
            // 
            // msgRecebidas
            // 
            this.msgRecebidas.HideSelection = false;
            this.msgRecebidas.Location = new System.Drawing.Point(12, 11);
            this.msgRecebidas.Name = "msgRecebidas";
            this.msgRecebidas.ReadOnly = true;
            this.msgRecebidas.Size = new System.Drawing.Size(161, 216);
            this.msgRecebidas.TabIndex = 4;
            this.msgRecebidas.Text = "";
            this.msgRecebidas.TextChanged += new System.EventHandler(this.txtReceive_TextChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 239);
            this.Controls.Add(this.msgRecebidas);
            this.Controls.Add(this.btEnviar);
            this.Controls.Add(this.area_txt);
            this.Controls.Add(this.tabelaClientes);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerenciador do Server";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader coluna1;
        private System.Windows.Forms.ColumnHeader coluna2;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chatWithClientToolStripMenuItem;
        private System.Windows.Forms.TextBox area_txt;
        private System.Windows.Forms.Button btEnviar;
        private System.Windows.Forms.ColumnHeader coluna3;
        private System.Windows.Forms.RichTextBox msgRecebidas;
        public System.Windows.Forms.ListView tabelaClientes;
    }
}

