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
import SendOutlinedIcon from '@mui/icons-material/SendOutlined';
import { purple } from '@mui/material/colors';
import User from '../components/basicos/User';
import InputLabel from '@mui/material/InputLabel';
import FormControl from '@mui/material/FormControl';
import Select from '@mui/material/Select';
import NativeSelect from '@mui/material/NativeSelect';
import InputBase from '@mui/material/InputBase';
import Divider from '@mui/material/Divider';
import IconButton from '@mui/material/IconButton';
import MenuIcon from '@mui/icons-material/Menu';
import SearchIcon from '@mui/icons-material/Search';
import DirectionsIcon from '@mui/icons-material/Directions';
import WhatsAppIcon from '@mui/icons-material/WhatsApp';
import AppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';
import Menu from '@mui/material/Menu';
import Container from '@mui/material/Container';
import Avatar from '@mui/material/Avatar';
import Tooltip from '@mui/material/Tooltip';
import TrendingFlatIcon from '@mui/icons-material/TrendingFlat';
import AdbIcon from '@mui/icons-material/Adb';
import StopIcon from '@mui/icons-material/Stop';
import Card from '@mui/material/Card';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';

import ListItemText from '@mui/material/ListItemText';
import ListItemAvatar from '@mui/material/ListItemAvatar';





const color = purple[500];

function Chat() {





  const [anchorElNav, setAnchorElNav] = React.useState(null);
  const [anchorElUser, setAnchorElUser] = React.useState(null);

  const [age, setAge] = React.useState('');

  const handleChange = (event) => {
    setAge(event.target.value);
  };


  const { usuario, logout } = React.useContext(AuthContext)

  const navigate = useNavigate();


  const [loading, setLoading] = React.useState(false);

  const [variant, setVariant] = React.useState('success');
  const [message, setMessage] = React.useState('');
  const [open, setOpen] = React.useState(false);

  const [connection, setConnection] = React.useState(null);
  const [chat, setChat] = React.useState([]);
  const latestChat = React.useRef(null);

  const [signalRId, setSignalRId] = React.useState("");
  const [connectedUsuarioList, setConnectedUsuarioList] = React.useState([])
  const [receiverUsuario, setReceiverUsuario] = React.useState("");
  const [chatMessage, setChatMessage] = React.useState("");

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
          openNotification('error', 'Connection failed: ' + e.message, true);

        });
    }

  }, [connection]);

  function openNotification(variant, message, open) {
    setVariant(variant);
    setMessage(message);
    setOpen(open);
  }

  function closeNotification() {
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
      <Grid flexWrap={'nowrap'} item xs={12} md={12} display={'flex'} container spacing={0}>
        <Grid item xs={4} md={4}>
          <Grid item xs={12} md={12} style={{ padding: 0, backgroundColor: 'purple', borderTopLeftRadius: '30px' }}>
            <Grid style={{ color: 'white', padding: '20' }}>
              <b>atendimentos</b>
            </Grid>
            <Grid justifyContent={'center'} display={'flex'}>
              <Paper
                component="form"
                sx={{ p: '2px 4px', display: 'flex', alignItems: 'center', width: 400, borderRadius: '20px' }}
              >

                <InputBase
                  sx={{ ml: 1, flex: 1 }}
                  placeholder="Pesquisa"
                  inputProps={{ 'aria-label': 'search google maps' }}
                />
                <IconButton type="button" sx={{ p: '10px' }} aria-label="search">
                  <SearchIcon />
                </IconButton>
              </Paper>
            </Grid>
            <Grid justifyContent={'space-around'} spacing={10} display={'flex'}>
              <Grid >
                <FormControl fullWidth>
                  <InputLabel variant="standard" htmlFor="uncontrolled-native">

                  </InputLabel>
                  <NativeSelect style={{ marginBottom: 20, backgroundColor: 'white', borderRadius: '20px', width: '200%', marginTop: '40px' }}
                    defaultValue={30}
                    inputProps={{
                      name: 'Andamento ',
                      id: 'uncontrolled-native',
                    }}
                  >
                    <option value={10}>whatsapp</option>
                    <option value={20}>Telegran</option>
                    <option value={30}>Telefone</option>
                  </NativeSelect>
                </FormControl>
              </Grid>

              <Grid >
                <FormControl fullWidth>
                  <InputLabel variant="standard" htmlFor="uncontrolled-native">

                  </InputLabel>
                  <NativeSelect style={{ backgroundColor: 'white', borderRadius: '20px', width: '150%', marginTop: '40px' }}
                    defaultValue={30}
                    inputProps={{
                      name: 'Andamento ',
                      id: 'uncontrolled-native',
                    }}
                  >
                    <option value={10}>Em andamento</option>
                    <option value={20}>Finalizado</option>
                    <option value={30}>Chamado</option>
                  </NativeSelect>
                </FormControl>
              </Grid>
            </Grid>
          </Grid>
          <Grid>
          <List sx={{ width: '100%',  bgcolor: 'background.paper' }}>

            <Card sx={{backgroundColor:'lightgray' ,borderRadius:'20px'}}>
              <Button>
      <ListItem alignItems="flex-start">
        <ListItemAvatar>
          <Avatar alt="Remy Sharp" src="/static/images/avatar/1.jpg" />
        </ListItemAvatar>
        <ListItemText
          primary="Brunch this weekend?"
          secondary={
            <React.Fragment>
              <Typography
                sx={{ display: 'inline' }}
                component="span"
                variant="body2"
                color="text.primary"
              >
                Ali Connors
              </Typography>
              {" — I'll be in your neighborhood doing errands this…"}
            </React.Fragment>
          }
        />
      </ListItem>
      </Button>
      </Card>

      <Divider variant="inset" component="li" />
      
      <Card sx={{backgroundColor:'lightgray' ,borderRadius:'20px'}}>
        <Button>
      <ListItem alignItems="flex-start">
        <ListItemAvatar>
          <Avatar alt="Travis Howard" src="/static/images/avatar/2.jpg" />
        </ListItemAvatar>
        <ListItemText
          primary="Summer BBQ"
          secondary={
            <React.Fragment>
              <Typography
                sx={{ display: 'inline' }}
                component="span"
                variant="body2"
                color="text.primary"
              >
                to Scott, Alex, Jennifer
              </Typography>
              {" — Wish I could come, but I'm out of town this…"}
            </React.Fragment>
          }
        />
      </ListItem>
      </Button>
      </Card>

      <Divider variant="inset" component="li" />

      <Card sx={{backgroundColor:'lightgray' ,borderRadius:'20px'}}>
        <Button>
      <ListItem alignItems="flex-start">
        <ListItemAvatar>
          <Avatar alt="Cindy Baker" src="/static/images/avatar/3.jpg" />
        </ListItemAvatar>
        <ListItemText
          primary="Oui Oui"
          secondary={
            <React.Fragment>
              <Typography
                sx={{ display: 'inline' }}
                component="span"
                variant="body2"
                color="text.primary"
              >
                Sandra Adams
              </Typography>
              {' — Do you have Paris recommendations? Have you ever…'}
            </React.Fragment>
          }
        />
      </ListItem>
      </Button>
      </Card>
    </List> 
          </Grid>
        </Grid>

        <Grid alignItems={'stretch'} flexDirection={'column'} item xs={12} md={12} display={'flex'}>
          <Grid item xs={12} md={12} style={{ padding: 0, }}>
            <AppBar display='flex' style={{ width: '100%', backgroundColor: 'lightgrey' }} position="static">
              <Container maxWidth="100hv" >
                <Toolbar disableGutters>
                  <Button><Avatar /></Button>
                  <BasicSelect
                  label={"Destinatário"}
                  list={connectedUsuarioList}
                  value={receiverUsuario}
                  handleChange={handleChangeReceiverUsuario} />
                  <Divider style={{ padding: 5, color: 'grey' }} orientation="vertical" flexItem />
                  <strong style={{ padding: 5, color: 'GrayText' }}>
                    perfil
                  </strong>
                  <Divider style={{ padding: 5, color: 'grey' }} orientation="vertical" flexItem />
                  <Button> <WhatsAppIcon style={{ color: 'GrayText' }} /></Button>
                </Toolbar>
              </Container>
            </AppBar>


            <AppBar style={{ width: '100%', backgroundColor: 'snow', }} position="static">
              <Container maxWidth="100vh">

                <Toolbar style={{ justifyContent: 'space-between' }} display={'flex'} disableGutters>
                  <FormControl variant="standard" sx={{ m: 1, minWidth: 120 }}>

                    <InputLabel id="demo-simple-select-standard-label">Atendimento</InputLabel>
                    <Select
                      labelId="demo-simple-select-standard-label"
                      id="demo-simple-select-standard"
                      value={age}
                      onChange={handleChange}
                      label="Age"
                    >
                      <MenuItem value="">

                      </MenuItem>
                      <MenuItem value={10}>Em Atendimento</MenuItem>
                      <MenuItem value={20}>Em Espera</MenuItem>
                      <MenuItem value={30}>Finalizado</MenuItem>
                    </Select>
                  </FormControl>

                  <div><Button style={{ color: 'green' }}>Transferir<TrendingFlatIcon /></Button>
                    <Button style={{ color: 'red' }}>Encerrar<StopIcon /></Button></div>

                </Toolbar>
              </Container>
            </AppBar>
          </Grid>

          <Grid item xs={12} md={12} style={{ padding: 10 }}>
            <h3>{usuario.name}</h3>
          </Grid>
          <Grid item xs={12} md={12} style={{ padding: 10 }}>
            <form onSubmit={onSubmit}>
              <label htmlFor="usuario">Selecione um destinatário:</label>
              <br />
              <Grid item xs={12} md={12} style={{ padding: 10 }}>
                <BasicSelect
                  label={"Lista"}
                  list={connectedUsuarioList}
                  value={receiverUsuario}
                  handleChange={handleChangeReceiverUsuario} />
              </Grid>
              <Grid item xs={12} md={12} style={{ padding: 10 }}>
                <Paper>
                  <MenuList>
                    {connectedUsuarioList && connectedUsuarioList.map(item => <MenuItem onClick={() => handleChangeReceiverUsuario(item.signalrId)}>{item.name}</MenuItem>)}
                  </MenuList>
                </Paper>
              </Grid>
              <br />
              <label htmlFor="message">Mensagem:</label>
              <br />
              <Grid display={'flex'}>
                <Grid item xs={12} md={12} style={{ padding: 10, borderRadius: '30px', backgroundColor: 'purple' }}>
                  <TextField
                    fullWidth

                    id="message"
                    name="message"
                    label="Mensagem"
                    multiline
                    maxRows={8}
                    rows={1}
                    value={chatMessage}
                    onChange={onMessageUpdate}
                    variant="filled"
                  />
                </Grid>
                <Grid item xs={1} md={1} style={{ padding: 10 }}>
                  <Button type="submit">
                    <SendOutlinedIcon style={{ color: 'purple' }} />
                  </Button>
                </Grid>
              </Grid>
            </form>
            <hr />
            <ChatWindow chat={chat} />
          </Grid></Grid>

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