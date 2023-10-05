import React, { Component } from 'react';
import { Container, Navbar } from 'reactstrap';
import './Footer.css';
import axios from 'axios';


export class Footer extends Component {
    static displayName = Footer.name;

    constructor(props) {
        super(props);

        this.state = {

            version: '0.0.0.0',
            user: ''
        };
    }

    async getUser() {
        let self = this;

        axios
            .get(`https://localhost:44382/api/userInfo/`, {
                withCredentials: true
            })
            .then(res => {
                self.setState({ user: res.data });
            }
            ).catch(error => {
                // Zpracování chyby
                console.log(error)
            });
    }

    async getVersion() {
        let self = this;
        axios
            .get(`https://localhost:44382/api/version/`, {
                withCredentials: true
            })
            .then(res => {
               // console.log(res.data)
                self.setState({ version: res.data });
            }
            ).catch(error => {
                // Zpracování chyby
                console.log(error)
            });
    }
    componentDidMount() {
        this.getVersion();
        this.getUser();
    }

    render() {
        return (
            <footer>
                <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
                    <Container>
                        <span>
                            {this.state.version}, user: {this.state.user}
                        </span>
                    </Container>
                </Navbar>
            </footer>
        );
    }
}
