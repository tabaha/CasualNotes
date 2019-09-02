using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Threading;

namespace CasualNotes {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {

    private NoteManager NoteManager;

    public MainWindow() {
      InitializeComponent();
      //NoteWindow nw = new NoteWindow();
      //nw.Show();
      //242x126

      NoteManager = new NoteManager();

      NoteManager.NewNote += NoteManager_NewNote;
      NoteManager.NoteClosed += NoteManager_NoteClosed;
      NoteManager.NoteTextChanged += NoteManager_NoteTextChanged;

      NoteManager.LoadNotes("CasualNotes.json");

      if(NoteManager.IsEmpty) {
        NoteWindow nw = new NoteWindow(NoteManager);
        nw.Show();
      }

    }

    private void NoteManager_NoteTextChanged(object sender, NoteEventArgs e) {
      var control = lvNotes.Items.Cast<Control>().FirstOrDefault(c => c.Tag == e.NoteWindow);
      if(control != null && control is Button btn) {
        btn.Content = e.NoteWindow.NoteText;
      }
    }

    private void NoteManager_NoteClosed(object sender, NoteEventArgs e) {
      var control = lvNotes.Items.Cast<Control>().FirstOrDefault(c => c.Tag == e.NoteWindow);
      if (control != null)
        lvNotes.Items.Remove(control);
    }

    private void NoteManager_NewNote(object sender, NoteEventArgs e) {
      Button btn = new Button();
      btn.Width = 300;
      btn.Content = e.NoteWindow.NoteText;
      btn.Click += (s, ce) => {
        e.NoteWindow.Show();
        e.NoteWindow.Activate();
      };
      btn.MouseDown += (s, ce) => {
        if (ce.ChangedButton == MouseButton.Middle && ce.ButtonState == MouseButtonState.Pressed) {
          NoteManager.Remove(e.NoteWindow);
          e.NoteWindow.Close();
        }
      };
      btn.Tag = e.NoteWindow;
      int index = lvNotes.Items.Add(btn);
    }

    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
      NoteManager.Close();
    }
  }
}
