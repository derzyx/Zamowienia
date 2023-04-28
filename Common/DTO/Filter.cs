using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class Filter
    {
        public string Number { get; set; } = string.Empty;
        public DateTime DateFrom { get; set; } = DateTime.MinValue;
        public DateTime DateTo { get; set; } = DateTime.MinValue;
        public List<string> ClientNames { get; set; } = new List<string>();
    }
}
