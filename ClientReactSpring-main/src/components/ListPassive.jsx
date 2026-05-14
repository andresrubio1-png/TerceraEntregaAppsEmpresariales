import { useEffect, useState } from "react";
import * as passiveService from "../services/passiveService";

function ListPassive() {

    const [data, setData] = useState([]);

    useEffect(() => {

        passiveService.getAll()
            .then(res => setData(res.data))
            .catch(err => console.error(err));

    }, []);

    return (

        <div className="page-container">

            <div className="horizontal-form">

                <div className="form-header">
                    <h2>Lista de Componentes</h2>
                </div>

                {data.length === 0 ? (

                    <p>
                        No hay componentes registrados
                    </p>

                ) : (

                    <table>

                        <thead>

                            <tr>

                                <th>ID</th>
                                <th>Nombre</th>
                                <th>Pines</th>
                                <th>Encapsulado</th>
                                <th>Voltaje</th>
                                <th>Tolerancia</th>
                                <th>Valor Nominal</th>
                                <th>Fabricante</th>
                                <th>País</th>
                                <th>Fecha</th>

                            </tr>

                        </thead>

                        <tbody>

                            {data.map(c => (

                                <tr key={c.id}>

                                    <td>{c.id}</td>
                                    <td>{c.name}</td>
                                    <td>{c.pinCount}</td>

                                    <td>{c.packageType}</td>

                                    <td>{c.voltage} V</td>

                                    <td>{c.tolerance}</td>

                                    <td>
                                        {c.nominalValue?.value}
                                        {" "}
                                        {c.nominalValue?.unit}
                                    </td>

                                    <td>
                                        {c.manufacturer?.name}
                                    </td>

                                    <td>
                                        {c.manufacturer?.country}
                                    </td>

                                    <td>
                                        {c.createdAt?.split("T")[0]}
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

export default ListPassive;