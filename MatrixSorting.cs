namespace SortingAlgorithms;

public class MatrixSorting
{
    public int[,] Sort(int[,] input)
    {
        if (input == null)
        {
            throw new ArgumentNullException(nameof(input), "Input matrix cannot be null.");
        }

        int rows = input.GetLength(0);
        int cols = input.GetLength(1);

        // Збираємо елементи над головною діагоналлю, які не належать побічній діагоналі
        List<int> elements = new List<int>();
        for (int i = 0; i < rows; i++)
        {
            for (int j = i + 1; j < cols; j++) // Елементи над головною діагоналлю
            {
                if (i + j != cols - 1) // Не побічна діагональ
                {
                    elements.Add(input[i, j]);
                }
            }
        }

        // Сортуємо зібрані елементи методом змішування
        int[] sortedElements = CocktailShakerSort(elements.ToArray());

        // Повертаємо відсортовані елементи назад у матрицю
        int index = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = i + 1; j < cols; j++)
            {
                if (i + j != rows - 1)
                {
                    // вставляє елемент і додає 1 до індекса переходячи до наступного елементу
                    input[i, j] = sortedElements[index++];
                }
            }
        }

        return input;
    }

    private int[] CocktailShakerSort(int[] array)
    {
        // ця змінна показує чи були проходи в останньому циклі і якщо не було значить він відсортований
        bool swapped = true;
        int start = 0;
        int end = array.Length - 1;

        while (swapped)
        {
            swapped = false;

            // Прохід зліва направо
            for (int i = start; i < end; i++)
            {
                if (array[i] > array[i + 1])
                {
                    Swap(ref array[i], ref array[i + 1]);
                    swapped = true;
                }
            }

            // Якщо не було обмінів, виходимо
            if (!swapped)
            {
                break;
            }

            swapped = false;
            end--;

            // Прохід справа наліво
            for (int i = end; i > start; i--)
            {
                if (array[i] < array[i - 1])
                {
                    Swap(ref array[i], ref array[i - 1]);
                    swapped = true;
                }
            }

            start++;
        }

        return array;
    }

    private void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
}
       

    