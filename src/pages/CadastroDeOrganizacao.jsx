import * as React from 'react';
import { useState } from 'react';
import { styled } from '@mui/material/styles';
import Box from '@mui/material/Box';
import Paper from '@mui/material/Paper';
import { useNavigate } from 'react-router-dom';

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
import { useParams } from 'react-router-dom';
import { useEffect } from 'react';



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




export default function CadastroDeOrganizacao() {

const [id, setId] = useState(null);
const [idSegmento, setIdSegmento] = useState('');
const [idGrupo, setidGrupo] = useState('');
const [nomeOrganizacao, setNomeOrganizacao] = useState('');
const [telefone, setTelefone] = useState('');

const {organizacaoId} = useParams();

const accessToken = localStorage.getItem('accessToken');

  const authorization = {
    Headers:{
      Authorization: `Bearer ${accessToken}`
    }
  }

const navigate = useNavigate()

  useEffect(() => {
    if(organizacaoId === '0') return;
    else loadOrganizacao();
  }, organizacaoId);

  async function loadOrganizacao() {
    try {
      const response = await api.get(`api/organizacao/v1/${organizacaoId}`, authorization)

      setId(response.data.id);
      setNomeOrganizacao(response.data.nome);
    } catch (error) {
      alert('Erro de carregamento, tente novamente')
      navigate('/listorganizacao')
    }
  }





const listorganizacao = (e) => {
    e.preventDefault()

    navigate('/listorganizacao')
}

    return (
        <Navbar>
        
            
                <Grid container spacing={2}>

                    <Grid className='Exit' justifyContent={'end'} display={'flex'} item xs={12} sm={12} md={12} lg={12} xl={12}>
                        
                    </Grid>

                    
                    
                    <Grid item xs={2} sm={2} md={2} lg={2} xl={2}><p>Nome da Organização</p> </Grid>
                    <Grid item xs={10} sm={10} md={10} lg={10} xl={10}>
                        <TextField prop fullWidth id="outlined-basic" label="Nome da Organização" variant="outlined" />
                    </Grid>
                    <Grid item xs={2} sm={2} md={2} lg={2} xl={2}><p>Telefone</p></Grid>
                    <Grid item xs={10} sm={10} md={10} lg={10} xl={10}>
                        <TextField prop fullWidth id="outlined-basic" label="Telefone" variant="outlined" />

                    </Grid>
                    <Grid item xs={2} sm={2} md={2} lg={2} xl={2}><p>Segmento</p></Grid>
                    <Grid item xs={10} sm={10} md={10} lg={10} xl={10}>
                        <TextField className='Arredondado' prop fullWidth id="outlined-basic" label="Segmento" variant="outlined" />

                    </Grid>
                    <Grid item xs={2} sm={2} md={2} lg={2} xl={2}><p>Grupo</p></Grid>
                    <Grid item xs={10} sm={10} md={10} lg={10} xl={10}>
                        <TextField className='Arredondado' prop fullWidth id="outlined-basic" label="Grupo" variant="outlined" />

                    </Grid>

                    <Grid justifyContent={'flex-end'} display={'flex'} item xs={12} sm={12} md={12} lg={12} xl={12}>
                        <ColorButton1 onClick={listorganizacao} className='BotaoCancelar' variant="contained">
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