import React from "react";
// import Table from "react-bootstrap/Table";
import UserRow from "./userRow";
import { Table, Input, Icon, Button } from "semantic-ui-react";

function UserTable({ users, reloadUsersData, alertMessage }) {
  return (
    <React.Fragment>
      <Table>
        <Table.Header>
          <Table.Row>
            <Table.HeaderCell />
            <Table.HeaderCell>Name</Table.HeaderCell>
            <Table.HeaderCell>Email</Table.HeaderCell>
            <Table.HeaderCell>Date Created</Table.HeaderCell>
            <Table.HeaderCell>Firm Name</Table.HeaderCell>
            <Table.HeaderCell>Firm ID</Table.HeaderCell>
            <Table.HeaderCell>Firm Role</Table.HeaderCell>
            <Table.HeaderCell>Account Type</Table.HeaderCell>
            <Table.HeaderCell>Status</Table.HeaderCell>
            <Table.HeaderCell>Actions</Table.HeaderCell>
          </Table.Row>
        </Table.Header>
        <Table.Body>
          {users.map((user) => (
            <UserRow user={user} reloadUsersData={reloadUsersData} alertMessage={alertMessage} />
          ))}
        </Table.Body>
      </Table>
    </React.Fragment>
  );
}

export default UserTable;
