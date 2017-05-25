export class SummaryStat {
    firstRequestDateUtc: Date; // nullable
    lastRequestDateUtc: Date; // nullable
    durationInSecondsAvg: number;
    durationInSecondsMin: number;
    durationInSecondsMax: number;
    totalCount: number;
    positiveResultCount: number;
    negativeResultCount: number;
    fileSizeSum: number;
    fileSizeAvg: number;
    fileSizeMin: number;
    fileSizeMax: number;
    resultFileSizeSum: number;
    resultFileSizeAvg: number;
    resultFileSizeMin: number;
    resultFileSizeMax: number;
    totalFileSizeSum: number;
}
