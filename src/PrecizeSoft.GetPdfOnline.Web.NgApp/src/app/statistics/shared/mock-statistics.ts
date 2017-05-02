import { Statistics } from './statistics';
import { SummaryStat } from './summary-stat';
import { StatByFileCategory } from './stat-by-file-category';
import { StatByHour } from './stat-by-hour';

export const STATISTICS: Statistics = {
  summary: {
    firstRequestDateUtc: new Date(2017, 5, 1, 12, 30, 30, 0),
    lastRequestDateUtc: new Date(2017, 5, 1, 12, 30, 30, 0),
    durationInSecondsAvg: 1.237,
    durationInSecondsMin: 0,
    durationInSecondsMax: 0,
    totalCount: 0,
    positiveResultCount: 0,
    negativeResultCount: 0,
    fileSizeSum: 0,
    fileSizeAvg: 5000,
    fileSizeMin: 0,
    fileSizeMax: 0,
    resultFileSizeSum: 0,
    resultFileSizeAvg: 0,
    resultFileSizeMin: 0,
    resultFileSizeMax: 0,
    totalFileSizeSum: 0
  },
  dailyStat: [
    {
      hour: 5,
      fileSizeSum: 0,
      resultFileSizeSum: 0,
      totalFileSizeSum: 0,
      totalCount: 10
    }
  ],
  statByFileCategories: [
    {
      fileCategoryCode: 'Document',
      totalCount: 10,
      fileSizeAvg: 0,
      fileSizeMax: 0,
      fileSizeMin: 0,
      fileSizeSum: 0
    }
  ]
}
