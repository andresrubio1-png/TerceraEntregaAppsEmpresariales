import { useState } from "react";
import * as passiveService from "../services/passiveService";

function SearchPassive() {

    const [mode, setMode] = useState("id");

    const [query, setQuery] = useState("");

    const [result, setResult] = useState(null);

    const [results, setResults] = useState([]);

    const handleSearch = () => {

        // BUSQUEDA POR ID
        if (mode === "id") {

            passiveService.getById(query)
                .then(res => {

                    setResult(res.data);

                    setResults([]);

                })
                .catch(() => {

                    alert("No encontrado");

                    setResult(null);

                    setResults([]);

                });

            return;
        }

        // BUSQUEDA POR NOMBRE
        passiveService.getByName(query)
            .then(res => {

                setResults(res.data);

                setResult(null);

            })
            .catch(() => {

                alert("No encontrado");

                setResults([]);

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
                        gridTemplateColumns: "140px 140px 1fr 180px",
                        alignItems: "end"
                    }}
                >

                    <div className="form-group">

                        <label>

                            <input
                                type="radio"
                                checked={mode === "id"}
                                onChange={() => setMode("id")}
                            />

                            {" "}Por ID

                        </label>

                    </div>

                    <div className="form-group">

                        <label>

                            <input
                                type="radio"
                                checked={mode === "name"}
                                onChange={() => setMode("name")}
                            />

                            {" "}Por Nombre

                        </label>

                    </div>

                    <div className="form-group">

                        <label>Buscar</label>

                        <input
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

                {/* RESULTADO POR ID */}

                {result && (

                    <div
                        className="horizontal-form"
                        style={{
                            marginTop: "30px"
                        }}
                    >

                        <h3>
                            Detalles del componente
                        </h3>

                        <p><strong>ID:</strong> {result.id}</p>

                        <p><strong>Nombre:</strong> {result.name}</p>

                        <p><strong>Pines:</strong> {result.pinCount}</p>

                        <p><strong>Encapsulado:</strong> {result.packageType}</p>

                        <p><strong>Voltaje:</strong> {result.voltage}</p>

                        <p><strong>Tolerancia:</strong> {result.tolerance}</p>

                        <p>
                            <strong>Valor Nominal:</strong>{" "}
                            {result.nominalValue.value} {result.nominalValue.unit}
                        </p>

                    </div>

                )}

                {/* RESULTADOS POR NOMBRE */}

                {results.length > 0 && (

                    <table style={{ marginTop: "30px" }}>

                        <thead>

                            <tr>

                                <th>ID</th>

                                <th>Nombre</th>

                                <th>Encapsulado</th>

                                <th>Voltaje</th>

                                <th>Fabricante</th>

                            </tr>

                        </thead>

                        <tbody>

                            {results.map(c => (

                                <tr key={c.id}>

                                    <td>{c.id}</td>

                                    <td>{c.name}</td>

                                    <td>{c.packageType}</td>

                                    <td>{c.voltage}V</td>

                                    <td>{c.manufacturer?.name}</td>

                                </tr>

                            ))}

                        </tbody>

                    </table>

                )}

            </div>

        </div>

    );
}

export default SearchPassive;