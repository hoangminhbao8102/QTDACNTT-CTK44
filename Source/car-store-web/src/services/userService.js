import api from './api';

export const getUsers = () => api.get('/Users');
export const createUser = (user) => api.post('/Users', user);
export const updateUser = (id, user) => api.put(`/Users/${id}`, user);
export const deleteUser = (id) => api.delete(`/Users/${id}`);
export const getUserByEmail = (email) => api.get(`/Users/email/${email}`);
