﻿using PrecizeSoft.IO.Contracts.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecizeSoft.GetPdfOnline.Domain.Models
{
    public class ConvertedFile: IFile
    {
        public Guid FileId { get; set; }

        public string FileName { get; set; }

        public int FileSize { get; set; }

        public DateTime CreateDateUtc { get; set; }

        public byte[] Bytes { get; set; }
    }
}
