import React from "react";
import EditUser from "../userInputs/editUser/editUser";
import DeleteUser from "../userInputs/deleteUser/deleteUser";
import { Table, Input, Icon, Button } from "semantic-ui-react";

function UserRow({ user, reloadUsersData, alertMessage }) {
  const onRadioChange = (e) => {
  };
  return (
    <Table.Row>
      <Table.Cell>
        <div className="ui checkbox radio">
          <input
            //  checked={user.id === (currentItemSelected && currentItemSelected.id)}
            onChange={onRadioChange}
            data-user-id={user.id}
            type="checkbox"
          />
          <label />
        </div>
      </Table.Cell>
      <Table.Cell>
        {user.firstName} {user.lastName}
      </Table.Cell>
      <Table.Cell>{user.email}</Table.Cell>
      <Table.Cell></Table.Cell>
      <Table.Cell></Table.Cell>
      <Table.Cell></Table.Cell>
      <Table.Cell></Table.Cell>
      <Table.Cell></Table.Cell>
      <Table.Cell></Table.Cell>
      <Table.Cell>
        <div>
          <EditUser user={user} reloadUsersData={reloadUsersData} alertMessage={alertMessage} />{" "}
          <DeleteUser user={user} reloadUsersData={reloadUsersData} alertMessage={alertMessage} />
        </div>
      </Table.Cell>
    </Table.Row>
  );
}

export default UserRow;
