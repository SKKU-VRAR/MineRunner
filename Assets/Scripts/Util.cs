using System;

public static class Util
{
    /// <summary>
    ///     <paramref name="arr"/>의 <paramref name="range"/> 만큼을 <paramref name="value"/>로 채웁니다.
    /// </summary>
    /// <param name="arr">내용을 채우려는 배열입니다.</param>
    /// <param name="value">배열에 채울 원소입니다.</param>
    /// <param name="range">
    ///     수정할 범위를 나타내는 튜플입니다.
    ///     range가 (from, to)인 경우, <paramref name="arr"/>는 from부터 (to - 1)까지 수정됩니다.
    ///     from이 to보다 작거나 같은 경우 <paramref name="arr"/>는 수정되지 않습니다.
    ///     지정되지 않으면 처음부터 끝까지 배열을 <paramref name="value"/>로 채웁니다.
    /// </param>
    public static void Fill<T>(this T[] arr, T value,
                               (int from, int to) range = default)
    {
        arr.Fill(_ => value, range);
    }

    /// <summary>
    ///     <paramref name="arr"/>의 <paramref name="range"/> 만큼을 <paramref name="func"/>의 반환값으로 채웁니다.
    /// </summary>
    /// <param name="arr">내용을 채우려는 배열입니다.</param>
    /// <param name="func">인덱스를 받아 배열에 채울 원소를 반환하는 함수입니다.</param>
    /// <param name="range">
    ///     수정할 범위를 나타내는 튜플입니다.
    ///     range가 (from, to)인 경우, <paramref name="arr"/>는 from부터 (to - 1)까지 수정됩니다.
    ///     from이 to보다 작거나 같은 경우 <paramref name="arr"/>는 수정되지 않습니다.
    ///     지정되지 않으면 처음부터 끝까지 배열을 <paramref name="func"/>로 채웁니다.
    /// </param>
    public static void Fill<T>(this T[] arr, Func<int, T> func,
                               (int from, int to) range = default)
    {
        if (range == default)
            range = new ValueTuple<int, int>(0, arr.Length);

        for (int i = range.from; i < range.to; i++)
            arr[i] = func(i);
    }

    /// <summary>
    ///     2차원 배열 <paramref name="arr"/>의 사각 영역을 <paramref name="value"/>로 채웁니다.
    /// </summary>
    /// <param name="arr">내용을 채우려는 배열입니다.</param>
    /// <param name="value">배열에 채울 원소입니다.</param>
    /// <param name="first">첫번째 차원에 대한 범위를 나타내는 튜플입니다.</param>
    /// <param name="second">첫번째 차원에 대한 범위를 나타내는 튜플입니다.</param>
    /// <seealso cref="Fill{T}(T[],T,(int from, int to))"/>
    public static void Fill<T>(this T[,] arr, T value,
                               (int from, int to) first = default,
                               (int from, int to) second = default)
    {
        arr.Fill(_ => value, first, second);
    }

    /// <summary>
    ///     2차원 배열 <paramref name="arr"/>의 사각 영역을 <paramref name="func"/>의 반환값으로 채웁니다.
    /// </summary>
    /// <param name="arr">내용을 채우려는 배열입니다.</param>
    /// <param name="func">좌표를 받아 배열에 채울 원소를 반환하는 함수입니다.</param>
    /// <param name="first">첫번째 차원에 대한 범위를 나타내는 튜플입니다.</param>
    /// <param name="second">첫번째 차원에 대한 범위를 나타내는 튜플입니다.</param>
    /// <seealso cref="Fill{T}(T[], Func{int, T}, (int, int))"/>
    public static void Fill<T>(this T[,] arr,
                               Func<(int x, int y), T> func,
                               (int from, int to) first = default,
                               (int from, int to) second = default)
    {
        if (first == default)
            first = (0, arr.GetLength(0));

        if (second == default)
            second = (0, arr.GetLength(1));

        for (int i = first.from; i < first.to; i++)
            for (int j = second.from; j < second.to; j++)
                arr[i, j] = func((i, j));
    }
}
