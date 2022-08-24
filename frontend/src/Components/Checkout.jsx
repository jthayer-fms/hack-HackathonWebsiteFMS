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
  const [touched, setTouched] = useState({})
  console.log(touched, "touched")

  const errors = getErrors(pitch)
  const isValid = Object.keys(errors).length === 0

  function handleChange(event) {
    setPitch((curPitch) => {
      return { ...curPitch, [event.target.id] : event.target.value }
    })
    
    setTouched((cur) => {
      return { ...cur, [event.target.id]: true}
    })
  }

  async function handleSubmit(event) {
    event.preventDefault();
    event.stopPropagation();
    setStatus(STATUS.SUBMITTING)
    if (isValid) {
      try {
        await savePitch(pitch)
        setStatus(STATUS.COMPLETED)
      } catch (error) {
        setError(error);
      }
    } else {
      setStatus(STATUS.SUBMITTED)
    }
  }

  function getErrors(pitch) {
    const result = {}
    if (pitch.description.length < 3) {
      result.description = "A description must contain at least three characters"
    }
    return result
  }

  if(saveError) throw saveError;
  if (status === STATUS.COMPLETED) {
    return <h1>Thanks to create a new event</h1>
  }

  return (
    <>
      <form onSubmit={handleSubmit}>
        <TextField
          id="description"
          type="text"
          label="Description"
          value={pitch.description}
          error={errors.description}
          touched={touched.description}
          onChange={handleChange} />
        <div className="d-flex justify-content-end">
          <input
            type="submit"
            className="btn btn-primary"
            value="Submit"
            disabled={status === STATUS.SUBMITTING}
          />
          {/* <i class="fa fas fa-user pr-2"></i> */}
        </div>
      </form>
    </>
  );
}
