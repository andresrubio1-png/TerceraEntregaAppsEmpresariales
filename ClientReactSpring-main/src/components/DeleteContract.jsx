import { useState } from "react";
import * as contractService from "../services/contractService";

function DeleteContract() {

    const [query, setQuery] = useState("");
    const [result, setResult] = useState(null);

    const handleSearch = () => {
        if (!query.trim()) {
            alert("Ingrese un número de contrato");
            return;
        }

        contractService.getByContractNumber(query.trim().toUpperCase())
            .then(res => setResult(res.data))
            .catch(() => {
                alert("Contrato no encontrado");
                setResult(null);
            });
    };

    const handleDelete = (contractNumber) => {
        const confirmed = window.confirm(
            `¿Seguro que deseas eliminar el contrato ${contractNumber}?`
        );
        if (!confirmed) return;

        contractService.remove(contractNumber)
            .then(() => {
                alert("Contrato eliminado correctamente");
                setResult(null);
                setQuery("");
            })
            .catch(err => {
                console.error(err);
                alert("Error al eliminar el contrato");
            });
    };

    return (
        <div className="page-container">

            <div className="horizontal-form">

                <div className="form-header">
                    <h2>Eliminar Contrato</h2>
                </div>

                <div
                    className="horizontal-grid"
                    style={{ gridTemplateColumns: "1fr 180px", alignItems: "end" }}
                >

                    <div className="form-group">
                        <label>Número de Contrato</label>
                        <input
                            placeholder="CNT-2024-001"
                            value={query}
                            onChange={(e) => setQuery(e.target.value)}
                            onKeyDown={(e) => e.key === "Enter" && handleSearch()}
                        />
                    </div>

                    <div className="form-actions">
                        <button onClick={handleSearch}>Buscar</button>
                    </div>

                </div>

                {result && (
                    <table style={{ marginTop: "30px" }}>

                        <thead>
                            <tr>
                                <th>Número Contrato</th>
                                <th>Valor Total</th>
                                <th>Duración</th>
                                <th>Estado</th>
                                <th>ID Fabricante</th>
                                <th>Acción</th>
                            </tr>
                        </thead>

                        <tbody>
                            <tr>
                                <td>{result.contractNumber}</td>
                                <td>${result.totalValue?.toLocaleString()} USD</td>
                                <td>{result.durationMonths} meses</td>
                                <td>{result.status}</td>
                                <td>{result.manufacturerId}</td>
                                <td>
                                    <button
                                        onClick={() => handleDelete(result.contractNumber)}
                                        style={{ background: "#dc2626" }}
                                    >
                                        Eliminar
                                    </button>
                                </td>
                            </tr>
                        </tbody>

                    </table>
                )}

            </div>

        </div>
    );
}

export default DeleteContract;
