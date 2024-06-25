namespace domain;

public static class Utils
{
    public static void InsertItem<T>(ref T[] array, int index, T value)
    {
        for (int i = array.Length - 1; i > index; --i) { array[i] = array[i - 1]; }

        array[index] = value;
    }
}