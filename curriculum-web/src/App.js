import React from 'react';
import { Route } from 'react-router-dom';
import FormPage from './Containers/FormPage';
import UserForm from './Containers/UserForm';
import { CssBaseline } from '@material-ui/core';

const App = () => {
  return (
    <React.Fragment>
      <CssBaseline />
      <Route path="/" exact component={FormPage} />
    </React.Fragment>
  );
}

export default App;
