import React, { Component } from 'react';
import axios from 'axios';

export class Employee extends Component {
    static displayName = Employee.name;


    constructor(props) {
        super(props);
        var baseUrl = (window.location).href; // You can also use document.URL
        var id = 0;
        if (window.location.search.indexOf('id=') >= 0) {
            id = baseUrl.substring(baseUrl.lastIndexOf('=') + 1);
        }
        else {
            id = 0
        }
        this.state = {
            employeeObj: {
                id: id,
                name: '',
                surname: '',
                position: '',
                expiryDateOfContract: '',
            },
            loading: true
        };
    }

    async populateEmployeesData(id) {
        let self = this;
        axios
            .get(`https://localhost:44382/api/employee/` + id, {
                withCredentials: true,

            })
            .then(res => {
                self.setState({ employeeObj: res.data, loading: false });
            })
    }
    componentDidMount() {
        if (this.state.employeeObj.id !== 0) {
            this.populateEmployeesData(this.state.employeeObj.id);
        }
    }

    handle(e) {
        const newdata = { ...this.state.employeeObj }
        newdata[e.target.id] = e.target.value
        this.setState({ employeeObj: newdata, loading: false });
    }
    sendFormData(e) {
        e.preventDefault();
        if (this.state.employeeObj.id !== 0) {
            axios({
                method: 'put',
                url: 'https://localhost:44382/api/Employee',
                data: this.state.employeeObj,
                withCredentials: true, 
                headers: {
                    'Content-Type': 'application/json',
                },
            })
                .then((res) => {
                    // Handle success
                    //console.log(res);
                })
                .catch(function (error) {
                    // Handle error
                    console.log(error);
                });
            return;
        }

        axios({
            method: 'post',
            url: 'https://localhost:44382/api/Employee',
            data: this.state.employeeObj,
            withCredentials: true, // Povolení sCredentials
            headers: {
                'Content-Type': 'application/json',
            },
        })
            .then((res) => {
                // Handle success
                // console.log(res);
            })
            .catch(function (error) {
                // Handle error
                console.log(error);
            });
    }

    render() {
        return (
            <div>
                <form onSubmit={(e) => this.sendFormData(e)}>
                    <div>
                        <h1>Edit employee</h1>
                        {/*{this.state.employeeObj.name}*/}
                    </div>
                    <input autoComplete="off" className="input is-hovered" type="text" placeholder="Name" onChange={(e) => this.handle(e)} id="name" value={this.state.employeeObj.name} type="text"></input>
                    <input autoComplete="off" className="input is-hovered" type="text" placeholder="Surname" onChange={(e) => this.handle(e)} id="surname" value={this.state.employeeObj.surname} type="text"></input>
                    <input autoComplete="off" className="input is-hovered" type="text" placeholder="Job position" onChange={(e) => this.handle(e)} id="position" value={this.state.employeeObj.position} type="text"></input>
                    <input autoComplete="off" className="input is-hovered" type="text" placeholder="Contract expiration" onChange={(e) => this.handle(e)} id="expiryDateOfContract" value={this.state.employeeObj.expiryDateOfContract} type="text"></input>
                    <button className="button is-success" type="submit" >Submit</button>
                </form>
            </div>
        );
    }
}
