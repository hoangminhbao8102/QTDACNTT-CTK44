import React, { useEffect, useState } from 'react';
import { getCars, createCar, updateCar, deleteCar } from '../../services/carService';
import CarForm from './CarForm';

function CarManager() {
  const [cars, setCars] = useState([]);
  const [editingCar, setEditingCar] = useState(null);
  const [isAdding, setIsAdding] = useState(false);
  const [searchTerm, setSearchTerm] = useState('');
  const [currentPage, setCurrentPage] = useState(1);
  const itemsPerPage = 5;

  const fetchCars = () => {
    getCars().then(res => setCars(res.data)).catch(console.error);
  };

  useEffect(() => { fetchCars(); }, []);

  const handleAdd = () => {
    setEditingCar(null);
    setIsAdding(true);
  };

  const handleEdit = (car) => {
    setEditingCar(car);
    setIsAdding(true);
  };

  const handleDelete = (id) => {
    if (window.confirm('Xóa xe này?')) {
      deleteCar(id).then(fetchCars);
    }
  };

  const handleSubmit = (data) => {
    if (editingCar) {
      updateCar(editingCar.id, data).then(() => {
        fetchCars();
        setIsAdding(false);
      });
    } else {
      createCar(data).then(() => {
        fetchCars();
        setIsAdding(false);
      });
    }
  };

  const filteredCars = cars.filter(car =>
    car.name.toLowerCase().includes(searchTerm.toLowerCase())
);

    const totalPages = Math.ceil(filteredCars.length / itemsPerPage);
    const displayedCars = filteredCars.slice(
    (currentPage - 1) * itemsPerPage,
    currentPage * itemsPerPage
    );

  return (
    <div>
      {!isAdding ? (
        <>
          <button className="btn btn-success mb-3" onClick={handleAdd}>Thêm xe</button>
          <input
            type="text"
            className="form-control mb-3"
            placeholder="Tìm kiếm xe..."
            value={searchTerm}
            onChange={(e) => {
                setSearchTerm(e.target.value);
                setCurrentPage(1);
            }}
            />
          <table className="table table-bordered">
            <thead>
              <tr>
                <th>ID</th>
                <th>Tên xe</th>
                <th>Giá</th>
                <th>Category</th>
                <th>Hành động</th>
              </tr>
            </thead>
            <tbody>
    {displayedCars.map(car => (
      <tr key={car.id}>
        <td>{car.id}</td>
        <td>{car.name}</td>
        <td>{car.price} USD</td>
        <td>{car.categoryId}</td>
        <td>
          <button className="btn btn-primary btn-sm me-2" onClick={() => handleEdit(car)}>Sửa</button>
          <button className="btn btn-danger btn-sm" onClick={() => handleDelete(car.id)}>Xóa</button>
        </td>
      </tr>
    ))}
  </tbody>
          </table>
        </>
      ) : (
        <CarForm
          initialData={editingCar}
          onSubmit={handleSubmit}
          onCancel={() => setIsAdding(false)}
        />
      )}
      <div className="d-flex justify-content-center mt-3">
  <button
    className="btn btn-outline-secondary me-2"
    disabled={currentPage === 1}
    onClick={() => setCurrentPage(prev => prev - 1)}
  >
    « Trước
  </button>
  <span>Trang {currentPage} / {totalPages}</span>
  <button
    className="btn btn-outline-secondary ms-2"
    disabled={currentPage === totalPages}
    onClick={() => setCurrentPage(prev => prev + 1)}
  >
    Sau »
  </button>
</div>
    </div>
  );
}

export default CarManager;
