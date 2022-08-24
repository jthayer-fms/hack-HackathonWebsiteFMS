import React from "react";

export default function TextField(props) {
  const {id, type, label, onChange} = props
  return (
    <div className="form-group hide-icon col-md-4 mb-3">
      <label for="defaultTextInputIconText">{label}</label>
      <div className="input-group">
        <span className="prepend-placeholder"></span>
        <input
          type={type}
          className="form-control"
          id={id}
          onChange={onChange}
          autocomplete="off" />
        <div className="input-group-prepend">
          <span className="input-group-text">
            <i className="feedback-icon fa fas fa-user"></i>
          </span>
        </div>
        <div class="form-feedback">
          <small class="invalid-feedback">Example invalid message text</small>
        </div>
      </div>
    </div>
  )
}