import { Navigate, Outlet } from "react-router-dom";

export default function PreAuthRoute() {
  const preAuthToken = localStorage.getItem("preAuthToken");

  return preAuthToken ? <Outlet /> : <Navigate to="/login" replace />;
}
