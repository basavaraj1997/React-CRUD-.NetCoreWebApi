import React, { useState } from 'react';
import { Modal, Button } from 'react-bootstrap';
function DeleteConfirmationDialog({ bookToDelete, onClose, onConfirm }) {

  const handleClose = () => {
    onClose();
  };

  const handleConfirm = () => {
    onConfirm(bookToDelete.id);
  };
  return (
    <>
      <Modal show={bookToDelete !== null} onHide={handleClose} animation={false}>
        <Modal.Header closeButton>
          <Modal.Title>Confirm Delete</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          Are you sure you want to delete "{bookToDelete && bookToDelete.title}"?
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" className="btn btn-secondary" onClick={handleClose}>
            Cancel
          </Button>
          <Button className="btn btn-primary" variant="primary" onClick={handleConfirm}>
            Delete
          </Button>
        </Modal.Footer>
      </Modal>
    </>
  );
};

export default DeleteConfirmationDialog;

