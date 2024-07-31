namespace PreventiviScolastici
{
    using OfficeOpenXml;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Defines the <see cref="ExcelRW" />
    /// </summary>
    internal class ExcelRW
    {
        /// <summary>
        /// The SalvaDatiInExcelEPPlus
        /// </summary>
        /// <param name="filePath">The filePath<see cref="string"/></param>
        /// <param name="acquisti">The acquisti<see cref="List{Acquisti}"/></param>
        /// <param name="sconto">The sconto<see cref="decimal"/></param>
        /// <param name="dati">The dati<see cref="string"/></param>
        /// <param name="luogo">The luogo<see cref="string"/></param>
        /// <param name="pagamento">The pagamento<see cref="string"/></param>
        /// <param name="validita">The validita<see cref="string"/></param>
        /// <param name="iva">The iva<see cref="string"/></param>
        /// <param name="tempi">The tempi<see cref="string"/></param>
        /// <param name="montaggio">The montaggio<see cref="string"/></param>
        /// <param name="totale">The totale<see cref="string"/></param>
        /// <param name="scontoSecondario">The scontoSecondario<see cref="decimal"/></param>
        /// <param name="flag">The flag<see cref="bool"/></param>
        public void SalvaDatiInExcelEPPlus(string filePath, List<Acquisti> acquisti, decimal sconto, string dati,
            string luogo, string pagamento, string validita, string iva, string tempi, string montaggio, string totale, decimal scontoSecondario, bool flag)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Foglio1");

                // Qui puoi aggiungere i dati che desideri nel foglio Excel
                worksheet.Cells["A1"].Value = "CODICE";
                //worksheet.Cells["B1"].Value = "IMMAGINE";
                worksheet.Cells["C1"].Value = "DESCRIZIONE";
                worksheet.Cells["D1"].Value = "LARGHEZZA";
                worksheet.Cells["E1"].Value = "PROFONDITA";
                worksheet.Cells["F1"].Value = "ALTEZZA";
                worksheet.Cells["G1"].Value = "DIMENSIONI";
                worksheet.Cells["H1"].Value = "PREZZO LISTINO";
                worksheet.Cells["I1"].Value = "SCONTO";
                worksheet.Cells["J1"].Value = "PREZZO UNITARIO SCONTATO";
                worksheet.Cells["K1"].Value = "QUANTITA";
                worksheet.Cells["L1"].Value = "PREZZO TOTALE";
                worksheet.Cells["M1"].Value = "PREZZO TOTALE SCONTATO";
                worksheet.Cells["N1"].Value = "QUANTITA MELANIMICI";
                worksheet.Cells["O1"].Value = "PREZZO MELANIMICI";
                worksheet.Cells["P1"].Value = "QUANTITA PUNTALI";
                worksheet.Cells["Q1"].Value = "PREZZO PUNTALI";
                worksheet.Cells["R1"].Value = "QUANTITA RUOTE";
                worksheet.Cells["S1"].Value = "PREZZO RUOTE";
                worksheet.Cells["T1"].Value = "QUANTITA TERMINALI";
                worksheet.Cells["U1"].Value = "PREZZO TERMINALI";

                worksheet.Cells["V1"].Value = "QUANTITA BOCCOLA";
                worksheet.Cells["W1"].Value = "PREZZO BOCCOLA";
                worksheet.Cells["X1"].Value = "QUANTITA MAGIC TOP";
                worksheet.Cells["Y1"].Value = "PREZZO MAGIC TOP";
                worksheet.Cells["Z1"].Value = "QUANTITA PRESA";
                worksheet.Cells["AA1"].Value = "PREZZO PRESA";
                worksheet.Cells["AB1"].Value = "QUANTITA MULTIPRESA 2x3";
                worksheet.Cells["AC1"].Value = "PREZZO MULTIPRESA 2x3";
                worksheet.Cells["AD1"].Value = "QUANTITA MULTIPRESA 3x3";
                worksheet.Cells["AE1"].Value = "PREZZO MULTIPRESA 3x3";

                worksheet.Cells["AF1"].Value = "DATI AZIENDA";
                worksheet.Cells["AG1"].Value = "LUOGO";
                worksheet.Cells["AH1"].Value = "PAGAMENTO";
                worksheet.Cells["AI1"].Value = "VALIDITA";
                worksheet.Cells["AJ1"].Value = "IVA";
                worksheet.Cells["AK1"].Value = "TEMPI DI CONSEGNA";
                worksheet.Cells["AL1"].Value = "MONATAGGIO";
                worksheet.Cells["AM1"].Value = "TOTALE";
                worksheet.Cells["AN1"].Value = "SCONTO SECONDARIO";
                worksheet.Cells["AO1"].Value = "EXTRA SCONTO";

                int count = acquisti.Count + 2;
                for (int j = 2; j < count; j++)
                {
                    Acquisti aux = acquisti[j - 2];
                    worksheet.Cells["A" + j].Value = aux.codice;
                    // L'immagine non viene mostrata a caus dell'elevata difficoltà nella stampa
                    worksheet.Cells["C" + j].Value = aux.descrizione;
                    worksheet.Cells["D" + j].Value = aux.larghezza;
                    worksheet.Cells["E" + j].Value = aux.profondita;
                    worksheet.Cells["F" + j].Value = aux.altezza;
                    worksheet.Cells["G" + j].Value = aux.dimensioni;
                    worksheet.Cells["H" + j].Value = aux.prezzoListino;
                    if (sconto == default)
                        worksheet.Cells["I" + j].Value = 0;
                    else
                        worksheet.Cells["I" + j].Value = sconto;
                    worksheet.Cells["J" + j].Value = aux.prezzoUnitarioScontato;
                    worksheet.Cells["K" + j].Value = aux.quantita;
                    worksheet.Cells["L" + j].Value = aux.prezzoTotale;
                    worksheet.Cells["M" + j].Value = aux.prezzoTotaleScontato;
                    worksheet.Cells["N" + j].Value = aux.quantitaMelanimici;
                    worksheet.Cells["O" + j].Value = aux.prezzoMelanimici;
                    worksheet.Cells["P" + j].Value = aux.quantitaPuntali;
                    worksheet.Cells["Q" + j].Value = aux.prezzoPuntali;
                    worksheet.Cells["R" + j].Value = aux.quantitaRuote;
                    worksheet.Cells["S" + j].Value = aux.prezzoRuote;
                    worksheet.Cells["T" + j].Value = aux.quantitaTerminali;

                    worksheet.Cells["V" + j].Value = aux.quantitaBoccola;
                    worksheet.Cells["W" + j].Value = aux.prezzoBoccola;
                    worksheet.Cells["X" + j].Value = aux.quantitaTop;
                    worksheet.Cells["Y" + j].Value = aux.prezzoTop;
                    worksheet.Cells["Z" + j].Value = aux.quantitaPresa;
                    worksheet.Cells["AA" + j].Value = aux.prezzoPresa;
                    worksheet.Cells["AB" + j].Value = aux.quantitaMulti2x3;
                    worksheet.Cells["AC" + j].Value = aux.prezzoMulti2x3;
                    worksheet.Cells["AD" + j].Value = aux.quantitaMulti3x3;
                    worksheet.Cells["AE" + j].Value = aux.prezzoMulti3x3;

                    worksheet.Cells["AF" + j].Value = dati;
                    worksheet.Cells["AG" + j].Value = luogo;
                    worksheet.Cells["AH" + j].Value = pagamento;
                    worksheet.Cells["AI" + j].Value = validita;
                    worksheet.Cells["AJ" + j].Value = iva;
                    worksheet.Cells["AK" + j].Value = tempi;
                    worksheet.Cells["AL" + j].Value = montaggio;
                    worksheet.Cells["AM" + j].Value = totale;
                    worksheet.Cells["AN" + j].Value = scontoSecondario;
                    worksheet.Cells["AO" + j].Value = flag;
                }

                // Salva il file nel percorso specificato dall'utente
                package.SaveAs(new FileInfo(filePath));
            }
        }

        /// <summary>
        /// The CaricaDatiDaExcelEPPlus
        /// </summary>
        /// <param name="filePath">The filePath<see cref="string"/></param>
        /// <param name="mainView">The mainView<see cref="MainView"/></param>
        /// <returns>The <see cref="List{Acquisti}"/></returns>
        public List<Acquisti> CaricaDatiDaExcelEPPlus(string filePath, MainView mainView)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            Database db = new Database();
            List<Acquisti> acquistiCaricati = new List<Acquisti>();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Assumi che i dati siano nel primo foglio

                int rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    bool var1, var2, var3, var4, var5, var6, var7, var8, var9, var10;
                    if (worksheet.Cells[row, 14].Text == "TRUE")
                        var1 = true;
                    else
                        var1 = false;
                    if (worksheet.Cells[row, 16].Text == "TRUE")
                        var2 = true;
                    else
                        var2 = false;
                    if (worksheet.Cells[row, 18].Text == "TRUE")
                        var3 = true;
                    else
                        var3 = false;
                    if (worksheet.Cells[row, 20].Text == "TRUE")
                        var4 = true;
                    else
                        var4 = false;
                    if (worksheet.Cells[row, 22].Text == "TRUE")
                        var5 = true;
                    else
                        var5 = false;
                    if (worksheet.Cells[row, 24].Text == "TRUE")
                        var6 = true;
                    else
                        var6 = false;
                    if (worksheet.Cells[row, 26].Text == "TRUE")
                        var7 = true;
                    else
                        var7 = false;
                    if (worksheet.Cells[row, 28].Text == "TRUE")
                        var8 = true;
                    else
                        var8 = false;
                    if (worksheet.Cells[row, 30].Text == "TRUE")
                        var9 = true;
                    else
                        var9 = false;
                    if (worksheet.Cells[row, 41].Text == "TRUE")
                        var10 = true;
                    else
                        var10 = false;

                    Acquisti acquisto = new Acquisti
                    {
                        codice = worksheet.Cells[row, 1].Text,
                        immagine = db.find(worksheet.Cells[row, 1].Text).immagine,
                        descrizione = worksheet.Cells[row, 3].Text,
                        larghezza = worksheet.Cells[row, 4].Text,
                        profondita = worksheet.Cells[row, 5].Text,
                        altezza = worksheet.Cells[row, 6].Text,
                        dimensioni = worksheet.Cells[row, 7].Text,
                        prezzoListino = worksheet.Cells[row, 8].Text,
                        prezzoMelanimici = worksheet.Cells[row, 15].Text,
                        prezzoPuntali = worksheet.Cells[row, 17].Text,
                        prezzoRuote = worksheet.Cells[row, 19].Text,
                        prezzoTerminali = worksheet.Cells[row, 21].Text,

                        prezzoBoccola = worksheet.Cells[row, 23].Text,
                        prezzoTop = worksheet.Cells[row, 25].Text,
                        prezzoPresa = worksheet.Cells[row, 27].Text,
                        prezzoMulti2x3 = worksheet.Cells[row, 29].Text,
                        prezzoMulti3x3 = worksheet.Cells[row, 31].Text,

                        quantita = worksheet.Cells[row, 11].Text,
                        quantitaMelanimici = var1,
                        quantitaPuntali = var2,
                        quantitaRuote = var3,
                        quantitaTerminali = var4,

                        quantitaBoccola = var5,
                        quantitaTop = var6,
                        quantitaPresa = var7,
                        quantitaMulti2x3 = var8,
                        quantitaMulti3x3 = var9,

                        prezzoTotale = worksheet.Cells[row, 12].Text,
                        prezzoUnitarioScontato = worksheet.Cells[row, 10].Text,
                        prezzoTotaleScontato = worksheet.Cells[row, 13].Text,
                    };

                    mainView.setValue(worksheet.Cells[row, 9].Text,
                        worksheet.Cells[row, 32].Text,
                        worksheet.Cells[row, 33].Text,
                        worksheet.Cells[row, 34].Text,
                        worksheet.Cells[row, 35].Text,
                        worksheet.Cells[row, 36].Text,
                        worksheet.Cells[row, 37].Text,
                        worksheet.Cells[row, 38].Text,
                        worksheet.Cells[row, 39].Text,
                        worksheet.Cells[row, 40].Text,
                        var10);

                    acquistiCaricati.Add(acquisto);
                }

                // Dispose of the ExcelPackage object to release the lock on the file
                package.Dispose();
            }

            return acquistiCaricati;
        }
    }
}
