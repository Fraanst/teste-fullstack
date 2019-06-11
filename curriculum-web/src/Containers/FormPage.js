import React, { Component } from 'react';
import CssBaseline from '@material-ui/core/CssBaseline';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Paper from '@material-ui/core/Paper';
import Stepper from '@material-ui/core/Stepper';
import Step from '@material-ui/core/Step';
import StepLabel from '@material-ui/core/StepLabel';
import Button from '@material-ui/core/Button';
import Link from '@material-ui/core/Link';
import Typography from '@material-ui/core/Typography';
import UserForm from './UserForm';
import { withStyles } from '@material-ui/styles';
import CurriculumForm from './CurriculumForm';
import viewForm from './viewForm';

export const StepperContext = React.createContext({ activeStep: 0, setActiveStep: () => { } })

const styles = (theme) => ({
    appBar: {
        position: 'relative',
    },
    layout: {
        width: 'auto',
        marginLeft: theme.spacing(2),
        marginRight: theme.spacing(2),
        [theme.breakpoints.up(600 + theme.spacing(2) * 2)]: {
            width: 600,
            marginLeft: 'auto',
            marginRight: 'auto',
        },
    },
    paper: {
        marginTop: theme.spacing(3),
        marginBottom: theme.spacing(3),
        padding: theme.spacing(2),
        [theme.breakpoints.up(600 + theme.spacing(3) * 2)]: {
            marginTop: theme.spacing(6),
            marginBottom: theme.spacing(6),
            padding: theme.spacing(3),
        },
    },
    stepper: {
        padding: theme.spacing(3, 0, 5),
    },
});

const steps = ['Dados do usuário', 'Dados do currículo', 'Visualizar'];

function getStepContent(step) {
    switch (step) {
        case 0:
            return <UserForm />;
        case 1:
            return <CurriculumForm />;
        case 2:
            return <viewForm />;
        default:
            throw new Error('Unknown step');
    }
}

class FormPage extends Component {
    state = {
        activeStep: 0,
    }

    setActiveStep = (step) => {
        this.setState({
            activeStep: step
        });
    };

    render() {
        const { activeStep } = this.state;
        const { classes } = this.props;
        return (
            <StepperContext.Provider value={{activeStep, setActiveStep: this.setActiveStep}} >
                <React.Fragment>
                    <CssBaseline />
                    <AppBar position="absolute" color="default" className={classes.appBar}>
                        <Toolbar>
                            <Typography variant="h6" color="inherit" noWrap>
                                Curriculum
                            </Typography>
                        </Toolbar>
                    </AppBar>
                    <main className={classes.layout}>
                        <Paper className={classes.paper}>
                            <Stepper activeStep={activeStep} className={classes.stepper}>
                                {steps.map(label => (
                                    <Step key={label}>
                                        <StepLabel>{label}</StepLabel>
                                    </Step>
                                ))}
                            </Stepper>

                            <React.Fragment>
                                {getStepContent(activeStep)}
                            </React.Fragment>
                        </Paper>
                    </main>
                </React.Fragment>
            </StepperContext.Provider>
        );
    }

}

export default withStyles(styles)(FormPage);