import React from 'react'
import classes from './Cart.module.scss'
import cartImg from '../../../public/img/cart.png'
import trashImg from '../../../public/img/trash.png'
import CartItem from '../../components/CartItem/CartItem'
import { Link } from 'react-router-dom'
import { useDispatch, useSelector } from 'react-redux'
import { RootState } from '../../redux/store'
import { CartItem as CartItemProps} from '../../redux/cart/types'
import axios from 'axios'
import { clearCart, setItems } from '../../redux/cart/slice'
const Cart = () => {
  

  React.useEffect(()=>{
    axios.get('https://localhost:7040/api/books/cartitems').then((responce) =>dispatch(setItems(responce.data))
    )
  },[])

  const cartItems = useSelector((state:RootState) => state.cart.items)
  const totalPrice = useSelector((state:RootState) => state.cart.totalPrice)
  const totalBooks = useSelector((state:RootState) => state.cart.totalBooks)
  const dispatch = useDispatch();
  return (
    <>
      {cartItems.length !== 0 ? (<div className={classes.content}>
      <div className={classes.content__top}>
        <div className={classes.content__top__left}>
          <img width={40} src={cartImg} alt="cartImg" />
          <h1>Cart</h1>
        </div>
        <div onClick={() => dispatch(clearCart())} className={classes.content__top__right}>
          <img width={20} src={trashImg} alt="trashImg" />
          <span>Clear cart</span>
        </div>
      </div>
      <div className={classes.items}>
        {cartItems.map((item:CartItemProps) => <CartItem key={item.id} {...item}/>)}
      </div>
      <div className={classes.content__bottom}>
        <div className={classes.content__bottom__left}>
          <h1>Total Books: <span>{totalBooks}</span></h1> 
          <Link to="/">
            <button>Go back</button>
          </Link>
        </div>
        <div className={classes.content__bottom__right}>
          <h1>Order Price: <span>{totalPrice} $</span></h1>
          <button>Pay now</button>
        </div>
      </div>
    </div>):<h1>Пусто</h1>}
    </>
  )
}

export default Cart