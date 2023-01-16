using System;

namespace matrixNameSpace;

#pragma warning disable CS8618, CS1717, CS8603
class Matrix {
    private int rows, columns;
    private List<List<float>> array;

    private void swapSizes() {
        rows = rows ^ columns;
        columns = rows ^ columns;
        rows = rows ^ columns;
    }

    internal Matrix(int rows, int columns, List<List<float>> array) {
		this.rows = rows;
		this.columns = columns;
		this.array = array;
	}

    internal float getElement(int row, int column) {
		return array[row][column];
	}

    public Matrix(int rows, int columns) {
        this.rows = rows;
        this.columns = columns;
    }

    public Matrix fill() {
        array = new List<List<float>>();
        List<float> tempRow;
        for (int row = 0; row < rows; row++) {
            tempRow = new List<float>();
            for (int column = 0; column < columns; column++) {
                tempRow.Add(KeyboardGetter.getFloat($"{row + 1} row, {column + 1} column: "));
            }
            array.Add(tempRow);
        }
        this.array = array;
        return this;
    }

    public Matrix multiplByNum(float number) {
		List<List<float>> array = new List<List<float>>();
		List<float> tempRow;
		foreach (List<float> row in this.array) {
			tempRow = new List<float>();
			foreach (float num in row) {
				tempRow.Add(num * number);
			}
			array.Add(tempRow);
		}
		this.array = array;
		return this;
	}

    public Matrix transpose() {
        List<List<float>> array = new List<List<float>>();
        List<float> tempRow;
        for (int column = 0; column < columns; column++) {
            tempRow = new List<float>();
            for (int row = 0; row < rows; row++) {
                tempRow.Add(this.array[row][column]);
            }
            array.Add(tempRow);
        }
        swapSizes();
        this.array = array;
        return this;
    }

    public int Rows => rows;
    public int Columns => columns;

	public override string ToString() {
		if (rows == 0 || columns == 0)
			return "";
		string str = "";
		foreach (List<float> row in array) {
			foreach (float number in row) {
				str += number + " ";
			}
			str += "\n";
		}
		return str;
	}
}

class Operations {
    private const int NEGATIVE = -1;
    private const int POSITIVE = 1;
    private Matrix getSum(Matrix matrix1, Matrix matrix2, int factor) {
        if (matrix1.Rows != matrix2.Rows | matrix1.Columns != matrix2.Columns) return null;
        List<List<float>> array = new List<List<float>>();
        List<float> tempRow;
        for (int row = 0; row < matrix1.Rows; row++) {
			tempRow = new List<float>();
			for (int column = 0; column < matrix1.Columns; column++) {
				tempRow.Add(matrix1.getElement(row, column) + matrix2.getElement(row, column) * factor);
			}
			array.Add(tempRow);
		}
        return new Matrix(matrix1.Rows, matrix2.Columns, array);
    }

    public Matrix getSum(Matrix matrix1, Matrix matrix2) {
        return getSum(matrix1, matrix2, POSITIVE);
    }

    public Matrix getDiff(Matrix matrix1, Matrix matrix2) {
        return getSum(matrix1, matrix2, NEGATIVE);
    }

    public static Matrix getMultipl(Matrix matrix1, Matrix matrix2) {
		if (matrix1.Columns != matrix2.Rows) return null;
		List<List<float>> array = new List<List<float>>();
		List<float> tempRow;
		float temp;
		for (int row = 0; row < matrix1.Rows; row++) {
			tempRow = new List<float>();
			for (int column = 0; column < matrix2.Columns; column++) {
				temp = 0F;
				for (int i = 0; i < matrix1.Columns; i++) {
					temp += matrix1.getElement(row, i) * matrix2.getElement(i, column);
				}
				tempRow.Add(temp);
			}
			array.Add(tempRow);
		}
		return new Matrix(matrix1.Rows, matrix2.Columns, array);
	}
}

class KeyboardGetter {
    public static float getFloat(string msg) {
        Console.Write(msg);
        if (!float.TryParse(Console.ReadLine(), out float value)) {
            displayError();
            return getFloat(msg);
        }
        return value;
    }
    
    private static void displayError() {
        Console.WriteLine("[ERROR] Enter a float value!");
    }
}