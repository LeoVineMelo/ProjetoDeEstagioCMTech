import React from 'react'
import Navbar from '../components/basicos/Navbar'
import { Grid, MenuItem, MenuList, Paper } from "@mui/material";
import { useNavigate } from "react-router-dom";
import Button from '@mui/material/Button';
import { AuthContext } from '../context/auth';
import { HubConnectionBuilder } from '@microsoft/signalr';
import BasicSelect from '../components/BasicSelect';
import TextField from '@mui/material/TextField';
import ChatWindow from '../components/ChatWindow';
import CircularProgress from '@mui/material/CircularProgress';
import { green } from '@mui/material/colors';
import { MySnackbar } from '../components/MySnackbar';
import { Link } from 'react-router-dom';

function Chat() {

  const { usuario, logout } = React.useContext(AuthContext)

  const navigate = useNavigate();


  const [loading, setLoading] = React.useState(false);
 
  const [variant, setVariant] = React.useState('success');
  const [message, setMessage] = React.useState('');
  const [open, setOpen] = React.useState(false);

  const [ connection, setConnection ] = React.useState(null);
  const [ chat, setChat ] = React.useState([]);
  const latestChat = React.useRef(null);

  const [ signalRId, setSignalRId] = React.useState("");
  const [ connectedUsuarioList, setConnectedUsuarioList] = React.useState([])
  const [ receiverUsuario, setReceiverUsuario] = React.useState("");
  const [ chatMessage, setChatMessage ] = React.useState("");

  latestChat.current = chat;

  React.useEffect(() => {
		const newConnection = new HubConnectionBuilder()
			.withUrl('https://localhost:44300/chat')
			.withAutomaticReconnect()
			.build();

		setConnection(newConnection);
	}, []);


  React.useEffect(() => {
	
        if (connection) {
            connection.start()
                .then(result => {
                    console.log('Connected!');
					          openNotification('success', 'Conectado!', true);
                    authMeListenerSuccess()
                    authMeListenerFail()
                    getOnlineUsuariosListener()
                    usuarioOnListener()
                    usuarioOffListener()
                    messageListener()
                    getUsuariosMessageListener()
                    authMe()
                })
                .catch(e => {
					  console.log('Connection failed: ', e);
					  openNotification('error', 'Connection failed: '+e.message, true);

			});
        }

      }, [connection]);

      function openNotification(variant, message, open){
        setVariant(variant);
        setMessage(message);
        setOpen(open);
      }
    
      function closeNotification(){
        setOpen(false);
      }
      
      const onMessageUpdate = (e) => {
        setChatMessage(e.target.value);
      }
    
      const authMe = async () => {
        if (connection._connectionStarted) {
          try {
            await connection.invoke("authMe", usuario.id)
          } catch (e) {
            console.log(e)
          }
        }
      }
      
      const authMeListenerSuccess = () => {
        connection.on("authMeResponseSuccess", usuarioVO => {
          setSignalRId(usuarioVO.signalrId)
          getOnlineUsuarios()
        })
      }
    
      const authMeListenerFail = () => {
        connection.on("authMeResponseFail", () => {
          openNotification('error', 'Usuário não existe no sistema!', true);
        })
      }
    
      const getOnlineUsuarios = async () => {
        try {
          await connection.invoke("getOnlineUsuarios")
        } catch (e) {
          console.log(e)
        }
      }
      
      const getOnlineUsuariosListener = () => {
        connection.on("getOnlineUsuariosResponse", connectedUsuarios => {
          setConnectedUsuarioList(connectedUsuarios);
        })
      }
    
      const usuarioOnListener = () => {
        connection.on("usuarioOn", newUsuario => {
          let usuarioExists = connectedUsuarioList.filter(u => u.id == newUsuario.id)
          if (usuarioExists == null || (usuarioExists && usuarioExists.length == 0)) {
            setConnectedUsuarioList([...usuarioExists, newUsuario])
          } else {
            let otherUsuarios = connectedUsuarioList.filter(u => u.id != newUsuario.id)
            setConnectedUsuarioList([...otherUsuarios, newUsuario])
          }
        })
      }
    
      const usuarioOffListener = () => {
        connection.on("usuarioOff", usuarioId => {
          let onlineUsuariosList = connectedUsuarioList
          onlineUsuariosList.filter(u => u.id != usuarioId)
          setConnectedUsuarioList(onlineUsuariosList)
        })
      }
    
      const messageListener = () => {
        connection.on("sendMsgResponse", (connId, usuarioName, msg) => {
          let receiver = connectedUsuarioList.find(u => u.connId === connId);
          if (receiver != null) {
            if (receiver.msgs == null) receiver.msgs = []
            receiver.msgs.push({ usuario: usuarioName, message: msg })
    
            let otherUsuarios = connectedUsuarioList.filter(u => u.id != receiver.id)
            setConnectedUsuarioList([...otherUsuarios, receiver])
          }
          let updatedChat = [...latestChat.current];
          updatedChat.push({ usuario: usuarioName, message: msg });
          setChat(updatedChat)
        })
      }
    
      const getUsuariosMessageListener = () => {
        connection.on("getUsuarioMessagesResponse", chatMessages => {
          setChat(chatMessages)
        })
      }
    
      const onSubmit = (e) => {
        e.preventDefault();
    
        const isUsuarioProvided = receiverUsuario && receiverUsuario !== '';
        const isMessageProvided = chatMessage && chatMessage !== '';
    
        if (isUsuarioProvided && isMessageProvided) {
          sendMessage(receiverUsuario, chatMessage);
        } else {
          alert('Por favor, insira um usuário e uma mensagem.');
        }
      }
      
      const getUsuariosMessage = async (connId) => {
        if (connection._connectionStarted) {
          connection.invoke("getUsuarioMessages", connId)
            .catch(err => console.log(err))
    
          setChatMessage("")
        } else {
          openNotification('info', 'Não há conexão ativa com o servidor de mensagens.', true);
        }
      }
    
      const sendMessage = async (connId, msg) => {
        if (connection._connectionStarted) {
          connection.invoke("sendMsg", connId, msg)
            .catch(err => console.log(err))
    
          setChatMessage("")
        } else {
          openNotification('info', 'Não há conexão ativa com o servidor de mensagens.', true);
        }
      }
    
      const handleChangeReceiverUsuario = (e) => {
        setReceiverUsuario(e)
        if (e == null || (e && e.length > 0))
          getUsuariosMessage(e)
        else
          setChat([])
      }


  return (
    <Navbar>
      <Grid display={'flex'} container spacing={4}>
        <Grid item xs={2} md={2} style={{padding: 10}}>
          <button variant="containerd">
            <Link to={`/home`} style={{ color: '#FFF', textDecoration: 'none'}}>Voltar</Link>
          </button>
          </Grid>
          <Grid item xs={6} md={6} style={{padding: 10}}>
            <box component="form" sx={{'& > :not(style)': {m: 1, width: '25ch'}, fontSize: '2em'}} noValidate autoComplete="off">
              Chat
            </box>       
          </Grid>
        <Grid item xs={2} md={4} style={{ padding: 10 }}>
        <Button variant="contained" onClick={() => logout()}>
            Sair
          </Button>
        </Grid>
        <Grid item xs={12} md={12} style={{ padding: 10 }}>
          <h3>{usuario.name}</h3>
        </Grid>
        <Grid item xs={12} md={12} style={{ padding: 10 }}>
        <form onSubmit={onSubmit}>
              <label htmlFor="usuario">Selecione um destinatário:</label>
              <br />
              <Grid item xs={6} md={6} style={{ padding: 10 }}>
                <BasicSelect
                  label={"Lista"}
                  list={connectedUsuarioList}
                  value={receiverUsuario}
                  handleChange={handleChangeReceiverUsuario} />
                  </Grid>
                  <Grid item xs={6} md={6} style={{ padding: 10 }}>
                <Paper>
                  <MenuList>
                    {connectedUsuarioList && connectedUsuarioList.map(item => <MenuItem onClick={() => handleChangeReceiverUsuario(item.signalrId) }>{item.name}</MenuItem>)}
                  </MenuList>
                </Paper>
              </Grid>
              <br/>
              <label htmlFor="message">Mensagem:</label>
              <br />
              <Grid item xs={12} md={12} style={{ padding: 10 }}>
                <TextField
                  id="message"
                  name="message"
                  label="Mensagem"
                  multiline
                  maxRows={8}
                  rows={6}
                  value={chatMessage}
                  onChange={onMessageUpdate}
                  variant="filled"
                />
              </Grid>
              <Grid item xs={2} md={2} style={{ padding: 10 }}>
                <Button variant="contained" type="submit">
                  Enviar
                </Button>
              </Grid>
                  </form>
                  <hr/>
                  <ChatWindow chat={chat}/>
      </Grid>
      </Grid>
      {loading && (
        <div style={{
          position: 'fixed',
          top: 0,
          left: 0,
          width: '100%',
          height: '100%',
          background: '#000',
          opacity: 0.7,
          display: 'flex',
          justifyContent: 'center',
          alignItems: 'center',
          zIndex: 2147483646
        }}>
          <CircularProgress size={68}
            sx={{
            color: green[500]
            }} />
        </div>
      )}
      <MySnackbar
        variant={variant}
        message={message}
        isOpen={open}
        toClose={closeNotification} 
      />
    </Navbar>
  )
}

export default Chat