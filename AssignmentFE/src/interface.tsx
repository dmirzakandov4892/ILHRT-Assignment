export interface SearchBarInputprops {
  getData: (userTxt: string) => any;
  setInputTxt: React.Dispatch<React.SetStateAction<string>>;
  setInFocus:React.Dispatch<React.SetStateAction<boolean>>
}

export interface cardItemProps {
  fullName: string;
  jobTitle: string;
  searchedTxt: string;
  imageUrl: string;
}

export interface ScrollBoxProps {
  searchedTxt: string;
  display: boolean;
  usersData: { fullName: string; workTitle: string; imageUrl: string }[];
}

export interface LocationCheckBoxprops {
  setSearchedLocation: Function;
  defultLabels: string[];
}
