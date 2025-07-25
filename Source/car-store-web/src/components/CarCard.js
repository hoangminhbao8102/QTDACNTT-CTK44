import React from 'react';
import { Link } from 'react-router-dom';

function CarCard({ car }) {
  return (
    <div className="card h-100">
      <img
        src={car.imageUrl || "https://via.placeholder.com/300"}
        className="card-img-top"
        alt={car.name}
      />
      <div className="card-body">
        <h5 className="card-title">{car.name}</h5>
        <p className="card-text">{car.price} USD</p>
        <Link to={`/cars/${car.id}`} className="btn btn-primary">Xem chi tiết</Link>
      </div>
    </div>
  );
}

export default CarCard;
