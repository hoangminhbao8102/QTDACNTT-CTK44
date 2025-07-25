import React, { useState, useEffect } from 'react';
import { useNavigate, Link } from 'react-router-dom';

import CarManager from '../components/Admin/CarManager';
import CategoryManager from '../components/Admin/CategoryManager';
import OrdersManager from '../components/Admin/OrdersManager';
import UsersManager from '../components/Admin/UsersManager';
import ReviewsManager from '../components/Admin/ReviewsManager';

function AdminDashboard() {
  const [activeTab, setActiveTab] = useState('cars');
  const navigate = useNavigate();

  // Khai báo admin ở ngoài để dùng trong JSX
  const admin = JSON.parse(localStorage.getItem('admin'));

  useEffect(() => {
    if (!admin) {
      navigate('/admin-login');
    }
  }, [navigate, admin]);

  const handleLogout = () => {
    localStorage.removeItem('admin');
    navigate('/admin-login');
  };

  const renderTab = () => {
    switch (activeTab) {
      case 'cars': return <CarManager />;
      case 'categories': return <CategoryManager />;
      case 'orders': return <OrdersManager />;
      case 'users': return <UsersManager />;
      case 'reviews': return <ReviewsManager />;
      default: return <CarManager />;
    }
  };

  return (
    <div className="container mt-4">
      <div className="d-flex justify-content-between align-items-center">
        <h2>Admin Dashboard</h2>
        <button className="btn btn-outline-danger" onClick={handleLogout}>Đăng xuất</button>
      </div>
      <ul className="nav nav-tabs mb-3">
        <li className="nav-item">
          <button
            className={`nav-link ${activeTab === 'cars' ? 'active' : ''}`}
            onClick={() => setActiveTab('cars')}
          >
            Cars
          </button>
        </li>
        <li className="nav-item">
          <button
            className={`nav-link ${activeTab === 'categories' ? 'active' : ''}`}
            onClick={() => setActiveTab('categories')}
          >
            Categories
          </button>
        </li>
        <li className="nav-item">
          <button
            className={`nav-link ${activeTab === 'orders' ? 'active' : ''}`}
            onClick={() => setActiveTab('orders')}
          >
            Orders
          </button>
        </li>
        <li className="nav-item">
          <button
            className={`nav-link ${activeTab === 'users' ? 'active' : ''}`}
            onClick={() => setActiveTab('users')}
          >
            Users
          </button>
        </li>
        <li className="nav-item">
          <button
            className={`nav-link ${activeTab === 'reviews' ? 'active' : ''}`}
            onClick={() => setActiveTab('reviews')}
          >
            Reviews
          </button>
        </li>
        <li className="nav-item">
          {admin ? (
            <button className="btn btn-link nav-link" onClick={handleLogout}>
              Logout
            </button>
          ) : (
            <Link className="nav-link" to="/admin-login">Admin</Link>
          )}
        </li>
      </ul>
      {renderTab()}
    </div>
  );
}

export default AdminDashboard;
