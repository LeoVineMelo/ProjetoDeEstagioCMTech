import * as React from 'react';
import { styled } from '@mui/material/styles';
import Box from '@mui/material/Box';
import Paper from '@mui/material/Paper';
import Grid from '@mui/material/Grid';
import TextField from '@mui/material/TextField';
import Card from '../components/layout/Card';
import Stack from '@mui/material/Stack';
import Link from '@mui/material/Link';
import Button from '@mui/material/Button';
import {useNavigate} from 'react-router-dom'

const Item = styled(Paper)(({ theme }) => ({
    backgroundColor: theme.palette.mode === 'dark' ? '#1A2027' : '#fff',
    ...theme.typography.body2,
    padding: theme.spacing(1),
    textAlign: 'center',
    color: theme.palette.text.secondary,
}));

export default function AutoGrid() {

    const navigate = useNavigate()

    const login = (e) =>{
         e.preventDefault()
 
         navigate('/login')
    }
    const home = (e) =>{
        e.preventDefault()

        navigate('/home')
   }

    return (
        <Box component="form" sx={{ flexGrow: 1 }}>
            <Card style={{ padding: '5% 20%' }}>
                <Grid container spacing={2}>
                    <Grid className='CorFont' item xs={12} sm={12} md={12} lg={12} xl={12}>
                        <h1><strong>Trocar Senha</strong></h1>
                    </Grid>

                    <Grid item xs={12} sm={12} md={12} lg={12} xl={12}>
                        <TextField className='Text'
                            id="outlined-password-input"
                            label="Password"
                            type="password"
                            autoComplete="current-password"
                        />
                    </Grid>

                    <Grid item xs={12} sm={12} md={12} lg={12} xl={12}>
                        <TextField className='Text'
                            id="outlined-password-input"
                            label="Password"
                            type="password"
                            autoComplete="current-password"
                        />

                    </Grid>
                    <Grid item xs={12} sm={12} md={12} lg={12} xl={12}>
                        <TextField className='Text'
                            id="outlined-password-input"
                            label="Password"
                            type="password"
                            autoComplete="current-password"
                        />

                    </Grid>

                    <Grid justifyContent={'flex-end'} display={'flex'} item xs={6} sm={6} md={6} lg={6} xl={6}>
                        <Button color="secondary"onClick={home}>Cancelar</Button>

                    </Grid>

                    <Grid justifyContent={'flex-start'} display={'flex'} item xs={6} sm={6} md={6} lg={6} xl={6}>
                        <Button className='Botaoo' variant="contained" color="success"onClick={login}>
                            Enviar
                        </Button>
                    </Grid>
                </Grid>
            </Card>
        </Box>
    );
}