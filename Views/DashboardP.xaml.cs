using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace Bloc3_Caviste.Views
{
    public partial class Dashboard : Page
    {
        public Dashboard()
        {
            InitializeComponent();
            DataContext = new DashboardViewModel();
        }
    }

    public class DashboardViewModel : INotifyPropertyChanged
    {
        public ISeries[] Series { get; set; }
        public ISeries[] PieSeries { get; set; }

        public DashboardViewModel()
        {
            // Graphique en barres simple
            Series = new ISeries[]
            {
                new ColumnSeries<double>
                {
                    Name = "Ventes",
                    Values = new double[] { 15, 25, 18, 30, 12 },
                    Fill = new SolidColorPaint(new SKColor(237, 212, 166)),
                    Stroke = new SolidColorPaint(new SKColor(61, 29, 28)) { StrokeThickness = 1.5f }
                }
            };

            // Graphique en secteurs simple
            PieSeries = new ISeries[]
            {
                new PieSeries<double>
                {
                    Name = "Rouge",
                    Values = new double[] { 30 },
                    Fill = new SolidColorPaint(new SKColor(139, 69, 19))
                },
                new PieSeries<double>
                {
                    Name = "Blanc", 
                    Values = new double[] { 25 },
                    Fill = new SolidColorPaint(new SKColor(255, 250, 205))
                },
                new PieSeries<double>
                {
                    Name = "Rosé",
                    Values = new double[] { 18 },
                    Fill = new SolidColorPaint(new SKColor(255, 182, 193))
                },
                new PieSeries<double>
                {
                    Name = "Champagne",
                    Values = new double[] { 15 },
                    Fill = new SolidColorPaint(new SKColor(255, 215, 0))
                },
                new PieSeries<double>
                {
                    Name = "Autres",
                    Values = new double[] { 12 },
                    Fill = new SolidColorPaint(new SKColor(237, 212, 166))
                }
            };
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
