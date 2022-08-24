import React, { useState } from "react";
import TextField from './TextField'
import {saveEvent} from '../Hooks/postService'

// Declaring outside component to avoid recreation on each render
const emptyEvent = {
  name: "",
  description: "",
};

const STATUS = {
  IDLE: "IDLE",
  SUBMITTED: "SUBMITTED",
  SUBMITTING: "SUBMITTING",
  COMPLETED: "COMPLETED"
}

export default function Checkout() {
  const [eventToCreate, setEvent] = useState(emptyEvent);
  const [status, setStatus] = useState(STATUS.IDLE)
  const [saveError, setError] = useState(null)

  function handleChange(e) {
    console.log(e.target.value)
    setEvent((curAddres) => {
      return { ...curAddres, [e.target.id] : e.target.value }
    })
  }

  async function handleSubmit(event) {
    console.log(eventToCreate, "event")
    event.preventDefault();
    event.stopPropagation();
    setStatus(STATUS.SUBMITTING)
    try {
      await saveEvent(eventToCreate)
      setStatus(STATUS.COMPLETED)
    } catch (error) {
      setError(error);
    }
  }

  if(saveError) throw saveError;
  if (status === STATUS.COMPLETED) {
    return <h1>Thanks to create a new event</h1>
  }

  return (
    <>
      <h1>Create Event</h1>
      <form onSubmit={handleSubmit}>
        <TextField 
          id="name"
          type="text"
          label="Name"
          value={eventToCreate.name}
          onChange={handleChange} />
        <TextField
          id="description"
          type="text"
          label="Description"
          value={eventToCreate.description}
          onChange={handleChange} />
        <div>
          <input
            type="submit"
            className="btn btn-primary"
            value="Save Shipping Info"
            disabled={status === STATUS.SUBMITTING}
          />
        </div>
      </form>
    </>
  );
}
