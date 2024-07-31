using PreventiviScolastici;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Xml.Serialization;

[Serializable]
public class AppState
{
    public decimal sconto { get; set; }
    public List<Acquisti> acquisti { get; set; }
    public void SaveState(AppState state)
    {
        using (SaveFileDialog saveFileDialog = new SaveFileDialog())
        {
            saveFileDialog.Filter = "XML Files (*.xml)|*.xml";
            saveFileDialog.Title = "Salva stato applicazione";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(AppState));
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    serializer.Serialize(writer, state);
                }
            }
        }
    }

    public AppState LoadState()
    {
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = "XML Files (*.xml)|*.xml";
            openFileDialog.Title = "Apri stato applicazione";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(AppState));
                using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                {
                    return (AppState)serializer.Deserialize(reader);
                }
            }
        }
        return null;
    }
}