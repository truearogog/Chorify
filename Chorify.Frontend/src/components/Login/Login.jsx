import axios from "axios";
import { useState } from "react";
import "../Register/register.css";

const Login = () => {
  const [loginData, setLoginData] = useState({
    email: "",
    password: "",
  });

  const handleLoginInput = (e) => {
    setLoginData((prev) => ({ ...prev, [e.target.name]: e.target.value }));
  };

  const handleSubmit = async (e) => {
    try {
        e.preventDefault();
      const { data } = await axios.post("http://localhost:5160/api/Auth/login", loginData, {
          withCredentials: true
        });
        console.log(data);
      if (data.success == true) {
        window.location.href = "/";
      }
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <div>
      <form onSubmit={handleSubmit}>
        <div className="formItem">
          <label>E-mail</label>
          <input
            className="loginInput"
            onChange={handleLoginInput}
            type="email"
            name="email"
          />
        </div>
        <div className="formItem">
          <label>Password</label>
          <input
            className="loginInput"
            onChange={handleLoginInput}
            type="password"
            name="password"
          />
        </div>
        <button className="btnRegister" type="submit">
          Login
        </button>
      </form>
    </div>
  );
};

export default Login;
