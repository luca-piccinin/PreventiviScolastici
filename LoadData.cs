using OfficeOpenXml;
using PreventiviScolastici;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

/// <summary>
/// Defines the <see cref="LoadData" />
/// </summary>
public class LoadData
{
    /// <summary>
    /// Defines the dbDati
    /// </summary>
    private static Database dbDati = new Database();

    /// <summary>
    /// Defines the dbImmagini
    /// </summary>
    private static DataBaseImmagini dbImmagini = new DataBaseImmagini();

    /// <summary>
    /// The writeFile
    /// </summary>
    /// <param name="dbVersion">The dbVersion<see cref="string"/></param>
    public static void writeFile(string dbVersion)
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Versione.txt");

        // Assicurati che la directory esista
        string directoryPath = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        File.WriteAllText(filePath, dbVersion);
    }

    /// <summary>
    /// The readFile
    /// </summary>
    /// <returns>The <see cref="string"/></returns>
    public static string readFile()
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Versione.txt");

        if (!File.Exists(filePath))
        {
            // La versione predefinita che desideri utilizzare
            string defaultVersion = "listinoV1";

            // Crea il file con la versione di default
            writeFile(defaultVersion);

            return defaultVersion;
        }
        else
        {
            // Se il file esiste, leggi e restituisci il suo contenuto
            return File.ReadAllText(filePath);
        }
    }

    /// <summary>
    /// The controlloVersione
    /// </summary>
    /// <param name="newVersion">The newVersion<see cref="string"/></param>
    /// <returns>The <see cref="bool"/></returns>
    private static bool controlloVersione(string newVersion)
    {
        string oldVersion = readFile(); // Assumo che questo metodo restituisca la versione precedente come stringa

        // Estrai solo la parte numerica della versione, assumendo che il formato sia sempre "esempioV1"
        string versioneOld = new string(oldVersion.SkipWhile(c => !char.IsDigit(c)).ToArray());
        string versioneNew = new string(newVersion.SkipWhile(c => !char.IsDigit(c)).ToArray());

        // Assicurati che le stringhe estratte non siano vuote e aggiungi ".0" per formattare correttamente
        if (string.IsNullOrWhiteSpace(versioneOld) || string.IsNullOrWhiteSpace(versioneNew))
        {
            // Logica per gestire il caso in cui una delle stringhe di versione sia vuota o contenga solo spazi
            Console.WriteLine("Errore: una delle stringhe di versione è vuota o non valida.");
            return false;
        }

        try
        {
            Version versioneObjOld = new Version(versioneOld + ".0");
            Version versioneObjNew = new Version(versioneNew + ".0");

            if (versioneObjOld.Equals(versioneObjNew))
            {
                return true;
            }
            else if (versioneObjNew > versioneObjOld)
            {
                writeFile(newVersion); // Assumo che questo metodo aggiorni la versione salvata
                return false;
            }
            else
            {
                // Questo caso si verifica se la "nuova" versione è in realtà inferiore alla vecchia, il che potrebbe essere un errore
                writeFile(newVersion);
                return false;
            }
        }
        catch (FormatException ex)
        {
            // Logica per gestire l'eccezione se la conversione della stringa di versione fallisce
            Console.WriteLine($"Errore di formato nella conversione della versione: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// The CaricaImmagini
    /// </summary>
    public static void CaricaImmagini()
    {
        ConvertPdf();
        ConvertPngToJpeg();

        string folderPath = @"C:\Preventivi Scolastici\immagini";
        Immagini img = new Immagini();

        // Controlla se la cartella esiste
        if (!Directory.Exists(folderPath))
        {
            MessageBox.Show("La cartella specificata delle immagini non esiste.");
        }

        // Ottieni tutti i file .jpg nella cartella
        string[] files = Directory.GetFiles(folderPath, "*.jpeg");

        foreach (string file in files)
        {
            string name = Path.GetFileNameWithoutExtension(file);
            Image imj = Image.FromFile(file);

            img = new Immagini(
                imj,
                name);

            dbImmagini.InsertData(img);
        }
    }

    /// <summary>
    /// The FindExistingImage
    /// </summary>
    /// <param name="name">The name<see cref="string"/></param>
    /// <returns>The <see cref="bool"/></returns>
    public static bool FindExistingImage(string name)
    {
        string folderPath = @"C:\Preventivi Scolastici\immagini";

        // Ottieni tutti i file .jpg e .png nella cartella
        string[] imageFiles = Directory.GetFiles(folderPath, "*.*")
            .Where(file => file.EndsWith(".jpeg"))
            .ToArray();

        foreach (string imagePath in imageFiles)
        {
            string imageName = Path.GetFileNameWithoutExtension(imagePath);

            if (imageName == name)
                return true;
        }
        return false;
    }

    /// <summary>
    /// The ConvertPngToJpeg
    /// </summary>
    public static void ConvertPngToJpeg()
    {
        string folderPath = @"C:\Preventivi Scolastici\immagini";
        // Ottieni tutti i file PNG nella cartella
        string[] pngFiles = Directory.GetFiles(folderPath, "*.png");

        foreach (string pngFilePath in pngFiles)
        {
            // Nome del file PNG senza percorso
            string pngFileName = Path.GetFileNameWithoutExtension(pngFilePath);
            // Percorso di output per il file JPEG
            string jpegFilePath = Path.Combine(folderPath, pngFileName + ".jpeg");

            using (Image image = Image.FromFile(pngFilePath))
            {
                // Salva l'immagine in formato JPEG
                image.Save(jpegFilePath, ImageFormat.Jpeg);
            }

            try
            {
                // Elimina il file
                File.Delete(pngFilePath);
            }
            catch (IOException ex)
            {
                // Gestisce errori di I/O (es. il file è in uso da un altro processo)
                Console.WriteLine($"Impossibile eliminare il file: {ex.Message}");
            }
        }
    }

    /// <summary>
    /// The ConvertPdf
    /// </summary>
    public static void ConvertPdf()
    {
        string folderPath = @"C:\Preventivi Scolastici\immagini";
        // Ottieni tutti i file PDF nella cartella
        string[] pdfFiles = Directory.GetFiles(folderPath, "*.pdf");

        foreach (string pdfFilePath in pdfFiles)
        {
            // Nome del file PDF senza percorso
            string pdfFileName = Path.GetFileNameWithoutExtension(pdfFilePath);

            if (!FindExistingImage(pdfFilePath))
            {
                var pdf = IronPdf.PdfDocument.FromFile(pdfFilePath);

                // Crea un pattern di percorso che includa un segnaposto per il numero di pagina
                string outputPattern = Path.Combine(folderPath, pdfFileName + ".jpeg");

                pdf.RasterizeToImageFiles(outputPattern);

                try
                {
                    // Elimina il file
                    File.Delete(pdfFilePath);
                }
                catch (IOException ex)
                {
                    // Gestisce errori di I/O (es. il file è in uso da un altro processo)
                    Console.WriteLine($"Impossibile eliminare il file: {ex.Message}");
                }
            }
        }
    }

    /// <summary>
    /// The controllo
    /// </summary>
    /// <returns>The <see cref="bool"/></returns>
    public static bool controllo()
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        string filePath = @"C:\Preventivi Scolastici\test.xlsx";
        FileInfo fileInfo = new FileInfo(filePath);

        using (ExcelPackage package = new ExcelPackage(fileInfo))
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

            return controlloVersione(worksheet.Name);
        }
    }

    /// <summary>
    /// The CaricaDati
    /// </summary>
    public static void CaricaDati()
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        //string filePath = @"C:\Preventivi Scolastici\bozza_listino_07_12.xlsx";
        string filePath = @"C:\Preventivi Scolastici\test.xlsx";

        FileInfo fileInfo = new FileInfo(filePath);
        List<Listino> listaProdotti = new List<Listino>();

        using (ExcelPackage package = new ExcelPackage(fileInfo))
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Assume che i dati siano nel primo foglio
            int rowCount = worksheet.Dimension.Rows;

            writeFile(worksheet.Name);

            CaricaImmagini();

            string aus = "";
            bool flag = false;
            Image immagine = null;
            Image immagineAus = null;

            for (int row = 3; row <= rowCount; row++) // Inizia da 2 per saltare l'intestazione
            {
                // Ottieni i valori dalle celle specifiche di ogni riga
                string descrizione = worksheet.Cells[row, 2].Text;

                // Se non c'è una descrizione, usa quella precedente
                if (descrizione == "")
                    descrizione = aus;
                else
                    aus = descrizione;

                string codice = worksheet.Cells[row, 4].Text;

                if (codice == "")
                    flag = true;
                else
                    flag = false;

                string altezza = worksheet.Cells[row, 7].Text;
                string larghezza = worksheet.Cells[row, 5].Text;
                string profondita = worksheet.Cells[row, 6].Text;
                string prezzoListino = worksheet.Cells[row, 8].Text;
                string prezzoMelanimici = worksheet.Cells[row, 9].Text;
                string prezzoPuntali = worksheet.Cells[row, 10].Text;
                string prezzoRuote = worksheet.Cells[row, 11].Text;
                string prezzoTerminali = worksheet.Cells[row, 12].Text;
                string prezzoBoccola = worksheet.Cells[row, 13].Text;
                string prezzoTop = worksheet.Cells[row, 14].Text;
                string prezzoPresa = worksheet.Cells[row, 15].Text;
                string prezzoMulti2x3 = worksheet.Cells[row, 16].Text;
                string prezzoMulti3x3 = worksheet.Cells[row, 17].Text;

                string dimensioni = "L" + larghezza + "x" + "P" + profondita + "x" + "H" + altezza + " mm";

                Image tempImage = dbImmagini.find(codice);
                if (tempImage == null)
                {
                    immagine = immagineAus; // Usa l'immagine precedente se quella attuale non è trovata
                }
                else
                {
                    immagine = tempImage; // Usa l'immagine trovata
                    immagineAus = tempImage; // Aggiorna l'immagine precedente con quella attuale
                }

                if (flag == false)
                {
                    // Creazione e aggiunta del nuovo prodotto alla lista
                    Listino p = new Listino(
                                    codice,
                                    immagine,
                                    descrizione,
                                    larghezza,
                                    altezza,
                                    profondita,
                                    dimensioni,
                                    prezzoListino,
                                    prezzoMelanimici,
                                    prezzoPuntali,
                                    prezzoRuote,
                                    prezzoTerminali,
                                    prezzoBoccola,
                                    prezzoTop,
                                    prezzoPresa,
                                    prezzoMulti2x3,
                                    prezzoMulti3x3
                                );

                    listaProdotti.Add(p);
                }
            }
        }

        // Inserimento dei dati nel database
        foreach (var prodotto in listaProdotti)
        {
            dbDati.InsertData(prodotto);
        }
    }

    /// <summary>
    /// The twoDecimal
    /// </summary>
    /// <param name="aus">The aus<see cref="string"/></param>
    /// <returns>The <see cref="string"/></returns>
    public static string twoDecimal(string aus)
    {
        decimal export;
        string numPulito = aus.Replace(",", ".").Trim();
        if (decimal.TryParse(numPulito, NumberStyles.Any, CultureInfo.InvariantCulture, out export))
        {
            // Conversione riuscita, 'export' contiene il numero
            return export.ToString("0 €", CultureInfo.InvariantCulture); ;
        }
        else
        {
            // La conversione è fallita, gestisci il caso appropriatamente
            // Ad esempio, puoi decidere di restituire 0, loggare un errore, o lanciare un'eccezione personalizzata
            return ""; // o gestisci l'errore in un altro modo che preferisci
        }
    }
}
