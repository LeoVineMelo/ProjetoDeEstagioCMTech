import React from 'react'
import Navbar from '../components/basicos/Navbar'
import { Avatar, Grid } from '@mui/material';
import User from '../components/basicos/User';
import {useNavigate} from 'react-router-dom'
import Button from '@mui/material/Button';
import ArrowBackIosIcon from '@mui/icons-material/ArrowBackIos';

export default function Operacoes() {

    const navigate = useNavigate()

    const listperfil = (e) =>{
         e.preventDefault()
 
         navigate('/listperfil')
    }
    const home = (e) => {
        e.preventDefault()

        navigate('/home')
    }
    const listusuario = (e) => {
        e.preventDefault()

        navigate('/listusuario')
    }
    const listdepartamento = (e) => {
      e.preventDefault()

      navigate('/listdepartamento')
  }
  const listorganizacao = (e) => {
    e.preventDefault()

    navigate('/listorganizacao')
}

  return (
    <Navbar>
         <Grid display={'flex'}item xs={6} sm={6} md={6} lg={6} xl={6}>
        <Button variant="text" onClick={home}><ArrowBackIosIcon/> Voltar</Button>
        </Grid>
      <Grid justifyContent={'center'} display={'flex'} container spacing={3}>
        <h1>Listagens</h1>
        <Grid item xs={12} sm={12} md={12} lg={12} xl={12}>
        <Button className='Text' variant="contained" onClick={listusuario}>Usuario</Button>
        </Grid>
        <Grid item xs={12} sm={12} md={12} lg={12} xl={12}>
        <Button className='Text' variant="contained" onClick={listperfil} >Perfil</Button>
        </Grid>
        <Grid item xs={12} sm={12} md={12} lg={12} xl={12}>
        <Button className='Text' variant="contained" onClick={listdepartamento}>Departamento</Button>
        </Grid>
        <Grid item xs={12} sm={12} md={12} lg={12} xl={12}>
        <Button className='Text' variant="contained"onClick={listorganizacao}>Organização</Button>
        </Grid>
      </Grid>
    </Navbar>
  )
}