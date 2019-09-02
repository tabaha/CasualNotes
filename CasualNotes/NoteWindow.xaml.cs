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
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace CasualNotes {
  /// <summary>
  /// Interaction logic for NoteWindow.xaml
  /// </summary>
  /// 
  public partial class NoteWindow : Window {

    //public event EventHandler NoteCreated;

    public static readonly double CollapsedHeaderSize = 7.5;
    public static readonly double ExpandedHeaderSize = 32;

    private bool headerIsExpanded = false;

    private NoteManager NoteManager;

    public string NoteText {
      get {
        return txtNote.Text;
      }
      set {
        txtNote.Text = value;
      }
    }

    //public Brush Background {
    //  get {
    //    return Background;
    //  }
    //  set {
    //    base.Background = value;
    //    txtNote.Background = value;
    //  }
    //}

    public Brush TitleColor {
      get {
        return grdTitle.Background;
      }
      set {
        grdTitle.Background = value;
      }
    }

    public Brush ForegroundColor {
      get {
        return Foreground;
      }
      set {
        Foreground = txtNote.Foreground = txtNote.CaretBrush = value;
      }
    }

    public NoteWindow(NoteManager noteManager) {
      InitializeComponent();

      Background = new SolidColorBrush(Color.FromRgb(51, 51, 51));
      txtNote.Foreground = new SolidColorBrush(Colors.White);
      txtNote.CaretBrush = txtNote.Foreground;
      TitleColor = new SolidColorBrush(Colors.LightGoldenrodYellow);

      NoteManager = noteManager;
      noteManager.Add(this);
    }

    public NoteWindow(NoteManager noteManager, string text, SolidColorBrush titleColor, double width, double height, double top, double left) : this(noteManager) {
      NoteText = text;
      TitleColor = titleColor;
      Width = width;
      Height = height;
      Top = top;
      Left = left;
    }

    public NoteWindow(NoteManager noteManager, string text, List<byte> titleColor, List<byte> backgroundColor, double width, double height, double top, double left) : this(noteManager) {
      NoteText = text;
      if(titleColor.Count == 3)
        TitleColor = new SolidColorBrush(Color.FromRgb(titleColor[0], titleColor[1], titleColor[2]));
      if (titleColor.Count == 4)
        TitleColor = new SolidColorBrush(Color.FromArgb(titleColor[0], titleColor[1], titleColor[2], titleColor[3]));

      if (backgroundColor.Count == 3)
        Background = new SolidColorBrush(Color.FromRgb(backgroundColor[0], backgroundColor[1], backgroundColor[2]));
      if (backgroundColor.Count == 4)
        Background = new SolidColorBrush(Color.FromArgb(backgroundColor[0], backgroundColor[1], backgroundColor[2], backgroundColor[3]));

      Width = width;
      Height = height;
      Top = top;
      Left = left;
    }

    private void GrdTitle_MouseEnter(object sender, MouseEventArgs e) {
      if (!headerIsExpanded) {
        grdMain.RowDefinitions[0].Height = new GridLength(ExpandedHeaderSize);
        headerIsExpanded = true;
        txtNote.Margin = new Thickness(12, CollapsedHeaderSize + 2, 12, 18);
        foreach (UIElement control in grdTitle.Children) {
          control.Visibility = Visibility.Visible;
        }
      }
    }

    private void GrdTitle_MouseLeave(object sender, MouseEventArgs e) {
      if (headerIsExpanded) {
        grdMain.RowDefinitions[0].Height = new GridLength(CollapsedHeaderSize);
        headerIsExpanded = false;
        txtNote.Margin = new Thickness(12, 41.5 - CollapsedHeaderSize, 12, 18);
        foreach (UIElement control in grdTitle.Children) {
          control.Visibility = Visibility.Hidden;
        }
      }
    }

    private void GrdTitle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
      this.DragMove();
    }

    public void SetBackground(string path) {
      Background = new ImageBrush(new BitmapImage(new Uri(path))) { Stretch = Stretch.UniformToFill};
    }


    private void BtnNewNote_Click(object sender, RoutedEventArgs e) {
      var nw = new NoteWindow(NoteManager);
      nw.TitleColor = TitleColor;
      //nw.Show();
    }

    private void BtnCloseNote_Click(object sender, RoutedEventArgs e) {
      NoteManager.Remove(this);
      this.Close();
    }

    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
      
    }

    private void Window_Deactivated(object sender, EventArgs e) {
      NoteManager.UpdateNote(this);
    }

    public CasualNote ToCasualNote() {
      return new CasualNote() {
        Text = NoteText,
        Height = Height,
        Width = Width,
        Left = Left,
        Top = Top,
        TitleColor = TitleColor != null && TitleColor is SolidColorBrush btc ? new List<byte> { btc.Color.R, btc.Color.G, btc.Color.B } : null,
        BackgroundColor = Background != null && Background is SolidColorBrush bbc ? new List<byte> { bbc.Color.R, bbc.Color.G, bbc.Color.B } : null,
      };
    }
  }
}
