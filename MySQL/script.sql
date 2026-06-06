CREATE DATABASE IF NOT EXISTS agencia_de_viagens;
USE agencia_de_viagens;

CREATE TABLE IF NOT EXISTS usuario (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nome  VARCHAR(100) NOT NULL,
    email VARCHAR(254) NOT NULL UNIQUE,
    senha_hash VARCHAR(255) NOT NULL,
    nivel_acesso VARCHAR(50) NOT NULL
);

INSERT INTO usuario (nome, email, senha_hash, nivel_acesso)
VALUES
(
    'Administrador',
    'admin@admin.com',
    '$2a$11$b3cdy/LEgzdZxpfjbpM62OmhAUwPUokOdoedRngAR4ohe0c761u4K', -- admin123
    'Administrador'
);

SELECT * FROM usuario;