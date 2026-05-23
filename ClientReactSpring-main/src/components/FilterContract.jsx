import { useState } from "react";
import * as contractService from "../services/contractService";

const CONTRACT_STATUSES = ["PENDING", "ACTIVE", "EXPIRED", "CANCELLED"];

function FilterContract() {

    const [filterMode, setFilterMode] = useState("status");
    const [status, setStatus] = useState("");
    const [manufacturerId, setManufacturerId] = useState("");
    const [minValue, setMinValue] = useState("");
    const [maxValue, setMaxValue] = useState("");
    const [data, setData] = useState([]);

    const handleFilter = () => {

        if (filterMode === "status") {
            if (!status) {
                alert("Seleccione un estado");
                return;
            }
            contractService.getByStatus(status)
                .then(res => setData(res.data))
                .catch(err => console.error(err));

        } else if (filterMode === "manufacturer") {
            if (!manufacturerId) {
                alert("Ingrese un ID de fabricante");
                return;
            }
            contractService.getByManufacturerId(parseInt(manufacturerId))
                .then(res => setData(res.data))
                .catch(err => console.error(err));

        } else if (filterMode === "value") {
            if (!minValue || !maxValue) {
                alert("Ingrese ambos valores");
                return;
            }
            if (Number(minValue) > Number(maxValue)) {
                alert("El mínimo no puede ser mayor que el máximo");
                return;
            }
            contractService.getByTotalValueRange(parseFloat(minValue), parseFloat(maxValue))
                .then(res => setData(res.data))
                .catch(err => console.error(err));
        }
    };

    const resetFilters = () => {
        setStatus("");
        setManufacturerId("");
        setMinValue("");
        setMaxValue("");
        setData([]);
    };

    return (
        <div className="page-container">

            <div className="horizontal-form">

                <div className="form-header">
                    <h2>Filtrar Contratos</h2>
                </div>

                <div
                    className="horizontal-grid"
                    style={{ gridTemplateColumns: "220px 1fr 1fr 180px", alignItems: "end" }}
                >

                    {/* MODO */}
                    <div className="form-group">
                        <label>Tipo de Filtro</label>
                        <select
                            value={filterMode}
                            onChange={(e) => {
                                setFilterMode(e.target.value);
                                resetFilters();
                            }}
                        >
                            <option value="status">Por Estado</option>
                            <option value="manufacturer">Por Fabricante</option>
                            <option value="value">Por Valor Total</option>
                        </select>
                    </div>

                    {/* FILTRO ESTADO */}
                    {filterMode === "status" && (
                        <div className="form-group">
                            <label>Estado</label>
                            <select
                                value={status}
                                onChange={(e) => setStatus(e.target.value)}
                            >
                                <option value="">Seleccione</option>
                                {CONTRACT_STATUSES.map(s => (
                                    <option key={s} value={s}>{s}</option>
                                ))}
                            </select>
                        </div>
                    )}

                    {/* FILTRO FABRICANTE */}
                    {filterMode === "manufacturer" && (
                        <div className="form-group">
                            <label>ID del Fabricante</label>
                            <input
                                type="number"
                                placeholder="Ej: 1"
                                value={manufacturerId}
                                onChange={(e) => setManufacturerId(e.target.value)}
                            />
                        </div>
                    )}

                    {/* FILTRO VALOR */}
                    {filterMode === "value" && (
                        <>
                            <div className="form-group">
                                <label>Valor Mínimo (USD)</label>
                                <input
                                    type="number"
                                    placeholder="Ej: 1000"
                                    value={minValue}
                                    onChange={(e) => setMinValue(e.target.value)}
                                />
                            </div>
                            <div className="form-group">
                                <label>Valor Máximo (USD)</label>
                                <input
                                    type="number"
                                    placeholder="Ej: 500000"
                                    value={maxValue}
                                    onChange={(e) => setMaxValue(e.target.value)}
                                />
                            </div>
                        </>
                    )}

                    <div className="form-actions">
                        <button onClick={handleFilter}>Filtrar</button>
                    </div>

                </div>

                {/* RESULTADOS */}
                {data.length > 0 && (
                    <table style={{ marginTop: "30px" }}>

                        <thead>
                            <tr>
                                <th>Número Contrato</th>
                                <th>Valor Total (USD)</th>
                                <th>Duración</th>
                                <th>Estado</th>
                                <th>Fecha de Firma</th>
                                <th>ID Fabricante</th>
                            </tr>
                        </thead>

                        <tbody>
                            {data.map(c => (
                                <tr key={c.contractNumber}>
                                    <td>{c.contractNumber}</td>
                                    <td>${c.totalValue?.toLocaleString()}</td>
                                    <td>{c.durationMonths} meses</td>
                                    <td>{c.status}</td>
                                    <td>{c.signedAt?.replace("T", " ").substring(0, 16)}</td>
                                    <td>{c.manufacturerId}</td>
                                </tr>
                            ))}
                        </tbody>

                    </table>
                )}

                {data.length === 0 && (
                    <p style={{ marginTop: "20px", color: "#64748b" }}>
                        Aplique un filtro para ver resultados
                    </p>
                )}

            </div>

        </div>
    );
}

export default FilterContract;
