import { useState } from "react";
import * as contractService from "../services/contractService";

function SearchContract() {

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

    return (
        <div className="page-container">

            <div className="horizontal-form">

                <div className="form-header">
                    <h2>Buscar Contrato</h2>
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
                    <div className="horizontal-form" style={{ marginTop: "30px" }}>

                        <h3>Detalles del Contrato</h3>

                        <p><strong>Número:</strong> {result.contractNumber}</p>
                        <p><strong>Valor Total:</strong> ${result.totalValue?.toLocaleString()} USD</p>
                        <p><strong>Duración:</strong> {result.durationMonths} meses</p>
                        <p><strong>Estado:</strong> {result.status}</p>
                        <p><strong>Fecha de Firma:</strong> {result.signedAt?.replace("T", " ").substring(0, 16)}</p>
                        <p><strong>ID Fabricante:</strong> {result.manufacturerId}</p>
                        <p><strong>Creado:</strong> {result.createdAt?.replace("T", " ").substring(0, 16)}</p>

                    </div>
                )}

            </div>

        </div>
    );
}

export default SearchContract;
