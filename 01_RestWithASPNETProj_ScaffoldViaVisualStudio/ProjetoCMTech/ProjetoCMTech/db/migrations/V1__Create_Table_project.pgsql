CREATE TABLE grupo (
 id SERIAL NOT NULL,
 nome VARCHAR(255) NULL,
 PRIMARY KEY(id)
); 
CREATE TABLE status_atendimento (
 id SERIAL NOT NULL,
 nome VARCHAR(255) NULL,
 PRIMARY KEY(id)
);
CREATE TABLE perfil (
 id SERIAL NOT NULL,
 nome VARCHAR(255) NULL,
 PRIMARY KEY(id)
);
CREATE TABLE organizacao (
 id SERIAL NOT NULL,
 segmento_id INTEGER NOT NULL,
 grupo_id INTEGER NOT NULL,
 nome VARCHAR(255) NULL,
 telefone VARCHAR(255) NULL,
 PRIMARY KEY(id),
 FOREIGN KEY(grupo_id)
 REFERENCES grupo(id)
 ON DELETE NO ACTION
 ON UPDATE NO ACTION,
 FOREIGN KEY(segmento_id)
 REFERENCES segmento(id)
 ON DELETE NO ACTION
 ON UPDATE NO ACTION
); 
CREATE TABLE departamento (
 id SERIAL NOT NULL,
 organizacao_id INTEGER NOT NULL,
 nome VARCHAR(255) NULL,
 PRIMARY KEY(id),
 FOREIGN KEY(organizacao_id)
 REFERENCES organizacao(id)
 ON DELETE NO ACTION
 ON UPDATE NO ACTION
);
CREATE TABLE usuario (
 id SERIAL NOT NULL,
 departamento_id INTEGER NULL,
 organizacao_id INTEGER NULL,
 perfil_id INTEGER NOT NULL,
 nome VARCHAR(255) NULL,
 email VARCHAR(255) NULL,
 senha VARCHAR(255) NULL,
 data_cadastro TIMESTAMP NULL,
 PRIMARY KEY(id),
 FOREIGN KEY(perfil_id)
 REFERENCES perfil(id)
 ON DELETE NO ACTION
 ON UPDATE NO ACTION,
 FOREIGN KEY(organizacao_id)
 REFERENCES organizacao(id)
 ON DELETE NO ACTION
 ON UPDATE NO ACTION,
 FOREIGN KEY(departamento_id)
 REFERENCES departamento(id)
 ON DELETE NO ACTION
 ON UPDATE NO ACTION
);
CREATE TABLE atendimento (
 id SERIAL NOT NULL,
 status_atendimento_id INTEGER NOT NULL,
 departamento_id INTEGER NOT NULL,
 usuario_id INTEGER NOT NULL,
 cliente_id INTEGER NOT NULL,
 organizacao_id INTEGER NOT NULL,
 data_hora_atendimento TIMESTAMP NULL,
 PRIMARY KEY(id),
 FOREIGN KEY(cliente_id)
 REFERENCES usuario(id)
 ON DELETE NO ACTION
 ON UPDATE NO ACTION,
 FOREIGN KEY(organizacao_id)
 REFERENCES organizacao(id)
 ON DELETE NO ACTION
 ON UPDATE NO ACTION,
 FOREIGN KEY(usuario_id)
 REFERENCES usuario(id)
 ON DELETE NO ACTION
 ON UPDATE NO ACTION,
 FOREIGN KEY(departamento_id)
 REFERENCES departamento(id)
 ON DELETE NO ACTION
 ON UPDATE NO ACTION,
 FOREIGN KEY(status_atendimento_id)
 REFERENCES status_atendimento(id)
 ON DELETE NO ACTION
 ON UPDATE NO ACTION
);
CREATE TABLE chat_atendimento (
 id SERIAL NOT NULL,
 atendimento_id INTEGER NOT NULL,
 rementente VARCHAR(255) NULL,
 destinatario VARCHAR(255) NULL,
 data_hora TIMESTAMP NULL,
 mensagem TEXT NULL,
 PRIMARY KEY(id),
 FOREIGN KEY(atendimento_id)
 REFERENCES atendimento(id)
 ON DELETE NO ACTION
 ON UPDATE NO ACTION
);
