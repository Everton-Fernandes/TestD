import "./globals.css";
import { AuthProvider } from "../context/AuthContext";

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <html lang="pt">
      <body className="bg-gray-50">
        <AuthProvider>
          <nav className="p-4 bg-blue-500 text-white flex justify-between">
            <a href="/" className="font-bold">
              Home
            </a>
            <div>
              <a href="/login" className="mx-2">
                Login
              </a>
              <a href="/register" className="mx-2">
                Registrar
              </a>
              <a href="/users" className="mx-2">
                Dashboard
              </a>
            </div>
          </nav>
          <main className="p-6">{children}</main>
        </AuthProvider>
      </body>
    </html>
  );
}
