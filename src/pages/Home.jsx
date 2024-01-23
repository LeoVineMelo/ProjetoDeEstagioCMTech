import React from 'react'
import Navbar from '../components/basicos/Navbar'
import { Avatar, Grid } from '@mui/material';
import User from '../components/basicos/User';
import { AuthContext } from '../context/auth';

export default function Home() {
  const { usuario } = React.useContext(AuthContext)

  return (
    <Navbar>
      <Avatar sx={{ fontSize: 100 }}/> <strong> Olá <User user={{
        FirstName: usuario.nome
      }} /></strong>
    </Navbar>
  )
}