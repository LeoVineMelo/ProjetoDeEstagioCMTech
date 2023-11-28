import * as React from 'react';
import { styled, useTheme } from '@mui/material/styles';
import Box from '@mui/material/Box';
import Drawer from '@mui/material/Drawer';
import CssBaseline from '@mui/material/CssBaseline';
import MuiAppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import List from '@mui/material/List';
import Typography from '@mui/material/Typography';
import Divider from '@mui/material/Divider';
import IconButton from '@mui/material/IconButton';
import MenuIcon from '@mui/icons-material/Menu';
import ChevronLeftIcon from '@mui/icons-material/ChevronLeft';
import ChevronRightIcon from '@mui/icons-material/ChevronRight';
import ListItem from '@mui/material/ListItem';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import "./Navbar.css";
import MailOutlineIcon from '@mui/icons-material/MailOutline';
import NotificationsNoneIcon from '@mui/icons-material/NotificationsNone';
import { Avatar, Grid } from '@mui/material';
import HomeOutlinedIcon from '@mui/icons-material/HomeOutlined';
import ModeCommentOutlinedIcon from '@mui/icons-material/ModeCommentOutlined';
import HistoryToggleOffOutlinedIcon from '@mui/icons-material/HistoryToggleOffOutlined';
import GridViewOutlinedIcon from '@mui/icons-material/GridViewOutlined';
import HeadsetMicRoundedIcon from '@mui/icons-material/HeadsetMicRounded';
import SettingsOutlinedIcon from '@mui/icons-material/SettingsOutlined';
import HelpOutlineOutlinedIcon from '@mui/icons-material/HelpOutlineOutlined';
import { deepPurple } from '@mui/material/colors';
import { useNavigate } from 'react-router-dom'


import SubscriptIcon from '@mui/icons-material/Subscript';
import User from './User';

const drawerWidth = 140;

const Main = styled('main', { shouldForwardProp: (prop) => prop !== 'open' })(
    ({ theme, open }) => ({
        flexGrow: 1,
        padding: theme.spacing(3),
        transition: theme.transitions.create('margin', {
            easing: theme.transitions.easing.sharp,
            duration: theme.transitions.duration.leavingScreen,
        }),
        marginLeft: `-${drawerWidth}px`,
        ...(open && {
            transition: theme.transitions.create('margin', {
                easing: theme.transitions.easing.easeOut,
                duration: theme.transitions.duration.enteringScreen,
            }),
            marginLeft: 0,
        }),
    }),
);

const AppBar = styled(MuiAppBar, {
    shouldForwardProp: (prop) => prop !== 'open',
})(({ theme, open }) => ({
    transition: theme.transitions.create(['margin', 'width'], {
        easing: theme.transitions.easing.sharp,
        duration: theme.transitions.duration.leavingScreen,
    }),
    ...(open && {
        width: `calc(100% - ${drawerWidth}px)`,
        marginLeft: `${drawerWidth}px`,
        transition: theme.transitions.create(['margin', 'width'], {
            easing: theme.transitions.easing.easeOut,
            duration: theme.transitions.duration.enteringScreen,
        }),
    }),
}));

const DrawerHeader = styled('div')(({ theme }) => ({
    display: 'flex',
    alignItems: 'center',
    padding: theme.spacing(0, 1),
    // necessary for content to be below app bar
    ...theme.mixins.toolbar,
    justifyContent: 'flex-end',
}));

export default function PersistentDrawerLeft({ children }) {
    const theme = useTheme();
    const [open, setOpen] = React.useState(false);

    const handleDrawerOpen = () => {
        setOpen(true);
    };

    const handleDrawerClose = () => {
        setOpen(false);
    };

    const navigate = useNavigate()

    const cadperfill = (e) => {
        e.preventDefault()

        navigate('/cadperfill')
    }

    const home = (e) => {
        e.preventDefault()

        navigate('/home')
    }
    const trocarsenha = (e) => {
        e.preventDefault()

        navigate('/trocarsenha')
    }


    const operacoes = (e) => {
        e.preventDefault()

        navigate('/operacoes')
    }
    const cadastros = (e) => {
        e.preventDefault()

        navigate('/cadastros')
    }
    const atendimento = (e) => {
        e.preventDefault()

        navigate('/atendimento')
    }
    const relatendimentos = (e) => {
        e.preventDefault()

        navigate('/relatendimentos')
    }

    return (
        <Box sx={{ display: 'flex', height: '100vh', maxHeight: '100vh', overflowY: 'auto' }}>
            <CssBaseline />
            <AppBar position="fixed" open={open}>
                <Toolbar sx={{ justifyContent: 'space-between', display: 'flex' }} className='Navb'>
                    <IconButton
                        color="inherit"
                        aria-label="open drawer"
                        onClick={handleDrawerOpen}
                        edge="start"
                        sx={{ mr: 2, ...(open && { display: 'none' }) }}
                    >
                        <MenuIcon className='Home' />
                    </IconButton>
                    <Typography className='Home' variant="h6" noWrap component="div">
                        Home
                    </Typography>
                    <Grid className='Barra' justifyContent={'flex-end'} display={'flex'} item xs={11} sm={11} md={11} lg={11} xl={11}>
                        <IconButton className='Mail'>
                            <MailOutlineIcon></MailOutlineIcon>
                        </IconButton>
                        <IconButton className='Noti'>
                            <NotificationsNoneIcon></NotificationsNoneIcon>
                        </IconButton>
                        <Typography className='User'>
                            <strong>
                                <User user={{
                                    FirstName: 'Leonardo',
                                    LastName: 'Melo'
                                }} />
                            </strong>
                        </Typography>
                        <IconButton display={'flex'} className='Avat'>
                            <Avatar sx={{ backgroundColor: deepPurple[500] }}></Avatar>
                        </IconButton>
                    </Grid>
                </Toolbar>
            </AppBar>
            <Drawer
                sx={{
                    width: drawerWidth,
                    flexShrink: 0,
                    '& .MuiDrawer-paper': {
                        width: drawerWidth,
                        boxSizing: 'border-box',
                        backgroundColor: 'blueviolet'
                    }
                }}
                variant="persistent"
                anchor="left"
                open={open}
            >
                <DrawerHeader className='Base'>
                    <IconButton onClick={handleDrawerClose}>
                        {theme.direction === 'ltr' ? <ChevronLeftIcon /> : <ChevronRightIcon />}
                    </IconButton>
                </DrawerHeader>
                <Grid container spacing={0}>
                    <Grid item xs={12} sm={12} md={12} lg={12} xl={12}>
                        <SubscriptIcon sx={{ fontSize: 40, color: 'white' }} />
                    </Grid>
                </Grid>
                <List display={'flex'} className='Draw' sx={{ marginLeft: '10%' }}>
                    <ListItem className='Bottao Navbar-Menu-Item'>
                        <ListItemButton>
                            <ListItemIcon sx={{ color: deepPurple[200], justifyContent: 'center', display: 'flex' }} onClick={home}>
                                <HomeOutlinedIcon sx={{ fontSize: 30 }} />
                            </ListItemIcon>
                            <ListItemText />
                        </ListItemButton>
                    </ListItem>
                    <ListItem className='Bottao Navbar-Menu-Item'>
                        <ListItemButton>
                            <ListItemIcon sx={{ color: deepPurple[200], justifyContent: 'center', display: 'flex' }} onClick={atendimento}>
                                <ModeCommentOutlinedIcon sx={{ fontSize: 30 }} />
                            </ListItemIcon>
                            <ListItemText />
                        </ListItemButton>
                    </ListItem>
                    <ListItem className='Bottao Navbar-Menu-Item'>
                        <ListItemButton>
                            <ListItemIcon sx={{ color: deepPurple[200], justifyContent: 'center', display: 'flex' }} onClick={cadastros}>
                                <HistoryToggleOffOutlinedIcon sx={{ fontSize: 30 }} />
                            </ListItemIcon>
                            <ListItemText />
                        </ListItemButton>
                    </ListItem>
                    <ListItem className='Bottao Navbar-Menu-Item'>
                        <ListItemButton>
                            <ListItemIcon sx={{ color: deepPurple[200], justifyContent: 'center', display: 'flex' }}>
                                <GridViewOutlinedIcon sx={{ fontSize: 30 }} onClick={operacoes} />
                            </ListItemIcon>
                            <ListItemText />
                        </ListItemButton>
                    </ListItem>
                    <ListItem className='Bottao Navbar-Menu-Item'>
                        <ListItemButton>
                            <ListItemIcon sx={{ color: deepPurple[200], justifyContent: 'center', display: 'flex' }}>
                                <HeadsetMicRoundedIcon sx={{ fontSize: 30 }} onClick={relatendimentos} />
                            </ListItemIcon>
                            <ListItemText />
                        </ListItemButton>
                    </ListItem>
                    <ListItem className='Bottao Navbar-Menu-Item'>
                        <ListItemButton>
                            <ListItemIcon sx={{ color: deepPurple[200], justifyContent: 'center', display: 'flex' }}>
                                <SettingsOutlinedIcon sx={{ fontSize: 30 }} onClick={trocarsenha} />
                            </ListItemIcon>
                            <ListItemText />
                        </ListItemButton>
                    </ListItem>
                </List>

                <Divider />
                <List justifyContent={'center'} display={'flex'} className='DrawF' >

                    <ListItem className='Bottao'>
                        <ListItemButton sx={{ justifyContent: 'center', display: 'flex' }} >
                            <ListItemIcon sx={{ color: deepPurple[200] }}>
                                <HelpOutlineOutlinedIcon sx={{ fontSize: 30 }}></HelpOutlineOutlinedIcon>
                            </ListItemIcon>

                        </ListItemButton>
                    </ListItem>

                </List>

            </Drawer>
            <Main open={open}>
                <DrawerHeader />
                <Grid sx={{ paddingTop: 20 }} alignItems={'center'} className='ContM' item xs={11} sm={11} md={11} lg={11} xl={11}>
                    {children}
                </Grid>

            </Main>
        </Box>
    );
}