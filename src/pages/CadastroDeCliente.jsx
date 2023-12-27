import * as React from 'react';
import { useState } from 'react';
import { styled } from '@mui/material/styles';
import Box from '@mui/material/Box';
import Paper from '@mui/material/Paper';
import { useNavigate } from 'react-router-dom';
import { alpha } from '@mui/material/styles';
import TextField from '@mui/material/TextField';
import Card from '../components/layout/Card';
import Stack from '@mui/material/Stack';
import Link from '@mui/material/Link';
import Button from '@mui/material/Button';
import CloseIcon from '@mui/icons-material/Close';
import Navbar from '../components/basicos/Navbar'
import { Avatar, Grid } from '@mui/material';
import User from '../components/basicos/User';
import api from '../services/api';
import { purple } from '@mui/material/colors';
import { grey } from '@mui/material/colors';



const RedditTextField = styled((props) => (
    <TextField InputProps={{ disableUnderline: true }} {...props} />
))(({ theme }) => ({
    '& .MuiFilledInput-root': {
        overflow: 'hidden',
        borderRadius: 30,
        backgroundColor: theme.palette.mode === 'light' ? '#F3F6F9' : '#1A2027',
        border: '1px solid',
        borderColor: theme.palette.mode === 'light' ? '#E0E3E7' : '#2D3843',
        transition: theme.transitions.create([
            'border-color',
            'background-color',
            'box-shadow',
        ]),
        '&:hover': {
            backgroundColor: 'transparent',
        },
        '&.Mui-focused': {
            backgroundColor: 'transparent',
            boxShadow: `${alpha(theme.palette.primary.main, 0.25)} 0 0 0 2px`,
            borderColor: theme.palette.primary.main,
        },
    },
}));


const ColorButton1 = styled(Button)(({ theme }) => ({
    margin: 10,
    borderRadius: 30,
    marginTop: '20px',
    padding: '5px 30px',
    color: theme.palette.getContrastText(grey[300]),
    backgroundColor: grey[400],
    '&:hover': {
        backgroundColor: grey[600],
    },
}));


const ColorButton = styled(Button)(({ theme }) => ({
    margin: 10,
    borderRadius: 30,
    marginTop: '20px',
    padding: '5px 30px',
    color: theme.palette.getContrastText(purple[700]),
    backgroundColor: purple[800],
    '&:hover': {
        backgroundColor: purple[900],
    },
}));

const Item = styled(Paper)(({ theme }) => ({
    backgroundColor: theme.palette.mode === 'dark' ? '#1A2027' : '#fff',
    ...theme.typography.body2,
    padding: theme.spacing(1),
    textAlign: 'center',
    color: theme.palette.text.secondary,
}));

export default function AutoGrid() {
    const navigate = useNavigate()

        const home = (e) =>{
             e.preventDefault()
     
             navigate('home')
        };
        return (
        
        <Navbar>


            <Grid container spacing={2}>

                <Grid className='Exit' justifyContent={'end'} display={'flex'} item xs={12} sm={12} md={12} lg={12} xl={12}>
                   

                </Grid>

                <Grid className='Avt' justifyContent={'center'} display={'flex'} item xs={12} sm={12} md={12} lg={12} xl={12}>
                    <Avatar src="/broken-image.jpg" sx={{ width: 80, height: 80 }} />

                </Grid>
                <Grid justifyContent={'center'} display={'flex'} item xs={12} sm={12} md={12} lg={12} xl={12}>

                    <h3>Nome Cliente</h3>
                </Grid>
                <Grid item xs={2} sm={2} md={2} lg={2} xl={2}><p>Telefone</p> </Grid>
                <Grid item xs={10} sm={10} md={10} lg={10} xl={10}>
                    
                    <RedditTextField
                        proq fullWidth
                        label="Telefone"
                        defaultValue=""
                        id="reddit-input"
                        variant="filled"
                        style={{ marginTop: 11 }}
                    />
                </Grid>
                <Grid item xs={2} sm={2} md={2} lg={2} xl={2}><p>E-mail</p></Grid>
                <Grid item xs={10} sm={10} md={10} lg={10} xl={10}>
                <RedditTextField
                        proq fullWidth
                        label="E-mail"
                        defaultValue=""
                        id="reddit-input"
                        variant="filled"
                        style={{ marginTop: 11 }}
                    />

                </Grid>
                <Grid item xs={2} sm={2} md={2} lg={2} xl={2}><p>Empresa</p></Grid>
                <Grid item xs={10} sm={10} md={10} lg={10} xl={10}>
                <RedditTextField
                        proq fullWidth
                        label="Empresa"
                        defaultValue=""
                        id="reddit-input"
                        variant="filled"
                        style={{ marginTop: 11 }}
                    />
                </Grid>

                <Grid justifyContent={'flex-end'} display={'flex'} item xs={12} sm={12} md={12} lg={12} xl={12}>
                    <ColorButton1 className='BotaoCancelar' onClick={'home'} variant="contained">
                        Cancelar
                    </ColorButton1>

                    <ColorButton className='Botao' variant="contained" >
                        Salvar
                    </ColorButton>
                </Grid>
            </Grid>


        </Navbar>
    );
}