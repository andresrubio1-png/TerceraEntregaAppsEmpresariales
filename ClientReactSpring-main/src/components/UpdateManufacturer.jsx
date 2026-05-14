import { useState } from "react";
import * as manufacturerService from "../services/manufacturerService";

function UpdateManufacturer() {

    const [id, setId] = useState("");
    const [form, setForm] = useState(null);

    const handleSearch = () => {

        if (!id) {
            alert("Ingrese un ID");
            return;
        }

        manufacturerService.getById(id)
            .then(res => {

                const d = res.data;

                setForm({
                    name: d.name,
                    country: d.country,
                    averageLeadTime: d.averageLeadTime
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
            country: form.country,
            averageLeadTime: parseFloat(
                form.averageLeadTime
            )
        };

        manufacturerService.update(id, payload)
            .then(() =>
                alert("Actualizado correctamente")
            )
            .catch(err => console.error(err));
    };

    return (

        <div className="page-container">

            <div className="horizontal-form">

                <div className="form-header">
                    <h2>Actualizar Fabricante</h2>
                </div>

                {/* BUSQUEDA */}

                <div
                    className="horizontal-grid"
                    style={{
                        gridTemplateColumns:
                            "1fr 180px",
                        alignItems: "end"
                    }}
                >

                    <div className="form-group">

                        <label>ID del Fabricante</label>

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
                                marginTop: "30px",
                                gridTemplateColumns:
                                    "1fr 1fr 260px"
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

                                <label>País</label>

                                <input
                                    name="country"
                                    value={form.country}
                                    onChange={handleChange}
                                />

                            </div>

                            <div className="form-group">

                                <label>
                                    Lead Time (Días)
                                </label>

                                <input
                                    type="number"
                                    name="averageLeadTime"
                                    value={form.averageLeadTime}
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

export default UpdateManufacturer;