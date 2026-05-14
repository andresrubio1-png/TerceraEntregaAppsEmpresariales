import { useState } from "react";
import * as passiveService from "../services/passiveService";

function DeletePassive() {

    const [id, setId] = useState("");
    const [result, setResult] = useState(null);

    const handleSearch = () => {

        if (!id) {
            alert("Ingrese un ID");
            return;
        }

        passiveService.getById(id)
            .then(res => setResult(res.data))
            .catch(() => {
                alert("No encontrado");
                setResult(null);
            });
    };

    const handleDelete = () => {

        const confirmDelete = window.confirm(
            "¿Seguro que deseas eliminar este componente?"
        );

        if (!confirmDelete) return;

        passiveService.remove(id)
            .then(() => {

                alert("Eliminado correctamente");

                setResult(null);
                setId("");

            })
            .catch(err => console.error(err));
    };

    return (

        <div className="page-container">

            <div className="horizontal-form">

                <div className="form-header">
                    <h2>Eliminar Componente</h2>
                </div>

                <div
                    className="horizontal-grid"
                    style={{
                        gridTemplateColumns: "1fr 180px",
                        alignItems: "end"
                    }}
                >

                    <div className="form-group">

                        <label>ID del Componente</label>

                        <input
                            type="number"
                            placeholder="Ingrese ID"
                            value={id}
                            onChange={(e) => setId(e.target.value)}
                        />

                    </div>

                    <div className="form-actions">

                        <button onClick={handleSearch}>
                            Buscar
                        </button>

                    </div>

                </div>

                {result && (

                    <>

                        <table style={{ marginTop: "30px" }}>

                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>Nombre </th>
                                    <th>Pines</th>
                                    <th>Encapsulado</th>
                                    <th>Voltaje</th>
                                    <th>Tolerancia</th>
                                    <th>Valor Nominal</th>
                                    <th>Fecha</th>
                                </tr>
                            </thead>

                            <tbody>

                                <tr>

                                    <td>{result.id}</td>
                                    <td>{result.name}</td>
                                    <td>{result.pinCount}</td>

                                    <td>{result.packageType}</td>

                                    <td>{result.voltage}</td>

                                    <td>{result.tolerance}</td>

                                    <td>
                                        {result.nominalValue?.value}
                                        {" "}
                                        {result.nominalValue?.unit}
                                    </td>

                                    <td>
                                        {result.createdAt?.split("T")[0]}
                                    </td>

                                </tr>

                            </tbody>

                        </table>

                        <table style={{ marginTop: "20px" }}>

                            <thead>
                                <tr>
                                    <th>Fabricante</th>
                                    <th>País</th>
                                    <th>Lead Time</th>
                                    <th>Acción</th>
                                </tr>
                            </thead>

                            <tbody>

                                <tr>

                                    <td>
                                        {result.manufacturer?.name}
                                    </td>

                                    <td>
                                        {result.manufacturer?.country}
                                    </td>

                                    <td>
                                        {result.manufacturer?.averageLeadTime}
                                    </td>

                                    <td>

                                        <button
                                            onClick={handleDelete}
                                            style={{
                                                background: "#dc2626"
                                            }}
                                        >
                                            Eliminar
                                        </button>

                                    </td>

                                </tr>

                            </tbody>

                        </table>

                    </>

                )}

            </div>

        </div>
    );
}

export default DeletePassive;