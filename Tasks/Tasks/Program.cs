public class IntArrayList
{
    private int[] _buffer;
    private int _count;
    private int _capacity;
    private const int DEFAULT_CAPACITY = 2;

    public int Count => _count;
    public int Capacity => _capacity;

    public int this[int index]
    {
        get => _buffer[index];
        set => _buffer[index] = value;
    }

    public IntArrayList()
    {
        _buffer = new int[DEFAULT_CAPACITY];
        _capacity = DEFAULT_CAPACITY;
        _count = 0;
    }

    public IntArrayList(int initialCapacity)
    {
        if (initialCapacity > 0)
        {
            _capacity = initialCapacity;
        }
        else
        {
            _capacity = DEFAULT_CAPACITY;
        }
        _buffer = new int[_capacity];
        _count = 0;
    }

    public void PushBack(int value)
    {
        if (_count >= _capacity)
        {
            Resize(_capacity * 2);
        }
        _buffer[_count++] = value;
    }

    public void PopBack()
    {
        if (_count > 0)
        {
            _count--;
        }
    }

    public bool TryInsert(int index, int value)
    {
        if (index < 0 || index > _count)
        {
            return false;
        }

        if (_count >= _capacity)
        {
            Resize(_capacity * 2);
        }

        for (int i = _count; i > index; i--)
        {
            _buffer[i] = _buffer[i - 1];
        }

        _buffer[index] = value;
        _count++;
        return true;
    }

    public bool TryErase(int index)
    {
        if (index < 0 || index >= _count)
        {
            return false;
        }

        for (int i = index; i < _count - 1; i++)
        {
            _buffer[i] = _buffer[i + 1];
        }

        _count--;
        return true;
    }

    public bool TryGetAt(int index, out int result)
    {
        if (index < 0 || index >= _count)
        {
            result = 0;
            return false;
        }

        result = _buffer[index];
        return true;
    }

    public void Clear()
    {
        _count = 0;
    }

    public bool TryForceCapacity(int newCapacity)
    {
        if (newCapacity < 0)
        {
            return false;
        }

        if (newCapacity < _count)
        {
            _count = newCapacity;
        }

        Resize(newCapacity);
        return true;
    }

    public int Find(int value)
    {
        for (int i = 0; i < _count; i++)
        {
            if (_buffer[i] == value)
            {
                return i;
            }
        }
        return -1;
    }

    private void Resize(int newCapacity)
    {
        int[] newBuffer = new int[newCapacity];
        for (int i = 0; i < _count; i++)
        {
            newBuffer[i] = _buffer[i];
        }
        _buffer = newBuffer;
        _capacity = newCapacity;
    }
}