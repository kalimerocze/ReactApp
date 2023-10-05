import React, { Component } from 'react';
import PostForm from './PostForm';
import {EmployeeList} from './EmployeeList';
import Product from './Product';

const handler = function handler(parametr) {
    console.log("Clicked" + parametr);
}

export class Home extends Component {
    static displayName = Home.name;

    render() {
        return (<div>

            <div className="tile is-ancestor">
                <div className="tile is-vertical is-8">
                    <div className="tile">
                        <div className="tile is-parent is-vertical">
                            <article className="tile is-child notification is-primary">
                                <p className="title">News</p>
                                <p className="subtitle">Subtitle</p>

                            </article>
                            <article className="tile is-child notification is-warning">
                                <p className="title">To be defined</p>
                                <p className="subtitle"></p>
                            </article>
                        </div>
                        <div className="tile is-parent">
                            <article className="tile is-child notification is-info">
                                <p className="title">Product</p>
                                <p className="subtitle">New Audi Q7</p>
                                <figure className="image is-4by3">
                                    <img src="./auto.jpg" />
                                </figure>
                            </article>
                        </div>
                    </div>
                    <div className="tile is-parent">
                        <article className="tile is-child notification is-danger">
                            <EmployeeList/>
                            <div className="content">
                            </div>
                        </article>
                    </div>
                </div>
            </div>
        </div>
        );
    }
}
