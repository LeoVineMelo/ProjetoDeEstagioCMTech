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


const columns = [
  { id: 'nome', name: 'Organização' },
  { id: 'telefone', name: 'Telefone' },
  { id: 'segmento_id', name: 'Segmento' },
  { id: 'grupo_id', name: 'Grupo' }
];



export default function ListPerfil() {

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


  useEffect(() => {
    fetch("https://localhost:44300/api/Organizacao/v1").then(resp => {
      return resp.json();
    }).then(resp => {
      rowChange(resp);
    }).catch(e => {
      console.log(e.message)
    })
  }, [])


  const [id, setId] = useState(null);
  const [perfil, setPerfil] = useState([]);
  const [departamento, setDepartamento] = useState([]);
  const [organizacao, setOrganizacao] = useState([]);

 /* useEffect(() => {
    api.get('api/perfil/v1/asc', {
      headers: {

      }
    }).then(response => {
      setPerfil(response.data)
    })

  });


  useEffect(() => {
    api.get('api/departamento/v1/asc', {
      headers: {

      }
    }).then(response => {
      setDepartamento(response.data)
    })

  });


  useEffect(() => {
    api.get('api/organizacao/v1/asc', {
      headers: {

      }
    }).then(response => {
      setOrganizacao(response.data)
    })

  });

  /* async function deleteOganizacao(id){
    try {
      await api.delete(`api/Oganizacao/v1/${id}`, {
        headers: {
          authorization: `Bearer ${accessToken}`
        }
      });
    } catch (error) {
      alert('A deleção falhou, tente novamente.');
    }
  }*/

  //botão de deleção : <button onClick={()=> deleteOganizacao(oganizacao.id)}


  const navigate = useNavigate()

   /*async function editOganizacao(id){
    try {
      navigate(`cadastrodeorganizacao/${id}`)
    } catch (error) {
      alert('A edição falhou, tente novamente.');
    }
  }*/

  //botão de edição : <button onClick={()=> editOganizacao(oganizacao.id)}

  const cadastrodeorganizacao = (e) => {
    e.preventDefault()

    navigate('/cadastrodeorganizacao')
  }

  const operacoes = (e) => {
    e.preventDefault()

    navigate('/operacoes')
  }

  return (
    <Navbar>
      <Grid container spacing={2}>
        <Grid display={'flex'} item xs={6} sm={6} md={6} lg={6} xl={6}>
          <Button style={{color:'lightgrey'}} variant="text" onClick={operacoes}><ArrowBackIosIcon /> Voltar</Button>
        </Grid>
        <Grid justifyContent={'flex-end'} display={'flex'} item xs={6} sm={6} md={6} lg={6} xl={6}>
          <ColorButton variant="contained" onClick={cadastrodeorganizacao}>Adicionar</ColorButton>
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
                            <Button >
                              <ModeEditOutlineIcon style={{color: 'grey'}}></ModeEditOutlineIcon>
                            </Button>
                            <Button >
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