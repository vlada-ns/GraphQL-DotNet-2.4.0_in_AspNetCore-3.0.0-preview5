import React, { Component } from 'react';
import { SelectionState, PagingState, IntegratedPaging, IntegratedSelection, SortingState } from '@devexpress/dx-react-grid';
import { Grid, Table, TableHeaderRow, TableSelection, PagingPanel } from '@devexpress/dx-react-grid-bootstrap4';

export class AdventureWorks extends Component {
    static displayName = AdventureWorks.name;

    constructor(props) {
        super(props);
        this.state = {
            products: [],
            loading: true,
            productId: -411,
            orderBy: "asc",
            graphqlQuery: ``,   //${this.state.productId=1}
            selection: []
        };

        this.setProductId = this.setProductId.bind(this);
        this.refreshProducts = this.refreshProducts.bind(this);
        this.changeSelection = selection => this.setState({ selection });
    }

    componentDidMount() {
        this.populateWeatherData();
    }

    static renderProductsTable(products, selection) {
        const tmp3 = Object.keys(products[0])[7]
        const tmp = Object.keys(products[0])[8]
        const tmp2 = Object.keys(products[0])[9]
        return (
            <Grid
                rows={products}
                columns={[
                    { name: Object.keys(products[0])[0], title: 'ID' },
                    { name: Object.keys(products[0])[1], title: 'Name' },
                    { name: Object.keys(products[0])[2], title: 'ProductNumber' },
                    { name: Object.keys(products[0])[3], title: 'MakeFlag' },
                    { name: Object.keys(products[0])[4], title: 'Color' },
                    { name: Object.keys(products[0])[5], title: 'StandardCost' },
                    { name: Object.keys(products[0])[6], title: 'ListPrice' },
                    { name: Object.keys(products[0])[7], title: 'Size' },
                    { name: Object.keys(products[0])[8], title: 'SellStartDate' },
                    { name: Object.keys(products[0])[9], title: 'SellEndDate' }
                ]}>

                <PagingState
                    defaultCurrentPage={0}
                    pageSize={6}
                />
                <SelectionState
                    selection={selection}
                    onSelectionChange={this.changeSelection}
                />
                <IntegratedPaging />
                <IntegratedSelection />
                <SortingState />

                <Table />
                <TableHeaderRow allowSorting />
                <TableSelection showSelectAll />
            </Grid>

            /*
            <table className='table table-striped table-bordered table-hover table-sm'>
                <thead class="thead-dark">
                    <tr>
                        <th scope="col">ProductId</th>
                        <th scope="col">Name</th>
                        <th scope="col">ProductNumber</th>
                        <th scope="col">makeFlag</th>
                        <th scope="col">Color</th>
                        <th scope="col">standardCost</th>
                        <th scope="col">listPrice</th>
                        <th scope="col">size</th>
                        <th scope="col">sellStartDate</th>
                        <th scope="col">sellEndDate</th>
                    </tr>
                </thead>
                <tbody>
                    {products.map(product =>
                        <tr key={product.productId}>
                            <th scope="row">{product.productId}</th>
                            <td>{product.name}</td>
                            <td>{product.productNumber}</td>
                            <td>{product.makeFlag}</td>
                            <td>{product.color}</td>
                            <td>{product.standardCost}</td>
                            <td>{product.listPrice}</td>
                            <td>{product.size}</td>
                            <td>{product.sellStartDate}</td>
                            <td>{product.sellEndDate}</td>
                        </tr>
                    )}
                </tbody>
            </table>
            */
        );
    }

    setProductId(event) {
        //const saveValue = event.target.value;
        this.setState({ productId: event.target.value });
    }

    refreshProducts(event) {
        if (this.state.productId == '') {
            this.state.productId = -411;
        }
        this.populateWeatherData();
        this.render();
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : AdventureWorks.renderProductsTable(this.state.products, this.state.selection);

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

    async populateWeatherData() {
        this.state.graphqlQuery = "?query={products(productId:" + this.state.productId + "){productId: productId, name, productNumber, makeFlag, color, standardCost, listPrice, size, sellStartDate, sellEndDate }}"
        const response = await fetch('graphql' + this.state.graphqlQuery);
        const data = await response.json();
        const data2 = data.data.products;
        this.setState({ products: data2, loading: false });
    }
}