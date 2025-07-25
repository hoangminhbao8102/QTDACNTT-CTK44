import api from './api';

export const getCategories = () => api.get('/Categories');
export const createCategory = (category) => api.post('/Categories', category);
export const updateCategory = (id, category) => api.put(`/Categories/${id}`, category);
export const deleteCategory = (id) => api.delete(`/Categories/${id}`);
