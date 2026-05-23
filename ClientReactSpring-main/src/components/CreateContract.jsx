import { useState } from "react";
import * as contractService from "../services/contractService";

const CONTRACT_STATUSES = ["PENDING", "ACTIVE", "EXPIRED", "CANCELLED"];

function CreateContract() {

    const [form, setForm] = useState({
        contractNumber: "",
        totalValue: "",
        durationMonths: "",
        status: "",
        signedAt: "",
        manufacturerId: ""
    });

    const handleChange = (e) => {
        setForm({ ...form, [e.target.name]: e.target.value });
    };

    const handleSubmit = (e) => {
        e.preventDefault();

        const payload = {
            contractNumber: form.contractNumber,
            totalValue: parseFloat(form.totalValue),
            durationMonths: parseInt(form.durationMonths),
            status: form.status,
            signedAt: form.signedAt ? form.signedAt + ":00" : "",
            manufacturerId: parseInt(form.manufacturerId)
        };

        contractService.create(payload)
            .then(() => {
                alert(`Contrato ${payload.contractNumber} creado exitosamente`);
                setForm({
                    contractNumber: "",
                    totalValue: "",
                    durationMonths: "",
                    status: "",
                    signedAt: "",
                    manufacturerId: ""
                });
            })
            .catch(err => {
                const msg = err.response?.status === 409
                    ? "Ya existe un contrato con ese número"
                    : "Error al crear el contrato";
                alert(msg);
                console.error(err);
            });
    };

    return (
        <div className="page-container">

            <form className="horizontal-form" onSubmit={handleSubmit}>

                <div className="form-header">
                    <h2>Crear Contrato de Suministro</h2>
                </div>

                <div className="horizontal-grid">

                    <div className="form-group">
                        <label>Número de Contrato</label>
                        <input
                            name="contractNumber"
                            placeholder="CNT-2024-001"
                            value={form.contractNumber}
                            onChange={handleChange}
                        />
                    </div>

                    <div className="form-group">
                        <label>Valor Total (USD)</label>
                        <input
                            type="number"
                            step="0.01"
                            name="totalValue"
                            placeholder="150000.50"
                            value={form.totalValue}
                            onChange={handleChange}
                        />
                    </div>

                    <div className="form-group">
                        <label>Duración (meses)</label>
                        <input
                            type="number"
                            name="durationMonths"
                            placeholder="24"
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
                            <option value="">Seleccione</option>
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
                            placeholder="1"
                            value={form.manufacturerId}
                            onChange={handleChange}
                        />
                    </div>

                </div>

                <div className="form-actions">
                    <button type="submit">Crear Contrato</button>
                </div>

            </form>

        </div>
    );
}

export default CreateContract;
