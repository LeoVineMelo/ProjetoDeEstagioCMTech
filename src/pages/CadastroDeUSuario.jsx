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

import { IconButton } from '@mui/material';
import Autocomplete from '@mui/material/Autocomplete';
import {useNavigate} from 'react-router-dom'
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

const Setores = [
    { label: 'Comercial', year: 2023 },
    { label: 'The Godfather', year: 1972 },
    { label: 'The Godfather: Part II', year: 1974 },
    { label: 'The Dark Knight', year: 2008 },
    { label: '12 Angry Men', year: 1957 },
    { label: "Schindler's List", year: 1993 },
    { label: 'Pulp Fiction', year: 1994 },
];

const Cargos = [
    { label: 'Atendente', year: 2023 },
    { label: 'The Godfather', year: 1972 },
    { label: 'The Godfather: Part II', year: 1974 },
    { label: 'The Dark Knight', year: 2008 },
    { label: '12 Angry Men', year: 1957 },
    { label: "Schindler's List", year: 1993 },
    { label: 'Pulp Fiction', year: 1994 },
];

export default function AutoGrid() {
    return (
        <Navbar>
       
                <Grid container spacing={2}>
                    <Grid className='Exit' justifyContent={'end'} display={'flex'} item xs={12} sm={12} md={12} lg={12} xl={12}>
                        <button type="button" class="close" aria-label="Close">
                            <CloseIcon></CloseIcon>
                        </button>

                    </Grid>
                    <Grid item xs={2} sm={2} md={2} lg={2} xl={2}><p>Telefone</p> </Grid>
                    <Grid item xs={10} sm={10} md={10} lg={10} xl={10}>
                        <TextField prop fullWidth id="outlined-basic" label="Telefone" variant="outlined" />
                    </Grid>
                    <Grid item xs={2} sm={2} md={2} lg={2} xl={2}><p>E-mail</p></Grid>
                    <Grid item xs={10} sm={10} md={10} lg={10} xl={10}>
                        <TextField prop fullWidth id="outlined-basic" label="E-mail" variant="outlined" />

                    </Grid>
                    <Grid item xs={2} sm={2} md={2} lg={2} xl={2}><p>Empresa</p></Grid>
                    <Grid item xs={10} sm={10} md={10} lg={10} xl={10}>
                        <TextField className='Arredondado' prop fullWidth id="outlined-basic" label="Confirmar nova senha" variant="outlined" />

                    </Grid>

                    <Grid item xs={2} sm={2} md={2} lg={2} xl={2}><p>Cargo</p></Grid>
                    <Grid item xs={5} sm={5} md={5} lg={5} xl={5}>
                    <Autocomplete
                            className='Arredondado'
                            disablePortal
                            id="combo-box-demo"
                            options={Cargos}
                            sx={{ width: 300 }}
                            renderInput={(params) => <TextField {...params} label="Cargos" />}
                        />

                    </Grid>

                    <Grid item xs={1} sm={1} md={1} lg={1} xl={1}><p>Setor</p></Grid>
                    <Grid item xs={4} sm={4} md={4} lg={4} xl={4}>
                        <Autocomplete
                            disablePortal
                            id="combo-box-demo"
                            options={Setores}
                            sx={{ width: 300 }}
                            renderInput={(params) => <TextField {...params} label="Setores" />}
                        />

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