import React, { useEffect, useRef, useState } from "react"
import { Modal, ModalHeader, ModalBody, ModalFooter } from "reactstrap"
import "./modal.css"

type SignInRequiredProps = {
    isOpen: boolean
    setIsOpen: (isOpen: boolean) => void
}

const SignInRequired: React.FC<SignInRequiredProps> = ({ isOpen, setIsOpen }) => {
    return <Modal isOpen={isOpen} className="modal-window">
        <ModalHeader>Sign in required</ModalHeader>
        <ModalBody>
            You are not currently signed in. To use this function you need to sign in.
        </ModalBody>
        <ModalFooter>
            <button className="btn btn-default" onClick={_ => setIsOpen(false)}>Close</button>
            <button className="btn btn-secondary">Sign in</button>
        </ModalFooter>
    </Modal>
}

export default SignInRequired