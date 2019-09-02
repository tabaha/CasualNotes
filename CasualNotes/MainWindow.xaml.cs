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
    public MainWindow() {
      InitializeComponent();
      //NoteWindow nw = new NoteWindow();
      //nw.Show();
      //242x126
      List<SolidColorBrush> colors = new List<SolidColorBrush>() {
        new SolidColorBrush(Colors.Bisque),
        new SolidColorBrush(Colors.CadetBlue),
        new SolidColorBrush(Colors.Chartreuse),
        new SolidColorBrush(Colors.LightYellow),
        new SolidColorBrush(Colors.AliceBlue),
        new SolidColorBrush(Colors.BlanchedAlmond),
        new SolidColorBrush(Colors.BlueViolet),
        new SolidColorBrush(Colors.DeepPink),
        new SolidColorBrush(Colors.DarkViolet),
        new SolidColorBrush(Colors.LightCyan),
        new SolidColorBrush(Colors.LightYellow),
        new SolidColorBrush(Colors.Magenta),
        new SolidColorBrush(Colors.Bisque),
        new SolidColorBrush(Colors.CadetBlue),
        new SolidColorBrush(Colors.Chartreuse),
        new SolidColorBrush(Colors.LightYellow),
        new SolidColorBrush(Colors.AliceBlue),
        new SolidColorBrush(Colors.BlanchedAlmond),
        new SolidColorBrush(Colors.BlueViolet),
        new SolidColorBrush(Colors.DeepPink),
        new SolidColorBrush(Colors.DarkViolet),
        new SolidColorBrush(Colors.LightCyan),
        new SolidColorBrush(Colors.LightYellow),
        new SolidColorBrush(Colors.Magenta),
        new SolidColorBrush(Colors.Bisque),
        new SolidColorBrush(Colors.CadetBlue),
        new SolidColorBrush(Colors.Chartreuse),
        new SolidColorBrush(Colors.LightYellow),
        new SolidColorBrush(Colors.AliceBlue),
        new SolidColorBrush(Colors.BlanchedAlmond),
        new SolidColorBrush(Colors.BlueViolet),
        new SolidColorBrush(Colors.DeepPink),
        new SolidColorBrush(Colors.DarkViolet),
        new SolidColorBrush(Colors.LightCyan),
        new SolidColorBrush(Colors.LightYellow),
        new SolidColorBrush(Colors.Magenta),
      };

      List<Color> betterColors = new List<Color>() {
        Colors.AliceBlue,
        Colors.PaleGoldenrod,
        Colors.Orchid,
        Colors.OrangeRed,
        Colors.Orange,
        Colors.OliveDrab,
        Colors.Olive,
        Colors.OldLace,
        Colors.Navy,
        Colors.NavajoWhite,
        Colors.Moccasin,
        Colors.MistyRose,
        Colors.MintCream,
        Colors.MidnightBlue,
        Colors.MediumVioletRed,
        Colors.MediumTurquoise,
        Colors.MediumSpringGreen,
        Colors.MediumSlateBlue,
        Colors.LightSkyBlue,
        Colors.LightSlateGray,
        Colors.LightSteelBlue,
        Colors.LightYellow,
        Colors.Lime,
        Colors.LimeGreen,
        Colors.PaleGreen,
        Colors.Linen,
        Colors.Maroon,
        Colors.MediumAquamarine,
        Colors.MediumBlue,
        Colors.MediumOrchid,
        Colors.MediumPurple,
        Colors.MediumSeaGreen,
        Colors.Magenta,
        Colors.PaleTurquoise,
        Colors.PaleVioletRed,
        Colors.PapayaWhip,
        Colors.SlateGray,
        Colors.Snow,
        Colors.SpringGreen,
        Colors.SteelBlue,
        Colors.Tan,
        Colors.Teal,
        Colors.SlateBlue,
        Colors.Thistle,
        Colors.Transparent,
        Colors.Turquoise,
        Colors.Violet,
        Colors.Wheat,
        Colors.White,
        Colors.WhiteSmoke,
        Colors.Tomato,
        Colors.LightSeaGreen,
        Colors.SkyBlue,
        Colors.Sienna,
        Colors.PeachPuff,
        Colors.Peru,
        Colors.Pink,
        Colors.Plum,
        Colors.PowderBlue,
        Colors.Purple,
        Colors.Silver,
        Colors.Red,
        Colors.RoyalBlue,
        Colors.SaddleBrown,
        Colors.Salmon,
        Colors.SandyBrown,
        Colors.SeaGreen,
        Colors.SeaShell,
        Colors.RosyBrown,
        Colors.Yellow,
        Colors.LightSalmon,
        Colors.LightGreen,
        Colors.DarkRed,
        Colors.DarkOrchid,
        Colors.DarkOrange,
        Colors.DarkOliveGreen,
        Colors.DarkMagenta,
        Colors.DarkKhaki,
        Colors.DarkGreen,
        Colors.DarkGray,
        Colors.DarkGoldenrod,
        Colors.DarkCyan,
        Colors.DarkBlue,
        Colors.Cyan,
        Colors.Crimson,
        Colors.Cornsilk,
        Colors.CornflowerBlue,
        Colors.Coral,
        Colors.Chocolate,
        Colors.AntiqueWhite,
        Colors.Aqua,
        Colors.Aquamarine,
        Colors.Azure,
        Colors.Beige,
        Colors.Bisque,
        Colors.DarkSalmon,
        Colors.Black,
        Colors.Blue,
        Colors.BlueViolet,
        Colors.Brown,
        Colors.BurlyWood,
        Colors.CadetBlue,
        Colors.Chartreuse,
        Colors.BlanchedAlmond,
        Colors.DarkSeaGreen,
        Colors.DarkSlateBlue,
        Colors.DarkSlateGray,
        Colors.HotPink,
        Colors.IndianRed,
        Colors.Indigo,
        Colors.Ivory,
        Colors.Khaki,
        Colors.Lavender,
        Colors.Honeydew,
        Colors.LavenderBlush,
        Colors.LemonChiffon,
        Colors.LightBlue,
        Colors.LightCoral,
        Colors.LightCyan,
        Colors.LightGoldenrodYellow,
        Colors.LightGray,
        Colors.LawnGreen,
        Colors.LightPink,
        Colors.GreenYellow,
        Colors.Gray,
        Colors.DarkTurquoise,
        Colors.DarkViolet,
        Colors.DeepPink,
        Colors.DeepSkyBlue,
        Colors.DimGray,
        Colors.DodgerBlue,
        Colors.Green,
        Colors.Firebrick,
        Colors.ForestGreen,
        Colors.Fuchsia,
        Colors.Gainsboro,
        Colors.GhostWhite,
        Colors.Gold,
        Colors.Goldenrod,
        Colors.FloralWhite,
        Colors.YellowGreen,
      };
      Random rand = new Random();
      List<NoteWindow> nlist = new List<NoteWindow>();

      //    //var nw = new NoteWindow() { NoteText = s, TitleColor = colors[i], Width=242, Height=126};
      //    var nw = new NoteWindow() { NoteText = s, TitleColor = RandomColor(betterColors, rand), Width = 181.5, Height = 94.5, Top = rand.Next(980), Left = rand.Next(-1920, -160)};

      //for (double left = -1920; left < 1900; left += 182.5) {
      //  for(double top = 0; top < 1000; top+= 70/*95.5*/) {
      //    nlist.Add(new NoteWindow() { NoteText = "", TitleColor = RandomColor(betterColors, rand), Width = 181.5, Height = 94.5, Left = left, Top = top });
    }

    static SolidColorBrush RandomColor(IEnumerable<Color> colors, Random rand) {
      return new SolidColorBrush(colors.ElementAt(rand.Next(0, colors.Count() - 1)));
    }
  }
}
