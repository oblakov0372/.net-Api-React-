import React from 'react'
import classes from './CartItem.module.scss'
import clearImg from '../../../public/img/clear.png'
import { CartItem as CartItemProps } from '../../redux/cart/types'
import { useDispatch } from 'react-redux'
import { clearRow, minusCount, plusCount } from '../../redux/cart/slice'
const CartItem:React.FC<CartItemProps> = ({id,price,title,author,url,count}) => {

  const dispatch = useDispatch();
  return (
    <div className={classes.content}>
      <div className={classes.content__left}>
        <img width={80} height={120} src={url} alt="BookImg" />
        <div className={classes.content__left__details}>
          <h2>{title}</h2>
          <h3>Author: {author}</h3>
        </div>
      </div>
      <div className={classes.content__right}>
        <div className={classes.content__right__count}>
          <span onClick={() => dispatch(minusCount(id))} className={classes.content__right__count__minus}>-</span>
          <p>{count}</p>
          <span onClick={() => dispatch(plusCount({id}))} className={classes.content__right__count__plus}>+</span>
        </div>
        <div className={classes.content__right__price}>
          <h1>{price * count} $</h1>
        </div>
        <div className={classes.content__right__clear}>
          <img onClick={()=>dispatch(clearRow(id))} width={32} src={clearImg} alt="clearImg" />
        </div>
      </div>
    </div>
  )
}

export default CartItem