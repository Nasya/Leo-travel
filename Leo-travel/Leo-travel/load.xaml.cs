using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Interop;
using System.Windows.Threading;

namespace Leo_travel
{
    /// <summary>
    /// Логика взаимодействия для load.xaml
    /// </summary>
    public partial class load : Window
    {

        public load()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri(@"E:\Projects\Leo-travel\Leo-travel\Leo-travel\pics\waiting.gif", UriKind.RelativeOrAbsolute);
            bi.EndInit();
            imBackGround.Source = bi;
            _source = GetSource();
            imBackGround.Source = _source;
            ImageAnimator.Animate(_bitmap, OnFrameChanged);
        }
        Bitmap _bitmap;

        private BitmapSource GetSource()
        {
            if (_bitmap == null)
            {
                _bitmap = new Bitmap(@"E:\Projects\Leo-travel\Leo-travel\Leo-travel\pics\waiting.gif");
            }
            IntPtr handle = IntPtr.Zero;
            handle = _bitmap.GetHbitmap();
            return Imaging.CreateBitmapSourceFromHBitmap(
                    handle, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }
        BitmapSource _source;

        private void FrameUpdatedCallback()
        {
            ImageAnimator.UpdateFrames();
            if (_source != null)
                _source.Freeze();
            _source = GetSource();
            imBackGround.Source = _source;
            InvalidateVisual();
        }

        private void OnFrameChanged(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                                    new Action(FrameUpdatedCallback));
        }
    }

}
