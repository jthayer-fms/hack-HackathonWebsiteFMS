import React from 'react'
import { Link, NavLink } from 'react-router-dom'
const activeStyle = {
  color: "purple"
}
export default function NavBar() {
  return (
    <nav class="navbar navbar-light bg-faded justify-content-between flex-nowrap flex-row">
      <div class="container" id="navbarSupportedContent">
        <ul class="nav navbar-nav flex-row float-right">
          <li class="nav-item active">
            <NavLink className="nav-link active pb-2 pl-2" to="/">
              Home
            </NavLink>
          </li>
          <li class="nav-item">
            <NavLink className="nav-link active pb-2 pl-2" activeStyle={activeStyle} to="/events">Pitches</NavLink>
          </li>
          <li class="nav-item">
            <NavLink className="nav-link active pb-2 pl-2" activeStyle={activeStyle} to="/checkout">Create</NavLink>
          </li>
        </ul>
      </div>
    </nav>
  )
}