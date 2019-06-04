import React, { Component } from 'react';
import {
    FilteringState,
    IntegratedFiltering,
    SortingState,
    IntegratedSorting,
    PagingState,
    IntegratedPaging,
    SelectionState
} from '@devexpress/dx-react-grid';
import {
    Grid,
    Table,
    TableHeaderRow,
    PagingPanel,
    TableFilterRow,
    Toolbar,
    TableSelection,
    ColumnChooser,
    TableColumnVisibility
} from '@devexpress/dx-react-grid-bootstrap4';
import mySvg from '../open-iconic-master/svg/aperture.svg'
//import { Loading } from '../../../theme-sources/bootstrap4/components/loading';

export class AdventureWorks extends Component {
    static displayName = AdventureWorks.name;

    constructor(props) {
        super(props);
        this.state = {
            productId: -411,
            rows: [],
            totalCount: 0,
            loading: true,
            graphqlQuery: ``,
            selection: [],
            currentPage: 0,
            pageSize: 10,
            pageSizes: [10, 20, 50, 100, 0],
            defaultHiddenColumnNames: [],
            lastQuery: ''
        };

        this.setProductId = this.setProductId.bind(this);
        this.refreshProducts = this.refreshProducts.bind(this);
        this.changeSelection = this.changeSelection.bind(this);

        this.changeCurrentPage = this.changeCurrentPage.bind(this);
        this.changePageSize = this.changePageSize.bind(this);
    }

    componentDidMount() {
        this.loadData();
    }

    componentDidUpdate() {
        this.loadData();
    }

    //static renderProductsTable(rows, defaultHiddenColumnNames) {
    //    return (
    //        <Grid
    //            rows={rows}
    //            columns={Object.keys(rows[0]).map(function (key) {
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

    queryStringMethod() {
        const { searchValue } = this.state;
        var qString = '';

        if (searchValue <= 0 || searchValue > 9999) {
            qString = 'graphql?query={products(productId:-411){productId:productId,name,productNumber,makeFlag,color,standardCost,listPrice,size,sellStartDate,sellEndDate}}';
        }
        else{
            qString = 'graphql?query={products(productId:' + searchValue + '){productId:productId,name,productNumber,makeFlag,color,standardCost,listPrice,size,sellStartDate,sellEndDate}}';
        }
        return qString;
    }

    setProductId(event) {
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
        this.loadData();
        this.render();
    }

    changeSearchValue(searchValue) {
        this.setState({
            loading: true,
            searchValue,
        });
    }

    render() {
        //let contents = this.state.loading
        //    ? <p><em>Loading...</em></p>
        //    : AdventureWorks.renderProductsTable(this.state.rows, this.state.selection, this.state.defaultHiddenColumnNames);

        const { rows, columns, loading, currentPage, pageSizes, searchValue } = this.state;

        if (this.state.loading) {
            return (
                <div className="text-center">
                    <div className="spinner-border" role="status">
                        <span class="sr-only">Loading...</span>
                    </div>
                </div>)
        }
        return (
            //<div>
            //    <h1>Products</h1>
            //    <p>
            //        <p>Search product by Id:
            //        <input type="number" name="productId" onChange={this.setProductId} min={1} max={9999} />
            //            <button onClick={this.refreshProducts}>Search</button>
            //        </p>
            //    </p>
            //    {contents}
            //</div>
            <div className="card">
                <img src={mySvg} alt="aperture" />
                <Grid
                    rows={rows}
                    columns={Object.keys(rows[0]).map(function (key) {
                        return { name: key, title: key }
                    })
                }>
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
                    <TableFilterRow />
                </Grid>
            </div>
        );
    }

    async loadData() {
        const queryString1 = 'graphql?query={products(productId:-411){productId:productId,name,productNumber,makeFlag,color,standardCost,listPrice,size,sellStartDate,sellEndDate}}';

        //graphql1?query={products(first:2,after:'2'){productId}}
        // https://localhost:44385/graphql/graphql1?query={products{productId}}

        fetch(queryString1)
            .then(response => response.json())
            .then(data => data.data)
            .then(data =>
                this.setState({
                    rows: data.products,
                    totalCount: data.totalCount,
                    loading: false,
                })).catch(() => this.setState({ loading: false }));
        this.state.lastQuery = this.state.queryString1;

        //const response = await fetch(this.state.queryString);
        //const data = await response.json();
        //const data2 = data.data.products;       //const data2 = data.items;
        //this.setState({ products: data2, loading: false });
    }
}