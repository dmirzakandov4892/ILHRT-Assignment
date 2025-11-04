import Logo from "./components/common/Logo";
import Header from "./components/Header";
import SearchBar from "./components/SearchBar";
import "./style/App.css";

export default function App() {
  return (
    <div className="App">
      <Logo />
      <Header />
      <SearchBar />
    </div>
  );
}
