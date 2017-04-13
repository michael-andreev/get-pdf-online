using PrecizeSoft.GetPdfOnline.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrecizeSoft.GetPdfOnline.Data
{
    public interface ICacheRepository
    {
        void CreateResultFile(ResultFile resultFile);

        ResultFile GetResultFile(Guid resultFileId, bool includeContent = false);

        IEnumerable<ResultFile> GetResultFilesBySessionId(string sessionId);

        void DeleteResultFile(Guid resultFileId);
    }
}
