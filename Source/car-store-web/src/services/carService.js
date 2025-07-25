import api from './api';

export const getCars = () => api.get('/Cars');
export const getCarById = (id) => api.get(`/Cars/${id}`);
export const createCar = (car) => api.post('/Cars', car);
export const updateCar = (id, car) => api.put(`/Cars/${id}`, car);
export const deleteCar = (id) => api.delete(`/Cars/${id}`);
export const getCarsByCategory = (categoryId) => api.get(`/Cars/category/${categoryId}`);
export const searchCars = (query) => api.get(`/Cars/search?keyword=${query}`);
