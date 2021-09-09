using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CI.interview.pltosman.Business.Abstract;
using CI.interview.pltosman.Core.Utilities.Security;
using CI.interview.pltosman.Entities.Dtos;
using Ganss.Excel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OfficeOpenXml;
using CI.interview.pltosman.Business.Extension;
using CsvHelper;
using System.Data;

namespace CI.interview.pltosman.Business.Concrete
{
    public class ExcelService:IExcelService
    {
        private readonly ILogger<ExcelService> _logger;
        private readonly ApplicationSettings _settings;
        private static string _fileName;

        public ExcelService(ILogger<ExcelService> logger, IConfiguration configuration, IOptions<ApplicationSettings> settings)
        {
            _logger = logger;
            _settings = settings.Value;
        }




        public Task<List<DataExcelModelDto>> GetData()
        {
            List<DataExcelModelDto> dataToReturn = new List<DataExcelModelDto>();
            try
            {
                dataToReturn = ReadExcelData();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Excel document cannot be read");
            }
            return Task.FromResult(dataToReturn);
        }


        public List<DataExcelModelDto> GetCSVExcelData()
        {

            List<DataExcelModelDto> data = new List<DataExcelModelDto>();

            ProcessDirectory(_settings.ExcelSetting.FilePath);


            var csvTable = new DataTable();
            using (var csvReader = new LumenWorks.Framework.IO.Csv.CsvReader(new StreamReader(_fileName), true))
            {
                csvTable.Load(csvReader);
            }
            for (int i = 0; i < csvTable.Rows.Count; i++)
            {

                DataExcelModelDto model = new DataExcelModelDto();
                try
                {
                    model.Date =Convert.ToDateTime( csvTable.Rows[i][0].ToString());

                    model.Country = csvTable.Rows[i][1].ToString();
                    model.Currency = csvTable.Rows[i][2].ToString();
                    model.Amount = Convert.ToInt32(csvTable.Rows[i][3].ToString());

                   data.Add(model);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Some error occured while importing.");
                }
            }
            return data;
        }

        public List<string> ReadInCSV()
        {

            ProcessDirectory(_settings.ExcelSetting.FilePath);


            List<string> result = new List<string>();
            string value;
            using (TextReader fileReader = File.OpenText(_fileName))
            {
                
                var csv = new CsvReader(fileReader,new CultureInfo("en-En"));
               
                while (csv.Read())
                {
                    for (int i = 0; csv.TryGetField<string>(i, out value); i++)
                    {
                        result.Add(value);
                    }
                }
            }
            return result;
        }


        private List<DataExcelModelDto> ReadCsvData()
        {


            List<DataExcelModelDto> data = new List<DataExcelModelDto>();

            ProcessDirectory(_settings.ExcelSetting.FilePath);

            FileInfo file = new FileInfo(_fileName);
            try
            {






            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error occured while importing.");
            }
            return data;
        }

        private List<DataExcelModelDto> ReadExcelData()
        {

            List<DataExcelModelDto> data = new List<DataExcelModelDto>();

            ProcessDirectory(_settings.ExcelSetting.FilePath);

            FileInfo file = new FileInfo(_fileName);
            try
            {
                using (ExcelPackage package = new ExcelPackage(file))
                {
                    foreach (ExcelWorksheet worksheet in package.Workbook.Worksheets)
                    {
                        int rowCount = worksheet.Dimension.Rows;
                        int ColCount = worksheet.Dimension.Columns;
                        string sheetName = worksheet.Name.ToString();

                        for (int row = 2; row <= rowCount; row++)
                        {
                            DataExcelModelDto model = new DataExcelModelDto();
                            try
                            {
                                model.SheetName = sheetName;

                                int index = model.GetAttributeFrom<ColumnAttribute>("Date").Index;
                                var date = worksheet.Cells[row, index].Value;

                                double d = double.Parse(date.ToString());
                                model.Date = DateTime.FromOADate(d);
                                model.Date = model.Date.AddHours(9);


                                index = model.GetAttributeFrom<ColumnAttribute>("Country").Index;
                                model.Country = worksheet.Cells[row, index].Value.ToString();

                                index = model.GetAttributeFrom<ColumnAttribute>("Currency").Index;
                                model.Currency = worksheet.Cells[row, index].Value.ToString();

                                index = model.GetAttributeFrom<ColumnAttribute>("Amount").Index;
                                model.Amount = Convert.ToInt32(worksheet.Cells[row, index].Value.ToString());

                                data.Add(model);
                            }
                            catch (Exception ex)
                            {
                                _logger.LogError(ex, "Some error occured while importing.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error occured while importing.");
            }
            return data;
        }

        // Process all files in the directory passed in, recurse on any directories 
        // that are found, and process the files they contain.
        private static void ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.
            var fileEntries = Directory.GetFiles(targetDirectory);
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-En");

            foreach (var fileName in fileEntries)
            {
                if (fileName.Contains("data"))// && fileName.Contains("2")
                    _fileName = fileName;
            }

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
        }

    }
}
