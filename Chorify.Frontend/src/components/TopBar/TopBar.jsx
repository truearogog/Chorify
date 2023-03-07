import { useState, useEffect } from "react";
import axios from "axios";
import "./topBar.css";

const TopBar = () => {
  const [credentials, setCredentials] = useState([]);

  useEffect(() => {
    const fetchItems = async () => {
      try {
        const { data } = await axios.get(
          "http://localhost:5160/api/Auth/user",
          { withCredentials: true }
        );
        setCredentials(data);
        console.log(credentials);
      } catch (error) {
        console.error(error);
      }
    };

    fetchItems();
  }, []);

  const handleLogOut = async () => {
    try {
      await axios.post("http://localhost:5160/api/Auth/logout", {
        withCredentials: true,
      });
      window.location.href = '/login';
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <div className="top-bar">
      <div className="website-name">Chorify</div>
      <div className="email-container">
        <div className="email">{credentials.data?.email}</div>
        <button className="logout-button" onClick={handleLogOut}>
          Log Out
        </button>
      </div>
    </div>
  );
};

export default TopBar;
