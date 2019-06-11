import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { AdventureWorks } from './components/AdventureWorks';

import '@devexpress/dx-react-grid-bootstrap4/dist/dx-react-grid-bootstrap4.css';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetch-data' component={FetchData} />
        <Route path='/AdventureWorks' component={AdventureWorks} />
        <Route path='/ui/playground' component={() => {
            window.open(window.location.origin + "/ui/playground", '_blank');
            return null;
        }} />
      </Layout>
    );
  }
}