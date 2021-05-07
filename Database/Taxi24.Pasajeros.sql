--
-- PostgreSQL database dump
--

-- Dumped from database version 12.4 (Debian 12.4-1.pgdg100+1)
-- Dumped by pg_dump version 13.2

-- Started on 2021-05-07 01:09:23 UTC

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 204 (class 1259 OID 16423)
-- Name: Pasajeros; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Pasajeros" (
    "ID" bigint NOT NULL,
    "EmpresaID" bigint NOT NULL,
    "Nombre" text
);


ALTER TABLE public."Pasajeros" OWNER TO postgres;

--
-- TOC entry 203 (class 1259 OID 16421)
-- Name: Pasajeros_ID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."Pasajeros" ALTER COLUMN "ID" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Pasajeros_ID_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 202 (class 1259 OID 16416)
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE public."__EFMigrationsHistory" OWNER TO postgres;

--
-- TOC entry 2914 (class 0 OID 16423)
-- Dependencies: 204
-- Data for Name: Pasajeros; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Pasajeros" ("ID", "EmpresaID", "Nombre") FROM stdin;
1	1	Angel
2	1	Katherine
3	1	Gilby
\.


--
-- TOC entry 2912 (class 0 OID 16416)
-- Dependencies: 202
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
20210506134417_init	5.0.5
\.


--
-- TOC entry 2920 (class 0 OID 0)
-- Dependencies: 203
-- Name: Pasajeros_ID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Pasajeros_ID_seq"', 3, true);


--
-- TOC entry 2785 (class 2606 OID 16430)
-- Name: Pasajeros PK_Pasajeros; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Pasajeros"
    ADD CONSTRAINT "PK_Pasajeros" PRIMARY KEY ("ID");


--
-- TOC entry 2783 (class 2606 OID 16420)
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


-- Completed on 2021-05-07 01:09:23 UTC

--
-- PostgreSQL database dump complete
--
