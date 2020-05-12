import React from "react"

type NewCommentProps = {
    paragraphId: number
    associated?: number
};

const NewComment: React.FC<NewCommentProps> = ({ paragraphId, associated }) => {
    return <div>
        <input type="text" name="new-comment" placeholder="Leave comment" />
        <input type="button" name="add-comment" value="Add" />
    </div>
}

export default NewComment