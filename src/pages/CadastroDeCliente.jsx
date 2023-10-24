import * as React from 'react';
import { styled } from '@mui/material/styles';
import Box from '@mui/material/Box';
import Paper from '@mui/material/Paper';

import TextField from '@mui/material/TextField';
import Card from '../components/layout/Card';
import Stack from '@mui/material/Stack';
import Link from '@mui/material/Link';
import Button from '@mui/material/Button';
import CloseIcon from '@mui/icons-material/Close';
import Navbar from '../components/basicos/Navbar'
import { Avatar, Grid } from '@mui/material';
import User from '../components/basicos/User';


const Item = styled(Paper)(({ theme }) => ({
    backgroundColor: theme.palette.mode === 'dark' ? '#1A2027' : '#fff',
    ...theme.typography.body2,
    padding: theme.spacing(1),
    textAlign: 'center',
    color: theme.palette.text.secondary,
}));

export default function AutoGrid() {
    return (
        <Navbar>
        
            
                <Grid container spacing={2}>

                    <Grid className='Exit' justifyContent={'end'} display={'flex'} item xs={12} sm={12} md={12} lg={12} xl={12}>
                        <button type="button" class="close" aria-label="Close">
                            <CloseIcon></CloseIcon>
                        </button>

                    </Grid>

                    <Grid className='Avt' justifyContent={'center'} display={'flex'} item xs={12} sm={12} md={12} lg={12} xl={12}>
                        <Avatar src="/broken-image.jpg" sx={{ width: 80, height: 80 }} />

                    </Grid>
                    <Grid justifyContent={'center'} display={'flex'} item xs={12} sm={12} md={12} lg={12} xl={12}>

                        <h3>Nome Cliente</h3>
                    </Grid>
                    <Grid item xs={2} sm={2} md={2} lg={2} xl={2}><p>Telefone</p> </Grid>
                    <Grid item xs={10} sm={10} md={10} lg={10} xl={10}>
                        <TextField prop fullWidth id="outlined-basic" label="Senha atual" variant="outlined" />
                    </Grid>
                    <Grid item xs={2} sm={2} md={2} lg={2} xl={2}><p>E-mail</p></Grid>
                    <Grid item xs={10} sm={10} md={10} lg={10} xl={10}>
                        <TextField prop fullWidth id="outlined-basic" label="Nova senha" variant="outlined" />

                    </Grid>
                    <Grid item xs={2} sm={2} md={2} lg={2} xl={2}><p>Empresa</p></Grid>
                    <Grid item xs={10} sm={10} md={10} lg={10} xl={10}>
                        <TextField className='Arredondado' prop fullWidth id="outlined-basic" label="Confirmar nova senha" variant="outlined" />

                    </Grid>

                    <Grid justifyContent={'flex-end'} display={'flex'} item xs={12} sm={12} md={12} lg={12} xl={12}>
                        <Button className='BotaoCancelar' variant="contained" color="success">
                            Cancelar
                        </Button>

                        <Button className='Botao' variant="contained" color="success">
                            Salvar
                        </Button>
                    </Grid>
                </Grid>
            
        
        </Navbar>
    );
}