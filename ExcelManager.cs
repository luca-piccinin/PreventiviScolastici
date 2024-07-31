using ClosedXML.Excel;
using PreventiviScolastici;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

/// <summary>
/// Defines the <see cref="ExcelManager" />
/// </summary>
public class ExcelManager
{
    /// <summary>
    /// The RidimensionaImmagineConProporzioni
    /// </summary>
    /// <param name="immagineOriginale">The immagineOriginale<see cref="Image"/></param>
    /// <returns>The <see cref="Image"/></returns>
    public static Image RidimensionaImmagineConProporzioni(Image immagineOriginale)
    {
        float fattoreScala;
        int larghezzaDesiderata, altezzaDesiderata;
        int dimensioneMassima = 200;

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
    /// The CreateExcel
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
    static public void CreateExcel(string azienda, string ausiliare, string luogoData, string lblPrezzo, string prezzo, string lblCondizioni, string condizioni, string servizi, List<Acquisti> acquisti)
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog
        {
            Filter = "Excel files (*.xlsx)|*.xlsx",
            RestoreDirectory = true,
            Title = "Esportazione",
            FileName = "Documento.xlsx"
        };

        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Dati");

                worksheet.Cell("A1").Value = azienda;
                worksheet.Cell("A3").Value = ausiliare;

                // Aggiungi intestazioni
                worksheet.Cell("B5").Value = "CODICE";
                worksheet.Cell("C5").Value = "IMMAGINE";
                worksheet.Cell("D5").Value = "DESCRIZIONE";
                worksheet.Cell("E5").Value = "DIMENSIONI";
                worksheet.Cell("F5").Value = "QUANTITA'";
                worksheet.Cell("G5").Value = "PREZZO UNITARIO SCONTATO";
                worksheet.Cell("H5").Value = "PREZZO TOTALE SCONTATO";

                int currentRow = 6;
                foreach (var acquisto in acquisti)
                {
                    worksheet.Cell(currentRow, 2).Value = acquisto.codice;

                    using (Bitmap bmb = new Bitmap(RidimensionaImmagineConProporzioni(acquisto.immagine)))
                    {
                        MemoryStream m = new MemoryStream();
                        bmb.Save(m, ImageFormat.Png);

                        var picture = worksheet.AddPicture(m)
                          .MoveTo(worksheet.Cell(currentRow, 3));

                        worksheet.Row(currentRow).Height = 100;
                        worksheet.Column(3).Width = 30;
                    }

                    worksheet.Cell(currentRow, 4).Value = acquisto.descrizione;
                    worksheet.Cell(currentRow, 5).Value = acquisto.dimensioni;
                    worksheet.Cell(currentRow, 6).Value = int.Parse(acquisto.quantita);
                    worksheet.Cell(currentRow, 7).Value = decimal.Parse(acquisto.prezzoUnitarioScontato.Replace("€", ""));
                    worksheet.Cell(currentRow, 8).Value = acquisto.prezzoTotaleScontato;
                    currentRow++;
                }

                worksheet.Cell(currentRow + 2, 1).Value = lblPrezzo;
                worksheet.Cell(currentRow + 2, 2).Value = prezzo;
                worksheet.Cell(currentRow + 4, 1).Value = condizioni;
                worksheet.Cell(currentRow + 6, 1).Value = servizi;

                // Applica auto-size alle colonne
                worksheet.Column(1).AdjustToContents();
                worksheet.Column(2).AdjustToContents();
                worksheet.Column(4).AdjustToContents();
                worksheet.Column(5).AdjustToContents();
                worksheet.Column(6).AdjustToContents();
                worksheet.Column(7).AdjustToContents();
                worksheet.Column(8).AdjustToContents();

                // Definisci il range per l'applicazione dei bordi
                var range = worksheet.Range("B5:H" + (5).ToString());
                var range2 = worksheet.Range("B6:H" + (5 + acquisti.Count).ToString());
                var rangeFormat = worksheet.Range("G6:H" + (5 + acquisti.Count).ToString());

                // Applica bordi spessi al range
                range.Style.Border.OutsideBorder = XLBorderStyleValues.Thick;
                range.Style.Border.InsideBorder = XLBorderStyleValues.Thick;

                // Applica bordi fini al range2
                range2.Style.Border.OutsideBorder = XLBorderStyleValues.Thick;
                range2.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                // Imposta il formato valuta italiana
                rangeFormat.Style.NumberFormat.Format = "#,##0.00 €";
                worksheet.Cell("B12").Style.NumberFormat.Format = "#,##0.00 €";

                // Allineare il tutto il testo a sinistra
                worksheet.Rows().Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);

                // Centrare il testo nelle celle delle intestazioni
                worksheet.Range("F6:H" + (5 + acquisti.Count).ToString()).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                // Allineare il testo del prezzo a destra
                int val = 5 + 3 + acquisti.Count;
                worksheet.Row(val).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);

                // Salva il documento
                workbook.SaveAs(saveFileDialog.FileName);
            }
        }
    }
}
