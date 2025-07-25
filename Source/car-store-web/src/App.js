import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import HomePage from './pages/HomePage';
import CarDetailPage from './pages/CarDetailPage';
import AdminDashboard from './pages/AdminDashboard';
import CartPage from './pages/CartPage';
import Navbar from './components/Navbar';
import LoginAdminPage from './pages/LoginAdminPage';
import RegisterPage from './pages/RegisterPage';
import UserRegisterPage from './pages/UserRegisterPage';
import UserLoginPage from './pages/UserLoginPage';

function App() {
  return (
    <Router>
      <Navbar />
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/cars/:id" element={<CarDetailPage />} />
        <Route path="/cart" element={<CartPage />} />
        <Route path="/admin" element={<AdminDashboard />} />
        <Route path="/admin-login" element={<LoginAdminPage />} />
        <Route path="/register" element={<RegisterPage />} />
        <Route path="/register" element={<UserRegisterPage />} />
        <Route path="/user-login" element={<UserLoginPage />} />
        <Route path="/cart" element={<CartPage />} />
      </Routes>
    </Router>
  );
}

export default App;
