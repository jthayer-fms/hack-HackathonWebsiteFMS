import React from "react";

export default function TextField(props) {
  const {id, type, label, error, touched, onChange} = props

  return (
    <div className="form-group hide-icon mb-3">
      <label htmlFor="defaultTextInputIconText">{label}</label>
      <div className="input-group">
        <span className="prepend-placeholder"></span>
        <input
          type={type}
          className={`form-control ${touched && error && 'is-invalid'}`}
          id={id}
          onChange={onChange}
          autoComplete="off" />
        <div className="input-group-prepend">
          <span className="input-group-text">
            <i className="feedback-icon fa fas fa-user"></i>
          </span>
        </div>
        <div className="form-feedback">
          <small className="invalid-feedback">{error}</small>
        </div>
      </div>
    </div>
  )
}