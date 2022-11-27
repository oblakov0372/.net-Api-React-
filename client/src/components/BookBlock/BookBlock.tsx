import React from 'react'
import classes from './BookBlock.module.scss'
import { Book } from '../../redux/book/types'

const BookBlock:React.FC<Book> = ({id,url,title,author,price}) => {
  return (
    <div className={classes.container}>
      <img width={270} height={400} src={url} alt="BookImg" />
      <h2>{title}</h2>
      <h2>Author: {author}</h2>
      <div className={classes.container__bottom}>
        <span>{price} $</span>
        <div className={classes.container__bottom__button}>
          + Add to cart
        </div>
      </div>
    </div>
  )
}

export default BookBlock