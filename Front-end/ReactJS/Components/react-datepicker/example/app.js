import React from 'react';
import ReactDOM from 'react-dom';
import { DateRange, DatePicker } from '../src/js/index';
import moment from 'moment';

const iconElement = (<span className="oi oi-calendar"></span>);

const _language_en = {
    jan: 'Jan',
    feb: 'Feb',
    mar: 'Mar',
    apr: 'Apr',
    may: 'May',
    jun: 'Jun',
    jul: 'Jul',
    aug: 'Aug',
    sep: 'Sep',
    oct: 'Oct',
    nov: 'Nov',
    dec: 'Dec',
    su: 'Su',
    mo: 'Mo',
    tu: 'Tu',
    we: 'We',
    th: 'Th',
    fr: 'Fr',
    sa: 'Sa',
    today: 'Today',
    yesterday: 'Yesterday',
    currentweek: 'Current week',
    lastweek: 'Last week',
    currentmonth: 'Current month',
    lastmonth: 'Last month',
    sincelastmonth: 'Since last month',
    cancel: 'Cancel',
    ok: 'OK'
};

export default class App extends React.Component {
    constructor(props) {
        super(props);

        this.inputDateRef = React.createRef();
        this.now = new Date();

        this.dateInfo = {
            fromDate:'03/15/2021',
            toDate:'05/11/2021',
            minDate:'03/15/2000',
            maxDate:'12/30/2030',
            limitedMonthRange:3
        };

        this.state = {
            fromDate: this.dateInfo.fromDate,
            toDate: this.dateInfo.toDate,
            singleDateValue: `${this.now.getMonth() + 1}/${this.now.getDate()}/${this.now.getFullYear()}`,
            isEnableSingleDate: true
        }
    }

    langHandler = key => _language_en[key.toLowerCase()] || key; 


    handleChangeDateRange = (date, isValidMonthRange = true) => {
        console.log(date, isValidMonthRange);
        this.setState({fromDate:date.startDate,toDate:date.endDate});
    }

    handleChangeDate = (date) => {
        this.setState({ singleDateValue: date });
        console.log(date)
    }

    handleClickChangeDate = () => {
        this.setState({ singleDateValue: this.inputDateRef.current.value });
    }

    handleToggle = () => {
        this.setState((prevState) => {
            return {
                isEnableSingleDate: !prevState.isEnableSingleDate
            }
        })
    }

    render() {
        const { singleDateValue, isEnableSingleDate } = this.state;

        const RANGE_MONTH_CONSTRAINT=3;

        const now = moment();

        const locale = {
            applyLabel: "OK1",
            cancelLabel: "Cancel1",
            months: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
            weekdays: ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa']
        }

        const myRanges={
            ["Today"]:{       
                startDate: now.clone(),
                endDate: now.clone()
            },
            ["Yesterday"]:{          
                startDate: now.clone().add(-1, 'days'),
                endDate: now.clone().add(-1, 'days')
            },
            ["Current Week"]:{          
                startDate: now.clone().startOf('week'),
                endDate: now.clone()
            },
            ["Current Month"]:{          
                startDate: now.clone().startOf('month'),
                endDate: now.clone()
            }
        };

        const dateInfo = this.dateInfo;
        const {fromDate, toDate} = this.state;

        return (
            <div>
                <div>Date range: </div>
                <DateRange onChange={this.handleChangeDateRange}
                    startDate={fromDate} endDate={toDate}
                    minDate={dateInfo.minDate} maxDate={dateInfo.maxDate}
                    today={dateInfo.toDate} limitedMonthRange={dateInfo.limitedMonthRange}
                    langHandler={this.langHandler}
                    iconElement={iconElement} />

                <div>Date range with customizing range</div>
                <DateRange startDate={fromDate} endDate={toDate}
                    minDate={dateInfo.minDate} maxDate={dateInfo.maxDate}
                    today={dateInfo.toDate} limitedMonthRange={dateInfo.limitedMonthRange}
                    onChange={this.handleChangeDateRange}
                    iconElement={iconElement}
                    locale={locale}
                    ranges={myRanges} />

                <div>Single Date Picker:</div>
                <DatePicker onChange={this.handleChangeDate} iconElement={iconElement} date={singleDateValue} isEnable={isEnableSingleDate} />
                <input type="text" defaultValue="" ref={this.inputDateRef} />
                <button onClick={this.handleClickChangeDate}>Change Date</button>
                <button onClick={this.handleToggle}>Toggle</button>
            </div>
        )
    }
}

ReactDOM.render(<App />, document.getElementById("app"));
