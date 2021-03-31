import React, { useState } from "react";
import { Container } from "reactstrap";
import Header from "./Header";
import User from "./components/users";
import Companies from "./components/companies";
import ShowAlert from "./components/alerts/alertBasic";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
const imgLink =
  "data:image/jpeg;base64,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";

export default function App() {
  const [alerts, setAlerts] = useState([]);

  const alertMessage = (type, headline, message) => {
    const alert = { type: type, headline: headline, message: message };
    setAlerts([alert]);
  };

  const onDismissed = () => {
    setAlerts([]);
  };

  return (
    <Container className="App">
      <ShowAlert alerts={alerts} onDismissed={onDismissed} />
      <Header />
      <article className="article">
        <Router>
          <div className="nav-container">
            <div className="img-container">
              <img src={imgLink} alt="abc" />
            </div>
            <ul className="list-menu">
              <li className="active">Home</li>
              <li>About</li>
              <li>
                <Link className="custom-link" to="/user">User</Link>
              </li>
              <li><Link className="custom-link" to="/company">Companies</Link></li>
              <li>Contact</li>
            </ul>
          </div>
          <Switch>
              <Route exact path="/user">
                <User alertMessage={alertMessage} />
              </Route>
              <Route exact path="/company">
                <Companies />
              </Route>
            </Switch>
        </Router>
      </article>
    </Container>
  );
}
