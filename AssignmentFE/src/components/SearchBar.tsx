import { useState, useEffect } from "react";
import SearchBarInput from "./common/SearchBarInput";
import ScrollBox from "./ScrollBox";
import "../style/SearchBar.css";
import { getAllUsers, searchUsers, type UserModel } from "../services/usersService";

// UI shape expected by ScrollBox
type UiUser = { fullName: string; workTitle: string; imageUrl: string };

export default function SearchBar() {
  const [inputTxt, setInputTxt] = useState("");
  const [usersData, setUsersData] = useState<UiUser[]>([]);
  const [inFocus, setInFocus] = useState(false);

  // Load all users once (2.4)
  useEffect(() => {
    let mounted = true;
    (async () => {
      const data: UserModel[] = await getAllUsers();
      const ui: UiUser[] = data.map(u => ({
        fullName: u.fullName ?? u.userName ?? "",
        workTitle: u.workTitle ?? "",
        imageUrl: u.imageUrl ?? ""
      }));
      if (mounted) setUsersData(ui);
    })();
    return () => { mounted = false; };
  }, []);

  // Called by SearchBarInput; implements server filter (2.5) + autocomplete (2.3)
  const getData = async (userTxt: string) => {
    const q = (userTxt ?? "").trim();
    if (!q) {
      const data = await getAllUsers();
      setUsersData(data.map(u => ({
        fullName: u.fullName ?? u.userName ?? "",
        workTitle: u.workTitle ?? "",
        imageUrl: u.imageUrl ?? ""
      })));
      return;
    }
    const data = await searchUsers(q);
    setUsersData(data.map(u => ({
      fullName: u.fullName ?? u.userName ?? "",
      workTitle: u.workTitle ?? "",
      imageUrl: u.imageUrl ?? ""
    })));
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
          usersData={usersData}   // exactly { fullName, workTitle, imageUrl }[]
          display={inFocus}
        />
      </div>
    </div>
  );
}
