import React from 'react'
import classes from './CartItem.module.scss'
import clearImg from '../../../public/img/clear.png'
const CartItem = () => {
  return (
    <div className={classes.content}>
      <div className={classes.content__left}>
        <img width={80} src="https://d28hgpri8am2if.cloudfront.net/book_images/onix/cvr9781608870080/harry-potter-a-pop-up-book-9781608870080_hr.jpg" alt="BookImg" />
        <div className={classes.content__left__details}>
          <h2>Harry Poter</h2>
          <h3>J. K. Rowling</h3>
        </div>
      </div>
      <div className={classes.content__right}>
        <div className={classes.content__right__count}>
          <span className={classes.content__right__count__minus}>-</span>
          <p>1</p>
          <span className={classes.content__right__count__plus}>+</span>
        </div>
        <div className={classes.content__right__price}>
          <h1>55 $</h1>
        </div>
        <div className={classes.content__right__clear}>
          <img width={32} src={clearImg} alt="clearImg" />
        </div>
      </div>
    </div>
  )
}

export default CartItem