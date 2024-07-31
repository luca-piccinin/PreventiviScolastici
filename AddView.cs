namespace PreventiviScolastici
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Reflection;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="AddView" />
    /// </summary>
    public partial class AddView : Form
    {
        // Imposta la cultura italiana (it-IT) che utilizza la virgola come separatore decimale

        /// <summary>
        /// Defines the culture
        /// </summary>
        internal System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("it-IT");

        /// <summary>
        /// Defines the dbData
        /// </summary>
        private Database dbData = new Database();

        /// <summary>
        /// Defines the dbImmagini
        /// </summary>
        private DataBaseImmagini dbImmagini = new DataBaseImmagini();

        /// <summary>
        /// Gets or sets the IstanzaCorrente
        /// </summary>
        public static AddView IstanzaCorrente { get; set; }

        /// <summary>
        /// The EnableDoubleBuffering
        /// </summary>
        /// <param name="control">The control<see cref="Control"/></param>
        public void EnableDoubleBuffering(Control control)
        {
            PropertyInfo doubleBufferPropertyInfo = control.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            doubleBufferPropertyInfo.SetValue(control, true, null);
        }

        /// <summary>
        /// The setCentral
        /// </summary>
        private void setCentral()
        {
            sceltaProdotti.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddView"/> class.
        /// </summary>
        public AddView()
        {
            InitializeComponent();
            sceltaProdotti.CellClick += sceltaProdotti_CellClick;
            txbxRicerca.TextChanged += txbxRicerca_TextChanged;
            sceltaProdotti.DataBindingComplete += sceltaProdotti_DataBindingComplete;
            EnableDoubleBuffering(sceltaProdotti);
            setCentral();
            this.WindowState = FormWindowState.Maximized;
            this.FormClosing += MyForm_FormClosing;
            sceltaProdotti.RowTemplate.Height = 100;
            propertyName();
        }

        /// <summary>
        /// The propertyName
        /// </summary>
        private void propertyName()
        {
            this.sceltaProdotti.Columns["codice"].DataPropertyName = "codice";
            this.sceltaProdotti.Columns["immagine"].DataPropertyName = "immagine";
            this.sceltaProdotti.Columns["descrizione"].DataPropertyName = "descrizione";
            this.sceltaProdotti.Columns["larghezza"].DataPropertyName = "larghezza";
            this.sceltaProdotti.Columns["altezza"].DataPropertyName = "altezza";
            this.sceltaProdotti.Columns["profondita"].DataPropertyName = "profondita";
            this.sceltaProdotti.Columns["dimensioni"].DataPropertyName = "dimensioni";
            this.sceltaProdotti.Columns["prezzoListino"].DataPropertyName = "prezzoListino";
            this.sceltaProdotti.Columns["prezzoMelanimici"].DataPropertyName = "prezzoMelanimici";
            this.sceltaProdotti.Columns["prezzoPuntali"].DataPropertyName = "prezzoPuntali";
            this.sceltaProdotti.Columns["prezzoRuote"].DataPropertyName = "prezzoRuote";
            this.sceltaProdotti.Columns["prezzoTerminali"].DataPropertyName = "prezzoTerminali";
            this.sceltaProdotti.Columns["boccolaPassaCavi"].DataPropertyName = "prezzoBoccola";
            this.sceltaProdotti.Columns["magicTop"].DataPropertyName = "prezzoTop";
            this.sceltaProdotti.Columns["presaCirc"].DataPropertyName = "prezzoPresa";
            this.sceltaProdotti.Columns["multipresa2x3"].DataPropertyName = "prezzoMulti2x3";
            this.sceltaProdotti.Columns["multipresa3x3"].DataPropertyName = "prezzoMulti3x3";
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
        /// The MyForm_FormClosing
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="FormClosingEventArgs"/></param>
        private void MyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Puoi controllare la proprietà CloseReason per capire il motivo della chiusura
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // L'utente ha tentato di chiudere il form cliccando sul pulsante di chiusura
                // Qui puoi fare delle operazioni prima della chiusura, ad esempio chiedere conferma
                if (MessageBox.Show("Sei sicuro di voler chiudere?", "Conferma Chiusura", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    // L'utente ha scelto di non chiudere il form, quindi annulla l'operazione di chiusura
                    e.Cancel = true;
                }
                else
                {
                    e.Cancel = false;

                    MainView formDestinazione = MainView.IstanzaCorrente;
                    if (formDestinazione != null && !formDestinazione.IsDisposed)
                    {
                        formDestinazione.Show();
                        formDestinazione.BringToFront();
                        this.Hide();
                    }
                    else
                    {
                        MainView destinazione = new MainView(); // o riferimento esistente
                        destinazione.Show(); // Mostra FormDestinazione se non è già visibile
                        destinazione.BringToFront();
                        this.Hide();
                    }
                }
            }
        }

        /// <summary>
        /// The txbxRicerca_TextChanged
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void txbxRicerca_TextChanged(object sender, EventArgs e)
        {
            sceltaProdotti.SuspendLayout();
            FiltraDati();
            sceltaProdotti.ResumeLayout();
        }

        /// <summary>
        /// The FiltraDati
        /// </summary>
        private void FiltraDati()
        {
            sceltaProdotti.SuspendLayout();

            string testoRicerca = txbxRicerca.Text.ToUpper();

            if (String.IsNullOrWhiteSpace(txbxRicerca.Text))
                Caricamento();
            else
            {
                List<Listino> aux = dbData.Filter(testoRicerca);
                foreach (var prodotto in aux)
                {
                    if (prodotto.immagine != null)
                    {
                        prodotto.immagine = RidimensionaImmagineConProporzioni(prodotto.immagine);
                    }
                }

                sceltaProdotti.DataSource = aux;
            }

            sceltaProdotti.ResumeLayout();
        }

        /// <summary>
        /// The Caricamento
        /// </summary>
        private void Caricamento()
        {
            sceltaProdotti.SuspendLayout();

            List<Listino> lista = dbData.ReadData();

            foreach (var prodotto in lista)
            {
                if (prodotto.immagine != null)
                {
                    prodotto.immagine = RidimensionaImmagineConProporzioni(prodotto.immagine);
                }
            }

            sceltaProdotti.DataSource = lista;

            sceltaProdotti.ResumeLayout();
        }

        /// <summary>
        /// The sceltaProdotti_DataBindingComplete
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="DataGridViewBindingCompleteEventArgs"/></param>
        private void sceltaProdotti_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in sceltaProdotti.Rows)
            {
                Listino oggetto = row.DataBoundItem as Listino;
                if (oggetto != null && oggetto.immagine != null)
                {
                    row.Cells["immagine"].Value = oggetto.immagine;
                }
            }
        }

        /// <summary>
        /// The AddView_Load
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void AddView_Load(object sender, EventArgs e)
        {
            if (LoadData.controllo() == false)
            {
                dbData.DeleteTable();
                dbImmagini.DeleteTable();
                dbData.CreateTable();
                dbImmagini.CreateTable();
                LoadData.CaricaDati();
            }
            Caricamento();
        }

        /// <summary>
        /// The sceltaProdotti_CellClick
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="DataGridViewCellEventArgs"/></param>
        private void sceltaProdotti_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string aux = "";
            // Controlla se il click è avvenuto nella colonna dei pulsanti
            if (e.ColumnIndex == sceltaProdotti.Columns["aggiungi"].Index && e.RowIndex >= 0)
            {
                aux = sceltaProdotti.Rows[e.RowIndex].Cells["codice"].Value.ToString();

                MainView formDestinazione = MainView.IstanzaCorrente;
                if (formDestinazione != null && !formDestinazione.IsDisposed)
                {
                    formDestinazione.Show();
                    formDestinazione.BringToFront();
                    formDestinazione.AggiungiProdotto(aux);
                    this.Hide();
                }
                else
                {
                    MainView destinazione = new MainView(); // o riferimento esistente
                    destinazione.Show(); // Mostra FormDestinazione se non è già visibile
                    destinazione.AggiungiProdotto(aux); // Aggiungi il prodotto al datagridDestinazione
                    destinazione.BringToFront();
                    this.Hide();
                }
            }
        }
    }
}
