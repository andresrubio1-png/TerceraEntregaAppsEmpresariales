import {
  BrowserRouter,
  Routes,
  Route,
  Link,
  useLocation
} from "react-router-dom";
import './index.css'
import './App.css'

import PassiveComponentsPage from "./pages/PassiveComponentsPage";
import ManufacturersPage from "./pages/ManufacturersPage";
import SupplyContractPage from "./pages/SupplyContractPage";

function Navigation() {

  const location = useLocation();

  return (

    <header className="topbar">

      <div className="topbar-logo">
        Electronic Manager
      </div>

      <nav className="topbar-nav">

        <Link
          to="/manufacturers"
          className={
            location.pathname === "/manufacturers"
              ? "nav-link active"
              : "nav-link"
          }
        >
          Fabricantes
        </Link>

        <Link
          to="/components"
          className={
            location.pathname === "/components"
              ? "nav-link active"
              : "nav-link"
          }
        >
          Componentes
        </Link>


        <Link
          to="/contracts"
          className={
            location.pathname === "/contracts"
              ? "nav-link active"
              : "nav-link"
          }
        >
          Contrato
        </Link>


      </nav>

    </header>

  );
}

function App() {

  return (

    <BrowserRouter>

      <div className="app-layout">

        <Navigation />

        <Routes>

          <Route
            path="/components"
            element={<PassiveComponentsPage />}
          />

          <Route
            path="/manufacturers"
            element={<ManufacturersPage />}
          />

          <Route
            path="/contracts"
            element={<SupplyContractPage />}
          />


          <Route
            path="*"
            element={<PassiveComponentsPage />}
          />

        </Routes>

      </div>

    </BrowserRouter>

  );
}

export default App;