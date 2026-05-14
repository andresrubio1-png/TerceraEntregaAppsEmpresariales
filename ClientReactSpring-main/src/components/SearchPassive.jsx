import { useState } from "react";
import * as passiveService from "../services/passiveService";

function SearchPassive() {

    const [mode, setMode] = useState("id");
    const [query, setQuery] = useState("");
    const [result, setResult] = useState(null);

    const handleSearch = () => {

        const service =
            mode === "id"
                ? passiveService.getById(query)
                : passiveService.getByName(query);

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
                    <h2>Buscar Componente Pasivo</h2>
                </div>

                <div
                    className="horizontal-grid"
                    style={{
                        gridTemplateColumns:
                            "220px 1fr 180px",
                        alignItems: "end"
                    }}
                >

                    {/* MODO */}

                    <div className="form-group">

                        <label>Tipo de búsqueda</label>

                        <select
                            value={mode}
                            onChange={(e) =>
                                setMode(e.target.value)
                            }
                        >

                            <option value="id">
                                Por ID
                            </option>

                            <option value="name">
                                Por Nombre
                            </option>

                        </select>

                    </div>

                    {/* INPUT */}

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

                    {/* BOTÓN */}

                    <div className="form-actions">

                        <button onClick={handleSearch}>
                            Buscar
                        </button>

                    </div>

                </div>

                {result && (

                    <>

                        {/* COMPONENTE */}

                        <table style={{ marginTop: "30px" }}>

                            <thead>

                                <tr>

                                    <th>ID</th>

                                    <th>Nombre</th>

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

                        {/* FABRICANTE */}

                        <table style={{ marginTop: "20px" }}>

                            <thead>

                                <tr>

                                    <th>Fabricante</th>

                                    <th>País</th>

                                    <th>Lead Time</th>

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

                                </tr>

                            </tbody>

                        </table>

                    </>

                )}

            </div>

        </div>
    );
}

export default SearchPassive;