import React from 'react'
import { Link, NavLink } from 'react-router-dom'

export default function NavBar() {
  return (
    <nav className="navbar navbar-light bg-faded justify-content-between flex-nowrap flex-row">
      <div className="container" id="navbarSupportedContent">
        <ul className="nav navbar-nav flex-row float-right">
          <li className="nav-item active">
            <NavLink className="nav-link active pb-2 pl-2" to="/">
              Home
            </NavLink>
          </li>
          <li className="nav-item">
            <NavLink className="nav-link active pb-2 pl-2" to="/events">Pitches</NavLink>
          </li>
          <li className="nav-item">
            <NavLink className="nav-link active pb-2 pl-2" to="/checkout">Create</NavLink>
          </li>
        </ul>
      </div>
    </nav>
  )
}