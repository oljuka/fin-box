import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService'

export class SecurityPaperList extends Component {
  static displayName = SecurityPaperList.name;

  constructor(props) {
    super(props);
    this.state = { securityPapers: [], loading: true };
  }

  componentDidMount() {
    this.populateList();
  }

  static renderSecurityPaper(securityPapers) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Name</th>
            <th>Code</th>
            <th>Currency</th>
          </tr>
        </thead>
        <tbody>
          {securityPapers.map(securityPaper =>
            <tr key={securityPaper.id}>
              <td>{securityPaper.name}</td>
              <td>{securityPaper.code}</td>
		      <td>{securityPaper.currency}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
		: SecurityPaperList.renderSecurityPaper(this.state.securityPapers);

    return (
      <div>
        <h1 id="tabelLabel" >Security Papers</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

	async populateList() {
    const token = await authService.getAccessToken();
	const response = await fetch('securitypaper', {
      headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
    });
    const data = await response.json();
    this.setState({ securityPapers: data, loading: false });
  }
}


export default SecurityPaperList;
