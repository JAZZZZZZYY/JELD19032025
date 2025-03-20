
CREATE DATABASE Test20250319DB;
GO

USE Test20250319DB;
GO

-- Tabla Categories (Tabla Categorías)
CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY IDENTITY(1,1), -- ID de categoría (ID de categoría)
    CategoryName VARCHAR(255) NOT NULL,    -- Nombre de la categoría (Nombre de la categoría)
    Description TEXT                       -- Descripción de la categoría (Descripción de la categoría)
);
GO

-- Tabla Brands (Tabla Marcas)
CREATE TABLE Brands (
    BrandID INT PRIMARY KEY IDENTITY(1,1),    -- ID de la marca (ID de la marca)
    BrandName VARCHAR(255) NOT NULL,       -- Nombre de la marca (Nombre de la marca)
    Country VARCHAR(255)                   -- País de origen de la marca (País de origen de la marca)
);
GO

-- Tabla Products (Tabla Productos)
CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),  -- ID del producto (ID del producto)
    ProductName VARCHAR(255) NOT NULL,      -- Nombre del producto (Nombre del producto)
    Description TEXT,                       -- Descripción del producto (Descripción del producto)
    Price DECIMAL(10, 2) NOT NULL,          -- Precio del producto (Precio del producto)
    CategoryID INT FOREIGN KEY REFERENCES Categories(CategoryID), -- ID de la categoría (ID de la categoría)
    BrandID INT FOREIGN KEY REFERENCES Brands(BrandID)             -- ID de la marca (ID de la marca)
);
GO

-- Tabla Users (Tabla Usuarios)
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),     -- ID del usuario (ID del usuario)
    Username VARCHAR(255) NOT NULL,         -- Nombre de usuario (Nombre de usuario)
    Email VARCHAR(255) UNIQUE NOT NULL,     -- Correo electrónico del usuario (Correo electrónico del usuario)
    PasswordHash CHAR(32) NOT NULL,     -- Hash de la contraseña del usuario (Hash de la contraseña del usuario)
    Role VARCHAR(50) NOT NULL                -- Rol del usuario (Rol del usuario)

);
GO