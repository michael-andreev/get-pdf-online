using PrecizeSoft.GetPdfOnline.Data;
using PrecizeSoft.GetPdfOnline.Model;
using PrecizeSoft.IO.Contracts.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PrecizeSoft.GetPdfOnline.Domain.Converters;

namespace PrecizeSoft.GetPdfOnline.Domain.Services
{
    public class FileStorageService : IFileService
    {
        protected ICacheRepository cacheRepository;

        public FileStorageService(ICacheRepository cacheRepository)
        {
            this.cacheRepository = cacheRepository;
        }

        public void AddFile(IFile file)
        {
            BinaryFile resultFile = new BinaryFile
            {
                FileId = file.FileId,
                FileName = file.FileName,
                FileSize = file.FileSize,
                CreateDateUtc = file.CreateDateUtc,
                Content = new BinaryFileContent
                {
                    FileBytes = file.Bytes
                }
            };

            this.cacheRepository.CreateFile(resultFile);
        }

        public void DeleteFiles(IEnumerable<Guid> fileIds)
        {
            this.cacheRepository.DeleteFiles(fileIds);
        }

        public IFile GetFile(Guid fileId)
        {
            return this.cacheRepository.GetFile(fileId, true)?.ToConvertedFile();
        }

        public IFileInfo GetFileInfo(Guid fileId)
        {
            return this.cacheRepository.GetFile(fileId, false)?.ToConvertedFileInfo();
        }

        public IEnumerable<IFileInfo> GetFilesInfo(IEnumerable<Guid> fileIds)
        {
            return this.cacheRepository.GetFiles(fileIds)
                .Select(p => p.ToConvertedFileInfo()).ToList();
        }
    }
}
