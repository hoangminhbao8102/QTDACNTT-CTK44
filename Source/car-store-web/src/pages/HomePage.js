import React, { useEffect, useState } from 'react';
import { getCars } from '../services/carService';
import CarCard from '../components/CarCard';

function HomePage() {
  const [cars, setCars] = useState([]);

  useEffect(() => {
    getCars()
      .then(response => setCars(response.data))
      .catch(error => console.error('Error fetching cars:', error));
  }, []);

  return (
    <div className="container mt-4">
      <h2 className="mb-3">Danh sách ô tô</h2>
      <div className="row">
        {cars.map(car => (
          <div className="col-md-4 mb-3" key={car.id}>
            <CarCard car={car} />
          </div>
        ))}
      </div>
    </div>
  );
}

export default HomePage;
