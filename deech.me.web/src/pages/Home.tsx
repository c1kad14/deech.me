import React from "react"
import { useSelector } from "react-redux"
import Titles from "../components/Titles"
import { Spinner } from "reactstrap"
import { RootState } from "../store/rootReducer"

const Home: React.FC = () => {
  let { loading } = useSelector((state: RootState) => state.AppReducer)


  return <div className="home-wrapper">
    <div className="titles-container">
      {loading ? <Spinner /> : <Titles />}
    </div>
  </div>
}

export default Home