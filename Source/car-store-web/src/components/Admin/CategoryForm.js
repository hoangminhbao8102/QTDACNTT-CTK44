import React, { useState, useEffect } from 'react';

function CategoryForm({ initialData, onSubmit, onCancel }) {
  const [formData, setFormData] = useState({ name: '' });

  useEffect(() => {
    if (initialData) setFormData(initialData);
  }, [initialData]);

  const handleChange = (e) => setFormData({ ...formData, [e.target.name]: e.target.value });
  const handleSubmit = (e) => {
    e.preventDefault();
    onSubmit(formData);
  };

  return (
    <form onSubmit={handleSubmit} className="mb-3">
      <div className="mb-2">
        <label className="form-label">Tên danh mục</label>
        <input
          name="name"
          className="form-control"
          value={formData.name}
          onChange={handleChange}
          required
        />
      </div>
      <button type="submit" className="btn btn-primary me-2">Lưu</button>
      <button type="button" className="btn btn-secondary" onClick={onCancel}>Hủy</button>
    </form>
  );
}

export default CategoryForm;
