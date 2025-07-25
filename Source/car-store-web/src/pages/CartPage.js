import React, { useState, useEffect } from 'react';
import { createOrder } from '../services/orderService';
import { useNavigate } from 'react-router-dom';

function CartPage() {
  const [cart, setCart] = useState([]);
  const navigate = useNavigate();
  const user = JSON.parse(localStorage.getItem('user')); // Lấy user login

  useEffect(() => {
    if (!user) {
      alert('Bạn cần đăng nhập để xem giỏ hàng');
      navigate('/user-login');
      return;
    }

    const savedCart = JSON.parse(localStorage.getItem('cart')) || [];
    setCart(savedCart);
  }, [navigate, user]);

  const removeItem = (id) => {
    const newCart = cart.filter(item => item.id !== id);
    setCart(newCart);
    localStorage.setItem('cart', JSON.stringify(newCart));
  };

  const clearCart = () => {
    setCart([]);
    localStorage.removeItem('cart');
  };

  const checkout = () => {
    cart.forEach(item => {
      const orderData = {
        carId: item.id,
        userId: user.id,   // Lấy user ID từ login
        quantity: item.quantity,
        totalPrice: item.price * item.quantity
      };
      createOrder(orderData);
    });
    alert("Đặt hàng thành công!");
    clearCart();
  };

  return (
    <div className="container mt-4">
      <h2>Giỏ hàng</h2>
      {cart.length === 0 ? (
        <p>Giỏ hàng trống</p>
      ) : (
        <>
          <table className="table table-bordered">
            <thead>
              <tr>
                <th>Tên xe</th>
                <th>Giá</th>
                <th>Số lượng</th>
                <th>Thành tiền</th>
                <th>Hành động</th>
              </tr>
            </thead>
            <tbody>
              {cart.map(item => (
                <tr key={item.id}>
                  <td>{item.name}</td>
                  <td>{item.price} USD</td>
                  <td>{item.quantity}</td>
                  <td>{item.price * item.quantity} USD</td>
                  <td>
                    <button className="btn btn-danger btn-sm" onClick={() => removeItem(item.id)}>Xóa</button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
          <h5>
            Tổng cộng: {cart.reduce((sum, i) => sum + i.price * i.quantity, 0)} USD
          </h5>
          <button className="btn btn-success mt-2" onClick={checkout}>Thanh toán</button>
        </>
      )}
    </div>
  );
}

export default CartPage;
