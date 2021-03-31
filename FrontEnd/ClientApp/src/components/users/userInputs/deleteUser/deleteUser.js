import React, { useState } from "react";
import { Button, Modal, Spinner } from "react-bootstrap";
import { deleteUserAsync } from "../../../../restApi/userApiClient";

function DeleteUser({ user, alertMessage, reloadUsersData }) {
  const [show, setShow] = useState(false);
  const [deleted, setDeleted] = useState(false);

  const handleShow = () => {
    setShow(true);
  };

  const handleClose = () => {
    setShow(false);
  };

  const deleteUser = async (event) => {
    event.preventDefault();
    setDeleted(true);
    var result = await deleteUserAsync(user.id);

    if (result.succeeded) {
      alertMessage("success", "Success", `Delete user ${user.email} succeed.`);
      reloadUsersData();
    } else {
      setDeleted(false);
      alertMessage("warning", "Warning", result.Message);
    }
  };

  return (
    <>
      <Button variant="danger" onClick={handleShow}>
        Delete
      </Button>

      <Modal show={show} onHide={handleClose} className="modal-danger">
        <Modal.Header closeButton>
          <Modal.Title variant="danger">Warning</Modal.Title>
        </Modal.Header>
        <Modal.Body variant="danger">Do you want to delete user : {user.email}</Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleClose}>
            Close
          </Button>

          {deleted ? (
            <Button variant="danger" disabled>
              <Spinner as="span" animation="grow" size="sm" role="status" aria-hidden="true" />
              Deleting...
            </Button>
          ) : (
            <Button variant="danger" onClick={deleteUser}>
              Delete
            </Button>
          )}
        </Modal.Footer>
      </Modal>
    </>
  );
}

export default DeleteUser;