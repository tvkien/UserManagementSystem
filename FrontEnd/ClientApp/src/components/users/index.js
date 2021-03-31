import React, { useState, useEffect } from "react";
import { Row, Col } from "reactstrap";
import UserInputs from "./userInputs";
import UserTable from "./userTable/userTable";
import { getAllUserAsync } from "../../restApi/userApiClient";

function User({ alertMessage }) {
  const [users, setUsers] = useState([]);

  const reloadUsersData = async () => {
    await populateUsersData();
  };

  const populateUsersData = async () => {
    const result = await getAllUserAsync();

    if (result.succeeded) {
      setUsers(result.data);
    }
  };

  useEffect(() => {
    populateUsersData();
  }, []);

  return (
    <div>
      <Row>
        <Col>
          <h1 style={{ margin: "20px 0" }}>User Management</h1>
        </Col>
      </Row>
      <Row>
        <Col>
          <UserInputs reloadUsersData={reloadUsersData} alertMessage={alertMessage} />
          <UserTable users={users} reloadUsersData={reloadUsersData} alertMessage={alertMessage} />
        </Col>
      </Row>
    </div>
  );
}

export default User;
