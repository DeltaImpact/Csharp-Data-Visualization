using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace WindowsFormsApp1
{
    static class Palette
    {
        private static ColorPalette _monochromePalette;
        private static ColorPalette _monochromePaletteLowValuesHighlitg;
        private static ColorPalette _coloredPalette;
        private static ColorPalette _coloredPaletteLowValuesHighlitg;

        static Palette()
        {
            _monochromePalette = GenerateMonochromePalette();
            _monochromePaletteLowValuesHighlitg = GenerateMonochromePalette(true);
            _coloredPalette = GenerateColoredPalette();
            _coloredPaletteLowValuesHighlitg = GenerateColoredPalette(true);
        }

        public static ColorPalette GetMonochromePalette()
        {
            return _monochromePalette;
        }

        public static ColorPalette GetMonochromePaletteLowValuesHighlitg()
        {
            return _monochromePaletteLowValuesHighlitg;
        }

        public static ColorPalette GetColoredPalette()
        {
            return _coloredPalette;
        }

        public static ColorPalette GetColoredPaletteLowValuesHighlitg()
        {
            return _coloredPaletteLowValuesHighlitg;
        }

        /// <summary>
        /// Generates and return white to black palette.
        /// </summary>
        /// <param name="lowValuesHighlight">Add to palette additional colors, for low values, if true. False by default.</param>
        private static ColorPalette GenerateMonochromePalette(bool lowValuesHighlight = false)
        {
            Bitmap bitmap = new Bitmap(10, 10, PixelFormat.Format8bppIndexed);
            ColorPalette pal = bitmap.Palette;

            List<ColorInPalette> mainPaletteColors = new List<ColorInPalette>();

            mainPaletteColors.Add(new ColorInPalette(0, Color.White));
            mainPaletteColors.Add(new ColorInPalette(50, Color.Gray));
            if (lowValuesHighlight)
            {
                mainPaletteColors.Add(new ColorInPalette(85, Color.YellowGreen));
                mainPaletteColors.Add(new ColorInPalette(95, Color.Aquamarine));
            }

            mainPaletteColors.Add(new ColorInPalette(100, Color.Black));

            mainPaletteColors = mainPaletteColors.OrderBy(col => col.Coord).ToList();

            for (int i = 0; i < mainPaletteColors.Count; i++)
            {
                if (mainPaletteColors.Count - 1 != i)
                {
                    int keyCurrent = mainPaletteColors[i].Coord;
                    int keyAbove = mainPaletteColors[i + 1].Coord;

                    List<Color> colorsBetween = RgbLinearInterpolate(mainPaletteColors[i].Color,
                        mainPaletteColors[i + 1].Color,
                        keyAbove - keyCurrent);
                    for (int j = 0; j < colorsBetween.Count; j++)
                    {
                        pal.Entries[keyCurrent + j] = colorsBetween[j];
                    }
                }
            }

            return pal;
        }

        /// <summary>
        /// Generates and return colored palette.
        /// </summary>
        /// <param name="lowValuesHighlight">Add to palette additional colors, for low values, if true. False by default.</param>
        public static ColorPalette GenerateColoredPalette(bool lowValuesHighlight = false)
        {
            Bitmap bitmap = new Bitmap(10, 10, PixelFormat.Format8bppIndexed);
            ColorPalette pal = bitmap.Palette;

            List<ColorInPalette> paletteColors = new List<ColorInPalette>();

            paletteColors.Add(new ColorInPalette(0, Color.White));
            paletteColors.Add(new ColorInPalette(5, Color.LightYellow));
            paletteColors.Add(new ColorInPalette(10, Color.Yellow));
            paletteColors.Add(new ColorInPalette(20, Color.Orange));
            paletteColors.Add(new ColorInPalette(30, Color.Red));
            paletteColors.Add(new ColorInPalette(40, Color.IndianRed));
            paletteColors.Add(new ColorInPalette(50, Color.MediumPurple));
            paletteColors.Add(new ColorInPalette(65, Color.Blue));
            paletteColors.Add(new ColorInPalette(75, Color.DarkBlue));
            if (lowValuesHighlight)
            {
                paletteColors.Add(new ColorInPalette(85, Color.YellowGreen));
                paletteColors.Add(new ColorInPalette(95, Color.Aquamarine));
            }

            paletteColors.Add(new ColorInPalette(100, Color.Black));

            paletteColors = paletteColors.OrderBy(col => col.Coord).ToList();

            for (int i = 0; i < paletteColors.Count; i++)
            {
                if (paletteColors.Count - 1 != i)
                {
                    int keyCurrent = paletteColors[i].Coord;
                    int keyAbove = paletteColors[i + 1].Coord;

                    List<Color> colorsBetween = RgbLinearInterpolate(paletteColors[i].Color,
                        paletteColors[i + 1].Color,
                        keyAbove - keyCurrent);
                    for (int j = 0; j < colorsBetween.Count; j++)
                    {
                        pal.Entries[keyCurrent + j] = colorsBetween[j];
                    }
                }
            }

            return pal;
        }

        private static List<Color> RgbLinearInterpolate(Color start, Color end, int colorCount)
        {
            List<Color> ret = new List<Color>();

            // linear interpolation lerp (r,a,b) = (1-r)*a + r*b = (1-r)*(ax,ay,az) + r*(bx,by,bz)
            for (int n = 0; n < colorCount; n++)
            {
                double r = (double) n / (double) (colorCount - 1);
                double nr = 1.0 - r;
                double A = (nr * start.A) + (r * end.A);
                double R = (nr * start.R) + (r * end.R);
                double G = (nr * start.G) + (r * end.G);
                double B = (nr * start.B) + (r * end.B);

                ret.Add(Color.FromArgb((byte) A, (byte) R, (byte) G, (byte) B));
            }

            return ret;
        }

        //Was useful. Now not used.
        private static ColorPalette GetWhiteToBlackPalette()
        {
            Bitmap bitmap = new Bitmap(10, 10, PixelFormat.Format8bppIndexed);

            ColorPalette pal = bitmap.Palette;
            for (int i = 0; i < 256; i++)
                pal.Entries[i] = Color.FromArgb(255, i, i, i);
            return pal;
        }
    }

    class ColorInPalette
    {
        public int Coord;
        public Color Color;
        public int Position;


        public ColorInPalette(int pos, Color color)
        {
            Position = pos;
            Coord = (int) ConvertBetweenRanges(100 - pos, 0, 100, 0, 256);
            Color = color;
        }

        private static double ConvertBetweenRanges
            (double value, double From1, double From2, double To1, double To2)
        {
            return (value - From1) / (From2 - From1) * (To2 - To1) + To1;
        }
    }
}