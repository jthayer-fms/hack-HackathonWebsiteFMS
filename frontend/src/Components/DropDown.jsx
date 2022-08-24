import React from "react";

export default function DropDown() {
  return (
<div class="btn-group">
    <button type="button" id="secondaryToggleTextDropdown" className="btn btn-secondary dropdown-toggle" title="Text" data-toggle="dropdown" aria-label="Text" aria-haspopup="true" aria-expanded="false">
      Text
      <span className="sr-only">Toggle Text Dropdown</span>
    </button>
    <div className="dropdown-menu menu-secondary" aria-labelledby="secondaryToggleTextDropdown">
      <a className="dropdown-item" href="#">Default action</a>
      <a className="dropdown-item" href="#">Another action</a>
      <a className="dropdown-item" href="#">Something else here</a>
      <div className="dropdown-divider"></div>
      <a className="dropdown-item" href="#">Separated link</a>
    </div>
  </div>
  )
}