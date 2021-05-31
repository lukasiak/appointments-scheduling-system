import React, { Component } from 'react';
import { Route } from 'react-router';

import { Layout } from './components/Layout';
import { Appointments } from './components/Appointments';
import { AddAppointment } from './components/AddAppointment';

import './custom.css'

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Route exact path='/' component={Appointments} />
                <Route path='/add-appointment' component={AddAppointment} />
            </Layout>
        );
    }
}
