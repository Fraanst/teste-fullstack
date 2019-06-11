import React, { Component } from 'react';
import Grid from '@material-ui/core/Grid';
import Typography from '@material-ui/core/Typography';
import TextField from '@material-ui/core/TextField';
import { StepperContext } from './FormPage';
import { Button } from '@material-ui/core';

class CurriculumForm extends Component {
  state = {
    resumo:     '',
    telefone:   '',
    linkedin:   '',
    Interesses: '',
    Site:       '',
    Competencias: '',
    Conquistas:   '',
    Observacao:   '',
    Empresa:      '',
    Cargo:      '',
    Atribuicoes: '',
    DateIn:      '',
    DateEnd:     '',
    Instituicao: '',
    Curso:       '',
    idUser: 0,
  }
  
  componentDidMount(){
    fetch("https://localhost:44357/User/GetId", {
      method: 'Get',
      mode: 'cors',
      headers: {
        'Content-Type': 'application/json',
      },
    })
      .then(response => {
        if (response === true){
          const idUser = response.data;
          this.setState({ idUser: response.data });
          console.log(this.state.idUser);
        }
        else
          throw new Error(`Não foi possível encontrar Id. ${response['errors'][0].message}`);
      })
      .catch(e => alert(e))
  }
  

  onChangeInput = (e) => {
   
    var value = e.target.value
    this.setState({ [e.target.name]: value })
  }


  handleSave = (setActiveStep) => {

    fetch("https://localhost:44357/Curriculum/Create", {
      method: 'POST',
      mode: 'cors',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(this.state),
    })
      .then(r => r.json().then(response => {
        if (response === true)
          setActiveStep(2);
        else
          throw new Error(`Não foi possível salvar o Currículo. ${response['errors'][0].message}`);
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
                Dados do Currículo
              </Typography>
              <Grid container spacing={3}>
                <Grid item xs={12} sm={6}>
                  <TextField
                    onChange={this.onChangeInput}
                    id="resumo"
                    name="resumo"
                    label="Resumo:"
                    fullWidth
                  />
                </Grid>
                <Grid item xs={12} sm={6}>
                  <TextField
                    onChange={this.onChangeInput}
                    id="Interesses"
                    name="Interesses"
                    label="Informe seus Interesses:"
                    fullWidth
                  />
                </Grid>
                <Grid item xs={12} sm={6}>
                  <TextField
                    required
                    onChange={this.onChangeInput}
                    id="telefone"
                    type="phone"
                    name="telefone"
                    label="Informe seu telefone:"
                    fullWidth
                  />
                </Grid>
                <Grid item xs={12} sm={6}>
                  <TextField
                    onChange={this.onChangeInput}
                    id="linkedin"
                    name="linkedin"
                    label="Informe seu linkedin:"
                    fullWidth
                  />
                </Grid>
                <Grid item xs={12} sm={6}>
                  <TextField
                    onChange={this.onChangeInput}
                    id="Site"
                    name="Site"
                    label="Informe seu Site:"
                    fullWidth
                  />
                </Grid>

                <Grid item xs={12} sm={6}>
                  <TextField
                    onChange={this.onChangeInput}
                    id="Competencias"
                    name="Competencias"
                    label="Informa uma Competências:"
                    fullWidth
                  />
                      <TextField
                    onChange={this.onChangeInput}
                    id="Nivel"
                    name="Nivel"
                    label="Informe seu Nivel:"
                    fullWidth
                  />
                </Grid>

                <Grid item xs={12} sm={6}>
                  <TextField
                    onChange={this.onChangeInput}
                    id="Conquistas"
                    name="Conquistas"
                    label="Informa uma Conquistas:"
                    fullWidth
                  />
                      <TextField
                    onChange={this.onChangeInput}
                    id="Observacao"
                    name="Observacao"
                    label="Observacao:"
                    fullWidth
                  />
                </Grid>

                <Grid item xs={12} sm={6}>
                <TextField
                    disabled
                    label="Experiência Profissional"
                    fullWidth
                  />
                  <TextField
                    required
                    onChange={this.onChangeInput}
                    id="Empresa"
                    name="Empresa"
                    label="Empresa:"
                    fullWidth
                  />
                      <TextField
                    required
                    onChange={this.onChangeInput}
                    id="Cargo"
                    name="Cargo"
                    label="Cargo:"
                    fullWidth
                  />
                    <TextField
                    required
                    onChange={this.onChangeInput}
                    id="Atribuicoes"
                    name="Atribuicoes"
                    label="Atribuicoes:"
                    fullWidth
                  />
                    <TextField
                    required
                    onChange={this.onChangeInput}
                    id="DateIn"
                    name="DateIn"
                    label="Data Inicial:"
                    fullWidth
                  />
                    <TextField

                    onChange={this.onChangeInput}
                    id="DateEnd"
                    name="DateEnd"
                    label="Data Final::"
                    fullWidth
                  />
                </Grid>

                <Grid item xs={12} sm={6}>
                <TextField
                    disabled
                    label="Formação Academica"
                    fullWidth
                  />
                
                  <TextField
                    required
                    onChange={this.onChangeInput}
                    id="Instituicao"
                    name="Instituicao"
                    label="Instituicao:"
                    fullWidth
                  />
                      <TextField
                    required
                    onChange={this.onChangeInput}
                    id="Curso"
                    name="Curso"
                    label="Curso:"
                    fullWidth
                  />
                    <TextField
                    required
                    onChange={this.onChangeInput}
                    id="Datein"
                    name="Datein"
                    label="Data Inicio:"
                    fullWidth
                  />
                    <TextField
                    onChange={this.onChangeInput}
                    id="DateEnd"
                    name="DateEnd"
                    label="Data Final::"
                    fullWidth
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

export default CurriculumForm;