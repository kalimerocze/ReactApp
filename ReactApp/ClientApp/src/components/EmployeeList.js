import React, { Component } from 'react';
import axios from 'axios'; import { Link } from 'react-router-dom'

function callYourAPI(id) {
    axios
        .delete(`https://localhost:44382/api/employee/` + id, {
            withCredentials: true,
            'Content-Type': 'undefined',
            //'Content-Type': 'application/json',
           // credentials: 'include', crossDomain: true

        })
        .then(res => {

        }).then(r => {
            //prerenderujeme seznbam
            this.populateEmployeesData();
        }
        )

};
export class EmployeeList extends Component {
    static displayName = EmployeeList.name;

    constructor(props) {
        super(props);
        this.state = { employeeObj: [], loading: true };
    }

    componentDidMount() {
        this.populateEmployeesData();
    }

    static renderForecastsTable(employeeObj) {
        return (<div>
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Position</th>
                        <th>Surname</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody>
                    {employeeObj.map(employeeObj =>
                        <tr key={employeeObj.id}>
                            <td>{employeeObj.id}</td>
                            <td>{employeeObj.name}</td>
                            <td>{employeeObj.position}</td>
                            <td>{employeeObj.surname}</td>
                            <td>
                                <button className="btn btn-danger" onClick={() => callYourAPI(employeeObj.id)}> Delete</button>
                                <Link className="btn btn-primary" to={`Employee?id=${employeeObj.id}`} > Edit  </Link>
                            </td>
                        </tr>
                    )}
                </tbody>
            </table>
            {/*<Link to='/counter' target='_blank'> Counter  </Link>*/}
        </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : EmployeeList.renderForecastsTable(this.state.employeesforecast);

        return (
            <div>
                <h1 id="tabelLabel" >Seznam zaměstnanců</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async populateEmployeesData() {
        const response = await axios.get('https://localhost:44382/api/employee', {
            withCredentials: true
        });
        this.setState({ employeesforecast: response.data, loading: false });
    }

}
