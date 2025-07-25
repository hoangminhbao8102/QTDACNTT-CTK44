import React, { useEffect, useState } from 'react';
import { getUsers, deleteUser } from '../../services/userService';

function UsersManager() {
  const [users, setUsers] = useState([]);

  const fetchUsers = () => {
    getUsers().then(res => setUsers(res.data));
  };

  useEffect(() => { fetchUsers(); }, []);

  const handleDelete = (id) => {
    if (window.confirm('Xóa người dùng này?')) {
      deleteUser(id).then(fetchUsers);
    }
  };

  return (
    <div>
      <h5>Danh sách người dùng</h5>
      <table className="table table-bordered">
        <thead>
          <tr>
            <th>ID</th>
            <th>Email</th>
            <th>Tên</th>
            <th>Hành động</th>
          </tr>
        </thead>
        <tbody>
          {users.map(u => (
            <tr key={u.id}>
              <td>{u.id}</td>
              <td>{u.email}</td>
              <td>{u.name}</td>
              <td>
                <button className="btn btn-danger btn-sm" onClick={() => handleDelete(u.id)}>Xóa</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default UsersManager;
