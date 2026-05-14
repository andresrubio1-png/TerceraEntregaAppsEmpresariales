import { useState } from "react";
import * as manufacturerService from "../services/manufacturerService";

function SearchManufacturer() {

    const [mode, setMode] = useState("id");
    const [query, setQuery] = useState("");
    const [result, setResult] = useState(null);

    const handleSearch = () => {

        const service =
            mode === "id"
                ? manufacturerService.getById(query)
                : manufacturerService.getByName(query);

        service
            .then(res => setResult(res.data))
            .catch(() => {
                alert("No encontrado");
                setResult(null);
            });
    };

    return (

        <div className="page-container">

            <div className="horizontal-form">

                <div className="form-header">
                    <h2>Buscar Fabricante</h2>
                </div>

                <div
                    className="horizontal-grid"
                    style={{
                        gridTemplateColumns: "220px 1fr 180px",
                        alignItems: "end"
                    }}
                >

                    <div className="form-group">

                        <label>Tipo de búsqueda</label>

                        <select
                            value={mode}
                            onChange={(e) => setMode(e.target.value)}
                        >
                            <option value="id">
                                Por ID
                            </option>

                            <option value="name">
                                Por Nombre
                            </option>

                        </select>

                    </div>

                    <div className="form-group">

                        <label>
                            {mode === "id"
                                ? "ID"
                                : "Nombre"}
                        </label>

                        <input
                            type={
                                mode === "id"
                                    ? "number"
                                    : "text"
                            }
                            placeholder={
                                mode === "id"
                                    ? "Ingrese ID"
                                    : "Ingrese nombre"
                            }
                            value={query}
                            onChange={(e) =>
                                setQuery(e.target.value)
                            }
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
                                <th>Fecha</th>
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
                                    {result.createdAt?.split("T")[0]}
                                </td>
                            </tr>
                        </tbody>

                    </table>

                )}

            </div>

        </div>
    );
}

export default SearchManufacturer;