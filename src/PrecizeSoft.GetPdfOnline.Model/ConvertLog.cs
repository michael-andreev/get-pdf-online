using System;
using System.Collections.Generic;
using System.Text;

namespace PrecizeSoft.GetPdfOnline.Model
{
    public class ConvertLog
    {
        public Guid ConvertLogId { get; set; }

        public DateTime RequestDateUtc { get; set; }

        public DateTime? ResponseDateUtc { get; set; }

        public TimeSpan Duration { get; set; }

        public string SenderIp { get; set; }

        public string FileExtension { get; set; }

        public int? FileTypeId { get; set; }

        public int? FileCategoryId { get; set; }

        public string FileCategoryCode { get; set; }

        public int FileSize { get; set; }

        public int? ResultTypeId { get; set; }

        public int? ResultFileSize { get; set; }
    }
}
