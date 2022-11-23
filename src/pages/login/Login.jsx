
import React, { useState, useEffect } from "react";
import basestyle from "../login/Base.module.css";
import loginstyle from "./Login.module.css";
import axios from "axios";
import { useNavigate, NavLink } from "react-router-dom";
import { Label } from "recharts";


function Login() {

  const [username, setUser] = useState(""); 
  const [password, setPassword] = useState(""); 


  const handleUserChange =(value) =>{
    setUser(value);
  };

  const handlePasswordChange =(value) =>{
    setPassword(value);
  };

  const handleLogin = () => {

    const data ={
     UserName : username,
     Password :password
    };
    const url= 'https://localhost:5001/GBSSupport/v1/Login';
    axios.post(url,data).then((response) => { 
     console.log(data);
     console.log(response.data);
     // console.log(response.data.Success);
     if(response.data.Success === true)
     window.location.replace("http://localhost:3001");
     else 
     alert("Incorrect username or password");
     

    })

  }
  return (
    <> <div className={loginstyle.body}>
    <div className={loginstyle.login}>
      <form>
        <h1>Login</h1>
        <div><input type="radio" name="JTP" id="summer" value="summer" />ADMIN
<input type="radio" name="JTP" id="winter" value="winter" />TEAM</div>
        
        <input
          type="text"
          name="email"
          
          placeholder="UserName"
          onChange={ (e) => handleUserChange(e.target.value)}
         
        />
        <p className={basestyle.error}></p>
        <input
          type="password"
          name="password"
         
          placeholder="Password"
          onChange={ (e) => handlePasswordChange(e.target.value)}
          
        />
        
        <button className={basestyle.button_common} onClick={() => handleLogin()} >
          Login
        </button>
      </form>
      {/* <NavLink to="/signup">Not yet registered? Register Now</NavLink> */}
    </div>
    </div>
    </>
  );
};
export default Login;

