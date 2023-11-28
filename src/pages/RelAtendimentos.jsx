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

import TextField from '@mui/material/TextField';
import '../pages/ListUsuario.css';
import { grey } from '@mui/material/colors';
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
  color: theme.palette.getContrastText(grey[200]),
  backgroundColor: grey[300],
  '&:hover': {
    backgroundColor: grey[400],
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
  { id: 'perfilid', name: 'Área' },
  { id: 'departamentoid', name: 'canal' },
  { id: 'Status', name: 'data' }

]




export default function ListUsuario() {

  const [rows, rowChange] = useState([]);
  const [page, pageChange] = useState(0);
  const [rowPerPage, rowPerPageChange] = useState(5);


  const handlechangepage =(event, newpage)=>{
  pageChange(newpage)
}

const handleRowsPerPage = (event) => {
  rowPerPageChange(+event.target.value)
  pageChange(0)
}


  useEffect(() => {
    fetch("https://localhost:44300/api/Usuario/v1").then(resp => {
      return resp.json();
    }).then(resp => {
      rowChange(resp);
    }).catch(e => {
      console.log(e.message)
    })
  }, [])
  const navigate = useNavigate()

  const operacoes = (e) => {
    e.preventDefault()

    navigate('/operacoes')
  }

  return (
    <Navbar>
      <Grid container spacing={3}>
        <Grid justifyContent={'space-between'} display={'flex'} item xs={12} sm={12} md={12} lg={12} xl={12}>


          <FormControl variant="standard">
            <InputLabel shrink htmlFor="bootstrap-input">
              Nome
            </InputLabel>
            <BootstrapInput defaultValue="" id="bootstrap-input" />
          </FormControl>
          <FormControl variant="standard">
            <InputLabel shrink htmlFor="bootstrap-input">
              Cargo
            </InputLabel>
            <BootstrapInput defaultValue="" id="bootstrap-input" />
          </FormControl>
          <FormControl variant="standard">
            <InputLabel shrink htmlFor="bootstrap-input">
              Setor
            </InputLabel>
            <BootstrapInput defaultValue="" id="bootstrap-input" />
          </FormControl>
          <FormControl variant="standard">
            <InputLabel type='datatime' shrink htmlFor="bootstrap-input">
              Período de
            </InputLabel>
            <BootstrapInput defaultValue="" id="bootstrap-input" />
          </FormControl>
          <FormControl variant="standard">
            <InputLabel shrink htmlFor="bootstrap-input">
              Até
            </InputLabel>
            <BootstrapInput defaultValue="" id="bootstrap-input" />
          </FormControl>

          <ColorButton style={{color:'white'}} className='BtFiltrar' type='submit' variant="contained">Filtrar</ColorButton>
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
                  {rows && rows
                    .slice(page * rowPerPage, page * rowPerPage + rowPerPage)
                    .map((row, i) => {
                      return (
                        <TableRow key={i}>
                          {columns && columns.map((column, i) => {
                            let value = row[column.id];
                            return (
                              <TableCell key={value}>
                                {value} 
                              </TableCell>
                            )
                          })} 
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