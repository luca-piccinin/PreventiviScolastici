using System.Windows.Forms;

namespace PreventiviScolastici
{
    partial class AddView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddView));
            this.sceltaProdotti = new System.Windows.Forms.DataGridView();
            this.aggiungi = new System.Windows.Forms.DataGridViewButtonColumn();
            this.codice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.immagine = new System.Windows.Forms.DataGridViewImageColumn();
            this.descrizione = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.larghezza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.altezza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profondita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dimensioni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prezzoListino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prezzoMelanimici = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prezzoPuntali = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prezzoRuote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prezzoTerminali = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.boccolaPassaCavi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.magicTop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.presaCirc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.multipresa2x3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.multipresa3x3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txbxRicerca = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sceltaProdotti)).BeginInit();
            this.SuspendLayout();
            // 
            // sceltaProdotti
            // 
            this.sceltaProdotti.AllowUserToAddRows = false;
            this.sceltaProdotti.AllowUserToDeleteRows = false;
            this.sceltaProdotti.AllowUserToOrderColumns = true;
            this.sceltaProdotti.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.sceltaProdotti.BackgroundColor = System.Drawing.SystemColors.Control;
            this.sceltaProdotti.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sceltaProdotti.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.sceltaProdotti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sceltaProdotti.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.aggiungi,
            this.codice,
            this.immagine,
            this.descrizione,
            this.larghezza,
            this.altezza,
            this.profondita,
            this.dimensioni,
            this.prezzoListino,
            this.prezzoMelanimici,
            this.prezzoPuntali,
            this.prezzoRuote,
            this.prezzoTerminali,
            this.boccolaPassaCavi,
            this.magicTop,
            this.presaCirc,
            this.multipresa2x3,
            this.multipresa3x3});
            this.sceltaProdotti.Location = new System.Drawing.Point(12, 64);
            this.sceltaProdotti.Name = "sceltaProdotti";
            this.sceltaProdotti.ReadOnly = true;
            this.sceltaProdotti.RowHeadersVisible = false;
            this.sceltaProdotti.RowHeadersWidth = 50;
            this.sceltaProdotti.RowTemplate.Height = 24;
            this.sceltaProdotti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.sceltaProdotti.Size = new System.Drawing.Size(1878, 957);
            this.sceltaProdotti.TabIndex = 3;
            // 
            // aggiungi
            // 
            this.aggiungi.HeaderText = "";
            this.aggiungi.MinimumWidth = 75;
            this.aggiungi.Name = "aggiungi";
            this.aggiungi.ReadOnly = true;
            this.aggiungi.Text = "AGGIUNGI";
            this.aggiungi.UseColumnTextForButtonValue = true;
            this.aggiungi.Width = 75;
            // 
            // codice
            // 
            this.codice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.codice.HeaderText = "CODICE";
            this.codice.MinimumWidth = 6;
            this.codice.Name = "codice";
            this.codice.ReadOnly = true;
            this.codice.Width = 6;
            // 
            // immagine
            // 
            this.immagine.HeaderText = "IMMAGINE";
            this.immagine.MinimumWidth = 100;
            this.immagine.Name = "immagine";
            this.immagine.ReadOnly = true;
            this.immagine.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // descrizione
            // 
            this.descrizione.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.descrizione.HeaderText = "DESCRIZIONE";
            this.descrizione.MinimumWidth = 6;
            this.descrizione.Name = "descrizione";
            this.descrizione.ReadOnly = true;
            this.descrizione.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.descrizione.Width = 125;
            // 
            // larghezza
            // 
            this.larghezza.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.larghezza.HeaderText = "LARGHEZZA";
            this.larghezza.MinimumWidth = 6;
            this.larghezza.Name = "larghezza";
            this.larghezza.ReadOnly = true;
            this.larghezza.Width = 121;
            // 
            // altezza
            // 
            this.altezza.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.altezza.HeaderText = "ALTEZZA";
            this.altezza.MinimumWidth = 6;
            this.altezza.Name = "altezza";
            this.altezza.ReadOnly = true;
            this.altezza.Width = 99;
            // 
            // profondita
            // 
            this.profondita.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.profondita.HeaderText = "PROFONDITA\'";
            this.profondita.MinimumWidth = 6;
            this.profondita.Name = "profondita";
            this.profondita.ReadOnly = true;
            this.profondita.Width = 130;
            // 
            // dimensioni
            // 
            this.dimensioni.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dimensioni.HeaderText = "DIMENSIONI";
            this.dimensioni.MinimumWidth = 6;
            this.dimensioni.Name = "dimensioni";
            this.dimensioni.ReadOnly = true;
            this.dimensioni.Width = 116;
            // 
            // prezzoListino
            // 
            this.prezzoListino.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = "ND";
            this.prezzoListino.DefaultCellStyle = dataGridViewCellStyle2;
            this.prezzoListino.HeaderText = "PREZZO UNITARIO";
            this.prezzoListino.MinimumWidth = 6;
            this.prezzoListino.Name = "prezzoListino";
            this.prezzoListino.ReadOnly = true;
            this.prezzoListino.Width = 149;
            // 
            // prezzoMelanimici
            // 
            this.prezzoMelanimici.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = "ND";
            this.prezzoMelanimici.DefaultCellStyle = dataGridViewCellStyle3;
            this.prezzoMelanimici.HeaderText = "MELAMINICI COLORATI";
            this.prezzoMelanimici.MinimumWidth = 6;
            this.prezzoMelanimici.Name = "prezzoMelanimici";
            this.prezzoMelanimici.ReadOnly = true;
            this.prezzoMelanimici.Width = 171;
            // 
            // prezzoPuntali
            // 
            this.prezzoPuntali.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = "ND";
            this.prezzoPuntali.DefaultCellStyle = dataGridViewCellStyle4;
            this.prezzoPuntali.HeaderText = "PUNTALI CON PIEDINI LIVELLATORI";
            this.prezzoPuntali.MinimumWidth = 6;
            this.prezzoPuntali.Name = "prezzoPuntali";
            this.prezzoPuntali.ReadOnly = true;
            this.prezzoPuntali.Width = 246;
            // 
            // prezzoRuote
            // 
            this.prezzoRuote.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = "ND";
            this.prezzoRuote.DefaultCellStyle = dataGridViewCellStyle5;
            this.prezzoRuote.HeaderText = "RUOTE A RULLO CON TAPPI BLOCC. SCORRIMENTO";
            this.prezzoRuote.MinimumWidth = 6;
            this.prezzoRuote.Name = "prezzoRuote";
            this.prezzoRuote.ReadOnly = true;
            this.prezzoRuote.Width = 259;
            // 
            // prezzoTerminali
            // 
            this.prezzoTerminali.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.NullValue = "ND";
            this.prezzoTerminali.DefaultCellStyle = dataGridViewCellStyle6;
            this.prezzoTerminali.HeaderText = "TERMINALI A VITE PER REGOLAZ. H. DI 200 MM";
            this.prezzoTerminali.MinimumWidth = 6;
            this.prezzoTerminali.Name = "prezzoTerminali";
            this.prezzoTerminali.ReadOnly = true;
            this.prezzoTerminali.Width = 243;
            // 
            // boccolaPassaCavi
            // 
            this.boccolaPassaCavi.HeaderText = "BOCCOLA PASSA CAVI D.60";
            this.boccolaPassaCavi.MinimumWidth = 6;
            this.boccolaPassaCavi.Name = "boccolaPassaCavi";
            this.boccolaPassaCavi.ReadOnly = true;
            this.boccolaPassaCavi.Width = 173;
            // 
            // magicTop
            // 
            this.magicTop.HeaderText = "MAGIC TOP L.300";
            this.magicTop.MinimumWidth = 6;
            this.magicTop.Name = "magicTop";
            this.magicTop.ReadOnly = true;
            this.magicTop.Width = 108;
            // 
            // presaCirc
            // 
            this.presaCirc.HeaderText = "PRESA CIRC D.60";
            this.presaCirc.MinimumWidth = 6;
            this.presaCirc.Name = "presaCirc";
            this.presaCirc.ReadOnly = true;
            this.presaCirc.Width = 112;
            // 
            // multipresa2x3
            // 
            this.multipresa2x3.HeaderText = "MULTI PRESA RETT. 2 UNEL 3 USB 5V A+C";
            this.multipresa2x3.MinimumWidth = 6;
            this.multipresa2x3.Name = "multipresa2x3";
            this.multipresa2x3.ReadOnly = true;
            this.multipresa2x3.Width = 220;
            // 
            // multipresa3x3
            // 
            this.multipresa3x3.HeaderText = "MULTI PRESA RETT. 3 UNEL 3 USB 5V A+C";
            this.multipresa3x3.MinimumWidth = 6;
            this.multipresa3x3.Name = "multipresa3x3";
            this.multipresa3x3.ReadOnly = true;
            this.multipresa3x3.Width = 220;
            // 
            // txbxRicerca
            // 
            this.txbxRicerca.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbxRicerca.Location = new System.Drawing.Point(363, 14);
            this.txbxRicerca.Name = "txbxRicerca";
            this.txbxRicerca.Size = new System.Drawing.Size(209, 34);
            this.txbxRicerca.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "Inserisci codice per la ricerca";
            // 
            // AddView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbxRicerca);
            this.Controls.Add(this.sceltaProdotti);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddView";
            this.Text = "Listino";
            this.Load += new System.EventHandler(this.AddView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sceltaProdotti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView sceltaProdotti;
        private System.Windows.Forms.TextBox txbxRicerca;
        private System.Windows.Forms.Label label1;
        private DataGridViewButtonColumn aggiungi;
        private DataGridViewTextBoxColumn codice;
        private DataGridViewImageColumn immagine;
        private DataGridViewTextBoxColumn descrizione;
        private DataGridViewTextBoxColumn larghezza;
        private DataGridViewTextBoxColumn altezza;
        private DataGridViewTextBoxColumn profondita;
        private DataGridViewTextBoxColumn dimensioni;
        private DataGridViewTextBoxColumn prezzoListino;
        private DataGridViewTextBoxColumn prezzoMelanimici;
        private DataGridViewTextBoxColumn prezzoPuntali;
        private DataGridViewTextBoxColumn prezzoRuote;
        private DataGridViewTextBoxColumn prezzoTerminali;
        private DataGridViewTextBoxColumn boccolaPassaCavi;
        private DataGridViewTextBoxColumn magicTop;
        private DataGridViewTextBoxColumn presaCirc;
        private DataGridViewTextBoxColumn multipresa2x3;
        private DataGridViewTextBoxColumn multipresa3x3;
    }
}