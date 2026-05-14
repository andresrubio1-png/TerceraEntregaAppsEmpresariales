import { useEffect, useState } from "react";
import * as manufacturerService from "../services/manufacturerService";

function ListManufacturer() {

    const [data, setData] = useState([]);

    useEffect(() => {

        manufacturerService.getAll()
            .then(res => setData(res.data))
            .catch(err => console.error(err));

    }, []);

    return (

        <div className="page-container">

            <div className="horizontal-form">

                <div className="form-header">
                    <h2>Lista de Fabricantes</h2>
                </div>

                {data.length === 0 ? (

                    <p>
                        No hay fabricantes registrados
                    </p>

                ) : (

                    <table>

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

                            {data.map(m => (

                                <tr key={m.id}>

                                    <td>{m.id}</td>

                                    <td>{m.name}</td>

                                    <td>{m.country}</td>

                                    <td>
                                        {m.averageLeadTime} días
                                    </td>

                                    <td>
                                        {m.createdAt?.split("T")[0]}
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

export default ListManufacturer;