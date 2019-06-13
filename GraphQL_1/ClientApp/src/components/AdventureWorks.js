import React, { Component } from 'react';
import * as PropTypes from 'prop-types';
import '@devexpress/open-iconic-master/font/css/open-iconic-bootstrap.css';
import '@devexpress/dx-react-grid-bootstrap4/dist/dx-react-grid-bootstrap4.css';
import {
    FilteringState,
    SortingState,
    // IntegratedSorting,
    SelectionState,
    PagingState,
    CustomPaging,
    IntegratedSelection,
    DataTypeProvider,
    TreeDataState,
    CustomTreeData,
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
    TableColumnVisibility,
    TableTreeColumn,
    VirtualTable
} from '@devexpress/dx-react-grid-bootstrap4';

const FilterIcon = ({ type }) => {
    if (type === 'month') {
        return (
            <span className="d-block oi oi-calendar" />
        );
    }
    return <TableFilterRow.Icon type={type} />;
};

const ROOT_ID = '';

const getRowId = row => row.transactionId ? row.transactionId : row.productId;

//const getChildRows = (row, rootRows) => (row ? row.transactionHistory : rootRows);
const getChildRows = (currentRow, rootRows) => {
    if (currentRow) {
        if (currentRow.transactionId) {
            return null;
        }
        if (currentRow.transactionHistory) {
            return currentRow.transactionHistory;
        } else {
            return [];
        }
    } else {
        return rootRows;
    }

    //const childRows = rootRows.filter(r => r.productId === (currentRow.transactionId ? currentRow.productId : ROOT_ID));
    //if (childRows.length) {
    //    return childRows;
    //}
    //return currentRow && currentRow.hasItems ? [] : null;
};

const TableComponent = ({ ...restProps }) => (
    <Table.Table
        {...restProps}
        className="table-striped"
    />
);

const HighlightedCell = ({ value, style, ...restProps }) => (
    <Table.Cell
        {...restProps}
        style={{
            //backgroundColor: value < 5000 ? 'red' : undefined,
            //...style,
            backgroundColor: 'BurlyWood'
        }}
    >
         <span
            style={{
                color: undefined
            }}
        > 
            {value}
        </span>
    </Table.Cell>
);

const Cell = (props) => {
    const { column } = props;
    if (column.name === 'productSubcategoryId' || column.name === 'name2') {
        return <HighlightedCell {...props} />;
    }
    return <Table.Cell {...props} />;
};

const Root = props => <Grid.Root {...props} style={{ height: '100%', width: '100%', maxHeight: '50em' }} />;

export class AdventureWorks extends Component {
    static displayName = AdventureWorks.name;

    constructor(props) {
        super(props);
        this.state = {
            rows: [],
            columns: [
                { name: 'productId', title: 'Id' },
                { name: 'name', title: 'Name' },
                { name: 'transactionId', title: 'Trans Id' },
                { name: 'transactionType', title: 'Trans Type' },
                { name: 'productnumber', title: 'Number' },
                { name: 'makeFlag', title: 'Make flag' },
                { name: 'color', title: 'Color' },
                { name: 'standardCost', title: 'Cost' },
                { name: 'listPrice', title: 'Price' },
                { name: 'size', title: 'Size' },
                { name: 'sellStartDate', title: 'Sell start date' },
                { name: 'sellEndDate', title: 'Sell end date' },
                { name: 'productSubcategoryId', title: 'SubCat Id', getCellValue: row => (row.productSubcategory ? row.productSubcategory.productSubcategoryId : undefined) },
                { name: 'name2', title: 'SubCat name', getCellValue: row => (row.productSubcategory ? row.productSubcategory.name : undefined) }
            ],
            totalCount: 0,
            loading: true,
            queryString: ``,
            selection: [],
            currentPage: 0,
            pageSize: 10,
            pageSizes: [10, 20, 50, 100, 0],
            defaultHiddenColumnNames: [],
            lastQuery: '',
            filters: [],
            sorting: [{ columnName: 'productId', direction: 'asc' }],
            intColumns: ['productId'],
            dateColumns: ['sellStartDate'],
            intFilterOperations: ['equal', 'notEqual', 'greaterThan', 'greaterThanOrEqual', 'lessThan', 'lessThanOrEqual'],
            dateFilterOperations: ['month', 'contains', 'startsWith', 'endsWith'],
            tableColumnExtensions: [
                { columnName: 'productId' },
                { columnName: 'name', width: 200, wordWrapEnabled: true },
            ],
            defaultExpandedRowIds: [],
        };

        this.changeSelection = this.changeSelection.bind(this);

        this.changeCurrentPage = this.changeCurrentPage.bind(this);
        this.changePageSize = this.changePageSize.bind(this);
        this.changeFilters = this.changeFilters.bind(this);
        this.changeSorting = this.changeSorting.bind(this);
        this.changeExpandedRowIds = this.changeExpandedRowIds.bind(this);
    }

    componentDidMount() {
        this.loadData();
    }

    componentDidUpdate(prevProps, prevState) {
        const { currentPage, pageSize, filters, sorting } = this.state;

        var tmp1 = currentPage;
        var tmp2 = prevState.currentPage;
        var stopDebug = currentPage;

        if (currentPage != prevState.currentPage
            || pageSize != prevState.pageSize
            || filters != prevState.filters
            || sorting != prevState.sorting
        ) {
            this.createQueryString()
            this.loadData();
        }
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

    changeSelection(selection) {
        this.setState({ selection });
    }

    createQueryString() {
        let { pageSize, currentPage, totalCount, filters, sorting } = this.state;

        let qString = '';
        let after = pageSize * currentPage;
        let whereString = '';
        const columnSorting = sorting[0];
        let sortDirection = false;

        if (columnSorting.direction != "asc") {
            sortDirection = true;
        }

        if (pageSize == 0) {
            pageSize = totalCount;
        }

        if ((filters && filters.length) != 0) {
            for (let item of filters) {
                if (item.operation == "notContains") {
                    item.operation = "notEqual";
                }
                var where = `, where: { path: "${item.columnName}", comparison: "${item.operation}", value:"${item.value}"}`;
                whereString += where;

                after = -1;
                this.changeCurrentPage(0);
            }
        } else {
            if (pageSize * currentPage >= totalCount) {
                after = totalCount - pageSize;
            }

            if (after <= 0) {
                after = -1;
            }
        }

        qString = `graphql?query={
            productsConnection(
                first: ${pageSize},
                after: "${after}"
                ${whereString}
                ,orderBy: {
                    path: "${columnSorting.columnName}",
                    descending: ${sortDirection}
                }), {
                totalCount,
                items{ productId, name, productNumber, makeFlag, color, standardCost, listPrice, size, sellStartDate, sellEndDate,
                    productSubcategory { productSubcategoryId, name },
                    transactionHistory { transactionId, productId, transactionType } },
                pageInfo{ startCursor, endCursor, hasPreviousPage, hasNextPage }
            }
        }`;

        this.setState({ queryString: qString });
        return qString;
    }

    changeCurrentPage(currentPage) {
        this.setState({
            loading: true,
            currentPage,
        });
    }

    changePageSize(pageSize) {
        var { currentPage, totalCount } = this.state;

        if (pageSize == 0) {
            this.setState({ pageSize: totalCount })
        }

        var numberOfPages = Math.ceil((totalCount / pageSize) - 1);

        if (numberOfPages < currentPage) {
            this.changeCurrentPage(numberOfPages);
        }

        this.setState({ pageSize });
    }

    changeFilters(filters) {
        this.setState({
            loading: true,
            filters,
        });
    }

    changeSorting(sorting) {
        this.setState({
            loading: true,
            sorting,
        });
    }

    changeSearchValue(searchValue) {
        this.setState({
            loading: true,
            searchValue,
        });
    }

    changeExpandedRowIds(defaultExpandedRowIds) {
        this.setState({ defaultExpandedRowIds });
    }

    render() {
        const {
            rows,
            columns,
            totalCount,
            loading,
            pageSize,
            filters,
            intColumns,
            dateColumns,
            intFilterOperations,
            dateFilterOperations,
            sorting,
            tableColumnExtensions,
            defaultExpandedRowIds,
            selection
        } = this.state;

        //let contents = this.state.loading
        //    ? <p><em>Loading...</em></p>
        //    : AdventureWorks.renderProductsTable(rows, totalCount/*, this.state.selection, this.state.defaultHiddenColumnNames*/);

        if (loading) {
            return (
                <div className="text-center">
                    <div className="spinner-border" role="status">
                        <span class="sr-only">Loading...</span>
                    </div>
                </div>)
        }
        return (
            //<div>
            //    {contents}
            //</div>
            <div className="card">

                <Grid
                    rows={rows}
                    columns={columns}       /* Object.keys(rows[0]).map(function (key) {return { name: key, title: key }}) */
                    getRowId={getRowId}
                    rootComponent={Root}
                >

                    <DataTypeProvider
                        for={intColumns}
                        availableFilterOperations={intFilterOperations}
                    />

                    <DataTypeProvider
                        for={dateColumns}
                        availableFilterOperations={dateFilterOperations}
                    />

                    <TreeDataState defaultExpandedRowIds={defaultExpandedRowIds} onExpandedRowIdsChange={this.changeExpandedRowIds} />

                    { /* <CustomTreeData getChildRows={getChildRows} /> */}

                    <PagingState defaultCurrentPage={this.state.currentPage} defaultPageSize={pageSize} onCurrentPageChange={this.changeCurrentPage} onPageSizeChange={this.changePageSize} />
                    <CustomPaging totalCount={totalCount} />

                    <FilteringState defaultFilters={filters} onFiltersChange={this.changeFilters} />

                    <SortingState defaultSorting={sorting} onSortingChange={this.changeSorting} />
                    { /* <IntegratedSorting /> */ }

                    <SelectionState defaultSelection={selection} onSelectionChange={this.changeSelection} />

                    <CustomTreeData getChildRows={getChildRows} />

                    <VirtualTable columnExtensions={tableColumnExtensions} tableComponent={TableComponent} cellComponent={Cell} height="auto" />
                    <TableHeaderRow showSortingControls />
                    <TableColumnVisibility defaultHiddenColumnNames={this.state.defaultHiddenColumnNames} />
                    <TableSelection />

                    <Toolbar />
                    <ColumnChooser />
                    <TableFilterRow
                        showFilterSelector
                        iconComponent={FilterIcon}
                        messages={{ month: 'Month equals' }}
                    />
                    <PagingPanel pageSizes={this.state.pageSizes} />
                    <TableTreeColumn for="productId" />
                </Grid>
            </div>
        );
    }

    async loadData() {
        const queryString = this.createQueryString();
        //if (queryString === this.state.lastQuery) {
        //    this.setState({ loading: false });
        //    return;
        //}

        //fetch(queryString)
        //    .then(response => response.json())
        //    .then(data => data.data)
        //    .then(data => {
        //        if (data.productsConnection.totalCount != 0) {
        //            this.setState({
        //                rows: data.productsConnection.items,
        //                totalCount: data.productsConnection.totalCount,
        //                //loading: false,
        //            })
        //        }
        //        this.setState({ loading: false });
        //    })
        //    .catch(() => this.setState({ loading: false }));

        const response = await fetch(queryString);
        //if (response.ok) {
        const responseJson = await response.json();
        if (responseJson.data.productsConnection) {
            if (responseJson.data.productsConnection.totalCount != 0) {
                const data = responseJson.data.productsConnection;
                this.setState({ rows: data.items, totalCount: data.totalCount });
            } else {
                this.setState({ rows: [{ productId: null, name: null, productnumber: null, makeFlag: null, color: null, standardCost: null, listPrice: null, size: null, sellStartDate: null, sellEndDate: null }], totalCount: 0 });      //productId: null, name: null, productnumber: null, makeFlag: null, color: null, standardCost: null, listPrice: null, size: null, sellStartDate: null, sellEndDate: null
            }
        } else {
            this.setState({ rows: [{ productId: null, name: null, productnumber: null, makeFlag: null, color: null, standardCost: null, listPrice: null, size: null, sellStartDate: null, sellEndDate: null }], totalCount: 0 });
        }
        this.setState({ loading: false });

        //const response = await fetch(tmpString2);
        ////if (response.ok) {
        //const responseJson = await response.json();
        //djuif (responseJson.data.productsConnection) {
        //    if (responseJson.data.productsConnection.totalCount != 0) {
        //        const data = responseJson.data.productsConnection;
        //        this.setState({ rows: data.items, totalCount: data.totalCount });
        //    }
        //}
        //this.setState({ loading: false });

    //} 
    //else {
    //        throw Error(`Request rejected with status ${response.status}`);
    //    }

        //const response = await fetch(queryString);
        //const responseJson = await response.json();
        //const data = responseJson.data.productsConnection;
        //this.setState({ rows: data.items, totalCount: data.totalCount, loading: false });

        var tmp1 = this.state.totalCount;
        var stopDebug = queryString;
        var stopDebug2 = queryString;
    }
}

// GraphQL PLAYGROUND query
//
//query Products {
//    productsConnection(
//        first: 10,
//        after: "-1",
//        where: {
//            path: "productId",
//            comparison: "equal",
//            value: "3"
//        })
//    {
//        totalCount,
//            items{
//            productId,
//                name,
//                productNumber,
//                makeFlag,
//                color,
//                standardCost,
//                listPrice,
//                size,
//                sellStartDate,
//                sellEndDate
//        }
//    }
//}