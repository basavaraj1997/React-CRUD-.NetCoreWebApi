import React, { useState } from 'react';
import { Button, Modal } from 'react-bootstrap';
//import  from 'react-bootstrap';

function Example({ bookToDelete, onClose, onConfirm }) {
  const [show, setShow] = useState(false);

  
  const handleShow = () => {setShow(true);}
  const handleClose = () => {
    onClose();
    setShow(false);
  };


  const handleConfirm = () => {
    onConfirm(bookToDelete.id);
  };
   

  return (
    <>


      {/* <Modal show={bookToDelete !== null} onHide={handleClose} animation={false}>
        <Modal.Header closeButton>
          <Modal.Title>Modal heading</Modal.Title>
        </Modal.Header>
        <Modal.Body>Woohoo, you're reading this text in a modal!</Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleClose}>
            Close
          </Button>
          <Button variant="primary" onClick={handleClose}>
            Save Changes
          </Button>
        </Modal.Footer>
      </Modal> */}
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
}
export default Example; 