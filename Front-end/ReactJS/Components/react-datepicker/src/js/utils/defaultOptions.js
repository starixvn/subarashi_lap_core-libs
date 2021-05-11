import moment from 'moment';
import locale from "./locale";
import { MomentFormat } from './constants';
import LangHandler from './resource';

const addRange = (rangeObj, name, start, end, langHandler) => {
    const rangeName = LangHandler(langHandler, name) || name;
    rangeObj[rangeName] = {
        startDate: start,
        endDate: end
    };
};

const addOneDay = (rangeObj, name, day, min, max, langHandler) => {
    if (day >= min && day <= max) {
        addRange(rangeObj, name, day, day, langHandler);
    }
};

const addDistanceDays = (rangeObj, name, start, end, min, max, langHandler) => {
    if (!(max < start || end < min)) {
        addRange(rangeObj, name, start < min ? min : start, end > max ? max : end, langHandler);
    }
};

export default {
    ranges: (today, min, max, limitMonths, langHandler) => {
        today = !today ? moment() : (!moment.isMoment(today) ? moment(today, MomentFormat.default) : today);
        max = !max ? today : (!moment.isMoment(max) ? moment(max, MomentFormat.default) : max);
        min = !min ? today : (!moment.isMoment(min) ? moment(min, MomentFormat.default) : min);

        const range = {};

        if (today < min) {
            return range;
        }

        addOneDay(range, "Today", today, min, max, langHandler);

        const yesterday = today.clone().add(-1, 'days');
        addOneDay(range, "Yesterday", yesterday, min, max, langHandler);

        const startCurrentWeek = today.clone().startOf('week');
        const endCurrentWeek = today;
        addDistanceDays(range, "Currentweek", startCurrentWeek, endCurrentWeek, min, max, langHandler);

        const startLastWeek = today.clone().subtract(1, 'week').startOf('week');
        const endLastWeek = startLastWeek.clone().add(6, 'days');
        addDistanceDays(range, "Lastweek", startLastWeek, endLastWeek, min, max, langHandler);

        const startCurrentmonth = today.clone().startOf('month');
        const endCurrentmonth = today;
        addDistanceDays(range, "Currentmonth", startCurrentmonth, endCurrentmonth, min, max, langHandler);

        const startLastmonth = today.clone().subtract(1, 'month').startOf('month');
        const endLastmonth = startLastmonth.clone().endOf('month');
        addDistanceDays(range, "Lastmonth", startLastmonth, endLastmonth, min, max, langHandler);

        if (limitMonths && limitMonths > 1) {
            const startSincelastmonth = today.clone().subtract(1, 'month').startOf('month');
            const endSincelastmonth = today;
            addDistanceDays(range, "Sincelastmonth", startSincelastmonth, endSincelastmonth, min, max, langHandler);
        }

        return range;
    },

    locale: langHandler => ({
        applyLabel: LangHandler(langHandler, "OK"),
        cancelLabel: LangHandler(langHandler, "Cancel"),
        ...locale(langHandler)
    })
}