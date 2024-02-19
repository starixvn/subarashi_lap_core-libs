import React from 'react';
import PropTypes from 'prop-types';

const Popup = (props) => {
  const {
    isShow,
    containerClassName,
    contentClassName,
    className,
    children,
  } = props;

  const Content = () => (
    <div className={`popup-content ${contentClassName}`}>{children}</div>
  );

  return (
    <div
      className={`popup-container ${ containerClassName ? containerClassName : ""} ${isShow ? "show" : "hide"}`}
      onClick={props.onClick}
    >
      <div className="popup-block-body"></div>
      <div className={`flat-popup ${className ? className : ""}`}>
        <Content />
      </div>
    </div>
  );
};

Popup.propTypes = {
  title: PropTypes.string,
  isShow: PropTypes.bool,
  onClose: PropTypes.func,
  contentClassName: PropTypes.string,
  onClick: PropTypes.func,
};

Popup.defaultProps = {
  isShow: false,
  isHtml: false,
  iframeUrl: null,
  className: "",
  contentClassName: "",
};

export default Popup;
