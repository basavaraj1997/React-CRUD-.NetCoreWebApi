import React, { useState } from 'react';
import DeleteConfirmationDialog from './DeleteConfirmationDialog';
import 'bootstrap/dist/css/bootstrap.min.css';
import Example from './Example'
function BookList({ books, onDelete, onUpdate }) {
  const [bookToDelete, setBookToDelete] = useState(null);

  console.log(onUpdate);
  const handleDelete = (id) => { 
    onDelete(id);
    setBookToDelete(null);
  };

  return (
    <>
      <div className="container">
        <br />
        <table className="table" border="1">
          <thead>
            <tr>
              <th>Title</th>
              <th>Author</th>
              <th>ISBN</th>
              <th>Action</th>
            </tr>
          </thead>
          <tbody>
            {books.map((book) => (
              <tr key={book.id}>
                <td>{book.title}</td>
                <td>{book.author}</td>
                <td>{book.isbn}</td>
                <td>
                  <button className="btn btn-primary" onClick={() => onUpdate(book)}>Edit</button>

                  <button className="btn btn-warning" onClick={() => setBookToDelete(book)}>Delete</button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
      <DeleteConfirmationDialog
        bookToDelete={bookToDelete}
        onClose={() => setBookToDelete(null)}
        onConfirm={handleDelete}
      />

      {/* <Example
        bookToDelete={bookToDelete}
        onClose={() => setBookToDelete(null)}
        onConfirm={handleDelete}
      /> */}

    </>
  );
}

export default BookList;