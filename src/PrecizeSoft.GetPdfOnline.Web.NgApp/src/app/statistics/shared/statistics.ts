import { SummaryStat } from './summary-stat';
import { StatByFileCategory } from './stat-by-file-category';
import { StatByHour } from './stat-by-hour';

export class Statistics {
    summary: SummaryStat;
    statByFileCategories: StatByFileCategory[];
    dailyStat: StatByHour[];
}
