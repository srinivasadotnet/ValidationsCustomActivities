# Validations Custom Activities
Custom Validation framework for UI Path which can be used by UI Path developer to reduce the effort of data validation. 

In the process flow developers need to deal with lot of data, some times it may be from spread sheet, pushed spread sheet data to DataTable, iterate through DataTable and fill the form. 

? What happens when spread sheet contains bad data

? What happens when required fields in a form are empty

These scenarios will happens in the prod environments, because in the test environment we (developers) always use to work with good test data, which will never gives errors. ;-)

To prevent bad data, it is better to validate it before proceeding to next step. 

This ValidationsCustomActivities will help developer to validate DataTable data. Which contains 3 Activities. 

Also available as nuget package. 

## Requirements

Visual Studio 2017 required to compile this binary.

## Activities

- Is Valid Data
- Get Valid Records
- Get Invalid Records

### Is Valid Data

IsValidData Activity is responsible to verify whether given data is correct or not. This Activity will take two parameters as input and return two parameters as output.

##### Input Parameters :

*RequiredFields*   :  semicolon (';') separated required column names 

*ValidationData* :  input data in DataTable format

##### Output Parameters:

*ResultMessage* :  Based on given input DataTable and required columns returns either error message or success message.

*IsValidDataTable* :  If all given required column names contains data returns true else false.

### Get Valid Records

GetValidRecords Activity is responsible for filtering only valid records. This Activity will take two parameters as input and return one parameter as output.

##### Input Parameters :

*RequiredFields*   :  semicolon (';') separated required column names 

*ValidationData* :  input data in DataTable format

##### Output Parameters:

*ValidDataTable* :  Based on given input DataTable and required columns returns only valid records.

### Get Invalid Records

GetInvalidRecords Activity is responsible for filtering only invalid records. This Activity will take two parameters as input and return one parameter as output.

##### Input Parameters :

*RequiredFields*   :  semicolon (';') separated required column names 

*ValidationData* :  input data in DataTable format

##### Output Parameters:

*ValidDataTable* :  Based on given input DataTable and required columns returns only invalid records.



## Example table

| ID   | Name  | Age  | Salary |
| ---- | ----- | ---- | ------ |
| 1    | John  | 23   | 23000  |
| 2    | Smith |      | 21000  |
| 3    | Jane  | 21   | 23000  |
| 4    |       |      | 24000  |

* consider "Name" and "Age" columns are required for our process

* RequiredFields = "Name;Age" (User should pass required fields like this)
* Consider above table is given as input datatable

IsValidData : will return "false" as datatable contains some invalid data and it will give error message as 

 '(Name : 1 Rows Invalid);(Age : 2 Rows Invalid)' fields contains Invalid data

GetValidRecords: will return only valid records datatable

| ID   | Name | Age  | Salary |
| ---- | ---- | ---- | ------ |
| 1    | John | 23   | 23000  |
| 3    | Jane | 21   | 23000  |

GetInvalidRecords: will return only invalid records, this will help developer to report bad data to customer.

| ID   | Name  | Age  | Salary |
| ---- | ----- | ---- | ------ |
| 2    | Smith |      | 21000  |
| 4    |       |      | 24000  |

As "Name" and "Age" columns given as required fields, custom validator will return records with missing data.