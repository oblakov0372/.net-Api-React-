import React from 'react'
import classes from './BookBlock.module.scss'
import { Book } from '../../redux/book/types'
import { useDispatch, useSelector } from 'react-redux'
import { plusCount } from '../../redux/cart/slice'
import { RootState } from '../../redux/store'

const BookBlock:React.FC<Book> = ({id,url,title,author,price}) => {
  const items = useSelector((state:RootState) => state.cart.items)
  const count = items.find(item => item.id == id)?.count
  const dispatch = useDispatch()
  return (
    <div className={classes.container}>
      <img src={url} alt="BookImg" />
      <h2>{title}</h2>
      <h2>Author: {author}</h2>
      <div className={classes.container__bottom}>
        <span>{price} $</span>
        <div onClick={()=>dispatch(plusCount({id,url,title,author,price,count:1}))} className={classes.container__bottom__button}>
          <p>+ Add to cart</p> <span>{count}</span>
        </div>
      </div>
    </div>
  )
}

export default BookBlock