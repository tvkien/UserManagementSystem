import React from "react";
import { AlertList } from "react-bs-notifier";

function ShowAlert({alerts, onDismissed}) {
  return (
    <div className="center">
      <AlertList
        position="top-left"
        alerts={alerts}
        timeout={3000}
        onDismiss={onDismissed}
      />
    </div>
  );
}

export default ShowAlert;