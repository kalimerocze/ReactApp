import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { EmployeeList } from './components/EmployeeList';
import { Counter } from './components/Counter';
import { User } from './components/User';
import { UserList } from './components/UserList';
import { Group } from './components/Group';
import { GroupList } from './components/GroupList';

import './custom.css'
import { Employee } from './components/Employee';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
            <Route path='/employee' component={Employee} />
            <Route path='/employeeList' component={EmployeeList} />
        <Route path='/user' component={User} />
        <Route path='/userList' component={UserList} />
        <Route path='/group' component={Group} />
        <Route path='/groupList' component={GroupList} />
      </Layout>
    );
  }
}
