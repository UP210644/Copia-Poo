import React from 'react';
import ReactDOM from 'react-dom';
import App from './app'; // Asegúrate de tener un archivo App.js en la carpeta src

ReactDOM.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>,
  document.getElementById('root') // Esto conecta con el div `id="root"` en tu index.html
);