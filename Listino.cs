using System.Drawing;

/// <summary>
/// Defines the <see cref="Listino" />
/// </summary>
public class Listino
{
    /// <summary>
    /// Gets or sets the codice
    /// </summary>
    public string codice { get; set; }

    /// <summary>
    /// Gets or sets the immagine
    /// </summary>
    public Image immagine { get; set; }

    /// <summary>
    /// Gets or sets the descrizione
    /// </summary>
    public string descrizione { get; set; }

    /// <summary>
    /// Gets or sets the larghezza
    /// </summary>
    public string larghezza { get; set; }

    /// <summary>
    /// Gets or sets the profondita
    /// </summary>
    public string profondita { get; set; }

    /// <summary>
    /// Gets or sets the altezza
    /// </summary>
    public string altezza { get; set; }

    /// <summary>
    /// Gets or sets the dimensioni
    /// </summary>
    public string dimensioni { get; set; }

    /// <summary>
    /// Gets or sets the prezzoListino
    /// </summary>
    public string prezzoListino { get; set; }

    /// <summary>
    /// Gets or sets the prezzoMelanimici
    /// </summary>
    public string prezzoMelanimici { get; set; }

    /// <summary>
    /// Gets or sets the prezzoPuntali
    /// </summary>
    public string prezzoPuntali { get; set; }

    /// <summary>
    /// Gets or sets the prezzoRuote
    /// </summary>
    public string prezzoRuote { get; set; }

    /// <summary>
    /// Gets or sets the prezzoTerminali
    /// </summary>
    public string prezzoTerminali { get; set; }

    /// <summary>
    /// Gets or sets the prezzoBoccola
    /// </summary>
    public string prezzoBoccola { get; set; }

    /// <summary>
    /// Gets or sets the prezzoTop
    /// </summary>
    public string prezzoTop { get; set; }

    /// <summary>
    /// Gets or sets the prezzoPresa
    /// </summary>
    public string prezzoPresa { get; set; }

    /// <summary>
    /// Gets or sets the prezzoMulti2x3
    /// </summary>
    public string prezzoMulti2x3 { get; set; }

    /// <summary>
    /// Gets or sets the prezzoMulti3x3
    /// </summary>
    public string prezzoMulti3x3 { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Listino"/> class.
    /// </summary>
    public Listino()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Listino"/> class.
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
    public Listino(string codice, Image immagine, string descrizione, string larghezza, string profondità, string altezza,
                    string dimensioni, string prezzoListino, string prezzoMelanimici, string prezzoPuntali, string prezzoRuote,
                    string prezzoTerminali, string prezzoBoccola, string prezzoTop, string prezzoPresa, string prezzoMulti2x3,
                    string prezzoMulti3x3)
    {
        this.codice = codice;
        this.immagine = immagine;
        this.descrizione = descrizione;
        this.larghezza = larghezza;
        this.profondita = profondità;
        this.altezza = altezza;
        this.dimensioni = dimensioni;
        this.prezzoListino = prezzoListino;
        this.prezzoMelanimici = prezzoMelanimici;
        this.prezzoPuntali = prezzoPuntali;
        this.prezzoRuote = prezzoRuote;
        this.prezzoTerminali = prezzoTerminali;
        this.prezzoBoccola = prezzoBoccola;
        this.prezzoTop = prezzoTop;
        this.prezzoPresa = prezzoPresa;
        this.prezzoMulti2x3 = prezzoMulti2x3;
        this.prezzoMulti3x3 = prezzoMulti3x3;
    }

    /// <summary>
    /// The ToString
    /// </summary>
    /// <returns>The <see cref="string"/></returns>
    override public string ToString()
    {
        string aus = "codice: " + codice +
            "altezza: " + altezza +
            "larghezza: " + larghezza +
            "profondita: " + profondita +
            "dimensioni: " + dimensioni +
            "descrizione: " + descrizione +
            "prezzoListino: " + prezzoListino +
            "prezzoMelanimici: " + prezzoMelanimici +
            "prezzoPuntali: " + prezzoPuntali +
            "prezzoRuote: " + prezzoRuote +
            "prezzoTerminali: " + prezzoTerminali +
            "prezzoBoccola:" + prezzoBoccola +
            "prezzoTop:" + prezzoTop +
            "prezzoPresa:" + prezzoPresa +
            "prezzoMulti2x3:" + prezzoMulti2x3 +
            "prezzoMulti3x3:" + prezzoMulti3x3;
        return aus;
    }
}
