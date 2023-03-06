import { useState } from "react";
import axios from "axios";
import "./register.css";

const Register = () => {
  const [registerData, setRegisterData] = useState({
    email: "",
    password: "",
  });

  const handleRegisterInput = (e) => {
    setRegisterData((prev) => ({ ...prev, [e.target.name]: e.target.value }));
    console.log(registerData);
  };

  const handleRegisterSubmit = async (e) => {
    try {
      e.preventDefault();
      await axios.post("http://localhost:5160/api/Auth/register", JSON.stringify(registerData));
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <div>
      <form onSubmit={handleRegisterSubmit}>
        <div className="formItem">
          <label>E-mail</label>
          <input
            className="registerInput"
            onChange={handleRegisterInput}
            type="email"
            name="email"
          />
        </div>
        <div className="formItem">
          <label>Password</label>
          <input
            className="registerInput"
            onChange={handleRegisterInput}
            type="password"
            name="password"
          />
        </div>
        <button
          className="btnRegister" type="submit">
          Register
        </button>
      </form>
    </div>
  );
};

export default Register;
