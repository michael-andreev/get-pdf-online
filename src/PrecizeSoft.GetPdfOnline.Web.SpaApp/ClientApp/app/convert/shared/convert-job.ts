import { StorageFileInfo } from './storage-file-info';

export class ConvertJob {
    jobId: string;
    sessionId: string;
    expireDateUtc: Date;
    inputFile: StorageFileInfo;
    outputFile: StorageFileInfo;
    errorType: number;
    rating: number;
}