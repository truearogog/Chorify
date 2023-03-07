// import "./App.css";
// import React from "react";
// import Register from "./components/Register/Register";
// import Login from "./components/Login/Login";
// import MainPage from "./pages/mainPage/MainPage";

// import {
//   BrowserRouter as Router,
//   Route,
//   Routes,
//   Navigate
// } from "react-router-dom";

// function App() {

//   const [credentials, setCredentials] = useState([]);

//   useEffect(() => {
//     const fetchItems = async () => {
//       try {
//         const { data } = await axios.get(
//           "http://localhost:5160/api/Auth/user",
//           { withCredentials: true }
//         );
//         setCredentials(data);
//       } catch (error) {
//         console.error(error);
//       }
//     };

//     fetchItems();
//   }, []);

//   return (
//     <Router>
//       <Routes>
//         <Route path="/register" element={<Register />} />
//         <Route path="/login" element={<Login />} />
//         <Route path="/" element={<MainPage />} />
//       </Routes>
//     </Router>
//   );
// }

// export default App;

import "./App.css";
import React, { useState, useEffect } from "react";
import Register from "./components/Register/Register";
import Login from "./components/Login/Login";
import MainPage from "./pages/mainPage/MainPage";

import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import axios from "axios";

function App() {
  const [credentials, setCredentials] = useState([]);

  useEffect(() => {
    const fetchItems = async () => {
      try {
        const { data } = await axios.get(
          "http://localhost:5160/api/Auth/user",
          { withCredentials: true }
        );
        setCredentials(data);
      } catch (error) {
        console.error(error);
      }
    };

    fetchItems();
  }, []);

  if (credentials.success == true) {
    return (
      <Router>
        <Routes>
          <Route path="/" element={<MainPage />} />
        </Routes>
      </Router>
    );
  } else {
    return (
      <Router>
        <Routes>
          <Route path="/register" element={<Register />} />
          <Route path="/login" element={<Login />} />
          <Route path="/" element={<Login />} />
        </Routes>
      </Router>
    );
  }
}

export default App;
