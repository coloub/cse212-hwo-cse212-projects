/// <summary>
/// A basic implementation of a Queue
/// </summary>
public class PersonQueue
{
    private readonly List<Person> _queue = new();

    public int Length => _queue.Count;

    /// <summary>
    /// Add a person to the queue
    /// </summary>
    /// <param name="person">The person to add</param>
    public void Enqueue(Person person)
    {
        // Fixed: Add to the back of the queue (end of list) to maintain FIFO behavior
        // Previously was inserting at index 0 (front), which violated FIFO principles
        _queue.Add(person);
    }

    public Person Dequeue()
    {
        // Remove and return the person from the front of the queue (index 0)
        var person = _queue[0];
        _queue.RemoveAt(0);
        return person;
    }

    public bool IsEmpty()
    {
        return Length == 0;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}