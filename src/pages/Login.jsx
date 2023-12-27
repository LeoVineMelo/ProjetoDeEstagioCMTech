import * as React from 'react';
import { useState } from 'react';

import { styled } from '@mui/material/styles';
import Box from '@mui/material/Box';
import Paper from '@mui/material/Paper';
import Grid from '@mui/material/Grid';
import TextField from '@mui/material/TextField';
import Card from '../components/layout/Card';
import Stack from '@mui/material/Stack';
import Link from '@mui/material/Link';
import Button from '@mui/material/Button';
import { useNavigate } from 'react-router-dom'
import api from '../services/api';
import '../components/basicos/Navbar.css'




const Item = styled(Paper)(({ theme }) => ({
    backgroundColor: theme.palette.mode === 'dark' ? '#1A2027' : '#fff',
    ...theme.typography.body2,
    padding: theme.spacing(1),
    textAlign: 'center',
    color: theme.palette.text.secondary,
}));



export default function Login() {



    async function login(e) {
        e.preventDefault();

        const data = {
            email,
            senha,
        };

        try {
            const response = await api.post('api/Auth/v1/signin', data)
            localStorage.setItem('email', email);
            localStorage.setItem('accessToken', response.data.accessToken);
            navigate('/home')
        } catch (error) {
            console.log(error);
            alert('erro de autenticação! tente novamente');
        }

    }

    const [email, setEmail] = useState('');
    const [senha, setSenha] = useState('');

    const navigate = useNavigate();


    const recuperarsenha = (e) => {
        e.preventDefault()
        navigate('/recuperarsenha')

    }
    return (
        <Box component="form" sx={{ flexGrow: 1 }}>
            <Card style={{ padding: '5% 20%' }}>
                <Grid container justifyContent={'center'} spacing={3}>
                    <Grid className='CorFont' item xs={12} sm={12} md={12} lg={12} xl={12}>
                        <h1><strong>Acesso</strong></h1>
                    </Grid>
                    <form className='format' onSubmit={login}>
                        <Grid padding={2} item xs={12} sm={12} md={12} lg={12} xl={12}>
                            <TextField className='Text'
                                placeholder='Email'
                                value={email}
                                onChange={e => setEmail(e.target.value)}
                                id="outlined-basic"
                                label="Login"
                                variant="outlined"
                            />
                        </Grid>

                        <Grid padding={2} item xs={12} sm={12} md={12} lg={12} xl={12}>
                            <TextField prop className='Text'
                                placeholder='Senha'
                                value={senha}
                                onChange={e => setSenha(e.target.value)}
                                id="outlined-password-input"
                                label="Password"
                                type="password"
                                autoComplete="current-password"
                            />
                        </Grid>

                        <Grid item xs={12} sm={12} md={12} lg={12} xl={12}>
                            <Button className='Botaoo' variant="contained" onClick={login}>Entrar</Button>
                        </Grid>
                    </form>
                    <Grid paddingRight={30} justifyContent={'flex-end'} display={'flex'} item xs={12} sm={12} md={12} lg={12} xl={12}>
                        <Link className='RecSenha'
                            component="button"
                            variant="body2"
                            onClick={recuperarsenha}
                        >
                            Esqueci minha senha
                        </Link>
                    </Grid>
                </Grid>
            </Card>
        </Box>
    );
}