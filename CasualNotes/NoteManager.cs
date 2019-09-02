using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace CasualNotes {
  public class NoteEventArgs : EventArgs {

    private NoteWindow noteWindow;

    public NoteWindow NoteWindow {
      get {
        return noteWindow;
      }
      set {
        noteWindow = value;
      }
    }

    public NoteEventArgs(NoteWindow nw) {
      noteWindow = nw;
    }
  }

  public class NoteManager {
    private List<NoteWindow> Notes;

    public event EventHandler<NoteEventArgs> NewNote;
    public event EventHandler<NoteEventArgs> NoteClosed;
    public event EventHandler<NoteEventArgs> NoteTextChanged;

    public bool IsEmpty {
      get {
        return Notes.Count() == 0;
      }
    }

    public NoteManager() {
      Notes = new List<NoteWindow>();
    }

    public void Add(NoteWindow noteWindow, bool show = true) {
      Notes.Add(noteWindow);
      if (show)
        noteWindow.Show();
      OnNewNote(new NoteEventArgs(noteWindow));
    }

    public bool Remove(NoteWindow noteWindow) {
      OnNoteClosed(new NoteEventArgs(noteWindow));
      return Notes.Remove(noteWindow);
    }

    protected virtual void OnNewNote(NoteEventArgs e) {
      NewNote?.Invoke(this, e);
    }
    
    protected virtual void OnNoteClosed(NoteEventArgs e) {
      NoteClosed?.Invoke(this, e);
    }

    protected virtual void OnNoteTextChanged(NoteEventArgs e) {
      NoteTextChanged?.Invoke(this, e);
    }

    public void UpdateNote(NoteWindow nw) {
      OnNoteTextChanged(new NoteEventArgs(nw));
    }

    public void Close() {
      string json = JsonConvert.SerializeObject(Notes.Select(n => n.ToCasualNote()), Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
      using (StreamWriter w = new StreamWriter("CasualNotes.json", false)) {
        w.Write(json);
      };
      foreach (var note in Notes) {
        note.Close();
      }
    }

    public void LoadNotes(string path) {
      try {
        if (File.Exists(path)) {
          var deserialized = JsonConvert.DeserializeObject<List<CasualNote>>(File.ReadAllText(path));
          if (deserialized.Count > 0)
            deserialized.ForEach(cn => cn.ToNoteWindow(this));
        }
      }
      catch (Exception ex) {
        
      }

    }
  }
}
