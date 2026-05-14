import { useEffect, useState } from "react";
import * as passiveService from "../services/passiveService";
import * as manufacturerService from "../services/manufacturerService";

function CreatePassive() {

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

    const [form, setForm] = useState({
        name: "",
        pinCount: "",
        packageType: "",
        voltage: "",
        tolerance: "",
        manufacturerId: "",
        value: "",
        unit: ""
    });

    const [manufacturers, setManufacturers] = useState([]);

    useEffect(() => {
        manufacturerService.getAll()
            .then(res => setManufacturers(res.data))
            .catch(err => console.error(err));
    }, []);

    const handleChange = (e) => {
        setForm({
            ...form,
            [e.target.name]: e.target.value
        });
    };

    const handleSubmit = (e) => {
        e.preventDefault();

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

        passiveService.create(payload)
            .then(() => alert("Componente Creado con ID: "))
            .catch(err => console.error(err));
    };

    return (
        <div className="page-container">

            <form className="horizontal-form" onSubmit={handleSubmit}>

                <div className="form-header">
                    <h2>Crear Componente Electrónico</h2>
                </div>

                <div className="horizontal-grid">

                    <div className="form-group">
                        <label>Nombre</label>
                        <input
                            name="name"
                            placeholder="Resistencia"
                            value={form.name}
                            onChange={handleChange}
                        />
                    </div>

                    <div className="form-group">
                        <label>Pines</label>
                        <input
                            type="number"
                            name="pinCount"
                            placeholder="8"
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
                            <option value="">
                                Seleccione
                            </option>

                            {packageTypes.map(type => (
                                <option key={type} value={type}>
                                    {type}
                                </option>
                            ))}
                        </select>
                    </div>

                    <div className="form-group">
                        <label>Voltaje</label>
                        <input
                            type="number"
                            name="voltage"
                            placeholder="5"
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
                            placeholder="0.05"
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
                            <option value="">
                                Seleccione
                            </option>

                            {manufacturers.map(m => (
                                <option key={m.id} value={m.id}>
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
                            placeholder="10000"
                            value={form.value}
                            onChange={handleChange}
                        />
                    </div>

                    <div className="form-group">
                        <label>Unidad</label>
                        <input
                            name="unit"
                            placeholder="Ω"
                            value={form.unit}
                            onChange={handleChange}
                        />
                    </div>

                </div>

                <div className="form-actions">
                    <button type="submit">
                        Crear Componente
                    </button>
                </div>

            </form>

        </div>
    );
}

export default CreatePassive;