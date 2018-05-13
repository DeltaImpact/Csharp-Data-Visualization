using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using NAudio.Wave; // Для доступа к к звуковой карте
using NAudio.Dsp; // Для FFT
using System.Drawing.Imaging;
using System.Runtime.InteropServices; // for Marshal


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private static int _buffersCaptured;
        private static int _buffersCapturedOnPause = 0;

        private static double _unanalyzedMaxSec;

        private static List<short>
            _unanalyzedValues = new List<short>();

        private static List<List<double>> _specData;
        private static int _specWidth = 600;
        private static int _specHeight;
        int _pixelsPerBuffer;

        private int _rate;
        private int _bufferUpdateHz;

        int _fftSize;

        private bool _activeRendering = false;

        public Form1()
        {
            InitializeComponent();
            FillGradient();
            SetBufferText(0);
            label4.Text = "Статус: ожидание";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (_activeRendering == false)
            {
                _activeRendering = true;

                // sound card configuration
                _rate = 44100;
                _bufferUpdateHz = 20;
                _pixelsPerBuffer = 10;

                // FFT/spectrogram configuration
                _unanalyzedMaxSec = 2.5;
                _fftSize = 1024; // must be a multiple of 2

                _specHeight = _fftSize / 2;

                // fill spectrogram data with empty values
                _specData = new List<List<double>>();
                List<double> data_empty = new List<double>();
                for (int i = 0; i < _specHeight; i++) data_empty.Add(0);
                for (int i = 0; i < _specWidth; i++) _specData.Add(data_empty);

                // resize picturebox to accomodate data shape
                pictureBox1.Width = _specData.Count;
                pictureBox1.Height = _specData[0].Count;
                pictureBox1.Location = new Point(0, 0);

                // start listening
                var waveIn = new WaveIn();
                waveIn.DeviceNumber = 0;
                waveIn.DataAvailable += Audio_buffer_captured;
                waveIn.WaveFormat = new WaveFormat(_rate, 1);
                waveIn.BufferMilliseconds = 1000 / _bufferUpdateHz;
                waveIn.StartRecording();

                timer1.Enabled = true;
            }
            else
            {
                //buffersCapturedOnPause = buffers_captured;
                _activeRendering = false;
                button1.Text = "возобновить";
            }
        }

        /// <summary>
        /// analyze all unanalyzed data
        /// Аализирует все неанализированные данные
        /// </summary>
        void Analyze_values()
        {
            if (_fftSize == 0) return;
            if (_unanalyzedValues.Count < _fftSize) return;
            string.Format("Статус: не обработано {0}", _unanalyzedValues.Count);
            while (_unanalyzedValues.Count >= _fftSize) Analyze_chunk();
            label4.Text = "Статус: выполнено";
        }

        /// <summary>
        /// break-off the first chunk of unanalyzed_values and analyze it
        /// Взять первый чанк unanalyzed_values и проанализировать его
        /// </summary>
        void Analyze_chunk()
        {
            // remove the left-most (oldest) column of data
            _specData.RemoveAt(0);

            // insert new data to the right-most (newest) position
            List<double> newData = new List<double>();


            // prepare the complex data which will be FFT'd
            Complex[] fft_buffer = new Complex[_fftSize];
            for (int i = 0; i < _fftSize; i++)
            {
                //fft_buffer[i].X = (float)unanalyzed_values[i]; // no window
                fft_buffer[i].X = (float) (_unanalyzedValues[i] * FastFourierTransform.HammingWindow(i, _fftSize));
                fft_buffer[i].Y = 0;
            }

            // perform the FFT
            FastFourierTransform.FFT(true, (int) Math.Log(_fftSize, 2.0), fft_buffer);

            // fill that new data list with fft values
            for (int i = 0; i < _specData[_specData.Count - 1].Count; i++)
            {
                // should this be sqrt(X^2+Y^2)?
                double val;
                val = (double) fft_buffer[i].X + (double) fft_buffer[i].Y;
                val = Math.Abs(val);
                if (numericUpDown1.Value == 0) val = Math.Log(val);
                //if (checkBox1.Checked) val = Math.Log(val);
                newData.Add(val);
            }

            newData.Reverse();
            _specData.Insert(_specData.Count, newData); // replaces, doesn't append

            // remove a certain amount of unanalyzed data
            _unanalyzedValues.RemoveRange(0, _fftSize / _pixelsPerBuffer);
        }

        void FillGradient()
        {
            Bitmap bitmap = new Bitmap(pictureBoxGradient.Width, pictureBoxGradient.Height);
            Bitmap bitmapWithColors = new Bitmap(10, 10, PixelFormat.Format8bppIndexed);

            if (colorMode1RadioButton.Checked)
            {
                if (checkBoxLowValuesHighlight.Checked)
                {
                    bitmapWithColors.Palette = Palette.GetMonochromePaletteLowValuesHighlitg();
                }

                else
                {
                    bitmapWithColors.Palette = Palette.GetMonochromePalette();
                }
            }

            if (colorMode2RadioButton.Checked)
            {
                if (checkBoxLowValuesHighlight.Checked)
                {
                    bitmapWithColors.Palette = Palette.GetColoredPaletteLowValuesHighlitg();
                }

                else
                {
                    bitmapWithColors.Palette = Palette.GetColoredPalette();
                }
            }


            for (int i = 0; i < bitmap.Height; i++)
            {
                int numberOfColor = (int) convertBetweenRanges(i, 0, bitmap.Height, 0, 256);
                Color color = bitmapWithColors.Palette.Entries[numberOfColor];
                for (int j = 0; j < bitmap.Width; j++)
                {
                    bitmap.SetPixel(j, i, color);
                }
            }

            pictureBoxGradient.Image = bitmap;
        }

        double convertBetweenRanges
            (double value, double From1, double From2, double To1, double To2)
        {
            return (value - From1) / (From2 - From1) * (To2 - To1) + To1;
        }

        void Update_bitmap_with_data()
        {
            Bitmap bitmap = new Bitmap(_specData.Count, _specData[0].Count, PixelFormat.Format8bppIndexed);

            if (colorMode1RadioButton.Checked)
            {
                if (checkBoxLowValuesHighlight.Checked)
                {
                    bitmap.Palette = Palette.GetMonochromePaletteLowValuesHighlitg();
                }

                else
                {
                    bitmap.Palette = Palette.GetMonochromePalette();
                }
            }

            if (colorMode2RadioButton.Checked)
            {
                if (checkBoxLowValuesHighlight.Checked)
                {
                    bitmap.Palette = Palette.GetColoredPaletteLowValuesHighlitg();
                }

                else
                {
                    bitmap.Palette = Palette.GetColoredPalette();
                }
            }

            // prepare to access data via the bitmapdata object
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly, bitmap.PixelFormat);

            // create a byte array to reflect each pixel in the image
            byte[] pixels = new byte[bitmapData.Stride * bitmap.Height];

            // fill pixel array with data
            for (int col = 0; col < _specData.Count; col++)
            {
                double scaleFactor;
                scaleFactor = (double) numericUpDown1.Value;
                if (scaleFactor == 0) scaleFactor = 1;


                for (int row = 0; row < _specData[col].Count; row++)
                {
                    int bytePosition = row * bitmapData.Stride + col;
                    double pixelVal = _specData[col][row] * scaleFactor;
                    pixelVal = Math.Max(0, pixelVal);
                    pixelVal = Math.Min(255, pixelVal);
                    pixels[bytePosition] = (byte) (pixelVal);
                }
            }

            // turn the byte array back into a bitmap
            Marshal.Copy(pixels, 0, bitmapData.Scan0, pixels.Length);
            bitmap.UnlockBits(bitmapData);

            // apply the bitmap to the picturebox
            pictureBox1.Image = bitmap;
        }

        /// <summary>
        /// runs every time the recording buffer fills-up with new audio data.
        /// запускается каждый раз, когда буфер записи заполняется новыми аудиоданными
        /// </summary>
        void Audio_buffer_captured(object sender, WaveInEventArgs args)
        {
            if (_activeRendering)
            {
                _buffersCaptured += 1;

                // interpret as 16 bit audio, so each two bytes become one value
                short[] values = new short[args.Buffer.Length / 2];
                for (int i = 0; i < args.BytesRecorded; i += 2)
                {
                    values[i / 2] = (short) ((args.Buffer[i + 1] << 8) | args.Buffer[i + 0]);
                }

                _unanalyzedValues.AddRange(values);

                int unanalyzed_max_count = (int) _unanalyzedMaxSec * _rate;

                if (_unanalyzedValues.Count > unanalyzed_max_count)
                {
                    _unanalyzedValues.RemoveRange(0, _unanalyzedValues.Count - unanalyzed_max_count);
                }

                SetBufferText(values.Length);
            }
        }

        private void SetBufferText(int bufferSize)
        {
            label1.Text = $"Получено буфферов: {_buffersCaptured}";
            label2.Text = $"Размер буффера: {bufferSize}";
            label3.Text = $"Не обработанных значений: {_unanalyzedValues.Count}";
        }

        /// <summary>
        /// every so often clear-out the unanalyzed audio buffer and update the spectrograph
        /// цикл обработки звука и орисовки
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_activeRendering)
            {
                Analyze_values();
                Update_bitmap_with_data();
            }
        }

        private void colorMode1RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            FillGradient();
        }

        private void colorMode2RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            FillGradient();
        }

        private void checkBoxLowValuesHighlight_CheckedChanged(object sender, EventArgs e)
        {
            FillGradient();
        }
    }
}