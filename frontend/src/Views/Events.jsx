import React from 'react'
import useFetch from '../Hooks/useFetch'
import Spinner from '../Components/Spinner'
import TextField from '../Components/TextField'
import DropDown from '../Components/DropDown'
import Button from '../Components/Button'
import Select from '../Components/Select'
import Card from '../Components/Card'
import { useParams, Link } from 'react-router-dom'
import {} from 'react-router-dom'


export default function Events() {
  const {typeEvent} = useParams()
  const {data: events, loading, error} = useFetch(typeEvent)
  console.log(events)
  function createEvent(item) {
    return (
      <Link to={`/${typeEvent}/${item.id}`}>
        <Card id={item.id} name={item.name} description={item.description}/>
      </Link>
    )
  }

  if (loading) return <Spinner />

  return(
    <div className='card-columns'>
      {/* <>
        <TextField />
        <DropDown />
        <Button />
        <Select />
      </> */}
      {events.map(createEvent)}
    </div>
  )
}