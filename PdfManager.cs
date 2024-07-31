using iText.IO.Font.Constants;
using iText.Kernel.Events;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using PreventiviScolastici;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

/// <summary>
/// Defines the <see cref="PdfManager" />
/// </summary>
public class PdfManager
{
    /// <summary>
    /// Defines the <see cref="HeaderFooterHandler" />
    /// </summary>
    private class HeaderFooterHandler : IEventHandler
    {
        /// <summary>
        /// The HandleEvent
        /// </summary>
        /// <param name="currentEvent">The currentEvent<see cref="Event"/></param>
        public void HandleEvent(Event currentEvent)
        {
            PdfDocumentEvent docEvent = (PdfDocumentEvent)currentEvent;
            PdfDocument pdf = docEvent.GetDocument();
            PdfPage page = docEvent.GetPage();
            Rectangle pageSize = page.GetPageSize();

            PdfCanvas pdfCanvas = new PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), pdf);
            Canvas canvas = new Canvas(pdfCanvas, pageSize);

            string piePagina = "Quadrifoglio Sistemi d'Arredo spa\n" +
                                "Via Cornarè 12 - 31040 Mansuè(TV)\n" +
                                "Tel. 0422756025 - email: info@quadrifoglio.com";

            PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            float fontSize = 8;

            // Calcola la posizione y del piè di pagina rispetto al margine inferiore
            float yPiePagina = pageSize.GetBottom() + 15; // Aumenta questo valore se necessario

            canvas.SetFont(font).SetFontSize(fontSize);
            canvas.ShowTextAligned(piePagina, pageSize.GetWidth() / 2, yPiePagina, TextAlignment.CENTER);

            // Calcola la posizione y del numero di pagina
            String pageNumber = String.Format("Pagina {0} di {1}", pdf.GetPageNumber(page), pdf.GetNumberOfPages());
            canvas.ShowTextAligned(new Paragraph(pageNumber).SetFont(font).SetFontSize(fontSize), pageSize.GetWidth() - 40, yPiePagina, TextAlignment.RIGHT);

            string resourceName = "PreventiviScolastici.Quadrifoglio_Group_logo_rgb.jpg"; // Assicurati che il nome della risorsa sia corretto
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    byte[] imageBytes = new byte[stream.Length];
                    stream.Read(imageBytes, 0, imageBytes.Length);
                    iText.IO.Image.ImageData imageData = iText.IO.Image.ImageDataFactory.Create(imageBytes);
                    Image img = new Image(imageData);

                    // Imposta la larghezza dell'immagine e calcola l'altezza per mantenere le proporzioni
                    float newWidth = 150; // Ad esempio, 71 unità di larghezza
                    float scaleFactor = newWidth / img.GetImageWidth();
                    float newHeight = img.GetImageHeight() * scaleFactor;

                    // Posiziona l'immagine in alto a destra, con un margine di 20 unità
                    float positionX = pageSize.GetWidth() - newWidth - 20;
                    float positionY = pageSize.GetTop() - newHeight - 20;
                    img.SetFixedPosition(positionX, positionY, newWidth);

                    canvas.Add(img);
                }
            }

            canvas.Close();
        }
    }

    /// <summary>
    /// The createTable
    /// </summary>
    /// <param name="acquisti">The acquisti<see cref="List{Acquisti}"/></param>
    /// <returns>The <see cref="Table"/></returns>
    private Table createTable(List<Acquisti> acquisti)
    {
        Table table = new Table(UnitValue.CreatePercentArray(7)).UseAllAvailableWidth();

        // Aggiungi le intestazioni delle colonne con allineamento centrato
        Cell headerCodice = new Cell().Add(new Paragraph("CODICE"))
            .SetTextAlignment(TextAlignment.CENTER)
            .SetVerticalAlignment(VerticalAlignment.MIDDLE);
        table.AddHeaderCell(headerCodice);

        Cell headerImmagine = new Cell().Add(new Paragraph("IMMAGINE"))
            .SetTextAlignment(TextAlignment.CENTER)
            .SetVerticalAlignment(VerticalAlignment.MIDDLE);
        table.AddHeaderCell(headerImmagine);

        Cell headerDescrizione = new Cell().Add(new Paragraph("DESCRIZIONE"))
            .SetTextAlignment(TextAlignment.CENTER)
            .SetVerticalAlignment(VerticalAlignment.MIDDLE);
        table.AddHeaderCell(headerDescrizione);

        Cell headerDimensioni = new Cell().Add(new Paragraph("DIMENSIONI"))
            .SetTextAlignment(TextAlignment.CENTER)
            .SetVerticalAlignment(VerticalAlignment.MIDDLE);
        table.AddHeaderCell(headerDimensioni);

        Cell headerQuantita = new Cell().Add(new Paragraph("QUANTITA'"))
            .SetTextAlignment(TextAlignment.CENTER)
            .SetVerticalAlignment(VerticalAlignment.MIDDLE);
        table.AddHeaderCell(headerQuantita);

        Cell headerPrezzoUnitarioScontato = new Cell().Add(new Paragraph("PREZZO UNITARIO SCONTATO"))
            .SetTextAlignment(TextAlignment.CENTER)
            .SetVerticalAlignment(VerticalAlignment.MIDDLE);
        table.AddHeaderCell(headerPrezzoUnitarioScontato);

        Cell headerPrezzoTotaleScontato = new Cell().Add(new Paragraph("PREZZO TOTALE SCONTATO"))
            .SetTextAlignment(TextAlignment.CENTER)
            .SetVerticalAlignment(VerticalAlignment.MIDDLE);
        table.AddHeaderCell(headerPrezzoTotaleScontato);

        // Aggiungi le righe alla tabella per ogni prodotto, con allineamento centrato
        foreach (Acquisti aus in acquisti)
        {
            table.AddCell(new Cell().Add(new Paragraph(aus.codice))
                .SetTextAlignment(TextAlignment.CENTER)
                .SetVerticalAlignment(VerticalAlignment.MIDDLE));

            // Aggiunta dell'immagine (se presente) con allineamento centrato
            if (aus.immagine != null)
            {
                MemoryStream stream = new MemoryStream();
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(aus.immagine);
                bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageBytes = stream.ToArray();

                iText.IO.Image.ImageData imageData = iText.IO.Image.ImageDataFactory.Create(imageBytes);
                Image img = new Image(imageData);
                Cell imageCell = new Cell().Add(img.SetAutoScale(true))
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE);
                table.AddCell(imageCell);
            }
            else
            {
                table.AddCell(new Cell().Add(new Paragraph("No Image"))
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE));
            }

            table.AddCell(new Cell().Add(new Paragraph(aus.descrizione))
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE));
            table.AddCell(new Cell().Add(new Paragraph(aus.dimensioni))
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE));
            table.AddCell(new Cell().Add(new Paragraph(aus.quantita))
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE));
            table.AddCell(new Cell().Add(new Paragraph(aus.prezzoUnitarioScontato))
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE));
            table.AddCell(new Cell().Add(new Paragraph(aus.prezzoTotaleScontato))
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE));
        }

        return table;
    }

    /// <summary>
    /// The CreatePdf
    /// </summary>
    /// <param name="azienda">The azienda<see cref="string"/></param>
    /// <param name="ausiliare">The ausiliare<see cref="string"/></param>
    /// <param name="luogoData">The luogoData<see cref="string"/></param>
    /// <param name="lblPrezzo">The lblPrezzo<see cref="string"/></param>
    /// <param name="prezzo">The prezzo<see cref="string"/></param>
    /// <param name="lblCondizioni">The lblCondizioni<see cref="string"/></param>
    /// <param name="condizioni">The condizioni<see cref="string"/></param>
    /// <param name="servizi">The servizi<see cref="string"/></param>
    /// <param name="acquisti">The acquisti<see cref="List{Acquisti}"/></param>
    public void CreatePdf(string azienda, string ausiliare, string luogoData, string lblPrezzo, string prezzo, string lblCondizioni, string condizioni, string servizi, List<Acquisti> acquisti)
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
        saveFileDialog.RestoreDirectory = true;
        saveFileDialog.Title = "Esportazione";
        saveFileDialog.FileName = "Documento.pdf";

        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            string filePath = saveFileDialog.FileName;
            using (PdfWriter writer = new PdfWriter(filePath))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document document = new Document(pdf, PageSize.A4);
                    float marginTop = 70; // Spazio superiore per l'intestazione
                    float marginBottom = 50; // Spazio inferiore per il piè di pagina
                    document.SetMargins(marginTop, 36, marginBottom, 36);

                    Div div = new Div();

                    PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
                    float fontSizeText = 9;
                    float fontSizeTable = 6;

                    // Crea il paragrafo per luogoData e imposta l'allineamento a sinistra
                    Paragraph paragraphLuogoData = new Paragraph(luogoData)
                        .SetFont(font)
                        .SetFontSize(fontSizeTable)
                        .SetTextAlignment(TextAlignment.LEFT); // Allinea il testo a sinistra

                    Text textPrezzo = new Text(prezzo)
                        .SetFont(font)
                        .SetFontSize(fontSizeTable)
                        .SetBold();

                    // Crea il secondo pezzo di testo con la sua formattazione, inclusa quella in grassetto
                    Text textLblPrezzo = new Text(lblPrezzo)
                        .SetFont(font)
                        .SetFontSize(fontSizeTable)
                        .SetBold();

                    // Crea un nuovo paragrafo e aggiungi i pezzi di testo
                    Paragraph paragraphPrezzo = new Paragraph()
                        .Add(textLblPrezzo)
                        .Add(": ")
                        .Add(textPrezzo)
                        .SetFontSize(fontSizeTable)
                        .SetTextAlignment(TextAlignment.RIGHT);// Allinea il testo a destra

                    div.Add(paragraphPrezzo);
                    div.Add(paragraphLuogoData);

                    pdf.AddEventHandler(PdfDocumentEvent.END_PAGE, new HeaderFooterHandler());

                    document.Add(new Paragraph("\n").SetMarginTop(20));
                    document.Add(new Paragraph(azienda).SetFont(font).SetFontSize(fontSizeText).SetBold());
                    document.Add(new Paragraph("\n").SetMarginTop(5));
                    document.Add(new Paragraph(ausiliare).SetFont(font).SetFontSize(fontSizeText));
                    document.Add(new Paragraph("\n").SetMarginTop(2));
                    document.Add(createTable(acquisti).SetFont(font).SetFontSize(fontSizeTable));
                    document.Add(new Paragraph("\n").SetMarginTop(2));
                    document.Add(div);
                    document.Add(new Paragraph("\n").SetMarginTop(2));

                    Text textLblCondizioni = new Text(lblCondizioni)
                        .SetFont(font)
                        .SetFontSize(fontSizeTable)
                        .SetBold();

                    Text txtCondizioni = new Text(condizioni)
                        .SetFont(font)
                        .SetFontSize(fontSizeTable);

                    Paragraph paragraphCondizioni = new Paragraph()
                        .Add(textLblCondizioni)
                        .Add("\n")
                        .Add(txtCondizioni);

                    document.Add(paragraphCondizioni);
                    document.Add(new Paragraph("\n").SetMarginTop(2));

                    document.Add(new Paragraph(servizi).SetFont(font).SetFontSize(fontSizeTable));
                }
            }
        }
    }
}
