namespace RapidStudio
{
  using System;
  using System.Collections.Generic;
  using System.Globalization;
  using System.IO;

  class Element
  {
    public Element()
    {
      this.Lines = new List<string>();
    }

    public enum ElementType
    {
      Page,
      Picture,
      Text,
      RTFItem,
      BG
    }

    public ElementType Type { get; set; }
    public List<string> Lines { get; set; }
    public double Top { get; set; }
    public double Bottom
    {
      get
      {
        return this.Top + this.Height;
      }
    }
    public double Left { get; set; }

    public double Right
    {
      get
      {
        return this.Left + this.Width;
      }
    }
    public double Height { get; set; }
    public double Width { get; set; }
    public string Source { get; set; }
    public string PictureFileName { get; set; }

    public string DateCaption
    {
      get
      {
        if (!string.IsNullOrEmpty(this.PictureFileName))
        {
          DateTime d;
          if (DateTime.TryParseExact(Path.GetFileNameWithoutExtension(this.PictureFileName), "yyyy-MM-dd HH.mm.ss", new CultureInfo("en-US"), DateTimeStyles.None, out d))
          {
            return d.ToString("d MMM");
          }
        }

        return "???";
      }
    }

    public string Output(int index = 0)
    {
      string output = string.Empty;

      foreach (string line in this.Lines)
      {
        string[] values = line.Split(new string[] { " = " }, StringSplitOptions.RemoveEmptyEntries);
        switch (values[0])
        {
          case "PICTURE":
            if (this.Type == ElementType.Picture)
            {
              output += string.Format("{0} = {1}", values[0], index);
            }
            else
            {
              output += line;
            }
            break;
          case "RTF_ITEM":
          case "TEXT":
          case "BG":
            output += string.Format("{0} = {1}", values[0], index);
            break;
          case "PIC_LEFT": output += string.Format("{0} = {1}", values[0], this.Left); break;
          case "PIC_TOP": output += string.Format("{0} = {1}", values[0], this.Top); break;
          case "PIC_WIDTH": output += string.Format("{0} = {1}", values[0], this.Width); break;
          case "PIC_HEIGHT": output += string.Format("{0} = {1}", values[0], this.Height); break;
          case "PIC_ORDER": output += string.Format("{0} = {1}", values[0], index - 1); break;
          case "PIC_FILE_NAME": output += string.Format("{0} = {1}", values[0], this.PictureFileName); break;
          default: output += line; break;
        }
        output += "\r\n";
      }

      return output;
    }
  }
}
