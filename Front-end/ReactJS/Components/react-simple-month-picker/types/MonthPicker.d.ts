import * as React from 'react';

interface MonthPickerProps {
    onChange?: onChangeDatePicker,
    minDate: string,
    maxDate: string,
    fromDate: string,
    toDate: string,
    className?: string,
    showDate?: boolean,
    label?: string,
    fromDateOption?: DateOption,
    toDateOption?: DateOption
}

type onChangeDatePicker = ({ fromDate: string, toDate: string}) => {}

type DateOption = {
    label?: string, 
}

type MonthOption = {
    label?: string,
    shortMonths?: string[], 
    fullMonths?: string[], 
}

declare const MonthPicker: React.FC<MonthPickerProps>;

export default MonthPicker;