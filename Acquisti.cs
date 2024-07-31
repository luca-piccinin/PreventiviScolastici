namespace PreventiviScolastici
{
    using System.Drawing;

    /// <summary>
    /// Defines the <see cref="Acquisti" />
    /// </summary>
    public class Acquisti : Listino
    {
        /// <summary>
        /// Gets or sets the quantita
        /// </summary>
        public string quantita { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether quantitaMelanimici
        /// </summary>
        public bool quantitaMelanimici { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether quantitaPuntali
        /// </summary>
        public bool quantitaPuntali { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether quantitaRuote
        /// </summary>
        public bool quantitaRuote { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether quantitaTerminali
        /// </summary>
        public bool quantitaTerminali { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether quantitaBoccola
        /// </summary>
        public bool quantitaBoccola { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether quantitaTop
        /// </summary>
        public bool quantitaTop { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether quantitaPresa
        /// </summary>
        public bool quantitaPresa { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether quantitaMulti2x3
        /// </summary>
        public bool quantitaMulti2x3 { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether quantitaMulti3x3
        /// </summary>
        public bool quantitaMulti3x3 { get; set; }

        /// <summary>
        /// Gets or sets the prezzoTotale
        /// </summary>
        public string prezzoTotale { get; set; }

        /// <summary>
        /// Gets or sets the prezzoUnitarioScontato
        /// </summary>
        public string prezzoUnitarioScontato { get; set; }

        /// <summary>
        /// Gets or sets the prezzoTotaleScontato
        /// </summary>
        public string prezzoTotaleScontato { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Acquisti"/> class.
        /// </summary>
        public Acquisti() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Acquisti"/> class.
        /// </summary>
        /// <param name="codice">The codice<see cref="string"/></param>
        /// <param name="immagine">The immagine<see cref="Image"/></param>
        /// <param name="descrizione">The descrizione<see cref="string"/></param>
        /// <param name="larghezza">The larghezza<see cref="string"/></param>
        /// <param name="profondità">The profondità<see cref="string"/></param>
        /// <param name="altezza">The altezza<see cref="string"/></param>
        /// <param name="dimensioni">The dimensioni<see cref="string"/></param>
        /// <param name="prezzoListino">The prezzoListino<see cref="string"/></param>
        /// <param name="prezzoMelanimici">The prezzoMelanimici<see cref="string"/></param>
        /// <param name="prezzoPuntali">The prezzoPuntali<see cref="string"/></param>
        /// <param name="prezzoRuote">The prezzoRuote<see cref="string"/></param>
        /// <param name="prezzoTerminali">The prezzoTerminali<see cref="string"/></param>
        /// <param name="prezzoBoccola">The prezzoBoccola<see cref="string"/></param>
        /// <param name="prezzoTop">The prezzoTop<see cref="string"/></param>
        /// <param name="prezzoPresa">The prezzoPresa<see cref="string"/></param>
        /// <param name="prezzoMulti2x3">The prezzoMulti2x3<see cref="string"/></param>
        /// <param name="prezzoMulti3x3">The prezzoMulti3x3<see cref="string"/></param>
        /// <param name="quantita">The quantita<see cref="string"/></param>
        /// <param name="quantitaMelanimici">The quantitaMelanimici<see cref="bool"/></param>
        /// <param name="quantitaPuntali">The quantitaPuntali<see cref="bool"/></param>
        /// <param name="quantitaRuote">The quantitaRuote<see cref="bool"/></param>
        /// <param name="quantitaTerminali">The quantitaTerminali<see cref="bool"/></param>
        /// <param name="quantitaBoccola">The quantitaBoccola<see cref="bool"/></param>
        /// <param name="quantitaTop">The quantitaTop<see cref="bool"/></param>
        /// <param name="quantitaPresa">The quantitaPresa<see cref="bool"/></param>
        /// <param name="qauntitaMulti2x3">The qauntitaMulti2x3<see cref="bool"/></param>
        /// <param name="quantitaMulti3x3">The quantitaMulti3x3<see cref="bool"/></param>
        /// <param name="prezzoTotale">The prezzoTotale<see cref="string"/></param>
        /// <param name="prezzoUnitarioScontato">The prezzoUnitarioScontato<see cref="string"/></param>
        /// <param name="prezzoTotaleScontato">The prezzoTotaleScontato<see cref="string"/></param>
        public Acquisti(string codice, Image immagine, string descrizione, string larghezza, string profondità, string altezza,
                        string dimensioni, string prezzoListino, string prezzoMelanimici, string prezzoPuntali, string prezzoRuote,
                        string prezzoTerminali, string prezzoBoccola, string prezzoTop, string prezzoPresa, string prezzoMulti2x3,
                        string prezzoMulti3x3, string quantita, bool quantitaMelanimici, bool quantitaPuntali,
                        bool quantitaRuote, bool quantitaTerminali, bool quantitaBoccola, bool quantitaTop, bool quantitaPresa,
                        bool qauntitaMulti2x3, bool quantitaMulti3x3, string prezzoTotale, string prezzoUnitarioScontato,
                        string prezzoTotaleScontato)
            : base(codice, immagine, descrizione, larghezza, profondità,
                altezza, dimensioni, prezzoListino, prezzoMelanimici,
                prezzoPuntali, prezzoRuote, prezzoTerminali, prezzoBoccola,
                prezzoTop, prezzoPresa, prezzoMulti2x3, prezzoMulti3x3)
        {
            this.quantita = quantita;
            this.quantitaMelanimici = quantitaMelanimici;
            this.quantitaPuntali = quantitaPuntali;
            this.quantitaRuote = quantitaRuote;
            this.quantitaTerminali = quantitaTerminali;
            this.prezzoTotale = prezzoTotale;
            this.prezzoUnitarioScontato = prezzoUnitarioScontato;
            this.prezzoTotaleScontato = prezzoTotaleScontato;
            this.quantitaBoccola = quantitaBoccola;
            this.quantitaTop = quantitaTop;
            this.quantitaPresa = quantitaPresa;
            this.quantitaMulti2x3 = qauntitaMulti2x3;
            this.quantitaMulti3x3 = quantitaMulti3x3;
        }
    }
}
