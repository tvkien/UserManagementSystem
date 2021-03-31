import React from "react";
import { Modal } from "react-bootstrap";
import AddUserForm from "./addUserForm";

function AddUserModal(props) {
  return (
    <Modal
      show={props.show}
      onHide={props.close}
      size="lg"
      aria-labelledby="contained-modal-title-vcenter"
      centered
    >
      <Modal.Header closeButton>
        <Modal.Title id="contained-modal-title-vcenter">Add new user</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <AddUserForm
          close={props.close}
          reloadUsersData={props.reloadUsersData}
          alertMessage={props.alertMessage}
        />
      </Modal.Body>
    </Modal>
  );
}

export default AddUserModal;