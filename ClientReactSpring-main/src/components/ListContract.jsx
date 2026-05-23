import { useEffect, useState } from "react";
import * as contractService from "../services/contractService";

function ListContract() {

    const [data, setData] = useState([]);

    useEffect(() => {
        contractService.getAll()
            .then(res => setData(res.data))
            .catch(err => console.error(err));
    }, []);

    return (
        <div className="page-container">

            <div className="horizontal-form">

                <div className="form-header">
                    <h2>Lista de Contratos</h2>
                </div>

                {data.length === 0 ? (

                    <p>No hay contratos registrados</p>

                ) : (

                    <table>

                        <thead>
                            <tr>
                                <th>Número Contrato</th>
                                <th>Valor Total (USD)</th>
                                <th>Duración (meses)</th>
                                <th>Estado</th>
                                <th>Fecha de Firma</th>
                                <th>ID Fabricante</th>
                                <th>Creado</th>
                            </tr>
                        </thead>

                        <tbody>
                            {data.map(c => (
                                <tr key={c.contractNumber}>
                                    <td>{c.contractNumber}</td>
                                    <td>${c.totalValue?.toLocaleString()}</td>
                                    <td>{c.durationMonths}</td>
                                    <td>
                                        <span style={{
                                            padding: "2px 8px",
                                            borderRadius: "4px",
                                            background: c.status === "ACTIVE" ? "#16a34a22" :
                                                        c.status === "PENDING" ? "#ca8a0422" :
                                                        c.status === "CANCELLED" ? "#dc262622" : "#64748b22",
                                            color: c.status === "ACTIVE" ? "#16a34a" :
                                                   c.status === "PENDING" ? "#ca8a04" :
                                                   c.status === "CANCELLED" ? "#dc2626" : "#64748b"
                                        }}>
                                            {c.status}
                                        </span>
                                    </td>
                                    <td>{c.signedAt?.replace("T", " ").substring(0, 16)}</td>
                                    <td>{c.manufacturerId}</td>
                                    <td>{c.createdAt?.split("T")[0]}</td>
                                </tr>
                            ))}
                        </tbody>

                    </table>

                )}

            </div>

        </div>
    );
}

export default ListContract;
