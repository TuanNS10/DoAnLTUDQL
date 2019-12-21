using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace QuanLyBanHang
{
    /// <summary>
    /// Interaction logic for BieuDo.xaml
    /// </summary>
    public partial class BieuDo : Window
    {
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
        public Func<double, string> YFormatter { get; set; }

        public BieuDo()
        {
            InitializeComponent();

            NgayTruoc.SelectedDate = new DateTime(2015, 1, 1);
            NgaySau.SelectedDate = DateTime.Now;

            NgayTruocMonth.SelectedDate = new DateTime(2015, 1, 1);
            NgaySauMonth.SelectedDate = DateTime.Now;
        }

        private double DemSoLuongSP(int madh)
        {
            var db = new QLBHEntities();
            var soluong = db.ChiTietHoaDons.Where(x => x.MaHD == madh);
            var sl = soluong.Sum(x => x.SoLuong);

            return double.Parse(sl.Value.ToString());
        }

        private void BtnThongke_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var from = DateTime.Now;
                DateTime.TryParse(NgayTruoc.Text, CultureInfo.CreateSpecificCulture("en-US"), DateTimeStyles.None, out from);
                var to = DateTime.Now;
                DateTime.TryParse(NgaySau.Text, CultureInfo.CreateSpecificCulture("en-US"), DateTimeStyles.None, out to);
                
                var db = new QLBHEntities();
                var dhs = db.HoaDons.
                    Where(x => x.NgayLap.Value >= from && x.NgayLap.Value <= to && x.TrangThai == "Đã thanh toán")
                    .OrderBy(x => x.NgayLap).Distinct()
                    .ToList();
               
                SeriesCollection = new SeriesCollection();
                foreach (var item in dhs)
                {
                    if (item != null && item.NgayLap.HasValue)
                    {
                        SeriesCollection.Add(new ColumnSeries
                        {
                            Title = item.NgayLap.Value.ToString("dd/MM/yyyy"),

                            Values = new ChartValues<double> { DemSoLuongSP(item.MaHD) }
                        });
                    }

                }
            }
            catch (Exception ex)
            {

            }

            Formatter = value => value.ToString("N");



            CartesianChart.Series = SeriesCollection;
        }

        private void BtnThongkeMonth_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var from = DateTime.Now;
                DateTime.TryParse(NgayTruocMonth.Text, CultureInfo.CreateSpecificCulture("en-US"), DateTimeStyles.None, out from);
                var to = DateTime.Now;
                DateTime.TryParse(NgaySauMonth.Text, CultureInfo.CreateSpecificCulture("en-US"), DateTimeStyles.None, out to);

                var db = new QLBHEntities();
                var dhs = db.HoaDons.
                    Where(x => x.NgayLap.Value >= from && x.NgayLap.Value <= to && x.TrangThai == "Đã thanh toán")
                    .OrderBy(x => x.NgayLap).Distinct()
                    .ToList(); 

                SeriesCollection = new SeriesCollection();

                //foreach (var item in dhs)
                //{
                //    if (item != null && item.NgayLap.HasValue)
                //    {

                //        //SeriesCollection.Add(new ColumnSeries
                //        //{
                //        //    Title = item.NgayLap.Value.ToString("MM/yyyy"),

                //        //    Values = new ChartValues<double> { double.Parse(item.TongTien.Value.ToString()) },
                //        //    PointGeometry = DefaultGeometries.Square
                //        //});
                //    }

                //}


                foreach (var item in dhs)
                {
                    if (item != null && item.NgayLap.HasValue)
                    {

                        //SeriesCollection.Add(new ColumnSeries
                        //{
                        //    Title = item.NgayLap.Value.ToString("MM/yyyy"),

                        //    Values = new ChartValues<double> { double.Parse(item.TongTien.Value.ToString()) },
                        //    PointGeometry = DefaultGeometries.Square
                        //});
                    }

                }
                var listMonth = new List<string>();
                var values = new ChartValues<double>();
                for (int i = 0; i < dhs.Count; i++)
                {
                    if (dhs[i] != null && dhs[i].NgayLap.HasValue)
                    {
                        listMonth.Add(dhs[i].NgayLap.Value.ToString("MMMM"));
                        values.Add(double.Parse(dhs[i].TongTien.ToString()));
                    }
                }



            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = string.Empty,
                    Values = values
                }
               
            };

                Labels = listMonth.ToArray();
                
                YFormatter = value => value.ToString("C");

               

             

            }
            catch (Exception ex)
            {

            }

            YFormatter = value => value.ToString("C");
            


            SeriesCollectionMonth.Series = SeriesCollection;
        }
    }
}
