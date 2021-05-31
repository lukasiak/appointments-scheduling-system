import React, { Component } from 'react';
import axios from 'axios'; 

import { BASE_API_URL } from './../constants';

export class Appointments extends Component {
  static displayName = Appointments.name;

    constructor(props) {
        super(props);
        this.state = { appointments: [], loading: true };
    }

    componentDidMount() {
        this.populateData();
    }

    static renderTable(appointments) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                <tr>
                    <th>Name</th>
                    <th>Email</th>
                    <th>PhoneNumber</th>
                    <th>StartTime</th>
                    <th>EndTime</th>
                    <th>Date</th>
                    <th></th>
                </tr>
                </thead>
                <tbody>
                {appointments.map(appointment =>
                    <tr key={appointment.id}>
                        <td>{appointment.name}</td>
                        <td>{appointment.email}</td>
                        <td>{appointment.phoneNumber}</td>
                        <td>{appointment.startTime}</td>
                        <td>{appointment.endTime}</td>
                        <td>{appointment.date}</td>
                        <td></td>
                    </tr>
                )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Appointments.renderTable(this.state.appointments);

        return (
            <div>
                <h1>Appointments</h1>
                {contents}
            </div>
        );
    }

    async populateData() {
        fetch(`${BASE_API_URL}appointments`)
            .then(res => res.json())
            .then(jsonData => {
                this.setState({
                    appointments: jsonData,
                    loading: false
                })
            });
        // const response = await fetch('weatherforecast');
        // const data = await response.json();
        // this.setState({ appointments: data, loading: false });
    }
}
