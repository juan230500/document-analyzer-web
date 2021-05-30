CREATE TABLE Employees (
    Id INT IDENTITY (1, 1) NOT NULL,
    Name VARCHAR(30) NOT NULL,
    PRIMARY KEY (Id),
    UNIQUE (Name)
);

CREATE TABLE Files (
    Id INT IDENTITY (1, 1) NOT NULL,
    Name VARCHAR(30) NOT NULL,
    Container VARCHAR(30) NOT NULL,
    PRIMARY KEY (Id)
);

INSERT INTO Files (Name, Container) VALUES
 ('Arm', 'Noc'),
 ('RISCV', 'Sic');