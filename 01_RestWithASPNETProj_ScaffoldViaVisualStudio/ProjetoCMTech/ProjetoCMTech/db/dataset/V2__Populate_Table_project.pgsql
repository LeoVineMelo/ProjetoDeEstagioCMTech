INSERT INTO segmento (nome) VALUES ('Comércio');
INSERT INTO segmento (nome) VALUES ('Tecnologia');
INSERT INTO segmento (nome) VALUES ('Varejo'); 
INSERT INTO grupo (nome) VALUES ('CMTECH');
INSERT INTO status_atendimento (nome) VALUES ('Novo');
INSERT INTO status_atendimento (nome) VALUES ('Em atendimento');
INSERT INTO status_atendimento (nome) VALUES ('Encerrado'); 
INSERT INTO perfil (nome) VALUES ('Administrador');
INSERT INTO perfil (nome) VALUES ('Técnico');
INSERT INTO perfil (nome) VALUES ('Cliente'); 
INSERT INTO usuario (nome,perfil_id,email,senha,data_cadastro) VALUES 
('Administrador', 1, 'suporte@cmtech.com.br', 
'e10adc3949ba59abbe56e057f20f883e','2022-09-20 00:00:00');