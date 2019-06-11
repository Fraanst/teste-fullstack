import React, { Component } from 'react';
import Grid from '@material-ui/core/Grid';
import Typography from '@material-ui/core/Typography';
import TextField from '@material-ui/core/TextField';
import { StepperContext } from './FormPage';
import { Button } from '@material-ui/core';

class UserForm extends Component {
  state = {
    name: '',
    email: ''
  }

  onChangeInput = (e) => {
    var value = e.target.value
    this.setState({ [e.target.name]: value })
  }

  handleSave = (setActiveStep) => {
    fetch("https://localhost:44357/User/Create", {
      method: 'POST',
      mode: 'cors',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(this.state),
    })
      .then(r => r.json().then(response => {
        if (response === true)
          setActiveStep(1);
        else
          throw new Error(`Não foi possível salvar o usuário. ${response['errors'][0].message}`);
      }))
      .catch(e => alert(e))
  }

  render() {

    return (
      <StepperContext.Consumer>
        {
          ({ activeStep, setActiveStep }) => (

            <React.Fragment>
              <Typography variant="h6" gutterBottom>
                Dados de usuário
              </Typography>
              <Grid container spacing={3}>
                <Grid item xs={12} sm={6}>
                  <TextField
                    required
                    onChange={this.onChangeInput}
                    id="name"
                    name="name"
                    label="Informe seu nome completo"
                    fullWidth
                    autoComplete="name"
                  />
                </Grid>
                <Grid item xs={12} sm={6}>
                  <TextField
                    required
                    onChange={this.onChangeInput}
                    id="email"
                    type="email"
                    name="email"
                    label="Informe seu E-mail:"
                    fullWidth
                    autoComplete="lname"
                  />
                </Grid>

                <Grid item xs={12} sm={12} style={{
                  display: 'flex',
                  justifyContent: 'flex-end',
                }}>
                  <Button
                    variant="contained"
                    color="primary"
                    onClick={() => this.handleSave(setActiveStep)}
                  >
                    Salvar
                  </Button>
                </Grid>

              </Grid>
            </React.Fragment>
          )
        }

      </StepperContext.Consumer>

    );
  }
}

export default UserForm;