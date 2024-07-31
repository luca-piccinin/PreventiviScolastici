namespace PreventiviScolastici
{
    using System;
    using System.Data.SQLite;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;

    /// <summary>
    /// Defines the <see cref="DataBaseImmagini" />
    /// </summary>
    internal class DataBaseImmagini
    {
        /// <summary>
        /// Defines the connectionString
        /// </summary>
        private string connectionString = $"Data Source = immagini.db; Version=3;";

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
                    string sql = "CREATE TABLE immagini (" +
                    " codice VARCHAR(8) PRIMARY KEY," +
                    " immagine BLOB)";
                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        /// <summary>
        /// The DeleteTable
        /// </summary>
        public void DeleteTable()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string sql = "DROP TABLE IF EXISTS immagini";

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
                    command.Parameters.AddWithValue("@tableName", "immagini");

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
            using (var cmd = new SQLiteCommand("SELECT COUNT(*) FROM immagini WHERE codice = @codice", conn))
            {
                cmd.Parameters.AddWithValue("@codice", codice);
                long count = (long)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        /// <summary>
        /// The find
        /// </summary>
        /// <param name="codice">The codice<see cref="string"/></param>
        /// <returns>The <see cref="Image"/></returns>
        public Image find(string codice)
        {
            Image immagine = null;

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT immagine FROM immagini WHERE codice = @codice";

                using (var cmd = new SQLiteCommand(sql, connection))
                {
                    // Assegna il valore al parametro @codice.
                    cmd.Parameters.AddWithValue("@codice", codice);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Controlla se il valore della colonna 'immagine' non è DBNull.
                            if (reader["immagine"] != DBNull.Value)
                                immagine = ConvertiByteArrayInImage((byte[])reader["immagine"]);
                            else
                                immagine = null;
                        }
                    }
                }
            }

            return immagine;
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
        /// <param name="img">The img<see cref="Image"/></param>
        /// <returns>The <see cref="byte[]"/></returns>
        private byte[] ConvertiImmagineInByte(Image img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, ImageFormat.Jpeg);
                return stream.ToArray();
            }
        }

        /// <summary>
        /// The InsertData
        /// </summary>
        /// <param name="aus">The aus<see cref="Immagini"/></param>
        public void InsertData(Immagini aus)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO immagini (codice, immagine) VALUES (@codice, @immagine)";

                // Verifica se il codice esiste già
                if (!CodiceEsiste(aus.codice, connection))
                {
                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@codice", aus.codice);
                        command.Parameters.AddWithValue("@immagine", ConvertiImmagineInByte(aus.immagine));
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
