import React, { useEffect, useState } from 'react'
import Navbar from '../components/basicos/Navbar'
import { Avatar, Grid, TablePagination } from '@mui/material';
import User from '../components/basicos/User';
import { useNavigate } from 'react-router-dom'
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Button from '@mui/material/Button';
import api from '../services/api';

import TextField from '@mui/material/TextField';
import '../pages/ListUsuario.css';
import { purple } from '@mui/material/colors';
import { styled } from '@mui/material/styles';
import InputBase from '@mui/material/InputBase';
import { alpha } from '@mui/material/styles';
import InputLabel from '@mui/material/InputLabel';
import FormControl from '@mui/material/FormControl';

import Paper from '@mui/material/Paper';



const ColorButton = styled(Button)(({ theme }) => ({
  borderRadius: 30,
  marginTop: '20px',
  padding: '5px 12px',
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
    borderRadius: 30,
    position: 'relative',
    backgroundColor: theme.palette.mode === 'light' ? '#F3F6F9' : '#1A2027',
    border: '1px solid',
    borderColor: theme.palette.mode === 'light' ? '#E0E3E7' : '#2D3843',
    fontSize: 16,
    width: '100%',
    padding: '8px 40px',
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



const columns = [
  { id: 'nome', name: 'nome' },
  { id: 'Perfil', name: 'Perfil' },
  { id: 'Departamento', name: 'Departamento' },
  { id: 'Status', name: 'Status' }

]



export default function ListUsuario() {

  const [rows, rowChange] = useState([]);
  const [page, pageChange] = useState(0);
  const [rowPerPage, rowPerPageChange] = useState(5);

  const [nome, setNome] = useState('');
  const [cargo, setCargo] = useState('');
  const [setor, setSetor] = useState('');

  const handlechangepage = (event, newpage) => {
    pageChange(newpage)
  }

  const handleRowsPerPage = (event) => {
    rowPerPageChange(+event.target.value)
    pageChange(0)
  }


  useEffect(() => {
    Pesquisa()
  }, [])
  const navigate = useNavigate()

  const operacoes = (e) => {
    e.preventDefault()

    navigate('/operacoes')
  }

  async function FazerPesquisa(e) {
    e.preventDefault();

    Pesquisa()
  }
  

  async function Pesquisa() {

    const data = {
      nome: nome != null ? nome : "",
      cargo: cargo != null ? cargo : "",
      setor: setor != null ? setor : "",
    };

    try {
      //const response = await api.post('api/Usuario/v1/search', data)
      fetch(
        "https://localhost:44300/api/Usuario/v1/search",
        {
          headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
          },
          method: 'POST',
          body: JSON.stringify(data)
        }).then(resp => {
        return resp.json();
      }).then(resp => {
        console.log(resp)
        console.log(typeof resp)
        let list = resp.map(item => {
          return {
            ...item,
            Perfil: item.perfil ? item.perfil.nome : '',
            Organizacao: item.organizacao ? item.organizacao.nome : '',
            Departamento: item.departamento ? item.departamento.nome : ''
          }
        })
        console.log(list)
        console.log(typeof list)
        rowChange(list);
      }).catch(e => {
        console.log(e.message)
      })

    } catch (error) {
      console.log(error);

    }

    

  }

  /*const filteredRows = rows != null ? rows.filter(row => {

    let nomeFilter = row.nome.includes(nome);
    let cargoFilter = row.Perfil.includes(cargo);
    let setorFilter = row.Departamento.includes(setor);

    return nomeFilter && cargoFilter && setorFilter;
  }) : rows;*/





   /* async function deleteUsuario(id){
    try {
      await api.delete(`api/Usuario/v1/${id}`, {
        headers: {
          authorization: `Bearer ${accessToken}`
        }
      });
    } catch (error) {
      alert('A deleção falhou, tente novamente.');
    }
  }*/


  return (
    <Navbar>
      <Grid container spacing={3}>
        <Grid justifyContent={'space-between'} display={'flex'} item xs={12} sm={12} md={12} lg={12} xl={12}>


          <FormControl variant="standard">
            <InputLabel
              shrink htmlFor="bootstrap-input">
              Nome
            </InputLabel>
            <BootstrapInput value={nome}
              onChange={e => setNome(e.target.value)} defaultValue="" id="bootstrap-input" />
          </FormControl>
          <FormControl variant="standard">
            <InputLabel
              shrink htmlFor="bootstrap-input">
              Cargo
            </InputLabel>
            <BootstrapInput value={cargo}
              onChange={e => setCargo(e.target.value)} defaultValue="" id="bootstrap-input" />
          </FormControl>
          <FormControl variant="standard">
            <InputLabel
              shrink htmlFor="bootstrap-input">
              Setor
            </InputLabel>
            <BootstrapInput value={setor}
              onChange={e => setSetor(e.target.value)} defaultValue="" id="bootstrap-input" />
          </FormControl>

          <ColorButton onClick={FazerPesquisa} className='BtFiltrar' type='submit' variant="contained">Filtrar</ColorButton>
        </Grid>
        <Grid item xs={12} sm={12} md={12} lg={12} xl={12}>

          <Paper sx={{ width: '100%' }}>
            <TableContainer>
              <Table stickyHeader>
                <TableHead>
                  <TableRow>
                    {columns.map((column) => (
                      <TableCell style={{ backgroundColor: '#ce93d8', }} key={column.id}>{column.name}</TableCell>
                    ))}
                  </TableRow>
                </TableHead>
                <TableBody>
                  {/*<TableRow>
                    {filteredRows.map((row) =>{
                      console.log(row)
                      return (
                      <TableRow key={row.id}>
                        <TableCell>{row.nome}</TableCell>
                        <TableCell>{row.Perfil}</TableCell>
                        <TableCell>{row.Departamento}</TableCell>
                      </TableRow>
                    )})}
                      </TableRow>*/}
                  {rows && rows
                    .slice(page * rowPerPage, page * rowPerPage + rowPerPage)
                    .map((row, i) => {
                      return (
                        <TableRow key={i}>
                          <TableCell>{row.nome}</TableCell>
                          <TableCell>{row.Perfil}</TableCell>
                          <TableCell>{row.Departamento}</TableCell>
                          <TableCell>{""}</TableCell>
                          {/*columns && columns.map((column, i) => {
                            let value = row[column.id];
                            return (
                              <TableCell key={value}>
                                {value}
                              </TableCell>
                            )
                          })*/}
                        </TableRow>
                      )
                    })}
                </TableBody>
              </Table>
            </TableContainer>
            <TablePagination rowsPerPageOptions={[5, 10, 25]}
              page={page}
              rowsPerPage={rowPerPage}
              component="div"
              onPageChange={handlechangepage}
              onRowsPerPageChange={handleRowsPerPage}
            >
            </TablePagination>
          </Paper>


        </Grid>
      </Grid>
    </Navbar>
  )
}