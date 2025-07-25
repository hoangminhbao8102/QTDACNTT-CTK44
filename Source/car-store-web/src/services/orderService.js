import api from './api';

export const getOrders = () => api.get('/Orders');
export const getOrdersByUser = (userId) => api.get(`/Orders/user/${userId}`);
export const createOrder = (order) => api.post('/Orders', order);
export const updateOrder = (id, order) => api.put(`/Orders/${id}`, order);
export const deleteOrder = (id) => api.delete(`/Orders/${id}`);
