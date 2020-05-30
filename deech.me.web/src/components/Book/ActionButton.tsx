import React, { useState } from "react"

type ActionButtonProps = {
    icon: JSX.Element,
    hoverIcon: JSX.Element
}

export const ActionButton: React.FC<ActionButtonProps> = ({ icon, hoverIcon }) => {
    const [onHover, setOnHover] = useState(false)

    return <span className="action-button" onMouseEnter={_ => setOnHover(true)} onMouseLeave={_ => setOnHover(false)}>
        {
            onHover ? hoverIcon : icon
        }
    </span>
}