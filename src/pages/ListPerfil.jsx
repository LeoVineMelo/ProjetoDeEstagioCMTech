import React, {useState,useEffect} from 'react'
import Navbar from '../components/basicos/Navbar'
import { Avatar, Grid } from '@mui/material';
import User from '../components/basicos/User';
import {Router,useNavigate} from 'react-router-dom'
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

const columns = [
  
  { field: 'perfil', headerName: 'Perfil', width: 130 },
  { field: 'departamento', headerName: 'Departamento', width: 130 },
  { field: 'organizacao', headerName: 'Organizacao', width: 130 },

];

const rows = [
  {  departamento: 'Gestor', perfil: 'Jon', organizacao: 'Cmtech' },
  {  departamento: 'Atendente', perfil: 'Cersei', organizacao: 'Cmtech'},
  {  departamento: 'Atendente', perfil: 'Jaime', organizacao: 'Cmtech'},
  {  departamento: 'Atendente', perfil: 'Arya', organizacao: 'Cmtech' },
  {  departamento: 'Atendente', perfil: 'Daenerys', organizacao: 'Cmtech' },
  { departamento: 'Atendente', perfil: 'null', organizacao: 'Cmtech'},
  {  departamento: 'Atendente', perfil: 'Ferrara', organizacao: 'Cmtech' },
  {  departamento: 'Atendente', perfil: 'Rossini', organizacao: 'Cmtech' },
  { departamento: 'Atendente', perfil: 'Harvey', organizacao: 'Cmtech' },
];

export default function ListPerfil() {

  const [perfil, setPerfil] = useState([]);
  const [departamento, setDepartamento] = useState([]);
  const [organizacao, setOrganizacao] = useState([]);

  useEffect(()=>{api.get('api/perfil/v1/asc',{
    headers: {
      
    }
  }).then(response => {
    setPerfil(response.data)
  })

  });


  useEffect(()=>{api.get('api/departamento/v1/asc',{
    headers: {
      
    }
  }).then(response => {
    setDepartamento(response.data)
  })

  });


  useEffect(()=>{api.get('api/organizacao/v1/asc',{
    headers: {
      
    }
  }).then(response => {
    setOrganizacao(response.data)
  })

  });


  const navigate = useNavigate()

   const cadperfill = (e) =>{
        e.preventDefault()

        navigate('/cadperfill')
   }

   const operacoes = (e) => {
    e.preventDefault()

    navigate('/operacoes')
}

  return (
    <Navbar>
      <Grid container spacing={2}>
        <Grid display={'flex'}item xs={6} sm={6} md={6} lg={6} xl={6}>
        <Button variant="text" onClick={operacoes}><ArrowBackIosIcon/> Voltar</Button>
        </Grid>
        <Grid justifyContent={'flex-end'} display={'flex'} item xs={6} sm={6} md={6} lg={6} xl={6}>
        <Button variant="contained" onClick={cadperfill}>Adicionar</Button>
          </Grid>
          <Grid item xs={12} sm={12} md={12} lg={12} xl={12}>
          <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead>
          <TableRow>
          <TableCell></TableCell>
            <TableCell align="right">Perfil</TableCell>
            <TableCell align="right">Departamento</TableCell>
            <TableCell align="right">Organização</TableCell>
            <TableCell align="right">           </TableCell>
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