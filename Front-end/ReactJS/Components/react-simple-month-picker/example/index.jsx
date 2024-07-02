import React, { useState } from 'react';
import moment from 'moment';
import { createRoot } from 'react-dom/client';

import MonthPicker from "../src/js";

const now = moment().utc().add(-4, 'h');

export const DateConstraint = {
    minDate: '06/1/2012',
    maxDate: now.clone().format('MM/DD/yyyy'),
    showDate: true,
    monthOption: {
        label: 'View Data in Month',
    },
    fromDateOption: {
        label: 'From',
        id: 'FromDateInput',
    },
    toDateOption: {
        label: 'To',
        id: 'ToDateInput',
    },
};

export const DateRange = {
    fromDate: now.clone().startOf('month').format('MM/DD/yyyy'),
    toDate: now.clone().format('MM/DD/yyyy'),
};

export const App = () => {
  const [dateRange, setDaterange] = useState(DateRange);

  return (
    <>
      <h1>Example Simple Month-Picker:</h1>
      <div className="container">
        <MonthPicker
            className="month-picker-wrap"
            minDate={DateConstraint.minDate}
            maxDate={DateConstraint.maxDate}
            fromDateOption={DateConstraint.fromDateOption}
            toDateOption={DateConstraint.toDateOption}
            monthOption={DateConstraint.monthOption}
            fromDate={dateRange.fromDate}
            toDate={dateRange.toDate}
            onChange={setDaterange}
          />
      </div>
    </>
  );
};

const root = createRoot(document.getElementById('root'));
root.render(
    <React.Fragment>
        <App />
    </React.Fragment>
);
