import React, { useEffect, useState } from 'react';
import { getOrders, deleteOrder } from '../../services/orderService';

function OrdersManager() {
  const [orders, setOrders] = useState([]);

  const fetchOrders = () => {
    getOrders().then(res => setOrders(res.data));
  };

  useEffect(() => { fetchOrders(); }, []);

  const handleDelete = (id) => {
    if (window.confirm('Xóa đơn hàng này?')) {
      deleteOrder(id).then(fetchOrders);
    }
  };

  return (
    <div>
      <h5>Danh sách đơn hàng</h5>
      <table className="table table-bordered">
        <thead>
          <tr>
            <th>ID</th>
            <th>Car ID</th>
            <th>User ID</th>
            <th>Tổng tiền</th>
            <th>Hành động</th>
          </tr>
        </thead>
        <tbody>
          {orders.map(o => (
            <tr key={o.id}>
              <td>{o.id}</td>
              <td>{o.carId}</td>
              <td>{o.userId}</td>
              <td>{o.totalPrice}</td>
              <td>
                <button className="btn btn-danger btn-sm" onClick={() => handleDelete(o.id)}>Xóa</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default OrdersManager;
