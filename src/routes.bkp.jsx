import * as React from "react";
import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom";
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



export const router = createBrowserRouter([
  {
    path: "/",
    element: <Login />
  },
  {
    path: "/login",
    element: <Login />
  },
  {
    path: "home",
    element: <Home />,
  },
  {
    path: "recuperarsenha",
    element: <RecuperarSenha/>
  },
  {
    path: "trocarsenha",
    element: <TrocarSenha/>
  },
  {
    path: "cadperfil/:perfilId",
    element: <CadPerfill/>
  },
  {
    path: "operacoes",
    element: <Operacoes/>
  },
  {
    path: "listperfil",
    element: <ListPerfil/>
  },
  {
    path: "listusuario",
    element: <ListUsuario/>
  },
  {
    path: "cadastros",
    element: <Cadastros/>
  },
  {
    path: "cadastrodeusuario",
    element: <CadastroDeUsuario/>
  },
  {
    path: "cadastrodecliente",
    element: <CadastroDeCliente/>
  },
  {
    path: "chatatendimento",
    element: <ChatAtendimento/>
  },
  {
    path: "atendimento",
    element: <Atendimento/>
  },
  {
    path: "listdepartamento",
    element: <ListDepartamento/>
  },
  {
    path: "listorganizacao",
    element: <ListOrganizacao/>
  },
  {
    path: "relatendimentos",
    element: <RelAtendimentos/>
  },
  {
    path: "cadastrodeorganizacao/:organizacaoId",
    element: <CadastroDeOrganizacao/>
  },
  {
    path: "caddepartamento/:departamentoId",
    element: <CadDepartamento/>
  },


]);