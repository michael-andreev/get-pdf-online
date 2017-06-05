using System;

namespace PrecizeSoft.GetPdfOnline.Model
{
    public class ConvertRequest
    {
        public Guid ConvertRequestId { get; set; }

        public DateTimeOffset RequestDateUtc { get; set; }

        public string SenderIp { get; set; }

        public string FileExtension { get; set; }

        public int FileTypeId { get; set; }

        public int FileSize { get; set; }

        public FileType FileType { get; set; }

        public ConvertResponse Response { get; set; }

        public string CustomAttributes { get; set; }
    }
}
