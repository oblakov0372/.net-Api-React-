import React from 'react'
import classes from './Cart.module.scss'
import cartImg from '../../../public/img/cart.png'
import trashImg from '../../../public/img/trash.png'
import CartItem from '../../components/CartItem/CartItem'
import { Link } from 'react-router-dom'

const Cart = () => {
  return (
    <div className={classes.content}>
      <div className={classes.content__top}>
        <div className={classes.content__top__left}>
          <img width={40} src={cartImg} alt="cartImg" />
          <h1>Cart</h1>
        </div>
        <div className={classes.content__top__right}>
          <img width={20} src={trashImg} alt="trashImg" />
          <span>Clear cart</span>
        </div>
      </div>
      <div className={classes.items}>
        <CartItem/>
        <CartItem/>
      </div>
      <div className={classes.content__bottom}>
        <div className={classes.content__bottom__left}>
          <h1>Total Books: <span>3</span></h1> 
          <Link to="/">
            <button>Go back</button>
          </Link>
        </div>
        <div className={classes.content__bottom__right}>
          <h1>Order Price: <span>150 $</span></h1>
          <button>Pay now</button>
        </div>
      </div>
    </div>
  )
}

export default Cart