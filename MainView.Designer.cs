using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace PreventiviScolastici
{
    partial class MainView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txbxDatiAzienda = new System.Windows.Forms.RichTextBox();
            this.prodottiAggiunti = new System.Windows.Forms.DataGridView();
            this.lblAusiliare = new System.Windows.Forms.Label();
            this.addProduct = new System.Windows.Forms.Button();
            this.lblData = new System.Windows.Forms.Label();
            this.txtLuogo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPrezzoNetto = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtMontaggio = new System.Windows.Forms.TextBox();
            this.txtTempi = new System.Windows.Forms.TextBox();
            this.txtIva = new System.Windows.Forms.TextBox();
            this.txtValidita = new System.Windows.Forms.TextBox();
            this.txtPagamento = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnPdf = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSconto = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbsSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tbsLoad = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEsportaExcel = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtScontoSecondario = new System.Windows.Forms.TextBox();
            this.btnExtraSconto = new System.Windows.Forms.Button();
            this.elimina = new System.Windows.Forms.DataGridViewButtonColumn();
            this.codice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.immagine = new System.Windows.Forms.DataGridViewImageColumn();
            this.descrizione = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dimensioni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prezzoListino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prezzoTotale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prezzoUnitarioScontato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prezzoTotaleScontato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantitaMelanimici = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.prezzoMelanimici = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantitaPuntali = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.prezzoPuntali = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantitaRuote = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.prezzoRuote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantitaTerminali = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.prezzoTerminali = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantitaBoccola = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.prezzoBoccola = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantitaTop = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.prezzoTop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantitaPresa = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.prezzoPresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantitaMulti2x3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.prezzoMulti2x3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantitaMulti3x3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.prezzoMulti3x3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.prodottiAggiunti)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txbxDatiAzienda
            // 
            this.txbxDatiAzienda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbxDatiAzienda.Location = new System.Drawing.Point(12, 28);
            this.txbxDatiAzienda.Name = "txbxDatiAzienda";
            this.txbxDatiAzienda.Size = new System.Drawing.Size(606, 211);
            this.txbxDatiAzienda.TabIndex = 2;
            this.txbxDatiAzienda.Text = "";
            // 
            // prodottiAggiunti
            // 
            this.prodottiAggiunti.AllowUserToAddRows = false;
            this.prodottiAggiunti.AllowUserToDeleteRows = false;
            this.prodottiAggiunti.AllowUserToOrderColumns = true;
            this.prodottiAggiunti.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.prodottiAggiunti.BackgroundColor = System.Drawing.SystemColors.Control;
            this.prodottiAggiunti.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.prodottiAggiunti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.prodottiAggiunti.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.elimina,
            this.codice,
            this.immagine,
            this.descrizione,
            this.dimensioni,
            this.quantita,
            this.prezzoListino,
            this.prezzoTotale,
            this.prezzoUnitarioScontato,
            this.prezzoTotaleScontato,
            this.quantitaMelanimici,
            this.prezzoMelanimici,
            this.quantitaPuntali,
            this.prezzoPuntali,
            this.quantitaRuote,
            this.prezzoRuote,
            this.quantitaTerminali,
            this.prezzoTerminali,
            this.quantitaBoccola,
            this.prezzoBoccola,
            this.quantitaTop,
            this.prezzoTop,
            this.quantitaPresa,
            this.prezzoPresa,
            this.quantitaMulti2x3,
            this.prezzoMulti2x3,
            this.quantitaMulti3x3,
            this.prezzoMulti3x3});
            this.prodottiAggiunti.Location = new System.Drawing.Point(12, 245);
            this.prodottiAggiunti.MinimumSize = new System.Drawing.Size(1500, 520);
            this.prodottiAggiunti.Name = "prodottiAggiunti";
            this.prodottiAggiunti.RowHeadersVisible = false;
            this.prodottiAggiunti.RowHeadersWidth = 51;
            this.prodottiAggiunti.RowTemplate.Height = 24;
            this.prodottiAggiunti.Size = new System.Drawing.Size(1878, 526);
            this.prodottiAggiunti.TabIndex = 3;
            // 
            // lblAusiliare
            // 
            this.lblAusiliare.AutoSize = true;
            this.lblAusiliare.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAusiliare.Location = new System.Drawing.Point(643, 28);
            this.lblAusiliare.Name = "lblAusiliare";
            this.lblAusiliare.Size = new System.Drawing.Size(514, 60);
            this.lblAusiliare.TabIndex = 1;
            this.lblAusiliare.Text = "Gentile Cliente, \r\nfacendo seguito a Vostra gradita richiesta, sottoponiamo alla " +
    "Vostra\r\nattenzione la nostra migliore quotazione per gli articoli richiesti.";
            // 
            // addProduct
            // 
            this.addProduct.Location = new System.Drawing.Point(647, 179);
            this.addProduct.Name = "addProduct";
            this.addProduct.Size = new System.Drawing.Size(211, 60);
            this.addProduct.TabIndex = 4;
            this.addProduct.Text = "AGGIUNGI UN PRODOTTO";
            this.addProduct.UseVisualStyleBackColor = true;
            this.addProduct.Click += new System.EventHandler(this.addProduct_Click);
            // 
            // lblData
            // 
            this.lblData.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblData.AutoSize = true;
            this.lblData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblData.Location = new System.Drawing.Point(132, 6);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(53, 20);
            this.lblData.TabIndex = 5;
            this.lblData.Text = "label2";
            // 
            // txtLuogo
            // 
            this.txtLuogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtLuogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLuogo.Location = new System.Drawing.Point(3, 3);
            this.txtLuogo.Name = "txtLuogo";
            this.txtLuogo.Size = new System.Drawing.Size(100, 27);
            this.txtLuogo.TabIndex = 6;
            this.txtLuogo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 40);
            this.label2.TabIndex = 7;
            this.label2.Text = "PREZZO NETTO\r\nTOTALE";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPrezzoNetto
            // 
            this.lblPrezzoNetto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPrezzoNetto.AutoSize = true;
            this.lblPrezzoNetto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrezzoNetto.Location = new System.Drawing.Point(178, 7);
            this.lblPrezzoNetto.Name = "lblPrezzoNetto";
            this.lblPrezzoNetto.Size = new System.Drawing.Size(66, 25);
            this.lblPrezzoNetto.TabIndex = 8;
            this.lblPrezzoNetto.Text = "0.00 €";
            this.lblPrezzoNetto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.txtLuogo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblData, 1, 0);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 777);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(212, 33);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblPrezzoNetto, 1, 0);
            this.tableLayoutPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(427, 774);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(282, 40);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(338, 32);
            this.label3.TabIndex = 0;
            this.label3.Text = "CONDIZIONI DI VENDITA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "PAGAMENTO:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "VALIDITA\':";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "IVA:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(5, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(186, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "TEMPI DI CONSEGNA:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(5, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(567, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "TRASPORTO COMPRESO PER ORDINI SUPERIORI AD € 2.000,00 + IVA";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 181);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "MONTAGGIO:";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.txtMontaggio);
            this.panel1.Controls.Add(this.txtTempi);
            this.panel1.Controls.Add(this.txtIva);
            this.panel1.Controls.Add(this.txtValidita);
            this.panel1.Controls.Add(this.txtPagamento);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(12, 820);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 206);
            this.panel1.TabIndex = 12;
            // 
            // txtMontaggio
            // 
            this.txtMontaggio.Location = new System.Drawing.Point(131, 181);
            this.txtMontaggio.Name = "txtMontaggio";
            this.txtMontaggio.Size = new System.Drawing.Size(400, 22);
            this.txtMontaggio.TabIndex = 5;
            // 
            // txtTempi
            // 
            this.txtTempi.Location = new System.Drawing.Point(197, 125);
            this.txtTempi.Name = "txtTempi";
            this.txtTempi.Size = new System.Drawing.Size(400, 22);
            this.txtTempi.TabIndex = 4;
            // 
            // txtIva
            // 
            this.txtIva.Location = new System.Drawing.Point(51, 97);
            this.txtIva.Name = "txtIva";
            this.txtIva.Size = new System.Drawing.Size(400, 22);
            this.txtIva.TabIndex = 3;
            // 
            // txtValidita
            // 
            this.txtValidita.Location = new System.Drawing.Point(103, 69);
            this.txtValidita.Name = "txtValidita";
            this.txtValidita.Size = new System.Drawing.Size(400, 22);
            this.txtValidita.TabIndex = 2;
            // 
            // txtPagamento
            // 
            this.txtPagamento.Location = new System.Drawing.Point(131, 41);
            this.txtPagamento.Name = "txtPagamento";
            this.txtPagamento.Size = new System.Drawing.Size(400, 22);
            this.txtPagamento.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(721, 820);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(564, 100);
            this.label10.TabIndex = 13;
            this.label10.Text = "SERVIZI DISPONIBILI SU RICHIESTA NON COMPRESI NELL\'OFFERTA:\r\n- Consegna in ZTL\r\n-" +
    " Consegna in luoghi disagiati\r\n- Ritiro arredi usati esistenti\r\n- Fissaggio a pa" +
    "rete";
            // 
            // btnPdf
            // 
            this.btnPdf.Location = new System.Drawing.Point(892, 179);
            this.btnPdf.Name = "btnPdf";
            this.btnPdf.Size = new System.Drawing.Size(211, 60);
            this.btnPdf.TabIndex = 14;
            this.btnPdf.Text = "ESPORTA";
            this.btnPdf.UseVisualStyleBackColor = true;
            this.btnPdf.Click += new System.EventHandler(this.btnPdf_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtSconto, 1, 0);
            this.tableLayoutPanel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel3.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(1386, 193);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(212, 33);
            this.tableLayoutPanel3.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(13, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 20);
            this.label11.TabIndex = 7;
            this.label11.Text = "SCONTO";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSconto
            // 
            this.txtSconto.Location = new System.Drawing.Point(109, 3);
            this.txtSconto.Name = "txtSconto";
            this.txtSconto.Size = new System.Drawing.Size(100, 27);
            this.txtSconto.TabIndex = 8;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.tsbNew,
            this.toolStripSeparator2,
            this.tbsSave,
            this.toolStripSeparator3,
            this.tbsLoad,
            this.toolStripSeparator4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1902, 30);
            this.toolStrip1.TabIndex = 16;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // tsbNew
            // 
            this.tsbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbNew.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbNew.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tsbNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbNew.Image")));
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(48, 27);
            this.tsbNew.Text = "New";
            this.tsbNew.Click += new System.EventHandler(this.tsbNew_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 30);
            // 
            // tbsSave
            // 
            this.tbsSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbsSave.Image = ((System.Drawing.Image)(resources.GetObject("tbsSave.Image")));
            this.tbsSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbsSave.Name = "tbsSave";
            this.tbsSave.Size = new System.Drawing.Size(44, 27);
            this.tbsSave.Text = "Save";
            this.tbsSave.Click += new System.EventHandler(this.tbsSave_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 30);
            // 
            // tbsLoad
            // 
            this.tbsLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbsLoad.Image = ((System.Drawing.Image)(resources.GetObject("tbsLoad.Image")));
            this.tbsLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbsLoad.Name = "tbsLoad";
            this.tbsLoad.Size = new System.Drawing.Size(46, 27);
            this.tbsLoad.Text = "Load";
            this.tbsLoad.Click += new System.EventHandler(this.tbsLoad_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 30);
            // 
            // btnEsportaExcel
            // 
            this.btnEsportaExcel.Location = new System.Drawing.Point(1137, 179);
            this.btnEsportaExcel.Name = "btnEsportaExcel";
            this.btnEsportaExcel.Size = new System.Drawing.Size(211, 60);
            this.btnEsportaExcel.TabIndex = 17;
            this.btnEsportaExcel.Text = "ESPORTA EXCEL";
            this.btnEsportaExcel.UseVisualStyleBackColor = true;
            this.btnEsportaExcel.Click += new System.EventHandler(this.btnEsportaExcel_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtScontoSecondario, 1, 0);
            this.tableLayoutPanel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel4.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(1618, 193);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(236, 40);
            this.tableLayoutPanel4.TabIndex = 18;
            this.tableLayoutPanel4.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 40);
            this.label1.TabIndex = 7;
            this.label1.Text = "SCONTO\r\nAGGIUNTIVO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtScontoSecondario
            // 
            this.txtScontoSecondario.Location = new System.Drawing.Point(121, 3);
            this.txtScontoSecondario.Name = "txtScontoSecondario";
            this.txtScontoSecondario.Size = new System.Drawing.Size(100, 27);
            this.txtScontoSecondario.TabIndex = 8;
            // 
            // btnExtraSconto
            // 
            this.btnExtraSconto.Location = new System.Drawing.Point(1508, 106);
            this.btnExtraSconto.Name = "btnExtraSconto";
            this.btnExtraSconto.Size = new System.Drawing.Size(211, 60);
            this.btnExtraSconto.TabIndex = 19;
            this.btnExtraSconto.Text = "SCONTO EXTRA";
            this.btnExtraSconto.UseVisualStyleBackColor = true;
            this.btnExtraSconto.Click += new System.EventHandler(this.btnExtraSconto_Click);
            // 
            // elimina
            // 
            this.elimina.HeaderText = "";
            this.elimina.MinimumWidth = 75;
            this.elimina.Name = "elimina";
            this.elimina.Text = "ELIMINA";
            this.elimina.UseColumnTextForButtonValue = true;
            this.elimina.Width = 75;
            // 
            // codice
            // 
            this.codice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.codice.HeaderText = "CODICE";
            this.codice.MinimumWidth = 6;
            this.codice.Name = "codice";
            this.codice.Width = 86;
            // 
            // immagine
            // 
            this.immagine.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.immagine.HeaderText = "IMMAGINE";
            this.immagine.MinimumWidth = 100;
            this.immagine.Name = "immagine";
            this.immagine.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // descrizione
            // 
            this.descrizione.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.descrizione.HeaderText = "DESCRIZIONE";
            this.descrizione.MinimumWidth = 6;
            this.descrizione.Name = "descrizione";
            this.descrizione.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.descrizione.Width = 125;
            // 
            // dimensioni
            // 
            this.dimensioni.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dimensioni.HeaderText = "DIMENSIONI";
            this.dimensioni.MinimumWidth = 6;
            this.dimensioni.Name = "dimensioni";
            this.dimensioni.Width = 114;
            // 
            // quantita
            // 
            this.quantita.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.quantita.HeaderText = "QUANTITA\'";
            this.quantita.MinimumWidth = 6;
            this.quantita.Name = "quantita";
            this.quantita.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.quantita.Width = 108;
            // 
            // prezzoListino
            // 
            this.prezzoListino.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = "0";
            this.prezzoListino.DefaultCellStyle = dataGridViewCellStyle1;
            this.prezzoListino.HeaderText = "PREZZO\nUNITARIO";
            this.prezzoListino.MinimumWidth = 6;
            this.prezzoListino.Name = "prezzoListino";
            this.prezzoListino.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // prezzoTotale
            // 
            this.prezzoTotale.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = "0";
            this.prezzoTotale.DefaultCellStyle = dataGridViewCellStyle2;
            this.prezzoTotale.HeaderText = "PREZZO\nTOTALE";
            this.prezzoTotale.MinimumWidth = 6;
            this.prezzoTotale.Name = "prezzoTotale";
            this.prezzoTotale.Width = 90;
            // 
            // prezzoUnitarioScontato
            // 
            this.prezzoUnitarioScontato.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = "0";
            this.prezzoUnitarioScontato.DefaultCellStyle = dataGridViewCellStyle3;
            this.prezzoUnitarioScontato.HeaderText = "PREZZO\nUNITARIO\nSCONTATO";
            this.prezzoUnitarioScontato.MinimumWidth = 6;
            this.prezzoUnitarioScontato.Name = "prezzoUnitarioScontato";
            this.prezzoUnitarioScontato.Width = 111;
            // 
            // prezzoTotaleScontato
            // 
            this.prezzoTotaleScontato.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = "0";
            this.prezzoTotaleScontato.DefaultCellStyle = dataGridViewCellStyle4;
            this.prezzoTotaleScontato.HeaderText = "PREZZO\nTOTALE\nSCONTATO";
            this.prezzoTotaleScontato.MinimumWidth = 6;
            this.prezzoTotaleScontato.Name = "prezzoTotaleScontato";
            this.prezzoTotaleScontato.Width = 111;
            // 
            // quantitaMelanimici
            // 
            this.quantitaMelanimici.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.quantitaMelanimici.FalseValue = false;
            this.quantitaMelanimici.HeaderText = "-->";
            this.quantitaMelanimici.MinimumWidth = 6;
            this.quantitaMelanimici.Name = "quantitaMelanimici";
            this.quantitaMelanimici.TrueValue = true;
            this.quantitaMelanimici.Width = 28;
            // 
            // prezzoMelanimici
            // 
            this.prezzoMelanimici.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = "ND";
            this.prezzoMelanimici.DefaultCellStyle = dataGridViewCellStyle5;
            this.prezzoMelanimici.HeaderText = "PREZZO\nMELAMINICI\nCOLORATI";
            this.prezzoMelanimici.MinimumWidth = 6;
            this.prezzoMelanimici.Name = "prezzoMelanimici";
            this.prezzoMelanimici.Width = 111;
            // 
            // quantitaPuntali
            // 
            this.quantitaPuntali.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.quantitaPuntali.FalseValue = false;
            this.quantitaPuntali.HeaderText = "-->";
            this.quantitaPuntali.MinimumWidth = 6;
            this.quantitaPuntali.Name = "quantitaPuntali";
            this.quantitaPuntali.TrueValue = true;
            this.quantitaPuntali.Width = 28;
            // 
            // prezzoPuntali
            // 
            this.prezzoPuntali.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.NullValue = "ND";
            this.prezzoPuntali.DefaultCellStyle = dataGridViewCellStyle6;
            this.prezzoPuntali.HeaderText = "PREZZO\nPUNTALI\nCON PIEDINI\nLIVELLATORI";
            this.prezzoPuntali.MinimumWidth = 6;
            this.prezzoPuntali.Name = "prezzoPuntali";
            this.prezzoPuntali.Width = 119;
            // 
            // quantitaRuote
            // 
            this.quantitaRuote.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.quantitaRuote.FalseValue = false;
            this.quantitaRuote.HeaderText = "-->";
            this.quantitaRuote.MinimumWidth = 6;
            this.quantitaRuote.Name = "quantitaRuote";
            this.quantitaRuote.TrueValue = true;
            this.quantitaRuote.Width = 28;
            // 
            // prezzoRuote
            // 
            this.prezzoRuote.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle7.Format = "C2";
            dataGridViewCellStyle7.NullValue = "ND";
            this.prezzoRuote.DefaultCellStyle = dataGridViewCellStyle7;
            this.prezzoRuote.HeaderText = "PREZZO\nRUOTE\nA RULLO\nCON TAPPI\nBLOCC. SCORRIMENTO";
            this.prezzoRuote.MinimumWidth = 6;
            this.prezzoRuote.Name = "prezzoRuote";
            this.prezzoRuote.Width = 186;
            // 
            // quantitaTerminali
            // 
            this.quantitaTerminali.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.quantitaTerminali.FalseValue = false;
            this.quantitaTerminali.HeaderText = "-->";
            this.quantitaTerminali.MinimumWidth = 6;
            this.quantitaTerminali.Name = "quantitaTerminali";
            this.quantitaTerminali.TrueValue = true;
            this.quantitaTerminali.Width = 28;
            // 
            // prezzoTerminali
            // 
            this.prezzoTerminali.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle8.Format = "C2";
            dataGridViewCellStyle8.NullValue = "ND";
            this.prezzoTerminali.DefaultCellStyle = dataGridViewCellStyle8;
            this.prezzoTerminali.HeaderText = "PREZZO\nTERMINALI\nA VITE\nPER REGOLAZ.\nH. DI 200 MM";
            this.prezzoTerminali.MinimumWidth = 6;
            this.prezzoTerminali.Name = "prezzoTerminali";
            this.prezzoTerminali.Width = 133;
            // 
            // quantitaBoccola
            // 
            this.quantitaBoccola.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.quantitaBoccola.FalseValue = false;
            this.quantitaBoccola.HeaderText = "-->";
            this.quantitaBoccola.MinimumWidth = 6;
            this.quantitaBoccola.TrueValue = true;
            this.quantitaBoccola.Width = 28;
            this.quantitaBoccola.Name = "quantitaBoccola";
            // 
            // prezzoBoccola
            // 
            this.prezzoTerminali.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle9.Format = "C2";
            dataGridViewCellStyle9.NullValue = "ND";
            this.prezzoTerminali.DefaultCellStyle = dataGridViewCellStyle9;
            this.prezzoBoccola.HeaderText = "BOCCOLA PASSA CAVI D.60";
            this.prezzoBoccola.MinimumWidth = 6;
            this.prezzoBoccola.Name = "prezzoBoccola";
            this.prezzoBoccola.Width = 108;
            // 
            // quantitaTop
            // 
            this.quantitaTop.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.quantitaTop.FalseValue = false;
            this.quantitaTop.HeaderText = "-->";
            this.quantitaTop.MinimumWidth = 6;
            this.quantitaTop.TrueValue = true;
            this.quantitaTop.Width = 28;
            this.quantitaTop.Name = "quantitaTop";
            // 
            // prezzoTop
            // 
            this.prezzoTerminali.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle10.Format = "C2";
            dataGridViewCellStyle10.NullValue = "ND";
            this.prezzoTerminali.DefaultCellStyle = dataGridViewCellStyle10;
            this.prezzoTop.HeaderText = "MAGIC TOP L.300";
            this.prezzoTop.MinimumWidth = 6;
            this.prezzoTop.Name = "prezzoTop";
            this.prezzoTop.Width = 91;
            // 
            // quantitaPresa
            // 
            this.quantitaPresa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.quantitaPresa.FalseValue = false;
            this.quantitaPresa.HeaderText = "-->";
            this.quantitaPresa.MinimumWidth = 6;
            this.quantitaPresa.TrueValue = true;
            this.quantitaPresa.Width = 28;
            this.quantitaPresa.Name = "quantitaPresa";
            // 
            // prezzoPresa
            // 
            this.prezzoTerminali.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle11.Format = "C2";
            dataGridViewCellStyle11.NullValue = "ND";
            this.prezzoTerminali.DefaultCellStyle = dataGridViewCellStyle11;
            this.prezzoPresa.HeaderText = "PRESA CIRC. D.60";
            this.prezzoPresa.MinimumWidth = 6;
            this.prezzoPresa.Name = "prezzoPresa";
            this.prezzoPresa.Width = 69;
            // 
            // quantitaMulti2x3
            // 
            this.quantitaMulti2x3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.quantitaMulti2x3.FalseValue = false;
            this.quantitaMulti2x3.HeaderText = "-->";
            this.quantitaMulti2x3.MinimumWidth = 6;
            this.quantitaMulti2x3.TrueValue = true;
            this.quantitaMulti2x3.Width = 28;
            this.quantitaMulti2x3.Name = "quantitaMulti2x3";
            // 
            // prezzoMulti2x3
            // 
            this.prezzoTerminali.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle12.Format = "C2";
            dataGridViewCellStyle12.NullValue = "ND";
            this.prezzoTerminali.DefaultCellStyle = dataGridViewCellStyle12;
            this.prezzoMulti2x3.HeaderText = "MULTI PRESA RETT. 2 UNEL 3 USB 5V A+C";
            this.prezzoMulti2x3.MinimumWidth = 6;
            this.prezzoMulti2x3.Name = "prezzoMulti2x3";
            this.prezzoMulti2x3.Width = 92;
            // 
            // quantitaMulti3x3
            // 
            this.quantitaMulti3x3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.quantitaMulti3x3.FalseValue = false;
            this.quantitaMulti3x3.HeaderText = "-->";
            this.quantitaMulti3x3.MinimumWidth = 6;
            this.quantitaMulti3x3.TrueValue = true;
            this.quantitaMulti3x3.Width = 28;
            this.quantitaMulti3x3.Name = "quantitaMulti3x3";
            // 
            // prezzoMulti3x3
            // 
            this.prezzoTerminali.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle13.Format = "C2";
            dataGridViewCellStyle13.NullValue = "ND";
            this.prezzoTerminali.DefaultCellStyle = dataGridViewCellStyle13;
            this.prezzoMulti3x3.HeaderText = "MULTI PRESA RETT. 3 UNEL 3 USB 5V A+C";
            this.prezzoMulti3x3.MinimumWidth = 6;
            this.prezzoMulti3x3.Name = "prezzoMulti3x3";
            this.prezzoMulti3x3.Width = 115;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.btnExtraSconto);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Controls.Add(this.btnEsportaExcel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.btnPdf);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.addProduct);
            this.Controls.Add(this.lblAusiliare);
            this.Controls.Add(this.prodottiAggiunti);
            this.Controls.Add(this.txbxDatiAzienda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1918, 1018);
            this.Name = "MainView";
            this.Text = "Preventivo Scolastico";
            this.Load += new System.EventHandler(this.MainView_Load);
            this.Resize += new System.EventHandler(this.MainView_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.prodottiAggiunti)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txbxDatiAzienda;
        private System.Windows.Forms.DataGridView prodottiAggiunti;
        private System.Windows.Forms.Label lblAusiliare;
        private System.Windows.Forms.Button addProduct;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.TextBox txtLuogo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPrezzoNetto;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Panel panel1;
        private TextBox txtMontaggio;
        private TextBox txtTempi;
        private TextBox txtIva;
        private TextBox txtValidita;
        private TextBox txtPagamento;
        private Label label10;
        private Button btnPdf;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label11;
        private TextBox txtSconto;
        private ToolStrip toolStrip1;
        private ToolStripButton tsbNew;
        private ToolStripButton tbsSave;
        private ToolStripButton tbsLoad;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
        private Button btnEsportaExcel;
        private TableLayoutPanel tableLayoutPanel4;
        private Label label1;
        private TextBox txtScontoSecondario;
        private Button btnExtraSconto;
        private DataGridViewButtonColumn elimina;
        private DataGridViewTextBoxColumn codice;
        private DataGridViewImageColumn immagine;
        private DataGridViewTextBoxColumn descrizione;
        private DataGridViewTextBoxColumn dimensioni;
        private DataGridViewTextBoxColumn quantita;
        private DataGridViewTextBoxColumn prezzoListino;
        private DataGridViewTextBoxColumn prezzoTotale;
        private DataGridViewTextBoxColumn prezzoUnitarioScontato;
        private DataGridViewTextBoxColumn prezzoTotaleScontato;
        private DataGridViewCheckBoxColumn quantitaMelanimici;
        private DataGridViewTextBoxColumn prezzoMelanimici;
        private DataGridViewCheckBoxColumn quantitaPuntali;
        private DataGridViewTextBoxColumn prezzoPuntali;
        private DataGridViewCheckBoxColumn quantitaRuote;
        private DataGridViewTextBoxColumn prezzoRuote;
        private DataGridViewCheckBoxColumn quantitaTerminali;
        private DataGridViewTextBoxColumn prezzoTerminali;
        private DataGridViewCheckBoxColumn quantitaBoccola;
        private DataGridViewTextBoxColumn prezzoBoccola;
        private DataGridViewCheckBoxColumn quantitaTop;
        private DataGridViewTextBoxColumn prezzoTop;
        private DataGridViewCheckBoxColumn quantitaPresa;
        private DataGridViewTextBoxColumn prezzoPresa;
        private DataGridViewCheckBoxColumn quantitaMulti2x3;
        private DataGridViewTextBoxColumn prezzoMulti2x3;
        private DataGridViewCheckBoxColumn quantitaMulti3x3;
        private DataGridViewTextBoxColumn prezzoMulti3x3;
    }
}

