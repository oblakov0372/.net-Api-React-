import React from 'react'
import { Link } from 'react-router-dom'
import classes from './Header.module.scss'
import logoImg from '../../../public/img/logo.png'
import cartImg from '../../../public/img/cart.png'
import loginImg from '../../../public/img/login.png'
import { useSelector } from 'react-redux'
import { RootState } from '../../redux/store'
const Header = () => {
  const isLogged = useSelector((state:RootState) => state.user.isLogged)
  const {totalPrice,totalBooks} = useSelector((state:RootState) => state.cart)
  return (
    <div className={classes.header}>
      <Link to="/">
        <div className={classes.header__logo}>
          <img width={40} src={logoImg} alt="Logo" />
          <div className={classes.header__logo__details}>
            <h1>Book Store</h1>
            <p>The best books in the world</p>
          </div>
        </div>
      </Link>
      <div className={classes.header__left}>
      <Link to="/cart">
        <div className={classes.header__left__cartButton}>
          <span>{totalPrice} $</span>
          <div>
            <img width={20} src={cartImg} alt="cart" />
            <span>{totalBooks}</span>
          </div>
        </div>
      </Link>
      {!isLogged && <Link to="login">
        <div className={classes.header__left__loginButton}>
          <img src={loginImg} alt="loginImg" width={40} />
        </div>
      </Link>}
      </div>
    </div>
  )
}

export default Header