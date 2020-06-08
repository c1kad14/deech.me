import React, { useState } from "react"

export type ActionButtonProps = {
    icon?: JSX.Element,
    hoverIcon?: JSX.Element
    onClick?: ((event: React.MouseEvent<HTMLSpanElement, MouseEvent>) => void)
}

export const ActionButton: React.FC<ActionButtonProps> = ({ icon, hoverIcon, onClick }) => {
    const [onHover, setOnHover] = useState(false)

    return <span className="action-button" onMouseEnter={_ => setOnHover(true)} onMouseLeave={_ => setOnHover(false)} onClick={onClick}>
        {
            onHover ? hoverIcon : icon
        }
    </span>
}