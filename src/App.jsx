import React from "react";

import Aleatorio from "./components/basicos/Aleatorio";
import Primeiro from './components/basicos/Primeiro'
import ComParametro from './components/basicos/ComParametro'
import Fragmento from './components/basicos/Fragmento'
import Card from "./components/layout/Card";

export default _ =>

    <div id="app">
        <h1>Fundamentos React (Arrow _)</h1>

        <Card titulo="#04 - Desafio Aleatório">
           <Aleatorio min={1} max={60}/> 

        </Card>

        <Card titulo="#03 - Fragmento">
         <Fragmento></Fragmento>

        </Card>
                <Card titulo="Com Parâmetro">
           <ComParametro
            titulo="#02 - Situação do Aluno"
            aluno="Pedro"
            nota={9.5} />

        </Card>
        <Card titulo="#01 - Pimeiro Componente">
         <Primeiro></Primeiro>

        </Card>

        
        

        

        
    </div> 
