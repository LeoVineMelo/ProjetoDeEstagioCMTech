import React, {useState} from 'react'
import Navbar from '../components/basicos/Navbar'
import { Avatar, Box, Grid } from '@mui/material';
import User from '../components/basicos/User';
import {useNavigate, useParams} from 'react-router-dom'
import '../components/basicos/Navbar.css'
import Button from '@mui/material/Button';
import { styled } from '@mui/material/styles';
import api from '../services/api';
import TextField from '@mui/material/TextField';
import MenuItem from '@mui/material/MenuItem';
import { useEffect } from 'react';


import { purple } from '@mui/material/colors';
import { grey } from '@mui/material/colors';
import { Token } from '@mui/icons-material';


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



const organizacao = [
  {
    value: 'Org1',
    label: 'CMTech',
  },
  {
    value: 'Org2',
    label: 'porto1',
  },
  {
    value: 'Org3',
    label: 'porto2',
  },
  {
    value: 'Org4',
    label: 'porto3',
  },
];
const departamento = [
  {
    value: 'Dep1',
    label: 'Suporte',
  },
  {
    value: 'Dep2',
    label: 'Administrativo',
  },
  {
    value: 'Dep3',
    label: 'Finaceiro',
  },
  {
    value: 'Dep4',
    label: 'Comercial',
  },
];


export default function CadPerfill() {

  const [id, setId] = useState(null)
  const [nomePerfil, setNomePerfil] = useState('');
  const [nomeDepartamento, setNomeDepartamento] = useState('');
  const [nomeOrganizacao, setNomeOrganizacao] = useState('');

  const {perfilId} = useParams();

  const accessToken = localStorage.getItem('accessToken');

  const authorization = {
    Headers:{
      Authorization: `Bearer ${accessToken}`
    }
  }

  const navigate = useNavigate()

  useEffect(() => {
    if(perfilId === '0') return;
    else loadPerfil();
  }, perfilId);

  async function loadPerfil() {
    try {
      const response = await api.get(`api/perfil/v1/${perfilId}`, authorization)

      setId(response.data.id);
      setNomePerfil(response.data.nome);
    } catch (error) {
      alert('Erro de carregamento, tente novamente')
      navigate('/listperfil')
    }
  }

  async function CreateNewPerfil(e) {
    e.preventDefault();
  }

  


  const listperfil = (e) =>{
    e.preventDefault()

    navigate('/listperfil')
}

  return (
    <Navbar>
      <Grid justifyContent={'center'} container spacing={3} display={'flex'}
      > <h1>Cadastro de perfil</h1>
        <Grid item xs={12} sm={12} md={12} lg={12} xl={12}>
          <TextField className='Formu' id="outlined-basic" label="Nome do perfil" variant="outlined" />
        </Grid>
        <Grid item xs={12} sm={12} md={12} lg={12} xl={12}>

          <TextField

            className='Formu'
            id="outlined-select-currency"
            select
            label="Select"
            defaultValue="Dep1"
            helperText="Selecione o Departamento"
          >
            {departamento.map((option) => (
              <MenuItem key={option.value} value={option.value}>
                {option.label}
              </MenuItem>
            ))}
          </TextField>

        </Grid>
        <Grid item xs={12} sm={12} md={12} lg={12} xl={12}>

          <TextField
            className='Formu'
            id="outlined-select-currency"
            select
            label="Select"
            defaultValue="Org1"
            helperText="Selecione a Organizaçao"
          >
            {organizacao.map((option) => (
              <MenuItem key={option.value} value={option.value}>
                {option.label}
              </MenuItem>
            ))}
          </TextField>
        </Grid >
        <Grid justifyContent={'center'} item xs={12} sm={12} md={12} lg={12} xl={12}display={'flex'}>
          <ColorButton1 className='BotaoCancelar' variant="contained"  display={'flex'} onClick={listperfil}>
            Cancelar
          </ColorButton1>
       
        <ColorButton className='BotaoSalvar' variant="contained" onClick={listperfil} >
                           Salvar
                        </ColorButton>
        </Grid>
      </Grid>


    </Navbar>
  )
}