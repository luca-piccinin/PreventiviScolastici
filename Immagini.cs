using System.Drawing;

/// <summary>
/// Defines the <see cref="Immagini" />
/// </summary>
public class Immagini
{
    /// <summary>
    /// Gets or sets the immagine
    /// </summary>
    public Image immagine { get; set; }

    /// <summary>
    /// Gets or sets the codice
    /// </summary>
    public string codice { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Immagini"/> class.
    /// </summary>
    public Immagini()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Immagini"/> class.
    /// </summary>
    /// <param name="immagine">The immagine<see cref="Image"/></param>
    /// <param name="codice">The codice<see cref="string"/></param>
    public Immagini(Image immagine, string codice)
    {
        this.immagine = immagine;
        this.codice = codice;
    }
}
