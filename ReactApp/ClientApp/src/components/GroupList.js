import React, { Component } from 'react';
import axios from 'axios'; import { Link } from 'react-router-dom'

function callDelete(id) {
    axios
        .delete(`https://localhost:44382/api/Group/` + id, {
            withCredentials: true
        })
        .then(res => {

        })
};
export class GroupList extends Component {
    static displayName = GroupList.name;

    constructor(props) {
        super(props);
        this.state = { forecasts: [], loading: true };
        this.state = { GroupArray: [], loading: true };
    }

    componentDidMount() {
        this.populateGroupList();
    }

    static renderGroupListTable(GroupArray) {
        return (<div>
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
             
                    </tr>
                </thead>
                <tbody>
                    {GroupArray.map(c =>
                        <tr key={c.id}>
                            <td>{c.id}</td>
                            <td>{c.name}</td>

                            <td>
                                <button className="btn btn-danger" onClick={() => callDelete(c.id)}  > Delete</button>
                                <Link className="btn btn-primary" to={`/Group?id=${c.id}`} > Edit  </Link>
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
            : GroupList.renderGroupListTable(this.state.GroupArray);

        return (
            <div>
                <h1 id="tabelLabel" >Uživatelé</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }
    
    async populateGroupList() {
        let self = this;
        axios
            .get(`https://localhost:44382/api/Group/`, {
                withCredentials: true
            })
            .then(res => {
                self.setState({ GroupArray: res.data, loading: false });
            })
    }
}
