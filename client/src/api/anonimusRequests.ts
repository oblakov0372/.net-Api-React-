import axios from "axios";

const BASE_URl = "https://localhost:7040/api";

export default axios.create({
  baseURL: BASE_URl,
});

export const axiosPrivate = axios.create({
  baseURL: BASE_URl,
  headers: { "Content/Type": "application/json" },
});
