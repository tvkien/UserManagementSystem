import React, { useState, useEffect } from "react";
import { Navbar, Dropdown } from "react-bootstrap";
import { getUsernameAsync, logout } from "./restApi/auth.js";

function Header() {
  const [username, setUsername] = useState('');

  useEffect(()=>{
    populateUsername();
  },[])

  const populateUsername = async () => {
    const result = await getUsernameAsync();
    setUsername(result);
  };

  const signOut = async () => {
    await logout();
  }

  return (
    <header className="header">
      <div className="header-menu">
        <Navbar variant="dark">
          <Navbar.Brand>Admin Portal</Navbar.Brand>
          <Navbar.Collapse className="justify-content-end">
            <Navbar.Brand>Hi, {username}</Navbar.Brand>
            <Dropdown>
              <Dropdown.Toggle id="dropdown-basic"></Dropdown.Toggle>

              <Dropdown.Menu>
                <Dropdown.Item onClick={signOut}>Sign out</Dropdown.Item>
              </Dropdown.Menu>
            </Dropdown>
          </Navbar.Collapse>
        </Navbar>
      </div>
    </header>
  );
}

export default Header;