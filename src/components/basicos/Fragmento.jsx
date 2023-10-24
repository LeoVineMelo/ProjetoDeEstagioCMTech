import * as React from 'react';
import { styled } from '@mui/material/styles';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import IconButton from '@mui/material/IconButton';
import Typography from '@mui/material/Typography';
import MenuIcon from '@mui/icons-material/Menu';
import SearchIcon from '@mui/icons-material/Search';
import MoreIcon from '@mui/icons-material/MoreVert';
import ArrowBackIosIcon from '@mui/icons-material/ArrowBackIos';
import MailOutlineIcon from '@mui/icons-material/MailOutline';
import NotificationsNoneIcon from '@mui/icons-material/NotificationsNone';
import User from './User';
import { Avatar, Grid } from '@mui/material';
import { deepPurple } from '@mui/material/colors';
const StyledToolbar = styled(Toolbar)(({ theme }) => ({
    alignItems: 'flex-start',
    marginTop: theme.spacing(1),
    paddingBottom: theme.spacing(2),
    // Override media queries injected by theme.mixins.toolbar
    '@media all': {
        minHeight: 128,
    },
}));

export default function Fragmento() {
    return (
        <Box sx={{ flexGrow: 1 }}>
            <Grid>
            <AppBar position="static">
                <StyledToolbar>
                    <IconButton
                        size="large"
                        edge="start"
                        color="inherit"
                        aria-label="open drawer"
                        sx={{ mr: 2 }}
                    >
                        <ArrowBackIosIcon />
                    </IconButton>
                    <Typography 
                    display={'flex'}
                    marginTop={10}
                    className='Home'
                        variant="h5"
                        noWrap
                        component="div"
                        sx={{ flexGrow: 1, alignSelf: 'flex-start' }}
                    >
                        MUI
                    </Typography>
                    <IconButton  sx={{marginTop: 5}}>
                        <MailOutlineIcon />
                    </IconButton >
                    <IconButton sx={{ marginTop: 5 }}
                    >
                        <NotificationsNoneIcon />
                    </IconButton>
                    <IconButton className='User' sx={{marginTop: 5}}>
                       <strong> <User/></strong>
                    </IconButton>

                    <IconButton sx={{ marginTop: 5 }}>

                        <Avatar sx={{ backgroundColor: deepPurple[500] }}/>
                    </IconButton>
                </StyledToolbar>
            </AppBar>
            </Grid>
           <Grid>
            
           </Grid>
        </Box>
    );
}