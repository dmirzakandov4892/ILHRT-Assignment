// react
import React from "react";

//css
import "../style/ScrollBox.css";

//components
import CardItem from "./common/CardItem";

// interface
import { ScrollBoxProps } from "../interface";

const ScrollBox: React.FC<ScrollBoxProps> = ({ searchedTxt, usersData, display }) => {
  return (
    <div className="ScrollBox">
      {display && usersData.map((item, index) => (
        <CardItem
          fullName={item.fullName}
          jobTitle={item.workTitle}
          imageUrl={item.imageUrl}
          searchedTxt={searchedTxt}
          key={index}
        />
      ))}
    </div>
  );
};

export default ScrollBox;
