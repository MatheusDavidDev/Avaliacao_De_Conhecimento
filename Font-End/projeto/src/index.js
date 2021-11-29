// import React from 'react';
// import ReactDOM from 'react-dom';
// import './index.css';
// import App from './App';
// import reportWebVitals from './reportWebVitals';

// ReactDOM.render(
//   <React.StrictMode>
//     <App />
//   </React.StrictMode>,
//   document.getElementById('root')
// );

// // If you want to start measuring performance in your app, pass a function
// // to log results (for example: reportWebVitals(console.log))
// // or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
// reportWebVitals();

import React from 'react';
import { BrowserRouter, Route, Routes  } from 'react-router-dom';
import reactDom from 'react-dom';
import reportWebVitals from './reportWebVitals';


import './index.css';
import 'bootstrap/dist/css/bootstrap.min.css';

import Home from '../src/pages/Home/index'


const routing = (
  <BrowserRouter>
    <>
      <Routes>
          <Route path='/' element={<Home/>} />
      </Routes>
    </>
  </BrowserRouter>
)

reactDom.render(routing, document.getElementById('root'))
// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();