import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { GetTextResources } from './translation'

const MAX_SELECTED_ITEM_FOR_DISPLAY = 3;

export default class MultipleSelectLabel extends Component {
    constructor(props) {
        super(props);
    }

    static propTypes = {
        language: PropTypes.string,
        selectedItems: PropTypes.arrayOf(PropTypes.object).isRequired,
        maxDisplayItemCount: PropTypes.number,
        texts: PropTypes.object,
        disabled: PropTypes.bool
    }

    static defaultProps = {
        language: 'en-US',
        maxDisplayItemCount: MAX_SELECTED_ITEM_FOR_DISPLAY,
        disabled: false
    }

    get selectedItemsString() {
        const { selectedItems, maxDisplayItemCount, disabled } = this.props;
        const selectedValues = selectedItems.map(item => item.value);
        const texts = this.props.texts;

        let displayText = (texts && texts.SelectOptions) || GetTextResources(this.props.language, "SelectOptions");
        const selectedItemCount = selectedValues.length;

        if(this.props.isAllTextShown && selectedItemCount == this.props.dataSourceSize){
            displayText = (texts && texts.All) || GetTextResources(this.props.language, "All");
        }
        else if (selectedItemCount >= maxDisplayItemCount) {
            displayText = ((texts && texts.SelectedItemCount) || GetTextResources(this.props.language, "SelectedItemCount")).replace('#', selectedItemCount);
        }
        else if (selectedItemCount >= 1) {
            displayText = selectedValues.join(", ");
        }

        return displayText;
    }

    render() {
        return (
            <button type="button" className="multiple-select-default multiple-select-label" disabled={this.props.disabled}
                onClick={this.props.onToggle}>
                <span className="text-display" title={this.selectedItemsString}>{this.selectedItemsString}</span>
                <b className="caret"></b>
            </button>
        )
    }
}