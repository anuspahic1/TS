import { Outlet } from "react-router-dom";
import Header from "../components/layout/Header";

export default function AppLayout() {
  return (
    <>
      <Header/>
      <main className="container mx-auto px-4 py-6">
        <Outlet />
      </main>
    </>
  );
}
