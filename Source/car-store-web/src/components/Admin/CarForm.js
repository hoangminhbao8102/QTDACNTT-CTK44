import React, { useState, useEffect } from 'react';

function CarForm({ initialData, onSubmit, onCancel }) {
  const [formData, setFormData] = useState({
    name: '',
    price: '',
    description: '',
    imageUrl: '',
    categoryId: ''
  });

  useEffect(() => {
    if (initialData) {
      setFormData(initialData);
    }
  }, [initialData]);

  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    onSubmit(formData);
  };

  return (
    <form onSubmit={handleSubmit} className="mb-3">
      <div className="mb-2">
        <label className="form-label">Tên xe</label>
        <input
          name="name"
          className="form-control"
          value={formData.name}
          onChange={handleChange}
          required
        />
      </div>
      <div className="mb-2">
        <label className="form-label">Giá</label>
        <input
          name="price"
          type="number"
          className="form-control"
          value={formData.price}
          onChange={handleChange}
          required
        />
      </div>
      <div className="mb-2">
        <label className="form-label">Mô tả</label>
        <textarea
          name="description"
          className="form-control"
          value={formData.description}
          onChange={handleChange}
        />
      </div>
      <div className="mb-2">
        <label className="form-label">Hình ảnh (URL)</label>
        <input
          name="imageUrl"
          className="form-control"
          value={formData.imageUrl}
          onChange={handleChange}
        />
      </div>
      <div className="mb-2">
        <label className="form-label">Category ID</label>
        <input
          name="categoryId"
          type="number"
          className="form-control"
          value={formData.categoryId}
          onChange={handleChange}
        />
      </div>
      <button type="submit" className="btn btn-primary me-2">Lưu</button>
      <button type="button" className="btn btn-secondary" onClick={onCancel}>Hủy</button>
    </form>
  );
}

export default CarForm;
