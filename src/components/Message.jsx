import React, { useContext } from 'react';
import { AuthContext } from '../context/auth';

const Message = (props) => {
    
    const { usuario } = useContext(AuthContext)

    if (usuario.name === props.usuario) {
        return (
            <div style={{ display: 'flex', flexDirection: 'column', alignItems: 'flex-end', background: "#76D2F7", borderRadius: '5px', padding: '0 10px', marginBottom: 10 }}>
                <p><strong>{props.usuario}</strong> disse:</p>
                <p>{props.message}</p>
            </div>
        )
    } else {
        return (
            <div style={{ display: 'flex', flexDirection: 'column', background: "#EEE", borderRadius: '5px', padding: '0 10px', marginBottom: 10 }}>
                <p><strong>{props.usuario}</strong> disse:</p>
                <p>{props.message}</p>
            </div>
        )
    }
}

export default Message;