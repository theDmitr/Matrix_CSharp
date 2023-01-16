# Matrix

This library will help you work with matrices, fill them in and perform operations on them.

## Tutorial

To create a matrix object, you need to initialize it, call the constructor from the "Matrix" class.
The constructor method takes 2 required arguments — the number of rows and columns of the created matrix.

```cs
Matrix matrix = new Matrix(rows, columns);
```

### Methods of the Matrix class

| Method | Assignment | Use |
| - | - | - |
| fill | Filling the Matrix with a Scanner. | ```matrix.fill();``` |
| getRows | Returns the number of matrix rows. | ```matrix.getRows();``` |
| getColumns | Returns the number of matrix columns.  | ```matrix.getColumns();``` |
| multiplByNum | Multiplying a matrix by a number. Returns a matrix.  | ```matrix.multiplByNum(number);``` |
| transpose | Matrix transposition. Returns a matrix.  | ```matrix.transpose();``` |

## Operations

This class is designed to automate operations on matrices.

### Methods of the Operations class
| Method | Assignment | Use |
| - | - | - |
| getSum | The simple sum of two matrices. In case of size mismatch, ```null``` will be returned. If everything is OK, then the Matrix object is returned. | ```Operations.getSum(matrix1, matrix2);``` |
| getDiff | The simple difference of two matrices. In case of size mismatch, ```null``` will be returned. If everything is OK, then the Matrix object is returned. | ```Operations.getDiff(matrix1, matrix2);``` |
| getMultipl | Multiplication of two matrices. If the size does not match, ```null``` will be returned, if everything is in order - an object of the Matrix class. | ```Operations.getMultipl(matrix1, matrix2);``` |
