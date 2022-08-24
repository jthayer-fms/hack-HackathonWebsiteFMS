import react from 'react'
import Checkout from '../Components/Checkout'
export default function createPitch() {
  return (
    <section>
      <div>
        <div className='mt-4 mb-4 pl-3'>
          <h1 className="text-left">Create a Pitch</h1>
        </div>
        <div className='col-xl-5 col-lg-6 col-md-7'>
          <Checkout />
        </div>
      </div>
    </section>
  )
}