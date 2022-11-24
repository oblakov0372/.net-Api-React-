import React from 'react'
import classes from './BookBlock.module.scss'
const BookBlock = () => {
  return (
    <div className={classes.container}>
      <img width={270} src="https://d28hgpri8am2if.cloudfront.net/book_images/onix/cvr9781608870080/harry-potter-a-pop-up-book-9781608870080_hr.jpg" alt="BookImg" />
      <h2>Harry Potter</h2>
      <h2>Author: J. K. Rowling</h2>
      <div className={classes.container__bottom}>
        <span>14 $</span>
        <div className={classes.container__bottom__button}>
          + Add to cart
        </div>
      </div>
    </div>
  )
}

export default BookBlock