using CsvHelper;
using CsvHelper.Configuration;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class FileManager : IFileManager
    {
        private readonly IConfiguration _configuration;

        public FileManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Order> ReadCSV()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                Delimiter = ",",
                Encoding = Encoding.UTF8,
            };

            using var streamReader = File.OpenText(_configuration.GetSection("CSVPath").Value);

            using var csvReader = new CsvReader(streamReader, config);

            var orders = csvReader.GetRecords<Order>().ToList();

            return orders;
        }
    }
}
