import * as React from 'react';
import { useState } from 'react';
import { styled } from '@mui/material/styles';
import Box from '@mui/material/Box';
import Paper from '@mui/material/Paper';
import { useNavigate } from 'react-router-dom';
import MenuItem from '@mui/material/MenuItem';
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
import Select from '@mui/material/Select';



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

const {organizacaoId} = useParams();
const [id, setId] = useState(null);
const [nomeOrganizacao, setNomeOrganizacao] = useState('');
const [telefone, setTelefone] = useState('');
const [options, setOptions] = useState([]);
const [selectedOption, setSelectedOption] = useState('');
const [options2, setOptions2] = useState([]);
const [selectedOption2, setSelectedOption2] = useState('');


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

// Função para salvar o organizacao
async function saveOrganizacao() {
  try {
    const response = await api.post("/api/organizacao/v1", {
      //especificar o nome que vai receber 
     nome: nomeOrganizacao,
     segmentoid: selectedOption2,
     grupoid: selectedOption,
     telefone,
    });
    console.log('Organizacao salvo com sucesso:', response.data);
    navigate('/listorganizacao');
  } catch (error) {
    console.error('Erro ao salvar organizacao:', error);
    alert('Erro ao salvar organizacao, tente novamente');
  }
}

 //listagem de gurpo

 useEffect(() => {
  async function fetchData() {
    try {
      const response = await api.get('https://localhost:44300/api/Grupo/v1'); // Rota da API para obter as opções
      setOptions(response.data);
    } catch (error) {
      console.error('Erro ao buscar opções:', error);
    }
  }
  fetchData();
}, []);

const handleChange = (event) => {
  setSelectedOption(event.target.value);
};

//listagem de segmento

useEffect(() => {
  async function fetchData() {
    try {
      const response = await api.get('https://localhost:44300/api/Segmento/v1'); // Rota da API para obter as opções
      setOptions2(response.data);
    } catch (error) {
      console.error('Erro ao buscar opções:', error);
    }
  }
  fetchData();
}, []);

const handleChange2 = (event) => {
  setSelectedOption2(event.target.value);
};



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
                        <TextField prop fullWidth id="outlined-basic" label="Nome da Organização" variant="outlined"
                        value={nomeOrganizacao}
                        onChange={(e) => setNomeOrganizacao(e.target.value)} />
                      
                    </Grid>
                    <Grid item xs={2} sm={2} md={2} lg={2} xl={2}><p>Telefone</p></Grid>
                    <Grid item xs={10} sm={10} md={10} lg={10} xl={10}>
                        <TextField prop fullWidth id="outlined-basic" label="Telefone" variant="outlined" 
                        value={telefone}
                        onChange={(e) => setTelefone(e.target.value)}/>

                    </Grid>
                    <Grid item xs={2} sm={2} md={2} lg={2} xl={2}><p>Segmento</p></Grid>
                    <Grid item xs={10} sm={10} md={10} lg={10} xl={10}>
                    <Select fullWidth sx={{
                      borderRadius:'5px',
                      }} value={selectedOption2} onChange={handleChange2}  displayEmpty>
                    <MenuItem value="" disabled>
                    Selecione uma opção
                    </MenuItem>
                    {options2.map((option) => (
                    <MenuItem key={option.id} value={option.id}>
                    {option.nome}
                    </MenuItem>
                      ))}
                     </Select>

                    </Grid>
                    <Grid item xs={2} sm={2} md={2} lg={2} xl={2}><p>Grupo</p></Grid>
                    <Grid item xs={10} sm={10} md={10} lg={10} xl={10}>
                    <Select fullWidth sx={{
                      borderRadius:'5px',
                     }} value={selectedOption} onChange={handleChange}  displayEmpty>
                    <MenuItem value="" disabled>
                    Selecione uma opção
                    </MenuItem>
                    {options.map((option) => (
                    <MenuItem key={option.id} value={option.id}>
                    {option.nome}
                    </MenuItem>
                      ))}
                     </Select>

                    </Grid>

                    <Grid justifyContent={'flex-end'} display={'flex'} item xs={12} sm={12} md={12} lg={12} xl={12}>
                        <ColorButton1 onClick={listorganizacao} className='BotaoCancelar' variant="contained">
                            Cancelar
                        </ColorButton1>

                        <ColorButton onClick={saveOrganizacao} className='Botao' variant="contained" >
                            Salvar
                        </ColorButton>
                    </Grid>
                </Grid>
            
        
        </Navbar>
    );
}