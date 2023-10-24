import React from 'react'
import Navbar from '../components/basicos/Navbar'
import { Avatar, Grid } from '@mui/material';
import User from '../components/basicos/User';

export default function Home() {
  return (
    <Navbar>
      <Avatar sx={{ fontSize: 100 }}/> <strong> Olá <User user={{
        FirstName: 'Leonardo',
        LastName: 'Melo'
      }} /></strong>
    </Navbar>
  )
}