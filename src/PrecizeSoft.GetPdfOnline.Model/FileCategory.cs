using System;
using System.Collections.Generic;
using System.Text;

namespace PrecizeSoft.GetPdfOnline.Model
{
    public class FileCategory
    {
        public int FileCategoryId { get; set; }

        public string FileCategoryCode { get; set; }

        public ICollection<FileType> FileTypes { get; set; }
    }
}
