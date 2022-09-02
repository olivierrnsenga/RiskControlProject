import React, { Component } from "react";
import { connect } from "react-redux";
import TextInputGroup from "../layout/TextInputGroup";
import { addClassRoom } from "../../actions/crudActions";

class AddClassRoom extends Component {
  state = {
    name: "",
    errors: {}
  };

  onSubmit = e => {
    e.preventDefault();

    const { name } = this.state;

    // Check For Errors
    if (name === "") {
      this.setState({ errors: { name: "Name is required" } });
      return;
    }

   
    const newClassRoom = {
      name
    };

    //// SUBMIT new Class Room ////
    this.props.addClassRoom(newClassRoom);

    // Clear State
    this.setState({
      name: "",
      errors: {}
    });

    //Redirect to home
    this.props.history.push("/");
  };

  onChange = e => this.setState({ [e.target.name]: e.target.value });

  render() {
    const { name, errors } = this.state;

    return (
      <div className="card mb-3">
        <div className="card-header">Add ClassRoom</div>
        <div className="card-body">
          <form onSubmit={this.onSubmit}>
            <TextInputGroup
              label="Name"
              name="name"
              placeholder="Enter Name"
              value={name}
              onChange={this.onChange}
              error={errors.name}
            />
            <input
              type="submit"
              value="Add ClassRoom"
              className="btn btn-light btn-block"
            />
          </form>
        </div>
      </div>
    );
  }
}

export default connect(
  null,
  { addClassRoom }
)(AddClassRoom);
