import axios, { AxiosError } from 'axios';
import React, {  useState } from 'react'
import classes from './Login.module.scss'

type postDataType = {
  userName:string;
  password:string;
}

const Login = () => {

  async function submit(e:any,value:postDataType){
    e.preventDefault()
    try{
      let res = await axios.post("https://localhost:7040/api/Users/login",value)
      console.log(res.data);
    }
    catch(error){
      const err = error as AxiosError
      if(err.response?.status === 400){
        alert("password or email incorrect")
      }
      
    }
    
  }

  const [postData,setPostData] = useState<postDataType>({userName:'',password:''})
  
  return (
    <form onSubmit={(e) => submit(e,postData)} className={classes.formLogin}>
      <div className={classes.formLogin__field}>
        <label htmlFor="text">UserName: </label>
        <input value={postData.userName} onChange={(e) => setPostData(prev => ({userName : e.target.value,password : prev.password}))}
        type="text" />
      </div>
      <div className={classes.formLogin__field}>
        <label  htmlFor="password">Password: </label>
        <input value={postData.password} onChange={(e) => setPostData(prev => ({password : e.target.value,userName : prev.userName}))} type="password" />
      </div>
      <button type='submit'>Login</button>
    </form>
  )
}

export default Login