import React from 'react'
import Navbar from '../components/basicos/Navbar'
import { Avatar, Grid } from '@mui/material';
import User from '../components/basicos/User';
import Button from '@mui/material/Button';
import { useNavigate } from 'react-router-dom'
import ArrowBackIosIcon from '@mui/icons-material/ArrowBackIos';

export default function Cadastros() {


    const navigate = useNavigate()

    const home = (e) => {
        e.preventDefault()

        navigate('/home')
    }
    const cadastrodeusuario= (e) => {
        e.preventDefault()

        navigate('/cadastrodeusuario')
    }
    const cadastrodecliente = (e) => {
        e.preventDefault()

        navigate('/cadastrodecliente')
    }

    return (
        <Navbar>
            <Grid justifyContent={'center'} display={'flex'} container spacing={3}>
                <h1>cadastros</h1>
                <Grid item xs={12} sm={12} md={12} lg={12} xl={12}>
                    <Button variant="contained"onClick={cadastrodecliente}>Cadastro de Cliente</Button>
                </Grid>
                <Grid item xs={12} sm={12} md={12} lg={12} xl={12}>
                    <Button variant="contained"onClick={cadastrodeusuario}>Cadastro de Usuário</Button>
                </Grid>
                <Grid display={'flex'} item xs={12} sm={12} md={12} lg={12} xl={12}>
                    <Button variant="text" onClick={home}><ArrowBackIosIcon /> Voltar</Button>
                </Grid>
            </Grid>

        </Navbar>
    )
}