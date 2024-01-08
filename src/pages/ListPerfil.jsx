import React, { useState, useEffect } from 'react'
import Navbar from '../components/basicos/Navbar'
import { Avatar, Grid, TablePagination } from '@mui/material';
import User from '../components/basicos/User';
import { Router, useNavigate } from 'react-router-dom'
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import Button from '@mui/material/Button';
import ArrowBackIosIcon from '@mui/icons-material/ArrowBackIos';
import { type } from '@testing-library/user-event/dist/type';
import api from '../services/api';
import { purple } from '@mui/material/colors';
import { styled } from '@mui/material/styles';
import { Token } from '@mui/icons-material';
import DeleteOutlinedIcon from '@mui/icons-material/DeleteOutlined';
import ModeEditOutlineIcon from '@mui/icons-material/ModeEditOutline';


const ColorButton = styled(Button)(({ theme }) => ({

  borderRadius: 30,
  marginTop: '20px',
  padding: '5px 30px',
  color: theme.palette.getContrastText(purple[700]),
  backgroundColor: purple[800],
  '&:hover': {
    backgroundColor: purple[900],
  },
}));






export default function ListPerfil() {

  const columns = [
    { id: 'nome', name: 'Perfil' },
    { id: ' ', name: ' ' },
    { id: '', name: ' ' },
  ];
  const handlechangepage = (event, newpage) => {
    pageChange(newpage)
  }

  const handleRowspage = (event) => {
    rowPerPageChange(+event.target.value)
    pageChange(0)
  }

  const [rows, rowChange] = useState([]);
  const [page, pageChange] = useState(0);
  const [rowPerPage, rowPerPageChange] = useState(5);

 
  const accessToken = localStorage.getItem('Token');

  const authorization = {
    Headers: {
      Authorization: `Bearer ${accessToken}`
    }
  }

  useEffect(() => {
    fetch("https://localhost:44300/api/Perfil/v1").then(resp => {
      return resp.json();
    }).then(resp => {
      rowChange(resp);
    }).catch(e => {
      console.log(e.message)
    })
  }, [])



 const [id, setId] = useState(null);
  const [perfil, setPerfil] = useState([]);
  const nomeUsuario = localStorage.getItem('nome.usuario');

  /*
    useEffect(() => {
      api.get('api/perfil/v1/asc/5/1', {
            headers: {
              Authorization: `Bearer ${Token}`
            }
      }).then(Response => {
          setPerfil(Response.data.list)
      })
    }, [Token]);
  */
 async function deletePerfil(id){
     try {
       await api.delete(`api/Perfil/v1/${id}`, {
         headers: {
           authorization: `Bearer ${accessToken}`
         }
       });
     } catch (error) {
       alert('A deleção falhou, tente novamente.');
     }
   }

  const navigate = useNavigate()


  async function editPerfil(id){
      try {
        navigate(`cadperfil/${id}`)
      } catch (error) {
        alert('A edição falhou, tente novamente.');
      }
    }

  const cadperfil = (e) => {
    e.preventDefault()

    navigate('/cadperfil')
  }

  const operacoes = (e) => {
    e.preventDefault()

    navigate('/operacoes')
  }

  return (
    <Navbar>
      <Grid container spacing={2}>
        <Grid display={'flex'} item xs={6} sm={6} md={6} lg={6} xl={6}>
          <Button style={{ color: 'lightgrey' }} variant="text" onClick={operacoes}><ArrowBackIosIcon /> Voltar</Button>
        </Grid>
        <Grid justifyContent={'flex-end'} display={'flex'} item xs={6} sm={6} md={6} lg={6} xl={6}>
          <ColorButton variant="contained" onClick={cadperfil / 0}>Adicionar</ColorButton>
        </Grid>
        <Grid item xs={12} sm={12} md={12} lg={12} xl={12}>
          <Paper sx={{ width: '100' }}>
            <TableContainer>
              <Table stickyHeader>
                <TableHead>
                  <TableRow>
                    {columns.map((column) => (
                      <TableCell style={{ color: 'lightgrey' }} key={column.id}>{column.name}</TableCell>
                    ))}
                    <TableCell style={{ color: 'lightgrey' }}>  </TableCell>
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
                              <TableCell style={{ backgroundColor: 'lightgrey', color: 'black' }} key={value}>
                                {value} 
                              </TableCell>
                            )
                          })}
                          <TableCell style={{ backgroundColor: 'lightgrey', color: 'black'}}>
                            <Button onClick={()=> editPerfil(perfil.id)}>
                              <ModeEditOutlineIcon style={{color: 'grey'}}></ModeEditOutlineIcon>
                            </Button>
                            <Button onClick={()=> deletePerfil(perfil.id)}>
                              <DeleteOutlinedIcon style={{color: 'grey'}}></DeleteOutlinedIcon>
                            </Button>
                          </TableCell>
                        </TableRow>
                      )
                    })}
                </TableBody>
              </Table>
            </TableContainer>
            <TablePagination rowsPerPageOptions={[5, 10, 25]}
              rowsPerPage={rowPerPage}
              page={page}
              count={rows.length}
              component="div"
              onPageChange={handlechangepage}
              onRowsPerPageChange={handleRowspage}
            >

            </TablePagination>
          </Paper>
        </Grid>
      </Grid>
    </Navbar>
  )
}