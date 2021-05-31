import React, { Component } from 'react';
import { Link } from 'react-router-dom';

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

    static getDate(date) {
        var datetime = new Date(date);
        var dd = datetime.getDate();
        var mm = datetime.getMonth();
        var yyyy = datetime.getFullYear();

        if (dd < 10) {
            dd = '0' + dd;
        }

        if (mm < 10) {
            mm = '0' + mm;
        }

        return `${yyyy}-${mm}-${dd}`;
    }

    static getTime(date) {
        var datetime = new Date(date);
        var h = datetime.getHours();
        var m = datetime.getMinutes();

        if (h < 10) {
            h = '0' + h;
        }

        if (m < 10) {
            m = '0' + m;
        }

        return `${h}:${m}`;
    }

    static renderTable(appointments) {
        return (
            <>
                <div className="row">
                    <div className="col text-right">
                        <Link to="/add-appointment">
                            <button className="btn btn-sm btn-success">Add new appointment</button>
                        </Link>
                        <button className="btn btn-sm btn-success" disabled="disabled">Fetch data</button>
                    </div>
                </div>
                <table className="table table-striped" aria-labelledby="tabelLabel">
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
                            <td>{Appointments.getTime(appointment.startTime)}</td>
                            <td>{Appointments.getTime(appointment.endTime)}</td>
                            <td>{Appointments.getDate(appointment.date)}</td>
                            <td><button className="btn btn-sm btn-warning">Edit</button> | <button className="btn btn-sm btn-danger">Delete</button></td>
                        </tr>
                    )}
                    </tbody>
                </table>
            </>
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
        fetch(`${BASE_API_URL}Appointments`)
            .then(res => res.json())
            .then(jsonData => {
                this.setState({
                    appointments: jsonData,
                    loading: false
                })
            });
    }
}
