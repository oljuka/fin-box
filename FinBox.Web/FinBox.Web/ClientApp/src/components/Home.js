import React, { Component } from 'react';
import SecurityPaperList from './SecurityPaperList.js'

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Hello, world!</h1>
		<SecurityPaperList />
      </div>
    );
  }
}
