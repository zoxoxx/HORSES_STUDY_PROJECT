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
        private readonly HorseCompetitionsContext _context; 

        public ArrivalReportWindow()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
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

                using (ExcelPackage excel = new ExcelPackage())
                {
                    var worksheet = excel.Workbook.Worksheets.Add("Report");

                    worksheet.Cells[1, 1].Value = "Дата";
                    worksheet.Cells[1, 2].Value = "Имя жокея";
                    worksheet.Cells[1, 3].Value = "Результат";
                    worksheet.Cells[1, 4].Value = "Время";
                    worksheet.Cells[1, 1, 1, 4].Style.Font.Bold = true;

                    var checkInResults = _context.CheckInResults
                        .Include(c => c.Participant) 
                        .Where(c => c.CheckInId != null) 
                        .ToList();

                    int row = 2;
                    foreach (var result in checkInResults)
                    {
                        worksheet.Cells[row, 1].Value = DateTime.Now.ToString("dd.MM.yyyy");
                        worksheet.Cells[row, 2].Value = result.Participant; 
                        worksheet.Cells[row, 3].Value = result.Result ?? 0;
                        worksheet.Cells[row, 4].Value = result.TimeEnd?.ToString("HH:mm:ss");

                        row++;
                    }

                    File.WriteAllBytes(filePath, excel.GetAsByteArray());
                }

                MessageBox.Show($"Файл успешно сохранён!\nМестоположение: {filePath}", "Сохранение отчёта", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
