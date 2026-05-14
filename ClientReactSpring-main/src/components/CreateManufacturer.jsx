import { useState } from "react";
import * as manufacturerService from "../services/manufacturerService";

function CreateManufacturer() {

    const [form, setForm] = useState({
        name: "",
        country: "",
        averageLeadTime: ""
    });

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
        country: form.country,
        averageLeadTime: parseFloat(form.averageLeadTime)
    };

    manufacturerService.create(payload)
        .then((res) => {
            console.log("res.data:", res.data);
            alert(`Fabricante creado con ID: ${res.data.id}`);
            setForm({
                name: "",
                country: "",
                averageLeadTime: ""
            });
        })
        .catch(err => {
            alert("Error al crear el fabricante");
            console.error(err);
        });
};

    return (

        <div className="page-container">

            <form
                className="horizontal-form"
                onSubmit={handleSubmit}
            >

                <div className="form-header">
                    <h2>Crear Fabricante</h2>
                </div>

                <div
                    className="horizontal-grid"
                    style={{
                        gridTemplateColumns:
                            "1fr 1fr 260px",
                        alignItems: "end"
                    }}
                >

                    <div className="form-group">

                        <label>Nombre</label>

                        <input
                            type="text"
                            name="name"
                            placeholder="Ej: Texas Instruments"
                            value={form.name}
                            onChange={handleChange}
                        />

                    </div>

                    <div className="form-group">

                        <label>País</label>

                        <input
                            type="text"
                            name="country"
                            placeholder="Ej: Estados Unidos"
                            value={form.country}
                            onChange={handleChange}
                        />

                    </div>

                    <div className="form-group">

                        <label>Lead Time (Días)</label>

                        <input
                            type="number"
                            name="averageLeadTime"
                            placeholder="Ej: 15"
                            value={form.averageLeadTime}
                            onChange={handleChange}
                        />

                    </div>

                </div>

                <div className="form-actions">

                    <button type="submit">
                        Crear Fabricante
                    </button>

                </div>

            </form>

        </div>
    );
}

export default CreateManufacturer;