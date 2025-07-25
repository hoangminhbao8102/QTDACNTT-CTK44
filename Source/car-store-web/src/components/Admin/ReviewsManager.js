import React, { useEffect, useState } from 'react';
import { getReviews, deleteReview } from '../../services/reviewService';

function ReviewsManager() {
  const [reviews, setReviews] = useState([]);

  const fetchReviews = () => {
    getReviews().then(res => setReviews(res.data));
  };

  useEffect(() => { fetchReviews(); }, []);

  const handleDelete = (id) => {
    if (window.confirm('Xóa review này?')) {
      deleteReview(id).then(fetchReviews);
    }
  };

  return (
    <div>
      <h5>Danh sách reviews</h5>
      <table className="table table-bordered">
        <thead>
          <tr>
            <th>ID</th>
            <th>Car ID</th>
            <th>User ID</th>
            <th>Nội dung</th>
            <th>Hành động</th>
          </tr>
        </thead>
        <tbody>
          {reviews.map(r => (
            <tr key={r.id}>
              <td>{r.id}</td>
              <td>{r.carId}</td>
              <td>{r.userId}</td>
              <td>{r.content}</td>
              <td>
                <button className="btn btn-danger btn-sm" onClick={() => handleDelete(r.id)}>Xóa</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default ReviewsManager;
