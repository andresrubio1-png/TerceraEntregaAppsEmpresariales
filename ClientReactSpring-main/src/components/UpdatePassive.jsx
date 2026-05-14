import { useState, useEffect } from "react";
import * as passiveService from "../services/passiveService";
import * as manufacturerService from "../services/manufacturerService";

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

function UpdatePassive() {

    const [id, setId] = useState("");

    const [form, setForm] = useState(null);

    const [manufacturers, setManufacturers] = useState([]);

    useEffect(() => {

        manufacturerService.getAll()
            .then(res => setManufacturers(res.data))
            .catch(err => console.error(err));

    }, []);

    const handleSearch = () => {

        if (!id) {

            alert("Ingrese un ID");
            return;

        }

        passiveService.getById(id)
            .then(res => {

                const data = res.data;

                setForm({

                    name: data.name,

                    pinCount: data.pinCount,

                    packageType: data.packageType,

                    voltage: data.voltage,

                    tolerance: data.tolerance,

                    manufacturerId: data.manufacturer?.id,

                    value: data.nominalValue?.value,

                    unit: data.nominalValue?.unit

                });

            })
            .catch(() => {

                alert("No encontrado");

                setForm(null);

            });
    };

    const handleChange = (e) => {

        setForm({

            ...form,

            [e.target.name]: e.target.value

        });

    };

    const handleUpdate = () => {

        const payload = {

            name: form.name,

            pinCount: parseInt(form.pinCount),

            packageType: form.packageType,

            voltage: parseFloat(form.voltage),

            tolerance: parseFloat(form.tolerance),

            manufacturerId: parseInt(form.manufacturerId),

            nominalValue: {

                value: parseFloat(form.value),

                unit: form.unit

            }

        };

        passiveService.update(id, payload)
            .then(() =>
                alert("Actualizado correctamente")
            )
            .catch(err => console.error(err));
    };

    return (

        <div className="page-container">

            <div className="horizontal-form">

                <div className="form-header">
                    <h2>Actualizar Componente</h2>
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

                        <label>ID del Componente</label>

                        <input
                            type="number"
                            placeholder="Ingrese ID"
                            value={id}
                            onChange={(e) =>
                                setId(e.target.value)
                            }
                        />

                    </div>

                    <div className="form-actions">

                        <button onClick={handleSearch}>
                            Buscar
                        </button>

                    </div>

                </div>

                {/* FORMULARIO */}

                {form && (

                    <>

                        <div
                            className="horizontal-grid"
                            style={{
                                marginTop: "30px"
                            }}
                        >

                            <div className="form-group">

                                <label>Nombre</label>

                                <input
                                    name="name"
                                    value={form.name}
                                    onChange={handleChange}
                                />

                            </div>

                            <div className="form-group">

                                <label>Pines</label>

                                <input
                                    type="number"
                                    name="pinCount"
                                    value={form.pinCount}
                                    onChange={handleChange}
                                />

                            </div>

                            <div className="form-group">

                                <label>Encapsulado</label>

                                <select
                                    name="packageType"
                                    value={form.packageType}
                                    onChange={handleChange}
                                >

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

                            <div className="form-group">

                                <label>Voltaje</label>

                                <input
                                    type="number"
                                    name="voltage"
                                    value={form.voltage}
                                    onChange={handleChange}
                                />

                            </div>

                            <div className="form-group">

                                <label>Tolerancia</label>

                                <input
                                    type="number"
                                    step="0.01"
                                    name="tolerance"
                                    value={form.tolerance}
                                    onChange={handleChange}
                                />

                            </div>

                            <div className="form-group">

                                <label>Fabricante</label>

                                <select
                                    name="manufacturerId"
                                    value={form.manufacturerId}
                                    onChange={handleChange}
                                >

                                    {manufacturers.map(m => (

                                        <option
                                            key={m.id}
                                            value={m.id}
                                        >
                                            {m.name}
                                        </option>

                                    ))}

                                </select>

                            </div>

                            <div className="form-group">

                                <label>Valor Nominal</label>

                                <input
                                    type="number"
                                    name="value"
                                    value={form.value}
                                    onChange={handleChange}
                                />

                            </div>

                            <div className="form-group">

                                <label>Unidad</label>

                                <input
                                    name="unit"
                                    value={form.unit}
                                    onChange={handleChange}
                                />

                            </div>

                        </div>

                        <div className="form-actions">

                            <button onClick={handleUpdate}>
                                Actualizar
                            </button>

                        </div>

                    </>

                )}

            </div>

        </div>
    );
}

export default UpdatePassive;