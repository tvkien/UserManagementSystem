import React, { useState } from "react";
import { Form, Col, Row, Button, Spinner } from "react-bootstrap";
import { createUserAsync } from "../../../../restApi/userApiClient";

function AddUserForm(props) {
  const [submitted, setSubmitted] = useState(false);
  const [user, setUser] = useState({});

  const onChange = (event) => {
    const newUser = { ...user };
    newUser[event.target.name] = event.target.value;
    setUser(newUser);
  };

  const submitAddUser = async (event) => {
    event.preventDefault();
    setSubmitted(true);
    var result = await createUserAsync(user);

    if (result.succeeded) {
      props.alertMessage("success", "Success", `Add user ${result.Email} succeed.`);
      props.close();
      props.reloadUsersData();
    }
    else{
      setSubmitted(false);
      props.alertMessage("warning", "Warning", result.Message);
    }
  };

  return (
    <Form onSubmit={submitAddUser}>
      <Form.Group as={Row} controlId="formPlaintextEmail">
        <Form.Label column sm="2">
          First Name:
        </Form.Label>
        <Col sm="10">
          <Form.Control
            name="firstName"
            type="text"
            placeholder="First Name"
            value={user.firstName}
            onChange={onChange}
          />
        </Col>
      </Form.Group>

      <Form.Group as={Row} controlId="formPlaintextEmail">
        <Form.Label column sm="2">
          Last Name:
        </Form.Label>
        <Col sm="10">
          <Form.Control
            name="lastName"
            type="text"
            placeholder="Last Name"
            value={user.lastName}
            onChange={onChange}
          />
        </Col>
      </Form.Group>

      <Form.Group as={Row} controlId="formPlaintextEmail">
        <Form.Label column sm="2">
          Email Address:
        </Form.Label>
        <Col sm="10">
          <Form.Control
            name="email"
            type="email"
            placeholder="Enter email"
            value={user.email}
            onChange={onChange}
          />
        </Col>
      </Form.Group>

      <Form.Group as={Row}>
        <Col sm={{ span: 10, offset: 2 }}>
          {submitted ? (
            <Button variant="primary" disabled>
              <Spinner as="span" animation="grow" size="sm" role="status" aria-hidden="true" />
              Submitting...
            </Button>
          ) : (
            <Button variant="primary" type="submit">
              Submit
            </Button>
          )}

          <Button onClick={props.close} className="margin-button">
            Close
          </Button>
        </Col>
      </Form.Group>
    </Form>
  );
}

export default AddUserForm;