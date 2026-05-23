import { useState } from "react";
import * as contractService from "../services/contractService";

const CONTRACT_STATUSES = ["PENDING", "ACTIVE", "EXPIRED", "CANCELLED"];

function UpdateContract() {

    const [contractNumber, setContractNumber] = useState("");
    const [form, setForm] = useState(null);

    const handleSearch = () => {
        if (!contractNumber.trim()) {
            alert("Ingrese un número de contrato");
            return;
        }

        contractService.getByContractNumber(contractNumber.trim().toUpperCase())
            .then(res => {
                const d = res.data;
                setForm({
                    totalValue: d.totalValue,
                    durationMonths: d.durationMonths,
                    status: d.status,
                    signedAt: d.signedAt?.substring(0, 16),
                    manufacturerId: d.manufacturerId
                });
            })
            .catch(() => {
                alert("Contrato no encontrado");
                setForm(null);
            });
    };

    const handleChange = (e) => {
        setForm({ ...form, [e.target.name]: e.target.value });
    };

    const handleUpdate = () => {
        const payload = {
            contractNumber: contractNumber.trim().toUpperCase(),
            totalValue: parseFloat(form.totalValue),
            durationMonths: parseInt(form.durationMonths),
            status: form.status,
            signedAt: form.signedAt ? form.signedAt + ":00" : "",
            manufacturerId: parseInt(form.manufacturerId)
        };

        contractService.update(contractNumber.trim().toUpperCase(), payload)
            .then(() => alert("Contrato actualizado correctamente"))
            .catch(err => {
                console.error(err);
                alert("Error al actualizar el contrato");
            });
    };

    return (
        <div className="page-container">

            <div className="horizontal-form">

                <div className="form-header">
                    <h2>Actualizar Contrato</h2>
                </div>

                {/* BUSQUEDA */}
                <div
                    className="horizontal-grid"
                    style={{ gridTemplateColumns: "1fr 180px", alignItems: "end" }}
                >

                    <div className="form-group">
                        <label>Número de Contrato</label>
                        <input
                            placeholder="CNT-2024-001"
                            value={contractNumber}
                            onChange={(e) => setContractNumber(e.target.value)}
                        />
                    </div>

                    <div className="form-actions">
                        <button onClick={handleSearch}>Buscar</button>
                    </div>

                </div>

                {/* FORMULARIO */}
                {form && (
                    <>
                        <div className="horizontal-grid" style={{ marginTop: "30px" }}>

                            <div className="form-group">
                                <label>Valor Total (USD)</label>
                                <input
                                    type="number"
                                    step="0.01"
                                    name="totalValue"
                                    value={form.totalValue}
                                    onChange={handleChange}
                                />
                            </div>

                            <div className="form-group">
                                <label>Duración (meses)</label>
                                <input
                                    type="number"
                                    name="durationMonths"
                                    value={form.durationMonths}
                                    onChange={handleChange}
                                />
                            </div>

                            <div className="form-group">
                                <label>Estado</label>
                                <select
                                    name="status"
                                    value={form.status}
                                    onChange={handleChange}
                                >
                                    {CONTRACT_STATUSES.map(s => (
                                        <option key={s} value={s}>{s}</option>
                                    ))}
                                </select>
                            </div>

                            <div className="form-group">
                                <label>Fecha de Firma</label>
                                <input
                                    type="datetime-local"
                                    name="signedAt"
                                    value={form.signedAt}
                                    onChange={handleChange}
                                />
                            </div>

                            <div className="form-group">
                                <label>ID Fabricante</label>
                                <input
                                    type="number"
                                    name="manufacturerId"
                                    value={form.manufacturerId}
                                    onChange={handleChange}
                                />
                            </div>

                        </div>

                        <div className="form-actions">
                            <button onClick={handleUpdate}>Actualizar</button>
                        </div>
                    </>
                )}

            </div>

        </div>
    );
}

export default UpdateContract;
