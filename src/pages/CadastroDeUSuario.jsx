import * as React from 'react';
import { styled } from '@mui/material/styles';
import Box from '@mui/material/Box';
import Paper from '@mui/material/Paper';
import api from '../services/api';
import TextField from '@mui/material/TextField';
import Card from '../components/layout/Card';
import Stack from '@mui/material/Stack';
import Link from '@mui/material/Link';
import Button from '@mui/material/Button';
import CloseIcon from '@mui/icons-material/Close';

import '../components/basicos/Navbar.css'

import { IconButton } from '@mui/material';
import Autocomplete from '@mui/material/Autocomplete';
import { useNavigate } from 'react-router-dom'
import Navbar from '../components/basicos/Navbar'
import { Avatar, Grid } from '@mui/material';
import User from '../components/basicos/User';

import { purple } from '@mui/material/colors';
import { grey } from '@mui/material/colors';


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

const Setores = [
    { label: 'Comercial', id:1 },
    { label: 'Recursos Humanos', id:2 },
    { label: 'Atendimento', id:3 },
    { label: 'Analise', id:4 },
    { label: 'Suporte',id:5 },
    { label: 'Infra Estrutura',id:6 },


];

const Cargos = [
    { label: 'Atendente', id:4 },
    { label: 'Analista', id:3 },
    { label: 'Administrador',id:1 },
    { label: 'Cliente' , id:3},
    { label: 'Técnico', id:2 },

];

const Empresa = [
    { label: 'CMTECH', id: 1},



];




export default function NovoUsuario() {

    const [nome, setNome] = React.useState('');
    const [email, setEmail] = React.useState('');
    const [grupo, setGrupo] = React.useState('');
    const [perfil, setPerfil] = React.useState('');
    const [departamento, setDepartamento] = React.useState('');
    const [dataCadastro, setDataCadastro] = React.useState('');



    const navigate = useNavigate();

    async function CadUsuario(e) {
        e.preventDefault();

        const dataAtual = new Date();

        const options = {
            year: 'numeric',
            month: '2-digit',
            day: '2-digit',
            hour: '2-digit',
            minute: '2-digit',
            second: '2-digit',
            fractionalSecondDigits: 3,
        };

        const dataHoraFormatada = dataAtual.toLocaleString('pt-BR', options);

        const data = {
            nome,
            email,
            grupo,
            perfil,
            departamento,
            dataCadastro: dataHoraFormatada,
        }



    const accessToken = localStorage.getItem('accessToken')

    try {
        await api.post('api/Usuario/v1', data, {
            headers: {
                Authorization: `Bearer ${accessToken}`
            }
        });
    } catch (error) {
        alert('erro não foi possível recuperar o Usuário, por favor tente novamente')
    }
    navigate('/listusuario')


}


return (
    <Navbar>

        <Grid container spacing={2} onSubmit={CadUsuario} >
            <Grid className='Exit' justifyContent={'end'} display={'flex'} item xs={12} sm={12} md={12} lg={12} xl={12}>
                <button type="button" class="close" aria-label="Close">
                    <CloseIcon></CloseIcon>
                </button>

            </Grid>
            <Grid item xs={2} sm={2} md={2} lg={2} xl={2}><p>Nome</p> </Grid>
            <Grid item xs={10} sm={10} md={10} lg={10} xl={10}>
                <TextField className='borda' prop fullWidth id="outlined-basic" label="Nome" variant="outlined" value={nome}
                    onChange={e => setNome(e.target.value)} />
            </Grid>
            <Grid item xs={2} sm={2} md={2} lg={2} xl={2}><p>E-mail</p></Grid>
            <Grid item xs={10} sm={10} md={10} lg={10} xl={10}>
                <TextField prop fullWidth id="outlined-basic" label="E-mail" variant="outlined" value={email}
                    onChange={e => setEmail(e.target.value)} />

            </Grid>
            <Grid item xs={2} sm={2} md={2} lg={2} xl={2}><p>Empresa</p></Grid>
            <Grid item xs={10} sm={10} md={10} lg={10} xl={10}>
                
            <Autocomplete
                    disablePortal
                    id="combo-box-demo"
                    options={Empresa}
                    prop fullWidth
                    renderInput={(params) => <TextField {...params} label="Empresa"
                        value={grupo}
                        onChange={e => setGrupo(e.target.value)} />}
                />

            </Grid>

            <Grid item xs={2} sm={2} md={2} lg={2} xl={2}><p>Cargo</p></Grid>
            <Grid item xs={5} sm={5} md={5} lg={5} xl={5}>
                <Autocomplete
                    className='Arredondado'
                    disablePortal
                    id="combo-box-demo"
                    options={Cargos}
                    sx={{ width: 300 }}
                    renderInput={(params) => <TextField {...params} label="Cargos"
                        value={perfil}
                        onChange={e => setPerfil(e.target.value)} />}
                />

            </Grid>

            <Grid item xs={1} sm={1} md={1} lg={1} xl={1}><p>Setor</p></Grid>
            <Grid item xs={4} sm={4} md={4} lg={4} xl={4}>
                <Autocomplete
                    
                    disablePortal
                    id="combo-box-demo"
                    options={Setores}
                    sx={{ width: 300 }}
                    renderInput={(params) => <TextField {...params} label="Setores"
                        value={departamento}
                        onChange={e => setDepartamento(e.target.value)} />}
                />

            </Grid>

            <Grid justifyContent={'flex-end'} display={'flex'} item xs={12} sm={12} md={12} lg={12} xl={12}>
                <ColorButton1 className='BotaoCancelar' variant="contained" color="success">
                    Cancelar
                </ColorButton1>

                <ColorButton className='Botao' variant="contained" color="success"
                    type="submit"
                >
                    Salvar
                </ColorButton>
            </Grid>
        </Grid>

    </Navbar>
);
}