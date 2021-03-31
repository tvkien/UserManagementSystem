import React, { useState, useEffect, useRef } from "react";
import Button from "react-bootstrap/Button";
import { CSVLink } from "react-csv-3";

import { getUsersToExportAsync } from "../../../../restApi/userApiClient";

function ExportUser(props) {
  const [users, setUsers] = useState([]);
  const [headers, setHeaders] = useState([]);
  const ref = useRef(null);

  const download = async (event) => {
    event.preventDefault();
    const result = await getUsersToExportAsync();

    if (result.succeeded) {
      setUsers(result.data.data);
      setHeaders(result.data.headers);
    }
  };

  useEffect(() => {
    if (users.length > 0 && headers.length > 0) {
      ref.current.link.click();
    }
  }, [users, headers]);

  return (
    <>
      <Button className={props.className} variant="success" onClick={download}>
        Download CSV
      </Button>
      <CSVLink
        data={users}
        headers={headers}
        filename="user_data.csv"
        className="hidden"
        ref={ref}
        target="_blank"
      />
    </>
  );
}

export default ExportUser;
