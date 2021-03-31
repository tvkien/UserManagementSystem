import React, { useState } from "react";
import Button from "react-bootstrap/Button";

import EditUserModal from "./editUserModal";

function EditUser(props) {
  const [show, setShow] = useState(false);

  const close = () => {
    setShow(false);
  };

  const open = () => {
    setShow(true);
  };

  return (
    <>
      <Button variant="warning" onClick={open}>
        Edit
      </Button>
      <EditUserModal
        show={show}
        close={close}
        user={props.user}
        alertMessage={props.alertMessage}
        reloadUsersData={props.reloadUsersData}
      />
    </>
  );
}

export default EditUser;