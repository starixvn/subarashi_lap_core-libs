import React, { Component } from 'react';
import PropTypes from 'prop-types';
import parseInput from './utils/parseInput';
import Calendar from './Calendar';
import PredefinedRanges from './PredefinedRanges';
import getTheme, { defaultClasses } from './utils/styles';
import { MomentFormat } from './utils/constants';
import defaultOptions from './utils/defaultOptions';
import Overlay from './Overlay';
import Popup from './Popup';

class DateRange extends Component {
  constructor(props, context) {
    super(props, context);

    const { format, linkedCalendars, theme, langHandler } = props;

    const startDate = parseInput(props.startDate, format, 'startOf');
    const endDate = parseInput(props.endDate, format, 'endOf');
    this.styles = getTheme(theme);
    this.calendarSelectionStep = 0;

    this.locale = { ...defaultOptions.locale(langHandler), ...props.locale };
    this.ranges =
      props.ranges ||
      defaultOptions.ranges(
        props.today,
        props.minDate,
        props.maxDate,
        props.limitedMonthRange,
        langHandler
      );

    this.isValid = true;
    this.originalRange = { startDate, endDate };

    this.state = {
      range: { startDate, endDate },
      link: linkedCalendars && endDate,
      show: false
    };
  }

  get dateRangeText() {
    const range = this.state.range;
    if (range.startDate && range.endDate) {
      const { format } = this.props;
      return `${range.startDate.format(format)} - ${range.endDate.format(format)}`;
    }

    return "";
  }

  show = () => {
    this.calendarSelectionStep = 0;
    this.setState({ show: true });
  };

  close() {
    this.setState({ show: false });
  }

  componentDidMount() {
    const { onInit } = this.props;
    onInit && onInit(this.state.range);
  }

  orderRange(range) {
    const { startDate, endDate } = range;
    const swap = startDate.isAfter(endDate);

    if (!swap) return range;

    return {
      startDate: endDate,
      endDate: startDate
    };
  }

  setRange(range, show) {
    range = this.orderRange(range);
    this.isValid = this.isValidMonthRange(range);

    if (this.isValid) {
      const newState = show === undefined ? { range } : { range, show };
      this.setState(newState);
    } else {
      const { onChange } = this.props;
      onChange && onChange(range, false);
    }
  }

  handlePredefinedRangesSelect(range) {
    this.setRange(range, false);

    this.originalRange = Object.assign({}, range);
    const { onChange } = this.props;
    onChange && onChange(range, true);
  }

  handleCalendarSelect = (date) => {
    const { startDate, endDate } = this.state.range;

    const range = {
      startDate: startDate,
      endDate: endDate
    };

    switch (this.calendarSelectionStep) {
      case 0:
        range['startDate'] = date;
        range['endDate'] = date;
        this.calendarSelectionStep = 1;
        break;

      case 1:
        range['endDate'] = date;
        this.calendarSelectionStep = 0;
        break;
    }

    this.setRange(range);
  };

  isValidMonthRange(date) {
    const { limitedMonthRange } = this.props;

    if (limitedMonthRange) {
      const startDate = date.startDate;
      const endDate = date.endDate;
      const diffMonth = 12 * (endDate.year() - startDate.year()) + endDate.month() - startDate.month() + 1;

      return diffMonth <= limitedMonthRange;
    }

    return true;
  }

  handleLinkChange(newDate) {
    this.setState({
      link: newDate
    });
  }

  handleApply = () => {
    const { onClickApplyButton, onChange } = this.props;
    const range = this.state.range;
    this.originalRange = Object.assign({}, range);
    onClickApplyButton && onClickApplyButton(range, this.isValid);
    onChange && onChange(range, this.isValid);
    this.close();
  };

  handleCancel = () => {
    this.setRange(this.originalRange, false);
  };

  render() {
    const {
      showRange,
      format,
      linkedCalendars,
      calendars,
      firstDayOfWeek,
      minDate,
      maxDate,
      classNames,
      onlyClasses,
      specialDays,
      lang,
      disableDaysBeforeToday,
      showMonthArrow,
      iconElement,
      isMobile,
    } = this.props;

    const { range, link } = this.state;
    const { styles } = this;

    const classes = { ...defaultClasses, ...classNames };
    const calendarsCount = Number(calendars) - 1;

    const buttonHandlers = {
      apply: this.handleApply,
      cancel: this.handleCancel
    };

    const CalendarList = () => {
      const calendars = [];
      for (var i = calendarsCount; i >= 0; i--) {
        const shownDate = i == calendarsCount ? range.startDate : range.endDate;
        calendars.push(
          <Calendar
            showMonthArrow={showMonthArrow}
            shownDate={shownDate}
            disableDaysBeforeToday={disableDaysBeforeToday}
            lang={lang}
            key={i}
            link={linkedCalendars && link}
            linkCB={this.handleLinkChange.bind(this)}
            range={range}
            format={format}
            firstDayOfWeek={firstDayOfWeek}
            theme={styles}
            minDate={minDate}
            maxDate={maxDate}
            onlyClasses={onlyClasses}
            specialDays={specialDays}
            classNames={classes}
            onChange={this.handleCalendarSelect}
            locale={this.locale}
          />
        );
      }
      return calendars;
    };

    return (
      <div className="daterange-container">
        <div className="daterange-label" onClick={this.show}>
          <input readOnly name="DateRange" id="DateRange" className="input-text datepicker" type="text" autoComplete="off" value={this.dateRangeText} />
          {iconElement}
        </div>

        {isMobile ? (
          <Popup
            isShow={this.state.show}
            containerClassName={"rdr-mobile-popup"}
            key={
              range.startDate.month().toString() +
              range.startDate.year().toString() +
              range.endDate.month().toString() +
              range.endDate.year().toString()
            }
          >
            <div
              className={classes.dateRange}
              ref={(element) => (this.dateRangeContainer = element)}
            >
              {showRange && (
                <PredefinedRanges
                  format={format}
                  ranges={this.ranges}
                  range={range}
                  theme={styles}
                  onSelect={(range) => this.handlePredefinedRangesSelect(range)}
                  onlyClasses={onlyClasses}
                  classNames={classes}
                  locale={this.locale}
                  isShowRangeButton={false}
                  buttonHandlers={buttonHandlers}
                />
              )}
              <div className="mobile-calender">
                <CalendarList />
              </div>
            </div>
            <div className="calender-button">
              <button
                className={classes.applyButton}
                style={
                  onlyClasses
                    ? undefined
                    : { ...styles["RangeApplyButton"], ...style }
                }
                type="button"
                onClick={buttonHandlers.apply}
              >
                {this.locale.applyLabel}
              </button>

              <button
                className={classes.cancelButton}
                style={
                  onlyClasses
                    ? undefined
                    : { ...styles["RangeCancelButton"], ...style }
                }
                onClick={buttonHandlers.cancel}
                type="button"
              >
                {this.locale.cancelLabel}
              </button>
            </div>
          </Popup>
        ) : (
          <Overlay isOpening={this.state.show} onClose={this.handleCancel}>
            <div
              className={classes.dateRange}
              ref={(element) => (this.dateRangeContainer = element)}
            >
              {showRange && (
                <PredefinedRanges
                  format={format}
                  ranges={this.ranges}
                  range={range}
                  theme={styles}
                  onSelect={(range) => this.handlePredefinedRangesSelect(range)}
                  onlyClasses={onlyClasses}
                  classNames={classes}
                  locale={this.locale}
                  buttonHandlers={buttonHandlers}
                />
              )}

              <CalendarList />
            </div>
          </Overlay>
        )}
      </div>
    );
  }
}

DateRange.defaultProps = {
  linkedCalendars: false,
  theme: {},
  format: MomentFormat.default,
  calendars: 2,
  onlyClasses: true,
  classNames: {},
  specialDays: [],
  twoStepChange: false,
  showRange: true,
  iconElement: <i className="icon icon-calendar"></i>,
  isMobile: false
};

DateRange.propTypes = {
  format: PropTypes.string,
  firstDayOfWeek: PropTypes.number,
  calendars: PropTypes.oneOfType([PropTypes.string, PropTypes.number]),
  startDate: PropTypes.oneOfType([PropTypes.object, PropTypes.func, PropTypes.string]),
  endDate: PropTypes.oneOfType([PropTypes.object, PropTypes.func, PropTypes.string]),
  minDate: PropTypes.oneOfType([PropTypes.object, PropTypes.func, PropTypes.string]),
  maxDate: PropTypes.oneOfType([PropTypes.object, PropTypes.func, PropTypes.string]),
  langHandler: PropTypes.func,
  dateLimit: PropTypes.func,
  ranges: PropTypes.object,
  linkedCalendars: PropTypes.bool,
  twoStepChange: PropTypes.bool,
  theme: PropTypes.object,
  onInit: PropTypes.func,
  onChange: PropTypes.func,
  onlyClasses: PropTypes.bool,
  specialDays: PropTypes.array,
  classNames: PropTypes.object,
  onClickApplyButton: PropTypes.func,
  showRange: PropTypes.bool,
  limitedMonthRange: PropTypes.number,
  today: PropTypes.oneOfType([PropTypes.object, PropTypes.func, PropTypes.string]),
  iconElement: PropTypes.any,
  isMobile: PropTypes.bool,
};

export default DateRange;
