import React from 'react'
import {useParams} from 'react-router-dom'
import useFetch from '../Hooks/useFetch'
import Spinner from '../Components/Spinner'

export default function PitchDetails() {
  const {id} = useParams()

  const {data: event, loading, error} = useFetch(`events/${id}`)
  console.log(event)

  if (loading) return <Spinner />
  if (error) throw error

  return <div>{event.name}</div>
}