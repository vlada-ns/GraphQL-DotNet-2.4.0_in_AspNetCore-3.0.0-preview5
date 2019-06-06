using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GraphQL_1.Migrations
{
    public partial class added_classes_student_and_grade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Person");

            migrationBuilder.EnsureSchema(
                name: "Production");

            migrationBuilder.EnsureSchema(
                name: "Sales");

            migrationBuilder.EnsureSchema(
                name: "Demo");

            migrationBuilder.EnsureSchema(
                name: "HumanResources");

            migrationBuilder.EnsureSchema(
                name: "Purchasing");

            migrationBuilder.AlterDatabase()
                .Annotation("SqlServer:MemoryOptimized", true);

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AWBuildVersion",
                columns: table => new
                {
                    SystemInformationID = table.Column<byte>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatabaseVersion = table.Column<string>(name: "Database Version", maxLength: 25, nullable: false),
                    VersionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AWBuildVersion_SystemInformationID", x => x.SystemInformationID);
                });

            migrationBuilder.CreateTable(
                name: "DatabaseLog",
                columns: table => new
                {
                    DatabaseLogID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PostTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    DatabaseUser = table.Column<string>(maxLength: 128, nullable: false),
                    Event = table.Column<string>(maxLength: 128, nullable: false),
                    Schema = table.Column<string>(maxLength: 128, nullable: true),
                    Object = table.Column<string>(maxLength: 128, nullable: true),
                    TSQL = table.Column<string>(nullable: false),
                    XmlEvent = table.Column<string>(type: "xml", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatabaseLog_DatabaseLogID", x => x.DatabaseLogID)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "DeviceCodes",
                columns: table => new
                {
                    UserCode = table.Column<string>(maxLength: 200, nullable: false),
                    DeviceCode = table.Column<string>(maxLength: 200, nullable: false),
                    SubjectId = table.Column<string>(maxLength: 200, nullable: true),
                    ClientId = table.Column<string>(maxLength: 200, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Expiration = table.Column<DateTime>(nullable: false),
                    Data = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceCodes", x => x.UserCode);
                });

            migrationBuilder.CreateTable(
                name: "ErrorLog",
                columns: table => new
                {
                    ErrorLogID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ErrorTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UserName = table.Column<string>(maxLength: 128, nullable: false),
                    ErrorNumber = table.Column<int>(nullable: false),
                    ErrorSeverity = table.Column<int>(nullable: true),
                    ErrorState = table.Column<int>(nullable: true),
                    ErrorProcedure = table.Column<string>(maxLength: 126, nullable: true),
                    ErrorLine = table.Column<int>(nullable: true),
                    ErrorMessage = table.Column<string>(maxLength: 4000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorLog", x => x.ErrorLogID);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    GradeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GradeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.GradeId);
                });

            migrationBuilder.CreateTable(
                name: "PersistedGrants",
                columns: table => new
                {
                    Key = table.Column<string>(maxLength: 200, nullable: false),
                    Type = table.Column<string>(maxLength: 50, nullable: false),
                    SubjectId = table.Column<string>(maxLength: 200, nullable: true),
                    ClientId = table.Column<string>(maxLength: 200, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Expiration = table.Column<DateTime>(nullable: true),
                    Data = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersistedGrants", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "DemoSalesOrderDetailSeed",
                schema: "Demo",
                columns: table => new
                {
                    LocalID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderQty = table.Column<short>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    SpecialOfferID = table.Column<int>(nullable: false),
                    OrderID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DemoSale__499359DA37DC4424", x => x.LocalID)
                        .Annotation("SqlServer:Clustered", false);
                })
                .Annotation("SqlServer:MemoryOptimized", true);

            migrationBuilder.CreateTable(
                name: "DemoSalesOrderHeaderSeed",
                schema: "Demo",
                columns: table => new
                {
                    LocalID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DueDate = table.Column<DateTime>(nullable: false),
                    CustomerID = table.Column<int>(nullable: false),
                    SalesPersonID = table.Column<int>(nullable: false),
                    BillToAddressID = table.Column<int>(nullable: false),
                    ShipToAddressID = table.Column<int>(nullable: false),
                    ShipMethodID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DemoSale__499359DA31897820", x => x.LocalID)
                        .Annotation("SqlServer:Clustered", false);
                })
                .Annotation("SqlServer:MemoryOptimized", true);

            migrationBuilder.CreateTable(
                name: "Department",
                schema: "HumanResources",
                columns: table => new
                {
                    DepartmentID = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    GroupName = table.Column<string>(maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Employee_Temporal",
                schema: "HumanResources",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(nullable: false),
                    NationalIDNumber = table.Column<string>(maxLength: 15, nullable: false),
                    LoginID = table.Column<string>(maxLength: 256, nullable: false),
                    OrganizationLevel = table.Column<short>(nullable: true, computedColumnSql: "([OrganizationNode].[GetLevel]())"),
                    JobTitle = table.Column<string>(maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    MaritalStatus = table.Column<string>(maxLength: 1, nullable: false),
                    Gender = table.Column<string>(maxLength: 1, nullable: false),
                    HireDate = table.Column<DateTime>(type: "date", nullable: false),
                    VacationHours = table.Column<short>(nullable: false),
                    SickLeaveHours = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_History_BusinessEntityID", x => x.BusinessEntityID);
                });

            migrationBuilder.CreateTable(
                name: "Shift",
                schema: "HumanResources",
                columns: table => new
                {
                    ShiftID = table.Column<byte>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    StartTime = table.Column<TimeSpan>(nullable: false),
                    EndTime = table.Column<TimeSpan>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shift", x => x.ShiftID);
                });

            migrationBuilder.CreateTable(
                name: "AddressType",
                schema: "Person",
                columns: table => new
                {
                    AddressTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressType", x => x.AddressTypeID);
                });

            migrationBuilder.CreateTable(
                name: "BusinessEntity",
                schema: "Person",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessEntity", x => x.BusinessEntityID);
                });

            migrationBuilder.CreateTable(
                name: "ContactType",
                schema: "Person",
                columns: table => new
                {
                    ContactTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactType", x => x.ContactTypeID);
                });

            migrationBuilder.CreateTable(
                name: "CountryRegion",
                schema: "Person",
                columns: table => new
                {
                    CountryRegionCode = table.Column<string>(maxLength: 3, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryRegion_CountryRegionCode", x => x.CountryRegionCode);
                });

            migrationBuilder.CreateTable(
                name: "Person_json",
                schema: "Person",
                columns: table => new
                {
                    PersonID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonType = table.Column<string>(maxLength: 2, nullable: false),
                    NameStyle = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(maxLength: 8, nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Suffix = table.Column<string>(maxLength: 10, nullable: true),
                    EmailPromotion = table.Column<int>(nullable: false),
                    AdditionalContactInfo = table.Column<string>(nullable: true),
                    Demographics = table.Column<string>(nullable: true),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    PhoneNumbers = table.Column<string>(nullable: true),
                    EmailAddresses = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person_json_PersonID", x => x.PersonID);
                });

            migrationBuilder.CreateTable(
                name: "Person_Temporal",
                schema: "Person",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(nullable: false),
                    PersonType = table.Column<string>(maxLength: 2, nullable: false),
                    NameStyle = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(maxLength: 8, nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Suffix = table.Column<string>(maxLength: 10, nullable: true),
                    EmailPromotion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person_Temporal_BusinessEntityID", x => x.BusinessEntityID);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumberType",
                schema: "Person",
                columns: table => new
                {
                    PhoneNumberTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumberType", x => x.PhoneNumberTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Culture",
                schema: "Production",
                columns: table => new
                {
                    CultureID = table.Column<string>(maxLength: 6, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Culture", x => x.CultureID);
                });

            migrationBuilder.CreateTable(
                name: "Illustration",
                schema: "Production",
                columns: table => new
                {
                    IllustrationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Diagram = table.Column<string>(type: "xml", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Illustration", x => x.IllustrationID);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                schema: "Production",
                columns: table => new
                {
                    LocationID = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    CostRate = table.Column<decimal>(type: "smallmoney", nullable: false, defaultValueSql: "((0.00))"),
                    Availability = table.Column<decimal>(type: "decimal(8, 2)", nullable: false, defaultValueSql: "((0.00))"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationID);
                });

            migrationBuilder.CreateTable(
                name: "Product_inmem",
                schema: "Production",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ProductNumber = table.Column<string>(maxLength: 25, nullable: false),
                    MakeFlag = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    FinishedGoodsFlag = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    Color = table.Column<string>(maxLength: 15, nullable: true),
                    SafetyStockLevel = table.Column<short>(nullable: false),
                    ReorderPoint = table.Column<short>(nullable: false),
                    StandardCost = table.Column<decimal>(type: "money", nullable: false),
                    ListPrice = table.Column<decimal>(type: "money", nullable: false),
                    Size = table.Column<string>(maxLength: 5, nullable: true),
                    SizeUnitMeasureCode = table.Column<string>(maxLength: 3, nullable: true),
                    WeightUnitMeasureCode = table.Column<string>(maxLength: 3, nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(8, 2)", nullable: true),
                    DaysToManufacture = table.Column<int>(nullable: false),
                    ProductLine = table.Column<string>(maxLength: 2, nullable: true),
                    Class = table.Column<string>(maxLength: 2, nullable: true),
                    Style = table.Column<string>(maxLength: 2, nullable: true),
                    ProductSubcategoryID = table.Column<int>(nullable: true),
                    ProductModelID = table.Column<int>(nullable: true),
                    SellStartDate = table.Column<DateTime>(nullable: false),
                    SellEndDate = table.Column<DateTime>(nullable: true),
                    DiscontinuedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(sysdatetime())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("IMPK_Product_ProductID", x => x.ProductID)
                        .Annotation("SqlServer:Clustered", false);
                })
                .Annotation("SqlServer:MemoryOptimized", true);

            migrationBuilder.CreateTable(
                name: "Product_ondisk",
                schema: "Production",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ProductNumber = table.Column<string>(maxLength: 25, nullable: false),
                    MakeFlag = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    FinishedGoodsFlag = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    Color = table.Column<string>(maxLength: 15, nullable: true),
                    SafetyStockLevel = table.Column<short>(nullable: false),
                    ReorderPoint = table.Column<short>(nullable: false),
                    StandardCost = table.Column<decimal>(type: "money", nullable: false),
                    ListPrice = table.Column<decimal>(type: "money", nullable: false),
                    Size = table.Column<string>(maxLength: 5, nullable: true),
                    SizeUnitMeasureCode = table.Column<string>(maxLength: 3, nullable: true),
                    WeightUnitMeasureCode = table.Column<string>(maxLength: 3, nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(8, 2)", nullable: true),
                    DaysToManufacture = table.Column<int>(nullable: false),
                    ProductLine = table.Column<string>(maxLength: 2, nullable: true),
                    Class = table.Column<string>(maxLength: 2, nullable: true),
                    Style = table.Column<string>(maxLength: 2, nullable: true),
                    ProductSubcategoryID = table.Column<int>(nullable: true),
                    ProductModelID = table.Column<int>(nullable: true),
                    SellStartDate = table.Column<DateTime>(nullable: false),
                    SellEndDate = table.Column<DateTime>(nullable: true),
                    DiscontinuedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(sysdatetime())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("ODPK_Product_ProductID", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                schema: "Production",
                columns: table => new
                {
                    ProductCategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.ProductCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "ProductDescription",
                schema: "Production",
                columns: table => new
                {
                    ProductDescriptionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 400, nullable: false),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDescription", x => x.ProductDescriptionID);
                });

            migrationBuilder.CreateTable(
                name: "ProductModel",
                schema: "Production",
                columns: table => new
                {
                    ProductModelID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    CatalogDescription = table.Column<string>(type: "xml", nullable: true),
                    Instructions = table.Column<string>(type: "xml", nullable: true),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModel", x => x.ProductModelID);
                });

            migrationBuilder.CreateTable(
                name: "ProductPhoto",
                schema: "Production",
                columns: table => new
                {
                    ProductPhotoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ThumbNailPhoto = table.Column<byte[]>(nullable: true),
                    ThumbnailPhotoFileName = table.Column<string>(maxLength: 50, nullable: true),
                    LargePhoto = table.Column<byte[]>(nullable: true),
                    LargePhotoFileName = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPhoto", x => x.ProductPhotoID);
                });

            migrationBuilder.CreateTable(
                name: "ScrapReason",
                schema: "Production",
                columns: table => new
                {
                    ScrapReasonID = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrapReason", x => x.ScrapReasonID);
                });

            migrationBuilder.CreateTable(
                name: "TransactionHistoryArchive",
                schema: "Production",
                columns: table => new
                {
                    TransactionID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    ReferenceOrderID = table.Column<int>(nullable: false),
                    ReferenceOrderLineID = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    TransactionType = table.Column<string>(maxLength: 1, nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ActualCost = table.Column<decimal>(type: "money", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionHistoryArchive_TransactionID", x => x.TransactionID);
                });

            migrationBuilder.CreateTable(
                name: "UnitMeasure",
                schema: "Production",
                columns: table => new
                {
                    UnitMeasureCode = table.Column<string>(maxLength: 3, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitMeasure_UnitMeasureCode", x => x.UnitMeasureCode);
                });

            migrationBuilder.CreateTable(
                name: "ShipMethod",
                schema: "Purchasing",
                columns: table => new
                {
                    ShipMethodID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ShipBase = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    ShipRate = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipMethod", x => x.ShipMethodID);
                });

            migrationBuilder.CreateTable(
                name: "CreditCard",
                schema: "Sales",
                columns: table => new
                {
                    CreditCardID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CardType = table.Column<string>(maxLength: 50, nullable: false),
                    CardNumber = table.Column<string>(maxLength: 25, nullable: false),
                    ExpMonth = table.Column<byte>(nullable: false),
                    ExpYear = table.Column<short>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCard", x => x.CreditCardID);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                schema: "Sales",
                columns: table => new
                {
                    CurrencyCode = table.Column<string>(maxLength: 3, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency_CurrencyCode", x => x.CurrencyCode);
                });

            migrationBuilder.CreateTable(
                name: "OrderTracking",
                schema: "Sales",
                columns: table => new
                {
                    OrderTrackingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SalesOrderID = table.Column<int>(nullable: false),
                    CarrierTrackingNumber = table.Column<string>(maxLength: 25, nullable: true),
                    TrackingEventID = table.Column<int>(nullable: false),
                    EventDetails = table.Column<string>(maxLength: 2000, nullable: false),
                    EventDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTracking", x => x.OrderTrackingID);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrder_json",
                schema: "Sales",
                columns: table => new
                {
                    SalesOrderID = table.Column<int>(nullable: false),
                    RevisionNumber = table.Column<byte>(nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    DueDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ShipDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<byte>(nullable: false, defaultValueSql: "((1))"),
                    OnlineOrderFlag = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    SalesOrderNumber = table.Column<string>(maxLength: 25, nullable: false, computedColumnSql: "(isnull(N'SO'+CONVERT([nvarchar](23),[SalesOrderID]),N'*** ERROR ***'))"),
                    PurchaseOrderNumber = table.Column<string>(maxLength: 25, nullable: true),
                    AccountNumber = table.Column<string>(maxLength: 15, nullable: true),
                    CustomerID = table.Column<int>(nullable: false),
                    SalesPersonID = table.Column<int>(nullable: true),
                    TerritoryID = table.Column<int>(nullable: true),
                    BillToAddressID = table.Column<int>(nullable: true),
                    ShipToAddressID = table.Column<int>(nullable: true),
                    ShipMethodID = table.Column<int>(nullable: true),
                    CreditCardID = table.Column<int>(nullable: true),
                    CreditCardApprovalCode = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    CurrencyRateID = table.Column<int>(nullable: true),
                    SubTotal = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    TaxAmt = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    Freight = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    TotalDue = table.Column<decimal>(type: "money", nullable: false, computedColumnSql: "(isnull(([SubTotal]+[TaxAmt])+[Freight],(0)))"),
                    Comment = table.Column<string>(maxLength: 128, nullable: true),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SalesReasons = table.Column<string>(nullable: true),
                    OrderItems = table.Column<string>(nullable: true),
                    Info = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrder__json_SalesOrderID", x => x.SalesOrderID);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrderHeader_inmem",
                schema: "Sales",
                columns: table => new
                {
                    SalesOrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RevisionNumber = table.Column<byte>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    ShipDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false, defaultValueSql: "((1))"),
                    OnlineOrderFlag = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    PurchaseOrderNumber = table.Column<string>(maxLength: 25, nullable: true),
                    AccountNumber = table.Column<string>(maxLength: 15, nullable: true),
                    CustomerID = table.Column<int>(nullable: false),
                    SalesPersonID = table.Column<int>(nullable: false, defaultValueSql: "((-1))"),
                    TerritoryID = table.Column<int>(nullable: true),
                    BillToAddressID = table.Column<int>(nullable: false),
                    ShipToAddressID = table.Column<int>(nullable: false),
                    ShipMethodID = table.Column<int>(nullable: false),
                    CreditCardID = table.Column<int>(nullable: true),
                    CreditCardApprovalCode = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    CurrencyRateID = table.Column<int>(nullable: true),
                    SubTotal = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    TaxAmt = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    Freight = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    Comment = table.Column<string>(maxLength: 128, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SalesOrd__B14003C3270C320B", x => x.SalesOrderID)
                        .Annotation("SqlServer:Clustered", false);
                })
                .Annotation("SqlServer:MemoryOptimized", true);

            migrationBuilder.CreateTable(
                name: "SalesOrderHeader_ondisk",
                schema: "Sales",
                columns: table => new
                {
                    SalesOrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RevisionNumber = table.Column<byte>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    ShipDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false, defaultValueSql: "((1))"),
                    OnlineOrderFlag = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    PurchaseOrderNumber = table.Column<string>(maxLength: 25, nullable: true),
                    AccountNumber = table.Column<string>(maxLength: 15, nullable: true),
                    CustomerID = table.Column<int>(nullable: false),
                    SalesPersonID = table.Column<int>(nullable: false, defaultValueSql: "((-1))"),
                    TerritoryID = table.Column<int>(nullable: true),
                    BillToAddressID = table.Column<int>(nullable: false),
                    ShipToAddressID = table.Column<int>(nullable: false),
                    ShipMethodID = table.Column<int>(nullable: false),
                    CreditCardID = table.Column<int>(nullable: true),
                    CreditCardApprovalCode = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    CurrencyRateID = table.Column<int>(nullable: true),
                    SubTotal = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    TaxAmt = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    Freight = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    Comment = table.Column<string>(maxLength: 128, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SalesOrd__B14003C2B181FB70", x => x.SalesOrderID);
                });

            migrationBuilder.CreateTable(
                name: "SalesReason",
                schema: "Sales",
                columns: table => new
                {
                    SalesReasonID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ReasonType = table.Column<string>(maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesReason", x => x.SalesReasonID);
                });

            migrationBuilder.CreateTable(
                name: "SpecialOffer",
                schema: "Sales",
                columns: table => new
                {
                    SpecialOfferID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 255, nullable: false),
                    DiscountPct = table.Column<decimal>(type: "smallmoney", nullable: false, defaultValueSql: "((0.00))"),
                    Type = table.Column<string>(maxLength: 50, nullable: false),
                    Category = table.Column<string>(maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    MinQty = table.Column<int>(nullable: false),
                    MaxQty = table.Column<int>(nullable: true),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialOffer", x => x.SpecialOfferID);
                });

            migrationBuilder.CreateTable(
                name: "SpecialOffer_inmem",
                schema: "Sales",
                columns: table => new
                {
                    SpecialOfferID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 255, nullable: false),
                    DiscountPct = table.Column<decimal>(type: "smallmoney", nullable: false, defaultValueSql: "((0.00))"),
                    Type = table.Column<string>(maxLength: 50, nullable: false),
                    Category = table.Column<string>(maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    MinQty = table.Column<int>(nullable: false),
                    MaxQty = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(sysdatetime())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("IMPK_SpecialOffer_SpecialOfferID", x => x.SpecialOfferID)
                        .Annotation("SqlServer:Clustered", false);
                })
                .Annotation("SqlServer:MemoryOptimized", true);

            migrationBuilder.CreateTable(
                name: "SpecialOffer_ondisk",
                schema: "Sales",
                columns: table => new
                {
                    SpecialOfferID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 255, nullable: false),
                    DiscountPct = table.Column<decimal>(type: "smallmoney", nullable: false, defaultValueSql: "((0.00))"),
                    Type = table.Column<string>(maxLength: 50, nullable: false),
                    Category = table.Column<string>(maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    MinQty = table.Column<int>(nullable: false),
                    MaxQty = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(sysdatetime())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("ODPK_SpecialOffer_SpecialOfferID", x => x.SpecialOfferID);
                });

            migrationBuilder.CreateTable(
                name: "TrackingEvent",
                schema: "Sales",
                columns: table => new
                {
                    TrackingEventID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventName = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackingEvent", x => x.TrackingEventID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    GradeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "GradeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                schema: "Person",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(nullable: false),
                    PersonType = table.Column<string>(maxLength: 2, nullable: false),
                    NameStyle = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(maxLength: 8, nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Suffix = table.Column<string>(maxLength: 10, nullable: true),
                    EmailPromotion = table.Column<int>(nullable: false),
                    AdditionalContactInfo = table.Column<string>(type: "xml", nullable: true),
                    Demographics = table.Column<string>(type: "xml", nullable: true),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person_BusinessEntityID", x => x.BusinessEntityID);
                    table.ForeignKey(
                        name: "FK_Person_BusinessEntity_BusinessEntityID",
                        column: x => x.BusinessEntityID,
                        principalSchema: "Person",
                        principalTable: "BusinessEntity",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                schema: "Purchasing",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(nullable: false),
                    AccountNumber = table.Column<string>(maxLength: 15, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    CreditRating = table.Column<byte>(nullable: false),
                    PreferredVendorStatus = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    ActiveFlag = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    PurchasingWebServiceURL = table.Column<string>(maxLength: 1024, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor_BusinessEntityID", x => x.BusinessEntityID);
                    table.ForeignKey(
                        name: "FK_Vendor_BusinessEntity_BusinessEntityID",
                        column: x => x.BusinessEntityID,
                        principalSchema: "Person",
                        principalTable: "BusinessEntity",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesTerritory",
                schema: "Sales",
                columns: table => new
                {
                    TerritoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    CountryRegionCode = table.Column<string>(maxLength: 3, nullable: false),
                    Group = table.Column<string>(maxLength: 50, nullable: false),
                    SalesYTD = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    SalesLastYear = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    CostYTD = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    CostLastYear = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesTerritory_TerritoryID", x => x.TerritoryID);
                    table.ForeignKey(
                        name: "FK_SalesTerritory_CountryRegion_CountryRegionCode",
                        column: x => x.CountryRegionCode,
                        principalSchema: "Person",
                        principalTable: "CountryRegion",
                        principalColumn: "CountryRegionCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductSubcategory",
                schema: "Production",
                columns: table => new
                {
                    ProductSubcategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductCategoryID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSubcategory", x => x.ProductSubcategoryID);
                    table.ForeignKey(
                        name: "FK_ProductSubcategory_ProductCategory_ProductCategoryID",
                        column: x => x.ProductCategoryID,
                        principalSchema: "Production",
                        principalTable: "ProductCategory",
                        principalColumn: "ProductCategoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductModelIllustration",
                schema: "Production",
                columns: table => new
                {
                    ProductModelID = table.Column<int>(nullable: false),
                    IllustrationID = table.Column<int>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModelIllustration_ProductModelID_IllustrationID", x => new { x.ProductModelID, x.IllustrationID });
                    table.ForeignKey(
                        name: "FK_ProductModelIllustration_Illustration_IllustrationID",
                        column: x => x.IllustrationID,
                        principalSchema: "Production",
                        principalTable: "Illustration",
                        principalColumn: "IllustrationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductModelIllustration_ProductModel_ProductModelID",
                        column: x => x.ProductModelID,
                        principalSchema: "Production",
                        principalTable: "ProductModel",
                        principalColumn: "ProductModelID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductModelProductDescriptionCulture",
                schema: "Production",
                columns: table => new
                {
                    ProductModelID = table.Column<int>(nullable: false),
                    ProductDescriptionID = table.Column<int>(nullable: false),
                    CultureID = table.Column<string>(maxLength: 6, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModelProductDescriptionCulture_ProductModelID_ProductDescriptionID_CultureID", x => new { x.ProductModelID, x.ProductDescriptionID, x.CultureID });
                    table.ForeignKey(
                        name: "FK_ProductModelProductDescriptionCulture_Culture_CultureID",
                        column: x => x.CultureID,
                        principalSchema: "Production",
                        principalTable: "Culture",
                        principalColumn: "CultureID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductModelProductDescriptionCulture_ProductDescription_ProductDescriptionID",
                        column: x => x.ProductDescriptionID,
                        principalSchema: "Production",
                        principalTable: "ProductDescription",
                        principalColumn: "ProductDescriptionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductModelProductDescriptionCulture_ProductModel_ProductModelID",
                        column: x => x.ProductModelID,
                        principalSchema: "Production",
                        principalTable: "ProductModel",
                        principalColumn: "ProductModelID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CountryRegionCurrency",
                schema: "Sales",
                columns: table => new
                {
                    CountryRegionCode = table.Column<string>(maxLength: 3, nullable: false),
                    CurrencyCode = table.Column<string>(maxLength: 3, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryRegionCurrency_CountryRegionCode_CurrencyCode", x => new { x.CountryRegionCode, x.CurrencyCode });
                    table.ForeignKey(
                        name: "FK_CountryRegionCurrency_CountryRegion_CountryRegionCode",
                        column: x => x.CountryRegionCode,
                        principalSchema: "Person",
                        principalTable: "CountryRegion",
                        principalColumn: "CountryRegionCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CountryRegionCurrency_Currency_CurrencyCode",
                        column: x => x.CurrencyCode,
                        principalSchema: "Sales",
                        principalTable: "Currency",
                        principalColumn: "CurrencyCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyRate",
                schema: "Sales",
                columns: table => new
                {
                    CurrencyRateID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CurrencyRateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    FromCurrencyCode = table.Column<string>(maxLength: 3, nullable: false),
                    ToCurrencyCode = table.Column<string>(maxLength: 3, nullable: false),
                    AverageRate = table.Column<decimal>(type: "money", nullable: false),
                    EndOfDayRate = table.Column<decimal>(type: "money", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyRate", x => x.CurrencyRateID);
                    table.ForeignKey(
                        name: "FK_CurrencyRate_Currency_FromCurrencyCode",
                        column: x => x.FromCurrencyCode,
                        principalSchema: "Sales",
                        principalTable: "Currency",
                        principalColumn: "CurrencyCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurrencyRate_Currency_ToCurrencyCode",
                        column: x => x.ToCurrencyCode,
                        principalSchema: "Sales",
                        principalTable: "Currency",
                        principalColumn: "CurrencyCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecialOfferProduct_inmem",
                schema: "Sales",
                columns: table => new
                {
                    SpecialOfferID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(sysdatetime())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("IMPK_SpecialOfferProduct_SpecialOfferID_ProductID", x => new { x.SpecialOfferID, x.ProductID })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "IMFK_SpecialOfferProduct_Product_ProductID",
                        column: x => x.ProductID,
                        principalSchema: "Production",
                        principalTable: "Product_inmem",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "IMFK_SpecialOfferProduct_SpecialOffer_SpecialOfferID",
                        column: x => x.SpecialOfferID,
                        principalSchema: "Sales",
                        principalTable: "SpecialOffer_inmem",
                        principalColumn: "SpecialOfferID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("SqlServer:MemoryOptimized", true);

            migrationBuilder.CreateTable(
                name: "SpecialOfferProduct_ondisk",
                schema: "Sales",
                columns: table => new
                {
                    SpecialOfferID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(sysdatetime())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("ODPK_SpecialOfferProduct_SpecialOfferID_ProductID", x => new { x.SpecialOfferID, x.ProductID })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "ODFK_SpecialOfferProduct_Product_ProductID",
                        column: x => x.ProductID,
                        principalSchema: "Production",
                        principalTable: "Product_ondisk",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "ODFK_SpecialOfferProduct_SpecialOffer_SpecialOfferID",
                        column: x => x.SpecialOfferID,
                        principalSchema: "Sales",
                        principalTable: "SpecialOffer_ondisk",
                        principalColumn: "SpecialOfferID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "HumanResources",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(nullable: false),
                    NationalIDNumber = table.Column<string>(maxLength: 15, nullable: false),
                    LoginID = table.Column<string>(maxLength: 256, nullable: false),
                    OrganizationLevel = table.Column<short>(nullable: true, computedColumnSql: "([OrganizationNode].[GetLevel]())"),
                    JobTitle = table.Column<string>(maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    MaritalStatus = table.Column<string>(maxLength: 1, nullable: false),
                    Gender = table.Column<string>(maxLength: 1, nullable: false),
                    HireDate = table.Column<DateTime>(type: "date", nullable: false),
                    SalariedFlag = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    VacationHours = table.Column<short>(nullable: false),
                    SickLeaveHours = table.Column<short>(nullable: false),
                    CurrentFlag = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_BusinessEntityID", x => x.BusinessEntityID);
                    table.ForeignKey(
                        name: "FK_Employee_Person_BusinessEntityID",
                        column: x => x.BusinessEntityID,
                        principalSchema: "Person",
                        principalTable: "Person",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessEntityContact",
                schema: "Person",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(nullable: false),
                    PersonID = table.Column<int>(nullable: false),
                    ContactTypeID = table.Column<int>(nullable: false),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessEntityContact_BusinessEntityID_PersonID_ContactTypeID", x => new { x.BusinessEntityID, x.PersonID, x.ContactTypeID });
                    table.ForeignKey(
                        name: "FK_BusinessEntityContact_BusinessEntity_BusinessEntityID",
                        column: x => x.BusinessEntityID,
                        principalSchema: "Person",
                        principalTable: "BusinessEntity",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessEntityContact_ContactType_ContactTypeID",
                        column: x => x.ContactTypeID,
                        principalSchema: "Person",
                        principalTable: "ContactType",
                        principalColumn: "ContactTypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessEntityContact_Person_PersonID",
                        column: x => x.PersonID,
                        principalSchema: "Person",
                        principalTable: "Person",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmailAddress",
                schema: "Person",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(nullable: false),
                    EmailAddressID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmailAddress = table.Column<string>(maxLength: 50, nullable: true),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAddress_BusinessEntityID_EmailAddressID", x => new { x.BusinessEntityID, x.EmailAddressID });
                    table.ForeignKey(
                        name: "FK_EmailAddress_Person_BusinessEntityID",
                        column: x => x.BusinessEntityID,
                        principalSchema: "Person",
                        principalTable: "Person",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Password",
                schema: "Person",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(nullable: false),
                    PasswordHash = table.Column<string>(unicode: false, maxLength: 128, nullable: false),
                    PasswordSalt = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Password_BusinessEntityID", x => x.BusinessEntityID);
                    table.ForeignKey(
                        name: "FK_Password_Person_BusinessEntityID",
                        column: x => x.BusinessEntityID,
                        principalSchema: "Person",
                        principalTable: "Person",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonPhone",
                schema: "Person",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 25, nullable: false),
                    PhoneNumberTypeID = table.Column<int>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonPhone_BusinessEntityID_PhoneNumber_PhoneNumberTypeID", x => new { x.BusinessEntityID, x.PhoneNumber, x.PhoneNumberTypeID });
                    table.ForeignKey(
                        name: "FK_PersonPhone_Person_BusinessEntityID",
                        column: x => x.BusinessEntityID,
                        principalSchema: "Person",
                        principalTable: "Person",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonPhone_PhoneNumberType_PhoneNumberTypeID",
                        column: x => x.PhoneNumberTypeID,
                        principalSchema: "Person",
                        principalTable: "PhoneNumberType",
                        principalColumn: "PhoneNumberTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonCreditCard",
                schema: "Sales",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(nullable: false),
                    CreditCardID = table.Column<int>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonCreditCard_BusinessEntityID_CreditCardID", x => new { x.BusinessEntityID, x.CreditCardID });
                    table.ForeignKey(
                        name: "FK_PersonCreditCard_Person_BusinessEntityID",
                        column: x => x.BusinessEntityID,
                        principalSchema: "Person",
                        principalTable: "Person",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonCreditCard_CreditCard_CreditCardID",
                        column: x => x.CreditCardID,
                        principalSchema: "Sales",
                        principalTable: "CreditCard",
                        principalColumn: "CreditCardID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StateProvince",
                schema: "Person",
                columns: table => new
                {
                    StateProvinceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StateProvinceCode = table.Column<string>(maxLength: 3, nullable: false),
                    CountryRegionCode = table.Column<string>(maxLength: 3, nullable: false),
                    IsOnlyStateProvinceFlag = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    TerritoryID = table.Column<int>(nullable: false),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateProvince", x => x.StateProvinceID);
                    table.ForeignKey(
                        name: "FK_StateProvince_CountryRegion_CountryRegionCode",
                        column: x => x.CountryRegionCode,
                        principalSchema: "Person",
                        principalTable: "CountryRegion",
                        principalColumn: "CountryRegionCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StateProvince_SalesTerritory_TerritoryID",
                        column: x => x.TerritoryID,
                        principalSchema: "Sales",
                        principalTable: "SalesTerritory",
                        principalColumn: "TerritoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "Production",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ProductNumber = table.Column<string>(maxLength: 25, nullable: false),
                    MakeFlag = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    FinishedGoodsFlag = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    Color = table.Column<string>(maxLength: 15, nullable: true),
                    SafetyStockLevel = table.Column<short>(nullable: false),
                    ReorderPoint = table.Column<short>(nullable: false),
                    StandardCost = table.Column<decimal>(type: "money", nullable: false),
                    ListPrice = table.Column<decimal>(type: "money", nullable: false),
                    Size = table.Column<string>(maxLength: 5, nullable: true),
                    SizeUnitMeasureCode = table.Column<string>(maxLength: 3, nullable: true),
                    WeightUnitMeasureCode = table.Column<string>(maxLength: 3, nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(8, 2)", nullable: true),
                    DaysToManufacture = table.Column<int>(nullable: false),
                    ProductLine = table.Column<string>(maxLength: 2, nullable: true),
                    Class = table.Column<string>(maxLength: 2, nullable: true),
                    Style = table.Column<string>(maxLength: 2, nullable: true),
                    ProductSubcategoryID = table.Column<int>(nullable: true),
                    ProductModelID = table.Column<int>(nullable: true),
                    SellStartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    SellEndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DiscontinuedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Product_ProductModel_ProductModelID",
                        column: x => x.ProductModelID,
                        principalSchema: "Production",
                        principalTable: "ProductModel",
                        principalColumn: "ProductModelID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_ProductSubcategory_ProductSubcategoryID",
                        column: x => x.ProductSubcategoryID,
                        principalSchema: "Production",
                        principalTable: "ProductSubcategory",
                        principalColumn: "ProductSubcategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_UnitMeasure_SizeUnitMeasureCode",
                        column: x => x.SizeUnitMeasureCode,
                        principalSchema: "Production",
                        principalTable: "UnitMeasure",
                        principalColumn: "UnitMeasureCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_UnitMeasure_WeightUnitMeasureCode",
                        column: x => x.WeightUnitMeasureCode,
                        principalSchema: "Production",
                        principalTable: "UnitMeasure",
                        principalColumn: "UnitMeasureCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrderDetail_inmem",
                schema: "Sales",
                columns: table => new
                {
                    SalesOrderID = table.Column<int>(nullable: false),
                    SalesOrderDetailID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarrierTrackingNumber = table.Column<string>(maxLength: 25, nullable: true),
                    OrderQty = table.Column<short>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    SpecialOfferID = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: false),
                    UnitPriceDiscount = table.Column<decimal>(type: "money", nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("imPK_SalesOrderDetail_SalesOrderID_SalesOrderDetailID", x => new { x.SalesOrderID, x.SalesOrderDetailID })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "IMFK_SalesOrderDetail_SalesOrderHeader_SalesOrderID",
                        column: x => x.SalesOrderID,
                        principalSchema: "Sales",
                        principalTable: "SalesOrderHeader_inmem",
                        principalColumn: "SalesOrderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "IMFK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID",
                        columns: x => new { x.SpecialOfferID, x.ProductID },
                        principalSchema: "Sales",
                        principalTable: "SpecialOfferProduct_inmem",
                        principalColumns: new[] { "SpecialOfferID", "ProductID" },
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("SqlServer:MemoryOptimized", true);

            migrationBuilder.CreateTable(
                name: "SalesOrderDetail_ondisk",
                schema: "Sales",
                columns: table => new
                {
                    SalesOrderID = table.Column<int>(nullable: false),
                    SalesOrderDetailID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarrierTrackingNumber = table.Column<string>(maxLength: 25, nullable: true),
                    OrderQty = table.Column<short>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    SpecialOfferID = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: false),
                    UnitPriceDiscount = table.Column<decimal>(type: "money", nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ODPK_SalesOrderDetail_SalesOrderID_SalesOrderDetailID", x => new { x.SalesOrderID, x.SalesOrderDetailID });
                    table.ForeignKey(
                        name: "ODFK_SalesOrderDetail_SalesOrderHeader_SalesOrderID",
                        column: x => x.SalesOrderID,
                        principalSchema: "Sales",
                        principalTable: "SalesOrderHeader_ondisk",
                        principalColumn: "SalesOrderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "ODFK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID",
                        columns: x => new { x.SpecialOfferID, x.ProductID },
                        principalSchema: "Sales",
                        principalTable: "SpecialOfferProduct_ondisk",
                        principalColumns: new[] { "SpecialOfferID", "ProductID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDepartmentHistory",
                schema: "HumanResources",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(nullable: false),
                    DepartmentID = table.Column<short>(nullable: false),
                    ShiftID = table.Column<byte>(nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDepartmentHistory_BusinessEntityID_StartDate_DepartmentID", x => new { x.BusinessEntityID, x.StartDate, x.DepartmentID, x.ShiftID });
                    table.ForeignKey(
                        name: "FK_EmployeeDepartmentHistory_Employee_BusinessEntityID",
                        column: x => x.BusinessEntityID,
                        principalSchema: "HumanResources",
                        principalTable: "Employee",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeDepartmentHistory_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalSchema: "HumanResources",
                        principalTable: "Department",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeDepartmentHistory_Shift_ShiftID",
                        column: x => x.ShiftID,
                        principalSchema: "HumanResources",
                        principalTable: "Shift",
                        principalColumn: "ShiftID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePayHistory",
                schema: "HumanResources",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(nullable: false),
                    RateChangeDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Rate = table.Column<decimal>(type: "money", nullable: false),
                    PayFrequency = table.Column<byte>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePayHistory_BusinessEntityID_RateChangeDate", x => new { x.BusinessEntityID, x.RateChangeDate });
                    table.ForeignKey(
                        name: "FK_EmployeePayHistory_Employee_BusinessEntityID",
                        column: x => x.BusinessEntityID,
                        principalSchema: "HumanResources",
                        principalTable: "Employee",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobCandidate",
                schema: "HumanResources",
                columns: table => new
                {
                    JobCandidateID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BusinessEntityID = table.Column<int>(nullable: true),
                    Resume = table.Column<string>(type: "xml", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCandidate", x => x.JobCandidateID);
                    table.ForeignKey(
                        name: "FK_JobCandidate_Employee_BusinessEntityID",
                        column: x => x.BusinessEntityID,
                        principalSchema: "HumanResources",
                        principalTable: "Employee",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderHeader",
                schema: "Purchasing",
                columns: table => new
                {
                    PurchaseOrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RevisionNumber = table.Column<byte>(nullable: false),
                    Status = table.Column<byte>(nullable: false, defaultValueSql: "((1))"),
                    EmployeeID = table.Column<int>(nullable: false),
                    VendorID = table.Column<int>(nullable: false),
                    ShipMethodID = table.Column<int>(nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    ShipDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    SubTotal = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    TaxAmt = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    Freight = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    TotalDue = table.Column<decimal>(type: "money", nullable: false, computedColumnSql: "(isnull(([SubTotal]+[TaxAmt])+[Freight],(0)))"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderHeader_PurchaseOrderID", x => x.PurchaseOrderID);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderHeader_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalSchema: "HumanResources",
                        principalTable: "Employee",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderHeader_ShipMethod_ShipMethodID",
                        column: x => x.ShipMethodID,
                        principalSchema: "Purchasing",
                        principalTable: "ShipMethod",
                        principalColumn: "ShipMethodID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderHeader_Vendor_VendorID",
                        column: x => x.VendorID,
                        principalSchema: "Purchasing",
                        principalTable: "Vendor",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesPerson",
                schema: "Sales",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(nullable: false),
                    TerritoryID = table.Column<int>(nullable: true),
                    SalesQuota = table.Column<decimal>(type: "money", nullable: true),
                    Bonus = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    CommissionPct = table.Column<decimal>(type: "smallmoney", nullable: false, defaultValueSql: "((0.00))"),
                    SalesYTD = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    SalesLastYear = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPerson_BusinessEntityID", x => x.BusinessEntityID);
                    table.ForeignKey(
                        name: "FK_SalesPerson_Employee_BusinessEntityID",
                        column: x => x.BusinessEntityID,
                        principalSchema: "HumanResources",
                        principalTable: "Employee",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesPerson_SalesTerritory_TerritoryID",
                        column: x => x.TerritoryID,
                        principalSchema: "Sales",
                        principalTable: "SalesTerritory",
                        principalColumn: "TerritoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "Person",
                columns: table => new
                {
                    AddressID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressLine1 = table.Column<string>(maxLength: 60, nullable: false),
                    AddressLine2 = table.Column<string>(maxLength: 60, nullable: true),
                    City = table.Column<string>(maxLength: 30, nullable: false),
                    StateProvinceID = table.Column<int>(nullable: false),
                    PostalCode = table.Column<string>(maxLength: 15, nullable: false),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressID);
                    table.ForeignKey(
                        name: "FK_Address_StateProvince_StateProvinceID",
                        column: x => x.StateProvinceID,
                        principalSchema: "Person",
                        principalTable: "StateProvince",
                        principalColumn: "StateProvinceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesTaxRate",
                schema: "Sales",
                columns: table => new
                {
                    SalesTaxRateID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StateProvinceID = table.Column<int>(nullable: false),
                    TaxType = table.Column<byte>(nullable: false),
                    TaxRate = table.Column<decimal>(type: "smallmoney", nullable: false, defaultValueSql: "((0.00))"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesTaxRate", x => x.SalesTaxRateID);
                    table.ForeignKey(
                        name: "FK_SalesTaxRate_StateProvince_StateProvinceID",
                        column: x => x.StateProvinceID,
                        principalSchema: "Person",
                        principalTable: "StateProvince",
                        principalColumn: "StateProvinceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BillOfMaterials",
                schema: "Production",
                columns: table => new
                {
                    BillOfMaterialsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductAssemblyID = table.Column<int>(nullable: true),
                    ComponentID = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UnitMeasureCode = table.Column<string>(maxLength: 3, nullable: false),
                    BOMLevel = table.Column<short>(nullable: false),
                    PerAssemblyQty = table.Column<decimal>(type: "decimal(8, 2)", nullable: false, defaultValueSql: "((1.00))"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillOfMaterials_BillOfMaterialsID", x => x.BillOfMaterialsID)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_BillOfMaterials_Product_ComponentID",
                        column: x => x.ComponentID,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BillOfMaterials_Product_ProductAssemblyID",
                        column: x => x.ProductAssemblyID,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BillOfMaterials_UnitMeasure_UnitMeasureCode",
                        column: x => x.UnitMeasureCode,
                        principalSchema: "Production",
                        principalTable: "UnitMeasure",
                        principalColumn: "UnitMeasureCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductCostHistory",
                schema: "Production",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    StandardCost = table.Column<decimal>(type: "money", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCostHistory_ProductID_StartDate", x => new { x.ProductID, x.StartDate });
                    table.ForeignKey(
                        name: "FK_ProductCostHistory_Product_ProductID",
                        column: x => x.ProductID,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductInventory",
                schema: "Production",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false),
                    LocationID = table.Column<short>(nullable: false),
                    Shelf = table.Column<string>(maxLength: 10, nullable: false),
                    Bin = table.Column<byte>(nullable: false),
                    Quantity = table.Column<short>(nullable: false),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInventory_ProductID_LocationID", x => new { x.ProductID, x.LocationID });
                    table.ForeignKey(
                        name: "FK_ProductInventory_Location_LocationID",
                        column: x => x.LocationID,
                        principalSchema: "Production",
                        principalTable: "Location",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductInventory_Product_ProductID",
                        column: x => x.ProductID,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductListPriceHistory",
                schema: "Production",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ListPrice = table.Column<decimal>(type: "money", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductListPriceHistory_ProductID_StartDate", x => new { x.ProductID, x.StartDate });
                    table.ForeignKey(
                        name: "FK_ProductListPriceHistory_Product_ProductID",
                        column: x => x.ProductID,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductProductPhoto",
                schema: "Production",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false),
                    ProductPhotoID = table.Column<int>(nullable: false),
                    Primary = table.Column<bool>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductPhoto_ProductID_ProductPhotoID", x => new { x.ProductID, x.ProductPhotoID })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_ProductProductPhoto_Product_ProductID",
                        column: x => x.ProductID,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductProductPhoto_ProductPhoto_ProductPhotoID",
                        column: x => x.ProductPhotoID,
                        principalSchema: "Production",
                        principalTable: "ProductPhoto",
                        principalColumn: "ProductPhotoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductReview",
                schema: "Production",
                columns: table => new
                {
                    ProductReviewID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductID = table.Column<int>(nullable: false),
                    ReviewerName = table.Column<string>(maxLength: 50, nullable: false),
                    ReviewDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    EmailAddress = table.Column<string>(maxLength: 50, nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    Comments = table.Column<string>(maxLength: 3850, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReview", x => x.ProductReviewID);
                    table.ForeignKey(
                        name: "FK_ProductReview_Product_ProductID",
                        column: x => x.ProductID,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransactionHistory",
                schema: "Production",
                columns: table => new
                {
                    TransactionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductID = table.Column<int>(nullable: false),
                    ReferenceOrderID = table.Column<int>(nullable: false),
                    ReferenceOrderLineID = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    TransactionType = table.Column<string>(maxLength: 1, nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ActualCost = table.Column<decimal>(type: "money", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionHistory_TransactionID", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_TransactionHistory_Product_ProductID",
                        column: x => x.ProductID,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrder",
                schema: "Production",
                columns: table => new
                {
                    WorkOrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductID = table.Column<int>(nullable: false),
                    OrderQty = table.Column<int>(nullable: false),
                    StockedQty = table.Column<int>(nullable: false, computedColumnSql: "(isnull([OrderQty]-[ScrappedQty],(0)))"),
                    ScrappedQty = table.Column<short>(nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ScrapReasonID = table.Column<short>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrder", x => x.WorkOrderID);
                    table.ForeignKey(
                        name: "FK_WorkOrder_Product_ProductID",
                        column: x => x.ProductID,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkOrder_ScrapReason_ScrapReasonID",
                        column: x => x.ScrapReasonID,
                        principalSchema: "Production",
                        principalTable: "ScrapReason",
                        principalColumn: "ScrapReasonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductVendor",
                schema: "Purchasing",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false),
                    BusinessEntityID = table.Column<int>(nullable: false),
                    AverageLeadTime = table.Column<int>(nullable: false),
                    StandardPrice = table.Column<decimal>(type: "money", nullable: false),
                    LastReceiptCost = table.Column<decimal>(type: "money", nullable: true),
                    LastReceiptDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    MinOrderQty = table.Column<int>(nullable: false),
                    MaxOrderQty = table.Column<int>(nullable: false),
                    OnOrderQty = table.Column<int>(nullable: true),
                    UnitMeasureCode = table.Column<string>(maxLength: 3, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVendor_ProductID_BusinessEntityID", x => new { x.ProductID, x.BusinessEntityID });
                    table.ForeignKey(
                        name: "FK_ProductVendor_Vendor_BusinessEntityID",
                        column: x => x.BusinessEntityID,
                        principalSchema: "Purchasing",
                        principalTable: "Vendor",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductVendor_Product_ProductID",
                        column: x => x.ProductID,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductVendor_UnitMeasure_UnitMeasureCode",
                        column: x => x.UnitMeasureCode,
                        principalSchema: "Production",
                        principalTable: "UnitMeasure",
                        principalColumn: "UnitMeasureCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItem",
                schema: "Sales",
                columns: table => new
                {
                    ShoppingCartItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ShoppingCartID = table.Column<string>(maxLength: 50, nullable: false),
                    Quantity = table.Column<int>(nullable: false, defaultValueSql: "((1))"),
                    ProductID = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItem", x => x.ShoppingCartItemID);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItem_Product_ProductID",
                        column: x => x.ProductID,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecialOfferProduct",
                schema: "Sales",
                columns: table => new
                {
                    SpecialOfferID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialOfferProduct_SpecialOfferID_ProductID", x => new { x.SpecialOfferID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_SpecialOfferProduct_Product_ProductID",
                        column: x => x.ProductID,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecialOfferProduct_SpecialOffer_SpecialOfferID",
                        column: x => x.SpecialOfferID,
                        principalSchema: "Sales",
                        principalTable: "SpecialOffer",
                        principalColumn: "SpecialOfferID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderDetail",
                schema: "Purchasing",
                columns: table => new
                {
                    PurchaseOrderID = table.Column<int>(nullable: false),
                    PurchaseOrderDetailID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DueDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    OrderQty = table.Column<short>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: false),
                    LineTotal = table.Column<decimal>(type: "money", nullable: false, computedColumnSql: "(isnull([OrderQty]*[UnitPrice],(0.00)))"),
                    ReceivedQty = table.Column<decimal>(type: "decimal(8, 2)", nullable: false),
                    RejectedQty = table.Column<decimal>(type: "decimal(8, 2)", nullable: false),
                    StockedQty = table.Column<decimal>(type: "decimal(9, 2)", nullable: false, computedColumnSql: "(isnull([ReceivedQty]-[RejectedQty],(0.00)))"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderDetail_PurchaseOrderID_PurchaseOrderDetailID", x => new { x.PurchaseOrderID, x.PurchaseOrderDetailID });
                    table.ForeignKey(
                        name: "FK_PurchaseOrderDetail_Product_ProductID",
                        column: x => x.ProductID,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderDetail_PurchaseOrderHeader_PurchaseOrderID",
                        column: x => x.PurchaseOrderID,
                        principalSchema: "Purchasing",
                        principalTable: "PurchaseOrderHeader",
                        principalColumn: "PurchaseOrderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesPersonQuotaHistory",
                schema: "Sales",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(nullable: false),
                    QuotaDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    SalesQuota = table.Column<decimal>(type: "money", nullable: false),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPersonQuotaHistory_BusinessEntityID_QuotaDate", x => new { x.BusinessEntityID, x.QuotaDate });
                    table.ForeignKey(
                        name: "FK_SalesPersonQuotaHistory_SalesPerson_BusinessEntityID",
                        column: x => x.BusinessEntityID,
                        principalSchema: "Sales",
                        principalTable: "SalesPerson",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesTerritoryHistory",
                schema: "Sales",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(nullable: false),
                    TerritoryID = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesTerritoryHistory_BusinessEntityID_StartDate_TerritoryID", x => new { x.BusinessEntityID, x.StartDate, x.TerritoryID });
                    table.ForeignKey(
                        name: "FK_SalesTerritoryHistory_SalesPerson_BusinessEntityID",
                        column: x => x.BusinessEntityID,
                        principalSchema: "Sales",
                        principalTable: "SalesPerson",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesTerritoryHistory_SalesTerritory_TerritoryID",
                        column: x => x.TerritoryID,
                        principalSchema: "Sales",
                        principalTable: "SalesTerritory",
                        principalColumn: "TerritoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                schema: "Sales",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    SalesPersonID = table.Column<int>(nullable: true),
                    Demographics = table.Column<string>(type: "xml", nullable: true),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store_BusinessEntityID", x => x.BusinessEntityID);
                    table.ForeignKey(
                        name: "FK_Store_BusinessEntity_BusinessEntityID",
                        column: x => x.BusinessEntityID,
                        principalSchema: "Person",
                        principalTable: "BusinessEntity",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Store_SalesPerson_SalesPersonID",
                        column: x => x.SalesPersonID,
                        principalSchema: "Sales",
                        principalTable: "SalesPerson",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessEntityAddress",
                schema: "Person",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(nullable: false),
                    AddressID = table.Column<int>(nullable: false),
                    AddressTypeID = table.Column<int>(nullable: false),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessEntityAddress_BusinessEntityID_AddressID_AddressTypeID", x => new { x.BusinessEntityID, x.AddressID, x.AddressTypeID });
                    table.ForeignKey(
                        name: "FK_BusinessEntityAddress_Address_AddressID",
                        column: x => x.AddressID,
                        principalSchema: "Person",
                        principalTable: "Address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessEntityAddress_AddressType_AddressTypeID",
                        column: x => x.AddressTypeID,
                        principalSchema: "Person",
                        principalTable: "AddressType",
                        principalColumn: "AddressTypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessEntityAddress_BusinessEntity_BusinessEntityID",
                        column: x => x.BusinessEntityID,
                        principalSchema: "Person",
                        principalTable: "BusinessEntity",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrderRouting",
                schema: "Production",
                columns: table => new
                {
                    WorkOrderID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    OperationSequence = table.Column<short>(nullable: false),
                    LocationID = table.Column<short>(nullable: false),
                    ScheduledStartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ScheduledEndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ActualStartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ActualEndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ActualResourceHrs = table.Column<decimal>(type: "decimal(9, 4)", nullable: true),
                    PlannedCost = table.Column<decimal>(type: "money", nullable: false),
                    ActualCost = table.Column<decimal>(type: "money", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderRouting_WorkOrderID_ProductID_OperationSequence", x => new { x.WorkOrderID, x.ProductID, x.OperationSequence });
                    table.ForeignKey(
                        name: "FK_WorkOrderRouting_Location_LocationID",
                        column: x => x.LocationID,
                        principalSchema: "Production",
                        principalTable: "Location",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkOrderRouting_WorkOrder_WorkOrderID",
                        column: x => x.WorkOrderID,
                        principalSchema: "Production",
                        principalTable: "WorkOrder",
                        principalColumn: "WorkOrderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "Sales",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonID = table.Column<int>(nullable: true),
                    StoreID = table.Column<int>(nullable: true),
                    TerritoryID = table.Column<int>(nullable: true),
                    AccountNumber = table.Column<string>(unicode: false, maxLength: 10, nullable: false, computedColumnSql: "(isnull('AW'+[dbo].[ufnLeadingZeros]([CustomerID]),''))"),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_Customer_Person_PersonID",
                        column: x => x.PersonID,
                        principalSchema: "Person",
                        principalTable: "Person",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customer_Store_StoreID",
                        column: x => x.StoreID,
                        principalSchema: "Sales",
                        principalTable: "Store",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customer_SalesTerritory_TerritoryID",
                        column: x => x.TerritoryID,
                        principalSchema: "Sales",
                        principalTable: "SalesTerritory",
                        principalColumn: "TerritoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrderHeader",
                schema: "Sales",
                columns: table => new
                {
                    SalesOrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RevisionNumber = table.Column<byte>(nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    DueDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ShipDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<byte>(nullable: false, defaultValueSql: "((1))"),
                    OnlineOrderFlag = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    SalesOrderNumber = table.Column<string>(maxLength: 25, nullable: false, computedColumnSql: "(isnull(N'SO'+CONVERT([nvarchar](23),[SalesOrderID]),N'*** ERROR ***'))"),
                    PurchaseOrderNumber = table.Column<string>(maxLength: 25, nullable: true),
                    AccountNumber = table.Column<string>(maxLength: 15, nullable: true),
                    CustomerID = table.Column<int>(nullable: false),
                    SalesPersonID = table.Column<int>(nullable: true),
                    TerritoryID = table.Column<int>(nullable: true),
                    BillToAddressID = table.Column<int>(nullable: false),
                    ShipToAddressID = table.Column<int>(nullable: false),
                    ShipMethodID = table.Column<int>(nullable: false),
                    CreditCardID = table.Column<int>(nullable: true),
                    CreditCardApprovalCode = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    CurrencyRateID = table.Column<int>(nullable: true),
                    SubTotal = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    TaxAmt = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    Freight = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))"),
                    TotalDue = table.Column<decimal>(type: "money", nullable: false, computedColumnSql: "(isnull(([SubTotal]+[TaxAmt])+[Freight],(0)))"),
                    Comment = table.Column<string>(maxLength: 128, nullable: true),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderHeader_SalesOrderID", x => x.SalesOrderID);
                    table.ForeignKey(
                        name: "FK_SalesOrderHeader_Address_BillToAddressID",
                        column: x => x.BillToAddressID,
                        principalSchema: "Person",
                        principalTable: "Address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesOrderHeader_CreditCard_CreditCardID",
                        column: x => x.CreditCardID,
                        principalSchema: "Sales",
                        principalTable: "CreditCard",
                        principalColumn: "CreditCardID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesOrderHeader_CurrencyRate_CurrencyRateID",
                        column: x => x.CurrencyRateID,
                        principalSchema: "Sales",
                        principalTable: "CurrencyRate",
                        principalColumn: "CurrencyRateID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesOrderHeader_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalSchema: "Sales",
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesOrderHeader_SalesPerson_SalesPersonID",
                        column: x => x.SalesPersonID,
                        principalSchema: "Sales",
                        principalTable: "SalesPerson",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesOrderHeader_ShipMethod_ShipMethodID",
                        column: x => x.ShipMethodID,
                        principalSchema: "Purchasing",
                        principalTable: "ShipMethod",
                        principalColumn: "ShipMethodID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesOrderHeader_Address_ShipToAddressID",
                        column: x => x.ShipToAddressID,
                        principalSchema: "Person",
                        principalTable: "Address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesOrderHeader_SalesTerritory_TerritoryID",
                        column: x => x.TerritoryID,
                        principalSchema: "Sales",
                        principalTable: "SalesTerritory",
                        principalColumn: "TerritoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrderDetail",
                schema: "Sales",
                columns: table => new
                {
                    SalesOrderID = table.Column<int>(nullable: false),
                    SalesOrderDetailID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarrierTrackingNumber = table.Column<string>(maxLength: 25, nullable: true),
                    OrderQty = table.Column<short>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    SpecialOfferID = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: false),
                    UnitPriceDiscount = table.Column<decimal>(type: "money", nullable: false),
                    LineTotal = table.Column<decimal>(type: "numeric(38, 6)", nullable: false, computedColumnSql: "(isnull(([UnitPrice]*((1.0)-[UnitPriceDiscount]))*[OrderQty],(0.0)))"),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderDetail_SalesOrderID_SalesOrderDetailID", x => new { x.SalesOrderID, x.SalesOrderDetailID });
                    table.ForeignKey(
                        name: "FK_SalesOrderDetail_SalesOrderHeader_SalesOrderID",
                        column: x => x.SalesOrderID,
                        principalSchema: "Sales",
                        principalTable: "SalesOrderHeader",
                        principalColumn: "SalesOrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID",
                        columns: x => new { x.SpecialOfferID, x.ProductID },
                        principalSchema: "Sales",
                        principalTable: "SpecialOfferProduct",
                        principalColumns: new[] { "SpecialOfferID", "ProductID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrderHeaderSalesReason",
                schema: "Sales",
                columns: table => new
                {
                    SalesOrderID = table.Column<int>(nullable: false),
                    SalesReasonID = table.Column<int>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderHeaderSalesReason_SalesOrderID_SalesReasonID", x => new { x.SalesOrderID, x.SalesReasonID });
                    table.ForeignKey(
                        name: "FK_SalesOrderHeaderSalesReason_SalesOrderHeader_SalesOrderID",
                        column: x => x.SalesOrderID,
                        principalSchema: "Sales",
                        principalTable: "SalesOrderHeader",
                        principalColumn: "SalesOrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesOrderHeaderSalesReason_SalesReason_SalesReasonID",
                        column: x => x.SalesReasonID,
                        principalSchema: "Sales",
                        principalTable: "SalesReason",
                        principalColumn: "SalesReasonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "([NormalizedName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "([NormalizedUserName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_DeviceCode",
                table: "DeviceCodes",
                column: "DeviceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_ClientId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "ClientId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_Students_GradeId",
                table: "Students",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderID",
                schema: "Demo",
                table: "DemoSalesOrderDetailSeed",
                column: "OrderID")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "AK_Department_Name",
                schema: "HumanResources",
                table: "Department",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Employee_LoginID",
                schema: "HumanResources",
                table: "Employee",
                column: "LoginID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Employee_NationalIDNumber",
                schema: "HumanResources",
                table: "Employee",
                column: "NationalIDNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Employee_rowguid",
                schema: "HumanResources",
                table: "Employee",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDepartmentHistory_DepartmentID",
                schema: "HumanResources",
                table: "EmployeeDepartmentHistory",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDepartmentHistory_ShiftID",
                schema: "HumanResources",
                table: "EmployeeDepartmentHistory",
                column: "ShiftID");

            migrationBuilder.CreateIndex(
                name: "IX_JobCandidate_BusinessEntityID",
                schema: "HumanResources",
                table: "JobCandidate",
                column: "BusinessEntityID");

            migrationBuilder.CreateIndex(
                name: "AK_Shift_Name",
                schema: "HumanResources",
                table: "Shift",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Shift_StartTime_EndTime",
                schema: "HumanResources",
                table: "Shift",
                columns: new[] { "StartTime", "EndTime" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Address_rowguid",
                schema: "Person",
                table: "Address",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_StateProvinceID",
                schema: "Person",
                table: "Address",
                column: "StateProvinceID");

            migrationBuilder.CreateIndex(
                name: "IX_Address_AddressLine1_AddressLine2_City_StateProvinceID_PostalCode",
                schema: "Person",
                table: "Address",
                columns: new[] { "AddressLine1", "AddressLine2", "City", "StateProvinceID", "PostalCode" },
                unique: true,
                filter: "[AddressLine2] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "AK_AddressType_Name",
                schema: "Person",
                table: "AddressType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_AddressType_rowguid",
                schema: "Person",
                table: "AddressType",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_BusinessEntity_rowguid",
                schema: "Person",
                table: "BusinessEntity",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessEntityAddress_AddressID",
                schema: "Person",
                table: "BusinessEntityAddress",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessEntityAddress_AddressTypeID",
                schema: "Person",
                table: "BusinessEntityAddress",
                column: "AddressTypeID");

            migrationBuilder.CreateIndex(
                name: "AK_BusinessEntityAddress_rowguid",
                schema: "Person",
                table: "BusinessEntityAddress",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessEntityContact_ContactTypeID",
                schema: "Person",
                table: "BusinessEntityContact",
                column: "ContactTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessEntityContact_PersonID",
                schema: "Person",
                table: "BusinessEntityContact",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "AK_BusinessEntityContact_rowguid",
                schema: "Person",
                table: "BusinessEntityContact",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_ContactType_Name",
                schema: "Person",
                table: "ContactType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_CountryRegion_Name",
                schema: "Person",
                table: "CountryRegion",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmailAddress_EmailAddress",
                schema: "Person",
                table: "EmailAddress",
                column: "EmailAddress");

            migrationBuilder.CreateIndex(
                name: "PXML_Person_AddContact",
                schema: "Person",
                table: "Person",
                column: "AdditionalContactInfo");

            migrationBuilder.CreateIndex(
                name: "XMLVALUE_Person_Demographics",
                schema: "Person",
                table: "Person",
                column: "Demographics");

            migrationBuilder.CreateIndex(
                name: "AK_Person_rowguid",
                schema: "Person",
                table: "Person",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_LastName_FirstName_MiddleName",
                schema: "Person",
                table: "Person",
                columns: new[] { "LastName", "FirstName", "MiddleName" });

            migrationBuilder.CreateIndex(
                name: "IX_PersonPhone_PhoneNumber",
                schema: "Person",
                table: "PersonPhone",
                column: "PhoneNumber");

            migrationBuilder.CreateIndex(
                name: "IX_PersonPhone_PhoneNumberTypeID",
                schema: "Person",
                table: "PersonPhone",
                column: "PhoneNumberTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_StateProvince_CountryRegionCode",
                schema: "Person",
                table: "StateProvince",
                column: "CountryRegionCode");

            migrationBuilder.CreateIndex(
                name: "AK_StateProvince_Name",
                schema: "Person",
                table: "StateProvince",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_StateProvince_rowguid",
                schema: "Person",
                table: "StateProvince",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StateProvince_TerritoryID",
                schema: "Person",
                table: "StateProvince",
                column: "TerritoryID");

            migrationBuilder.CreateIndex(
                name: "AK_StateProvince_StateProvinceCode_CountryRegionCode",
                schema: "Person",
                table: "StateProvince",
                columns: new[] { "StateProvinceCode", "CountryRegionCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BillOfMaterials_ComponentID",
                schema: "Production",
                table: "BillOfMaterials",
                column: "ComponentID");

            migrationBuilder.CreateIndex(
                name: "IX_BillOfMaterials_UnitMeasureCode",
                schema: "Production",
                table: "BillOfMaterials",
                column: "UnitMeasureCode");

            migrationBuilder.CreateIndex(
                name: "AK_BillOfMaterials_ProductAssemblyID_ComponentID_StartDate",
                schema: "Production",
                table: "BillOfMaterials",
                columns: new[] { "ProductAssemblyID", "ComponentID", "StartDate" },
                unique: true)
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "AK_Culture_Name",
                schema: "Production",
                table: "Culture",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Location_Name",
                schema: "Production",
                table: "Location",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Product_Name",
                schema: "Production",
                table: "Product",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductModelID",
                schema: "Production",
                table: "Product",
                column: "ProductModelID");

            migrationBuilder.CreateIndex(
                name: "AK_Product_ProductNumber",
                schema: "Production",
                table: "Product",
                column: "ProductNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductSubcategoryID",
                schema: "Production",
                table: "Product",
                column: "ProductSubcategoryID");

            migrationBuilder.CreateIndex(
                name: "AK_Product_rowguid",
                schema: "Production",
                table: "Product",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_SizeUnitMeasureCode",
                schema: "Production",
                table: "Product",
                column: "SizeUnitMeasureCode");

            migrationBuilder.CreateIndex(
                name: "IX_Product_WeightUnitMeasureCode",
                schema: "Production",
                table: "Product",
                column: "WeightUnitMeasureCode");

            migrationBuilder.CreateIndex(
                name: "IX_Name",
                schema: "Production",
                table: "Product_inmem",
                column: "Name")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_ProductNumber",
                schema: "Production",
                table: "Product_inmem",
                column: "ProductNumber")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_Name",
                schema: "Production",
                table: "Product_ondisk",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_ProductNumber",
                schema: "Production",
                table: "Product_ondisk",
                column: "ProductNumber");

            migrationBuilder.CreateIndex(
                name: "AK_ProductCategory_Name",
                schema: "Production",
                table: "ProductCategory",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_ProductCategory_rowguid",
                schema: "Production",
                table: "ProductCategory",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_ProductDescription_rowguid",
                schema: "Production",
                table: "ProductDescription",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductInventory_LocationID",
                schema: "Production",
                table: "ProductInventory",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "PXML_ProductModel_CatalogDescription",
                schema: "Production",
                table: "ProductModel",
                column: "CatalogDescription");

            migrationBuilder.CreateIndex(
                name: "PXML_ProductModel_Instructions",
                schema: "Production",
                table: "ProductModel",
                column: "Instructions");

            migrationBuilder.CreateIndex(
                name: "AK_ProductModel_Name",
                schema: "Production",
                table: "ProductModel",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_ProductModel_rowguid",
                schema: "Production",
                table: "ProductModel",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductModelIllustration_IllustrationID",
                schema: "Production",
                table: "ProductModelIllustration",
                column: "IllustrationID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductModelProductDescriptionCulture_CultureID",
                schema: "Production",
                table: "ProductModelProductDescriptionCulture",
                column: "CultureID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductModelProductDescriptionCulture_ProductDescriptionID",
                schema: "Production",
                table: "ProductModelProductDescriptionCulture",
                column: "ProductDescriptionID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductPhoto_ProductPhotoID",
                schema: "Production",
                table: "ProductProductPhoto",
                column: "ProductPhotoID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReview_ProductID",
                schema: "Production",
                table: "ProductReview",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReview_ProductID_Name",
                schema: "Production",
                table: "ProductReview",
                columns: new[] { "Comments", "ProductID", "ReviewerName" });

            migrationBuilder.CreateIndex(
                name: "AK_ProductSubcategory_Name",
                schema: "Production",
                table: "ProductSubcategory",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductSubcategory_ProductCategoryID",
                schema: "Production",
                table: "ProductSubcategory",
                column: "ProductCategoryID");

            migrationBuilder.CreateIndex(
                name: "AK_ProductSubcategory_rowguid",
                schema: "Production",
                table: "ProductSubcategory",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_ScrapReason_Name",
                schema: "Production",
                table: "ScrapReason",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistory_ProductID",
                schema: "Production",
                table: "TransactionHistory",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistory_ReferenceOrderID_ReferenceOrderLineID",
                schema: "Production",
                table: "TransactionHistory",
                columns: new[] { "ReferenceOrderID", "ReferenceOrderLineID" });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistoryArchive_ProductID",
                schema: "Production",
                table: "TransactionHistoryArchive",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistoryArchive_ReferenceOrderID_ReferenceOrderLineID",
                schema: "Production",
                table: "TransactionHistoryArchive",
                columns: new[] { "ReferenceOrderID", "ReferenceOrderLineID" });

            migrationBuilder.CreateIndex(
                name: "AK_UnitMeasure_Name",
                schema: "Production",
                table: "UnitMeasure",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrder_ProductID",
                schema: "Production",
                table: "WorkOrder",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrder_ScrapReasonID",
                schema: "Production",
                table: "WorkOrder",
                column: "ScrapReasonID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderRouting_LocationID",
                schema: "Production",
                table: "WorkOrderRouting",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderRouting_ProductID",
                schema: "Production",
                table: "WorkOrderRouting",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVendor_BusinessEntityID",
                schema: "Purchasing",
                table: "ProductVendor",
                column: "BusinessEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVendor_UnitMeasureCode",
                schema: "Purchasing",
                table: "ProductVendor",
                column: "UnitMeasureCode");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderDetail_ProductID",
                schema: "Purchasing",
                table: "PurchaseOrderDetail",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderHeader_EmployeeID",
                schema: "Purchasing",
                table: "PurchaseOrderHeader",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderHeader_ShipMethodID",
                schema: "Purchasing",
                table: "PurchaseOrderHeader",
                column: "ShipMethodID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderHeader_VendorID",
                schema: "Purchasing",
                table: "PurchaseOrderHeader",
                column: "VendorID");

            migrationBuilder.CreateIndex(
                name: "AK_ShipMethod_Name",
                schema: "Purchasing",
                table: "ShipMethod",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_ShipMethod_rowguid",
                schema: "Purchasing",
                table: "ShipMethod",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Vendor_AccountNumber",
                schema: "Purchasing",
                table: "Vendor",
                column: "AccountNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CountryRegionCurrency_CurrencyCode",
                schema: "Sales",
                table: "CountryRegionCurrency",
                column: "CurrencyCode");

            migrationBuilder.CreateIndex(
                name: "AK_CreditCard_CardNumber",
                schema: "Sales",
                table: "CreditCard",
                column: "CardNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Currency_Name",
                schema: "Sales",
                table: "Currency",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyRate_FromCurrencyCode",
                schema: "Sales",
                table: "CurrencyRate",
                column: "FromCurrencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyRate_ToCurrencyCode",
                schema: "Sales",
                table: "CurrencyRate",
                column: "ToCurrencyCode");

            migrationBuilder.CreateIndex(
                name: "AK_CurrencyRate_CurrencyRateDate_FromCurrencyCode_ToCurrencyCode",
                schema: "Sales",
                table: "CurrencyRate",
                columns: new[] { "CurrencyRateDate", "FromCurrencyCode", "ToCurrencyCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Customer_AccountNumber",
                schema: "Sales",
                table: "Customer",
                column: "AccountNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_PersonID",
                schema: "Sales",
                table: "Customer",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "AK_Customer_rowguid",
                schema: "Sales",
                table: "Customer",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_StoreID",
                schema: "Sales",
                table: "Customer",
                column: "StoreID");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_TerritoryID",
                schema: "Sales",
                table: "Customer",
                column: "TerritoryID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTracking_CarrierTrackingNumber",
                schema: "Sales",
                table: "OrderTracking",
                column: "CarrierTrackingNumber");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTracking_SalesOrderID",
                schema: "Sales",
                table: "OrderTracking",
                column: "SalesOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonCreditCard_CreditCardID",
                schema: "Sales",
                table: "PersonCreditCard",
                column: "CreditCardID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderDetail_ProductID",
                schema: "Sales",
                table: "SalesOrderDetail",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "AK_SalesOrderDetail_rowguid",
                schema: "Sales",
                table: "SalesOrderDetail",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderDetail_SpecialOfferID_ProductID",
                schema: "Sales",
                table: "SalesOrderDetail",
                columns: new[] { "SpecialOfferID", "ProductID" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductID",
                schema: "Sales",
                table: "SalesOrderDetail_inmem",
                column: "ProductID")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderID",
                schema: "Sales",
                table: "SalesOrderDetail_inmem",
                column: "SalesOrderID")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderDetail_inmem_SpecialOfferID_ProductID",
                schema: "Sales",
                table: "SalesOrderDetail_inmem",
                columns: new[] { "SpecialOfferID", "ProductID" })
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_ProductID",
                schema: "Sales",
                table: "SalesOrderDetail_ondisk",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderDetail_ondisk_SpecialOfferID_ProductID",
                schema: "Sales",
                table: "SalesOrderDetail_ondisk",
                columns: new[] { "SpecialOfferID", "ProductID" });

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderHeader_BillToAddressID",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "BillToAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderHeader_CreditCardID",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "CreditCardID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderHeader_CurrencyRateID",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "CurrencyRateID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderHeader_CustomerID",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "AK_SalesOrderHeader_rowguid",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_SalesOrderHeader_SalesOrderNumber",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "SalesOrderNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderHeader_SalesPersonID",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "SalesPersonID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderHeader_ShipMethodID",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "ShipMethodID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderHeader_ShipToAddressID",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "ShipToAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderHeader_TerritoryID",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "TerritoryID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerID",
                schema: "Sales",
                table: "SalesOrderHeader_inmem",
                column: "CustomerID")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_SalesPersonID",
                schema: "Sales",
                table: "SalesOrderHeader_inmem",
                column: "SalesPersonID")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerID",
                schema: "Sales",
                table: "SalesOrderHeader_ondisk",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPersonID",
                schema: "Sales",
                table: "SalesOrderHeader_ondisk",
                column: "SalesPersonID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderHeaderSalesReason_SalesReasonID",
                schema: "Sales",
                table: "SalesOrderHeaderSalesReason",
                column: "SalesReasonID");

            migrationBuilder.CreateIndex(
                name: "AK_SalesPerson_rowguid",
                schema: "Sales",
                table: "SalesPerson",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesPerson_TerritoryID",
                schema: "Sales",
                table: "SalesPerson",
                column: "TerritoryID");

            migrationBuilder.CreateIndex(
                name: "AK_SalesPersonQuotaHistory_rowguid",
                schema: "Sales",
                table: "SalesPersonQuotaHistory",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_SalesTaxRate_rowguid",
                schema: "Sales",
                table: "SalesTaxRate",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_SalesTaxRate_StateProvinceID_TaxType",
                schema: "Sales",
                table: "SalesTaxRate",
                columns: new[] { "StateProvinceID", "TaxType" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesTerritory_CountryRegionCode",
                schema: "Sales",
                table: "SalesTerritory",
                column: "CountryRegionCode");

            migrationBuilder.CreateIndex(
                name: "AK_SalesTerritory_Name",
                schema: "Sales",
                table: "SalesTerritory",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_SalesTerritory_rowguid",
                schema: "Sales",
                table: "SalesTerritory",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_SalesTerritoryHistory_rowguid",
                schema: "Sales",
                table: "SalesTerritoryHistory",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesTerritoryHistory_TerritoryID",
                schema: "Sales",
                table: "SalesTerritoryHistory",
                column: "TerritoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_ProductID",
                schema: "Sales",
                table: "ShoppingCartItem",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_ShoppingCartID_ProductID",
                schema: "Sales",
                table: "ShoppingCartItem",
                columns: new[] { "ShoppingCartID", "ProductID" });

            migrationBuilder.CreateIndex(
                name: "AK_SpecialOffer_rowguid",
                schema: "Sales",
                table: "SpecialOffer",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpecialOfferProduct_ProductID",
                schema: "Sales",
                table: "SpecialOfferProduct",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "AK_SpecialOfferProduct_rowguid",
                schema: "Sales",
                table: "SpecialOfferProduct",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_ProductID",
                schema: "Sales",
                table: "SpecialOfferProduct_inmem",
                column: "ProductID")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "ix_ProductID",
                schema: "Sales",
                table: "SpecialOfferProduct_ondisk",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "PXML_Store_Demographics",
                schema: "Sales",
                table: "Store",
                column: "Demographics");

            migrationBuilder.CreateIndex(
                name: "AK_Store_rowguid",
                schema: "Sales",
                table: "Store",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Store_SalesPersonID",
                schema: "Sales",
                table: "Store",
                column: "SalesPersonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AWBuildVersion");

            migrationBuilder.DropTable(
                name: "DatabaseLog");

            migrationBuilder.DropTable(
                name: "DeviceCodes");

            migrationBuilder.DropTable(
                name: "ErrorLog");

            migrationBuilder.DropTable(
                name: "PersistedGrants");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "DemoSalesOrderDetailSeed",
                schema: "Demo")
                .Annotation("SqlServer:MemoryOptimized", true);

            migrationBuilder.DropTable(
                name: "DemoSalesOrderHeaderSeed",
                schema: "Demo")
                .Annotation("SqlServer:MemoryOptimized", true);

            migrationBuilder.DropTable(
                name: "Employee_Temporal",
                schema: "HumanResources");

            migrationBuilder.DropTable(
                name: "EmployeeDepartmentHistory",
                schema: "HumanResources");

            migrationBuilder.DropTable(
                name: "EmployeePayHistory",
                schema: "HumanResources");

            migrationBuilder.DropTable(
                name: "JobCandidate",
                schema: "HumanResources");

            migrationBuilder.DropTable(
                name: "BusinessEntityAddress",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "BusinessEntityContact",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "EmailAddress",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "Password",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "Person_json",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "Person_Temporal",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "PersonPhone",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "BillOfMaterials",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductCostHistory",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductInventory",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductListPriceHistory",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductModelIllustration",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductModelProductDescriptionCulture",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductProductPhoto",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductReview",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "TransactionHistory",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "TransactionHistoryArchive",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "WorkOrderRouting",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductVendor",
                schema: "Purchasing");

            migrationBuilder.DropTable(
                name: "PurchaseOrderDetail",
                schema: "Purchasing");

            migrationBuilder.DropTable(
                name: "CountryRegionCurrency",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "OrderTracking",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "PersonCreditCard",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesOrder_json",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesOrderDetail",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesOrderDetail_inmem",
                schema: "Sales")
                .Annotation("SqlServer:MemoryOptimized", true);

            migrationBuilder.DropTable(
                name: "SalesOrderDetail_ondisk",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesOrderHeaderSalesReason",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesPersonQuotaHistory",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesTaxRate",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesTerritoryHistory",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "ShoppingCartItem",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "TrackingEvent",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Department",
                schema: "HumanResources");

            migrationBuilder.DropTable(
                name: "Shift",
                schema: "HumanResources");

            migrationBuilder.DropTable(
                name: "AddressType",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "ContactType",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "PhoneNumberType",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "Illustration",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "Culture",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductDescription",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductPhoto",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "Location",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "WorkOrder",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "PurchaseOrderHeader",
                schema: "Purchasing");

            migrationBuilder.DropTable(
                name: "SpecialOfferProduct",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesOrderHeader_inmem",
                schema: "Sales")
                .Annotation("SqlServer:MemoryOptimized", true);

            migrationBuilder.DropTable(
                name: "SpecialOfferProduct_inmem",
                schema: "Sales")
                .Annotation("SqlServer:MemoryOptimized", true);

            migrationBuilder.DropTable(
                name: "SalesOrderHeader_ondisk",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SpecialOfferProduct_ondisk",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesOrderHeader",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesReason",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "ScrapReason",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "Vendor",
                schema: "Purchasing");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "SpecialOffer",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Product_inmem",
                schema: "Production")
                .Annotation("SqlServer:MemoryOptimized", true);

            migrationBuilder.DropTable(
                name: "SpecialOffer_inmem",
                schema: "Sales")
                .Annotation("SqlServer:MemoryOptimized", true);

            migrationBuilder.DropTable(
                name: "Product_ondisk",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "SpecialOffer_ondisk",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "CreditCard",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "CurrencyRate",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "ShipMethod",
                schema: "Purchasing");

            migrationBuilder.DropTable(
                name: "ProductModel",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductSubcategory",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "UnitMeasure",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "StateProvince",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "Currency",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Store",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "ProductCategory",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "SalesPerson",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Employee",
                schema: "HumanResources");

            migrationBuilder.DropTable(
                name: "SalesTerritory",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Person",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "CountryRegion",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "BusinessEntity",
                schema: "Person");

            migrationBuilder.AlterDatabase()
                .OldAnnotation("SqlServer:MemoryOptimized", true);
        }
    }
}
