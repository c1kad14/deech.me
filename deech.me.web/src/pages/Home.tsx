import React, { useEffect, useState } from "react"
import { useDispatch, useSelector } from "react-redux"
import { searchTitles } from "../store/title/actions"
import Titles from "../components/Titles"
import { Spinner } from "reactstrap"
import { RootState } from "../store/rootReducer"

const Home: React.FC = () => {
  const dispatch = useDispatch()

  useEffect(() => {
    console.log("Component mounted")
    return () => {
      console.log("Component will be unmount")
    }
  }, [])

  const [filter, setFilter] = useState<string>("")

  let { loading } = useSelector((state: RootState) => state.AppReducer)

  const onFilterChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setFilter(e.target.value)
  }

  const onKeyPressHandler = (e: React.KeyboardEvent) => {
    if (e.key === "Enter") {
      if (filter)
        dispatch(searchTitles(filter))
    }
  }

  const searchButtonClickHandler = () => {
    dispatch(searchTitles(filter))
  }

  return <div>
    <h1>Enter book title</h1>
    <input type="text" name="title" onChange={onFilterChange} onKeyPress={onKeyPressHandler} />
    <input type="button" name="search" value="search" onTouchStart={searchButtonClickHandler} />
    {loading ? <Spinner /> : <Titles />}
  </div>
}

export default Home