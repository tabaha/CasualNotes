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

    public string NoteText {
      get {
        return txtNote.Text;
      }
      set {
        txtNote.Text = value;
      }
    }

    public Brush BackgroundColor {
      get {
        return Background;
      }
      set {
        Background = value;
        txtNote.Background = value;
      }
    }

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
        Foreground = txtNote.Foreground = value;
      }
    }

    public NoteWindow() {
      InitializeComponent();

      //BackgroundColor = new SolidColorBrush(Color.FromRgb(51, 51, 51));
      Background = new SolidColorBrush(Color.FromRgb(51, 51, 51));
      txtNote.Foreground = new SolidColorBrush(Colors.White);
      txtNote.CaretBrush = txtNote.Foreground;
    }

    public NoteWindow(string text, SolidColorBrush titleColor, double width, double height, double top, double left) : this() {
      NoteText = text;
      TitleColor = titleColor;
      Width = width;
      Height = height;
      Top = top;
      Left = left;
    }

    //protected void OnNoteCreated(EventArgs eventArgs) {
    //  NoteCreated?.Invoke(this, eventArgs);
    //}

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
      var nw = new NoteWindow();
      nw.TitleColor = TitleColor;
      nw.Show();
    }

    private void BtnCloseNote_Click(object sender, RoutedEventArgs e) {
      this.Close();
    }
  }
}
