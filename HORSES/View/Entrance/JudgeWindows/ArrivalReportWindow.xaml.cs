using System.Linq;
using Microsoft.Win32;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Windows;
using HORSES.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace HORSES.View.Entrance.JudgeWindows
{
    public partial class ArrivalReportWindow : Window
    {
        public ArrivalReportWindow()
        {
            InitializeComponent();
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel файлы (*.xlsx)|*.xlsx|Все файлы (*.*)|*.*",
                Title = "Сохранить отчёт как",
                FileName = "ArrivalReport.xlsx"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var oneMonthAgo = DateTime.Now.AddMonths(-1);
                int numberMonth = oneMonthAgo.Month;

                using (ExcelPackage excel = new ExcelPackage())
                {
                    var worksheet = excel.Workbook.Worksheets.Add("Report");

                    worksheet.Cells[1, 1].Value = "Дата";
                    worksheet.Cells[1, 2].Value = "Имя жокея";
                    worksheet.Cells[1, 3].Value = "Результат";
                    worksheet.Cells[1, 4].Value = "Время";
                    worksheet.Cells[1, 1, 1, 4].Style.Font.Bold = true;

                    var checkInResults = App.db.CheckInResults
                        .Include(c => c.Participant) 
                        .Where(c => c.CheckInId != null && c.CheckIn.DateStart.Value.Month >= numberMonth) 
                        .ToList();

                    int row = 2;
                    foreach (var result in checkInResults)
                    {
                        worksheet.Cells[row, 1].Value = DateTime.Now.ToString("dd.MM.yyyy");
                        worksheet.Cells[row, 2].Value = result.Participant.User.Phyo; 
                        worksheet.Cells[row, 3].Value = result.Result ?? 0;
                        worksheet.Cells[row, 4].Value = result.TimeEnd?.ToString("HH:mm:ss");

                        row++;
                    }

                    File.WriteAllBytes(filePath, excel.GetAsByteArray());
                }
                numberMonth = numberMonth + 2;
                MessageBox.Show($"Файл успешно сохранён!\nМестоположение: {filePath}", "Сохранение отчёта", MessageBoxButton.OK, MessageBoxImage.Information);
                await App.db.CheckInResults.Where(c => c.CheckIn.DateStart.Value.Month >= numberMonth).ExecuteDeleteAsync();
                this.Close();
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
