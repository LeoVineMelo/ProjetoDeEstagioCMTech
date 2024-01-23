import React, { useContext } from 'react'
import { BrowserRouter as Router, Routes, Route, Navigate } from "react-router-dom/dist"
import { AuthProvider, AuthContext } from "./context/auth";
import Login from './pages/Login';
import Home from "./pages/Home";
import TrocarSenha from './pages/TrocarSenha';
import RecuperarSenha from './pages/RecuperarSenha';
import CadPerfill from "./pages/Cadperfill";
import Operacoes from "./pages/Operacoes";
import ListPerfil from "./pages/ListPerfil";
import ListUsuario from './pages/ListUsuario';
import Cadastros from "./pages/Cadastros";
import CadastroDeCliente from './pages/CadastroDeCliente';
import CadastroDeUsuario from './pages/CadastroDeUSuario';
import Atendimento from  './pages/Atendimento';
import ListDepartamento from './pages/ListDepartamento';
import ListOrganizacao from './pages/ListOrganizacao';
import RelAtendimentos from './pages/RelAtendimentos';
import CadastroDeOrganizacao from './pages/CadastroDeOrganizacao';
import CadDepartamento from './pages/CadDepartamentos';
import ChatAtendimento from './pages/ChatAtendimento';

const AppRoutes = () => {

  const Private = ({ children }) => {
    const { authenticated, loadingRoute } = useContext(AuthContext)
    
    if (loadingRoute)
      return <div>carregando...</div>

    if (!authenticated)
      return <Navigate to="/login" />
    else
      return children
  }

  return(
    <Router>
      <AuthProvider>
        <Routes>
          <Route exact path="/login" element={<Login />} />
          <Route exact path="/" element={<Login />} />
          <Route exact path="/home" element={<Private><Home /></Private>} />
          <Route exact path="/recuperarsenha" element={<Private><RecuperarSenha /></Private>} />
          <Route exact path="/trocarsenha" element={<Private><TrocarSenha /></Private>} />
          <Route exact path="/cadperfil/:perfilId" element={<Private><CadPerfill /></Private>} />
          <Route exact path="/operacoes" element={<Private><Operacoes /></Private>} />
          <Route exact path="/listperfil" element={<Private><ListPerfil /></Private>} />
          <Route exact path="/listusuario" element={<Private><ListUsuario /></Private>} />
          <Route exact path="/cadastros" element={<Private><Cadastros /></Private>} />
          <Route exact path="/cadastrodeusuario" element={<Private><CadastroDeUsuario /></Private>} />
          <Route exact path="/cadastrodecliente" element={<Private><CadastroDeCliente /></Private>} />
          <Route exact path="/chatatendimento" element={<Private><ChatAtendimento /></Private>} />
          <Route exact path="/atendimento" element={<Private><Atendimento /></Private>} />
          <Route exact path="/listdepartamento" element={<Private><ListDepartamento /></Private>} />
          <Route exact path="/listorganizacao" element={<Private><ListOrganizacao /></Private>} />
          <Route exact path="/relatendimentos" element={<Private><RelAtendimentos /></Private>} />
          <Route exact path="/cadastrodeorganizacao/:organizacaoId" element={<Private><CadastroDeOrganizacao /></Private>} />
          <Route exact path="/caddepartamento/:departamentoId" element={<Private><CadDepartamento /></Private>} />
        </Routes>
      </AuthProvider>
    </Router>
  )
}

export default AppRoutes