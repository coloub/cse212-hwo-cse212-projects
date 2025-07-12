using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add items with different priorities and dequeue them to verify highest priority comes first
    // Expected Result: Items should be dequeued in priority order (highest first), regardless of insertion order
    // Defect(s) Found: 1) Loop in Dequeue didn't check last item (< _queue.Count - 1 instead of < _queue.Count)
    // 2) Item was not actually removed from queue after being found
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        
        // Add items with different priorities (not in priority order)
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 5);
        priorityQueue.Enqueue("Medium", 3);
        priorityQueue.Enqueue("Highest", 10);
        
        // Should dequeue in priority order (highest first)
        Assert.AreEqual("Highest", priorityQueue.Dequeue());
        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add items with same priority and verify FIFO behavior for equal priorities
    // Expected Result: When priorities are equal, first item added should be dequeued first
    // Defect(s) Found: Same defects as Test 1 - loop boundary and missing removal
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        
        // Add items with same priority
        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 5);
        
        // Should maintain FIFO order for equal priorities
        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Test dequeuing from empty queue
    // Expected Result: Should throw InvalidOperationException with appropriate message
    // Defect(s) Found: No defects expected - this should work correctly
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();
        
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail($"Unexpected exception of type {e.GetType()} caught: {e.Message}");
        }
    }

    [TestMethod]
    // Scenario: Test with negative priorities
    // Expected Result: Higher numbers should still have higher priority (including negative numbers)
    // Defect(s) Found: Same defects as Test 1
    public void TestPriorityQueue_NegativePriorities()
    {
        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue("VeryLow", -10);
        priorityQueue.Enqueue("Low", -5);
        priorityQueue.Enqueue("High", 0);
        priorityQueue.Enqueue("Highest", 3);
        
        // Should dequeue in priority order (highest number first)
        Assert.AreEqual("Highest", priorityQueue.Dequeue());
        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
        Assert.AreEqual("VeryLow", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Test single item queue
    // Expected Result: Single item should be dequeued successfully
    // Defect(s) Found: This test specifically checks if the last item bug is fixed
    public void TestPriorityQueue_SingleItem()
    {
        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue("OnlyItem", 42);
        
        Assert.AreEqual("OnlyItem", priorityQueue.Dequeue());
        
        // Verify queue is now empty
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown for empty queue.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

    [TestMethod]
    // Scenario: Test mixed enqueue/dequeue operations
    // Expected Result: Should handle dynamic additions and removals correctly
    // Defect(s) Found: Same defects as Test 1 - affects dynamic operations
    public void TestPriorityQueue_MixedOperations()
    {
        var priorityQueue = new PriorityQueue();
        
        // Add initial items
        priorityQueue.Enqueue("Medium", 5);
        priorityQueue.Enqueue("Low", 1);
        
        // Dequeue highest priority
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        
        // Add more items
        priorityQueue.Enqueue("High", 10);
        priorityQueue.Enqueue("VeryHigh", 15);
        
        // Dequeue in priority order
        Assert.AreEqual("VeryHigh", priorityQueue.Dequeue());
        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Test with zero priority
    // Expected Result: Zero priority should be handled correctly in comparison with negative and positive
    // Defect(s) Found: Same defects as Test 1
    public void TestPriorityQueue_ZeroPriority()
    {
        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue("Negative", -1);
        priorityQueue.Enqueue("Zero", 0);
        priorityQueue.Enqueue("Positive", 1);
        
        Assert.AreEqual("Positive", priorityQueue.Dequeue());
        Assert.AreEqual("Zero", priorityQueue.Dequeue());
        Assert.AreEqual("Negative", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Test ToString method works correctly
    // Expected Result: Should display queue contents in insertion order with priorities
    // Defect(s) Found: No defects expected for ToString, but queue operations might affect it
    public void TestPriorityQueue_ToString()
    {
        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue("First", 1);
        priorityQueue.Enqueue("Second", 2);
        
        string result = priorityQueue.ToString();
        
        // Should show items in insertion order
        Assert.IsTrue(result.Contains("First (Pri:1)"));
        Assert.IsTrue(result.Contains("Second (Pri:2)"));
    }
}