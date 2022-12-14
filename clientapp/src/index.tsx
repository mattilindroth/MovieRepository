import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import Header from './Components/Header';
import Movies from './Components/Movies';
import MovieView from './Components/Movie';
import AddMovie from './Components/AddMovie';
import Search from './Components/Search';
import { Provider } from 'react-redux'
//import { store } from './store';

import {
  BrowserRouter as Router,
  Routes,
  Route,
} from "react-router-dom";


const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
root.render(
  <React.StrictMode>
    <Header />
    <Router>
      <div>
        <Routes>
          <Route path = "/" element={<Movies />} />
          <Route path = "/movie/:id" element={<MovieView  />} />
          <Route path = "/add" element={<AddMovie />} />
          <Route path = "/search" element={<Search />} />
        </Routes>
      </div>
    </Router>
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
//reportWebVitals();
