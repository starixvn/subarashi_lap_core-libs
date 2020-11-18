import React from 'react';

const Cell = (props) => {
    return (<td style={{ height: props.height ? props.height : 'auto' }} {...props}>{props.children}</td>)
}


export default Cell;