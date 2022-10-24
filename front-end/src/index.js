import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App';
import { Toaster } from 'react-hot-toast';

import 'bootstrap/dist/css/bootstrap.css';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <>
    <Toaster />
    <App />
  </>
);
