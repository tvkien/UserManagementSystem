import React from "react";
import AddUser from "./addUser/addUser.js";
import ExportUser from "./exportUser/exportUser.js";
import SearchUser from "./searchUser/searchUser.js";

function UserInputs({ reloadUsersData, alertMessage }) {
  return (
    <div className="userInput">
      <AddUser reloadUsersData={reloadUsersData} alertMessage={alertMessage} />
      <ExportUser className="margin-button" />
      <SearchUser />
    </div>
  );
}

export default UserInputs;
