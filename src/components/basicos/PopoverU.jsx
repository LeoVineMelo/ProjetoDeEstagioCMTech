import * as React from 'react';
import Popover from '@mui/material/Popover';
import Typography from '@mui/material/Typography';
import Button from '@mui/material/Button';
import { Avatar } from '@mui/material';
import { deepPurple } from '@mui/material/colors';
import { purple } from '@mui/material/colors';
import { styled } from '@mui/material/styles';
import { useNavigate } from 'react-router-dom';
import { Login } from '@mui/icons-material';
import { AuthContext } from '../../context/auth';



const ColorButton = styled(Button)(({ theme }) => ({
  borderRadius: 0,
  marginTop: '0',
  padding: '5px 12px',
  color: theme.palette.getContrastText(purple[700]),
  backgroundColor: purple[800],
  '&:hover': {
    backgroundColor: purple[900],
  },
}));

export default function BasicPopover() {
  const [anchorEl, setAnchorEl] = React.useState(null);
  const { logout } = React.useContext(AuthContext);

  const handleClick = (event) => {
    setAnchorEl(event.currentTarget);
  };

  const handleClose = () => {
    setAnchorEl(null);
  };

  const open = Boolean(anchorEl);
  const id = open ? 'simple-popover' : undefined;

  const navigate = useNavigate()

  const trocarsenha = (e) => {
    e.preventDefault()

    navigate('/trocarsenha')

  }

  const handleLogout = (e) => {
    e.preventDefault()

    logout()
  }

  return (
    <div>
      <Button aria-describedby={id} variant="contained" onClick={handleClick}>
        <Avatar sx={{ backgroundColor: deepPurple[500] }}></Avatar>
      </Button>
      <Popover
        id={id}
        open={open}
        anchorEl={anchorEl}
        onClose={handleClose}
        anchorOrigin={{
          vertical: 'bottom',
          horizontal: 'left',
        }}
      >
        <ColorButton onClick={handleLogout} >
          Deslogar
        </ColorButton>

        <ColorButton onClick={trocarsenha} >
          Trocarsenha
        </ColorButton>

        <ColorButton>
          notificação
        </ColorButton>

      </Popover>
    </div>
  );
}