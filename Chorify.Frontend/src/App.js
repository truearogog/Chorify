import "./App.css";
import React from "react";
import Register from "./components/Register/Register";
import Login from "./components/Login/Login";
import MainPage from "./pages/mainPage/MainPage";

import {
  BrowserRouter as Router,
  Route,
  Routes,
  Navigate,
} from "react-router-dom";

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/register" element={<Register />} />
        <Route path="/login" element={<Login />} />
        <Route path="/" element={<MainPage />} />
      </Routes>
    </Router>
  );
}

export default App;
