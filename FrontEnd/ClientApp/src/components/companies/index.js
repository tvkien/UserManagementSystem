import React, { useState, useEffect } from "react";
import { Table, Input, Icon, Button } from "semantic-ui-react";

function Companies() {
  const onRadioChange = (e) => {
  };
  return (
    <React.Fragment>
      <Table>
        <Table.Header>
          <Table.Row>
            <Table.HeaderCell />
            <Table.HeaderCell>Firm Name</Table.HeaderCell>
            <Table.HeaderCell>Firm ID</Table.HeaderCell>
            <Table.HeaderCell>PEG</Table.HeaderCell>
            <Table.HeaderCell>Date Created</Table.HeaderCell>
            <Table.HeaderCell>Date Offboarded</Table.HeaderCell>
            <Table.HeaderCell>Firm Admins</Table.HeaderCell>
            <Table.HeaderCell>Pro Users</Table.HeaderCell>
            <Table.HeaderCell>Basic Users</Table.HeaderCell>
          </Table.Row>
        </Table.Header>
        <Table.Body>
          <Table.Row>
            <Table.Cell>
              <div className="ui checkbox radio">
                <input
                //   checked={user.id === (currentItemSelected && currentItemSelected.id)}
                  onChange={onRadioChange}
                //   data-user-id={user.id}
                  type="checkbox"
                />
                <label />
              </div>
            </Table.Cell>
            <Table.Cell>Name</Table.Cell>
            <Table.Cell>Email</Table.Cell>
            <Table.Cell>Date Created</Table.Cell>
            <Table.Cell>Firm Name</Table.Cell>
            <Table.Cell>Firm ID</Table.Cell>
            <Table.Cell>Firm Role</Table.Cell>
            <Table.Cell>Account Type</Table.Cell>
            <Table.Cell>Status</Table.Cell>
          </Table.Row>
        </Table.Body>
      </Table>
    </React.Fragment>
  );
}

export default Companies;
