import api from './api';

export const getReviews = () => api.get('/Reviews');
export const getReviewsByCar = (carId) => api.get(`/Reviews/car/${carId}`);
export const createReview = (review) => api.post('/Reviews', review);
export const updateReview = (id, review) => api.put(`/Reviews/${id}`, review);
export const deleteReview = (id) => api.delete(`/Reviews/${id}`);
