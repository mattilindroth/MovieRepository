import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';

import Movies from './Movies';
import Movie from './Movie';
import AddMovie from './AddMovie';

import {
  BrowserRouter as Router,
  Routes,
  Route,
  Link,
  useParams
} from "react-router-dom";

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
root.render(
  <React.StrictMode>
    <Router>
      <div>
        <Routes>

          <Route path = "/" element={<Movies />} />
          <Route path = "/movie/:id" element={<Movie  />} />
          <Route path = "/add" element={<AddMovie />} />
        </Routes>
      </div>
    </Router>
    <App />
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
