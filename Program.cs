using System.Collections;

var list = new SingleLinkedList<string>();

list.AddToFront("x");
list.AddToFront("y");
list.AddToFront("z");
list.Add("a");
list.Add("b");

foreach (var item in list)
{
    Console.WriteLine(item);
}

Console.ReadKey();

public interface ILinkedList<T> : ICollection<T>
{
    void AddToFront(T item);
    void AddToEnd(T item);
}

public class SingleLinkedList<T> : ILinkedList<T?>
{

    private Node<T> _head;
    private int _count;
    public int Count => _count;

    public bool IsReadOnly => false;

    public void Add(T? item)
    {
        AddToEnd(item);
    }

    public void AddToEnd(T? item)
    {
        var newNode = new Node<T>(item);
        if (_head is null)
        {
            _head = newNode;
        }
        else
        {
            var chain = GetNode().Last();
            chain.Next = newNode;
        }
        ++_count;
    }

    public void AddToFront(T? item)
    {
        var newHead = new Node<T>(item)
        {
            Next = _head
        };
        _head = newHead;
        ++_count;
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(T? item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(T?[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }
    public bool Remove(T? item)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<T?> GetEnumerator()
    {
        foreach (var node in GetNode())
        {
            yield return node.Value;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private IEnumerable<Node<T>> GetNode()
    {
        if (_head is null)
        {
            yield break;
        }

        Node<T> current = _head;
        while (current is not null)
        {
            yield return current;
            current = current.Next;
        }
    }
}

public class Node<T>
{
    public T? Value { get; set; }
    public Node<T>? Next { get; set; }

    public Node(T? value)
    {
        Value = value;
    }

    public override string ToString() => $"Value: {Value}" + $"Next: {(Next is null ? "null" : Next.Value)}";
}


