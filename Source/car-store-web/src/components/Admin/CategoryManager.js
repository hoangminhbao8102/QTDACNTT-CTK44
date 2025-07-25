import React, { useEffect, useState } from 'react';
import { getCategories, createCategory, updateCategory, deleteCategory } from '../../services/categoryService';
import CategoryForm from './CategoryForm';

function CategoryManager() {
  const [categories, setCategories] = useState([]);
  const [editingCategory, setEditingCategory] = useState(null);
  const [isAdding, setIsAdding] = useState(false);

  const fetchCategories = () => {
    getCategories().then(res => setCategories(res.data)).catch(console.error);
  };

  useEffect(() => { fetchCategories(); }, []);

  const handleAdd = () => {
    setEditingCategory(null);
    setIsAdding(true);
  };

  const handleEdit = (cat) => {
    setEditingCategory(cat);
    setIsAdding(true);
  };

  const handleDelete = (id) => {
    if (window.confirm('Xóa danh mục này?')) {
      deleteCategory(id).then(fetchCategories);
    }
  };

  const handleSubmit = (data) => {
    if (editingCategory) {
      updateCategory(editingCategory.id, data).then(() => {
        fetchCategories();
        setIsAdding(false);
      });
    } else {
      createCategory(data).then(() => {
        fetchCategories();
        setIsAdding(false);
      });
    }
  };

  return (
    <div>
      {!isAdding ? (
        <>
          <button className="btn btn-success mb-3" onClick={handleAdd}>Thêm danh mục</button>
          <table className="table table-bordered">
            <thead>
              <tr>
                <th>ID</th>
                <th>Tên danh mục</th>
                <th>Hành động</th>
              </tr>
            </thead>
            <tbody>
              {categories.map(cat => (
                <tr key={cat.id}>
                  <td>{cat.id}</td>
                  <td>{cat.name}</td>
                  <td>
                    <button className="btn btn-primary btn-sm me-2" onClick={() => handleEdit(cat)}>Sửa</button>
                    <button className="btn btn-danger btn-sm" onClick={() => handleDelete(cat.id)}>Xóa</button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </>
      ) : (
        <CategoryForm
          initialData={editingCategory}
          onSubmit={handleSubmit}
          onCancel={() => setIsAdding(false)}
        />
      )}
    </div>
  );
}

export default CategoryManager;
