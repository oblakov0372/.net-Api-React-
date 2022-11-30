import React, { useEffect,useState } from 'react'
import BookBlock from '../../components/BookBlock/BookBlock'
import classes from './Home.module.scss'
import axios from 'axios'
import { Book } from '../../redux/book/types'
import { useDispatch, useSelector } from 'react-redux'
import { RootState } from '../../redux/store'
import { setItems } from '../../redux/book/slice'
import { setItems as setCartItems } from '../../redux/cart/slice'

const Home = () => {

  const items = useSelector((state:RootState) => state.pizza.items)
  const dispatch = useDispatch()

  useEffect(() => {
    axios.get('https://localhost:7040/api/books')
         .then((responce) => dispatch(setItems(responce.data)));
    axios.get('https://localhost:7040/api/books/cartitems').then((responce) =>dispatch(setCartItems(responce.data))
    )
  },[])
  return (
    <div className={classes.container}>
      <h1>All Books</h1>
      <div className={classes.container__items}>
        {items.map((obj:Book) => <BookBlock key={obj.id} {...obj}/>)}
      </div>
    </div>
  )
}

export default Home