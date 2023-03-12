import React, { useState, useEffect } from 'react';
import axios from 'axios';
import BookForm from './BookForm';
import BookList from './BookList'; 

function crud() {
    const [books, setBooks] = useState([]);
    const [editing, setEditing] = useState(false);
    const [editingBook, setEditingBook] = useState({});

    // const url = "http://localhost:5019"; //{headers:{headers}}
    const url = ""; //{headers:{headers}}
    useEffect(() => {
        axios.get(url + '/api/books', {
            headers: { "Access-Control-Allow-Origin": "*", 'Content-Type': 'application/json; charset=UTF-8' },
        })
            .then(response => {
                setBooks(response.data)
                console.log('FORM DATA:', response.data)
            }).catch(error => console.log(error));
    }, [handleCreate,handleUpdate,handleDelete]);

    const handleCreate = (book) => {
        axios.post(url + '/api/books', book)
            .then(response => {

                setBooks([...books, response.data])
            })
            .catch(error => console.log(error));
    };

    const handleUpdate = (book) => {

        axios.put(url + `/api/books/${book.id}`, book)
            .then(response => {
                const updatedBooks = books.map(b => b.id === book.id ? response.data : b);
                setBooks(updatedBooks);
                setEditing(false);
                setEditingBook({});
            })
            .catch(error => console.log(error));
    };

    const handleDelete = (id) => {
        
        axios.delete(url + `/api/books/${id}`)
            .then(() => setBooks(books.filter(b => b.id !== id)))
            .catch(error => console.log(error));
    };

    return (
        <div>
            <h1>Books</h1>
            {editing ? (
                <BookForm onSubmit={handleUpdate} initialData={editingBook} />
            ) : (
                <BookForm onSubmit={handleCreate} />
            )}

            <BookList books={books} onDelete={handleDelete} onUpdate={(book) => {
                setEditing(true);
                setEditingBook(book);
            }} />
           
        </div>
    );
}

export default crud;
