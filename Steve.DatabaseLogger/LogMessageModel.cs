using Steve.Core.Converter;
using Steve.Core;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Steve.DatabaseLogger
{
    internal class LogMessageModel
    {

        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Message { get; set; }

        public Dictionary<string, object>? Parameters { get; set; }

        public LogLevel? Level { get; set; } = LogLevel.Informative;

        public DateTime? LoggedAt { get; set; } = DateTime.Now;

        public string? LoggedFrom { get; set; }

        public Exception? Exception { get; set; }

        public string? CallerInfo_Origin { get; set; }

        public string? CallerInfo_FilePath { get; set; }

        public int? CallerInfo_LineNumber { get; set; }

        public double? Duration { get; set; }

        public object? Object { get; set; }

    }
}
