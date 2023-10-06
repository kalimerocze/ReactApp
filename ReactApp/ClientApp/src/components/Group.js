import React, { Component } from 'react';
import axios from 'axios';

export class Group extends Component {
    static displayName = Group.name;

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
            Group: { id: id, name: '' }
            ,
            loading: true
        };
    }

    async populateUzivatelData(id) {
        let self = this;
        axios
            .get(`https://localhost:44382/api/Group/` + id, {
                withCredentials: true
            })
            .then(res => {
                self.setState({ Group: res.data, loading: false });
            })
    }
    componentDidMount() {
        if (this.state.Group.id !== 0) {
            this.populateUzivatelData(this.state.Group.id);
        }
    }

    handle(e) {
        const newdata = { ...this.state.Group }
        newdata[e.target.id] = e.target.value
        this.setState({ Group: newdata, loading: false });
    }
    sendFormData(e) {
        e.preventDefault();
        var bodyFormData = new FormData();
        bodyFormData.append('Group', this.state.Group);

        axios({
            method: this.state.Group.id !== 0 ? 'put' : 'post',
            url: this.state.Group.id !== 0 ? `https://localhost:44382/api/group` : 'https://localhost:44382/api/group',
            data: this.state.Group,
            withCredentials: true,
            headers: {
                'Content-Type': 'application/json',
            },
        })
            .then((res) => {
                // Handle success
            })
            .catch(function (error) {
                // Handle error
                console.log(error);
            });
        return;
    }

    render() {
        return (
            <div>
                <form onSubmit={(e) => this.sendFormData(e)}>
                    <div>
                        <h1>Edit zam</h1>
                        {/*{this.state.Group.name}*/}
                    </div>
                    <input autoComplete="off" className="input is-hovered" type="text" placeholder="Name" onChange={(e) => this.handle(e)} id="name" value={this.state.Group.name} type="text"></input>
                    <button className="button is-success" type="submit" >Submit</button>
                </form>
            </div>
        );
    }
}

