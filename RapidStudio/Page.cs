namespace RapidStudio
{
  using System;
  using System.Collections.Generic;
  using System.IO;
  using System.Linq;
  using static RapidStudio.Element;

  class Page
  {
    const double Seperator = 0.5;
    const double CaptionHeight = 1;
    const double DateWidth = 1.5;
    public Page(string path)
    {
      Elements = Page.GetElements(path);
    }
    public List<Element> Elements { get; set; }

    public Element PageElement
    {
      get
      {
        return this.Elements.First(e => e.Type == ElementType.Page);
      }
    }

    public string Output()
    {
      string output = string.Empty;

      foreach (Element element in this.Elements.Where(e => e.Type == ElementType.Page))
      {
        output += element.Output() + "\r\n";
      }

      int index = 1;

      foreach (Element element in this.Elements.Where(e => e.Type == ElementType.Text).OrderBy(e => e.Top).ThenBy(e => e.Left))
      {
        output += element.Output(index) + "\r\n";
        index++;
      }

      foreach (Element element in this.Elements.Where(e => e.Type != ElementType.Page && e.Type != ElementType.Text).OrderBy(e => e.Top).ThenBy(e => e.Left))
      {
        output += element.Output(index) + "\r\n";
        index++;
      }

      return output;
    }

    private static List<Element> GetElements(string path)
    {
      List<Element> elements = new List<Element>();
      Element element = null;

      using (TextReader textReader = File.OpenText(path))
      {
        string[] lines = textReader.ReadToEnd().Split(new string[] { "\r\n" }, StringSplitOptions.None);

        for (int iLine = 0; iLine < lines.Length; iLine++)
        {
          string line = lines[iLine];
          string nextLine = string.Empty;
          if (iLine < lines.Length - 1) { nextLine = lines[iLine + 1]; }

          if (string.IsNullOrEmpty(line) && nextLine != "RTF_END")
          {
            element = null;
          }
          else
          {
            string[] values = line.Split(new string[] { " = " }, StringSplitOptions.RemoveEmptyEntries);

            if (element == null)
            {
              element = new Element();
              switch (values[0])
              {
                case "SIZE_X": element.Type = ElementType.Page; break;
                case "PICTURE": element.Type = ElementType.Picture; break;
                case "RTF_ITEM": element.Type = ElementType.RTFItem; break;
                case "TEXT": element.Type = ElementType.Text; break;
                case "BG": element.Type = ElementType.BG; break;
                default: throw new Exception(string.Format("Unknown element type: {0}", values[0]));
              }
              elements.Add(element);
            }

            element.Lines.Add(line);
            element.Source += line + "\r\n";

            if (values.Length > 0)
            {
              switch (values[0])
              {
                case "PIC_LEFT":
                  element.Left = double.Parse(values[1]);
                  element.Left = Math.Round(element.Left * 2, 0) / 2;
                  break;
                case "PIC_TOP":
                  element.Top = double.Parse(values[1]);
                  element.Top = Math.Round(element.Top * 2, 0) / 2;
                  break;
                case "PIC_WIDTH":
                case "SIZE_X":
                  element.Width = double.Parse(values[1]);
                  element.Width = Math.Round(element.Width * 2, 0) / 2;
                  break;
                case "PIC_HEIGHT":
                case "SIZE_Y":
                  element.Height = double.Parse(values[1]);
                  element.Height = Math.Round(element.Height * 2, 0) / 2;
                  break;
                case "PIC_FILE_NAME":
                  element.PictureFileName = (values.Length > 1 ? values[1] : string.Empty);
                  break;
              }
            }
          }
        }
      }

      return elements;
    }

    public void RemoveCaptions()
    {
      this.Elements.RemoveAll(e => e.Type == ElementType.RTFItem && e.Height <= CaptionHeight);
    }

    public void AddCaptions()
    {
      List<Element> captions = new List<Element>();
      foreach (Element element in this.Elements.Where(e => e.Type == ElementType.Picture))
      {
        if (element.Bottom < this.PageElement.Height - CaptionHeight - Seperator)
        {
          if (!this.Elements.Any(e => e.Type == ElementType.Picture && ((e.Left < element.Right && e.Right > element.Left) || (e.Right > element.Left && e.Left < element.Right)) && e.Top >= element.Bottom && e.Top < element.Bottom + CaptionHeight + Seperator))
          {
            Element caption = new Element
            {
              Type = ElementType.RTFItem,
              Top = element.Bottom,
              Left = element.Left,
              Height = CaptionHeight,
              Width = element.Width - DateWidth,
              Lines = new List<string>
            {
              "RTF_ITEM = 0",
              "PIC_LEFT = 0",
              "PIC_TOP = 0",
              "PIC_WIDTH = 0",
              "PIC_HEIGHT = 0",
              "PIC_ROTATE = 0",
              "PIC_EFFECT =",
              "PIC_ORDER = 0",
              "PIC_MASK_FILE =",
              "PIC_OPACITY = 100",
              "PIC_EDIT_TYPE = 2",
              "TEXT_AUTO_FONT_SIZE = 0",
              "TEXT_ALIGN = 0",
              "TEXT_IS_FOLD_TEXT_ELEMENT = 0",
              "TEXT_SIMPLE = [TEXT]",
              "RTF_BEGIN",
              "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang7177{\\fonttbl{\\f0\\fnil\\fcharset0 Arial;}}",
              "{\\colortbl ;\\red255\\green255\\blue255;\\red0\\green0\\blue0;}",
              "{\\*\\generator Riched20 5.50.99.2050;}\\viewkind4\\uc1\\pard\\li150\\highlight1\\fs20 [TEXT]\\par}",
              "RTF_END"
            }
            };
            for (int i = 0; i < caption.Lines.Count; i++)
            {
              if (caption.Lines[i].Contains("[TEXT]"))
              {
                caption.Lines[i] = caption.Lines[i].Replace("[TEXT]", "???");
              }
            }
            captions.Add(caption);

            Element date = new Element
            {
              Type = ElementType.RTFItem,
              Top = element.Bottom,
              Left = element.Left + element.Width - DateWidth,
              Height = CaptionHeight,
              Width = DateWidth,
              Lines = new List<string>
            {
              "RTF_ITEM = 0",
              "PIC_LEFT = 0",
              "PIC_TOP = 0",
              "PIC_WIDTH = 0",
              "PIC_HEIGHT = 0",
              "PIC_ROTATE = 0",
              "PIC_EFFECT =",
              "PIC_ORDER = 0",
              "PIC_MASK_FILE =",
              "PIC_OPACITY = 100",
              "PIC_EDIT_TYPE = 2",
              "TEXT_AUTO_FONT_SIZE = 0",
              "TEXT_ALIGN = 0",
              "TEXT_IS_FOLD_TEXT_ELEMENT = 0",
              "TEXT_SIMPLE = [TEXT]",
              "RTF_BEGIN",
              "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang7177{\\fonttbl{\\f0\\fnil\\fcharset0 Arial;}}",
              "{\\colortbl ;\\red255\\green255\\blue255;\\red0\\green0\\blue0;}",
              "{\\*\\generator Riched20 5.50.99.2050;}\\viewkind4\\uc1\\pard\\li150\\qc\\highlight1\\fs20 [TEXT]\\cf0\\highlight0\\fs24\\par}",
              "RTF_END"
            }
            };
            for (int i = 0; i < date.Lines.Count; i++)
            {
              if (date.Lines[i].Contains("[TEXT]"))
              {
                date.Lines[i] = date.Lines[i].Replace("[TEXT]", element.DateCaption);
              }
            }
            captions.Add(date);
          }
        }
      }
      this.Elements.AddRange(captions);
    }
  }
}
