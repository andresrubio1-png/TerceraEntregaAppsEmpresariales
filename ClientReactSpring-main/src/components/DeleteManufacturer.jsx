import { useState } from "react";
import * as manufacturerService from "../services/manufacturerService";

function DeleteManufacturer() {

    const [id, setId] = useState("");
    const [result, setResult] = useState(null);

    const handleSearch = () => {

        if (!id) {
            alert("Ingrese un ID");
            return;
        }

        manufacturerService.getById(id)
            .then(res => setResult(res.data))
            .catch(() => {
                alert("No encontrado");
                setResult(null);
            });
    };

    const handleDelete = () => {

        if (!window.confirm(
            "¿Seguro que deseas eliminar este fabricante?"
        )) return;

        manufacturerService.remove(id)
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
                    <h2>Eliminar Fabricante</h2>
                </div>

                <div
                    className="horizontal-grid"
                    style={{
                        gridTemplateColumns: "1fr 180px",
                        alignItems: "end"
                    }}
                >

                    <div className="form-group">

                        <label>ID del Fabricante</label>

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

                    <table style={{ marginTop: "30px" }}>

                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>Nombre</th>
                                <th>País</th>
                                <th>Lead Time</th>
                                <th>Acción</th>
                            </tr>
                        </thead>

                        <tbody>

                            <tr>

                                <td>{result.id}</td>

                                <td>{result.name}</td>

                                <td>{result.country}</td>

                                <td>
                                    {result.averageLeadTime} días
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

                )}

            </div>

        </div>
    );
}

export default DeleteManufacturer;