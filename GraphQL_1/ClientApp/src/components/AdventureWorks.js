import React, { Component } from 'react';
import {
    SearchState, FilteringState, IntegratedFiltering, SortingState, IntegratedSorting, PagingState,
    IntegratedPaging, SelectionState
} from '@devexpress/dx-react-grid';
import {
    Grid, Table, TableHeaderRow, SearchPanel, PagingPanel, TableFilterRow,
    Toolbar, TableSelection, ColumnChooser, TableColumnVisibility
} from '@devexpress/dx-react-grid-bootstrap4';

import mySvg from './aperture.svg'

export class AdventureWorks extends Component {
    static displayName = AdventureWorks.name;

    constructor(props) {
        super(props);
        this.state = {
            productId: -411,
            rows: [],
            totalCount: 0,
            queryString: 'graphql?query={products(productId:-411){productId: productId, name, productNumber, makeFlag, color, standardCost, listPrice, size, sellStartDate, sellEndDate }}',
            products: [],
            loading: true,
            graphqlQuery: ``,
            selection: [],
            currentPage: 0,
            pageSize: 10,
            pageSizes: [10, 20, 50, 100, 0],
            defaultHiddenColumnNames: []
        };

        this.setProductId = this.setProductId.bind(this);
        this.refreshProducts = this.refreshProducts.bind(this);
        this.changeSelection = this.changeSelection.bind(this);

        this.changeCurrentPage = this.changeCurrentPage.bind(this);
        this.changePageSize = this.changePageSize.bind(this);
    }

    componentDidMount() {
        this.populateWeatherData();
    }

    //static renderProductsTable(products, defaultHiddenColumnNames) {
    //    return (
    //        <Grid
    //            rows={products}
    //            columns={Object.keys(products[0]).map(function (key) {
    //                    return { name: key, title: key }
    //                })
    //            }>

    //            <SearchState deafaultValue="" />
                
    //            <PagingState defaultCurrentPage={0} pageSize={10} />
    //            <IntegratedPaging />

    //            <FilteringState defaultFilters={[]} />
    //            <IntegratedFiltering />
                
    //            <SortingState defaultSorting={[{ columnName: 'productId', direction: 'asc' }]} />
    //            <IntegratedSorting />

    //            <SelectionState onSelectionChange={this.caller.changeSelection} />  {/* defaultSelection={selection} */}

    //            <Table />
    //            <TableHeaderRow allowSorting showSortingControls />
    //            <TableColumnVisibility defaultHiddenColumnNames={defaultHiddenColumnNames} />
    //            <TableSelection />
    //            <Toolbar />
    //            <ColumnChooser />
    //            <SearchPanel />
    //            <PagingPanel pageSizes={this.state.pageSizes} />
    //            <TableFilterRow />
    //        </Grid>
    //    );
    //}

    setProductId(event) {
        //const saveValue = event.target.value;
        this.setState({ productId: event.target.value });
    }

    changeSelection(event) {
        this.setState({ selection: event.target.value });
    }

    changeCurrentPage(event) {
        this.setState({ currentPage: event.target.value });
    }

    changePageSize(event) {
        this.setState({ pageSize: event.target.value });
    }

    refreshProducts(event) {
        if (this.state.productId == '') {
            this.state.productId = -411;
        }
        this.populateWeatherData();
        this.render();
    }

    render() {
        //let contents = this.state.loading
        //    ? <p><em>Loading...</em></p>
        //    : AdventureWorks.renderProductsTable(this.state.products, this.state.selection, this.state.defaultHiddenColumnNames);

        const products = this.state.products;
        const { currentPage, pageSizes } = this.state;

        if (this.state.loading) {
            return(
                <div>
                    Loading...
                </div>)
        }
        return (
            //<div>
            //    <h1>Products</h1>
            //    <img src={mySvg} alt="aperture" />

            //    <p>
            //        <p>Search product by Id:
            //        <input type="number" name="productId" onChange={this.setProductId} min={1} max={9999} />
            //            <button onClick={this.refreshProducts}>Search</button>
            //        </p>
            //    </p>
            //    {contents}
            //</div>
            <div className="card">
                <img src="..\open-iconic-master\svg\aperture.svg" alt="aperture" />
                <Grid
                    rows={products}
                    columns={Object.keys(products[0]).map(function (key) {
                        return { name: key, title: key }
                    })
                    }>

                    <SearchState deafaultValue={""} />

                    <PagingState defaultCurrentPage={this.state.currentPage} defaultPageSize={this.state.pageSize} />
                    <IntegratedPaging />

                    <FilteringState defaultFilters={[]} />
                    <IntegratedFiltering />

                    <SortingState defaultSorting={[{ columnName: 'productId', direction: 'asc' }]} />
                    <IntegratedSorting />

                    <SelectionState defaultSelection={this.state.selection} onSelectionChange={this.state.changeSelection} />

                    <Table />
                    <TableHeaderRow allowSorting showSortingControls />
                    <PagingPanel pageSizes={this.state.pageSizes} />
                    <TableColumnVisibility defaultHiddenColumnNames={this.state.defaultHiddenColumnNames} />
                    <TableSelection />
                    <Toolbar />
                    <ColumnChooser />
                    <SearchPanel />
                    <TableFilterRow />
                </Grid>
            </div>
        );
    }

    async populateWeatherData() {
        //this.state.graphqlQuery = "?query={products(productId:" + this.state.productId + "){productId: productId, name, productNumber, makeFlag, color, standardCost, listPrice, size, sellStartDate, sellEndDate }}"

        fetch(this.state.queryString)
            .then(response => response.json())
            .then(data => data.data)
            .then(data =>
                this.setState({
                    rows: data.products,
                    totalCount: data.totalCount,
                    products: data.products,
                    loading: false
                })).catch(() => this.setState({ loading: false }));
        this.state.lastQuery = this.state.queryString;

        ////const response = await fetch('graphql' + this.state.graphqlQuery);
        //const response = await fetch(this.state.queryString);
        //const data = await response.json();
        //const data2 = data.data.products;       //const data2 = data.items;
        //this.setState({ products: data2, loading: false });
    }
}