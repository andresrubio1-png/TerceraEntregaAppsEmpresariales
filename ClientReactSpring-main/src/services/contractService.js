// Comunicacion con el microservicio de Contratos (puerto 8081)

import axios from "axios";

const API_URL = "http://localhost:8081/contracts";

export const getAll = () =>
    axios.get(API_URL);

export const create = (data) =>
    axios.post(API_URL, data);

export const getByContractNumber = (contractNumber) =>
    axios.get(`${API_URL}/${contractNumber}`);

export const update = (contractNumber, data) =>
    axios.put(`${API_URL}/${contractNumber}`, data);

export const remove = (contractNumber) =>
    axios.delete(`${API_URL}/${contractNumber}`);

export const getByManufacturerId = (manufacturerId) =>
    axios.get(API_URL, { params: { manufacturerId } });

export const getByStatus = (status) =>
    axios.get(API_URL, { params: { status } });

export const getByTotalValueRange = (minValue, maxValue) =>
    axios.get(API_URL, { params: { minValue, maxValue } });
