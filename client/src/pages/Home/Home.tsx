import React from 'react'
import BookBlock from '../../components/BookBlock/BookBlock'
import classes from './Home.module.scss'
const Home = () => {
  return (
    <div className={classes.container}>
      <h1>All Books</h1>
      <div className={classes.container__items}>
        <BookBlock/>
      </div>
    </div>
  )
}

export default Home