CREATE DATABASE IF NOT EXISTS agencia_de_viagens;
USE agencia_de_viagens;

CREATE TABLE IF NOT EXISTS usuario (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nome  VARCHAR(100) NOT NULL,
    email VARCHAR(254) NOT NULL UNIQUE,
    senha_hash VARCHAR(255) NOT NULL
);

SELECT * FROM usuario;