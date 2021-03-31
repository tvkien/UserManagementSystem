import React from "react";
import { Form, Button } from "react-bootstrap";

function SearchUser() {
  const search = (event) => {
    event.preventDefault();
  };

  return (
    <>
      <Form className="searchUser" onSubmit={search}>
        <Form.Control type="text" placeholder="Search..." />
        <Button type="submit">
          <i class="fa fa-search"></i>
        </Button>
      </Form>
    </>
  );
}

export default SearchUser;
