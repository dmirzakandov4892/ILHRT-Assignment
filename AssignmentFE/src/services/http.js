import axios from "axios";
import cfg from "../config.json";

export const http = axios.create({
  baseURL: cfg.baseUrl,
  headers: { Accept: "application/json" }
});

export const get = (url, config) => http.get(url, config);
export const post = (url, data, config) =>
  http.post(url, data, { headers: { "Content-Type": "application/json" }, ...config });

export default http; 
