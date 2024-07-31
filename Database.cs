using PreventiviScolastici;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

/// <summary>
/// Defines the <see cref="Database" />
/// </summary>
public class Database
{
    /// <summary>
    /// Defines the connectionString
    /// </summary>
    private string connectionString = $"Data Source = listino.db; Version=3;";

    // Metodo per creare una tabella di esempio

    /// <summary>
    /// The CreateTable
    /// </summary>
    public void CreateTable()
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            if (!Existing())
            {
                string sql = "CREATE TABLE listino (" +
                " codice VARCHAR(8) PRIMARY KEY," +
                " immagine BLOB, " +
                " descrizione VARCHAR(500)," +
                " larghezza VARCHAR(20)," +
                " altezza VARCHAR(20)," +
                " profondita VARCHAR(20)," +
                " dimensioni VARCHAR(20)," +
                " prezzoListino VARCHAR(10)," +
                " prezzoMelanimici VARCHAR(10)," +
                " prezzoPuntali VARCHAR(10)," +
                " prezzoRuote VARCHAR(10)," +
                " prezzoTerminali VARCHAR(10)," +
                " prezzoBoccola VARCHAR(10)," +
                " prezzoTop VARCHAR(10)," +
                " prezzoPresa VARCHAR(10)," +
                " prezzoMulti2x3 VARCHAR(10)," +
                " prezzoMulti3x3 VARCHAR(10))";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }

    /// <summary>
    /// The Filter
    /// </summary>
    /// <param name="find">The find<see cref="string"/></param>
    /// <returns>The <see cref="List{Listino}"/></returns>
    public List<Listino> Filter(string find)
    {
        List<Listino> risultati = new List<Listino>();
        Listino listino = new Listino();

        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            string sql = "SELECT codice, immagine, descrizione, larghezza, altezza, profondita," +
                "dimensioni, prezzoListino, prezzoMelanimici, prezzoPuntali, prezzoRuote," +
                "prezzoTerminali, prezzoBoccola, prezzoTop, prezzoPresa, prezzoMulti2x3," +
                "prezzoMulti3x3 FROM listino WHERE codice LIKE @pattern";

            using (var cmd = new SQLiteCommand(sql, connection))
            {
                // Configura il parametro per la ricerca con pattern
                cmd.Parameters.AddWithValue("@pattern", "%" + find + "%");

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Assumendo che ci sia un costruttore appropriato per la tua classe Listino
                        listino = new Listino(
                            reader["codice"].ToString(),
                            ConvertiByteArrayInImage((byte[])reader["immagine"]),
                            reader["descrizione"].ToString(),
                            reader["larghezza"].ToString(),
                            reader["altezza"].ToString(),
                            reader["profondita"].ToString(),
                            reader["dimensioni"].ToString(),
                            reader["prezzoListino"].ToString(),
                            reader["prezzoMelanimici"].ToString(),
                            reader["prezzoPuntali"].ToString(),
                            reader["prezzoRuote"].ToString(),
                            reader["prezzoTerminali"].ToString(),
                            reader["prezzoBoccola"].ToString(),
                            reader["prezzoTop"].ToString(),
                            reader["prezzoPresa"].ToString(),
                            reader["prezzoMulti2x3"].ToString(),
                            reader["prezzoMulti3x3"].ToString()
                        );
                        risultati.Add(listino);
                    }
                }
            }
        }

        return risultati;
    }

    /// <summary>
    /// The find
    /// </summary>
    /// <param name="find">The find<see cref="string"/></param>
    /// <returns>The <see cref="Acquisti"/></returns>
    public Acquisti find(string find)
    {
        Acquisti acquisti = new Acquisti();
        Image immagine = null;

        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            if (Existing())
            {
                string sql = "SELECT codice, immagine, descrizione, larghezza," +
                "altezza, profondita, dimensioni, prezzoListino, prezzoMelanimici, prezzoPuntali," +
                "prezzoRuote, prezzoTerminali, prezzoBoccola, prezzoTop, prezzoPresa, prezzoMulti2x3," +
                "prezzoMulti3x3 FROM listino WHERE codice = @codice";
                using (var cmd = new SQLiteCommand(sql, connection))
                {
                    // Assegna il valore al parametro
                    cmd.Parameters.AddWithValue("@codice", find);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read(); // Sposta il reader alla prima riga dei risultati
                            // Recupera i valori delle colonne per ogni riga

                            if (reader["immagine"] != DBNull.Value)
                                immagine = ConvertiByteArrayInImage((byte[])reader["immagine"]);
                            else
                                immagine = null;

                            acquisti = new Acquisti(
                                reader["codice"].ToString(),
                                immagine,
                                reader["descrizione"].ToString(),
                                reader["larghezza"].ToString(),
                                reader["altezza"].ToString(),
                                reader["profondita"].ToString(),
                                reader["dimensioni"].ToString(),
                                reader["prezzoListino"].ToString(),
                                reader["prezzoMelanimici"].ToString(),
                                reader["prezzoPuntali"].ToString(),
                                reader["prezzoRuote"].ToString(),
                                reader["prezzoTerminali"].ToString(),
                                reader["prezzoBoccola"].ToString(),
                                reader["prezzoTop"].ToString(),
                                reader["prezzoPresa"].ToString(),
                                reader["prezzoMulti2x3"].ToString(),
                                reader["prezzoMulti3x3"].ToString(),
                                "0",
                                false,
                                false,
                                false,
                                false,
                                false,
                                false,
                                false,
                                false,
                                false,
                                "0",
                                "0",
                                "0"
                            );
                        }
                    }
                }
            }
        }

        return acquisti;
    }

    /// <summary>
    /// The DeleteTable
    /// </summary>
    public void DeleteTable()
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            string sql = "DROP TABLE IF EXISTS listino";

            using (var command = new SQLiteCommand(sql, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }

    /// <summary>
    /// The Existing
    /// </summary>
    /// <returns>The <see cref="bool"/></returns>
    private bool Existing()
    {
        // La connessione dovrebbe essere aperta prima di eseguire il comando
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            // Correggi la query SQL per utilizzare un parametro al posto di inserire direttamente il nome della tabella
            string sql = "SELECT name FROM sqlite_master WHERE type='table' AND name=@tableName";

            using (var command = new SQLiteCommand(sql, connection))
            {
                // Corretto l'utilizzo del parametro per prevenire SQL Injection
                command.Parameters.AddWithValue("@tableName", "listino");

                using (var reader = command.ExecuteReader())
                {
                    // Se il reader ha delle righe, significa che la tabella esiste
                    return reader.HasRows;
                }
            }
        }
    }

    /// <summary>
    /// The CodiceEsiste
    /// </summary>
    /// <param name="codice">The codice<see cref="string"/></param>
    /// <param name="conn">The conn<see cref="SQLiteConnection"/></param>
    /// <returns>The <see cref="bool"/></returns>
    private bool CodiceEsiste(string codice, SQLiteConnection conn)
    {
        using (var cmd = new SQLiteCommand("SELECT COUNT(*) FROM listino WHERE codice = @codice", conn))
        {
            cmd.Parameters.AddWithValue("@codice", codice);
            long count = (long)cmd.ExecuteScalar();
            return count > 0;
        }
    }

    // Metodo per inserire dati nella tabella di esempio

    /// <summary>
    /// The InsertData
    /// </summary>
    /// <param name="p">The p<see cref="Listino"/></param>
    public void InsertData(Listino p)
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string sql = "INSERT INTO listino (codice, immagine, descrizione, larghezza, altezza, profondita," +
                "dimensioni, prezzoListino, prezzoMelanimici, prezzoPuntali, prezzoRuote, prezzoTerminali," +
                "prezzoBoccola, prezzoTop, prezzoPresa, prezzoMulti2x3, prezzoMulti3x3)" +
                "VALUES (@codice, @immagine, @descrizione, @larghezza, @altezza, @profondita, @dimensioni," +
                "@prezzoListino, @prezzoMelanimici, @prezzoPuntali, @prezzoRuote, @prezzoTerminali," +
                "@prezzoBoccola, @prezzoTop, @prezzoPresa, @prezzoMulti2x3, @prezzoMulti3x3)";

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                if (!CodiceEsiste(p.codice, conn))
                {
                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@codice", p.codice);
                        command.Parameters.AddWithValue("@immagine", ConvertiImmagineInByte(p.immagine));
                        command.Parameters.AddWithValue("@descrizione", p.descrizione);
                        command.Parameters.AddWithValue("@larghezza", p.larghezza);
                        command.Parameters.AddWithValue("@altezza", p.altezza);
                        command.Parameters.AddWithValue("@dimensioni", p.dimensioni);
                        command.Parameters.AddWithValue("@profondita", p.profondita);
                        command.Parameters.AddWithValue("@prezzoListino", p.prezzoListino);
                        command.Parameters.AddWithValue("@prezzoMelanimici", p.prezzoMelanimici);
                        command.Parameters.AddWithValue("@prezzoPuntali", p.prezzoPuntali);
                        command.Parameters.AddWithValue("@prezzoRuote", p.prezzoRuote);
                        command.Parameters.AddWithValue("@prezzoTerminali", p.prezzoTerminali);
                        command.Parameters.AddWithValue("@prezzoBoccola", p.prezzoBoccola);
                        command.Parameters.AddWithValue("@prezzoTop", p.prezzoTop);
                        command.Parameters.AddWithValue("@prezzoPresa", p.prezzoPresa);
                        command.Parameters.AddWithValue("@prezzoMulti2x3", p.prezzoMulti2x3);
                        command.Parameters.AddWithValue("@prezzoMulti3x3", p.prezzoMulti3x3);
                        command.ExecuteNonQuery();
                    }
                }
            }

            connection.Close();
        }
    }

    // Metodo per leggere i dati dalla tabella di esempio

    /// <summary>
    /// The ReadData
    /// </summary>
    /// <returns>The <see cref="List{Listino}"/></returns>
    public List<Listino> ReadData()
    {
        List<Listino> prodotti = new List<Listino>();

        using (var conn = new SQLiteConnection(connectionString))
        {
            conn.Open();
            var cmd = new SQLiteCommand("SELECT codice, immagine, descrizione, larghezza," +
                "altezza, profondita, dimensioni, prezzoListino, prezzoMelanimici, prezzoPuntali," +
                "prezzoRuote, prezzoTerminali, prezzoBoccola, prezzoTop, prezzoPresa, prezzoMulti2x3, " +
                "prezzoMulti3x3 FROM listino", conn);

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Image aus = ConvertiByteArrayInImage((byte[])reader["immagine"]);

                    prodotti.Add(new Listino(
                        reader["codice"].ToString(),
                        aus,
                        reader["descrizione"].ToString(),
                        reader["larghezza"].ToString(),
                        reader["altezza"].ToString(),
                        reader["profondita"].ToString(),
                        reader["dimensioni"].ToString(),
                        reader["prezzoListino"].ToString(),
                        reader["prezzoMelanimici"].ToString(),
                        reader["prezzoPuntali"].ToString(),
                        reader["prezzoRuote"].ToString(),
                        reader["prezzoTerminali"].ToString(),
                        reader["prezzoBoccola"].ToString(),
                        reader["prezzoTop"].ToString(),
                        reader["prezzoPresa"].ToString(),
                        reader["prezzoMulti2x3"].ToString(),
                        reader["prezzoMulti3x3"].ToString()
                    ));
                }
            }
        }

        return prodotti;
    }

    /// <summary>
    /// The ConvertiByteArrayInImage
    /// </summary>
    /// <param name="byteArrayIn">The byteArrayIn<see cref="byte[]"/></param>
    /// <returns>The <see cref="Image"/></returns>
    private Image ConvertiByteArrayInImage(byte[] byteArrayIn)
    {
        using (var ms = new MemoryStream(byteArrayIn))
        {
            return Image.FromStream(ms);
        }
    }

    /// <summary>
    /// The ConvertiImmagineInByte
    /// </summary>
    /// <param name="image">The image<see cref="Image"/></param>
    /// <returns>The <see cref="byte[]"/></returns>
    public byte[] ConvertiImmagineInByte(Image image)
    {
        using (var ms = new MemoryStream())
        {
            Bitmap bmp = new Bitmap(image);
            bmp.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }
    }
}
