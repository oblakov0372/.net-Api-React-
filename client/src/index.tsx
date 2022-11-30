import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import { store } from './redux/store';
import { Provider } from 'react-redux'
import { BrowserRouter } from 'react-router-dom';
import axios from 'axios';
const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
  axios.defaults.headers.common['Authorization'] = `Bearer ${localStorage.getItem('jwtToken')}`
root.render(
  <Provider store={store}>
    <BrowserRouter>
    <React.StrictMode>
      <App />
    </React.StrictMode>
  </BrowserRouter>
  </Provider>
);

