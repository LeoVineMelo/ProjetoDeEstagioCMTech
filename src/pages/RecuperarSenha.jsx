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


   
    return (
        <Box component="form" sx={{ flexGrow: 1 }}>
            <Card style={{ padding: '5% 15%' }}>
                <Grid container spacing={7}>
                    <Grid className='CorFont' item xs={12} sm={12} md={12} lg={12} xl={12}>
                        <h1><strong>Recuperar Senha</strong></h1>
                    </Grid>

                    <Grid paddingTop={20} item xs={12} sm={12} md={12} lg={12} xl={12}>
                        <TextField className='Text' id="outlined-basic" label="Email de Recuperação" variant="outlined" />
                    </Grid>

                    <Grid justifyContent={'flex-end'} display={'flex'} item xs={6} sm={6} md={6} lg={6} xl={6}>
                        <Button  color="secondary" onClick={login} >Cancelar</Button>

                    </Grid>

                    <Grid  justifyContent={'flex-start'} display={'flex'} item xs={6} sm={6} md={6} lg={6} xl={6}>
                    <Button className='Botaoo' variant="contained" color="success" onClick={login}>
                            Enviar
                        </Button>
                    </Grid>
                </Grid>
            </Card>
        </Box>
    );
}