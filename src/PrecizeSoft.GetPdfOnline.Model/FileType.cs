using System;
using System.Collections.Generic;
using System.Text;

namespace PrecizeSoft.GetPdfOnline.Model
{
    public class FileType
    {
        public int FileTypeId { get; set; }

        public int FileCategoryId { get; set; }

        public FileCategory FileCategory { get; set; }

        public string FileExtension { get; set; }

        public ICollection<ConvertRequest> ConvertRequests { get; set; }
    }
}
