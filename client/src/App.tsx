import './App.scss';
import { Routes, Route } from 'react-router-dom';
import Header from './components/Header/Header';
import Home from './pages/Home/Home';
import Cart from './pages/Cart/Cart';
import NotFound from './pages/NotFound/NotFound';
import Login from './pages/Login/Login';
import axios from 'axios';
const App = () => {
  axios.interceptors.response.use(function (response) {
    return response;
  }, function (error) {
    if(error.response.status == 401){
      console.log('jwtToken is invalid');
      localStorage.removeItem("jwtToken")
    }
    return Promise.reject(error);
  });
  axios.defaults.headers.common['Authorization'] = `Bearer ${localStorage.getItem('jwtToken')}`
  return (
    <div className="wrapper">
      <Header/>
      <div className="content">
        <Routes>
          <Route path='/' element={<Home/>}/>
          <Route path='/cart' element={<Cart/>}/>
          <Route path='/login' element={<Login/>}/>
          <Route path="*" element={<NotFound />} />
        </Routes>
      </div>
    </div>
  );
}

export default App;
