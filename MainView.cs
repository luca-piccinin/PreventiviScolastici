namespace PreventiviScolastici
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="MainView" />
    /// </summary>
    public partial class MainView : Form
    {
        // Imposta la cultura italiana (it-IT) che utilizza la virgola come separatore decimale

        /// <summary>
        /// Defines the culture
        /// </summary>
        internal System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("it-IT");

        /// <summary>
        /// Gets or sets the IstanzaCorrente
        /// </summary>
        public static MainView IstanzaCorrente { get; set; }

        /// <summary>
        /// Defines the modifica
        /// </summary>
        public bool modifica = false;

        /// <summary>
        /// Defines the aggiunta
        /// </summary>
        public bool aggiunta;

        /// <summary>
        /// Defines the ExtraSconto
        /// </summary>
        public bool ExtraSconto = false;

        /// <summary>
        /// Gets or sets the sconto
        /// </summary>
        public static Decimal sconto { get; set; }

        /// <summary>
        /// Gets or sets the scontoSecondario
        /// </summary>
        public static Decimal scontoSecondario { get; set; }

        /// <summary>
        /// Defines the luogo, azienda
        /// </summary>
        internal string luogo = "", azienda = "";

        /// <summary>
        /// Defines the database
        /// </summary>
        internal Database database = new Database();

        /// <summary>
        /// Defines the acquisti
        /// </summary>
        internal List<Acquisti> acquisti = new List<Acquisti>();

        /// <summary>
        /// Defines the pdf
        /// </summary>
        internal PdfManager pdf = new PdfManager();

        /// <summary>
        /// Defines the excel
        /// </summary>
        internal ExcelRW excel = new ExcelRW();

        /// <summary>
        /// The ImpostaModificaDaEsterno
        /// </summary>
        public void ImpostaModificaDaEsterno()
        {
            modifica = false;
        }

        /// <summary>
        /// The setCentral
        /// </summary>
        private void setCentral()
        {
            prodottiAggiunti.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        /// <summary>
        /// The setData
        /// </summary>
        private void setData()
        {
            lblData.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        /// <summary>
        /// The ReimpostaModificaInterna
        /// </summary>
        public void ReimpostaModificaInterna()
        {
            modifica = true;
        }

        /// <summary>
        /// The setForm
        /// </summary>
        public void setForm()
        {
            prodottiAggiunti.CellClick -= prodottiAggiunti_CellClick;
            prodottiAggiunti.CellClick += prodottiAggiunti_CellClick;
            prodottiAggiunti.CellValueChanged -= prodottiAggiunti_CellValueChanged;
            prodottiAggiunti.CellValueChanged += prodottiAggiunti_CellValueChanged;

            txtSconto.TextChanged -= txtSconto_TextChanged;
            txtSconto.TextChanged += txtSconto_TextChanged;

            txtScontoSecondario.TextChanged -= txtScontoSecondario_TextChanged;
            txtScontoSecondario.TextChanged += txtScontoSecondario_TextChanged;

            if (!string.IsNullOrEmpty(azienda))
            {
                txbxDatiAzienda.Text = azienda;
                txbxDatiAzienda.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                txbxDatiAzienda.Text = "DATI AZIENDA";
                txbxDatiAzienda.ForeColor = System.Drawing.Color.Gray;
            }
            txbxDatiAzienda.Enter -= txbxDatiAzienda_Enter;
            txbxDatiAzienda.Enter += txbxDatiAzienda_Enter;
            txbxDatiAzienda.Leave -= txbxDatiAzienda_Leave;
            txbxDatiAzienda.Leave += txbxDatiAzienda_Leave;
            txbxDatiAzienda.TextChanged -= txbxDatiAzienda_TextChanged;
            txbxDatiAzienda.TextChanged += txbxDatiAzienda_TextChanged;

            if (!string.IsNullOrEmpty(luogo))
            {
                txtLuogo.Text = luogo;
                txtLuogo.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                txtLuogo.Text = "Luogo";
                txtLuogo.ForeColor = System.Drawing.Color.Gray;
            }
            txtLuogo.Enter -= txtLuogo_Enter;
            txtLuogo.Enter += txtLuogo_Enter;
            txtLuogo.Leave -= txtLuogo_Leave;
            txtLuogo.Leave += txtLuogo_Leave;
            txtLuogo.TextChanged -= txtLuogo_TextChanged;
            txtLuogo.TextChanged += txtLuogo_TextChanged;

            prodottiAggiunti.RowTemplate.Height = 100;

            IstanzaCorrente = this;
            setCentral();
            this.WindowState = FormWindowState.Maximized;
            this.FormClosing -= MyForm_FormClosing;
            this.FormClosing += MyForm_FormClosing;
            setData();

            propertyName();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainView"/> class.
        /// </summary>
        public MainView()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            setForm();
        }

        /// <summary>
        /// The MyForm_FormClosing
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="FormClosingEventArgs"/></param>
        private void MyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // L'utente ha tentato di chiudere il form cliccando sul pulsante di chiusura
                if (MessageBox.Show("Sei sicuro di voler chiudere?", "Conferma Chiusura", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    // L'utente ha scelto di non chiudere il form, quindi annulla l'operazione di chiusura
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// The txbxDatiAzienda_TextChanged
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void txbxDatiAzienda_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbxDatiAzienda.Text) && txbxDatiAzienda.Text != "DATI AZIENDA")
                azienda = txbxDatiAzienda.Text;
        }

        /// <summary>
        /// The txtLuogo_TextChanged
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void txtLuogo_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLuogo.Text) && txtLuogo.Text != "Luogo")
                luogo = txtLuogo.Text;
        }

        /// <summary>
        /// The setSconto
        /// </summary>
        private void setSconto()
        {
            string input = txtSconto.Text;

            // Verifica se l'input termina con il simbolo "%"
            if (input.EndsWith("%"))
            {
                // Rimuovi il simbolo "%" dall'input
                string numeroSenzaPercentuale = input.TrimEnd('%').Trim();

                // Utilizza il metodo onlyNum per convertire la stringa in un numero decimale
                sconto = onlyNum(numeroSenzaPercentuale);
            }
            else
            {
                // Utilizza il metodo onlyNum anche per l'input senza modifiche
                sconto = onlyNum(input);
            }
        }

        /// <summary>
        /// The setScontoSecondario
        /// </summary>
        private void setScontoSecondario()
        {
            string input = txtScontoSecondario.Text;

            // Verifica se l'input termina con il simbolo "%"
            if (input.EndsWith("%"))
            {
                // Rimuovi il simbolo "%" dall'input
                string numeroSenzaPercentuale = input.TrimEnd('%').Trim();

                // Utilizza il metodo onlyNum per convertire la stringa in un numero decimale
                scontoSecondario = onlyNum(numeroSenzaPercentuale);
            }
            else
            {
                // Utilizza il metodo onlyNum anche per l'input senza modifiche
                scontoSecondario = onlyNum(input);
            }
        }

        /// <summary>
        /// The txtSconto_TextChanged
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void txtSconto_TextChanged(object sender, EventArgs e)
        {
            if (onlyNum(txtSconto.Text.TrimEnd('%').Trim()) >= 0 && onlyNum(txtSconto.Text.TrimEnd('%').Trim()) <= 100)
            {
                if (txtSconto.Text != sconto.ToString())
                {
                    setSconto();
                    int row = prodottiAggiunti.RowCount;
                    for (int i = 0; i < row; i++)
                    {
                        modificaPrezzo(i);
                        prezzoScontato(i);
                    }
                }
                setPrezzo();
                updateListAcquisti();
            }
            else
            {
                txtSconto.Text = "0";
                MessageBox.Show("Lo sconto inserito non è valido");
            }
        }

        /// <summary>
        /// The txtScontoSecondario_TextChanged
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void txtScontoSecondario_TextChanged(object sender, EventArgs e)
        {
            if (onlyNum(txtScontoSecondario.Text.TrimEnd('%').Trim()) >= 0 && onlyNum(txtScontoSecondario.Text.TrimEnd('%').Trim()) <= 100)
            {
                if (txtScontoSecondario.Text != scontoSecondario.ToString())
                {
                    setScontoSecondario();
                    int row = prodottiAggiunti.RowCount;
                    for (int i = 0; i < row; i++)
                    {
                        prezzoScontato(i);
                        prezzoScontatoSecondario(i);
                    }
                }
                setPrezzo();
                updateListAcquisti();
            }
            else
            {
                MessageBox.Show("Lo sconto inserito non è valido");
                txtScontoSecondario.Text = "0";
            }
        }

        /// <summary>
        /// The addProduct_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void addProduct_Click(object sender, EventArgs e)
        {
            setForm();
            if (txtSconto.Text != "")
            {
                decimal verifica;
                if (decimal.TryParse(txtSconto.Text, out verifica) == true && onlyNum(txtSconto.Text.TrimEnd('%').Trim()) <= 100 && onlyNum(txtSconto.Text.TrimEnd('%').Trim()) >= 0)
                {
                    //txtSconto.Enabled = false;
                    setSconto();
                    AddView formDestinazione = AddView.IstanzaCorrente;
                    if (formDestinazione != null && !formDestinazione.IsDisposed)
                    {
                        formDestinazione.Show();
                        formDestinazione.BringToFront();
                        this.Hide();
                    }
                    else
                    {
                        AddView destinazione = new AddView(); // o riferimento esistente
                        destinazione.Show(); // Mostra FormDestinazione se non è già visibile
                        destinazione.BringToFront();
                        this.Hide();
                    }
                }
                else
                {
                    txtSconto.Text = "0";
                    MessageBox.Show("Lo sconto inserito non è valido", "Errore");
                }
            }
            else
            {
                txtSconto.Text = "0";
                addProduct_Click(sender, e);
            }
        }

        /// <summary>
        /// The setPrezzo
        /// </summary>
        private void setPrezzo()
        {
            decimal total = 0;
            foreach (Acquisti aus in acquisti)
            {
                total += onlyNum(aus.prezzoTotaleScontato);
            }
            lblPrezzoNetto.Text = total.ToString("0 €", culture);
        }

        /// <summary>
        /// The checkbox
        /// </summary>
        /// <param name="name">The name<see cref="string"/></param>
        /// <param name="e">The e<see cref="DataGridViewCellEventArgs"/></param>
        private void checkbox(string name, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == prodottiAggiunti.Columns[name].Index && e.RowIndex >= 0)
            {
                bool isChecked = (bool)prodottiAggiunti.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue;

                // Ottieni i valori già come decimali usando il metodo onlyNum
                decimal tot = onlyNum(prodottiAggiunti.Rows[e.RowIndex].Cells["prezzoTotale"].Value.ToString());
                decimal num = onlyNum(prodottiAggiunti.Rows[e.RowIndex].Cells["quantita"].Value.ToString());
                int index = prodottiAggiunti.Rows[e.RowIndex].Cells[name].ColumnIndex;
                decimal cost = onlyNum(prodottiAggiunti.Rows[e.RowIndex].Cells[index + 1].Value.ToString());

                if (isChecked)
                {
                    tot += num * cost;
                }
                else
                {
                    tot -= num * cost;
                }

                // Aggiorna il valore nella cella con il nuovo totale, formattato correttamente come stringa
                prodottiAggiunti.Rows[e.RowIndex].Cells["prezzoTotale"].Value = tot.ToString("0 €", culture);

                acquisti[e.RowIndex].prezzoTotale = tot.ToString("0 €", culture);

                prezzoScontato(e);
                prezzoScontatoSecondario(e);
                setPrezzo();
                updateListAcquisti();
            }
        }

        /// <summary>
        /// The prezzoScontato
        /// </summary>
        /// <param name="e">The e<see cref="DataGridViewCellEventArgs"/></param>
        private void prezzoScontato(DataGridViewCellEventArgs e)
        {
            decimal var, var1 = 0;
            if ((bool)prodottiAggiunti.Rows[e.RowIndex].Cells["quantitaMelanimici"].EditedFormattedValue)
                var1 += onlyNum(prodottiAggiunti.Rows[e.RowIndex].Cells["prezzoMelanimici"].Value.ToString());
            if ((bool)prodottiAggiunti.Rows[e.RowIndex].Cells["quantitaPuntali"].EditedFormattedValue)
                var1 += onlyNum(prodottiAggiunti.Rows[e.RowIndex].Cells["prezzoPuntali"].Value.ToString());
            if ((bool)prodottiAggiunti.Rows[e.RowIndex].Cells["quantitaRuote"].EditedFormattedValue)
                var1 += onlyNum(prodottiAggiunti.Rows[e.RowIndex].Cells["prezzoRuote"].Value.ToString());
            if ((bool)prodottiAggiunti.Rows[e.RowIndex].Cells["quantitaTerminali"].EditedFormattedValue)
                var1 += onlyNum(prodottiAggiunti.Rows[e.RowIndex].Cells["prezzoTerminali"].Value.ToString());
            if ((bool)prodottiAggiunti.Rows[e.RowIndex].Cells["quantitaBoccola"].EditedFormattedValue)
                var1 += onlyNum(prodottiAggiunti.Rows[e.RowIndex].Cells["prezzoBoccola"].Value.ToString());
            if ((bool)prodottiAggiunti.Rows[e.RowIndex].Cells["quantitaTop"].EditedFormattedValue)
                var1 += onlyNum(prodottiAggiunti.Rows[e.RowIndex].Cells["prezzoTop"].Value.ToString());
            if ((bool)prodottiAggiunti.Rows[e.RowIndex].Cells["quantitaPresa"].EditedFormattedValue)
                var1 += onlyNum(prodottiAggiunti.Rows[e.RowIndex].Cells["prezzoPresa"].Value.ToString());
            if ((bool)prodottiAggiunti.Rows[e.RowIndex].Cells["quantitaMulti2x3"].EditedFormattedValue)
                var1 += onlyNum(prodottiAggiunti.Rows[e.RowIndex].Cells["prezzoMulti2x3"].Value.ToString());
            if ((bool)prodottiAggiunti.Rows[e.RowIndex].Cells["quantitaMulti3x3"].EditedFormattedValue)
                var1 += onlyNum(prodottiAggiunti.Rows[e.RowIndex].Cells["prezzoMulti3x3"].Value.ToString());

            var = onlyNum(prodottiAggiunti.Rows[e.RowIndex].Cells["prezzoListino"].Value.ToString()) + var1;
            decimal scontato = var - (var * (sconto / 100));

            var = onlyNum(prodottiAggiunti.Rows[e.RowIndex].Cells["prezzoTotale"].Value.ToString());
            decimal scontatoTotale = var - (var * (sconto / 100));

            prodottiAggiunti.Rows[e.RowIndex].Cells["prezzoUnitarioScontato"].Value = scontato.ToString("0 €", culture);
            prodottiAggiunti.Rows[e.RowIndex].Cells["prezzoTotaleScontato"].Value = scontatoTotale.ToString("0 €", culture);
            acquisti[e.RowIndex].prezzoUnitarioScontato = scontato.ToString("0 €", culture);
            acquisti[e.RowIndex].prezzoTotaleScontato = scontatoTotale.ToString("0 €", culture);
        }

        /// <summary>
        /// The prezzoScontato
        /// </summary>
        /// <param name="row">The row<see cref="int"/></param>
        private void prezzoScontato(int row)
        {
            decimal var, var1 = 0;
            if ((bool)prodottiAggiunti.Rows[row].Cells["quantitaMelanimici"].EditedFormattedValue)
                var1 += onlyNum(prodottiAggiunti.Rows[row].Cells["prezzoMelanimici"].Value.ToString());
            if ((bool)prodottiAggiunti.Rows[row].Cells["quantitaPuntali"].EditedFormattedValue)
                var1 += onlyNum(prodottiAggiunti.Rows[row].Cells["prezzoPuntali"].Value.ToString());
            if ((bool)prodottiAggiunti.Rows[row].Cells["quantitaRuote"].EditedFormattedValue)
                var1 += onlyNum(prodottiAggiunti.Rows[row].Cells["prezzoRuote"].Value.ToString());
            if ((bool)prodottiAggiunti.Rows[row].Cells["quantitaTerminali"].EditedFormattedValue)
                var1 += onlyNum(prodottiAggiunti.Rows[row].Cells["prezzoTerminali"].Value.ToString());
            if ((bool)prodottiAggiunti.Rows[row].Cells["quantitaBoccola"].EditedFormattedValue)
                var1 += onlyNum(prodottiAggiunti.Rows[row].Cells["prezzoBoccola"].Value.ToString());
            if ((bool)prodottiAggiunti.Rows[row].Cells["quantitaTop"].EditedFormattedValue)
                var1 += onlyNum(prodottiAggiunti.Rows[row].Cells["prezzoTop"].Value.ToString());
            if ((bool)prodottiAggiunti.Rows[row].Cells["quantitaPresa"].EditedFormattedValue)
                var1 += onlyNum(prodottiAggiunti.Rows[row].Cells["prezzoPresa"].Value.ToString());
            if ((bool)prodottiAggiunti.Rows[row].Cells["quantitaMulti2x3"].EditedFormattedValue)
                var1 += onlyNum(prodottiAggiunti.Rows[row].Cells["prezzoMulti2x3"].Value.ToString());
            if ((bool)prodottiAggiunti.Rows[row].Cells["quantitaMulti3x3"].EditedFormattedValue)
                var1 += onlyNum(prodottiAggiunti.Rows[row].Cells["prezzoMulti3x3"].Value.ToString());

            var = onlyNum(prodottiAggiunti.Rows[row].Cells["prezzoListino"].Value.ToString()) + var1;
            decimal scontato = var - (var * (sconto / 100));

            var = onlyNum(prodottiAggiunti.Rows[row].Cells["prezzoTotale"].Value.ToString());
            decimal scontatoTotale = var - (var * (sconto / 100));

            prodottiAggiunti.Rows[row].Cells["prezzoUnitarioScontato"].Value = scontato.ToString("0 €", culture);
            prodottiAggiunti.Rows[row].Cells["prezzoTotaleScontato"].Value = scontatoTotale.ToString("0 €", culture);
            acquisti[row].prezzoUnitarioScontato = scontato.ToString("0 €", culture);
            acquisti[row].prezzoTotaleScontato = scontatoTotale.ToString("0 €", culture);
        }

        /// <summary>
        /// The prezzoScontatoSecondario
        /// </summary>
        /// <param name="e">The e<see cref="DataGridViewCellEventArgs"/></param>
        private void prezzoScontatoSecondario(DataGridViewCellEventArgs e)
        {
            decimal var;

            var = onlyNum(prodottiAggiunti.Rows[e.RowIndex].Cells["prezzoUnitarioScontato"].Value.ToString());
            decimal scontato = var - (var * (scontoSecondario / 100));

            var = onlyNum(prodottiAggiunti.Rows[e.RowIndex].Cells["prezzoTotaleScontato"].Value.ToString());
            decimal scontatoTotale = var - (var * (scontoSecondario / 100));

            prodottiAggiunti.Rows[e.RowIndex].Cells["prezzoUnitarioScontato"].Value = scontato.ToString("0 €", culture);
            prodottiAggiunti.Rows[e.RowIndex].Cells["prezzoTotaleScontato"].Value = scontatoTotale.ToString("0 €", culture);
            acquisti[e.RowIndex].prezzoUnitarioScontato = scontato.ToString("0 €", culture);
            acquisti[e.RowIndex].prezzoTotaleScontato = scontatoTotale.ToString("0 €", culture);
        }

        /// <summary>
        /// The prezzoScontatoSecondario
        /// </summary>
        /// <param name="row">The row<see cref="int"/></param>
        private void prezzoScontatoSecondario(int row)
        {
            decimal var;

            var = onlyNum(prodottiAggiunti.Rows[row].Cells["prezzoUnitarioScontato"].Value.ToString());
            decimal scontato = var - (var * (scontoSecondario / 100));

            var = onlyNum(prodottiAggiunti.Rows[row].Cells["prezzoTotaleScontato"].Value.ToString());
            decimal scontatoTotale = var - (var * (scontoSecondario / 100));

            prodottiAggiunti.Rows[row].Cells["prezzoUnitarioScontato"].Value = scontato.ToString("0 €", culture);
            prodottiAggiunti.Rows[row].Cells["prezzoTotaleScontato"].Value = scontatoTotale.ToString("0 €", culture);
            acquisti[row].prezzoUnitarioScontato = scontato.ToString("0 €", culture);
            acquisti[row].prezzoTotaleScontato = scontatoTotale.ToString("0 €", culture);
        }

        /// <summary>
        /// The modificaPrezzo
        /// </summary>
        /// <param name="e">The e<see cref="DataGridViewCellEventArgs"/></param>
        private void modificaPrezzo(DataGridViewCellEventArgs e)
        {
            decimal lis = onlyNum(prodottiAggiunti.Rows[e.RowIndex].Cells["prezzoListino"].Value.ToString());
            decimal aux = onlyNum(prodottiAggiunti.Rows[e.RowIndex].Cells["prezzoTotale"].Value.ToString());
            decimal num = onlyNum(prodottiAggiunti.Rows[e.RowIndex].Cells["quantita"].Value.ToString());
            decimal tot = num * lis;

            if (aux == tot) // non ci sono altre checkbox attive
            {
                prezzoScontato(e);
                prezzoScontatoSecondario(e);
            }
            else
            {
                decimal extra;
                string name = "";
                if ((bool)prodottiAggiunti.Rows[e.RowIndex].Cells["quantitaMelanimici"].EditedFormattedValue == true)
                {
                    extra = onlyNum(prodottiAggiunti.Rows[e.RowIndex].Cells["prezzoMelanimici"].Value.ToString());
                    tot += num * extra;
                    name = "prezzoMelanimici";
                }
                if ((bool)prodottiAggiunti.Rows[e.RowIndex].Cells["quantitaPuntali"].EditedFormattedValue == true)
                {
                    extra = onlyNum(prodottiAggiunti.Rows[e.RowIndex].Cells["prezzoPuntali"].Value.ToString());
                    tot += num * extra;
                    name = "prezzoPuntali";
                }
                if ((bool)prodottiAggiunti.Rows[e.RowIndex].Cells["quantitaRuote"].EditedFormattedValue == true)
                {
                    extra = onlyNum(prodottiAggiunti.Rows[e.RowIndex].Cells["prezzoRuote"].Value.ToString());
                    tot += num * extra;
                    name = "prezzoRuote";
                }
                if ((bool)prodottiAggiunti.Rows[e.RowIndex].Cells["quantitaTerminali"].EditedFormattedValue == true)
                {
                    extra = onlyNum(prodottiAggiunti.Rows[e.RowIndex].Cells["prezzoTerminali"].Value.ToString());
                    tot += num * extra;
                    name = "prezzoTerminali";
                }
                if ((bool)prodottiAggiunti.Rows[e.RowIndex].Cells["quantitaBoccola"].EditedFormattedValue == true)
                {
                    extra = onlyNum(prodottiAggiunti.Rows[e.RowIndex].Cells["prezzoBoccola"].Value.ToString());
                    tot += num * extra;
                    name = "prezzoBoccola";
                }
                if ((bool)prodottiAggiunti.Rows[e.RowIndex].Cells["quantitaTop"].EditedFormattedValue == true)
                {
                    extra = onlyNum(prodottiAggiunti.Rows[e.RowIndex].Cells["prezzoTop"].Value.ToString());
                    tot += num * extra;
                    name = "prezzoTop";
                }
                if ((bool)prodottiAggiunti.Rows[e.RowIndex].Cells["quantitaPresa"].EditedFormattedValue == true)
                {
                    extra = onlyNum(prodottiAggiunti.Rows[e.RowIndex].Cells["prezzoPresa"].Value.ToString());
                    tot += num * extra;
                    name = "prezzoPresa";
                }
                if ((bool)prodottiAggiunti.Rows[e.RowIndex].Cells["quantitaMulti2x3"].EditedFormattedValue == true)
                {
                    extra = onlyNum(prodottiAggiunti.Rows[e.RowIndex].Cells["prezzoMulti2x3"].Value.ToString());
                    tot += num * extra;
                    name = "prezzoMulti2x3";
                }
                if ((bool)prodottiAggiunti.Rows[e.RowIndex].Cells["quantitaMulti3x3"].EditedFormattedValue == true)
                {
                    extra = onlyNum(prodottiAggiunti.Rows[e.RowIndex].Cells["prezzoMulti3x3"].Value.ToString());
                    tot += num * extra;
                    name = "prezzoMulti3x3";
                }
                if (name != "")
                {
                    prodottiAggiunti.Rows[e.RowIndex].Cells["prezzoTotale"].Value = tot.ToString("0 €", culture);
                    prezzoScontato(e);
                    prezzoScontatoSecondario(e);
                }
            }
            setVisible(e.RowIndex);
            setPrezzo();
            updateListAcquisti();
        }

        /// <summary>
        /// The modificaPrezzo
        /// </summary>
        /// <param name="row">The row<see cref="int"/></param>
        private void modificaPrezzo(int row)
        {
            decimal lis = onlyNum(prodottiAggiunti.Rows[row].Cells["prezzoListino"].Value.ToString());
            decimal aux = onlyNum(prodottiAggiunti.Rows[row].Cells["prezzoTotale"].Value.ToString());
            decimal num = onlyNum(prodottiAggiunti.Rows[row].Cells["quantita"].Value.ToString());
            decimal tot = num * lis;

            if (aux == tot) // non ci sono altre checkbox attive
            {
                prezzoScontato(row);
                prezzoScontatoSecondario(row);
            }
            else
            {
                decimal extra;
                string name = "";
                if ((bool)prodottiAggiunti.Rows[row].Cells["quantitaMelanimici"].EditedFormattedValue == true)
                {
                    extra = onlyNum(prodottiAggiunti.Rows[row].Cells["prezzoMelanimici"].Value.ToString());
                    tot += num * extra;
                    name = "prezzoMelanimici";
                }
                if ((bool)prodottiAggiunti.Rows[row].Cells["quantitaPuntali"].EditedFormattedValue == true)
                {
                    extra = onlyNum(prodottiAggiunti.Rows[row].Cells["prezzoPuntali"].Value.ToString());
                    tot += num * extra;
                    name = "prezzoPuntali";
                }
                if ((bool)prodottiAggiunti.Rows[row].Cells["quantitaRuote"].EditedFormattedValue == true)
                {
                    extra = onlyNum(prodottiAggiunti.Rows[row].Cells["prezzoRuote"].Value.ToString());
                    tot += num * extra;
                    name = "prezzoRuote";
                }
                if ((bool)prodottiAggiunti.Rows[row].Cells["quantitaTerminali"].EditedFormattedValue == true)
                {
                    extra = onlyNum(prodottiAggiunti.Rows[row].Cells["prezzoTerminali"].Value.ToString());
                    tot += num * extra;
                    name = "prezzoTerminali";
                }
                if ((bool)prodottiAggiunti.Rows[row].Cells["quantitaBoccola"].EditedFormattedValue == true)
                {
                    extra = onlyNum(prodottiAggiunti.Rows[row].Cells["prezzoBoccola"].Value.ToString());
                    tot += num * extra;
                    name = "prezzoBoccola";
                }
                if ((bool)prodottiAggiunti.Rows[row].Cells["quantitaTop"].EditedFormattedValue == true)
                {
                    extra = onlyNum(prodottiAggiunti.Rows[row].Cells["prezzoTop"].Value.ToString());
                    tot += num * extra;
                    name = "prezzoTop";
                }
                if ((bool)prodottiAggiunti.Rows[row].Cells["quantitaPresa"].EditedFormattedValue == true)
                {
                    extra = onlyNum(prodottiAggiunti.Rows[row].Cells["prezzoPresa"].Value.ToString());
                    tot += num * extra;
                    name = "prezzoPresa";
                }
                if ((bool)prodottiAggiunti.Rows[row].Cells["quantitaMulti2x3"].EditedFormattedValue == true)
                {
                    extra = onlyNum(prodottiAggiunti.Rows[row].Cells["prezzoMulti2x3"].Value.ToString());
                    tot += num * extra;
                    name = "prezzoMulti2x3";
                }
                if ((bool)prodottiAggiunti.Rows[row].Cells["quantitaMulti3x3"].EditedFormattedValue == true)
                {
                    extra = onlyNum(prodottiAggiunti.Rows[row].Cells["prezzoMulti3x3"].Value.ToString());
                    tot += num * extra;
                    name = "prezzoMulti3x3";
                }
                if (name != "")
                {
                    prodottiAggiunti.Rows[row].Cells["prezzoTotale"].Value = tot.ToString("0 €", culture);
                    prezzoScontato(row);
                    prezzoScontatoSecondario(row);
                }
            }
            setVisible(row);
            setPrezzo();
            updateListAcquisti();
        }

        /// <summary>
        /// The prodottiAggiunti_CellValueChanged
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="DataGridViewCellEventArgs"/></param>
        private void prodottiAggiunti_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (modifica == true)
            {
                // Verifica che il clic sia avvenuto nella colonna della CheckBox
                if (prodottiAggiunti.Columns["quantitaMelanimici"].Index == e.ColumnIndex)
                {
                    checkbox("quantitaMelanimici", e);
                    if ((bool)prodottiAggiunti.Rows[e.RowIndex].Cells["quantitaMelanimici"].EditedFormattedValue == true)
                        acquisti[e.RowIndex].quantitaMelanimici = true;
                    else
                        acquisti[e.RowIndex].quantitaMelanimici = false;
                }
                if (prodottiAggiunti.Columns["quantitaPuntali"].Index == e.ColumnIndex)
                {
                    checkbox("quantitaPuntali", e);
                    if ((bool)prodottiAggiunti.Rows[e.RowIndex].Cells["quantitaPuntali"].EditedFormattedValue == true)
                        acquisti[e.RowIndex].quantitaPuntali = true;
                    else
                        acquisti[e.RowIndex].quantitaPuntali = false;
                }
                if (prodottiAggiunti.Columns["quantitaRuote"].Index == e.ColumnIndex)
                {
                    checkbox("quantitaRuote", e);
                    if ((bool)prodottiAggiunti.Rows[e.RowIndex].Cells["quantitaRuote"].EditedFormattedValue == true)
                        acquisti[e.RowIndex].quantitaRuote = true;
                    else
                        acquisti[e.RowIndex].quantitaRuote = false;
                }
                if (prodottiAggiunti.Columns["quantitaTerminali"].Index == e.ColumnIndex)
                {
                    checkbox("quantitaTerminali", e);
                    if ((bool)prodottiAggiunti.Rows[e.RowIndex].Cells["quantitaTerminali"].EditedFormattedValue == true)
                        acquisti[e.RowIndex].quantitaTerminali = true;
                    else
                        acquisti[e.RowIndex].quantitaTerminali = false;
                }
                if (prodottiAggiunti.Columns["quantitaBoccola"].Index == e.ColumnIndex)
                {
                    checkbox("quantitaBoccola", e);
                    if ((bool)prodottiAggiunti.Rows[e.RowIndex].Cells["quantitaBoccola"].EditedFormattedValue == true)
                        acquisti[e.RowIndex].quantitaBoccola = true;
                    else
                        acquisti[e.RowIndex].quantitaBoccola = false;
                }
                if (prodottiAggiunti.Columns["quantitaTop"].Index == e.ColumnIndex)
                {
                    checkbox("quantitaTop", e);
                    if ((bool)prodottiAggiunti.Rows[e.RowIndex].Cells["quantitaTop"].EditedFormattedValue == true)
                        acquisti[e.RowIndex].quantitaTop = true;
                    else
                        acquisti[e.RowIndex].quantitaTop = false;
                }
                if (prodottiAggiunti.Columns["quantitaPresa"].Index == e.ColumnIndex)
                {
                    checkbox("quantitaPresa", e);
                    if ((bool)prodottiAggiunti.Rows[e.RowIndex].Cells["quantitaPresa"].EditedFormattedValue == true)
                        acquisti[e.RowIndex].quantitaPresa = true;
                    else
                        acquisti[e.RowIndex].quantitaPresa = false;
                }
                if (prodottiAggiunti.Columns["quantitaMulti2x3"].Index == e.ColumnIndex)
                {
                    checkbox("quantitaTerminali", e);
                    if ((bool)prodottiAggiunti.Rows[e.RowIndex].Cells["quantitaMulti2x3"].EditedFormattedValue == true)
                        acquisti[e.RowIndex].quantitaMulti2x3 = true;
                    else
                        acquisti[e.RowIndex].quantitaMulti2x3 = false;
                }
                if (prodottiAggiunti.Columns["quantitaMulti3x3"].Index == e.ColumnIndex)
                {
                    checkbox("quantitaMulti3x3", e);
                    if ((bool)prodottiAggiunti.Rows[e.RowIndex].Cells["quantitaMulti3x3"].EditedFormattedValue == true)
                        acquisti[e.RowIndex].quantitaMulti3x3 = true;
                    else
                        acquisti[e.RowIndex].quantitaMulti3x3 = false;
                }

                if (aggiunta == false)
                {
                    if (prodottiAggiunti.Columns["prezzoMelanimici"].Index == e.ColumnIndex)
                        modificaPrezzo(e);
                    else if (prodottiAggiunti.Columns["prezzoPuntali"].Index == e.ColumnIndex)
                        modificaPrezzo(e);
                    else if (prodottiAggiunti.Columns["prezzoRuote"].Index == e.ColumnIndex)
                        modificaPrezzo(e);
                    else if (prodottiAggiunti.Columns["prezzoTerminali"].Index == e.ColumnIndex)
                        modificaPrezzo(e);
                    else if (prodottiAggiunti.Columns["prezzoBoccola"].Index == e.ColumnIndex)
                        modificaPrezzo(e);
                    else if (prodottiAggiunti.Columns["prezzoTop"].Index == e.ColumnIndex)
                        modificaPrezzo(e);
                    else if (prodottiAggiunti.Columns["prezzoPresa"].Index == e.ColumnIndex)
                        modificaPrezzo(e);
                    else if (prodottiAggiunti.Columns["prezzoMulti2x3"].Index == e.ColumnIndex)
                        modificaPrezzo(e);
                    else if (prodottiAggiunti.Columns["prezzoMulti3x3"].Index == e.ColumnIndex)
                        modificaPrezzo(e);
                }

                if (prodottiAggiunti.Columns["descrizione"].Index == e.ColumnIndex)
                {
                    string aus = prodottiAggiunti.Rows[e.RowIndex].Cells["descrizione"].Value.ToString();
                    acquisti[e.RowIndex].descrizione = aus;
                    updateListAcquisti();
                }
                if (prodottiAggiunti.Columns["dimensioni"].Index == e.ColumnIndex)
                {
                    string aus = prodottiAggiunti.Rows[e.RowIndex].Cells["dimensioni"].Value.ToString();
                    acquisti[e.RowIndex].dimensioni = aus;
                    updateListAcquisti();
                }
                if (prodottiAggiunti.Columns["quantita"].Index == e.ColumnIndex)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Verifica che l'indice della riga e della colonna siano validi
                    {
                        string aux = acquisti[e.RowIndex].quantita;

                        int row = e.RowIndex;
                        var aus = prodottiAggiunti.Rows[row].Cells["quantita"].Value;
                        int val;

                        // Prova a convertire direttamente se 'aus' è già un tipo numerico.
                        if (aus is int)
                        {
                            val = (int)aus;
                            acquisti[e.RowIndex].quantita = val.ToString();
                        }
                        // Altrimenti, verifica se 'aus' è una stringa che rappresenta un numero intero.
                        else if (int.TryParse(aus.ToString(), out val))
                        {
                            // 'valoreIntero' ha già il valore assegnato tramite 'TryParse'.
                            acquisti[e.RowIndex].quantita = val.ToString();
                        }
                        else
                        {
                            // Se 'aus' non è un intero e non può essere convertito direttamente in un intero,
                            // qui puoi decidere come gestirlo. Ad esempio, potresti voler convertirlo in un intero
                            // utilizzando Convert.ToInt32, gestire un valore predefinito o un errore.
                            try
                            {
                                // Tentativo di conversione forzata usando Convert.ToInt32 che può gestire diversi tipi numerici e stringhe.
                                val = Convert.ToInt32(aus);
                                acquisti[e.RowIndex].quantita = val.ToString();
                            }
                            catch (Exception ex)
                            {
                                // Imposta il valore della cella a 0 in caso di errore di conversione
                                prodottiAggiunti.Rows[row].Cells["quantita"].Value = 0;

                                // Visualizza una MessageBox con il messaggio di errore
                                MessageBox.Show($"ATTENZIONE \nIl valore è stato impostato a 0.", "Valore non valido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        
                        var cost = "";
                        decimal tot = 0;
                        ImpostaModificaDaEsterno();

                        cost = prodottiAggiunti.Rows[row].Cells["prezzoListino"].Value.ToString();
                        if(aux == "0" || acquisti[row].quantita == "0")
                            tot = onlyNum(cost) * decimal.Parse(prodottiAggiunti.Rows[row].Cells["quantita"].Value.ToString());
                        else
                            tot = onlyNum(cost) * decimal.Parse(prodottiAggiunti.Rows[row].Cells["quantita"].Value.ToString()) + 1;

                        string a = tot.ToString("0 €", culture);
                        prodottiAggiunti.Rows[row].Cells["prezzoTotale"].Value = a;
                        prodottiAggiunti.Rows[row].Cells["prezzoTotaleScontato"].Value = a;
                        prodottiAggiunti.Rows[row].Cells["prezzoUnitarioScontato"].Value = a;

                        acquisti[e.RowIndex].prezzoTotale = tot.ToString("0 €", culture);
                        acquisti[e.RowIndex].prezzoUnitarioScontato = tot.ToString("0 €", culture);
                        acquisti[e.RowIndex].prezzoTotaleScontato = tot.ToString("0 €", culture);

                        ReimpostaModificaInterna();

                        modificaPrezzo(e);

                        prezzoScontato(e);
                        prezzoScontatoSecondario(e);
                        setPrezzo();
                        updateListAcquisti();

                        setVisible(e.RowIndex);
                    }
                    else
                        return;
                }
            }
        }

        /// <summary>
        /// The onlyNum
        /// </summary>
        /// <param name="num">The num<see cref="string"/></param>
        /// <returns>The <see cref="decimal"/></returns>
        private decimal onlyNum(string num)
        {
            decimal export = 0;

            // Rimuovi il simbolo € (se presente) e gli spazi, poi prova a convertire
            string numPulito = num.Replace("€", "").Trim();
            if (decimal.TryParse(numPulito, out export))
            {
                // Conversione riuscita, 'export' contiene il numero
                return export;
            }
            else
            {
                // La conversione è fallita, gestisci il caso appropriatamente
                return 0; // o gestisci l'errore in un altro modo che preferisci
            }
        }

        /// <summary>
        /// The prodottiAggiunti_CellClick
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="DataGridViewCellEventArgs"/></param>
        private void prodottiAggiunti_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == prodottiAggiunti.Columns["elimina"].Index)
            {
                int index = e.RowIndex;
                prodottiAggiunti.Rows.RemoveAt(index);
                acquisti.RemoveAt(index);

                setPrezzo();
            }
            if (e.RowIndex >= 0 && e.ColumnIndex == prodottiAggiunti.Columns["immagine"].Index)
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog
                {
                    Filter = "Image files (*.png, *.jpeg)| *.png; *.jpeg;",
                    FilterIndex = 1,
                    RestoreDirectory = true
                };

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string fileExtension = System.IO.Path.GetExtension(openFileDialog1.FileName).ToLower();

                    if (fileExtension == ".png")
                    {
                        Image pngImage = Image.FromFile(openFileDialog1.FileName);
                        MemoryStream ms = new MemoryStream();
                        pngImage.Save(ms, ImageFormat.Jpeg);
                        Image jpegImage = Image.FromStream(ms);

                        // Display the message and load the image
                        prodottiAggiunti.Rows[e.RowIndex].Cells["immagine"].Value = RidimensionaImmagineConProporzioni(jpegImage);
                        acquisti[e.RowIndex].immagine = jpegImage;
                    }
                    else if (fileExtension == ".jpeg")
                    {
                        Image img = Image.FromFile(openFileDialog1.FileName);

                        prodottiAggiunti.Rows[e.RowIndex].Cells["immagine"].Value = RidimensionaImmagineConProporzioni(img);
                        acquisti[e.RowIndex].immagine = img;
                    }
                }
            }
        }

        /// <summary>
        /// The txbxDatiAzienda_Enter
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void txbxDatiAzienda_Enter(object sender, EventArgs e)
        {
            if (txbxDatiAzienda.Text == "DATI AZIENDA")
            {
                txbxDatiAzienda.Text = "";
                txbxDatiAzienda.ForeColor = System.Drawing.Color.Black; // Cambia il colore del testo se necessario
            }
        }

        /// <summary>
        /// The txbxDatiAzienda_Leave
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void txbxDatiAzienda_Leave(object sender, EventArgs e)
        {
            // Se la TextBox è vuota quando perde il focus, aggiungi il testo di esempio
            if (string.IsNullOrWhiteSpace(txbxDatiAzienda.Text) && string.IsNullOrWhiteSpace(azienda))
            {
                txbxDatiAzienda.Text = "DATI AZIENDA";
                txbxDatiAzienda.ForeColor = System.Drawing.Color.Gray; // Cambia il colore del testo per distinguere il testo di esempio
            }
        }

        /// <summary>
        /// The txtLuogo_Enter
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void txtLuogo_Enter(object sender, EventArgs e)
        {
            if (txtLuogo.Text == "Luogo")
            {
                txtLuogo.Text = "";
                txtLuogo.ForeColor = System.Drawing.Color.Black; // Cambia il colore del testo se necessario
            }
        }

        /// <summary>
        /// The txtLuogo_Leave
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void txtLuogo_Leave(object sender, EventArgs e)
        {
            // Se la TextBox è vuota quando perde il focus, aggiungi il testo di esempio
            if (string.IsNullOrWhiteSpace(txtLuogo.Text) && string.IsNullOrWhiteSpace(luogo))
            {
                txtLuogo.Text = "Luogo";
                txtLuogo.ForeColor = System.Drawing.Color.Gray; // Cambia il colore del testo per distinguere il testo di esempio
            }
        }

        /// <summary>
        /// The RidimensionaImmagineConProporzioni
        /// </summary>
        /// <param name="immagineOriginale">The immagineOriginale<see cref="Image"/></param>
        /// <returns>The <see cref="Image"/></returns>
        public static Image RidimensionaImmagineConProporzioni(Image immagineOriginale)
        {
            float fattoreScala;
            int larghezzaDesiderata, altezzaDesiderata;
            int dimensioneMassima = 100;

            // Verifica se l'immagine è più larga che alta (orientamento orizzontale)
            if (immagineOriginale.Width > immagineOriginale.Height)
            {
                // Mantieni la larghezza a dimensioneMassima e calcola l'altezza proporzionale
                fattoreScala = (float)dimensioneMassima / immagineOriginale.Width;
                larghezzaDesiderata = dimensioneMassima;
                altezzaDesiderata = (int)(immagineOriginale.Height * fattoreScala);
            }
            else
            {
                // Mantieni l'altezza a dimensioneMassima e calcola la larghezza proporzionale
                fattoreScala = (float)dimensioneMassima / immagineOriginale.Height;
                altezzaDesiderata = dimensioneMassima;
                larghezzaDesiderata = (int)(immagineOriginale.Width * fattoreScala);
            }

            var immagineRidimensionata = new Bitmap(larghezzaDesiderata, altezzaDesiderata);
            using (var graphics = Graphics.FromImage(immagineRidimensionata))
            {
                graphics.DrawImage(immagineOriginale, 0, 0, larghezzaDesiderata, altezzaDesiderata);
            }

            return immagineRidimensionata;
        }

        /// <summary>
        /// The MainView_Load
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void MainView_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The propertyName
        /// </summary>
        private void propertyName()
        {
            this.prodottiAggiunti.Columns["codice"].DataPropertyName = "codice";
            this.prodottiAggiunti.Columns["immagine"].DataPropertyName = "immagine";
            this.prodottiAggiunti.Columns["descrizione"].DataPropertyName = "descrizione";
            this.prodottiAggiunti.Columns["dimensioni"].DataPropertyName = "dimensioni";
            this.prodottiAggiunti.Columns["quantita"].DataPropertyName = "quantita";
            this.prodottiAggiunti.Columns["prezzoListino"].DataPropertyName = "prezzoListino";
            this.prodottiAggiunti.Columns["prezzoTotale"].DataPropertyName = "prezzoTotale";
            this.prodottiAggiunti.Columns["prezzoUnitarioScontato"].DataPropertyName = "prezzoUnitarioScontato";
            this.prodottiAggiunti.Columns["prezzoTotaleScontato"].DataPropertyName = "prezzoTotaleScontato";
            this.prodottiAggiunti.Columns["quantitaMelanimici"].DataPropertyName = "quantitaMelanimici";
            this.prodottiAggiunti.Columns["prezzoMelanimici"].DataPropertyName = "prezzoMelanimici";
            this.prodottiAggiunti.Columns["quantitaPuntali"].DataPropertyName = "quantitaPuntali";
            this.prodottiAggiunti.Columns["prezzoPuntali"].DataPropertyName = "prezzoPuntali";
            this.prodottiAggiunti.Columns["quantitaRuote"].DataPropertyName = "quantitaRuote";
            this.prodottiAggiunti.Columns["prezzoRuote"].DataPropertyName = "prezzoRuote";
            this.prodottiAggiunti.Columns["quantitaTerminali"].DataPropertyName = "quantitaTerminali";
            this.prodottiAggiunti.Columns["prezzoTerminali"].DataPropertyName = "prezzoTerminali";
            this.prodottiAggiunti.Columns["quantitaBoccola"].DataPropertyName = "quantitaBoccola";
            this.prodottiAggiunti.Columns["prezzoBoccola"].DataPropertyName = "prezzoBoccola";
            this.prodottiAggiunti.Columns["quantitaTop"].DataPropertyName = "quantitaTop";
            this.prodottiAggiunti.Columns["prezzoTop"].DataPropertyName = "prezzoTop";
            this.prodottiAggiunti.Columns["quantitaPresa"].DataPropertyName = "quantitaPresa";
            this.prodottiAggiunti.Columns["prezzoPresa"].DataPropertyName = "prezzoPresa";
            this.prodottiAggiunti.Columns["quantitaMulti2x3"].DataPropertyName = "quantitaMulti2x3";
            this.prodottiAggiunti.Columns["prezzoMulti2x3"].DataPropertyName = "prezzoMulti2x3";
            this.prodottiAggiunti.Columns["quantitaMulti3x3"].DataPropertyName = "quantitaMulti3x3";
            this.prodottiAggiunti.Columns["prezzoMulti3x3"].DataPropertyName = "prezzoMulti3x3";
        }

        /// <summary>
        /// The AggiungiProdotto
        /// </summary>
        /// <param name="aux">The aux<see cref="string"/></param>
        public void AggiungiProdotto(string aux)
        {
            ImpostaModificaDaEsterno();
            aggiunta = true;

            // Aggiungi il prodotto alla lista di acquisti
            acquisti.Add(database.find(aux));

            // Ottieni l'indice della nuova riga
            int rowIndex = prodottiAggiunti.Rows.Add();

            // Assumi che "RidimensionaImmagineConProporzioni" accetti un'immagine e ritorni un'immagine ridimensionata
            Image immagineRidimensionata = null;
            if (acquisti[rowIndex].immagine != null)
            {
                immagineRidimensionata = RidimensionaImmagineConProporzioni(acquisti[rowIndex].immagine);
            }

            // Assegna i valori alle celle, inclusa l'immagine ridimensionata
            prodottiAggiunti.Rows[rowIndex].Cells["codice"].Value = acquisti[rowIndex].codice;
            prodottiAggiunti.Rows[rowIndex].Cells["immagine"].Value = immagineRidimensionata; // Usa l'immagine ridimensionata
            prodottiAggiunti.Rows[rowIndex].Cells["dimensioni"].Value = acquisti[rowIndex].dimensioni;
            prodottiAggiunti.Rows[rowIndex].Cells["prezzoListino"].Value = acquisti[rowIndex].prezzoListino;
            prodottiAggiunti.Rows[rowIndex].Cells["prezzoMelanimici"].Value = acquisti[rowIndex].prezzoMelanimici;
            prodottiAggiunti.Rows[rowIndex].Cells["prezzoPuntali"].Value = acquisti[rowIndex].prezzoPuntali;
            prodottiAggiunti.Rows[rowIndex].Cells["prezzoRuote"].Value = acquisti[rowIndex].prezzoRuote;
            prodottiAggiunti.Rows[rowIndex].Cells["prezzoTerminali"].Value = acquisti[rowIndex].prezzoTerminali;
            prodottiAggiunti.Rows[rowIndex].Cells["descrizione"].Value = acquisti[rowIndex].descrizione;
            prodottiAggiunti.Rows[rowIndex].Cells["prezzoTotale"].Value = acquisti[rowIndex].prezzoTotale;
            prodottiAggiunti.Rows[rowIndex].Cells["prezzoUnitarioScontato"].Value = acquisti[rowIndex].prezzoUnitarioScontato;
            prodottiAggiunti.Rows[rowIndex].Cells["prezzoTotaleScontato"].Value = acquisti[rowIndex].prezzoTotaleScontato;
            prodottiAggiunti.Rows[rowIndex].Cells["quantita"].Value = acquisti[rowIndex].quantita;
            prodottiAggiunti.Rows[rowIndex].Cells["prezzoBoccola"].Value = acquisti[rowIndex].prezzoBoccola;
            prodottiAggiunti.Rows[rowIndex].Cells["prezzoTop"].Value = acquisti[rowIndex].prezzoTop;
            prodottiAggiunti.Rows[rowIndex].Cells["prezzoPresa"].Value = acquisti[rowIndex].prezzoPresa;
            prodottiAggiunti.Rows[rowIndex].Cells["prezzoMulti2x3"].Value = acquisti[rowIndex].prezzoMulti2x3;
            prodottiAggiunti.Rows[rowIndex].Cells["prezzoMulti3x3"].Value = acquisti[rowIndex].prezzoMulti3x3;

            setVisible(rowIndex);

            ReimpostaModificaInterna();
            aggiunta = false;
        }

        /// <summary>
        /// The setVisibleName
        /// </summary>
        /// <param name="name">The name<see cref="string"/></param>
        /// <param name="index">The index<see cref="int"/></param>
        private void setVisibleName(string name, int index)
        {
            List<string> list = new List<string>() { "0 €", "0", "", "ND" };
            int col = prodottiAggiunti.Columns[name].Index - 1;
            if (prodottiAggiunti.Rows[index].Cells[name].Value == null ||
                string.Equals(prodottiAggiunti.Rows[index].Cells[name].Value.ToString(), list[0], StringComparison.OrdinalIgnoreCase) ||
                string.Equals(prodottiAggiunti.Rows[index].Cells[name].Value.ToString(), list[1], StringComparison.OrdinalIgnoreCase) ||
                string.Equals(prodottiAggiunti.Rows[index].Cells[name].Value.ToString(), list[2], StringComparison.OrdinalIgnoreCase) ||
                string.Equals(prodottiAggiunti.Rows[index].Cells[name].Value.ToString(), list[3], StringComparison.OrdinalIgnoreCase))
            {
                prodottiAggiunti.Rows[index].Cells[name].Value = "ND";
                prodottiAggiunti.Rows[index].Cells[col].ReadOnly = true;
            }
            else
                prodottiAggiunti.Rows[index].Cells[col].ReadOnly = false;
        }

        /// <summary>
        /// The setVisibleValue
        /// </summary>
        /// <param name="name">The name<see cref="string"/></param>
        /// <param name="index">The index<see cref="int"/></param>
        private void setVisibleValue(string name, int index)
        {
            prodottiAggiunti.Rows[index].Cells[name].Value = false;
        }

        /// <summary>
        /// The setVisible
        /// </summary>
        /// <param name="index">The index<see cref="int"/></param>
        public void setVisible(int index)
        {
            ImpostaModificaDaEsterno();
            if (prodottiAggiunti.Rows[index].Cells["quantita"].Value.ToString() != "0")
            {
                setVisibleName("prezzoMelanimici", index);
                setVisibleName("prezzoPuntali", index);
                setVisibleName("prezzoRuote", index);
                setVisibleName("prezzoTerminali", index);
                setVisibleName("prezzoBoccola", index);
                setVisibleName("prezzoTop", index);
                setVisibleName("prezzoPresa", index);
                setVisibleName("prezzoMulti2x3", index);
                setVisibleName("prezzoMulti3x3", index);
            }
            else
            {
                prodottiAggiunti.Rows[index].Cells["quantitaMelanimici"].ReadOnly = true;
                prodottiAggiunti.Rows[index].Cells["quantitaPuntali"].ReadOnly = true;
                prodottiAggiunti.Rows[index].Cells["quantitaRuote"].ReadOnly = true;
                prodottiAggiunti.Rows[index].Cells["quantitaTerminali"].ReadOnly = true;
                prodottiAggiunti.Rows[index].Cells["quantitaBoccola"].ReadOnly = true;
                prodottiAggiunti.Rows[index].Cells["quantitaTop"].ReadOnly = true;
                prodottiAggiunti.Rows[index].Cells["quantitaPresa"].ReadOnly = true;
                prodottiAggiunti.Rows[index].Cells["quantitaMulti2x3"].ReadOnly = true;
                prodottiAggiunti.Rows[index].Cells["quantitaMulti3x3"].ReadOnly = true;

                setVisibleValue("quantitaMelanimici", index);
                setVisibleValue("quantitaPuntali", index);
                setVisibleValue("quantitaRuote", index);
                setVisibleValue("quantitaTerminali", index);
                setVisibleValue("quantitaBoccola", index);
                setVisibleValue("quantitaTop", index);
                setVisibleValue("quantitaPresa", index);
                setVisibleValue("quantitaMulti2x3", index);
                setVisibleValue("quantitaMulti3x3", index);
            }
            ReimpostaModificaInterna();
        }

        /// <summary>
        /// The updateListAcquisti
        /// </summary>
        private void updateListAcquisti()
        {
            foreach (DataGridViewRow row in prodottiAggiunti.Rows)
            {
                if (!row.IsNewRow) // Ignora la riga di inserimento nuovo
                {
                    string codice = row.Cells["Codice"].Value?.ToString();
                    Acquisti acquistoEsistente = acquisti.FirstOrDefault(a => a.codice == codice);

                    if (acquistoEsistente != null)
                    {
                        // Aggiorna solo i campi specifici dell'oggetto Acquisto trovato
                        acquistoEsistente.descrizione = row.Cells["descrizione"].Value?.ToString();
                        acquistoEsistente.quantita = row.Cells["quantita"].Value?.ToString();
                        if (row.Cells["quantitaMelanimici"].Value != null)
                            acquistoEsistente.quantitaMelanimici = Convert.ToBoolean(row.Cells["quantitaMelanimici"].Value);
                        else
                            acquistoEsistente.quantitaMelanimici = false; // o true, a seconda della logica desiderata
                        if (row.Cells["quantitaPuntali"].Value != null)
                            acquistoEsistente.quantitaPuntali = Convert.ToBoolean(row.Cells["quantitaPuntali"].Value);
                        else
                            acquistoEsistente.quantitaPuntali = false; // o true, a seconda della logica desiderata
                        if (row.Cells["quantitaTerminali"].Value != null)
                            acquistoEsistente.quantitaTerminali = Convert.ToBoolean(row.Cells["quantitaTerminali"].Value);
                        else
                            acquistoEsistente.quantitaTerminali = false; // o true, a seconda della logica desiderata
                        if (row.Cells["quantitaRuote"].Value != null)
                            acquistoEsistente.quantitaRuote = Convert.ToBoolean(row.Cells["quantitaRuote"].Value);
                        else
                            acquistoEsistente.quantitaRuote = false; // o true, a seconda della logica desiderata

                        acquistoEsistente.prezzoMelanimici = row.Cells["prezzoMelanimici"].Value?.ToString();
                        acquistoEsistente.prezzoPuntali = row.Cells["prezzoPuntali"].Value?.ToString();
                        acquistoEsistente.prezzoRuote = row.Cells["prezzoRuote"].Value?.ToString();
                        acquistoEsistente.prezzoTerminali = row.Cells["prezzoTerminali"].Value?.ToString();
                        acquistoEsistente.prezzoTotale = row.Cells["prezzoTotale"].Value?.ToString();
                        acquistoEsistente.prezzoUnitarioScontato = row.Cells["prezzoUnitarioScontato"].Value?.ToString();
                        acquistoEsistente.prezzoTotaleScontato = row.Cells["prezzoTotaleScontato"].Value?.ToString();

                        if (row.Cells["quantitaBoccola"].Value != null)
                            acquistoEsistente.quantitaBoccola = Convert.ToBoolean(row.Cells["quantitaBoccola"].Value);
                        else
                            acquistoEsistente.quantitaBoccola = false; // o true, a seconda della logica desiderata
                        if (row.Cells["quantitaTop"].Value != null)
                            acquistoEsistente.quantitaTop = Convert.ToBoolean(row.Cells["quantitaTop"].Value);
                        else
                            acquistoEsistente.quantitaTop = false; // o true, a seconda della logica desiderata
                        if (row.Cells["quantitaPresa"].Value != null)
                            acquistoEsistente.quantitaPresa = Convert.ToBoolean(row.Cells["quantitaPresa"].Value);
                        else
                            acquistoEsistente.quantitaPresa = false; // o true, a seconda della logica desiderata
                        if (row.Cells["quantitaMulti2x3"].Value != null)
                            acquistoEsistente.quantitaMulti2x3 = Convert.ToBoolean(row.Cells["quantitaMulti2x3"].Value);
                        else
                            acquistoEsistente.quantitaMulti2x3 = false; // o true, a seconda della logica desiderata
                        if (row.Cells["quantitaMulti3x3"].Value != null)
                            acquistoEsistente.quantitaMulti3x3 = Convert.ToBoolean(row.Cells["quantitaMulti3x3"].Value);
                        else
                            acquistoEsistente.quantitaMulti3x3 = false; // o true, a seconda della logica desiderata

                        acquistoEsistente.prezzoBoccola = row.Cells["prezzoBoccola"].Value?.ToString();
                        acquistoEsistente.prezzoTop = row.Cells["prezzoTop"].Value?.ToString();
                        acquistoEsistente.prezzoPresa = row.Cells["prezzoPresa"].Value?.ToString();
                        acquistoEsistente.prezzoMulti2x3 = row.Cells["prezzoMulti2x3"].Value?.ToString();
                        acquistoEsistente.prezzoMulti3x3 = row.Cells["prezzoMulti3x3"].Value?.ToString();
                    }
                }
            }
        }

        /// <summary>
        /// The btnPdf_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnPdf_Click(object sender, EventArgs e)
        {
            string lblPrezzo = label2.Text.Trim().Replace("\n", " ").Replace("\r", " ");
            string azienda = txbxDatiAzienda.Text.Trim();
            string ausiliare = lblAusiliare.Text.Trim();
            string luogoData = txtLuogo.Text.Trim() + ", " + lblData.Text;
            string prezzo = lblPrezzoNetto.Text;
            string lblCondizioni = label3.Text;
            string condizioni = label4.Text + " " + txtPagamento.Text.Trim() + "\n" +
                label5.Text + " " + txtValidita.Text.Trim() + "\n" +
                label6.Text + " " + txtIva.Text.Trim() + "\n" +
                label7.Text + " " + txtTempi.Text.Trim() + "\n" +
                label8.Text + "\n" +
                label9.Text + " " + txtMontaggio.Text.Trim();
            string servizi = label10.Text;

            updateListAcquisti();
            pdf.CreatePdf(azienda, ausiliare, luogoData, lblPrezzo, prezzo, lblCondizioni, condizioni, servizi, acquisti);

            MessageBox.Show("File esportato con successo", "Successo!");
        }

        /// <summary>
        /// The ReloadOnLoad
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void ReloadOnLoad(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Sei sicuro di voler caricare il file? \n" +
                    "Tutti i dati non salvati andranno persi", "Conferma Caricamento", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                // L'utente ha confermato di voler cancellare e ricominciare
                this.Controls.Clear(); // Rimuove tutti i controlli dal form

                InitializeComponent(); // Ricrea i controlli (se usi Windows Forms Designer)
                setForm();
            }
        }

        /// <summary>
        /// The MainView_Resize
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void MainView_Resize(object sender, EventArgs e)
        {
            //DO STUFF
            this.prodottiAggiunti.Width = this.Width - 25;
        }

        /// <summary>
        /// The tbsSave_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void tbsSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveFileDialog.Title = "Salva come";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Assicurati che il nome del file non sia vuoto
                    if (!string.IsNullOrWhiteSpace(saveFileDialog.FileName))
                    {
                        // Assumi che acquisti sia la tua lista di oggetti da salvare
                        excel.SalvaDatiInExcelEPPlus(saveFileDialog.FileName, acquisti, sconto, txbxDatiAzienda.Text, txtLuogo.Text,
                            txtPagamento.Text, txtValidita.Text, txtIva.Text, txtTempi.Text, txtMontaggio.Text, lblPrezzoNetto.Text, scontoSecondario, ExtraSconto);
                        MessageBox.Show("Il file è stato salvato!", "SALVATAGGIO");
                    }
                }
            }
        }

        /// <summary>
        /// The setValue
        /// </summary>
        /// <param name="sconto">The sconto<see cref="string"/></param>
        /// <param name="dati">The dati<see cref="string"/></param>
        /// <param name="luogo">The luogo<see cref="string"/></param>
        /// <param name="pagamento">The pagamento<see cref="string"/></param>
        /// <param name="validita">The validita<see cref="string"/></param>
        /// <param name="iva">The iva<see cref="string"/></param>
        /// <param name="tempi">The tempi<see cref="string"/></param>
        /// <param name="montaggio">The montaggio<see cref="string"/></param>
        /// <param name="totale">The totale<see cref="string"/></param>
        /// <param name="scontoSecondario">The scontoSecondario<see cref="string"/></param>
        /// <param name="flag">The flag<see cref="bool"/></param>
        public void setValue(string sconto, string dati, string luogo, string pagamento, string validita, string iva,
            string tempi, string montaggio, string totale, string scontoSecondario, bool flag)
        {
            this.txtSconto.Text = sconto;
            setSconto();

            this.txbxDatiAzienda.Text = dati;
            this.azienda = dati;
            txbxDatiAzienda.ForeColor = System.Drawing.Color.Black;
            this.txtLuogo.Text = luogo;
            this.luogo = luogo;
            txtLuogo.ForeColor = System.Drawing.Color.Black;

            this.txtPagamento.Text = pagamento;
            this.txtValidita.Text = validita;
            this.txtIva.Text = iva;
            this.txtTempi.Text = tempi;
            this.txtMontaggio.Text = montaggio;
            this.lblPrezzoNetto.Text = totale;
            this.txtScontoSecondario.Text = scontoSecondario;
            setScontoSecondario();

            if (flag)
                btnExtraSconto_Click(this, new EventArgs());
        }

        /// <summary>
        /// The tbsLoad_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void tbsLoad_Click(object sender, EventArgs e)
        {

            List<Acquisti> list = new List<Acquisti>();
            int index = 0;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                openFileDialog.Title = "Apri file Excel";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Assicurati che il nome del file non sia vuoto
                    if (!string.IsNullOrWhiteSpace(openFileDialog.FileName))
                    {
                        try
                        {
                            ReloadOnLoad(sender, e);
                            list = excel.CaricaDatiDaExcelEPPlus(openFileDialog.FileName, this);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Errore durante il caricamento del file: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            ImpostaModificaDaEsterno();

            acquisti = list;

            foreach (Acquisti item in list)
            {
                prodottiAggiunti.Rows.Add();
                prodottiAggiunti.Rows[index].Cells["codice"].Value = item.codice;
                prodottiAggiunti.Rows[index].Cells["immagine"].Value = RidimensionaImmagineConProporzioni(item.immagine);
                prodottiAggiunti.Rows[index].Cells["descrizione"].Value = item.descrizione;
                prodottiAggiunti.Rows[index].Cells["dimensioni"].Value = item.dimensioni;
                prodottiAggiunti.Rows[index].Cells["quantita"].Value = item.quantita;
                prodottiAggiunti.Rows[index].Cells["prezzoListino"].Value = item.prezzoListino;
                prodottiAggiunti.Rows[index].Cells["prezzoTotale"].Value = item.prezzoTotale;
                prodottiAggiunti.Rows[index].Cells["prezzoUnitarioScontato"].Value = item.prezzoUnitarioScontato;
                prodottiAggiunti.Rows[index].Cells["prezzoTotaleScontato"].Value = item.prezzoTotaleScontato;
                prodottiAggiunti.Rows[index].Cells["quantitaMelanimici"].Value = item.quantitaMelanimici ? true : false;
                prodottiAggiunti.Rows[index].Cells["prezzoMelanimici"].Value = item.prezzoMelanimici;
                prodottiAggiunti.Rows[index].Cells["quantitaPuntali"].Value = item.quantitaPuntali ? true : false;
                prodottiAggiunti.Rows[index].Cells["prezzoPuntali"].Value = item.prezzoPuntali;
                prodottiAggiunti.Rows[index].Cells["quantitaRuote"].Value = item.quantitaRuote ? true : false;
                prodottiAggiunti.Rows[index].Cells["prezzoRuote"].Value = item.prezzoRuote;
                prodottiAggiunti.Rows[index].Cells["quantitaTerminali"].Value = item.quantitaTerminali ? true : false;
                prodottiAggiunti.Rows[index].Cells["prezzoTerminali"].Value = item.prezzoTerminali;
                prodottiAggiunti.Rows[index].Cells["quantitaBoccola"].Value = item.quantitaBoccola ? true : false;
                prodottiAggiunti.Rows[index].Cells["prezzoBoccola"].Value = item.prezzoBoccola;
                prodottiAggiunti.Rows[index].Cells["quantitaTop"].Value = item.quantitaTop ? true : false;
                prodottiAggiunti.Rows[index].Cells["prezzoTop"].Value = item.prezzoTop;
                prodottiAggiunti.Rows[index].Cells["quantitaPresa"].Value = item.quantitaPresa ? true : false;
                prodottiAggiunti.Rows[index].Cells["prezzoPresa"].Value = item.prezzoPresa;
                prodottiAggiunti.Rows[index].Cells["quantitaMulti2x3"].Value = item.quantitaMulti2x3 ? true : false;
                prodottiAggiunti.Rows[index].Cells["prezzoMulti2x3"].Value = item.prezzoMulti2x3;
                prodottiAggiunti.Rows[index].Cells["quantitaMulti3x3"].Value = item.quantitaMulti3x3 ? true : false;
                prodottiAggiunti.Rows[index].Cells["prezzoMulti3x3"].Value = item.prezzoMulti3x3;
                index++;
            }

            int i = prodottiAggiunti.RowCount;
            for(int aux = 0; aux < i; aux++)
                setVisible(aux);

            ReimpostaModificaInterna();
        }

        /// <summary>
        /// The tsbNew_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void tsbNew_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Sei sicuro di voler creare un nuovo file? \n" +
                    "Potresti perdere tutti i dati non salvati", "Conferma Chiusura", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                luogo = "";
                azienda = "";
                acquisti.Clear();
                // L'utente ha confermato di voler cancellare e ricominciare
                this.Controls.Clear(); // Rimuove tutti i controlli dal form

                InitializeComponent(); // Ricrea i controlli
                setForm();
            }
        }

        /// <summary>
        /// The btnEsportaExcel_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnEsportaExcel_Click(object sender, EventArgs e)
        {
            if (!IsExcelOpen())
            {
                // Do something if Excel is not open.
                string lblPrezzo = label2.Text.Trim().Replace("\n", " ").Replace("\r", " ");
                string azienda = txbxDatiAzienda.Text.Trim();
                string ausiliare = lblAusiliare.Text.Trim();
                string luogoData = txtLuogo.Text.Trim() + ", " + lblData.Text;
                string prezzo = lblPrezzoNetto.Text;
                string lblCondizioni = label3.Text;
                string condizioni = label4.Text + " " + txtPagamento.Text.Trim() + Environment.NewLine +
                       label5.Text + " " + txtValidita.Text.Trim() + Environment.NewLine +
                       label6.Text + " " + txtIva.Text.Trim() + Environment.NewLine +
                       label7.Text + " " + txtTempi.Text.Trim() + Environment.NewLine +
                       label8.Text + Environment.NewLine +
                       label9.Text + " " + txtMontaggio.Text.Trim();
                string servizi = label10.Text;

                updateListAcquisti();

                ExcelManager.CreateExcel(azienda, ausiliare, luogoData, lblPrezzo, prezzo, lblCondizioni,
                    condizioni, servizi, acquisti);

                MessageBox.Show("File esportato con successo", "Successo!");
            }
            else
            {
                // Do something if Excel is already open.
                MessageBox.Show("File attualmente aperto, \nchiuderlo prima di eseguire il salvataggio", "Errore!");
            }
        }

        /// <summary>
        /// The IsExcelOpen
        /// </summary>
        /// <returns>The <see cref="bool"/></returns>
        public bool IsExcelOpen()
        {
            try
            {
                var excelApp = Marshal.GetActiveObject("Excel.Application");
                return true;
            }
            catch (COMException)
            {
                return false;
            }
        }

        /// <summary>
        /// The btnExtraSconto_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnExtraSconto_Click(object sender, EventArgs e)
        {
            btnExtraSconto.Visible = false;
            tableLayoutPanel4.Visible = true;

            ExtraSconto = true;
        }
    }
}
