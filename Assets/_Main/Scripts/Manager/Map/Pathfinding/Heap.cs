public class Heap<T> where T : IHeapItem<T>
{
    T[] items;
    int count;

    public Heap(int lenght)
    {
        items = new T[lenght];
    }

    public void Add(T item)
    {
        item.Index = count;
        items[count] = item;
        SortUp(item);
        count++;
    }

    public T GetAndRemoveFirst()
    {
        T item = items[0];
        count--;
        items[0] = items[count];
        items[0].Index = 0;
        SortDown(items[0]);
        return item;
    }

    public void UpdateItem(T item)
    {
        SortUp(item);
    }

    private void SortUp(T item)
    {
        int parentIndex = (item.Index - 1) / 2;

        while (true)
        {
            T parent = items[parentIndex];

            if (item.CompareTo(parent) > 0)
            {
                Swap(item, parent);
            }
            else
                break;

            parentIndex = (item.Index - 1) / 2;
        }
    }

    private void SortDown(T item)
    {
        while (true)
        {
            int childLeftIndex = item.Index * 2 + 1;
            int childRightIndex = item.Index * 2 + 2;
            int swapIndex = 0;

            if (childLeftIndex < count)
            {
                swapIndex = childLeftIndex;

                if (childRightIndex < count)
                {
                    if (items[childLeftIndex].CompareTo(items[childRightIndex]) < 0)
                        swapIndex = childRightIndex;
                }

                if (item.CompareTo(items[swapIndex]) < 0)
                    Swap(item ,items[swapIndex]);
                else
                    return;
            }
            else
                return;
        }
    }

    private void Swap(T itemA, T itemB)
    {
        items[itemA.Index] = itemB;
        items[itemB.Index] = itemA;
        int index = itemA.Index;
        itemA.Index = itemB.Index;
        itemB.Index = index;
    }

    public bool Contains(T item)
    {
        return Equals(items[item.Index], item);
    }

    public int Count => count;
}