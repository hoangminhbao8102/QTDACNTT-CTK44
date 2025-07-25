import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { getCarById } from '../services/carService';

function CarDetailPage() {
  const { id } = useParams();
  const [car, setCar] = useState(null);

  useEffect(() => {
    getCarById(id)
      .then(response => setCar(response.data))
      .catch(error => console.error('Error fetching car details:', error));
  }, [id]);

  const addToCart = () => {
    let cart = JSON.parse(localStorage.getItem('cart')) || [];
    // Nếu xe đã tồn tại trong giỏ thì tăng số lượng
    const existing = cart.find(item => item.id === car.id);
    if (existing) {
      existing.quantity += 1;
    } else {
      cart.push({ ...car, quantity: 1 });
    }
    localStorage.setItem('cart', JSON.stringify(cart));
    alert('Đã thêm vào giỏ hàng!');
  };

  if (!car) return <p>Đang tải...</p>;

  return (
    <div className="container mt-4">
      <h2>{car.name}</h2>
      <img
        src={car.imageUrl || "https://via.placeholder.com/500"}
        alt={car.name}
        className="img-fluid mb-3"
      />
      <p><strong>Giá:</strong> {car.price} USD</p>
      <p><strong>Mô tả:</strong> {car.description}</p>
      <button className="btn btn-primary me-2" onClick={addToCart}>Thêm vào giỏ</button>
    </div>
  );
}

export default CarDetailPage;
