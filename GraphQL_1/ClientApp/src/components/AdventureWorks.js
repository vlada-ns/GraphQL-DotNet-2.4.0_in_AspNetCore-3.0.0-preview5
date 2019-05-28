﻿import React, { Component } from 'react';

export class AdventureWorks extends Component {
    static displayName = AdventureWorks.name;

    constructor(props) {
        super(props);
        this.state = {
            forecasts: [],
            loading: true,
            productId: -1,
            graphqlQuery: `?query=
                            {
                                products {
                                    productId
                                    name
                                }
                            }`
        };

        this.setProductId = this.setProductId.bind(this);
        this.refreshProducts = this.refreshProducts.bind(this);
    }

    componentDidMount() {
        this.populateWeatherData();
    }

    static renderForecastsTable(forecasts) {
        return (
            <table className='table table-striped'>
                <thead>
                    <tr>
                        <th>ProductId</th>
                        <th>Name</th>
                        <th>ProductNumber</th>
                        <th>Color</th>
                    </tr>
                </thead>
                <tbody>
                    {forecasts.map(forecast =>
                        <tr key={forecast.productId}>
                            <td>{forecast.productId}</td>
                            <td>{forecast.name}</td>
                            <td>{forecast.productNumber}</td>
                            <td>{forecast.color}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    setProductId(event) {
        //const saveValue = event.target.value;
        this.setState({ productId: event.target.value });
    }

    refreshProducts(event) {
        this.populateWeatherData();
        this.render();
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : AdventureWorks.renderForecastsTable(this.state.forecasts);

        return (
            <div>
                <h1>Products</h1>
                <p>
                    <p>Search product by Id:
                    <input type="number" name="productId" onChange={this.setProductId} min={1} max={9999} />
                        <button onClick={this.refreshProducts}>Search</button>
                    </p>
                </p>
                {contents}
            </div>
        );
    }

    //////////////////////////   (3)   ////////////////////////////
    fetchDirectlyFromGraphQl() {
        const query = 
            `?query=
            {
                products {
                    productId
                    name
                }
            }`
    }


    async populateWeatherData() {
        const response = await fetch('api/Products/list?productId=' + this.state.productId);
        //const response = await fetch('graphql' + this.state.graphqlQuery);
        const data = await response.json();
        this.setState({ forecasts: data, loading: false });
    }
}