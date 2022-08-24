export default function name() {
  return (
    <div className="form-group col-md-6 mb-3">
      <label for="defaultSelectIconText" className="py-0">Default State</label>
      <div className="input-group left-icon">
        <select className="form-control custom-select" id="defaultSelectIconText">
          <optgroup label="Published">
            <option>Icon Text</option>
            <option>Supervisor best practice summary dashboard</option>
          </optgroup>
          <optgroup label="Unpublished">
            <option>Space Summary</option>
          </optgroup>
        </select>
        <div className="input-group-prepend">
          <span className="input-group-text">
            <i className="feedback-icon fa fas fa-user"></i>
          </span>
        </div>
      </div>
    </div>
  )
}