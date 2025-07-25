import { Link, useNavigate } from 'react-router-dom';

function Navbar() {
  const navigate = useNavigate(); // <-- khai báo navigate
  const user = JSON.parse(localStorage.getItem('user'));

  return (
    <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
      <div className="container">
        <Link className="navbar-brand" to="/">Car Shop</Link>
        <div className="collapse navbar-collapse">
          <ul className="navbar-nav ms-auto">
            <li className="nav-item">
              <Link className="nav-link" to="/">Home</Link>
            </li>
            <li className="nav-item">
              <Link className="nav-link" to="/cart">Cart</Link>
            </li>
            <li className="nav-item">
              <Link className="nav-link" to="/admin">Admin</Link>
            </li>
            <li className="nav-item">
              <Link className="nav-link" to="/admin-login">Admin</Link>
            </li>
            <li className="nav-item">
              {user ? (
                <button
                  className="btn btn-link nav-link"
                  onClick={() => {
                    localStorage.removeItem('user');
                    navigate('/user-login'); // <-- dùng navigate
                  }}
                >
                  Logout ({user.fullName})
                </button>
              ) : (
                <Link className="nav-link" to="/user-login">Login</Link>
              )}
            </li>
            <li className="nav-item">
              <Link className="nav-link" to="/register">Register</Link>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  );
}

export default Navbar;
