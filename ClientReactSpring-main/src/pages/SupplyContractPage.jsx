import { useState } from "react";

import CreateContract from "../components/CreateContract";
import DeleteContract from "../components/DeleteContract";
import FilterContract from "../components/FilterContract";
import SearchContract from "../components/SearchContract";
import UpdateContract from "../components/UpdateContract";
import ListContract   from "../components/ListContract";

function SupplyContractPage() {
    const [view, setView] = useState("list");

    return (
        <div>
            <h1>Contratos de Suministro</h1>

            <button onClick={() => setView("create")}>Crear</button>
            <button onClick={() => setView("search")}>Buscar</button>
            <button onClick={() => setView("delete")}>Eliminar</button>
            <button onClick={() => setView("update")}>Actualizar</button>
            <button onClick={() => setView("list")}>Listar</button>
            <button onClick={() => setView("filter")}>Filtrar</button>

            <hr />

            {view === "create" && <CreateContract />}
            {view === "search" && <SearchContract />}
            {view === "delete" && <DeleteContract />}
            {view === "update" && <UpdateContract />}
            {view === "list" && <ListContract />}
            {view === "filter" && <FilterContract />}
        </div>
    );
}

export default SupplyContractPage;
