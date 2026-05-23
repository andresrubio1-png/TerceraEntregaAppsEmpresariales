-- ============================================================
-- 1. Secuencia para NOMINAL_VALUE
-- ============================================================
CREATE SEQUENCE SEQ_NOMINALVALUE
    START WITH 1
    INCREMENT BY 1
    NOCACHE
    NOCYCLE;

-- ============================================================
-- 2. Nueva tabla de valores nominales
-- ============================================================
CREATE TABLE NOMINAL_VALUE (
    ID      NUMBER       NOT NULL,
    VALUE   NUMBER       NOT NULL,
    UNIT    VARCHAR2(20),
    CONSTRAINT PK_NVID          PRIMARY KEY (ID),
    CONSTRAINT CHK_NV_VALUE     CHECK (VALUE > 0),
    CONSTRAINT UQ_NV_VALUE_UNIT UNIQUE (VALUE, UNIT)
);

-- ============================================================
-- 3. Migrar datos existentes (ejecutar si ya hay filas en ELECTRONICCOMPONENT)
-- ============================================================
INSERT INTO NOMINAL_VALUE (ID, VALUE, UNIT)
SELECT SEQ_NOMINALVALUE.NEXTVAL, NOMINAL_VALUE, NOMINAL_UNIT
FROM (
    SELECT DISTINCT NOMINAL_VALUE, NOMINAL_UNIT
    FROM ELECTRONICCOMPONENT
);

-- ============================================================
-- 4. Agregar columna FK en ELECTRONICCOMPONENT (nullable temporalmente)
-- ============================================================
ALTER TABLE ELECTRONICCOMPONENT ADD ID_NOMINAL_VALUE NUMBER;

-- ============================================================
-- 5. Poblar la FK con los IDs recién creados
-- ============================================================
UPDATE ELECTRONICCOMPONENT ec
SET ID_NOMINAL_VALUE = (
    SELECT nv.ID
    FROM NOMINAL_VALUE nv
    WHERE nv.VALUE = ec.NOMINAL_VALUE
      AND (nv.UNIT = ec.NOMINAL_UNIT OR (nv.UNIT IS NULL AND ec.NOMINAL_UNIT IS NULL))
);

-- ============================================================
-- 6. Hacer la columna NOT NULL y agregar FK constraint
-- ============================================================
ALTER TABLE ELECTRONICCOMPONENT MODIFY ID_NOMINAL_VALUE NUMBER NOT NULL;

ALTER TABLE ELECTRONICCOMPONENT
    ADD CONSTRAINT FK_NOMINALVALUE
    FOREIGN KEY (ID_NOMINAL_VALUE) REFERENCES NOMINAL_VALUE(ID);

-- ============================================================
-- 7. Eliminar constraint y columnas antiguas
-- ============================================================
ALTER TABLE ELECTRONICCOMPONENT DROP CONSTRAINT CHK_NOMINALVALUE;
ALTER TABLE ELECTRONICCOMPONENT DROP COLUMN NOMINAL_VALUE;
ALTER TABLE ELECTRONICCOMPONENT DROP COLUMN NOMINAL_UNIT;


ALTER SESSION SET "_ORACLE_SCRIPT" = TRUE;
CREATE USER DAE2026_C IDENTIFIED BY DAE2026_C;
GRANT CONNECT, RESOURCE, CREATE SESSION, CREATE TABLE TO DAE2026_C;
ALTER USER DAE2026_C QUOTA UNLIMITED ON USERS;

DROP TABLE SUPPLYCONTRACT

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

CREATE INDEX IDX_SUPPLYCONTRACT_MFR ON SUPPLYCONTRACT (ID_MANUFACTURER);


SELECT * FROM SUPPLYCONTRACT





