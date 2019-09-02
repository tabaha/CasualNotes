using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CasualNotes {
  public class CasualNote {
    public string Text;
    public double Width;
    public double Height;
    public double Top;
    public double Left;
    public List<byte> BackgroundColor;
    public List<byte> TitleColor;

    public CasualNote() { }

    public NoteWindow ToNoteWindow(NoteManager noteManager) {
      return new NoteWindow(noteManager, Text, TitleColor, BackgroundColor, Width, Height, Top, Left);
    }
  }
}
