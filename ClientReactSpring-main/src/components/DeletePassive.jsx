import { useState } from "react";
import * as passiveService from "../services/passiveService";

function DeletePassive() {

    const [mode, setMode] = useState("id");

    const [query, setQuery] = useState("");

    const [results, setResults] = useState([]);

    const handleSearch = () => {

        if (!query) {

            alert("Ingrese un valor");
            return;

        }

        // BUSCAR POR ID
        if (mode === "id") {

            passiveService.getById(query)

                .then(res => {

                    setResults([res.data]);

                })

                .catch(() => {

                    alert("No encontrado");
                    setResults([]);

                });

            return;
        }

        // BUSCAR POR NOMBRE
        passiveService.getByName(query)

            .then(res => {

                setResults(res.data);

            })

            .catch(() => {

                alert("No encontrado");
                setResults([]);

            });
    };

    const handleDelete = (id) => {

        const confirmDelete = window.confirm(
            "¿Seguro que deseas eliminar este componente?"
        );

        if (!confirmDelete) return;

        passiveService.remove(id)

            .then(() => {

                alert("Eliminado correctamente");

                setResults(
                    results.filter(r => r.id !== id)
                );

            })

            .catch(err => console.error(err));
    };

    return (

        <div className="page-container">

            <div className="horizontal-form">

                <div className="form-header">
                    <h2>Eliminar Componente</h2>
                </div>

                {/* MODO DE BUSQUEDA */}

                <div
                    style={{
                        display: "flex",
                        gap: "20px",
                        marginBottom: "20px"
                    }}
                >

                    <label>

                        <input
                            type="radio"
                            checked={mode === "id"}
                            onChange={() => {
                                setMode("id");
                                setQuery("");
                                setResults([]);
                            }}
                        />

                        {" "}
                        Buscar por ID

                    </label>

                    <label>

                        <input
                            type="radio"
                            checked={mode === "name"}
                            onChange={() => {
                                setMode("name");
                                setQuery("");
                                setResults([]);
                            }}
                        />

                        {" "}
                        Buscar por Nombre

                    </label>

                </div>

                {/* BUSQUEDA */}

                <div
                    className="horizontal-grid"
                    style={{
                        gridTemplateColumns: "1fr 180px",
                        alignItems: "end"
                    }}
                >

                    <div className="form-group">

                        <label>
                            {mode === "id"
                                ? "ID del Componente"
                                : "Nombre del Componente"}
                        </label>

                        <input
                            type={mode === "id" ? "number" : "text"}
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

                {/* RESULTADOS */}

                {results.length > 0 && (

                    <table style={{ marginTop: "30px" }}>

                        <thead>

                            <tr>

                                <th>ID</th>
                                <th>Nombre</th>
                                <th>Pines</th>
                                <th>Encapsulado</th>
                                <th>Voltaje</th>
                                <th>Fabricante</th>
                                <th>Acción</th>

                            </tr>

                        </thead>

                        <tbody>

                            {results.map(result => (

                                <tr key={result.id}>

                                    <td>{result.id}</td>

                                    <td>{result.name}</td>

                                    <td>{result.pinCount}</td>

                                    <td>{result.packageType}</td>

                                    <td>{result.voltage}</td>

                                    <td>
                                        {result.manufacturer?.name}
                                    </td>

                                    <td>

                                        <button
                                            onClick={() =>
                                                handleDelete(result.id)
                                            }
                                            style={{
                                                background: "#dc2626"
                                            }}
                                        >
                                            Eliminar
                                        </button>

                                    </td>

                                </tr>

                            ))}

                        </tbody>

                    </table>

                )}

            </div>

        </div>
    );
}

export default DeletePassive;