import React from 'react'
import image from '../Images/default.png';
import Button from './Button'
import './Card.css'


export default function Card(props) {
  const {id, name, description} = props
  return (
    <div key={id} className="card">
        {/* <img src={image} className="card-img-top mw-20" alt="Max-width 20%"></img> */}
        <div className="card-body">
          <h5 class="card-title">{name}</h5>
          <p class="card-text">{description}</p>
        </div>
        <a href="#" class="card-link">Card link</a>
        <a href="#" class="card-link">Another link</a>
        <div class="card-footer">
          <small class="text-muted">Last updated 3 mins ago</small>
        </div>
    </div>
  )
}