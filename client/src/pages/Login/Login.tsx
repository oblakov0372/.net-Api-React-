import axios, { AxiosError } from 'axios';
import React, {  useState } from 'react'
import { useDispatch, useSelector } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import { RootState } from '../../redux/store';
import { setIsLoggedStatus } from '../../redux/user/slice';
import classes from './Login.module.scss'
import { setItems as setCartItems } from '../../redux/cart/slice'


type postDataType = {
  email:string;
  password:string;
}

const Login = () => {
  const[isSubmit,setIsSubmit] = useState(false);
  const isLogged = useSelector((state:RootState) => state.user.isLogged)
  const dispatch = useDispatch();
  const navigate = useNavigate();

  async function submit(e:any,value:postDataType){
    e.preventDefault()
    try{
      setIsSubmit(true)
      let res = await axios.post("https://localhost:7040/api/Users/login",value)
      localStorage.setItem("jwtToken",res.data)
      dispatch(setIsLoggedStatus(true))
      navigate('/')
      location.reload();
    }
    catch(error){
      const err = error as AxiosError
      if(err.response?.status === 400){
        alert("password or email incorrect")
      }
    }
    
    setIsSubmit(false)
    
  }

  const [postData,setPostData] = useState<postDataType>({email:'',password:''})
  
  return (
    <>
    {isSubmit && 
    <div className={classes.submiting}>
      Loading...
    </div>
    }
    <form onSubmit={(e) => submit(e,postData)} className={classes.formLogin}>
      <div className={classes.formLogin__field}>
        <label htmlFor="text">Email: </label>
        <input value={postData.email} onChange={(e) => setPostData(prev => ({email : e.target.value,password : prev.password}))}
        type="text" />
      </div>
      <div className={classes.formLogin__field}>
        <label  htmlFor="password">Password: </label>
        <input value={postData.password} onChange={(e) => setPostData(prev => ({password : e.target.value,email : prev.email}))} type="password" />
      </div>
      <button type='submit'>Login</button>
    </form>
    </>
  )
}

export default Login