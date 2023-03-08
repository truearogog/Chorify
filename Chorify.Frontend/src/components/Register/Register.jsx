import { useState } from "react";
import axios from "axios";
import "./register.css";

const Register = () => {
  const [registerData, setRegisterData] = useState({
    email: "",
    password: "",
  });

  const [error, setError] = useState("");

  const handleRegisterInput = (e) => {
    setRegisterData((prev) => ({ ...prev, [e.target.name]: e.target.value }));
    console.log(registerData);
  };

  const handleRegisterSubmit = async (e) => {
    try {
      e.preventDefault();
      const emailRegex = /^\S+@\S+\.\S+$/;
      if (!emailRegex.test(registerData.email)) {
        setError("Please enter a valid email address");
        return;
      }
      const { data } = await axios.post(
        "http://localhost:5160/api/Auth/register",
        registerData
      );
      console.log(data);
      if (data.success === true) {
        window.location.href = "/login";
      } else {
        setError("Invalid email or password");
      }
    } catch (error) {
      console.log(error);
    }
  };

  const handleLoginClick = (e) => {
    window.location.href = "/login";
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
            minlength="6"
          />
        </div>
        {error && <div className="errorMessage">{error}</div>}
        <button className="btnRegister" type="submit">
          Register
        </button>
        <br />
        <p>Already have an account?</p>
        <button
          className="btnRegisterNav"
          type="button"
          onClick={handleLoginClick}
        >
          Login
        </button>
      </form>
    </div>
  );
};

export default Register;
