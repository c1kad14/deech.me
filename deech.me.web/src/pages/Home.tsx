import * as React from "react";
import { connect } from "react-redux";

const Home = () => (
  <div>
    <h1>Hello, world!</h1>
    <input type="text" name="title" />

    <input type="button"
      className="btn btn-primary btn-lg"
      onClick={_ => console.log()}
      value="Search"
    />
  </div>
);

export default connect()(Home);
