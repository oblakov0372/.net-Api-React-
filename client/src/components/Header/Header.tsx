import React from 'react'
import { Link, useNavigate } from 'react-router-dom'
import classes from './Header.module.scss'
import logoImg from '../../../public/img/logo.png'
import cartImg from '../../../public/img/cart.png'
import loginImg from '../../../public/img/login.png'
import logoutImg from '../../../public/img/logout.png'
import { useDispatch, useSelector } from 'react-redux'
import { RootState } from '../../redux/store'
import { setIsLoggedStatus } from '../../redux/user/slice'
const Header = () => {
  const isLogged = useSelector((state:RootState) => state.user.isLogged)
  const dispatch = useDispatch();
  const navigate = useNavigate();
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
      {
        isLogged &&
        <div className={classes.header__left__loginButton}>
          <img src={logoutImg} onClick={() => dispatch(setIsLoggedStatus(false))} alt="logoutImg" width={40} />
        </div>
      }
      </div>
    </div>
  )
}

export default Header