import Home from "./pages/home/Home";
import LoginForm from "./pages/login/Login";
import List from "./pages/list/List";
import AddAgent from "./components/teams/addagent"
import Single from "./pages/single/Single";
import TeamMembers from "./components/teams/teammembers"
import New from "./pages/new/New";
import Team from "./components/teams/Team"
import Ticketss from "./components/Tickets/Tickets"
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { productInputs, userInputs } from "./formSource";
import "./style/dark.scss";
import { useContext } from "react";
import { DarkModeContext } from "./context/darkModeContext";
import Operations from "./components/Operations/Operations";

function App() {
  const { darkMode } = useContext(DarkModeContext);

  return (
    <div className={darkMode ? "app dark" : "app"}>
      <BrowserRouter>
        <Routes>
          <Route path="/">
            <Route index element={<Home />} />
            <Route path="login" element={<LoginForm />} />
            <Route path="users">
              <Route index element={<List />} />
              <Route path=":userId" element={<Single />} />
              <Route
                path="new"
                element={<New inputs={userInputs} title="Add New User" />}
              />
            </Route>
            <Route path="products">
              <Route index element={<List />} />
              <Route path=":productId" element={<Single />} />
              <Route
                path="new"
                element={<New inputs={productInputs} title="Add New Product" />}
              />

            </Route>
          </Route>
          <Route path="ticketss">
            <Route index element={<Ticketss />} />

          </Route>
          <Route path="teams">
            <Route index element={<Team />} />
            <Route path="addagent" index element={<AddAgent/>}></Route>
            <Route path="teammembers" index element={<TeamMembers/>}></Route>

          </Route>
          <Route>
            <Route path="operationss">
              <Route index element={<Operations />} />

            </Route>
          </Route>

        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
