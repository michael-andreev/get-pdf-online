export class StorageFileInfo {
    fileId: string;
    fileName: string;
    fileSize: number;
    createDateUtc: Date;

    getFileNameWithoutExtension(): string {
        return this.fileName;
    }
}