import { get, post } from "./http";

// Server shape (what the API returns)
export interface UserModel {
  userName?: string;   // server may send userName
  fullName?: string;   // or fullName – support both
  workTitle: string;
  email?: string;
  imageUrl: string;
  skills?: Record<string, number>;
}

export async function getAllUsers(): Promise<UserModel[]> {
  const { data } = await get("/User");
  return data;
}

// POST body is a raw string (your current controller)
export async function searchUsers(text: string): Promise<UserModel[]> {
  const { data } = await post("/User", JSON.stringify(text ?? ""));
  return data;
}

const usersService = { getAllUsers, searchUsers };
export default usersService;
