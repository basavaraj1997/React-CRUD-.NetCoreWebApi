import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';

function BookForm({ initialData, onSubmit }) {
  const [title, setTitle] = useState('');
  const [id, setId] = useState(0);
  const [author, setAuthor] = useState('');
  const [ISBN, setISBN] = useState('');
  useEffect(() => {
    if (initialData) {
      setTitle(initialData.title);
      setAuthor(initialData.author);
      setISBN(initialData.isbn);
      setId(initialData.id);
    }
  }, [initialData]);

  const handleSubmit = (e) => {
    e.preventDefault();
    onSubmit({ id, title, author, ISBN });
    setTitle('');
    setAuthor('');
    setISBN('');
    setId(0);
  };

const handleCancel=(event)=>{
  const { name, value } = event.target;
    console.log('State updated:' );  
};

  return (
    <form onSubmit={handleSubmit}>
      <div className="container">
        <input type="hidden" className="form-control" value={id} onChange={(e) => setId(e.target.value)} />
        <input type="text" className="form-control" placeholder="Title" value={title} onChange={(e) => setTitle(e.target.value)} />
        <br />
        <input type="text" className="form-control" placeholder="Author" value={author} onChange={(e) => setAuthor(e.target.value)} />
        <br />
        <input type="text" className="form-control" placeholder="ISBN No." value={ISBN} onChange={(e) => setISBN(e.target.value)} />
        <br />
        <div>
          <button type="submit" className="btn btn-primary">{initialData ? 'Update Book' : 'Add Book'}</button>
           
          <button type="submit" className="btn btn-danger">Cancel</button>
           
        </div>
      </div>
    </form>
  );
}

export default BookForm;
