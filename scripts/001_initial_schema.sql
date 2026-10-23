-- =============================================
-- Script: 001_initial_schema.sql
-- Description: Initial database schema
-- =============================================

CREATE DATABASE IF NOT EXISTS agentic_engineer;
USE agentic_engineer;

CREATE TABLE Users (
    Id CHAR(36) NOT NULL PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Email VARCHAR(255) NOT NULL UNIQUE,
    CreatedAt DATETIME NOT NULL,
    UpdatedAt DATETIME NULL
);