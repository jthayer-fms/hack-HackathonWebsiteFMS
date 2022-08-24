import React, {useState, useEffect} from "react";
import {Routes, Route} from 'react-router-dom'

import './App.css';
import Pitches from './Views/Pitches'
import NavBar from './Components/NavBar';
import Footer from './Components/Footer';
import PitchDetails from './Views/PitchDetails';
// import Checkout from './Components/Checkout'
import CreatePitch from './Views/CreatePitch'

function App() {
  return (
    <div className="App">
      <NavBar />
      <main className="pl-5 pr-5">
        <Routes>
          <Route path="/" element={<h1>Welcome to the events site</h1>} />
          <Route path="/:typeEvent" element={<Pitches />} />
          <Route path="/:typeEvent/:id" element={<PitchDetails />} />
          <Route path="/create" element={<CreatePitch />} />
        </Routes>
      </main>
      <Footer />
    </div>
  );
}

export default App;
