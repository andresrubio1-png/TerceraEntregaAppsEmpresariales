-- ============================================================
-- SQL - Microservicio C (SupplyContract) - Tercer Proyecto 2026A
-- Base de datos INDEPENDIENTE del microservicio A-B
-- Ejecutar manualmente en Oracle antes de iniciar la app
-- ============================================================

-- ------------------------------------------------------------
-- (Opcional) Crear el usuario/esquema independiente.
-- Ejecutar este bloque como SYS o SYSTEM en Oracle XE:
-- ------------------------------------------------------------
-- ALTER SESSION SET "_ORACLE_SCRIPT" = TRUE;
-- CREATE USER DAE2026_C IDENTIFIED BY DAE2026_C;
-- GRANT CONNECT, RESOURCE, CREATE SESSION, CREATE TABLE TO DAE2026_C;
-- ALTER USER DAE2026_C QUOTA UNLIMITED ON USERS;


-- ------------------------------------------------------------
-- Tabla SUPPLYCONTRACT
-- La PK es el contractNumber (no autogenerado, lo provee el cliente)
-- manufacturerId es FK LÓGICA (no de DB) hacia el microservicio A-B
-- ------------------------------------------------------------
CREATE TABLE SUPPLYCONTRACT (
    CONTRACT_NUMBER  VARCHAR2(20)   NOT NULL,
    TOTAL_VALUE      NUMBER(12,2)   NOT NULL,
    DURATION_MONTHS  NUMBER         NOT NULL,
    STATUS           VARCHAR2(20)   NOT NULL,
    SIGNED_AT        TIMESTAMP      NOT NULL,
    ID_MANUFACTURER  NUMBER         NOT NULL,
    CREATED_AT       TIMESTAMP      NOT NULL,
    CONSTRAINT PK_SUPPLYCONTRACT       PRIMARY KEY (CONTRACT_NUMBER),
    CONSTRAINT CHK_CONTRACT_NUMBER     CHECK (REGEXP_LIKE(CONTRACT_NUMBER, '^[A-Z0-9-]+$')),
    CONSTRAINT CHK_TOTAL_VALUE         CHECK (TOTAL_VALUE > 0),
    CONSTRAINT CHK_DURATION_MONTHS     CHECK (DURATION_MONTHS > 0 AND DURATION_MONTHS <= 120),
    CONSTRAINT CHK_STATUS              CHECK (STATUS IN ('PENDING','ACTIVE','EXPIRED','CANCELLED')),
    CONSTRAINT CHK_ID_MANUFACTURER     CHECK (ID_MANUFACTURER > 0)
);

-- ------------------------------------------------------------
-- Índice para acelerar la búsqueda por fabricante
-- ------------------------------------------------------------
CREATE INDEX IDX_SUPPLYCONTRACT_MFR ON SUPPLYCONTRACT (ID_MANUFACTURER);
