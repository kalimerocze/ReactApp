import React, { Component } from 'react';
import axios from 'axios'; import { Link } from 'react-router-dom'

function callDelete(id) {
    axios
        .delete(`https://localhost:44382/api/user/` + id, {
            withCredentials: true
        })
        .then(res => {

        })
};
export class UserList extends Component {
    static displayName = UserList.name;

    constructor(props) {
        super(props);
        this.state = { forecasts: [], loading: true };
        this.state = { usereArray: [], loading: true };
    }

    componentDidMount() {
        this.populateUserList();
    }

    static renderUserListTable(usereArray) {
        return (<div>
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Login</th>
                        <th>Password</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody>
                    {usereArray.map(c =>
                        <tr key={c.id}>
                            <td>{c.id}</td>
                            <td>{c.name}</td>
                            <td>{c.login}</td>
                            <td>{c.password}</td>
                            <td>
                                <button className="btn btn-danger" onClick={() => callDelete(c.id)}  > Delete</button>
                                <Link className="btn btn-primary" to={`/user?id=${c.id}`} > Edit  </Link>
                            </td>
                        </tr>
                    )}
                </tbody>
            </table>
        </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : UserList.renderUserListTable(this.state.usereArray);

        return (
            <div>
                <h1 id="tabelLabel" >Uživatelé</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }
    
    async populateUserList() {
        let self = this;
        axios
            .get(`https://localhost:44382/api/user/`, {
                withCredentials: true
            })
            .then(res => {
                self.setState({ usereArray: res.data, loading: false });
            })
    }
}
