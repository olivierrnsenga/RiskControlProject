import React, { Component } from "react";
import { connect } from "react-redux";
import ClassRoom from "./ClassRoom";
import { getClassRooms } from "../../actions/crudActions";

class ClassRooms extends Component {
  componentDidMount() {
    this.props.getClassRooms();
  }

  render() {
    return (
      <React.Fragment>
        <h1 className="mb-3">
          <span className="text-danger">ClassRoom</span> List
        </h1>
        {this.props.classRooms.map(contact => (
          <ClassRoom contact={contact} key={contact.id} />
        ))}
      </React.Fragment>
    );
  }
}

const mapStateToProps = state => ({
  classRooms: state.contact.classRooms
});

export default connect(
  mapStateToProps,
  { getClassRooms }
)(ClassRooms);
