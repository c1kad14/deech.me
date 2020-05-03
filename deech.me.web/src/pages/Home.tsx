import React, { ChangeEvent, MouseEvent, useEffect } from "react"
import { useDispatch, useSelector } from 'react-redux'
import { setFilter, searchTitles } from "../store/title/actions";
import { RootState } from "../store/rootReducer";

const Home: React.FC = () => {
  const dispatch = useDispatch();

  useEffect(() => {
    console.log('Component mounted');
    return () => {
      console.log('Component will be unmount')
    }
  }, []);

  const onFilterChange = (e: ChangeEvent<HTMLInputElement>) => {
    console.log(e.target.value)
    dispatch(setFilter({ title: e.target.value }));
  };

  const handleClick = (e: MouseEvent<HTMLInputElement>) => {
    e.preventDefault();
    console.log(filter)
    if (filter && filter.title)
      dispatch(searchTitles(filter.title));
  };

  let { filter } = useSelector((state: RootState) => state.TitleReducer);
  return <div>
    <h1>Enter book title</h1>
    <input type="text" name="title" onChange={onFilterChange} />

    <input type="button"
      className="btn btn-primary btn-lg"
      onClick={handleClick}
      value="Search"
    />
  </div>
}

export default Home;