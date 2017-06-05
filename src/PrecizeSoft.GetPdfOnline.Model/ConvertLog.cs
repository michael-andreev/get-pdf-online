using System;
using System.Collections.Generic;
using System.Text;

namespace PrecizeSoft.GetPdfOnline.Model
{
    public class ConvertLog
    {
        public Guid ConvertRequestId { get; set; }

        public DateTimeOffset RequestDateUtc { get; set; }

        public DateTimeOffset? ResponseDateUtc { get; set; }

        public double? DurationInSeconds { get; set; }

        public string SenderIp { get; set; }

        public string FileExtension { get; set; }

        public int FileTypeId { get; set; }

        public int FileCategoryId { get; set; }

        public string FileCategoryCode { get; set; }

        public int FileSize { get; set; }

        public string CustomAttributes { get; set; }

        public int ResultTypeId { get; set; }

        public string ResultTypeCode { get; set; }

        public int? ResultFileSize { get; set; }
    }
}
