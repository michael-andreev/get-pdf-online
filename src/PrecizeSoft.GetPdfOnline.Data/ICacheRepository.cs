using PrecizeSoft.GetPdfOnline.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrecizeSoft.GetPdfOnline.Data
{
    public interface ICacheRepository
    {
        void CreateFile(BinaryFile file);

        BinaryFile GetFile(Guid fileId, bool includeContent = false);

        IEnumerable<BinaryFile> GetFiles(IEnumerable<Guid> fileIds);

        void DeleteFiles(IEnumerable<Guid> fileIds);
            
        void CreateJob(ConvertJob job, bool createSessionIfNotExists);

        void UpdateJob(Guid jobId, byte? rating);

        ConvertJob GetJob(Guid jobId);

        IEnumerable<ConvertJob> GetJobsBySession(Guid sessionId, bool includeFiles = false);

        bool SessionExists(Guid sessionId);

        void DeleteSession(Guid sessionId);
    }
}
