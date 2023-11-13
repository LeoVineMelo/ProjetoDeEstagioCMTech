import React, {useState} from 'react'
import Navbar from '../components/basicos/Navbar'
import { Avatar, Box, Grid } from '@mui/material';
import User from '../components/basicos/User';
import {useNavigate} from 'react-router-dom'
import '../components/basicos/Navbar.css'
import Button from '@mui/material/Button';
import { deepPurple,  grey } from '@mui/material/colors';
import api from '../services/api';
import TextField from '@mui/material/TextField';
import MenuItem from '@mui/material/MenuItem';


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

  const [nomePerfil, setNomePerfil] = useState('');
  const [nomeDepartamento, setNomeDepartamento] = useState('');
  const [nomeOrganizacao, setNomeOrganizacao] = useState('');

  const navigate = useNavigate()


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
          <Button className='BotaoCancelar' variant="contained"  display={'flex'} onClick={listperfil}>
            Cancelar
          </Button>
       
        <Button className='BotaoSalvar' variant="contained" onClick={listperfil} >
                           Salvar
                        </Button>
        </Grid>
      </Grid>


    </Navbar>
  )
}