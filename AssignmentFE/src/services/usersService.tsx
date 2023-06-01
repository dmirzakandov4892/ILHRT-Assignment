// methodes
import http from "./http";

// config data
import config from "../config.json";

export async function getAllusers() {
  const { data } = await http.get(config.apiUrl);
  return data;
}

export async function getUsersByTxt(txt: string) {
  const { data } = await http.post(config.apiUrl, {
    "text": txt
  });
  return data;
}

export default {
  getAllusers,
  getUsersByTxt,
};
