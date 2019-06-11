import React from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import App from './App';
import registerServiceWorker from './registerServiceWorker';

import '@devexpress/dx-react-grid-bootstrap4/dist/dx-react-grid-bootstrap4.css';
import { Helmet } from "react-helmet";

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');

ReactDOM.render(
  <BrowserRouter basename={baseUrl}>
        <App>
            <Helmet>
                <link rel="stylesheet" href="/open-iconic/font/css/open-iconic-bootstrap.css" />
            </Helmet>
        </App>
  </BrowserRouter>,
  rootElement);

registerServiceWorker();
