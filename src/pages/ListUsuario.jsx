import React from 'react'
import Navbar from '../components/basicos/Navbar'
import { Avatar, Grid } from '@mui/material';
import User from '../components/basicos/User';
import { useNavigate } from 'react-router-dom'
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Button from '@mui/material/Button';
import ArrowBackIosIcon from '@mui/icons-material/ArrowBackIos';
import TextField from '@mui/material/TextField';


const columns = [
    { field: 'id', headerName: 'ID', width: 130 },
    { field: 'perfil', headerName: 'Perfil', width: 130 },
    { field: 'departamento', headerName: 'Departamento', width: 130 },
    { field: 'organizacao', headerName: 'Organizacao', width: 130 },
    
  ];
  
  const rows = [
    { id: 1, departamento: 'Gestor', perfil: 'Jon', organizacao: 'Cmtech' },
    { id: 2, departamento: 'Atendente', perfil: 'Cersei', organizacao: 'Cmtech' },
    { id: 3, departamento: 'Atendente', perfil: 'Jaime', organizacao: 'Cmtech' },
    { id: 4, departamento: 'Atendente', perfil: 'Arya', organizacao: 'Cmtech' },
    { id: 5, departamento: 'Atendente', perfil: 'Daenerys', organizacao: 'Cmtech' },
    { id: 6, departamento: 'Atendente', perfil: 'null', organizacao: 'Cmtech' },
    { id: 7, departamento: 'Atendente', perfil: 'Ferrara', organizacao: 'Cmtech' },
    { id: 8, departamento: 'Atendente', perfil: 'Rossini', organizacao: 'Cmtech' },
    { id: 9, departamento: 'Atendente', perfil: 'Harvey', organizacao: 'Cmtech' },
  ];



export default function ListUsuario() {


    const navigate = useNavigate()

    const operacoes = (e) => {
        e.preventDefault()

        navigate('/operacoes')
    }

  return (
    <Navbar>
        <Grid container spacing={3}>
            <Grid justifyContent={'space-between'} display={'flex'} item xs={12} sm={12} md={12} lg={12} xl={12}>
            <Button variant="text" onClick={operacoes}><ArrowBackIosIcon/> Voltar</Button>
            <TextField id="outlined-basic" label="Nome" variant="outlined" />
            <TextField id="outlined-basic" label="Cargo" variant="outlined" />
            <TextField id="outlined-basic" label="Setor" variant="outlined" />
            <Button variant="contained">Filtrar</Button>
            </Grid>
            <Grid item xs={12} sm={12} md={12} lg={12} xl={12}>
          <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead>
          <TableRow>
          <TableCell>Id</TableCell>
            <TableCell>Perfil</TableCell>
            <TableCell align="right">Departamento</TableCell>
            <TableCell align="right">Organização</TableCell>
            <TableCell align="right"></TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {rows.map((row) => (
            <TableRow
              key={row.name}
              sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
            >
              <TableCell component="th" scope="row">
                {row.id}
              </TableCell>
              
              <TableCell align="right">{row.perfil}</TableCell>
              <TableCell align="right">{row.departamento}</TableCell>
              <TableCell align="right">{row.organizacao}</TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
          </Grid>
        </Grid>
    </Navbar>
  )
}