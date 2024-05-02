import React, {useState} from 'react'
import Navbar from '../components/basicos/Navbar'
import { Avatar, Box, Grid } from '@mui/material';
import User from '../components/basicos/User';
import {useNavigate, useParams} from 'react-router-dom'
import '../components/basicos/Navbar.css'
import Button from '@mui/material/Button';
import { styled, alpha } from '@mui/material/styles';
import api from '../services/api';
import TextField from '@mui/material/TextField';
import MenuItem from '@mui/material/MenuItem';
import { useEffect } from 'react';
import InputLabel from '@mui/material/InputLabel';
import InputBase from '@mui/material/InputBase';
import FormControl from '@mui/material/FormControl';
import TableCell from '@mui/material/TableCell';
import Select from '@mui/material/Select';


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


  const BootstrapInput = styled(InputBase)(({ theme }) => ({
    'label + &': {
      marginTop: theme.spacing(3),
    },
    '& .MuiInputBase-input': {
      borderRadius: 20,
      position: 'relative',
      backgroundColor: theme.palette.mode === 'light' ? '#F3F6F9' : '#1A2027',
      border: '1px solid',
      borderColor: theme.palette.mode === 'light' ? '#E0E3E7' : '#2D3843',
      fontSize: 16,
      width: '100',
      padding: '10px 20px',
      marginLeft: '30%',
      marginRight:'30%',
      transition: theme.transitions.create([
        'border-color',
        'background-color',
        'box-shadow',
      ]),
      // Use the system font instead of the default Roboto font.
      fontFamily: [
        '-apple-system',
        'BlinkMacSystemFont',
        '"Segoe UI"',
        'Roboto',
        '"Helvetica Neue"',
        'Arial',
        'sans-serif',
        '"Apple Color Emoji"',
        '"Segoe UI Emoji"',
        '"Segoe UI Symbol"',
      ].join(','),
      '&:focus': {
        boxShadow: `${alpha(theme.palette.primary.main, 0.25)} 0 0 0 0.2rem`,
        borderColor: theme.palette.primary.main,
      },
    },
  }));

//  mudar para uma listagem de organização
const organizacao = [
  { id: 'nome', },
];




export default function CadDepartamento() {

  const navigate = useNavigate()
  const { departamentoId } = useParams();
  const [id, setId] = useState(null);


 // Estados para armazenar os dados do departamento e da organização
  const [nomeDepartamento, setNomeDepartamento] = useState('');
  const [nomeOrganizacao, setNomeOrganizacao] = useState('');
  const [options, setOptions] = useState([]);
  const [selectedOption, setSelectedOption] = useState('');
  


  const accessToken = localStorage.getItem('accessToken');

  const authorization = {
    Headers:{
      Authorization: `Bearer ${accessToken}`
    }
  }

  useEffect(() => {
    if(departamentoId === '0') return;
    else loadDepartamento();
  }, departamentoId);

  // Função para carregar os dados do departamento
  async function loadDepartamento() {
    try {
      const response = await api.get(`api/departamento/v1/${departamentoId}`);
      const departamento = response.data;
      setNomeDepartamento(departamento.nomeDepartamento);
      setNomeOrganizacao(departamento.nomeOrganizacao);
    } catch (error) {
      console.error('Erro ao carregar departamento:', error);
      alert('Erro de carregamento, tente novamente');
      navigate('/listdepartamento');
    }
  }
// Função para salvar o departamento
  async function saveDepartamento() {
    try {
      const response = await api.post("/api/departamento/v1", {
        //especificar o nome que vai receber 
       nome: nomeDepartamento,
       organizacaoid: selectedOption,
      });
      console.log('Departamento salvo com sucesso:', response.data);
      navigate('/listdepartamento');
    } catch (error) {
      console.error('Erro ao salvar departamento:', error);
      alert('Erro ao salvar departamento, tente novamente');
    }
  }

  //listagem de organização

  useEffect(() => {
    async function fetchData() {
      try {
        const response = await api.get('https://localhost:44300/api/Organizacao/v1'); // Rota da API para obter as opções
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


  const listDepartamento = (e) =>{
    e.preventDefault()

    navigate('/listdepartamento')
}

  return (
    <Navbar>
      <Grid justifyContent={'center'} container spacing={3} display={'flex'}
      > <h1>Cadastro de Departamento</h1>
        
        <Grid item xs={12} sm={12} md={12} lg={12} xl={12}>

        <InputLabel shrink htmlFor="nome-departamento">
          Nome do Departamento
        </InputLabel>
        <BootstrapInput value={nomeDepartamento}
        onChange={(e) => setNomeDepartamento(e.target.value)}  id="nome-departamento" fullWidth />

          
           
        </Grid>
        <Grid item xs={12} sm={12} md={12} lg={12} xl={12}>
          <Select sx={{width: '40%',
            borderRadius:'30px',
            marginLeft: '30%',
            marginRight:'30%',}} value={selectedOption} onChange={handleChange}  displayEmpty>
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
        <Grid justifyContent={'center'} item xs={12} sm={12} md={12} lg={12} xl={12}display={'flex'}>
          <ColorButton1 className='BotaoCancelar' variant="contained"  display={'flex'}
           onClick={listDepartamento}>
            Cancelar
          </ColorButton1>
       
        <ColorButton className='BotaoSalvar' variant="contained" type='submit' onClick={saveDepartamento} >
                           Salvar
                        </ColorButton>
        </Grid>
      </Grid>


    </Navbar>
  )
}