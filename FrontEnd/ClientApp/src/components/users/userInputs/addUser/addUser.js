import React, { useState } from "react";
import Button from "react-bootstrap/Button";

import AddUserModal from "./addUserModal";

function AddUser(props) {
  const [show, setShow] = useState(false);

  const close = () => {
    setShow(false);
  }

  const open = () => {
    setShow(true);
  }

  return (
    <>
      <Button variant="primary" onClick={open}>
        Add new user
      </Button>
      <AddUserModal
        show={show}
        close={close}
        reloadUsersData={props.reloadUsersData}
        alertMessage={props.alertMessage}
      />
    </>
  );
}

export default AddUser;