import { useState } from "react";
import * as passiveService from "../services/passiveService";

const packageTypes = [
    "SMD",
    "DIP",
    "SIP",
    "QFP",
    "BGA",
    "SOT",
    "TO",
    "AXIAL"
];

function FilterPassive() {

    const [filterMode, setFilterMode] = useState("type");

    const [packageType, setPackageType] = useState("");

    const [minVoltage, setMinVoltage] = useState("");
    const [maxVoltage, setMaxVoltage] = useState("");

    const [data, setData] = useState([]);

    const handleFilter = () => {

        // FILTRO POR TIPO
        if (filterMode === "type") {

            if (!packageType) {
                alert("Seleccione un tipo");
                return;
            }

            passiveService.getByPackageType(packageType)
                .then(res => setData(res.data))
                .catch(err => console.error(err));

            return;
        }

        // FILTRO POR VOLTAJE
        if (filterMode === "voltage") {

            if (!minVoltage || !maxVoltage) {
                alert("Ingrese ambos valores");
                return;
            }

            if (Number(minVoltage) > Number(maxVoltage)) {
                alert("El mínimo no puede ser mayor que el máximo");
                return;
            }

            passiveService.getByVoltageRange(
                minVoltage,
                maxVoltage
            )
                .then(res => setData(res.data))
                .catch(err => console.error(err));
        }
    };

    return (

        <div className="page-container">

            <div className="horizontal-form">

                <div className="form-header">
                    <h2>Filtrar Componentes</h2>
                </div>

                <div
                    className="horizontal-grid"
                    style={{
                        gridTemplateColumns:
                            "220px 1fr 1fr 180px",
                        alignItems: "end"
                    }}
                >

                    {/* MODO */}

                    <div className="form-group">

                        <label>Tipo de Filtro</label>

                        <select
                            value={filterMode}
                            onChange={(e) => {

                                setFilterMode(e.target.value);

                                setPackageType("");

                                setMinVoltage("");
                                setMaxVoltage("");

                                setData([]);

                            }}
                        >

                            <option value="type">
                                Por Tipo
                            </option>

                            <option value="voltage">
                                Por Voltaje
                            </option>

                        </select>

                    </div>

                    {/* FILTRO TIPO */}

                    {filterMode === "type" && (

                        <div className="form-group">

                            <label>Encapsulado</label>

                            <select
                                value={packageType}
                                onChange={(e) =>
                                    setPackageType(
                                        e.target.value
                                    )
                                }
                            >

                                <option value="">
                                    Seleccione tipo
                                </option>

                                {packageTypes.map(p => (
                                    <option
                                        key={p}
                                        value={p}
                                    >
                                        {p}
                                    </option>
                                ))}

                            </select>

                        </div>

                    )}

                    {/* FILTRO VOLTAJE */}

                    {filterMode === "voltage" && (

                        <>

                            <div className="form-group">

                                <label>Voltaje Mínimo</label>

                                <input
                                    type="number"
                                    value={minVoltage}
                                    onChange={(e) =>
                                        setMinVoltage(
                                            e.target.value
                                        )
                                    }
                                    placeholder="Ej: 1"
                                />

                            </div>

                            <div className="form-group">

                                <label>Voltaje Máximo</label>

                                <input
                                    type="number"
                                    value={maxVoltage}
                                    onChange={(e) =>
                                        setMaxVoltage(
                                            e.target.value
                                        )
                                    }
                                    placeholder="Ej: 12"
                                />

                            </div>

                        </>

                    )}

                    {/* BOTÓN */}

                    <div className="form-actions">

                        <button onClick={handleFilter}>
                            Filtrar
                        </button>

                    </div>

                </div>

                {/* RESULTADOS */}

                {data.length > 0 && (

                    <table style={{ marginTop: "30px" }}>

                        <thead>

                            <tr>

                                <th>ID</th>
                                <th>Nombre</th>
                                <th>Tipo</th>

                                <th>Voltaje</th>

                                <th>Pines</th>

                                <th>Fabricante</th>

                            </tr>

                        </thead>

                        <tbody>

                            {data.map(c => (

                                <tr key={c.id}>

                                    <td>{c.id}</td>
                                    <td>{c.name}</td>
                                    <td>
                                        {c.packageType}
                                    </td>

                                    <td>
                                        {c.voltage} V
                                    </td>

                                    <td>
                                        {c.pinCount}
                                    </td>

                                    <td>
                                        {c.manufacturer?.name}
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

export default FilterPassive;