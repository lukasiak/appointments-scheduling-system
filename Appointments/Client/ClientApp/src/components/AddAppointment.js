import React, { Component } from 'react';

import { BASE_API_URL } from './../constants';

export class AddAppointment extends Component {
    static displayName = AddAppointment.name;

    constructor(props) {
        super(props);
        this.state = {
            name: '',
            email: '',
            phoneNumber: '',
            startTime: '',
            endTime: '',
            date: ''
        }
    }

    addAppointment = () => {
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                name: this.state.name,
                email: this.state.email,
                phoneNumber: this.state.phoneNumber,
                startTime: this.state.startTime,
                endTime: this.state.endTime,
                date: new Date(this.state.date)
            })
        };
        fetch(`${BASE_API_URL}Appointments/CreateAppointment`, requestOptions)
            .then(res => {
                if (res.ok) {
                    this.props.history.push('/');
                }
                else {
                    throw Error("Should show error on page");
                }
            });
    }

    handleChange = (e) => {
        this.setState({ [e.target.name]: e.target.value });
    }

    render() {
        return (
            <form>
                <h2>Create appointment</h2>
                <div className="mb-3">
                    <label
                        htmlFor="name"
                        className="form-label">Name</label>
                    <input
                        type="text"
                        name="name"
                        className="form-control"
                        id="name"
                        onChange={this.handleChange}
                        value={this.state.name} />
                </div>
                <div className="mb-3">
                    <label
                        htmlFor="email"
                        className="form-label">Email</label>
                    <input
                        type="email"
                        name="email"
                        className="form-control"
                        id="email"
                        onChange={this.handleChange}
                        value={this.state.email} />
                </div>
                <div className="mb-3">
                    <label
                        htmlFor="phoneNumber"
                        className="form-label">PhoneNumber</label>
                    <input
                        type="text"
                        name="phoneNumber"
                        className="form-control"
                        id="phoneNumber"
                        onChange={this.handleChange}
                        value={this.state.phoneNumber} />
                </div>
                <div className="mb-3">
                    <label
                        htmlFor="startTime"
                        className="form-label">StartTime</label>
                    <input
                        type="time"
                        name="startTime"
                        className="form-control"
                        id="startTime"
                        onChange={this.handleChange}
                        value={this.state.startTime} />
                </div>
                <div className="mb-3">
                    <label
                        htmlFor="endTime"
                        className="form-label">EndTime</label>
                    <input
                        type="time"
                        name="endTime"
                        className="form-control"
                        id="endTime"
                        onChange={this.handleChange}
                        value={this.state.endTime} />
                </div>
                <div className="mb-3">
                    <label
                        htmlFor="date"
                        className="form-label">Date</label>
                    <input
                        type="date"
                        name="date"
                        className="form-control"
                        id="date"
                        onChange={this.handleChange}
                        value={this.state.date} />
                </div>
                <div className="mb-3">
                    <button
                        type="button"
                        onClick={this.addAppointment}
                        className="btn btn-success"
                        disabled={!this.state.name || !this.state.email || !this.state.phoneNumber || !this.state.startTime || !this.state.endTime || !this.state.date}>Submit</button>
                </div>
            </form>
        );
    }
}