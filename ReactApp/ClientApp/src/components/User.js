import React, { Component } from 'react';
import axios from 'axios';

export class User extends Component {
    static displayName = User.name;

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
            user: { id: id, name: '', surname: '', login: '', password: '' }
            ,
            loading: true
        };
    }

    async populateUzivatelData(id) {
        let self = this;
        axios
            .get(`https://localhost:44382/api/user/` + id, {
                withCredentials: true
            })
            .then(res => {
                self.setState({ user: res.data, loading: false });
            })
    }
    componentDidMount() {
        if (this.state.user.id !== 0) {
            this.populateUzivatelData(this.state.user.id);
        }
    }

    handle(e) {
        const newdata = { ...this.state.user }
        newdata[e.target.id] = e.target.value
        this.setState({ user: newdata, loading: false });
    }
    sendFormData(e) {
        e.preventDefault();
        var bodyFormData = new FormData();
        bodyFormData.append('user', this.state.user);

        axios({
            method: this.state.user.id !== 0 ? 'put' : 'post',
            url: this.state.user.id !== 0 ? `https://localhost:44382/api/user` : 'https://localhost:44382/api/user',
            data: this.state.user,
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
                        {/*{this.state.user.name}*/}
                    </div>
                    <input autoComplete="off" className="input is-hovered" type="text" placeholder="Name" onChange={(e) => this.handle(e)} id="name" value={this.state.user.name} type="text"></input>
                    <input autoComplete="off" className="input is-hovered" type="text" placeholder="Surname" onChange={(e) => this.handle(e)} id="surname" value={this.state.user.surname} type="text"></input>
                    <input autoComplete="off" className="input is-hovered" type="text" placeholder="Login" onChange={(e) => this.handle(e)} id="login" value={this.state.user.login} type="text"></input>
                    <input autoComplete="off" className="input is-hovered" type="text" placeholder="Password" onChange={(e) => this.handle(e)} id="password" value={this.state.user.password} type="text"></input>
                    <button className="button is-success" type="submit" >Submit</button>
                </form>
            </div>
        );
    }
}

