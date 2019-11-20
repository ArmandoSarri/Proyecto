using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proyecto_ArmandoSarrionGonzalez
{
    public partial class ColorPicker : UserControl
    {
        private DrawingAttributes drawingAttributes = new DrawingAttributes();
        private Color selectedColor = Colors.Transparent;
        private Boolean IsMouseDown = false;

        public ColorPicker()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(ColorPicker_Loaded);
        }
       
        public Color SelectedColor
        {
            get { return selectedColor; }
            private set
            {
                if (selectedColor != value)
                {
                    selectedColor = value;
                    CreateAlphaLinearBrush();
                    UpdateTextBoxes();
                    UpdateInk();
                }
            }
        }
      
        private void ColorPicker_Loaded(object sender, RoutedEventArgs e)
        {
            SelectedColor = Colors.Black;
        }

        private void CreateAlphaLinearBrush()
        {
            Color startColor = Color.FromArgb(
                    (byte)0,
                    SelectedColor.R,
                    SelectedColor.G,
                    SelectedColor.B);

            Color endColor = Color.FromArgb(
                    (byte)255,
                    SelectedColor.R,
                    SelectedColor.G,
                    SelectedColor.B);

            LinearGradientBrush alphaBrush =
                new LinearGradientBrush(startColor, endColor,
                    new Point(0, 0), new Point(1, 0));

            AlphaBorder.Background = alphaBrush;
        }

        private void Swatch_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image img = (sender as Image);
            ColorImage.Source = img.Source;
        }

        private void CanvImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (!IsMouseDown)
                return;

            try
            {
                CroppedBitmap cb = new CroppedBitmap(ColorImage.Source as BitmapSource,
                    new Int32Rect((int)Mouse.GetPosition(CanvImage).X,
                        (int)Mouse.GetPosition(CanvImage).Y, 1, 1));

                byte[] pixels = new byte[4];

                try
                {
                    cb.CopyPixels(pixels, 4, 0);
                }
                catch (Exception ex)
                {

                }

                ellipsePixel.SetValue(Canvas.LeftProperty,
                                     (double)(Mouse.GetPosition(CanvImage).X - 5));
                ellipsePixel.SetValue(Canvas.TopProperty,
                                     (double)(Mouse.GetPosition(CanvImage).Y - 5));
                CanvImage.InvalidateVisual();
                SelectedColor = Color.FromArgb((byte)AlphaSlider.Value,
                                                pixels[2], pixels[1], pixels[0]);
            }
            catch (Exception exc)
            {
                
            }
        }

        private void UpdateTextBoxes()
        {
            txtAlpha.Text = SelectedColor.A.ToString();
            txtAlphaHex.Text = SelectedColor.A.ToString("X");
            txtRed.Text = SelectedColor.R.ToString();
            txtRedHex.Text = SelectedColor.R.ToString("X");
            txtGreen.Text = SelectedColor.G.ToString();
            txtGreenHex.Text = SelectedColor.G.ToString("X");
            txtBlue.Text = SelectedColor.B.ToString();
            txtBlueHex.Text = SelectedColor.B.ToString("X");
            txtAll.Text = String.Format("#{0}{1}{2}{3}",
                    txtAlphaHex.Text, txtRedHex.Text,
                    txtGreenHex.Text, txtBlueHex.Text);
        }

        private void UpdateInk()
        {
            drawingAttributes.Color = SelectedColor;
            drawingAttributes.StylusTip = StylusTip.Ellipse;
            drawingAttributes.Width = 5;
           
            foreach (Stroke s in previewPresenter.Strokes)
            {
                s.DrawingAttributes = drawingAttributes;
            }
        }

        private void AlphaSlider_ValueChanged(object sender,
            RoutedPropertyChangedEventArgs<double> e)
        {
            SelectedColor =
                Color.FromArgb(
                    (byte)AlphaSlider.Value,
                    SelectedColor.R,
                    SelectedColor.G,
                    SelectedColor.B);
        }

        private void CanvImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            IsMouseDown = true;
        }

        private void CanvImage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            IsMouseDown = false;
        }
        
    }
}
