import React, { useState } from "react";
import TextField from './TextField'
import {savePitch} from '../Hooks/postService'

// Declaring outside component to avoid recreation on each render
const emptyPitch = {
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
  const [pitch, setPitch] = useState(emptyPitch);
  const [status, setStatus] = useState(STATUS.IDLE)
  const [saveError, setError] = useState(null)

  function handleChange(e) {
    console.log(e.target.value)
    setPitch((curPitch) => {
      return { ...curPitch, [e.target.id] : e.target.value }
    })
  }

  async function handleSubmit(event) {
    event.preventDefault();
    event.stopPropagation();
    setStatus(STATUS.SUBMITTING)
    try {
      await savePitch(pitch)
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
          value={pitch.name}
          onChange={handleChange} />
        <TextField
          id="description"
          type="text"
          label="Description"
          value={pitch.description}
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
