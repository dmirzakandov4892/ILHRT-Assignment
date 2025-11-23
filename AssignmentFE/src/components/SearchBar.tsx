// react
import { useState, useEffect } from "react";
//components
import SearchBarInput from "./common/SearchBarInput";
import ScrollBox from "./ScrollBox";
//css
import "../style/SearchBar.css";
//services
import { getUsersByTxt, getAllusers } from "../services/usersService";


export default function SearchBar() {
  const [inputTxt, setInputTxt] = useState("");
  const [usersData, setUsersData] = useState([]);
  const [inFocus, setInFocus] = useState(false);

  /* ------ Fix: ADD YOUR CODE HERE  ----- */
  useEffect(() => {
    const fetchData = async () => {
      const data = await getAllusers();
      setUsersData(data);
    }
    fetchData();
  }, []);

  /* ------ Complete: ADD YOUR CODE HERE ----- */
  const getData = async (userTxt: string) => {
    if (!userTxt || userTxt.trim() === "") {
      const allUsers = await getAllusers();
      setUsersData(allUsers.length ? allUsers : []);
    } else {
      const matched = await getUsersByTxt(userTxt);

      if (!matched || matched.length === 0) {
        setUsersData([]);
        console.log("No matching users found");
      } else {
        setUsersData(matched);
      }
    }
  };


  return (
    <div className="Main">
      <div className="searchInput">
        <SearchBarInput
          getData={getData}
          setInputTxt={setInputTxt}
          setInFocus={setInFocus}
        />
      </div>
      <div className="scroolable">
        <ScrollBox
          searchedTxt={inputTxt}
          usersData={usersData}
          display={inFocus}
        />
      </div>
    </div>
  );
}
