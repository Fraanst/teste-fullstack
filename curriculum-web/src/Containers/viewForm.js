import React, { Component } from 'react';
import Grid from '@material-ui/core/Grid';
import Typography from '@material-ui/core/Typography';
import TextField from '@material-ui/core/TextField';
import { StepperContext } from './FormPage';

class viewForm extends Component {
    state = {
        idUser: 0,
        User: { name: '',
                email: '', 
                curriculumId: 0},
        IdCv: 0,
        Curriculum:{
            resumo: '',
            end: '',
            telefone: '',
            interesses: '',
            linkedin: '',
            site: '',
            conquistas: [],
            formacaoAcademica: [],
            competencias: [],
            experienciaProfissional: []
        }

    }

 componentDidMount(){
    fetch("https://localhost:44357/User/GetId", {
      method: 'Get',
      mode: 'cors',
      headers: {
        'Content-Type': 'application/json',
      },
    })
        .then(r => r.json().then(response => {
          this.setState({ idUser: response });
        }))
      .catch(e => alert(e))

      fetch("https://localhost:44357//User/GetById?id="+ this.state.idUser, {
        method: 'Get',
        mode: 'cors',
        headers: {
          'Content-Type': 'application/json',
        },
      })
          .then(r => r.json().then(response => {
            this.setState({ User: response });
            this.setState({ IdCv: this.state.User.curriculumId});
            console.log(response);
            console.log(this.state.User.curriculumId);
          }))
        .catch(e => alert(e))

        fetch("https://localhost:44357//Curriculum/GetById?id="+ this.state.IdCv, {
            method: 'Get',
            mode: 'cors',
            headers: {
              'Content-Type': 'application/json',
            },
          })
              .then(r => r.json().then(response => {
                this.setState({ Curriculum: response });
                console.log(response);
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
                    Currículo
                  </Typography>

                  <Grid container item xs={12} sm={8} md={4} >
                    <TextField
                    fullWidth
                    variant='outlined'
                    id='fullName'
                    label='Nome'
                    value={this.state.User.name} />

                    <TextField
                    fullWidth
                    variant='outlined'
                    id='email'
                    label='Email'
                    value={this.state.Userer.email}/>
                </Grid>
                </React.Fragment>
              )
            }
    
          </StepperContext.Consumer>
    
        );
      }
    }
    export default viewForm;