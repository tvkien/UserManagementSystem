import React from "react";
import { Modal } from "react-bootstrap";
import EditUserForm from "./editUserForm";

function EditUserModal(props) {
  return (
    <Modal
      show={props.show}
      onHide={props.close}
      size="lg"
      aria-labelledby="contained-modal-title-vcenter"
      centered
    >
      <Modal.Header closeButton>
        <Modal.Title id="contained-modal-title-vcenter">Edit user</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <EditUserForm
          close={props.close}
          reloadUsersData={props.reloadUsersData}
          user={props.user}
          alertMessage={props.alertMessage}
        />
      </Modal.Body>
    </Modal>
  );
}

export default EditUserModal;