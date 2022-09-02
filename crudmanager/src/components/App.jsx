import React, { Component } from "react";
import { HashRouter as Router, Switch, Route } from "react-router-dom";
import { Provider } from "react-redux";
import store from "../store";

import ClassRooms from "./classRooms/ClassRooms";
import Header from "./layout/Header";
import About from "./pages/About";
import AddClassRoom from "./classRooms/AddClassRoom";
import NotFound from "./pages/NotFound";
import EditClassRooms from "./classRooms/EditClassRooms";

class App extends Component {
  state = {};
  render() {
    return (
      <Provider store={store}>
        <Router>
          <React.Fragment>
            <Header />
            <div className="container">
              <Switch>
                <Route exact path="/" component={ClassRooms} />
                <Route exact path="/about/" component={About} />
                <Route exact path="/contact/add" component={AddClassRoom} />
                <Route exact path="/contact/edit/:id" component={EditClassRooms} />
                <Route component={NotFound} />
              </Switch>
            </div>
          </React.Fragment>
        </Router>
      </Provider>
    );
  }
}

export default App;
