namespace RapidStudio
{
  using System.IO;
  using System.Windows.Forms;

  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void cmdBrowseAlbumDirectory_Click(object sender, System.EventArgs e)
    {
      if (fbdAlbumDirectory.ShowDialog() == DialogResult.OK)
      {
        txtAlbumDirectory.Text = fbdAlbumDirectory.SelectedPath;
      }
    }

    private void cmdRemoveCaptions_Click(object sender, System.EventArgs e)
    {
      ClearLog();
      if (Directory.Exists(txtAlbumDirectory.Text))
      {
        RemoveCaptions(txtAlbumDirectory.Text);
      }
      else
      {
        Log(string.Format("{0} does not exist", txtAlbumDirectory.Text));
      }
    }

    private void RemoveCaptions(string path)
    {
      Log("Removing captions:");

      string[] filePaths = Directory.GetFiles(path, "*.pck", SearchOption.AllDirectories);
      InitProgress(filePaths.Length);

      foreach (string filePath in filePaths)
      {
        Log(filePath);

        Page page = new Page(filePath);
        page.RemoveCaptions();

        string output = page.Output();
        File.WriteAllText(filePath, output);

        AdvanceProgress();
      }

      Log("Done");
    }

    private void cmdAddCaptions_Click(object sender, System.EventArgs e)
    {
      ClearLog();
      if (Directory.Exists(txtAlbumDirectory.Text))
      {
        AddCaptions(txtAlbumDirectory.Text);
      }
      else
      {
        Log(string.Format("{0} does not exist", txtAlbumDirectory.Text));
      }
    }

    private void AddCaptions(string path)
    {
      Log("Adding captions:");

      string[] filePaths = Directory.GetFiles(path, "*.pck", SearchOption.AllDirectories);
      InitProgress(filePaths.Length);

      foreach (string filePath in filePaths)
      {
        Log(filePath);

        Page page = new Page(filePath);
        page.AddCaptions();
        string output = page.Output();
        File.WriteAllText(filePath, output);

        AdvanceProgress();
      }

      Log("Done");
    }

    #region Logging

    private void ClearLog()
    {
      txtLog.Text = string.Empty;
    }

    private void Log(string message, bool newLine = true)
    {
      txtLog.Text += message + (newLine ? "\r\n" : string.Empty);
    }

    #endregion

    #region ProgressBar

    private void InitProgress(int max)
    {
      prg.Minimum = 0;
      prg.Maximum = max;
      prg.Value = 0;
    }

    private void AdvanceProgress(int delta = 1)
    {
      prg.Value += delta;
    }

    #endregion
  }
}
